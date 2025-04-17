using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class EnvironmentTaskConverter : DataConverter
    {
        private List<string> _func;
        private MediaData _media;
        public EnvironmentTaskConverter(IData obj, List<IGroup> groupElement, List<string> func)
        {
            selectObj = obj;
            dataGroupElement = groupElement;
            _func = func;
            _media = obj as MediaData;

            Debug.WriteLine($"MediaType {_media.MediaType}");
            Debug.WriteLine($"HeatExchangeFunc {_media.HeatExchangeFunc}");
            Debug.WriteLine($"HeatExchangeValue {_media.HeatExchangeValue}");
            Debug.WriteLine($"TemperatureFunc {_media.TemperatureFunc}");
            Debug.WriteLine($"TemperatureValue {_media.TemperatureValue}");

            if (_media.TemperatureFunc == "*" && _media.HeatExchangeFunc != "*")
            {
                data = new Dictionary<string, string>()
                {
                    { "Группа элементов", _media.Group.Name },
                    { "Коэф. теплоотдачи, Вт/мм2", _media.HeatExchangeFunc },
                    { "Температура среды", _media.TemperatureValue.ToString() },
                    { "Старт, сек.", _media.StartTime.ToString() },
                    { "Стоп, сек.", _media.StopTime.ToString() },
                    { "Траектория(default)", _media.TrajectoryInfo }
                };
            }
            else
            {
                data = new Dictionary<string, string>();

                data.Add("Группа", _media.Group.Name);
                if (_media.HeatExchangeFunc == "*") data.Add("Коэф. теплоотдачи", _media.HeatExchangeValue.ToString());
                else data.Add("Коэф. теплоотдачи", _media.HeatExchangeFunc);

                if (_media.TemperatureFunc == "*") data.Add("Температура среды", _media.TemperatureValue.ToString());
                else data.Add("Температура среды", _media.TemperatureFunc);
                data.Add("Старт, сек.", _media.StartTime.ToString());
                data.Add("Стоп, сек.", _media.StopTime.ToString());
                data.Add("Траектория(default)", _media.TrajectoryInfo);
            }
        }

        public override List<RowProperty> GetRowProperty()
        {
            var property = new List<RowProperty>();
            if (_media.TemperatureFunc == "*" && _media.HeatExchangeFunc != "*") //тепловой поток
            {
                property.Add(RowProperty.CreateTextBox("Имя", NodeType.Среда.ToString(), ValidationType.None, true));
                property.Add(RowProperty.CreateComboBox("Группа элементов", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                property.Add(RowProperty.CreateComboBox("Коэф. теплоотдачи, Вт/мм2", _media.HeatExchangeFunc, _func));
                property.Add(RowProperty.CreateTextBox("Температура среды", _media.TemperatureValue.ToString(), ValidationType.FloatAny));
                property.Add(RowProperty.CreateTextBox("Старт, сек.", _media.StartTime.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Стоп, сек.", _media.StopTime.ToString(), ValidationType.FloatPositive));
            }


            else
            {
                property.Add(RowProperty.CreateComboBox("Группа", _media.Group.Name, dataGroupElement.Select(x => x.Name).ToList()));
                if (_media.HeatExchangeFunc == "*")
                    property.Add(RowProperty.CreateTextBox("Коэф. теплоотдачи", _media.HeatExchangeValue.ToString()));
                else property.Add(RowProperty.CreateComboBox("Коэф. теплоотдачи", _media.HeatExchangeFunc, _func));
                if (_media.TemperatureFunc == "*")
                    property.Add(RowProperty.CreateTextBox("Температура среды", _media.TemperatureValue.ToString()));
                else property.Add(RowProperty.CreateComboBox("Температура среды", _media.TemperatureFunc, _func));
                property.Add(RowProperty.CreateTextBox("Старт, сек.", _media.StartTime.ToString(), ValidationType.FloatPositive));
                property.Add(RowProperty.CreateTextBox("Стоп, сек.", _media.StopTime.ToString(), ValidationType.FloatPositive));
            }
            return property;
        }
    }
}
