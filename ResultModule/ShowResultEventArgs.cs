namespace ResultModule
{
    public class ShowResultEventArgs
    {
        public string ResultKind { get; }
        public float Time { get; }

        public int ScaleFactor { get; }

        public ShowResultEventArgs(string resultName, float time, int scaleFactor)
        {
            var descr = resultName.Split('_');

            ResultKind = descr[0];
            Time = time;
            ScaleFactor = scaleFactor;
        }
    }
}