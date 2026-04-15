using System;
using System.Collections.Generic;

namespace BazisGUI.Console.Events
{
    public class CreateGeometryEventArgs : EventArgs
    {
        public int Type { get; }
        public List<string> Parameters { get; }
        public CreateGeometryEventArgs(int type, List<string> parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }
}
