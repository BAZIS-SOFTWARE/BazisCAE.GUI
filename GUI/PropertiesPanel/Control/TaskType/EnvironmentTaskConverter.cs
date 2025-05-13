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
        public EnvironmentTaskConverter(IPhysicalData obj, List<IGroup> groupElement, List<string> func)
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
                    { "Траектория(default)", _media.LocalFrame?.ToString() }
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
                data.Add("Траектория(default)", _media.LocalFrame?.ToString());
            }
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_media.TemperatureFunc == "*" && _media.HeatExchangeFunc != "*") 
            {
                property.Add(RowProperty.CreateComboBox("Группа элементов", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                property.Add(RowProperty.CreateComboBox("Коэф. теплоотдачи", _media.HeatExchangeFunc, _func, false));
                property.Add(RowProperty.CreateTextBox("Температура среды", _media.TemperatureValue.ToString(), ValidationType.FloatAny));
            }
            else
            {
                property.Add(RowProperty.CreateComboBox("Группа", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                property.Add(SelectData("Коэф. теплоотдачи", _media.HeatExchangeValue.ToString(), _media.HeatExchangeFunc));
                property.Add(SelectData("Температура среды", _media.TemperatureValue.ToString(), _media.TemperatureFunc));

            }
            property.Add(RowProperty.CreateTextBox("Старт, сек.", _media.StartTime.ToString(), ValidationType.FloatPositive));
            property.Add(RowProperty.CreateTextBox("Стоп, сек.", _media.StopTime.ToString(), ValidationType.FloatPositive));
            return property;
        }
        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            data[header] = newValue;
            if (header == "Коэф. теплоотдачи")
            {
                if (float.TryParse(newValue, out float res)) _media.HeatExchangeValue = float.Parse(newValue);
                else _media.HeatExchangeFunc = newValue;
            }
            else if (header == "Температура среды") _media.TemperatureValue = float.Parse(newValue);
        }
        private RowProperty SelectData(string header, string value, string func)
        {
            if (func == "*")
            {
                if (!_func.Contains(value)) _func.Add(value);
                return RowProperty.CreateComboBox(header, value, _func, true, ValidationType.None);
            }
            else
                return RowProperty.CreateComboBox(header, func, _func, true, ValidationType.None);
        }
    }
}
