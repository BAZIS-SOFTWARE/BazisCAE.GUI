using System;

namespace BaseModule.Results.Animation
{
    public class CreateAnimationEventArgs : EventArgs
    {
        public bool DeleteTempImages { get; }

        public int DelayTime { get; }

        public string ResltsKind { get; }

        public float[] Times { get; }

        public int ScaleFactor { get; }

        public CreateAnimationEventArgs(string resltsKind, float[] times,int scaleFactor, bool deleteTempImages, int delayTime)
        {
            if (resltsKind == "")
                throw new Exception("Выберите результаты");

            Times = times;

            ScaleFactor = scaleFactor;
            ResltsKind = resltsKind;
            DeleteTempImages = deleteTempImages;
            DelayTime = delayTime;
        }
    }
}