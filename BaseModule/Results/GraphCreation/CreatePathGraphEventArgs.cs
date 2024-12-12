using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.GraphCreation
{
    public class CreatePathGraphEventArgs : EventArgs
    {
        public CreatePathGraphEventArgs(Objects objects, string resName, float time )
        {
            var descr = resName.Split('_');
            ResultKind = descr[0];

            Objects = objects;
            Time = time;
        }

        public string ResultKind { get; }
        public Objects Objects { get; }
        public float Time { get; private set; }
    }
}