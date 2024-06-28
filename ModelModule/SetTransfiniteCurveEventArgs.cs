namespace ModelModule
{
    public class SetTransfiniteCurveEventArgs
    {
        public int tag;
        public string[] attributes;
        public int v;
        public double coef;
        public double points;
        public SetTransfiniteCurveEventArgs(int tag, string[] attributes, int v, double coef, double points)
        {
            this.tag = tag;
            this.attributes = attributes;
            this.v = v;
            this.coef = coef;
            this.points = points;
        }
    }
}