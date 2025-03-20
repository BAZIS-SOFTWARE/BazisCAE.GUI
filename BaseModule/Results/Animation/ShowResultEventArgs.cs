namespace BaseModule.Results.Animation
{
    public class ShowResultEventArgs
    {
        public float Time { get; }

        public int ScaleFactor { get; }

        public ShowResultEventArgs(float time, int scaleFactor)
        {
            Time = time;
            ScaleFactor = scaleFactor;
        }
    }
}