using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class MatTaskConverter : DataConverter
    {
        private readonly List<string> _mat;
        private readonly List<IGroup> _dataObjectType;

        public MatTaskConverter(IPhysicalData obj, List<string> mat, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            _mat = mat;
            var value = obj.ToString().Split(':')[1].Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", value[0] },
                { "Материал", value[1]},
                { "Старт, сек.", value[2]},
                { "Стоп, сек.", value[3]},
            };
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", NodeType.Материал.ToString(), ValidationType.None, true),
                RowProperty.CreateComboBox("Группа элементов", data["Группа элементов"], _dataObjectType.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Материал", data["Материал"],_mat),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }
    }
}
