using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control;
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

        public Func<List<string>> GetFuncDB;
        public Func<List<string>> GetMatDB;
        public Func<List<IGroup>> GetAllGroupElements;

        private List<string> _funcDBNames;
        private List<string> _matDBNames;
        private PanelConverter _converter;
        
        public void ShowPropertiesPanel<T>(T obj, TreeNode selectedNode)
        {
            InitializeConverter(obj);
            Out(new DrowPropertyOnPanelEventArgs(_converter.GetRowProperty()));
        }

        private void InitializeConverter<T>(T obj)
        {
            if (obj is ISetInfo setInfo) _converter = new SetInfoConverter(setInfo);

            else if (obj is IGroup group) _converter = new GroupConverter(group);

            else if (obj is IData data)
            {
                _matDBNames = _matDBNames is null ? GetMatDB() : _matDBNames;
                _funcDBNames = _funcDBNames is null ? GetFuncDB() : _funcDBNames;
                _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, GetAllGroupElements());
            }
            else throw new NotImplementedException("Тип конвертера не определен");
        }

        public bool ValidationData(string header, string newValue)
        {
            if(header == "Имя")
            {
                if (newValue == null || newValue.Contains(" "))
                {
                    MessageBox.Show("Имя не должно содержать пробелов или быть пустым", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if(header == "Старт, сек." || header == "Стоп, сек.")
            {
                if(newValue == null || !float.TryParse(newValue, out _) || newValue.Contains(" "))
                {
                    MessageBox.Show("Не верный формат данных", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        public void UpdateObjectValue(string header, string newValue, string oldValue)
        {
            _converter.UpdateObject(header, newValue, oldValue);
            OnUpdateNavigator.Invoke();
        }
    }
}