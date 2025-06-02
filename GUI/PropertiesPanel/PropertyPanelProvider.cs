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
        public event Action<string> OnUpdateTaskType;
        public event Action SendMessageInConsole;

        public Func<List<string>> GetFuncDB;
        public Func<List<string>> GetMatDB;
        public Func<List<IGroup>> GetAllGroupElements;

        private List<string> _funcDBNames;
        private List<string> _matDBNames;
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
                _matDBNames = _matDBNames is null ? GetMatDB() : _matDBNames;
                _funcDBNames = _funcDBNames is null ? GetFuncDB() : _funcDBNames;
                _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, GetAllGroupElements());
            }

            else if (obj is string[] st) 
            {
                _converter = new GeneralTaskTypeConverter(st);
                var generalTaskType = _converter as GeneralTaskTypeConverter;
                generalTaskType.UpdateTaskTupeEvent += GeneralTaskTupe_UpdateTaskTupeEvent;
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
            OnUpdateNavigator?.Invoke();
        }

        private void GeneralTaskTupe_UpdateTaskTupeEvent(string type)
        {
            if (OnUpdateTaskType != null) OnUpdateTaskType?.Invoke(type);
            else SendMessageInConsole?.Invoke();
        }
    }
}