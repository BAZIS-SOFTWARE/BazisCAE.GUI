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
        protected Dictionary<string, string> data;
        protected IData selectObj;
        protected List<IGroup> dataGroupElement;

        public static DataControl SelectTask(IData obj, List<string> func, List<string> mat, List<IGroup> groupElement)
        {
            if (obj.Name == NodeType.Материал.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Среда.ToString()) return EnvironmentTaskControl.SubtaskSelection(obj, func, groupElement);
            else if (obj.Name == NodeType.Нагрев.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Закрепление.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else if (obj.Name == NodeType.Нагрузка.ToString()) return new MatTaskControl(obj, mat, groupElement);
            else throw new NotImplementedException("Тип задачи не определен");
        }

        public override void UpdateObject(PropertyChangedEventArgs e)
        {
            data[e.Header] = e.NewValue.ToString();
            var set = string.Join(" ", data.Values);
            if (e.Header == "Группа элементов" || e.Header == "Группа узлов")
            {
                var k = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == e.NewValue.ToString());
                k.Group = group;
            }
            selectObj.SetInfo(set);
        }
    }
}