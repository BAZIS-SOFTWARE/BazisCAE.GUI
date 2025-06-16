using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        public event Action<DrowPropertyOnPanelEventArgs> Out;
        public event Action OnUpdateNavigator;

        public List<IGroup> AllGroup;
        public List<string> _funcDBNames;
        public List<string> _matDBNames;

        private PanelConverter _converter;

        public void ShowPropertiesPanel<T>(T obj)
        {
            InitializeConverter(obj);
            Out(new DrowPropertyOnPanelEventArgs(_converter.GetRowProperty()));
        }

        private void InitializeConverter<T>(T obj)
        {
            if (obj is ISetInfo setInfo) _converter = new SetInfoConverter(setInfo);

            else if (obj is IGroup group) _converter = new GroupConverter(group);

            else if (obj is IPhysicalData data)
            {
                _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, AllGroup);
            }
            else throw new NotImplementedException("Тип конвертера не определен");
        }

        public bool ValidationData(string tag, string newValue, out string corrected)
        {
            var type = Converters.StringToEnum<ValidationType>(tag);
            corrected = newValue;
            if (type.HasFlag(ValidationType.Text))
            {
                if (newValue == null || newValue.Contains(" "))
                {
                    MessageBox.Show("Имя не должно содержать пробелов или быть пустым", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (type.HasFlag(ValidationType.Float))
            {
                if (newValue.Contains(" "))
                {
                    newValue = newValue.Replace(" ", "");
                }
                if (!float.TryParse(newValue, out _))
                {
                    MessageBox.Show("Не верный формат данных", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (type.HasFlag(ValidationType.PositiveOnly))
            {
                if (Convert.ToDouble(newValue) < 0)
                {
                    MessageBox.Show("Не допустимо отрицательное значение", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            corrected = newValue;
            return true;
        }
        public void UpdateObjectValue(string header, string newValue, string oldValue)
        {
            _converter.UpdateObject(header, newValue);
            OnUpdateNavigator.Invoke();
        }
    }
}