using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Functions.Search;
using TaskModule.BasicAdvisorControls;
using Project;
using System.Linq;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.TaskPlannerControls;

namespace TaskModule.BasicTaskAdvisor
{
    public partial class TaskAdvisor : UserControl
    {

        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;
        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, ChangeTaskTypeEventArgs> Select2DPlaneEvent;
        public event Action<object, ChangeTaskTypeEventArgs> Select2DAxiEvent;
        public event Action<object, ChangeTaskTypeEventArgs> Select3DEvent;
        public event Action<object, string> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, EventArgs> AddDataUseTaskConditionsEvent;

        public TaskAdvisor()
        {
            InitializeComponent();
        }

        TaskTypeControl taskTypeControl {
            get
            {
                var searched = new List<TaskTypeControl>();
                RecursiveSearch.AllTypedControls(this, searched);
                return searched[0];
            }
        }

        TabControl tabControl
        {
            get
            {
                var searched = new List<TabControl>();
                RecursiveSearch.AllTypedControls(this, searched);

                return searched[0];
            }
        }     

        public void SetProjectData(ProjectData project)
        {
            var taskType = project.TaskType.ToString();
            taskTypeControl.SetTaskType(taskType);

            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is INodesGroupControl nGrControl)
                        nGrControl.Fill_nGroups(project.Model.GroupData.FindMany("Узлы").Select(x => x.GroupName).ToList());

                    if (control is IElmentsGroupsControl eGrControl)
                        if (taskType == "Plain" | taskType == "AxiPlain")
                        {

                            eGrControl.Fill_eGroups(project.Model.GroupData.FindMany("Элементы1D").Select(x => x.GroupName).ToList());
                            eGrControl.Fill_eGroups(project.Model.GroupData.FindMany("Элементы2D").Select(x => x.GroupName).ToList());
                        }
                        else
                        {
                            eGrControl.Fill_eGroups(project.Model.GroupData.FindMany("Элементы2D").Select(x => x.GroupName).ToList());
                            eGrControl.Fill_eGroups(project.Model.GroupData.FindMany("Элементы3D").Select(x => x.GroupName).ToList());
                        }

                    if (control is GridViewAdviserControl grvControl)
                    {
                        if(grvControl is TaskPlannerControl taskPlannerControl)
                            taskPlannerControl.Path = project.Path;

                        var data = project.TaskData.GetAllData().
                            Where(x => x.Name == grvControl.DataName).
                            Select(x => x.GetInfo);
                        grvControl.Set_DataGridLines(data);
                    }
                }
            }
        }

        public void SetMaterialData(List<string> materialNames)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is IMaterialsRelatedControl materialsRelatedControl)
                        materialsRelatedControl.Add_Materials(materialNames);
                }
            }
        }

        public void SetFunctionData(List<string> functionNames)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is IFunctionsRelatedControl functionsRelatedControl)
                        functionsRelatedControl.Add_Functions(functionNames);
                }
            }
        }

        public virtual void TaskPlannerControl1_StartComputationEvent(object arg1, string arg2)
        {
            StartComputationEvent(this, arg2);
        }


        public virtual void Control_ShowDataEvent(object arg1, ShowDataEventArgs arg2)
        {
            ShowDataEvent(this, arg2);
        }

        public virtual void Control_ChangeDataEvent(object arg1, ChangeDataEventArgs arg2)
        {
            ChangeDataEvent(this, arg2);
        }

        public virtual void Control_DeleteDataEvent(object arg1, DeleteDataEventArgs arg2)
        {
            DeleteDataEvent(this, arg2);
        }

        public virtual void Control_DeleteAllDataEvent(object arg1, DeleteAllDataEventArgs arg2)
        {
            DeleteAllDataEvent(this, arg2);
        }

        public virtual void Control_AddDataEvent(object arg1, AddDataEventArgs arg2)
        {
            AddDataEvent(this, arg2);
        }

        public virtual void Control_CheckDataEvent(object arg1, CheckDataEventArgs arg2)
        {
            CheckDataEvent(this, arg2);
        }

        public virtual void Control_HideDataEvent(object arg1, HideDataEventArgs arg2)
        {
            HideDataEvent(this, arg2);
        }

        public virtual void taskTypeControl_Select2DAxiTaskEvent(object arg1, EventArgs arg2)
        {
            Select2DAxiEvent(this, new ChangeTaskTypeEventArgs(1));
        }

        public virtual void taskTypeControl_Select2DPlaneTaskEvent(object arg1, EventArgs arg2)
        {
            Select2DPlaneEvent(this, new ChangeTaskTypeEventArgs(0));
        }

        public virtual void taskTypeControl_Select3DTaskEvent(object arg1, EventArgs arg2)
        {
            Select3DEvent(this, new ChangeTaskTypeEventArgs(2));
        }

        public virtual void TaskPlannerControl1_StopComputationEvent(object arg1, EventArgs arg2)
        {
            StopComputationEvent(this, arg2);
        }

        public virtual void TaskPlannerControl1_AddDataUseTaskConditionsEvent(object arg1, EventArgs arg2)
        {

        }


        public virtual void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush;

            // Get the item from the collection. 
            TabPage _TabPage = tabControl.TabPages[e.Index];

            // Use our own font. Because we CAN. 
            Font _TabFont = new Font(e.Font.FontFamily, (float)11, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text. 
            StringFormat _StringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Get the real bounds for the tab rectangle. 
            Rectangle _TabBounds = tabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle. 
                g.FillRectangle(Brushes.Gray, e.Bounds);

                _TextBrush = new SolidBrush(System.Drawing.Color.White);
                g.DrawImage(tabControl.ImageList.Images[_TabPage.ImageIndex], new Point(e.Bounds.X + 5, e.Bounds.Y + 7));
            }
            else
            {
                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
                g.DrawImage(tabControl.ImageList.Images[_TabPage.ImageIndex], new Point(e.Bounds.X + 1, e.Bounds.Y + 5));
            }
            g.DrawString(tabControl.TabPages[e.Index].Text, _TabFont, _TextBrush,
        new PointF(
            tabControl.ImageList.Images[_TabPage.ImageIndex].Width / 2 +
            _TabBounds.X + _TabBounds.Width / 2, _TabBounds.Height - _TabFont.Height), new StringFormat(_StringFlags));
        }
  
    }
}
