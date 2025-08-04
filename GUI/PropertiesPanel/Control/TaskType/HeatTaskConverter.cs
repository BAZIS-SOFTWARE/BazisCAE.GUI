using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using Project.Tasks.Functions;
using Project.Tasks.Functions.Welding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskConverter : DataConverter
    {
        private HeatData _objAsHeat;
        private List<string> _func;

        public HeatTaskConverter(HeatData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _objAsHeat = obj;
            _func = func;
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_objAsHeat.FrameFunction is ArcS arc)
            {
                property.Add(new RowProperty("Ширина шва (L), мм", arc.Width.ToString()));
                property.Add(new RowProperty("Ток, А", arc.Current.ToString()));
                property.Add(new RowProperty("Напряжение, В", arc.Voltage.ToString()));
            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {
                property.Add(new RowProperty("Мощность излучения, Дж", lazer.SurfacePower.ToString()));
                property.Add(new RowProperty("Глубина проплавления (L), мм", lazer.Length.ToString()));
                property.Add(new RowProperty("Диаметр основания (D2), мм", lazer.UpperDiam.ToString()));
                property.Add(new RowProperty("Диаметр конца (D3), мм", lazer.BottomDiam.ToString()));
            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {
                property.Add(new RowProperty("Скорость вращения, об/cек.", fSwPin.RotSpeed.ToString()));
                property.Add(new RowProperty("Длина бура (L), мм", fSwPin.Length.ToString()));
                property.Add(new RowProperty("Диаметр основания (D2), мм", fSwPin.BottomDiam.ToString()));
                property.Add(new RowProperty("Диаметр конца (D3), мм", fSwPin.UpperDiam.ToString()));
                property.Add(new RowProperty("Предел текучести, МПа", fSwPin.GetParameters().First().Name, _func));
            }
            else if (_objAsHeat.FrameFunction is FSWShoulder fSwShoulder)
            {
                property.Add(new RowProperty("Скорость вращения, об/cек.", fSwShoulder.RotSpeed.ToString()));
                property.Add(new RowProperty("Осевое усилие, Н", fSwShoulder.AxisForce.ToString()));
                property.Add(new RowProperty("Диаметр плеча (D1), мм", fSwShoulder.UpperDiam.ToString()));
                property.Add(new RowProperty("Коэффициент трения", fSwShoulder.GetParameters().First().Name, _func));
            }
            else throw new InvalidOperationException("Имя FrameFunction не известно");

            property.Add(new RowProperty("Группа элементов", _objAsHeat.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
            property.Add(new RowProperty("Старт, сек.", _objAsHeat.StartTime.ToString()));
            property.Add(new RowProperty("Стоп, сек.", _objAsHeat.StopTime.ToString()));

            return property;
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            if (_objAsHeat.FrameFunction is ArcS arc)
            {
                if (header == "Ширина шва (L), мм") arc.Width = float.Parse(newValue);
                else if (header == "Ток, А") arc.Current = float.Parse(newValue);
                else if (header == "Напряжение, В") arc.Voltage = float.Parse(newValue);
            }
            else if (_objAsHeat.FrameFunction is Lazer lazer)
            {
                if (header == "Мощность излучения, Дж")
                {
                    var builder = new LazerBuilder().
                        SetPower(newValue).
                        SetBottomDiam(lazer.BottomDiam.ToString()).
                        SetUpperDiam(lazer.UpperDiam.ToString()).
                        SetLength(lazer.Length.ToString()).
                        SetFrame(lazer.LocalFrame.Frame);
                    _objAsHeat.FrameFunction = (Lazer)builder;
                }
                if (header == "Глубина проплавления (L), мм") lazer.Length = float.Parse(newValue);
                else if (header == "Диаметр основания (D2), мм") lazer.UpperDiam = float.Parse(newValue);
                else if (header == "Диаметр конца (D3), мм") lazer.BottomDiam = float.Parse(newValue);
            }
            else if (_objAsHeat.FrameFunction is FSWPin fSwPin)
            {
                if (header == "Скорость вращения, об/cек.") fSwPin.RotSpeed = float.Parse(newValue);
                else if (header == "Длина бура (L), мм") fSwPin.Length = float.Parse(newValue);
                else if (header == "Диаметр основания (D2), мм") fSwPin.BottomDiam = float.Parse(newValue);
                else if (header == "Диаметр конца (D3), мм") fSwPin.UpperDiam = float.Parse(newValue);
                else if (header == "Предел текучести, МПа")
                {
                    var builder = new FSWPinBuilder().
                        SetRotSpeed(fSwPin.RotSpeed.ToString()).
                        SetLength(fSwPin.Length.ToString()).
                        SetBottomDiam(fSwPin.BottomDiam.ToString()).
                        SetUpperDiam(fSwPin.UpperDiam.ToString()).
                        SetYieldFunc(newValue);
                    _objAsHeat.FrameFunction = (FSWPin)builder;
                }
            }
            else if (_objAsHeat.FrameFunction is FSWShoulder fSwShoulder)
            {
                if (header == "Скорость вращения, об/cек.") fSwShoulder.RotSpeed = float.Parse(newValue);
                else if (header == "Осевое усилие, Н") fSwShoulder.AxisForce = float.Parse(newValue);
                else if (header == "Диаметр плеча (D1), мм") fSwShoulder.UpperDiam = float.Parse(newValue);
                else if (header == "Коэффициент трения")
                {
                    var builder = new FSWShoulderBuilder().
                        SetAxisForce(fSwShoulder.AxisForce.ToString()).
                        SetRotSpeed(fSwShoulder.RotSpeed.ToString()).
                        SetLength(fSwShoulder.Length.ToString()).
                        SetBottomDiam(fSwShoulder.BottomDiam.ToString()).
                        SetUpperDiam(fSwShoulder.UpperDiam.ToString()).
                        SetFricModuleFunc(newValue);
                    _objAsHeat.FrameFunction = (FSWShoulder)builder;
                }
            }
        }
    }
}
