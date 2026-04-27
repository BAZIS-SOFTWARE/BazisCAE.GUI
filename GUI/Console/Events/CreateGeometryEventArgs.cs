using System;
using System.Collections.Generic;

namespace BazisGUI.Console.Events
{
    public class CreateGeometryEventArgs : EventArgs
    {
        public CreateCommandType Type { get; }
        public List<string> Parameters { get; }
        public CreateGeometryEventArgs(CreateCommandType type, List<string> parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }

    public enum CreateCommandType
    {
        AddPoint,
        AddPointByVector,
        AddPointProjectToCurve,
        AddPointProjectToSurface,

        AddCurve,
        AddSurface
    }
}
