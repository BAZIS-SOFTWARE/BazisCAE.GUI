using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control
{
    public class GeneralTaskTypeConverter : PanelConverter
    {
        public event Action<string> UpdateTaskTupeEvent; 
        private readonly string[] _generalType;
        public GeneralTaskTypeConverter(string[] data)
        {
            _generalType = data;
        }

        public override List<RowProperty> GetRowProperty()
        {
            var value = _generalType[1];
            return new List<RowProperty>
            {
                RowProperty.CreateComboBox("Вид", value.Trim(), Converters.GetEnumNames<Project.Interfaces.Tasks.TaskType>().ToList())
            };
        }
        public override void UpdateObject(string header, string newValue)
        {
            UpdateTaskTupeEvent?.Invoke(newValue);
        }
    }
}
