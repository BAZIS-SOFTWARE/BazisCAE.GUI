using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty;
using BazisGUI.PropertiesPanel.Control.TaskType.HeatsRowProperty;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class HeatTaskControl : DataControl
    {


        public static HeatTaskControl SubtaskSelection(IData obj, List<IGroup> groupElement)
        {
            var data = obj.GetInfo.Split(' ');
            var processParameters = data[0].Split(';');
            var weldingType = processParameters[0];

            if(weldingType == HeatSources.ARC.ToString()) return new ARCGetRowProperty(obj, groupElement);
            else if (weldingType == HeatSources.LW.ToString()) return new LWGetRowProperty();
            else if (weldingType == HeatSources.FSWPin.ToString()) return new FSWPinGetRowProperty();
            else if (weldingType == HeatSources.FSWShoulder.ToString()) return new FSWShoulderGetRowProperty();
            else throw new NotImplementedException("Тип задачи не определен");
        }
    }
}
