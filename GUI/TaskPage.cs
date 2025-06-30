using BaseModule.Extensions;
using BaseModule.GanttChart;
using BaseModule.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.TasksFromNavigator;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.TasksControls;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Newtonsoft.Json;
using PreProc;
using PreProc.Interfaces;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Project.TaskParameters;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions.Welding;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using PropertiesDataBases.DataBases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;

namespace BazisGUI
{
    
    public partial class BaseForm
    {
        //public Priority Priority { get; private set; }
        public ProcessType ProcessType{ get; set; }

        public event Action<object> NeedSaveProjectEvent;
        public event Action<object,string> SelectConditionEvent;
        public event Action<object, AddDataEventArgs> CreatePhysicalDataEvent;
        public event Action<object> DeleteAllPhysicalDataEvent;
        public event Action<object> ShowGantChartEvent;
        public event Action<object,string> AddPhysicalDataEvent;

        public event Action<object> GenerateTSFEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object> GenerateTCFEvent;
        public event Action<object, string> EditTSFEvent;

        PropertyPanelProvider panelProvider = new PropertyPanelProvider();
  

        public virtual TaskAdvisor GetTaskAdvisor()
        {
            throw new Exception("Мастер не реализован");
        }                  

        //private void ConfigureMenuItemEnabledForModule(string processType)
        //{
        //    if (processType == "ТО")
        //    {
        //        var mainItem = condsMenuStrip.Items["добавитьToolStripMenuItem"] as ToolStripMenuItem;
        //        if (mainItem != null)
        //        {
        //            var subItem = mainItem.DropDownItems["нагревToolStripMenuItem"];
        //            if (subItem != null) subItem.Enabled = false;
        //        }
        //    }
        //}
    }
}