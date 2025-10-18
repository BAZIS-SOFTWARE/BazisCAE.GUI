using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private IEnumerable<RowProperty> GetSurfaceProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Номер", number));

            // TO DO добавть два свойства классу SurfaceFigure
            // - IsTransfinite (кнопка)
            // - IsRecombine (кнопка)
            // - снять все ограничения (кнопка)

            return rows;
        }
    }
}
