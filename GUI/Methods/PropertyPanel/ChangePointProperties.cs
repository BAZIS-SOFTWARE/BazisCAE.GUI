using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangePointProperty(PropertyChangedEventArgs obj, int number)
        {
            // Тут задаем настройки сетки в контрольных узлах геометрии

            //var meshSize = GmshController.GetSize(number);

            //var dimTags = new int[] { 0, number };
            //var meshSize = GmshController.Gmsh.Model.Mesh.GetSizes(dimTags);

            if (obj.Header == "Размер элементов")
                GmshController.SetSize(number, double.Parse(obj.NewValue));

            //GmshController.Gmsh.Model.Mesh.SetSize(dimTags, meshSize[0]);
            //SetMinMaxSizes()
        }
    }
}
