using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType.HeatsRowProperty
{
    class ARCGetRowProperty : HeatTaskControl
    {
        private readonly List<IGroup> _groupElement;
        private readonly List<IGroup> _groupLine;
        private string _set;
        public ARCGetRowProperty(IData obj, List<IGroup> groupElement)
        {
            selectObj = obj;
            _groupElement = groupElement;
            _set = obj.GetInfo;
            var set = obj.GetInfo.Split(' ');
            var processParameters = set[0].Split(';');
            var movementParameters = set[4].Split(';');
            var line = movementParameters[0].Split('|');

            _groupLine = GetGroupsByObjTypeFromOnesName(obj, line[0]);

            data = new Dictionary<string, string>()
            {
                { "Группа элементов", set[1] },
                { "Ширина шва (L), мм", processParameters[1] },
                { "Ток, А", processParameters[2] },
                { "Напряжение, В", processParameters[3] },
                { "Старт, сек.", set[2] },
                { "Стоп, сек.",set[3] },
                { "Линия движения",line[0] },
                { "Опорная линия",line[1] },
                { "Скорость сварки, мм/cек.",movementParameters[1] },
                { "Точка начала сварки",movementParameters[2] },
                { "Точка остановки сварки",movementParameters[3] },
                { "Положение источника X",set[2] },
                { "Положение источника Y",  set[2] },
                { "Положение источника Z",set[2] },
                { "Положение источника andle",set[3] }
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateComboBox("Группа элементов", data["Группа элементов"], _groupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Ширина шва (L), мм", data["Ширина шва (L), мм"]),
                RowProperty.CreateTextBox("Ток, А", data["Ток, А"]),
                RowProperty.CreateTextBox("Напряжение, В", data["Напряжение, В"]),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."]),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], true),
                RowProperty.CreateComboBox("Линия движения", data["Линия движения"], _groupLine.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Опорная линия", data["Опорная линия"], _groupLine.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Скорость сварки, мм/cек.", data["Скорость сварки, мм/cек."]),
                RowProperty.CreateComboBox("Точка начала сварки", data["Точка начала сварки"], _groupLine.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Точка остановки сварки", data["Точка остановки сварки"], _groupLine.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Положение источника X", data["Положение источника X"]),
                RowProperty.CreateTextBox("Положение источника Y", data["Положение источника Y"]),
                RowProperty.CreateTextBox("Положение источника Z", data["Положение источника Z"]),
                RowProperty.CreateTextBox("Положение источника andle", data["Положение источника andle"]),
            };
        }

        public override void UpdateObject(PropertyChangedEventArgs e)
        {
            data[e.Header] = e.NewValue.ToString();
            _set.Replace(e.OldValue.ToString(), e.NewValue.ToString());
            //var set = string.Join(" ", data.Values);
            if (e.Header == data["Линия движения"] || e.Header == data["Группа элементов"])
            {
                var k = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == e.NewValue.ToString());
                k.Group = group;
            }
            selectObj.SetInfo(_set);
        }
    }
}
