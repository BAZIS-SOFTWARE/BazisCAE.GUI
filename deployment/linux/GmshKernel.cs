using System;
using System.Runtime.InteropServices;

namespace GmshApi
{
    // Preserve the API used by OperationalController 4.10.7 while loading Linux ELF libraries.
    public static class GmshKernel
    {
        public static IntPtr DLL { get; set; }

        public static IntPtr LoadLibrary(string libraryPath) => NativeLibrary.Load(libraryPath);

        public static IntPtr GetProcAddress(IntPtr handle, string procedureName) => NativeLibrary.GetExport(handle, procedureName);

        public static T GetFunction<T>(string functionName)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(GetProcAddress(DLL, functionName));
        }
    }
}
