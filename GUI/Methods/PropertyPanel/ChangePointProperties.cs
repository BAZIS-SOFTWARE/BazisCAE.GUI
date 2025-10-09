using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangePointProperty(PropertyChangedEventArgs obj, int number)
        {
            // Тут задаем настройки сетки в контрольных узлах геометрии
            var dimTags = new int[] { 0, number };
            var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);

            if (obj.Header == "Размер элементов")
                meshSize[0] = double.Parse(obj.NewValue);

            gmshController.Gmsh.Model.Mesh.SetSize(dimTags, meshSize[0]);
            //SetMinMaxSizes()
        }
    }
}
