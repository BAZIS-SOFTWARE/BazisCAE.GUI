using TaskModule.BasicAdvisorControls;
using TaskModule.WeldingModule.WeldingTypeControls;
using TaskModule.BasicTaskAdvisor;
using UserControlsEx;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.BasicAdvisorControls.Events;

namespace BaseModule.Tasks.WeldingModule
{
    partial class WeldingAdvisor : TaskAdvisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeldingAdvisor));
            this.tabControl = new UserControlsEx.TabControlEx();
            this.pdgTaskType = new System.Windows.Forms.TabPage();
            this.taskTypeControl1 = new TaskModule.BasicAdvisorControls.TaskTypeControl();
            this.pdgMaterials = new System.Windows.Forms.TabPage();
            this.materialsControl1 = new TaskModule.BasicAdvisorControls.MaterialsControl();
            this.pgMedia = new System.Windows.Forms.TabPage();
            this.mediaControl1 = new TaskModule.WeldingModule.WeldingTypeControls.WeldingMediaControl();
            this.pdgWeldingRegime = new System.Windows.Forms.TabPage();
            this.weldingControl = new TaskModule.WeldingModule.WeldingTypeControls.WeldingHeatingControl();
            this.pdgClamps = new System.Windows.Forms.TabPage();
            this.clampControl = new TaskModule.BasicAdvisorControls.ClampControl();
            this.pdgLoad = new System.Windows.Forms.TabPage();
            this.loadControl1 = new TaskModule.BasicAdvisorControls.LoadControl();
            this.pdgPlanner = new System.Windows.Forms.TabPage();
            this.taskPlannerControl = new BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl_v2();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.pdgTaskType.SuspendLayout();
            this.pdgMaterials.SuspendLayout();
            this.pgMedia.SuspendLayout();
            this.pdgWeldingRegime.SuspendLayout();
            this.pdgClamps.SuspendLayout();
            this.pdgLoad.SuspendLayout();
            this.pdgPlanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pdgTaskType);
            this.tabControl.Controls.Add(this.pdgMaterials);
            this.tabControl.Controls.Add(this.pgMedia);
            this.tabControl.Controls.Add(this.pdgWeldingRegime);
            this.tabControl.Controls.Add(this.pdgClamps);
            this.tabControl.Controls.Add(this.pdgLoad);
            this.tabControl.Controls.Add(this.pdgPlanner);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.FontColor = System.Drawing.Color.Black;
            this.tabControl.ImageList = this.imageList;
            this.tabControl.ItemSize = new System.Drawing.Size(91, 30);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectColor = System.Drawing.SystemColors.Control;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(737, 623);
            this.tabControl.TabIndex = 0;
            this.tabControl.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // pdgTaskType
            // 
            this.pdgTaskType.BackColor = System.Drawing.SystemColors.Control;
            this.pdgTaskType.Controls.Add(this.taskTypeControl1);
            this.pdgTaskType.ImageIndex = 0;
            this.pdgTaskType.Location = new System.Drawing.Point(4, 34);
            this.pdgTaskType.Margin = new System.Windows.Forms.Padding(4);
            this.pdgTaskType.Name = "pdgTaskType";
            this.pdgTaskType.Size = new System.Drawing.Size(729, 585);
            this.pdgTaskType.TabIndex = 5;
            this.pdgTaskType.Text = "Тип задачи";
            // 
            // taskTypeControl1
            // 
            this.taskTypeControl1.BackColor = System.Drawing.Color.Transparent;
            this.taskTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTypeControl1.Location = new System.Drawing.Point(0, 0);
            this.taskTypeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.taskTypeControl1.MinimumSize = new System.Drawing.Size(533, 0);
            this.taskTypeControl1.Name = "taskTypeControl1";
            this.taskTypeControl1.Size = new System.Drawing.Size(729, 585);
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
            this.pdgMaterials.Margin = new System.Windows.Forms.Padding(0);
            this.pdgMaterials.Name = "pdgMaterials";
            this.pdgMaterials.Size = new System.Drawing.Size(729, 585);
            this.pdgMaterials.TabIndex = 1;
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
            this.materialsControl1.Margin = new System.Windows.Forms.Padding(0);
            this.materialsControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.materialsControl1.Name = "materialsControl1";
            this.materialsControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.RefreshButtonImage")));
            this.materialsControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.ShowAllButtonImage")));
            this.materialsControl1.Size = new System.Drawing.Size(729, 585);
            this.materialsControl1.TabIndex = 0;
            this.materialsControl1.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.materialsControl1.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.materialsControl1.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.materialsControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.materialsControl1.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.materialsControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.materialsControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pgMedia
            // 
            this.pgMedia.BackColor = System.Drawing.SystemColors.Control;
            this.pgMedia.Controls.Add(this.mediaControl1);
            this.pgMedia.ImageIndex = 2;
            this.pgMedia.Location = new System.Drawing.Point(4, 34);
            this.pgMedia.Margin = new System.Windows.Forms.Padding(4);
            this.pgMedia.Name = "pgMedia";
            this.pgMedia.Size = new System.Drawing.Size(729, 585);
            this.pgMedia.TabIndex = 4;
            this.pgMedia.Text = "Среда";
            // 
            // mediaControl1
            // 
            this.mediaControl1.BackColor = System.Drawing.Color.Transparent;
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mediaControl1.Location = new System.Drawing.Point(0, 0);
            this.mediaControl1.Margin = new System.Windows.Forms.Padding(0);
            this.mediaControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(729, 585);
            this.mediaControl1.TabIndex = 0;
            this.mediaControl1.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.mediaControl1.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.mediaControl1.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.mediaControl1.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.mediaControl1.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.mediaControl1.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.mediaControl1.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgWeldingRegime
            // 
            this.pdgWeldingRegime.BackColor = System.Drawing.SystemColors.Control;
            this.pdgWeldingRegime.Controls.Add(this.weldingControl);
            this.pdgWeldingRegime.ImageIndex = 3;
            this.pdgWeldingRegime.Location = new System.Drawing.Point(4, 34);
            this.pdgWeldingRegime.Margin = new System.Windows.Forms.Padding(4);
            this.pdgWeldingRegime.Name = "pdgWeldingRegime";
            this.pdgWeldingRegime.Size = new System.Drawing.Size(729, 585);
            this.pdgWeldingRegime.TabIndex = 3;
            this.pdgWeldingRegime.Text = "Режим сварки";
            // 
            // weldingControl
            // 
            this.weldingControl.AutoScroll = true;
            this.weldingControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weldingControl.BackColor = System.Drawing.Color.Transparent;
            this.weldingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldingControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weldingControl.Location = new System.Drawing.Point(0, 0);
            this.weldingControl.Margin = new System.Windows.Forms.Padding(0);
            this.weldingControl.MinimumSize = new System.Drawing.Size(400, 369);
            this.weldingControl.Name = "weldingControl";
            this.weldingControl.Size = new System.Drawing.Size(729, 585);
            this.weldingControl.TabIndex = 0;
            this.weldingControl.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.weldingControl.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.weldingControl.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.weldingControl.SpecifyFunctionAreaEvent += new System.Action<string, int>(this.weldingControl_SpecifyFunctionAreaEvent);
            this.weldingControl.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.weldingControl.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.weldingControl.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.weldingControl.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgClamps
            // 
            this.pdgClamps.BackColor = System.Drawing.SystemColors.Control;
            this.pdgClamps.Controls.Add(this.clampControl);
            this.pdgClamps.ImageIndex = 4;
            this.pdgClamps.Location = new System.Drawing.Point(4, 34);
            this.pdgClamps.Margin = new System.Windows.Forms.Padding(4);
            this.pdgClamps.Name = "pdgClamps";
            this.pdgClamps.Size = new System.Drawing.Size(729, 585);
            this.pdgClamps.TabIndex = 0;
            this.pdgClamps.Text = "Закрепления";
            // 
            // clampControl
            // 
            this.clampControl.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.AddButtonImage")));
            this.clampControl.AutoScroll = true;
            this.clampControl.AutoSize = true;
            this.clampControl.BackColor = System.Drawing.Color.Transparent;
            this.clampControl.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.ClearButtonImage")));
            this.clampControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clampControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clampControl.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.HideAllButtonImage")));
            this.clampControl.Location = new System.Drawing.Point(0, 0);
            this.clampControl.Margin = new System.Windows.Forms.Padding(0);
            this.clampControl.MinimumSize = new System.Drawing.Size(400, 369);
            this.clampControl.Name = "clampControl";
            this.clampControl.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.RefreshButtonImage")));
            this.clampControl.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.ShowAllButtonImage")));
            this.clampControl.Size = new System.Drawing.Size(729, 585);
            this.clampControl.TabIndex = 0;
            this.clampControl.ShowDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.clampControl.HideDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.clampControl.CheckDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.clampControl.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.clampControl.DeleteDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.clampControl.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.clampControl.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            // 
            // pdgLoad
            // 
            this.pdgLoad.BackColor = System.Drawing.SystemColors.Control;
            this.pdgLoad.Controls.Add(this.loadControl1);
            this.pdgLoad.ImageIndex = 5;
            this.pdgLoad.Location = new System.Drawing.Point(4, 34);
            this.pdgLoad.Margin = new System.Windows.Forms.Padding(4);
            this.pdgLoad.Name = "pdgLoad";
            this.pdgLoad.Size = new System.Drawing.Size(729, 585);
            this.pdgLoad.TabIndex = 2;
            this.pdgLoad.Text = "Нагрузки";
            // 
            // loadControl1
            // 
            this.loadControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.AddButtonImage")));
            this.loadControl1.BackColor = System.Drawing.Color.Transparent;
            this.loadControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ClearButtonImage")));
            this.loadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.HideAllButtonImage")));
            this.loadControl1.Location = new System.Drawing.Point(0, 0);
            this.loadControl1.Margin = new System.Windows.Forms.Padding(0);
            this.loadControl1.MinimumSize = new System.Drawing.Size(400, 369);
            this.loadControl1.Name = "loadControl1";
            this.loadControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.RefreshButtonImage")));
            this.loadControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ShowAllButtonImage")));
            this.loadControl1.Size = new System.Drawing.Size(729, 585);
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
            this.pdgPlanner.Controls.Add(this.taskPlannerControl);
            this.pdgPlanner.ImageIndex = 6;
            this.pdgPlanner.Location = new System.Drawing.Point(4, 34);
            this.pdgPlanner.Margin = new System.Windows.Forms.Padding(4);
            this.pdgPlanner.Name = "pdgPlanner";
            this.pdgPlanner.Size = new System.Drawing.Size(729, 585);
            this.pdgPlanner.TabIndex = 6;
            this.pdgPlanner.Text = "Планировщик";
            // 
            // taskPlannerControl
            // 
            this.taskPlannerControl.AutoScroll = true;
            this.taskPlannerControl.AutoSize = true;
            this.taskPlannerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPlannerControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.taskPlannerControl.Location = new System.Drawing.Point(0, 0);
            this.taskPlannerControl.Margin = new System.Windows.Forms.Padding(0);
            this.taskPlannerControl.MinimumSize = new System.Drawing.Size(300, 300);
            this.taskPlannerControl.Name = "taskPlannerControl";
            this.taskPlannerControl.Size = new System.Drawing.Size(729, 585);
            this.taskPlannerControl.TabIndex = 0;
            this.taskPlannerControl.AddDataUseTaskConditionsEvent += new System.Action<object, BasicAdvisorControls.TaskPlannerControls.Tasks, Priority>(this.TaskPlannerControl1_AddDataUseTaskConditionsEvent);
            this.taskPlannerControl.StopComputationEvent += new System.Action<object, System.EventArgs>(this.TaskPlannerControl1_StopComputationEvent);
            this.taskPlannerControl.GenerateTCFEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls.GenerateTCFEventArgs>(this.TaskPlannerControl_GenerateTCFEvent);
            this.taskPlannerControl.AddDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.taskPlannerControl.ChangeDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            this.taskPlannerControl.DeleteAllDataEvent += new System.Action<object, BaseModule.Tasks.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.taskPlannerControl.EditTSFEvent += new System.Action<object, string>(this.TaskPlannerControl_EditTSFEvent);
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
            // WeldingAdvisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WeldingAdvisor";
            this.Size = new System.Drawing.Size(737, 623);
            this.TaskType = "Volume";
            this.tabControl.ResumeLayout(false);
            this.pdgTaskType.ResumeLayout(false);
            this.pdgMaterials.ResumeLayout(false);
            this.pdgMaterials.PerformLayout();
            this.pgMedia.ResumeLayout(false);
            this.pdgWeldingRegime.ResumeLayout(false);
            this.pdgClamps.ResumeLayout(false);
            this.pdgClamps.PerformLayout();
            this.pdgLoad.ResumeLayout(false);
            this.pdgPlanner.ResumeLayout(false);
            this.pdgPlanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage pdgClamps;
        private System.Windows.Forms.TabPage pdgMaterials;
        private ClampControl clampControl;
        private MaterialsControl materialsControl1;
        private System.Windows.Forms.TabPage pdgLoad;
        private LoadControl loadControl1;
        private System.Windows.Forms.TabPage pdgWeldingRegime;
        private WeldingHeatingControl weldingControl;
        private System.Windows.Forms.TabPage pgMedia;
        private WeldingMediaControl mediaControl1;
        private System.Windows.Forms.TabPage pdgTaskType;
        private TaskTypeControl taskTypeControl1;
        private System.Windows.Forms.TabPage pdgPlanner;
        private System.Windows.Forms.ImageList imageList;
        private TabControlEx tabControl;
        private TaskPlannerControl_v2 taskPlannerControl;
        //private UserControl1 userControl11;
    }
}
