namespace ModelModule
{
    public enum SetTransfiniteCurveEventRequest
    {
        Get,
        Set,
        Reset
    }
    public class SetTransfiniteCurveEventArgs
    {
        public int Tag { get; private set; }
        public SetTransfiniteCurveEventRequest Request { get; private set; }
        public string[] Attributes { get; set; }
        public double Coef { get; private set; }
        public int Points { get; private set; }
        public SetTransfiniteCurveEventArgs(int tag, SetTransfiniteCurveEventRequest request, string[] attributes)
        {
            Tag = tag;
            Request = request;
            Attributes = attributes;

            if (attributes != null)
            {
                if (attributes[2].Length != 0)
                    Coef = double.Parse(attributes[2]);
                if (attributes[0].Length != 0)
                    Points = int.Parse(attributes[0]);
            }
        }
    }
}