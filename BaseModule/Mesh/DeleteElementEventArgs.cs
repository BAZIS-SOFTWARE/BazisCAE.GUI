namespace BaseModule.Mesh
{
    public class DeleteElementEventArgs
    {
        public int dim;
        public int tag;
        public string[] keyData;
        public bool isNumeric;

        public DeleteElementEventArgs(int dim, int tag, string[] keyData, bool isNumeric)
        {
            this.dim = dim;
            this.tag = tag;
            this.keyData = keyData;
            this.isNumeric = isNumeric;
        }
    }
}