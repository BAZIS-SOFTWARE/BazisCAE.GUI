using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetMediaProperty(MediaData obj, IEnumerable<IGroup> groups, List<string> func)
        {
            var rows = new List<RowProperty>()
            {
            new RowProperty("Группа элементов", new DropDownPropertyValue(obj.Group.Name, groups.Select(x => x.Name).ToList())),
            new RowProperty("Коэф. теплоотдачи", obj.HeatExchangeValue),
            new RowProperty("Функция, F(t), F - Дж./мм.^2", 
                new DropDownPropertyValue(obj.HeatExchangeFunc == null ? "*" : obj.HeatExchangeFunc.Name, func)),
            new RowProperty("Температура среды", obj.TemperatureValue),
            new RowProperty("Старт, сек.", obj.StartTime),
            new RowProperty("Стоп, сек.", obj.StopTime),
            new RowProperty("Функция, F(t), F - Град.",
                new DropDownPropertyValue(obj.TemperatureFunc == null ? "*" : obj.TemperatureFunc.Name, func))
            };

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Град.| Дж./мм.^2", new DropDownPropertyValue(obj.FrameFunction.Name, funcNames
)));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Град.| Дж./мм.^2", new DropDownPropertyValue("*", funcNames
)));
            }
                return rows;

        }
    }
}
