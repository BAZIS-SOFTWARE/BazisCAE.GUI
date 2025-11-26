using System;

namespace BaseModule.Console.Events
{
    public class ModelFindCoincidentsNodesEventArgs : EventArgs
    {
        public ModelFindCoincidentsNodesEventArgs(string v)
        {
            Distance = float.Parse(v);
        }

        public float Distance { get; }
    }
}