using System;
using System.Collections.Generic;

namespace BazisGUI.Console.Events
{
    public class CreateExtruderEventArgs : EventArgs
    {
        public ExtruderType Type { get; }
        public List<string> Parameters { get; } 
        public CreateExtruderEventArgs(ExtruderType type, List<string> parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }

    public enum ExtruderType
    {
        Rotate,
        Curve
    }
}
