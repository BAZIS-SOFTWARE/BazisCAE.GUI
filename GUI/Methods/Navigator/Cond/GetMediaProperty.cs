using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetMediaProperty(MediaData obj, IEnumerable<IGroup> groups, List<string> func)
        {
            var rows = new List<RowProperty>()
            {
                new RowProperty("Вид условия",obj.MediaType),
                new RowProperty("Группа элементов", new DropDownPropertyValue(obj.Group.Name, groups.Select(x => x.Name).ToList()))
            };

            rows.Add(new RowProperty("Функция, F(t), F - Град.",
            new DropDownPropertyValue(obj.TemperatureFunc == null ?
            "*" : obj.TemperatureFunc.Name, func)));
            rows.Add(new RowProperty("Температура среды", obj.TemperatureValue));


            rows.Add(new RowProperty("Функция, F(t), F - Дж./мм.^2",
new DropDownPropertyValue(obj.HeatExchangeFunc == null ?
"*" : obj.HeatExchangeFunc.Name, func)));
            rows.Add(new RowProperty("Коэф. теплоотдачи", obj.HeatExchangeValue));



            rows.Add(new RowProperty("Старт, сек.", obj.StartTime));
            rows.Add(new RowProperty("Стоп, сек.", obj.StopTime));

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
