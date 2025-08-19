using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.FrameCreators;
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
            new RowProperty("Группа элементов", obj.Group.Name, groups.Select(x => x.Name).ToList()),
            new RowProperty("Коэф. теплоотдачи", obj.HeatExchangeValue),
            new RowProperty("Функция, F(t), F - Дж./мм.^2", obj.HeatExchangeFunc, func),
            new RowProperty("Температура среды", obj.TemperatureValue),
            new RowProperty("Старт, сек.", obj.StartTime),
            new RowProperty("Стоп, сек.", obj.StopTime),
            new RowProperty("Функция, F(t), F - Град.", obj.TemperatureFunc)
            };

            var funcNames = new List<string>() { "*", "Custom" };

            if (obj.FrameFunction != null)
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Град.| Дж./мм.^2", obj.FrameFunction.Name, funcNames
));
                rows.AddRange(GetFrameFunctionProperties(obj.FrameFunction));
                rows.AddRange(GetLocalFrameProperties(obj.FrameFunction.LocalFrame, groups));
            }
            else
            {
                rows.Add(new RowProperty
(
"Функция, F(v(x,y,z)), F - Град.| Дж./мм.^2", "*", funcNames
));
            }
                return rows;

        }
    }
}
