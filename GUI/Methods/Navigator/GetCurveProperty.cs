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

            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {arg3}");

            if (attributes.Length == 0)
            {
                rows.Add(new RowProperty("Алгоритм", "*", algo));
                rows.Add(new RowProperty("Коэффициент", 1));
                rows.Add(new RowProperty("Колличество точек", 0));
            }
            else
            {
                rows.Add(new RowProperty("Алгоритм", attributes[2], algo));
                rows.Add(new RowProperty("Коэффициент", attributes[1]));
                rows.Add(new RowProperty("Колличество точек", attributes[0]));
            }

            return rows;
        }
    }
}
