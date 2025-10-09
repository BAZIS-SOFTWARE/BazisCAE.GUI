using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetVolProperties(VolumeFigure vol)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Степень градиента перехода", vol.GradientMeshPower));
            rows.Add(new RowProperty("Толщина слоя", vol.LayerThickness));
            rows.Add(new RowProperty("Размер элементов на поверхности", vol.SurfaceMeshSize));
            rows.Add(new RowProperty("Размер элементов в центре", vol.CoreMeshSize));
            rows.Add(new RowProperty("Применить", vol.IsFieldUsed));

            return rows;
        }      
    }
}
