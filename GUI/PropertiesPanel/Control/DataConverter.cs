using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control.TaskType;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control
{
    public abstract class DataConverter : PanelConverter
    {
        protected Dictionary<string, string> data;
        protected IData selectObj;
        protected List<IGroup> dataGroupElement;

        private static List<IGroup> _groupElement;
        public static DataConverter CreateConverter(IData obj, List<string> func, List<string> mat, List<IGroup> allGroupElement)
        {
            _groupElement = allGroupElement;
            if (obj.Name == NodeType.Материал.ToString()) return new MatTaskConverter(obj, mat, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Среда.ToString()) return new EnvironmentTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj), func);
            else if (obj.Name == NodeType.Нагрев.ToString()) return new HeatTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj), func);
            else if (obj.Name == NodeType.Закрепление.ToString()) return new ClampTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Name == NodeType.Нагрузка.ToString()) return new LoadTaskConverter(obj, func, GetGroupsByObjTypeFromOnesName(obj));
            else throw new NotImplementedException("Тип задачи не определен");
        }

        public static List<IGroup> GetGroupsByObjTypeFromOnesName(IData data, string groupName = null)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                if (data is HeatData htd)
                    groupName = htd.Group.Name;
                else
                    groupName = data.GetInfo.Split(' ')[0];
            }
            var group = _groupElement.Find(x => x.Name == groupName);
            return _groupElement.Where(x => x.ObjType == group.ObjType).ToList();
        }

        public override void UpdateObject(string header, string newValue, string oldValue)
        {
            data[header] = newValue.ToString();
            var set = string.Join(" ", data.Values);
            if (header.Contains("Группа"))
            {
                var k = selectObj as IValuableData;
                var group = dataGroupElement.Find(x => x.Name == newValue.ToString());
                k.Group = group;
            }
            selectObj.SetInfo(set);
        }
    }
}