using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskConverter : DataConverter
    {
        private HeatData _objAsHeat;
        private List<string> _func;
        private readonly List<IGroup> _groupLine;

        public HeatTaskConverter(IData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _objAsHeat = obj as HeatData;
            _func = func;
            _groupLine = GetGroupsByObjTypeFromOnesName(_objAsHeat, _objAsHeat.MovedFrame.BaseLine.Name.ToString());
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
            if (_objAsHeat.FrameFunction is Arc arc)
            {
                data = new Dictionary<string, string>()
                {
                    { "Вид сварки", _objAsHeat.FrameFunction.Name },
                    { "Ширина шва (L), мм", arc.Width.ToString() },
                    { "Ток, А", arc.Current.ToString() },
                    { "Напряжение, В", arc.Voltage.ToString() }
                };
            }
            data[header] = newValue.ToString();

            if (header == "Группа элементов")
            {
                var valuadleData = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == newValue.ToString());
                valuadleData.Group = group;
                _objAsHeat.Group.Name = newValue;
            }
            else if (header == "Старт, сек.")
            {
                _objAsHeat.StartTime = float.Parse(newValue);
            }

            var sb = new StringBuilder();
            sb.Append($"{data["Вид сварки"]};{data["Ширина шва (L), мм"]};{data["Ток, А"]};{data["Напряжение, В"]} "); // processParameters
            sb.Append($"{_objAsHeat.Group.Name} {_objAsHeat.StartTime} {_objAsHeat.StopTime} "); // set
            var test = _objAsHeat.TrajectoryInfo;
            sb.Append(test);
            var set = sb.ToString();

            var baseLine = _objAsHeat.MovedFrame.BaseLine;
            var refLine = _objAsHeat.MovedFrame.RefLine;
            var startLine = _objAsHeat.MovedFrame.StartPoints;
            var stopLine = _objAsHeat.MovedFrame.StopPoints;

            _objAsHeat.SetInfo(set);

            _objAsHeat.MovedFrame.BaseLine = _groupLine.First(x => x.Name == baseLine.Name);
            _objAsHeat.MovedFrame.RefLine = _groupLine.First(x => x.Name == refLine.Name);
            _objAsHeat.MovedFrame.StartPoints = _groupLine.First(x => x.Name == startLine.Name);
            _objAsHeat.MovedFrame.StopPoints = _groupLine.First(x => x.Name == stopLine.Name);
            Debug.WriteLine(_objAsHeat.GetInfo);
            selectObj = _objAsHeat as IData;

            
        }
    }
}
