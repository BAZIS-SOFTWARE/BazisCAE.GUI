using System;

namespace ResultModule
{
    public class CreatePathGraphEventArgs : EventArgs
    {
        public CreatePathGraphEventArgs(string objsType, string resName, float time )
        {
            var descr = resName.Split('_');
            ResultKind = descr[0];

            ObjsType = objsType;
            Time = time;
        }

        public string ResultKind { get; }
        public string ObjsType { get; }
        public float Time { get; private set; }
    }
}