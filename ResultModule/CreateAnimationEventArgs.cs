using System;

namespace ResultModule
{
    public class CreateAnimationEventArgs : EventArgs
    {
        public bool DeleteTempImages { get; }

        public int DelayTime { get; }

        public string ResltsName { get; }

        public float[] Times { get; }

        public int ScaleFactor { get; }

        public CreateAnimationEventArgs(string resltsName, float[] times,int scaleFactor, bool deleteTempImages, int delayTime)
        {
            if (resltsName == "")
                throw new Exception("Выберите результаты");

            Times = times;

            ScaleFactor = scaleFactor;
            ResltsName = resltsName;
            DeleteTempImages = deleteTempImages;
            DelayTime = delayTime;
        }
    }
}