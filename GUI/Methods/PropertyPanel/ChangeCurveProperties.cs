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
            var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite curve {number}");

            if (attributes.Length == 0)
                attributes = new string[] { "0", MeshType.Progression.ToString(), "1" };

            if (obj.Header == "Алгоритм")
                attributes[1] = obj.NewValue;
            else if (obj.Header == "Колличество точек")
                attributes[0] = obj.NewValue;
            else
                attributes[2] = obj.NewValue;


            //gmshController.Gmsh.Model.SetAttribute($"transfinite curve {arg3}", attributes);
            GmshController.Gmsh.Model.SetAttribute($"transfinite curve {number}", attributes);
            //if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            //{

            // записываем трансфиницию кривой
            var points = int.Parse(attributes[0]);
            var meshType = attributes[1].ToEnum<MeshType>();
            var coeff = double.Parse(attributes[2]);
            GmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(number, points, meshType, coeff);


            // динамически обновляем картину разбиения
            if (settingsConfig.ShowNodesOnCurves)
                ShowNodesOnCurves(true);
        }
    }
}
