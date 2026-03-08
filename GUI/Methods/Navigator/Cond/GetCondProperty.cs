using BazisGUI.PropertiesPanel;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetCondProperty(CondData obj, IEnumerable<IGroup> groups, List<string> funcTables)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Группа объектов", 
                new DropDownPropertyValue(obj.Group.Name, 
                groups.Select(x => x.Name).ToList())));

            rows.Add(new RowProperty("Значение", obj.Value) 
            { Color = Color.Gainsboro });

            var funcNames = Enum.GetNames(typeof(FuncName)).ToList();
            funcNames.Add("*");

            rows.Add(new RowProperty("Функция",
          new DropDownPropertyValue(obj.Function == null ?
          "*" : obj.Function.Name, funcNames))
            { Color = Color.Gainsboro });

            if(obj.Function != null)
            {
                funcTables.Add("Constant");
                var pars = obj.Function?.GetParameters();
                foreach (var item in pars)
                {
                    var parAr = item.ToString().Split("=");
          
                    rows.Add(new RowProperty($"Параметр {parAr[0]}",
                        item.ParameterKind == ParameterKind.Table ? 
                        new DropDownPropertyValue(parAr[1], funcTables) : parAr[1],
                        item.ParameterType == ParameterType.Variable ?
                        true : false));

                    if(item.ParameterKind == ParameterKind.Table)
                    {
                        var tablePar = item as TableParameter;
                        rows.Add(new RowProperty($"Таблица {tablePar.Table.Name}",
                            new DropDownPropertyValue(tablePar.Parameter.Name, 
                            pars.Select(x => x.Name).ToList())));
                    }
  
                }
            }

            var dirNames = Enum.GetNames(typeof(Direction)).ToList();
            rows.Add(new RowProperty("Направление", new DropDownPropertyValue(obj.Direction, dirNames)) 
            { Color = Color.Gainsboro });

            rows.Add(new RowProperty("Старт, сек.", obj.StartTime)
            { Color = Color.Gainsboro });
            rows.Add(new RowProperty("Стоп, сек.", obj.StopTime)
            { Color = Color.Gainsboro });

            rows.Add(new RowProperty
(
"Система координат", new DropDownPropertyValue(
obj.LocalFrame == null ? "*" : obj.LocalFrame,
new List<string>() { "MRF", "SRF", "*" }
))
            { Color = Color.Gainsboro });

            if (obj.LocalFrame != null)
                rows.AddRange(GetLocalFrameProperties(obj.LocalFrame, groups));

            return rows;

        }
    }
}
