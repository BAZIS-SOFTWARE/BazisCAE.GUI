using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Functions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskConverter : DataConverter
    {
        private HeatData _objAsHeat;
        private List<string> _func;

        public HeatTaskConverter(IData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _objAsHeat = obj as HeatData;
            _func = func;
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_objAsHeat.FrameFunction is Arc arc)
            {
                property.Add(RowProperty.CreateTextBox("Ширина шва (L), мм", arc.Width.ToString()));
                property.Add(RowProperty.CreateTextBox("Ток, А", arc.Current.ToString()));
                property.Add(RowProperty.CreateTextBox("Напряжение, В", arc.Voltage.ToString())); 
            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {
                property.Add(RowProperty.CreateTextBox("Мощность излучения, Дж", lazer.SurfacePower.ToString()));
                property.Add(RowProperty.CreateTextBox("Глубина проплавления (L), мм", lazer.Length.ToString()));
                property.Add(RowProperty.CreateTextBox("Диаметр основания (D2), мм", lazer.UpperDiam.ToString()));
                property.Add(RowProperty.CreateTextBox("Диаметр конца (D3), мм", lazer.BottomDiam.ToString()));
            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {
                property.Add(RowProperty.CreateTextBox("Скорость вращения, об/cек.", fSwPin.RotSpeed.ToString()));
                property.Add(RowProperty.CreateTextBox("Длина бура (L), мм", fSwPin.Length.ToString()));
                property.Add(RowProperty.CreateTextBox("Диаметр основания (D2), мм", fSwPin.BottomDiam.ToString())); 
                property.Add(RowProperty.CreateTextBox("Диаметр конца (D3)", fSwPin.UpperDiam.ToString()));
                property.Add(RowProperty.CreateComboBox("Предел текучести, МПа", fSwPin.GetParameters().First().Name, _func));
            }
            else if (_objAsHeat.FrameFunction is FSWShoulder fSwShoulder)
            {
                property.Add(RowProperty.CreateTextBox("Скорость вращения, об/cек.", fSwShoulder.RotSpeed.ToString()));
                property.Add(RowProperty.CreateTextBox("Осевое усилие, Н", fSwShoulder.AxisForce.ToString()));
                property.Add(RowProperty.CreateTextBox("Диаметр плеча (D1), мм", fSwShoulder.UpperDiam.ToString()));
                property.Add(RowProperty.CreateComboBox("Коэффициент трения", fSwShoulder.GetParameters().First().Name, _func));
            }
            else throw new InvalidOperationException("Имя FrameFunction не известно");
            
            property.Add(RowProperty.CreateComboBox("Группа элементов", _objAsHeat.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
            property.Add(RowProperty.CreateTextBox("Старт, сек.", _objAsHeat.StartTime.ToString()));
            property.Add(RowProperty.CreateTextBox("Стоп, сек.", _objAsHeat.StopTime.ToString(), true));
            return property;
        }

        public override void UpdateObject(string header, string newValue, string oldValue)
        {
            if (header == "Группа элементов")
            {
                var k = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == newValue.ToString());
                k.Group = group;

                _objAsHeat.Group.Name = newValue;
            }
            else if (header == "Старт, сек.")
            {
                _objAsHeat.StartTime = float.Parse(newValue);
            }
            selectObj = _objAsHeat as IData;
        }
    }
}
