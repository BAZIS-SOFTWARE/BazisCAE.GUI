[CmdletBinding()]
param(
    [string]$GmshApiSourceDirectory = (Join-Path $PSScriptRoot '../../../CoreSolution/GmshApi'),
    [string]$OutputDirectory = (Join-Path $PSScriptRoot '../../artifacts/linux-x64-bundle')
)

$ErrorActionPreference = 'Stop'
$repo = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../..'))
$OutputDirectory = [IO.Path]::GetFullPath($OutputDirectory)
$GmshApiSourceDirectory = [IO.Path]::GetFullPath($GmshApiSourceDirectory)
if (!(Test-Path -LiteralPath (Join-Path $GmshApiSourceDirectory 'Wrapper/Occ.cs'))) {
    throw "GmshApi sources not found: $GmshApiSourceDirectory"
}
if (Test-Path -LiteralPath $OutputDirectory) {
    throw "Choose a new output directory; existing output is preserved: $OutputDirectory"
}

$version = '4.13.1'
$sdkRoot = "gmsh-$version-Linux64-sdk"
$url = "https://gmsh.info/bin/Linux/$sdkRoot.tgz"
$expectedHash = 'E42B27ECF81D5BB2B7C34F166A78C3C864EF2198BEA1AAEBD942E188F4BF6941'
$cache = Join-Path $repo 'artifacts/native-cache'
New-Item -ItemType Directory -Force -Path $cache | Out-Null
$archive = Join-Path $cache "$sdkRoot.tgz"
if (!(Test-Path -LiteralPath $archive)) {
    Invoke-WebRequest -Uri $url -OutFile $archive
}
if ((Get-FileHash -LiteralPath $archive -Algorithm SHA256).Hash -ne $expectedHash) {
    throw "Gmsh SDK checksum mismatch: $archive"
}

$stage = Join-Path $cache ('build-' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $stage | Out-Null
& tar -xzf $archive -C $stage "$sdkRoot/lib/libgmsh.so.$version" "$sdkRoot/include/gmshc.h" "$sdkRoot/share/doc/gmsh/LICENSE.txt" "$sdkRoot/README.txt"
if ($LASTEXITCODE -ne 0) { throw 'Cannot extract Gmsh SDK.' }

# Build the existing wrapper sources with the Linux loader, keeping the signed assembly identity.
$wrapper = Join-Path $stage 'GmshApi'
New-Item -ItemType Directory -Path $wrapper | Out-Null
Copy-Item -LiteralPath (Join-Path $GmshApiSourceDirectory 'Wrapper') -Destination $wrapper -Recurse
Copy-Item -LiteralPath (Join-Path $GmshApiSourceDirectory 'ElementProperties.cs') -Destination $wrapper
Copy-Item -LiteralPath (Join-Path $GmshApiSourceDirectory 'GmshApiKey.snk') -Destination $wrapper
Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'GmshKernel.cs') -Destination $wrapper

