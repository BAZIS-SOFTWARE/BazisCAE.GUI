using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty
{
    public  class ThermalCycleGetRowProperty : EnvironmentTaskConverter
    {
        private List<string> _func;
        public ThermalCycleGetRowProperty(IData obj, List<string> func, List<IGroup> groupElement) 
        {
            _func = func;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", value[0] },
                { "Коэф. теплоотдачи, Вт/мм2", value[1] },
                { "Температура среды", value[2] },
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
                RowProperty.CreateComboBox("Группа элементов", data["Группа элементов"], dataGroupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Коэф. теплоотдачи, Вт/мм2", data["Коэф. теплоотдачи, Вт/мм2"], _func),
                RowProperty.CreateTextBox("Температура среды", data["Температура среды"], ValidationType.FloatAny),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }   
    }
}
