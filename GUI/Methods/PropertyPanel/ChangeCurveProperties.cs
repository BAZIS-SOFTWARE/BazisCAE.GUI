using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using GmshApi;
using Project.Interfaces.Tasks;
using System;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeCurveProperty(PropertyChangedEventArgs obj, int number)
        {
            var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite curve {number}");

            if (attributes.Length == 0)
                attributes = new string[] { "0", MeshType.Progression.ToString(), "1" };

            if (Enum.TryParse(obj.Key, out CurvePropertyKeys key))
            {
                switch (key)
                {
                    case CurvePropertyKeys.Algorithm:
                        attributes[1] = obj.NewValue;
                        break;
                    case CurvePropertyKeys.PointsNumber:
                        attributes[0] = obj.NewValue;
                        break;
                    case CurvePropertyKeys.Coefficient:
                        attributes[2] = obj.NewValue;
                        break;
                }
                
                SetMeshCurve(number, attributes);
            }
        }

        private void PrepareDataForSetMeshCurve(string number, string pointsCount, string algorithm, string factor)
        {
            var valid = int.TryParse(number, out var _number) & 
                        double.TryParse(factor, out var _factor);

            if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);

            var attributes = new[] { pointsCount, algorithm, factor };
            SetMeshCurve(_number, attributes);
        }

        private void SetMeshCurve(int number, string[] attributes)
        {
           // var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite curve {number}");
            GmshController.Gmsh.Model.SetAttribute($"transfinite curve {number}", attributes);

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
