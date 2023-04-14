using System;

namespace ConnectionModule
{
    public class StartLicenseEventArgs : EventArgs
    {
        public string Type { get; }
        public string Value { get; }
        public StartLicenseEventArgs(string licenseType, string licenseParam)
        {
            Type = licenseType;
            Value = licenseParam;
        }
    }
}