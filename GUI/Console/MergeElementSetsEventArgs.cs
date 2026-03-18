using System;

namespace BazisGUI.Console
{
    public class MergeElementSetsEventArgs : EventArgs
    {
        public string ObjType { get; }
        public string MasterSet { get; }
        public string SlaveSet { get; }

        public MergeElementSetsEventArgs(string v1, string v2, string v3)
        {
            ObjType = v1;
            MasterSet = v2;
            SlaveSet = v3;
        }
    }
}