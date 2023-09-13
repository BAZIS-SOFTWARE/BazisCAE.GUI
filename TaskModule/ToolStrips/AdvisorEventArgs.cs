using System;

namespace TaskModule.ToolStrips
{
    public class AdvisorEventArgs : EventArgs
    {

        public AdvisorEventArgs(string advisorName, bool advisorStatus)
        {
            Name = advisorName;
            Status = advisorStatus;
        }

        public string Name { get; }
        public bool Status { get; }
    }
}