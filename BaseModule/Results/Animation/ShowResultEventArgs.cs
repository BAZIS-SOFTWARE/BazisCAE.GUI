namespace BaseModule.Results.Animation
{
    public class ShowResultEventArgs
    {
        public string ResultKind { get; }
        public float Time { get; }

        public int ScaleFactor { get; }

        public ShowResultEventArgs(string resultKind, float time, int scaleFactor)
        {
            var descr = resultKind.Split('_');

            ResultKind = descr[0];
            Time = time;
            ScaleFactor = scaleFactor;
        }
    }
}