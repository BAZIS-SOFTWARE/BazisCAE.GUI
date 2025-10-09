using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using GmshApi;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeCurveProperty(PropertyChangedEventArgs obj, int number)
        {
            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite curve {number}");

            if (obj.Header == "Алгоритм")
                attributes[1] = obj.NewValue;
            else if (obj.Header == "Колличество точек")
                attributes[0] = obj.NewValue;
            else
                attributes[2] = obj.NewValue;

            gmshController.Gmsh.Model.SetAttribute($"transfinite curve {number}", attributes);
            //if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            //{
            if (attributes[0] != "0")
            {
                var points = int.Parse(attributes[0]);
                var meshType = attributes[1].ToEnum<MeshType>();
                var coeff = double.Parse(attributes[2]);
                gmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(number, points, meshType, coeff);
            }
        }
    }
}
