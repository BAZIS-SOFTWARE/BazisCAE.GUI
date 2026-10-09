#!/usr/bin/env bash
set -euo pipefail
app_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
export LD_LIBRARY_PATH="$app_dir${LD_LIBRARY_PATH:+:$LD_LIBRARY_PATH}"
status=0
for library in "$app_dir"/*.so* "$app_dir/SQLite.Interop.dll" "$app_dir/BazisAvaloniaGUI"; do
    [[ -f "$library" ]] || { echo "Missing file: $library"; status=1; continue; }
    # The .NET LTTng provider is optional and loaded only when native tracing is enabled.
    [[ "$(basename -- "$library")" == 'libcoreclrtraceptprovider.so' ]] && continue
    if ! result=$(ldd "$library" 2>&1); then
        printf '%s\n%s\n' "$library" "$result"
        status=1
    elif [[ "$result" == *"not found"* ]]; then
        printf '%s\n%s\n' "$library" "$result"
        status=1
    fi
done
if [[ $status -eq 0 ]]; then
    echo "All packaged native libraries resolve their dependencies."
fi
exit "$status"
