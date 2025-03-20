using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.GraphCreation
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
