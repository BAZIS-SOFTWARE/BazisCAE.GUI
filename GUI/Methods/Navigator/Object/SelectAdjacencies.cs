namespace BazisGUI
{
    public partial class BaseForm
    {
        private void SelectAdj(int dim, int number)
        {
            var adgTags = GmshController.Gmsh.Model.GetAdjacencies(dim, number);

            //var upperLevel = adgTags.Item1;
            //var lowerLevel = adgTags.Item2;

            foreach(var array in new[] { adgTags.Item1, adgTags.Item2 })
            {
                foreach(var item in array)
                {

                }
            }
        }
    }
}
