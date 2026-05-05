using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum ClampPopertyKeys { Type }
        enum ClampKindKeys { Жесткое, Упругое, Симметрия, Контакт }
        public List<RowProperty> GetClampProperty(ClampData obj, IEnumerable<IGroup> groups, List<string> funcTables)
        {
            var rows = GetCondProperty(obj, groups, funcTables);
            rows.Add(new RowProperty(ClampPopertyKeys.Type.ToString(),
                Resources.Header_clamp_type,
                new DropDownPropertyValue(obj.Kind, Enum.GetValues<ClampKindKeys>().Select(x => x.ToString()).ToList()))
            { Color = Color.Gainsboro });

            return rows;
        }
    }
}
