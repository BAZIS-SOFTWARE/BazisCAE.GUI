using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BazisGUI.PropertiesPanel.Control.TaskType.HeatsRowProperty
{
    class ARCGetRowProperty : HeatTaskControl
    {
        private readonly List<IGroup> _groupElement;
        private readonly List<IGroup> _groupLine;
        private string _set;
        private IData _selectObj;
        public ARCGetRowProperty(IData obj, List<IGroup> groupElement)
        {
            _selectObj = obj;
            _groupElement = groupElement;
            dataGroupElement = groupElement;
            _set = obj.GetInfo;
            var set = obj.GetInfo.Split(' ');
            var processParameters = set[0].Split(';');
            var movementParameters = set[4].Split(';');
            var line = movementParameters[0].Split('|');
            var sourcePosition = movementParameters[4].Split('|');

            _groupLine = GetGroupsByObjTypeFromOnesName(obj, line[0]);

            data = new Dictionary<string, string>()
            {
                { "Вид сварки", processParameters[0] },
                { "Ширина шва (L), мм", processParameters[1] },
                { "Ток, А", processParameters[2] },
                { "Напряжение, В", processParameters[3] },
                { "Группа элементов", set[1] },
                { "Старт, сек.", set[2] },
                { "Стоп, сек.",set[3] },
                { "Линия движения",line[0] },
                { "Опорная линия",line[1] },
                { "Скорость сварки, мм/cек.",movementParameters[1] },
                { "Точка начала сварки",movementParameters[2] },
                { "Точка остановки сварки",movementParameters[3] },
                { "Положение источника X",sourcePosition[0] },
                { "Положение источника Y",  sourcePosition[1] },
                { "Положение источника Z",sourcePosition[2] },
                { "Положение источника andle",sourcePosition[3] }
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

        //public override void UpdateObject(PropertyChangedEventArgs e)
        //{
        //    data[e.Header] = e.NewValue.ToString();

        //    var sb = new StringBuilder();
        //    sb.Append($"{data["Вид сварки"]};{data["Ширина шва (L), мм"]};{data["Ток, А"]};{data["Напряжение, В"]} "); // processParameters
        //    sb.Append($"{data["Группа элементов"]} {data["Старт, сек."]} {data["Стоп, сек."]} "); // set
        //    sb.Append($"{data["Линия движения"]}|{data["Опорная линия"]};"); // line
        //    sb.Append($"{data["Скорость сварки, мм/cек."]};{data["Точка начала сварки"]};{data["Точка остановки сварки"]};"); // movementParameters
        //    sb.Append($"{data["Положение источника X"]}|{data["Положение источника Y"]}|{data["Положение источника Z"]}|{data["Положение источника andle"]}"); // sourcePosition

        //    _set = sb.ToString();

        //    if (e.Header == "Группа элементов" || e.Header == "Линия движения" || e.Header == "Опорная линия" || e.Header == "Точка начала сварки" || e.Header == "Точка остановки сварки")
        //    {
        //        var k = selectObj as IValuableData;
        //        var group = dataGroupElement.Find(x => x.Name == e.NewValue.ToString());
        //        k.Group = group;
        //    }
        //    Debug.WriteLine(_selectObj.GetInfo);
        //    Debug.WriteLine(_set);
        //    _selectObj.SetInfo(_set); // Error
        //    var s = _selectObj as HeatData;
        //    s.SetInfo(_set);
        //    var r = s as IData;
        //    _selectObj = r;
        //    Debug.WriteLine(_selectObj.GetInfo);
        //    //selectObj.SetInfo(_set);
        //    //var k1 = selectObj as IValuableData;
        //    //selectObj = new HeatData(k1.Group, _set);
        //}
    }
}
