using System;

namespace BaseModule.Results.Animation
{
    public class CreateAnimationEventArgs : EventArgs
    {
        public bool DeleteTempImages { get; }

        public int DelayTime { get; }

        public string ResltsKind { get; }

        public float[] Times { get; }

        public CreateAnimationEventArgs(float[] times,int scaleFactor, bool deleteTempImages, int delayTime)
        {
            Times = times;

            DeleteTempImages = deleteTempImages;
            DelayTime = delayTime;
        }
    }
}