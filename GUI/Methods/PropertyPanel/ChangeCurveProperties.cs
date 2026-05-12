using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using GmshApi;
using Project.Interfaces.Tasks;
using System;

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
                GmshController.Gmsh.Model.SetAttribute($"transfinite curve {number}", attributes);
            }

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
