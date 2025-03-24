using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.Export
{
    public class ExportResultEventArgs : EventArgs
    {
        public float Time { get; set; }
        public string ResName { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public Objects ExportObj {get; set;}
        public ExportType ExportType { get; set; }


        public ExportResultEventArgs(float time, string resName, string path, string extension, Objects exportObj, ExportType exportType)
        {
            Time = time;
            ResName = resName;
            Path = path;
            Extension = extension;
            ExportObj = exportObj;
            ExportType = exportType;
        }
    }
}
