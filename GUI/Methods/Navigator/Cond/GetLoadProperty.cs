using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetLoadProperty(LoadData obj, List<string> funcTables, IEnumerable<IGroup> groups)
        {
            var rows = GetCondProperty(obj, groups, funcTables);
            rows.Add(new RowProperty("Вид",
                new DropDownPropertyValue(obj.Kind,
                Converters.GetEnumNames<LoadKind>()))
            { Color = Color.Gainsboro });

            return rows;
        }
    }
}
