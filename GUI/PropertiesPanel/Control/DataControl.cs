using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control.TaskType;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;

namespace BazisGUI.PropertiesPanel.Control
{
    public abstract class DataControl : PanelConverter
    {
        public override List<RowProperty> GetRowProperty()
        {
            return base.GetRowProperty();
        }

        public static DataControl SelectTask(IData obj, List<string> func, List<string> mat, List<IGroup> groupElement)
        {
            if (obj.Name == NodeType.Материал.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Среда.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Нагрев.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Закрепление.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Нагрузка.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else throw new NotImplementedException("Тип задачи не определен");
        }
        //Debug.WriteLine($"GetInfo return - {_dataRow},\nName return - {obj.Name}");
    }
}