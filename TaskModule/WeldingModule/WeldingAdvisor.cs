
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.TaskPlannerControls;
using TaskModule.BasicTaskAdvisor;

namespace TaskModule.WeldingModule
{
    public partial class WeldingAdvisor : TaskAdvisor
    {
        public WeldingAdvisor()
        {
            InitializeComponent();
        }

        public override void TaskPlannerControl_StartComputationEvent(object arg1, EventArgs arg2)
        {
            base.TaskPlannerControl_StartComputationEvent(arg1, arg2);
        }


        public override void Control_ShowDataEvent(object arg1, ShowDataEventArgs arg2)
        {
            base.Control_ShowDataEvent(arg1, arg2);
        }

        public override void Control_ChangeDataEvent(object arg1, ChangeDataEventArgs arg2)
        {
            base.Control_ChangeDataEvent(arg1, arg2);
        }

        public override void Control_DeleteDataEvent(object arg1, DeleteDataEventArgs arg2)
        {
            base.Control_DeleteDataEvent(arg1, arg2);
        }

        public override void Control_DeleteAllDataEvent(object arg1, DeleteAllDataEventArgs arg2)
        {
            base.Control_DeleteAllDataEvent(arg1, arg2);
        }

        public override void Control_AddDataEvent(object arg1, AddDataEventArgs arg2)
        {
            base.Control_AddDataEvent(arg1, arg2);
        }

        public override void Control_CheckDataEvent(object arg1, CheckDataEventArgs arg2)
        {
            base.Control_CheckDataEvent(arg1, arg2);
        }

        public override void Control_HideDataEvent(object arg1, HideDataEventArgs arg2)
        {
            base.Control_HideDataEvent(arg1, arg2);
        }

        public override void taskTypeControl_Select2DAxiTaskEvent(object arg1, EventArgs arg2)
        {
            base.taskTypeControl_Select2DAxiTaskEvent(arg1, arg2);
        }

        public override void taskTypeControl_Select2DPlaneTaskEvent(object arg1, EventArgs arg2)
        {
            base.taskTypeControl_Select2DPlaneTaskEvent(arg1, arg2);
        }

        public override void taskTypeControl_Select3DTaskEvent(object arg1, EventArgs arg2)
        {
            base.taskTypeControl_Select3DTaskEvent(arg1, arg2);
        }

        public override void TaskPlannerControl1_StopComputationEvent(object arg1, EventArgs arg2)
        {
            base.TaskPlannerControl1_StopComputationEvent(arg1, arg2);
        }

        public override void TaskPlannerControl1_AddDataUseTaskConditionsEvent(object arg1, EventArgs arg2)
        {
            base.TaskPlannerControl1_AddDataUseTaskConditionsEvent(arg1, arg2);
        }

        public override void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            base.TabControl_DrawItem(sender, e);
        }

        public override void TaskPlannerControl_GenerateTCFEvent(object sender, GenerateTCFEventArgs e)
        {
            base.TaskPlannerControl_GenerateTCFEvent(sender, e);
        }
    }
}