# Gmsh 4.12+ added the center flag before ierr. Preserve the wrapper's center-point semantics.
$occFile = Join-Path $wrapper 'Wrapper/Occ.cs'
$occ = Get-Content -LiteralPath $occFile -Raw
$oldDelegate = 'gmshModelOccAddCircleArcFun(int startTag, int centerTag, int endTag, int tag, ref int ierr)'
$oldCall = 'gmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, ref ierr)'
if (!$occ.Contains($oldDelegate) -or !$occ.Contains($oldCall)) {
    throw 'Occ.cs changed: review the AddCircleArc ABI patch before packaging.'
}
$occ = $occ.Replace($oldDelegate, 'gmshModelOccAddCircleArcFun(int startTag, int centerTag, int endTag, int tag, int center, ref int ierr)')
$occ = $occ.Replace($oldCall, 'gmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, 1, ref ierr)')
[IO.File]::WriteAllText($occFile, $occ)
$wrapperProject = Join-Path $wrapper 'GmshApi.csproj'
[IO.File]::WriteAllText($wrapperProject, @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Version>3.2.1</Version>
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>GmshApiKey.snk</AssemblyOriginatorKeyFile>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="GmshKernel.cs;ElementProperties.cs;Wrapper/**/*.cs" Exclude="Wrapper/Interfaces/**/*.cs" />
  </ItemGroup>
</Project>
'@)
& dotnet build $wrapperProject -c Release -m:1 -p:NuGetAudit=false -v minimal
if ($LASTEXITCODE -ne 0) { throw 'Linux GmshApi build failed.' }

$project = Join-Path $repo 'BazisAvaloniaGUI/BazisAvaloniaGUI.csproj'
& dotnet publish $project -c Release -r linux-x64 --self-contained true -m:1 -p:UseBazisCoreSource=false -p:NuGetAudit=false -o $OutputDirectory -v minimal
if ($LASTEXITCODE -ne 0) { throw 'Linux publication failed.' }
$publishedWrapper = Join-Path $OutputDirectory 'GmshApi.dll'
$linuxWrapper = Join-Path $wrapper 'bin/Release/net8.0/GmshApi.dll'
if ([Reflection.AssemblyName]::GetAssemblyName($publishedWrapper).FullName -ne [Reflection.AssemblyName]::GetAssemblyName($linuxWrapper).FullName) {
    throw 'GmshApi assembly identity changed; review dependencies before packaging.'
}
$oldContext = [System.Runtime.Loader.AssemblyLoadContext]::new('gmsh-original-' + [Guid]::NewGuid(), $true)
$linuxContext = [System.Runtime.Loader.AssemblyLoadContext]::new('gmsh-linux-' + [Guid]::NewGuid(), $true)
try {
    $originalStream = [IO.MemoryStream]::new([IO.File]::ReadAllBytes($publishedWrapper))
    $linuxStream = [IO.MemoryStream]::new([IO.File]::ReadAllBytes($linuxWrapper))
    try {
        $originalAssembly = $oldContext.LoadFromStream($originalStream)
        $linuxAssembly = $linuxContext.LoadFromStream($linuxStream)
    } finally {
        $originalStream.Dispose()
        $linuxStream.Dispose()
    }
    foreach ($type in $originalAssembly.GetExportedTypes()) {
        $replacement = $linuxAssembly.GetType($type.FullName)
        if (!$replacement) { throw "Missing public type: $($type.FullName)" }
        $methods = @($replacement.GetMethods() | ForEach-Object ToString)
        foreach ($method in $type.GetMethods()) {
            if ($method.ToString() -notin $methods) { throw "Missing public method: $($type.FullName).$method" }
        }
    }
    $header = Get-Content -LiteralPath (Join-Path $stage "$sdkRoot/include/gmshc.h") -Raw
    foreach ($type in $linuxAssembly.GetTypes() | Where-Object { $_.BaseType -eq [MulticastDelegate] }) {
        $function = $type.Name -replace 'Fun$', ''
        $signature = [regex]::Match($header, '\b' + $function + '\s*\(([^;]+)\);')
        if (!$signature.Success -or ($signature.Groups[1].Value -split ',').Count -ne $type.GetMethod('Invoke').GetParameters().Count) {
            throw "Native signature changed: $function"
        }
    }
} finally {
    $oldContext.Unload()
    $linuxContext.Unload()
}
Copy-Item -LiteralPath $linuxWrapper -Destination $publishedWrapper
Copy-Item -LiteralPath (Join-Path $stage "$sdkRoot/lib/libgmsh.so.$version") -Destination (Join-Path $OutputDirectory 'libgmsh.so')
foreach ($name in @('start-bazis.sh', 'check-dependencies.sh', 'README.md')) {
    # Linux scripts must also work from a Windows checkout with CRLF conversion.
    $content = (Get-Content -LiteralPath (Join-Path $PSScriptRoot $name) -Raw).Replace("`r`n", "`n")
    [IO.File]::WriteAllText((Join-Path $OutputDirectory $name), $content)
}
$licenses = Join-Path $OutputDirectory 'licenses/gmsh'
New-Item -ItemType Directory -Force -Path $licenses | Out-Null
Copy-Item -LiteralPath (Join-Path $stage "$sdkRoot/share/doc/gmsh/LICENSE.txt") -Destination $licenses
Copy-Item -LiteralPath (Join-Path $stage "$sdkRoot/README.txt") -Destination $licenses
@{
    runtime = 'linux-x64'
    gmshVersion = $version
    gmshSdkUrl = $url
    gmshSdkSha256 = $expectedHash
    gmshLibrarySha256 = (Get-FileHash (Join-Path $OutputDirectory 'libgmsh.so')).Hash
    gmshApiSourceDirectory = $GmshApiSourceDirectory
    gmshApiSourceSha256 = (Get-FileHash (Join-Path $GmshApiSourceDirectory 'Wrapper/Occ.cs')).Hash
    gmshApiPatches = @('NativeLibrary loader', 'AddCircleArc center flag')
    linuxRuntimeVerified = $false
} | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $OutputDirectory 'linux-bundle.json') -Encoding utf8

# Set Unix execute bits explicitly; a tar created from Windows file modes loses them.
$bundleArchive = "$OutputDirectory.tar.gz"
$fileStream = [IO.File]::Create($bundleArchive)
$gzip = [IO.Compression.GZipStream]::new($fileStream, [IO.Compression.CompressionLevel]::Fastest)
$writer = [System.Formats.Tar.TarWriter]::new($gzip, $true)
try {
    foreach ($file in Get-ChildItem -LiteralPath $OutputDirectory -File -Recurse) {
        $relative = [IO.Path]::GetRelativePath($OutputDirectory, $file.FullName).Replace('\', '/')
        $entry = [System.Formats.Tar.PaxTarEntry]::new([System.Formats.Tar.TarEntryType]::RegularFile, "BazisGUI/$relative")
        $entry.Mode = [IO.UnixFileMode]$(if ($file.Name -eq 'BazisAvaloniaGUI' -or $file.Extension -eq '.sh') { 493 } else { 420 })
        $inputStream = [IO.File]::OpenRead($file.FullName)
        try {
            $entry.DataStream = $inputStream
            $writer.WriteEntry($entry)
        } finally { $inputStream.Dispose() }
    }
} finally {
    $writer.Dispose()
    $gzip.Dispose()
    $fileStream.Dispose()
}
Write-Output "Linux bundle: $OutputDirectory"
Write-Output "Archive: $bundleArchive"
Write-Output 'Run check-dependencies.sh and start-bazis.sh on the target Linux machine.'
