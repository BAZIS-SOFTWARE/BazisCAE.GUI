using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BazisGUI.Interfaces.GeneralParams;

namespace BazisGUI.Results.Export
{
    public class CopyResultDBEventArgs : EventArgs
    {
        public float Time { get; }
        public string DirPath { get; }
        public Objects ExportObj { get; }

        public CopyResultDBEventArgs(float time, string dirPath, Objects exportObj)
        {
            Time = time;
            DirPath = dirPath;
            ExportObj = exportObj;
        }
    }
}
