using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using OperationalController;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private IEnumerable<RowProperty> GetSurfaceProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Номер", number));

            //controller.Gmsh.Model.Mesh.SetTransfiniteSurface(1);

            // TO DO добавть два свойства классу SurfaceFigure
            // - IsTransfinite (кнопка)
            // - IsRecombine (кнопка)
            // - снять все ограничения (кнопка)

            return rows;
        }
    }
}
