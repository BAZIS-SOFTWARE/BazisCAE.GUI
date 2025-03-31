using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class MatTaskControl : DataControl
    {
        private readonly List<string> _mat;
        private readonly List<IGroup> _dataObjectType;

        public MatTaskControl(IData obj, List<string> mat, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            _mat = mat;
            var value = obj.GetInfo.Split(' ');
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
                RowProperty.CreateTextBox("Имя", NodeType.Материал.ToString(), true),
                RowProperty.CreateComboBox("Группа элементов", data["Группа элементов"], _dataObjectType.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Материал", data["Материал"],_mat),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."]),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."])
            };
        }
    }
}
