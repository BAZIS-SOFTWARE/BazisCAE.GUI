using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetLoadProperty(LoadData obj, List<string> func, IEnumerable<IGroup> groups)
        {
            var rows = new List<RowProperty>
            {
                //RowProperty.new RowProperty("Имя", NodeType.Нагрузка.ToString(), ValidationType.None, true),
                new RowProperty("Вид", new DropDownPropertyValue(obj.Kind, Converters.GetEnumNames<LoadKind>())),
                new RowProperty("Направление", new DropDownPropertyValue(obj.Direction,Converters.GetEnumNames<Direction>())),
                new RowProperty("Группа объектов", new DropDownPropertyValue(obj.Group.Name,groups.Select(x => x.Name).ToList())),
                new RowProperty("Величина, Н", obj.Value),
                new RowProperty("Функция, F(t), F - Н.",
                new DropDownPropertyValue(obj.TimeFunction == null ? "*" : obj.TimeFunction.Name,func)),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime)
            };

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Н.", new DropDownPropertyValue(obj.FrameFunction.Name, funcNames
)));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Н.", new DropDownPropertyValue("*", funcNames
)));
            }

            return rows;
        }
    }
}
