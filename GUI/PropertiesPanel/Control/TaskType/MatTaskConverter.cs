using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class MatTaskConverter : DataConverter
    {
        private readonly List<string> _mat;
        private MatData _matData;
        private readonly List<IGroup> _dataObjectType;

        public MatTaskConverter(IPhysicalData obj, List<string> mat, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            _mat = mat;

            dataGroupElement = groupElement;
            selectObj = obj;
            _matData = obj as MatData;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", _matData.Group.Name },
                { "Материал", _matData.MatName},
                { "Старт, сек.", _matData.StartTime.ToString()},
                { "Стоп, сек.", _matData.StopTime.ToString()},
            };
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                //RowProperty.CreateTextBox("Имя", NodeType.Материал.ToString(), ValidationType.None, true),
                RowProperty.CreateComboBox("Группа элементов", data["Группа элементов"], _dataObjectType.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Материал", data["Материал"],_mat),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            _matData.MatName = newValue;
        }
    }
}
