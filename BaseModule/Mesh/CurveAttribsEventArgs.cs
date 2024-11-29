namespace BaseModule.Mesh
{
    public class CurveAttribsEventArgs
    {
        public int Tag { get; private set; }
        public string[] Attributes { get; set; }
        public double Coef { get; private set; }
        public int Points { get; private set; }
        public CurveAttribsEventArgs(int number, string[] attributes)
        {
            Tag = number;
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