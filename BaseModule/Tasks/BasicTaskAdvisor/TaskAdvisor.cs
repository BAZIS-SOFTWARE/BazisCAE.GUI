using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls;
using System.Linq;
using TaskModule.BasicAdvisorControls.Interfaces;
using BaseModule.Utilities;
using UserControlsEx;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.BasicAdvisorControls.Interfaces;

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
        public event Action<object, EventArgs> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, EventArgs> AddDataUseTaskConditionsEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;


        //public ProcessType ProcessType 
        //{
        //    get
        //    {
        //        var cntrs = new List<TaskPlannerControl_v2>();
        //        RecursiveSearchControls.AllTypedControls(this, cntrs);
        //        return cntrs.First().ProcessType;
        //    }
        //    set
        //    {
        //        var cntrs = new List<TaskPlannerControl_v2>();
        //        RecursiveSearchControls.AllTypedControls(this, cntrs);
        //        cntrs.First().ProcessType = value;
        //    }
        //}

        public TaskAdvisor()
        {
            InitializeComponent();
        }

        public string TaskType {
            get
            {
                var cntrs = new List<TaskTypeControl>();
                RecursiveSearchControls.AllTypedControls(this, cntrs);
                return cntrs.First().TaskType;
            }
            set
            {
                var cntrs = new List<TaskTypeControl>();
                RecursiveSearchControls.AllTypedControls(this, cntrs);
                cntrs.First().TaskType = value;
            }
        }

        TabControl tabControl
        {
            get
            {
                var cntrs = new List<TabControlEx>();
                RecursiveSearchControls.AllTypedControls(this, cntrs);
                return cntrs.First();
            }
        } 
       

        public void SetProjectData(IEnumerable<string> data)
        {
            //var taskType = generalData.TaskType.ToString();
            //taskTypeControl.SetTaskType(taskType);

            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {   
                    if(control is ICheckGridViewControl gvControl)
                    {
                        var subData = data.
    Where(x => x.Contains(gvControl.DataName)).Select(y => y.Split(':')[1].
    Substring(1));
    //Select(x => x.GetInfo);

                        //if (control is ILoadControl loadControl)
                        //{
                        //    loadControl.Fill_nGroups(modelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList());
                        //    if (taskType == "Plain" | taskType == "AxiPlain")
                        //        loadControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList());
                        //    else
                        //        loadControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList());
                        //}

                        //else if (control is IBoundaryControl boundaryControl)
                        //{
                        //    boundaryControl.Fill_nGroups(modelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList());
                        //    if (taskType == "Plain" | taskType == "AxiPlain")
                        //        boundaryControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент1D).Select(x => x.Name).ToList());
                        //    else
                        //        boundaryControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList());
                        //}

                        //else if (control is IMaterialsRelatedControl materialsRelatedControl)
                        //{
                        //    if (taskType == "Plain" | taskType == "AxiPlain")
                        //        materialsRelatedControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList());
                        //    else
                        //        materialsRelatedControl.Fill_eGroups(modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList());
                        //}

                        //else if (control is TaskPlannerControl_v2 taskPlannerControl)
                        //{
                        //    taskPlannerControl.ProjPath = generalData.Path;
                        //}
                        gvControl.Set_DataGridLines(subData);
                    }
     
                }
            }
        }

        public void SetTaskPlannerlData(List<string> cmdFiles)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TaskPlannerControl_v2 taskPlannerControl)
                        taskPlannerControl.Set_DataGridLines(cmdFiles);

                }
            }
        }

        public void SetLoadGroups(List<string> eGrpsNames, List<string> nGrpsNames)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is ILoadControl loadControl)
                    {
                        loadControl.Fill_nGroups(nGrpsNames);
                        loadControl.Fill_eGroups(eGrpsNames);
                    }

                }
            }
        }

        public void SetBoundaryGroups(List<string> eGrpsNames, List<string> nGrpsNames)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is IBoundaryControl boundaryControl)
                    {
                        boundaryControl.Fill_nGroups(nGrpsNames);
                        boundaryControl.Fill_eGroups(eGrpsNames);
                    }
    
                }
            }
        }

        public void SetMaterialGroups(List<string> eGrpsNames)
        {
            foreach (TabPage tabPage in tabControl.Controls)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is IMaterialsRelatedControl materialsRelatedControl)
                        materialsRelatedControl.Fill_eGroups(eGrpsNames);
                }
            }
        }

        public void SetMaterials(List<string> materialNames)
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

        public void SetFunctions(List<string> functionNames)
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

        public virtual void TaskPlannerControl_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            GenerateTCFEvent(arg1,arg2);
        }

        public virtual void TaskPlannerControl_StartComputationEvent(object arg1, EventArgs arg2)
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
            Select2DAxiEvent?.Invoke(this, new ChangeTaskTypeEventArgs(1));
        }

        public virtual void taskTypeControl_Select2DPlaneTaskEvent(object arg1, EventArgs arg2)
        {
            Select2DPlaneEvent?.Invoke(this, new ChangeTaskTypeEventArgs(0));
        }

        public virtual void taskTypeControl_Select3DTaskEvent(object arg1, EventArgs arg2)
        {
            Select3DEvent?.Invoke(this, new ChangeTaskTypeEventArgs(2));
        }

        public virtual void TaskPlannerControl1_StopComputationEvent(object arg1, EventArgs arg2)
        {
            StopComputationEvent(this, arg2);
        }

        public virtual void TaskPlannerControl1_AddDataUseTaskConditionsEvent(object arg1, EventArgs arg2)
        {
            AddDataUseTaskConditionsEvent(this, new EventArgs());
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
