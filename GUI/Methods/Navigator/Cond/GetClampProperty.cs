using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetClampProperty(ClampData obj, IEnumerable<IGroup> groups, List<string> funcTables)
        {
            var rows = GetCondProperty(obj, groups, funcTables);
            rows.Add(new RowProperty("Вид",
                new DropDownPropertyValue(obj.Kind,
                Converters.GetEnumNames<ClampKind>()))
            { Color = Color.Gainsboro });

            return rows;
        }
    }
}
