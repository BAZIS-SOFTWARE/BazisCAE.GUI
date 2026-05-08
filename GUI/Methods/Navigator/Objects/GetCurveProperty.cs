using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum CurvePropertyKeys { Number, PointsNumber, Algorithm, Coefficient, }
        private List<RowProperty> GetCurveProperties(int arg3)
        {
            var rows = new List<RowProperty>();
            var algo = Converters.GetEnumNames<MeshType>();

            rows.Add(new RowProperty(CurvePropertyKeys.Number.ToString(), Resources.Header_curve_number, arg3));

            var attributes = GmshController.Gmsh.Model.GetAttribute($"transfinite curve {arg3}");
                
            if (attributes.Length == 0)
            {
                //установить когда будут применены настройки

                //attributes = new string[] { "0", MeshType.Progression.ToString(), "1" };
                //gmshController.Gmsh.Model.SetAttribute($"transfinite curve {arg3}", attributes);

                rows.Add(new RowProperty(CurvePropertyKeys.PointsNumber.ToString(), Resources.Header_curve_PointsNumber, 0));
                rows.Add(new RowProperty(CurvePropertyKeys.Algorithm.ToString(), Resources.Header_curve_algorithm, new DropDownPropertyValue(MeshType.Progression, algo)));
                rows.Add(new RowProperty(CurvePropertyKeys.Coefficient.ToString(), Resources.Header_curve_coefficient, 1));            
            }
            else
            {
                rows.Add(new RowProperty(CurvePropertyKeys.PointsNumber.ToString(), Resources.Header_curve_PointsNumber, attributes[0]));
                rows.Add(new RowProperty(CurvePropertyKeys.Algorithm.ToString(), Resources.Header_curve_algorithm, new DropDownPropertyValue(attributes[1], algo)));
                rows.Add(new RowProperty(CurvePropertyKeys.Coefficient.ToString(), Resources.Header_curve_coefficient, attributes[2]));    
            }

            // - TO DO снять все ограничения (кнопка)

            return rows;
        }
    }
}
