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
    public abstract class DataConverter : PanelConverter
    {
        protected Dictionary<string, string> data;
        protected ICondData selectObj;
        protected List<IGroup> dataGroupElement;

        private static List<IGroup> _groupElement;
        public static DataConverter CreateConverter(ICondData obj, List<string> func, List<string> mat, List<IGroup> allGroupElement)
        {
            _groupElement = allGroupElement;
            if (obj.Kind.ToString() == NodeName.Материал.ToString()) return new MatTaskConverter(obj, mat, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Kind.ToString() == NodeName.Среда.ToString()) return new EnvironmentTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj), func);
            else if (obj.Kind.ToString() == NodeName.Нагрев.ToString()) return new HeatTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj), func);
            else if (obj.Kind.ToString() == NodeName.Закрепление.ToString()) return new ClampTaskConverter(obj, GetGroupsByObjTypeFromOnesName(obj));
            else if (obj.Kind.ToString() == NodeName.Нагрузка.ToString()) return new LoadTaskConverter(obj, func, GetGroupsByObjTypeFromOnesName(obj));
            else throw new NotImplementedException("Тип задачи не определен");
        }

        public static List<IGroup> GetGroupsByObjTypeFromOnesName(ICondData data, string groupName = null)
        {
            if (string.IsNullOrEmpty(groupName))
                groupName = data.Group.Name;

            var group = _groupElement.Find(x => x.Name == groupName);
            return _groupElement.Where(x => x.ObjType == group.ObjType).ToList();
        }

        public override void UpdateObject(string header, string newValue)
        {
            if (header.Contains("Группа"))
            {
                var group = dataGroupElement.Find(x => x.Name == newValue.ToString());
                selectObj.Group = group;
            }
            else if (header == "Старт, сек.") selectObj.StartTime = float.Parse(newValue);
            else if (header == "Стоп, сек.") selectObj.StopTime = float.Parse(newValue);
        }
    }
}