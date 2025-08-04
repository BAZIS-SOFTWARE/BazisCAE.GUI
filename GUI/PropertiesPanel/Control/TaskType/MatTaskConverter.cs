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

        public MatTaskConverter(MatData obj, List<string> mat, List<IGroup> groupElement)
        {
            _mat = mat;
            _matData = obj;
            dataGroupElement = groupElement;
            selectObj = obj;
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
                new RowProperty("Группа элементов", data["Группа элементов"], dataGroupElement.Select(x => x.Name).ToList()),
                new RowProperty("Материал", data["Материал"],  _mat),
                new RowProperty("Старт, сек.", data["Старт, сек."]),
                new RowProperty("Стоп, сек.", data["Стоп, сек."])
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            if(header == "Материал") _matData.MatName = newValue;
        }
    }
}
