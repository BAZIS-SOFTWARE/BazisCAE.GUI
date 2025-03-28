using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control.TaskType;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control
{
    public abstract class DataControl : PanelConverter
    {
        protected Dictionary<string, string> data;
        protected IData selectObj;
        protected List<IGroup> dataGroupElement;

        private static List<IGroup> _groupElement;
        public static DataControl SelectTask(IData obj, List<string> func, List<string> mat, List<IGroup> allGroupElement)
        {
            _groupElement = allGroupElement;
            if (obj.Name == NodeType.Материал.ToString()) return new MatTaskControl(obj, mat, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Среда.ToString()) return EnvironmentTaskControl.SubtaskSelection(obj, func, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Нагрев.ToString()) return HeatTaskControl.SubtaskSelection(obj, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Закрепление.ToString()) return new ClampTaskControl(obj, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Нагрузка.ToString()) return new LoadTaskControl(obj, func, GetGroupsByObjTypeFromOnesName(obj));
            else throw new NotImplementedException("Тип задачи не определен");
        }

        public static List<IGroup> GetGroupsByObjTypeFromOnesName(IData data, string groupName = null)
        {
            var groupElements = _groupElement;
            if (groupName == null)
            {
                groupName = data.GetInfo.Split(' ')[0];
            }
            var referenceGroup = groupElements.Find(x => x.Name == groupName);
            if (referenceGroup == null)
            {
                groupName = data.GetInfo.Split(' ')[1];
                referenceGroup = groupElements.Find(x => x.Name == groupName);
            }
            return referenceGroup != null
                ? groupElements.Where(y => y.ObjType == referenceGroup.ObjType).ToList() : new List<IGroup>();


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