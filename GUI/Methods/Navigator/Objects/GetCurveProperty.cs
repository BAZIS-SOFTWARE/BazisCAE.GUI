using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetCurveProperties(int arg3)
        {
            var rows = new List<RowProperty>();
            var algo = Converters.GetEnumNames<MeshType>();
            //if (rbtnBeta.Checked)
            //    attributes[1] = rbtnBeta.Text;
            //else if (rbtnBump.Checked)
            //    attributes[1] = rbtnBump.Text;

            //if (txbAlgoCoef.IsValueValid())
            //    attributes[2] = txbAlgoCoef.Text;
            //if (txbAlgoNPoints.IsValueValid())
            //    attributes[0] = txbAlgoNPoints.Text;

            rows.Add(new RowProperty("Номер", arg3));

            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite curve {arg3}");
                
            if (attributes.Length == 0)
            {
                attributes = new string[] { "0", MeshType.Progression.ToString(), "1" };
                gmshController.Gmsh.Model.SetAttribute($"transfinite curve {arg3}", attributes);

                rows.Add(new RowProperty("Колличество точек", 0));
                rows.Add(new RowProperty("Алгоритм", new DropDownPropertyValue(MeshType.Progression, algo)));
                rows.Add(new RowProperty("Коэффициент", 1));
                
            }
            else
            {
                rows.Add(new RowProperty("Колличество точек", attributes[0]));
                rows.Add(new RowProperty("Алгоритм", new DropDownPropertyValue(attributes[1], algo)));
                rows.Add(new RowProperty("Коэффициент", attributes[2]));    
            }

            // - TO DO снять все ограничения (кнопка)

            return rows;
        }
    }
}
