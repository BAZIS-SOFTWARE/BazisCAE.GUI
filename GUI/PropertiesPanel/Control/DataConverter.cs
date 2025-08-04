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