#if false
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty
{
    public class HeatFlowGetRowProperty : EnvironmentTaskConverter
    {
        private List<string> _func;
        public HeatFlowGetRowProperty(IData obj, List<string> func, List<IGroup> groupElement)
        {
            _func = func;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа узлов", value[0] },
                { "Коэф. теплоотдачи (default)", value[1] },
                { "Функция, F(t), °С - сек.", value[2] },
                { "Старт, сек.", value[3] },
                { "Стоп, сек.", value[4] },
                { "Траектория(default)", value[5] }
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", NodeType.Среда.ToString(), ValidationType.None, true),
                RowProperty.CreateComboBox("Группа узлов", data["Группа узлов"], dataGroupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Функция, F(t), °С - сек.", data["Функция, F(t), °С - сек."], _func),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }
    }
}
#endif