using System;

namespace Selector
{
    public class SelectInDirectionEventArgs : EventArgs
    {
        public string ObjsType { get; }

        public bool Reverse { get; }

        public SelectInDirectionEventArgs(string objsType, bool reverse)
        {
            ObjsType = objsType;
            Reverse = reverse;
        }
    }
}