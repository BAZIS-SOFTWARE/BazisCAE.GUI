using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class EnvironmentTaskConverter : DataConverter
    {
        private List<string> _func;
        private MediaData _media;
        public EnvironmentTaskConverter(ICondData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _func = func;
            _media = obj as MediaData;
            if (_media.TemperatureFunc == "*" && _media.HeatExchangeFunc != "*")
            {
                data = new Dictionary<string, string>()
                {
                    { "Группа элементов", _media.Group.Name },
                    { "Коэф. теплоотдачи, Вт/мм2", _media.HeatExchangeFunc },
                    { "Температура среды", _media.TemperatureValue.ToString() },
                    { "Старт, сек.", _media.StartTime.ToString() },
                    { "Стоп, сек.", _media.StopTime.ToString() },
                    { "Траектория(default)", _media.FrameFunction?.LocalFrame?.ToString() }
                };
            }
            else
            {
                data = new Dictionary<string, string>();
                data.Add("Группа", _media.Group.Name);
                data.Add("Коэф. теплоотдачи",
                    _media.HeatExchangeFunc == "*" ? _media.HeatExchangeValue.ToString() : _media.HeatExchangeFunc);
                data.Add("Температура среды",
                    _media.TemperatureFunc == "*" ? _media.TemperatureValue.ToString() : _media.TemperatureFunc);
                data.Add("Старт, сек.", _media.StartTime.ToString());
                data.Add("Стоп, сек.", _media.StopTime.ToString());
                data.Add("Траектория(default)", _media.FrameFunction.LocalFrame?.ToString());
            }
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_media.TemperatureFunc == "*" && _media.HeatExchangeFunc != "*") 
            {
                property.Add(new RowProperty("Группа элементов", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                property.Add(new RowProperty("Коэф. теплоотдачи", _media.HeatExchangeFunc, _func));
                property.Add(new RowProperty("Температура среды", _media.TemperatureValue.ToString()));
            }
            else
            {
                property.Add(new RowProperty("Группа", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                property.Add(SelectData("Коэф. теплоотдачи", _media.HeatExchangeValue.ToString(), _media.HeatExchangeFunc));
                property.Add(SelectData("Температура среды", _media.TemperatureValue.ToString(), _media.TemperatureFunc));

            }
            property.Add(new RowProperty("Старт, сек.", _media.StartTime.ToString()));
            property.Add(new RowProperty("Стоп, сек.", _media.StopTime.ToString()));
            return property;
        }
        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            data[header] = newValue;
            if (header == "Коэф. теплоотдачи")
            {
                _media.TrySetHeatExchange(newValue);
            }
            else if (header == "Температура среды") _media.TrySetTemp(newValue);
        }
        private RowProperty SelectData(string header, string value, string func)
        {
            if (func == "*")
            {
                if (!_func.Contains(value)) _func.Add(value);
                return new RowProperty(header, value, _func);
            }
            else
                return new RowProperty(header, func, _func);
        }
    }
}
