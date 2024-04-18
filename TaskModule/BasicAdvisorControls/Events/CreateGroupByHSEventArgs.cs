using ModelInterfaces;
using ProjectInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.BasicAdvisorControls.Events
{
    public class CreateGroupByHSEventArgs : EventArgs
    {
        public CreateGroupByHSEventArgs(string baseLine, string refLine, string start, string end, string heatSourceData) 
        {
            BaseLine = baseLine;
            RefLine = refLine;
            Start = start;
            End = end;
            HeatSourceData = heatSourceData;
        }

        public string BaseLine { get; set; }
        public string RefLine { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string HeatSourceData { get; set; }
    }
}
