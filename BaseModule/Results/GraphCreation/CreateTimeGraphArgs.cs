using System;
using static BazisGUI.Interfaces.GeneralParams;

namespace BazisGUI.Results.GraphCreation
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(GraphObjects objects)
        {
            Objects = objects;
        }
        public GraphObjects Objects { get; }
    }
}
