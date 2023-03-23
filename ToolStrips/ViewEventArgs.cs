using System;

namespace ToolStrips
{
    public class ViewEventArgs : EventArgs
    {
        public ViewEventArgs(string btnName, bool btnStatus)
        {
            BtnName = btnName;
            BtnStatus = btnStatus;
        }

        public string BtnName { get; }
        public bool BtnStatus { get; }
    }
}