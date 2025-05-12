using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskConverter : DataConverter
    {
        private HeatData _objAsHeat;
        private List<string> _func;
        //private readonly List<IGroup> _groupLine;

        public HeatTaskConverter(IPhysicalData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _objAsHeat = obj as HeatData;
            _func = func;
            // Почему тут требуется название группы опорной линии?
            //_groupLine = GetGroupsByObjTypeFromOnesName(_objAsHeat, _objAsHeat.MovedFrame.BaseLine.Name.ToString());
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_objAsHeat.FrameFunction is Arc arc)
            {
                property.Add(RowProperty.CreateTextBox("Ширина шва (L), мм", arc.Width.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Ток, А", arc.Current.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Напряжение, В", arc.Voltage.ToString(), ValidationType.FloatPositive));
            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {
                property.Add(RowProperty.CreateTextBox("Мощность излучения, Дж", lazer.SurfacePower.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Глубина проплавления (L), мм", lazer.Length.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Диаметр основания (D2), мм", lazer.UpperDiam.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Диаметр конца (D3), мм", lazer.BottomDiam.ToString(), ValidationType.FloatPositive));
            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {
                property.Add(RowProperty.CreateTextBox("Скорость вращения, об/cек.", fSwPin.RotSpeed.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Длина бура (L), мм", fSwPin.Length.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Диаметр основания (D2), мм", fSwPin.BottomDiam.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Диаметр конца (D3), мм", fSwPin.UpperDiam.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateComboBox("Предел текучести, МПа", fSwPin.GetParameters().First().Name, _func));
            }
            else if (_objAsHeat.FrameFunction is FSWShoulder fSwShoulder)
            {
                property.Add(RowProperty.CreateTextBox("Скорость вращения, об/cек.", fSwShoulder.RotSpeed.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Осевое усилие, Н", fSwShoulder.AxisForce.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Диаметр плеча (D1), мм", fSwShoulder.UpperDiam.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateComboBox("Коэффициент трения", fSwShoulder.GetParameters().First().Name, _func));
            }
            else throw new InvalidOperationException("Имя FrameFunction не известно");

            property.Add(RowProperty.CreateComboBox("Группа элементов", _objAsHeat.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
            property.Add(RowProperty.CreateTextBox("Старт, сек.", _objAsHeat.StartTime.ToString(), ValidationType.FloatPositive));
            property.Add(RowProperty.CreateTextBox("Стоп, сек.", _objAsHeat.StopTime.ToString(), ValidationType.None, true));

            return property;
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            if (_objAsHeat.FrameFunction is Arc arc)
            {


            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {

            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {

            }
            else if (_objAsHeat.FrameFunction is FSWShoulder fSwShoulder)
            {

            }
            //var set = GetFrameFunction(header, newValue);
            //UpdateTrajectoryInfo(set);
            //selectObj = _objAsHeat as IPhysicalData;
        }

        private string GetFrameFunction(string header, string newValue)
        {
            var sb = new StringBuilder();
            if (_objAsHeat.FrameFunction is Arc arc)
            {
                data = new Dictionary<string, string>()
                {
                    { "Вид сварки", _objAsHeat.FrameFunction.Name },
                    { "Ширина шва (L), мм", arc.Width.ToString() },
                    { "Ток, А", arc.Current.ToString() },
                    { "Напряжение, В", arc.Voltage.ToString() }
                };

                data[header] = newValue.ToString();
                sb.Append($"{data["Вид сварки"]};{data["Ширина шва (L), мм"]};{data["Ток, А"]};{data["Напряжение, В"]} "); // processParameters
                sb.Append($"{_objAsHeat.Group.Name} {_objAsHeat.StartTime} {_objAsHeat.StopTime} "); // set
                var trajectory = _objAsHeat.LocalFrame.ToString();
                sb.Append(trajectory);
                return sb.ToString();
            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {
                data = new Dictionary<string, string>()
                {
                    { "Вид сварки", _objAsHeat.FrameFunction.Name },
                    { "Мощность излучения, Дж", lazer.SurfacePower.ToString() },
                    { "Глубина проплавления (L), мм", lazer.Length.ToString() },
                    { "Диаметр основания (D2), мм", lazer.UpperDiam.ToString() },
                    { "Диаметр конца (D3), мм", lazer.BottomDiam.ToString() }
                };

                data[header] = newValue.ToString();
                sb.Append($"{data["Вид сварки"]};{data["Мощность излучения, Дж"]};{data["Глубина проплавления (L), мм"]};{data["Диаметр основания (D2), мм"]};{data["Диаметр конца (D3), мм"]} "); // processParameters
                sb.Append($"{_objAsHeat.Group.Name} {_objAsHeat.StartTime} {_objAsHeat.StopTime} "); // set
                var trajectory = _objAsHeat.LocalFrame.ToString();
                sb.Append(trajectory);
                return sb.ToString();
            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {
                data = new Dictionary<string, string>()
                {
                    { "Вид сварки", _objAsHeat.FrameFunction.Name },
                    { "Скорость вращения, об/cек.", fSwPin.RotSpeed.ToString() },
                    { "Длина бура (L), мм", fSwPin.Length.ToString() },
                    { "Диаметр основания (D2), мм", fSwPin.BottomDiam.ToString() },
                    { "Диаметр конца (D3), мм", fSwPin.UpperDiam.ToString() },
                    { "Предел текучести, МПа", fSwPin.GetParameters().First().Name }
                };

                data[header] = newValue.ToString();
                sb.Append($"{data["Вид сварки"]};{data["Скорость вращения, об/cек."]};{data["Длина бура (L), мм"]};{data["Диаметр основания (D2), мм"]};{data["Диаметр конца (D3), мм"]};{data["Предел текучести, МПа"]} "); // processParameters
                sb.Append($"{_objAsHeat.Group.Name} {_objAsHeat.StartTime} {_objAsHeat.StopTime} "); // set
                var trajectory = _objAsHeat.LocalFrame.ToString();
                sb.Append(trajectory);
                return sb.ToString();
            }
            else
            {
                var fSwShoulder = _objAsHeat.FrameFunction as FSWShoulder;

                data = new Dictionary<string, string>()
                {
                    { "Вид сварки", _objAsHeat.FrameFunction.Name },
                    { "Скорость вращения, об/cек.", fSwShoulder.RotSpeed.ToString() },
                    { "Осевое усилие, Н", fSwShoulder.AxisForce.ToString() },
                    { "Диаметр плеча (D1), мм", fSwShoulder.UpperDiam.ToString() },
                    { "Коэффициент трения", fSwShoulder.GetParameters().First().Name}
                };

                data[header] = newValue.ToString();
                sb.Append($"{data["Вид сварки"]};" +
                    $"{data["Осевое усилие, Н"]};" +
                    $"{data["Скорость вращения, об/cек."]};" +
                    $"{fSwShoulder.Length.ToString()};" +
                    $"{data["Диаметр плеча (D1), мм"]};" +
                    $"{data["Диаметр плеча (D1), мм"]};" +
                    $"{data["Коэффициент трения"]} ");
                sb.Append($"{_objAsHeat.Group.Name} {_objAsHeat.StartTime} {_objAsHeat.StopTime} "); // set
                var trajectory = _objAsHeat.LocalFrame.ToString();
                sb.Append(trajectory);
                return sb.ToString();
            }
        }

        [Obsolete("Использовать до изменения в Core")]
        private void UpdateTrajectoryInfo(string data)
        {
            // TO DO
            // Привести в соответствие к Core

            //var baseLine = _objAsHeat.MovedFrame.BaseLine;
            //var refLine = _objAsHeat.MovedFrame.RefLine;
            //var startLine = _objAsHeat.MovedFrame.StartPoints;
            //var stopLine = _objAsHeat.MovedFrame.StopPoints;

            //_objAsHeat.SetInfo(data);

            //_objAsHeat.MovedFrame.BaseLine = _groupLine.First(x => x.Name == baseLine.Name);
            //_objAsHeat.MovedFrame.RefLine = _groupLine.First(x => x.Name == refLine.Name);
            //_objAsHeat.MovedFrame.StartPoints = _groupLine.First(x => x.Name == startLine.Name);
            //_objAsHeat.MovedFrame.StopPoints = _groupLine.First(x => x.Name == stopLine.Name);
        }
    }
}
