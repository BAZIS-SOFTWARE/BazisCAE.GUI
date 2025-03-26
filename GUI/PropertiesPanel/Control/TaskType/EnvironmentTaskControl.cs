using BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public abstract class EnvironmentTaskControl : DataControl
    {
        public static EnvironmentTaskControl SubtaskSelection(IData obj, List<string> func, List<IGroup> groupElement)
        {
            var data = obj.GetInfo.Split(' ');
            if (data[1] == "*" && !float.TryParse(data[2], out _))
            {
                return new HeatFlowGetRowProperty(obj, func, groupElement);
            }
            else
            {
                return new ThermalCycleGetRowProperty(obj, func, groupElement);
            }
        }
    }
}
