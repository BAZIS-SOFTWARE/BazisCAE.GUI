using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.GraphCreation
{
    public class CreatePathGraphEventArgs : EventArgs
    {
        public CreatePathGraphEventArgs(GraphObjects objects, float time )
        {
            Objects = objects;
            Time = time;
        }
        public GraphObjects Objects { get; }
        public float Time { get; private set; }
    }
}