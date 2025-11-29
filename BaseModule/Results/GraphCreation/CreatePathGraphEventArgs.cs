using System;
using static BazisGUI.Interfaces.GeneralParams;

namespace BazisGUI.Results.GraphCreation
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