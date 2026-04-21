using System;
using System.Collections.Generic;

namespace BazisGUI.Console.Events
{
    public class CreateGeometryEventArgs : EventArgs
    {
        public GeometryType Type { get; }
        public List<string> Parameters { get; }
        public CreateGeometryEventArgs(GeometryType type, List<string> parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }

    public enum GeometryType
    {
        Point = 0,
        Curve = 1,
        Surface = 2
    }
}
