using TaskModule.BasicAdvisorControls;
using UserControlsEx;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.BasicAdvisorControls.Events;

namespace BaseModule.Tasks.HeatTreatmentModule
{
    partial class HeatTreatmentAdvisor
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatTreatmentAdvisor));
            this.tabControl1 = new UserControlsEx.TabControlEx();
            this.pdgTaskType = new System.Windows.Forms.TabPage();
            this.taskTypeControl1 = new TaskModule.BasicAdvisorControls.TaskTypeControl();
            this.pdgMaterials = new System.Windows.Forms.TabPage();
            this.materialsControl1 = new TaskModule.BasicAdvisorControls.MaterialsControl();
            this.pdgHTRegime = new System.Windows.Forms.TabPage();
            this.htMediaControl = new BaseModule.Tasks.HeatTreatmentModule.HeatControl();
            this.pdgClamps = new System.Windows.Forms.TabPage();
            this.clampControl1 = new TaskModule.BasicAdvisorControls.ClampControl();
            this.pdgLoad = new System.Windows.Forms.TabPage();
            this.loadControl1 = new TaskModule.BasicAdvisorControls.LoadControl();
            this.pdgPlanner = new System.Windows.Forms.TabPage();
            this.taskPlannerControl1 = new BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl_v2();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.pdgTaskType.SuspendLayout();
            this.pdgMaterials.SuspendLayout();
            this.pdgHTRegime.SuspendLayout();
            this.pdgClamps.SuspendLayout();
            this.pdgLoad.SuspendLayout();
            this.pdgPlanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pdgTaskType);
            this.tabControl1.Controls.Add(this.pdgMaterials);
            this.tabControl1.Controls.Add(this.pdgHTRegime);
            this.tabControl1.Controls.Add(this.pdgClamps);
            this.tabControl1.Controls.Add(this.pdgLoad);
            this.tabControl1.Controls.Add(this.pdgPlanner);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.FontColor = System.Drawing.Color.Black;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.ItemSize = new System.Drawing.Size(91, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectColor = System.Drawing.SystemColors.Control;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 738);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // pdgTaskType
            // 
            this.pdgTaskType.BackColor = System.Drawing.SystemColors.Control;
            this.pdgTaskType.Controls.Add(this.taskTypeControl1);
            this.pdgTaskType.ImageIndex = 0;
            this.pdgTaskType.Location = new System.Drawing.Point(4, 34);
            this.pdgTaskType.Margin = new System.Windows.Forms.Padding(4);
            this.pdgTaskType.Name = "pdgTaskType";
            this.pdgTaskType.Padding = new System.Windows.Forms.Padding(4);
            this.pdgTaskType.Size = new System.Drawing.Size(925, 700);
            this.pdgTaskType.TabIndex = 1;
            this.pdgTaskType.Text = "Тип задачи";
            // 
            // taskTypeControl1
            // 
            this.taskTypeControl1.BackColor = System.Drawing.Color.Transparent;
            this.taskTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTypeControl1.Location = new System.Drawing.Point(4, 4);
            this.taskTypeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.taskTypeControl1.MinimumSize = new System.Drawing.Size(533, 0);
            this.taskTypeControl1.Name = "taskTypeControl1";
            this.taskTypeControl1.Size = new System.Drawing.Size(917, 692);
            this.taskTypeControl1.TabIndex = 0;
            this.taskTypeControl1.Task2DAxiImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task2DAxiImage")));
            this.taskTypeControl1.Task2DImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task2DImage")));
            this.taskTypeControl1.Task3DImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task3DImage")));
            this.taskTypeControl1.TaskType = "Volume";
            this.taskTypeControl1.Select2DPlaneTaskEvent += new System.Action<object, System.EventArgs>(this.taskTypeControl_Select2DPlaneTaskEvent);
            this.taskTypeControl1.Select2DAxiTaskEvent += new System.Action<object, System.EventArgs>(this.taskTypeControl_Select2DAxiTaskEvent);
            this.taskTypeControl1.Select3DTaskEvent += new System.Action<object, System.EventArgs>(this.taskTypeControl_Select3DTaskEvent);
            // 
            // pdgMaterials
            // 
            this.pdgMaterials.BackColor = System.Drawing.SystemColors.Control;
            this.pdgMaterials.Controls.Add(this.materialsControl1);
            this.pdgMaterials.ImageIndex = 1;
            this.pdgMaterials.Location = new System.Drawing.Point(4, 34);
            this.pdgMaterials.Margin = new System.Windows.Forms.Padding(4);
            this.pdgMaterials.Name = "pdgMaterials";
            this.pdgMaterials.Size = new System.Drawing.Size(925, 700);
            this.pdgMaterials.TabIndex = 2;
            this.pdgMaterials.Text = "Материалы";
            // 
            // materialsControl1
            // 
            this.materialsControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.AddButtonImage")));
            this.materialsControl1.AutoScroll = true;
            this.materialsControl1.AutoSize = true;
            this.materialsControl1.BackColor = System.Drawing.Color.Transparent;
            this.materialsControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.ClearButtonImage")));
            this.materialsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialsControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.HideAllButtonImage")));
            this.materialsControl1.Location = new System.Drawing.Point(0, 0);
            this.materialsControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.materialsControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.materialsControl1.Name = "materialsControl1";
            this.materialsControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.RefreshButtonImage")));
            this.materialsControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.ShowAllButtonImage")));
            this.materialsControl1.Size = new System.Drawing.Size(925, 700);
            this.materialsControl1.TabIndex = 0;
            this.materialsControl1.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.materialsControl1.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.materialsControl1.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.materialsControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.materialsControl1.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.materialsControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.materialsControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgHTRegime
            // 
            this.pdgHTRegime.BackColor = System.Drawing.SystemColors.Control;
            this.pdgHTRegime.Controls.Add(this.htMediaControl);
            this.pdgHTRegime.ImageIndex = 2;
            this.pdgHTRegime.Location = new System.Drawing.Point(4, 34);
            this.pdgHTRegime.Margin = new System.Windows.Forms.Padding(4);
            this.pdgHTRegime.Name = "pdgHTRegime";
            this.pdgHTRegime.Size = new System.Drawing.Size(925, 700);
            this.pdgHTRegime.TabIndex = 3;
            this.pdgHTRegime.Text = "Режим ТО";
            // 
            // htMediaControl
            // 
            this.htMediaControl.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("htMediaControl.AddButtonImage")));
            this.htMediaControl.BackColor = System.Drawing.Color.Transparent;
            this.htMediaControl.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("htMediaControl.ClearButtonImage")));
            this.htMediaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htMediaControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.htMediaControl.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("htMediaControl.HideAllButtonImage")));
            this.htMediaControl.Location = new System.Drawing.Point(0, 0);
            this.htMediaControl.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.htMediaControl.MinimumSize = new System.Drawing.Size(400, 369);
            this.htMediaControl.Name = "htMediaControl";
            this.htMediaControl.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("htMediaControl.RefreshButtonImage")));
            this.htMediaControl.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("htMediaControl.ShowAllButtonImage")));
            this.htMediaControl.Size = new System.Drawing.Size(925, 700);
            this.htMediaControl.TabIndex = 0;
            this.htMediaControl.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.htMediaControl.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.htMediaControl.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.htMediaControl.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.htMediaControl.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.htMediaControl.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.htMediaControl.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgClamps
            // 
            this.pdgClamps.BackColor = System.Drawing.SystemColors.Control;
            this.pdgClamps.Controls.Add(this.clampControl1);
            this.pdgClamps.ImageIndex = 3;
            this.pdgClamps.Location = new System.Drawing.Point(4, 34);
            this.pdgClamps.Margin = new System.Windows.Forms.Padding(4);
            this.pdgClamps.Name = "pdgClamps";
            this.pdgClamps.Size = new System.Drawing.Size(925, 700);
            this.pdgClamps.TabIndex = 5;
            this.pdgClamps.Text = "Закрепления";
            // 
            // clampControl1
            // 
            this.clampControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl1.AddButtonImage")));
            this.clampControl1.AutoScroll = true;
            this.clampControl1.AutoSize = true;
            this.clampControl1.BackColor = System.Drawing.Color.Transparent;
            this.clampControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl1.ClearButtonImage")));
            this.clampControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clampControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clampControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl1.HideAllButtonImage")));
            this.clampControl1.Location = new System.Drawing.Point(0, 0);
            this.clampControl1.Margin = new System.Windows.Forms.Padding(4);
            this.clampControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.clampControl1.Name = "clampControl1";
            this.clampControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl1.RefreshButtonImage")));
            this.clampControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl1.ShowAllButtonImage")));
            this.clampControl1.Size = new System.Drawing.Size(925, 700);
            this.clampControl1.TabIndex = 0;
            this.clampControl1.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.clampControl1.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.clampControl1.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.clampControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.clampControl1.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.clampControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.clampControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgLoad
            // 
            this.pdgLoad.BackColor = System.Drawing.SystemColors.Control;
            this.pdgLoad.Controls.Add(this.loadControl1);
            this.pdgLoad.ImageIndex = 4;
            this.pdgLoad.Location = new System.Drawing.Point(4, 34);
            this.pdgLoad.Margin = new System.Windows.Forms.Padding(4);
            this.pdgLoad.Name = "pdgLoad";
            this.pdgLoad.Size = new System.Drawing.Size(925, 700);
            this.pdgLoad.TabIndex = 6;
            this.pdgLoad.Text = "Нагрузки";
            // 
            // loadControl1
            // 
            this.loadControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.AddButtonImage")));
            this.loadControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ClearButtonImage")));
            this.loadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.HideAllButtonImage")));
            this.loadControl1.Location = new System.Drawing.Point(0, 0);
            this.loadControl1.Margin = new System.Windows.Forms.Padding(4);
            this.loadControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.loadControl1.Name = "loadControl1";
            this.loadControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.RefreshButtonImage")));
            this.loadControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ShowAllButtonImage")));
            this.loadControl1.Size = new System.Drawing.Size(925, 700);
            this.loadControl1.TabIndex = 0;
            this.loadControl1.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.loadControl1.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.loadControl1.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.loadControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.loadControl1.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.loadControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.loadControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgPlanner
            // 
            this.pdgPlanner.BackColor = System.Drawing.SystemColors.Control;
            this.pdgPlanner.Controls.Add(this.taskPlannerControl1);
            this.pdgPlanner.ImageIndex = 5;
            this.pdgPlanner.Location = new System.Drawing.Point(4, 34);
            this.pdgPlanner.Margin = new System.Windows.Forms.Padding(4);
            this.pdgPlanner.Name = "pdgPlanner";
            this.pdgPlanner.Size = new System.Drawing.Size(925, 700);
            this.pdgPlanner.TabIndex = 7;
            this.pdgPlanner.Text = "Планировщик";
            // 
            // taskPlannerControl1
            // 
            this.taskPlannerControl1.AutoScroll = true;
            this.taskPlannerControl1.AutoSize = true;
            this.taskPlannerControl1.BackColor = System.Drawing.Color.Transparent;
            this.taskPlannerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPlannerControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.taskPlannerControl1.Location = new System.Drawing.Point(0, 0);
            this.taskPlannerControl1.Margin = new System.Windows.Forms.Padding(5);
            this.taskPlannerControl1.MinimumSize = new System.Drawing.Size(533, 862);
            this.taskPlannerControl1.Name = "taskPlannerControl1";
            this.taskPlannerControl1.Size = new System.Drawing.Size(925, 862);
            this.taskPlannerControl1.TabIndex = 0;
            this.taskPlannerControl1.GenerateTSFEvent += new System.Action<object, BasicAdvisorControls.TaskPlannerControls.Tasks, Priority>(this.TaskPlannerControl1_AddDataUseTaskConditionsEvent);
            this.taskPlannerControl1.StopComputationEvent += new System.Action<object, System.EventArgs>(this.TaskPlannerControl1_StopComputationEvent);
            this.taskPlannerControl1.GenerateTCFEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls.GenerateTCFEventArgs>(this.TaskPlannerControl_GenerateTCFEvent);
            this.taskPlannerControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.taskPlannerControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.taskPlannerControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.taskPlannerControl1.EditTSFEvent += new System.Action<object, string>(this.TaskPlannerControl_EditTSFEvent);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Num1.png");
            this.imageList.Images.SetKeyName(1, "Num2.png");
            this.imageList.Images.SetKeyName(2, "Num3.png");
            this.imageList.Images.SetKeyName(3, "Num4.png");
            this.imageList.Images.SetKeyName(4, "Num5.png");
            this.imageList.Images.SetKeyName(5, "Num6.png");
            this.imageList.Images.SetKeyName(6, "Num7.png");
            this.imageList.Images.SetKeyName(7, "Num8.png");
            // 
            // HeatTreatmentAdvisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HeatTreatmentAdvisor";
            this.Size = new System.Drawing.Size(933, 738);
            this.TaskType = "Volume";
            this.tabControl1.ResumeLayout(false);
            this.pdgTaskType.ResumeLayout(false);
            this.pdgMaterials.ResumeLayout(false);
            this.pdgMaterials.PerformLayout();
            this.pdgHTRegime.ResumeLayout(false);
            this.pdgClamps.ResumeLayout(false);
            this.pdgClamps.PerformLayout();
            this.pdgLoad.ResumeLayout(false);
            this.pdgPlanner.ResumeLayout(false);
            this.pdgPlanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage pdgTaskType;
        private TaskTypeControl taskTypeControl1;
        private System.Windows.Forms.TabPage pdgMaterials;
        private System.Windows.Forms.TabPage pdgHTRegime;
        private MaterialsControl materialsControl1;
        private System.Windows.Forms.TabPage pdgClamps;
        private ClampControl clampControl1;
        private System.Windows.Forms.TabPage pdgLoad;
        private LoadControl loadControl1;
        private System.Windows.Forms.TabPage pdgPlanner;
        private TaskPlannerControl_v2 taskPlannerControl1;
        private HeatControl htMediaControl;
        private System.Windows.Forms.ImageList imageList;
        private TabControlEx tabControl1;
    }
}
