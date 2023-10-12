using System;

namespace BaseModule.ToolStrips
{
    public class SelectObjectEventArgs : EventArgs
    {
        public string ObjsType {get;}
        public SelectObjectEventArgs(string objsType)
        {
            ObjsType = objsType;
        }
    }
}