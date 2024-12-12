using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.GraphCreation
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(Objects objects, string resKind)
        {
            Objects = objects;
            ResultKind = resKind;
        }
        public Objects Objects { get; }

        public string ResultKind { get; }
    }
}
