using TaskModule.BasicAdvisorControls.TaskPlannerControls;
using TaskModule.BasicAdvisorControls;
using TaskModule.WeldingModule.WeldingTypeControls;
using TaskModule.BasicTaskAdvisor;

namespace TaskModule.WeldingModule
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pdgTaskType = new System.Windows.Forms.TabPage();
            this.taskTypeControl1 = new TaskModule.BasicAdvisorControls.TaskTypeControl();
            this.pdgMaterials = new System.Windows.Forms.TabPage();
            this.materialsControl1 = new TaskModule.BasicAdvisorControls.MaterialsControl();
            this.pgMedia = new System.Windows.Forms.TabPage();
            this.mediaControl1 = new TaskModule.WeldingModule.WeldingTypeControls.WeldingMediaControl();
            this.pdgWelding = new System.Windows.Forms.TabPage();
            this.weldingControl1 = new TaskModule.WeldingModule.WeldingTypeControls.WeldingControl();
            this.pdgClamps = new System.Windows.Forms.TabPage();
            this.clampControl = new TaskModule.BasicAdvisorControls.ClampControl();
            this.pdgLoad = new System.Windows.Forms.TabPage();
            this.loadControl1 = new TaskModule.BasicAdvisorControls.LoadControl();
            this.pdgPlanner = new System.Windows.Forms.TabPage();
            this.taskPlannerControl1 = new TaskModule.BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.pdgTaskType.SuspendLayout();
            this.pdgMaterials.SuspendLayout();
            this.pgMedia.SuspendLayout();
            this.pdgWelding.SuspendLayout();
            this.pdgClamps.SuspendLayout();
            this.pdgLoad.SuspendLayout();
            this.pdgPlanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pdgTaskType);
            this.tabControl1.Controls.Add(this.pdgMaterials);
            this.tabControl1.Controls.Add(this.pgMedia);
            this.tabControl1.Controls.Add(this.pdgWelding);
            this.tabControl1.Controls.Add(this.pdgClamps);
            this.tabControl1.Controls.Add(this.pdgLoad);
            this.tabControl1.Controls.Add(this.pdgPlanner);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.ItemSize = new System.Drawing.Size(91, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 600);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            // 
            // pdgTaskType
            // 
            this.pdgTaskType.BackColor = System.Drawing.SystemColors.Control;
            this.pdgTaskType.Controls.Add(this.taskTypeControl1);
            this.pdgTaskType.ImageIndex = 0;
            this.pdgTaskType.Location = new System.Drawing.Point(4, 34);
            this.pdgTaskType.Name = "pdgTaskType";
            this.pdgTaskType.Padding = new System.Windows.Forms.Padding(3);
            this.pdgTaskType.Size = new System.Drawing.Size(692, 562);
            this.pdgTaskType.TabIndex = 5;
            this.pdgTaskType.Text = "Тип задачи";
            // 
            // taskTypeControl1
            // 
            this.taskTypeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.taskTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTypeControl1.Location = new System.Drawing.Point(3, 3);
            this.taskTypeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.taskTypeControl1.MinimumSize = new System.Drawing.Size(400, 0);
            this.taskTypeControl1.Name = "taskTypeControl1";
            this.taskTypeControl1.Size = new System.Drawing.Size(686, 556);
            this.taskTypeControl1.TabIndex = 0;
            this.taskTypeControl1.Task2DAxiImage = global::TaskModule.Properties.Resources.PlainTask;
            this.taskTypeControl1.Task2DImage = global::TaskModule.Properties.Resources.AxiSymTask;
            this.taskTypeControl1.Task3DImage = global::TaskModule.Properties.Resources.VolTask;
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
            this.pdgMaterials.Name = "pdgMaterials";
            this.pdgMaterials.Size = new System.Drawing.Size(692, 562);
            this.pdgMaterials.TabIndex = 1;
            this.pdgMaterials.Text = "Материалы";
            // 
            // materialsControl1
            // 
            this.materialsControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.AddButtonImage")));
            this.materialsControl1.AutoScroll = true;
            this.materialsControl1.AutoSize = true;
            this.materialsControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.ClearButtonImage")));
            this.materialsControl1.CurentSelectedRowInfo = null;
            this.materialsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.HideAllButtonImage")));
            this.materialsControl1.Location = new System.Drawing.Point(0, 0);
            this.materialsControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.materialsControl1.Name = "materialsControl1";
            this.materialsControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.RefreshButtonImage")));
            this.materialsControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("materialsControl1.ShowAllButtonImage")));
            this.materialsControl1.Size = new System.Drawing.Size(692, 562);
            this.materialsControl1.TabIndex = 0;
            this.materialsControl1.ShowDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.materialsControl1.HideDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.materialsControl1.CheckDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.materialsControl1.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.materialsControl1.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.materialsControl1.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.materialsControl1.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            // 
            // pgMedia
            // 
            this.pgMedia.BackColor = System.Drawing.SystemColors.Control;
            this.pgMedia.Controls.Add(this.mediaControl1);
            this.pgMedia.ImageIndex = 2;
            this.pgMedia.Location = new System.Drawing.Point(4, 34);
            this.pgMedia.Name = "pgMedia";
            this.pgMedia.Size = new System.Drawing.Size(692, 562);
            this.pgMedia.TabIndex = 4;
            this.pgMedia.Text = "Среда";
            // 
            // mediaControl1
            // 
            this.mediaControl1.CurentSelectedRowInfo = null;
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(0, 0);
            this.mediaControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(692, 562);
            this.mediaControl1.TabIndex = 0;
            this.mediaControl1.ShowDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.mediaControl1.HideDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.mediaControl1.CheckDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.mediaControl1.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.mediaControl1.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.mediaControl1.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.mediaControl1.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            // 
            // pdgWelding
            // 
            this.pdgWelding.Controls.Add(this.weldingControl1);
            this.pdgWelding.ImageIndex = 3;
            this.pdgWelding.Location = new System.Drawing.Point(4, 34);
            this.pdgWelding.Name = "pdgWelding";
            this.pdgWelding.Size = new System.Drawing.Size(692, 562);
            this.pdgWelding.TabIndex = 3;
            this.pdgWelding.Text = "Вид сварки";
            this.pdgWelding.UseVisualStyleBackColor = true;
            // 
            // weldingControl1
            // 
            this.weldingControl1.AutoScroll = true;
            this.weldingControl1.BackColor = System.Drawing.SystemColors.Control;
            this.weldingControl1.CurentSelectedRowInfo = null;
            this.weldingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldingControl1.Location = new System.Drawing.Point(0, 0);
            this.weldingControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.weldingControl1.Name = "weldingControl1";
            this.weldingControl1.Size = new System.Drawing.Size(692, 562);
            this.weldingControl1.TabIndex = 0;
            this.weldingControl1.ShowDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.weldingControl1.HideDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.weldingControl1.CheckDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.weldingControl1.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.weldingControl1.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.weldingControl1.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.weldingControl1.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            // 
            // pdgClamps
            // 
            this.pdgClamps.BackColor = System.Drawing.SystemColors.Control;
            this.pdgClamps.Controls.Add(this.clampControl);
            this.pdgClamps.ImageIndex = 4;
            this.pdgClamps.Location = new System.Drawing.Point(4, 34);
            this.pdgClamps.Name = "pdgClamps";
            this.pdgClamps.Size = new System.Drawing.Size(692, 562);
            this.pdgClamps.TabIndex = 0;
            this.pdgClamps.Text = "Закрепления";
            // 
            // clampControl
            // 
            this.clampControl.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.AddButtonImage")));
            this.clampControl.AutoScroll = true;
            this.clampControl.AutoSize = true;
            this.clampControl.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.ClearButtonImage")));
            this.clampControl.CurentSelectedRowInfo = null;
            this.clampControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clampControl.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.HideAllButtonImage")));
            this.clampControl.Location = new System.Drawing.Point(0, 0);
            this.clampControl.MinimumSize = new System.Drawing.Size(300, 300);
            this.clampControl.Name = "clampControl";
            this.clampControl.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.RefreshButtonImage")));
            this.clampControl.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("clampControl.ShowAllButtonImage")));
            this.clampControl.Size = new System.Drawing.Size(692, 562);
            this.clampControl.TabIndex = 0;
            this.clampControl.ShowDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.clampControl.HideDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.clampControl.CheckDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.clampControl.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.clampControl.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.clampControl.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.clampControl.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            // 
            // pdgLoad
            // 
            this.pdgLoad.Controls.Add(this.loadControl1);
            this.pdgLoad.ImageIndex = 5;
            this.pdgLoad.Location = new System.Drawing.Point(4, 34);
            this.pdgLoad.Name = "pdgLoad";
            this.pdgLoad.Size = new System.Drawing.Size(692, 562);
            this.pdgLoad.TabIndex = 2;
            this.pdgLoad.Text = "Нагрузки";
            this.pdgLoad.UseVisualStyleBackColor = true;
            // 
            // loadControl1
            // 
            this.loadControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.AddButtonImage")));
            this.loadControl1.BackColor = System.Drawing.SystemColors.Control;
            this.loadControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ClearButtonImage")));
            this.loadControl1.CurentSelectedRowInfo = null;
            this.loadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadControl1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.HideAllButtonImage")));
            this.loadControl1.Location = new System.Drawing.Point(0, 0);
            this.loadControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.loadControl1.Name = "loadControl1";
            this.loadControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.RefreshButtonImage")));
            this.loadControl1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("loadControl1.ShowAllButtonImage")));
            this.loadControl1.Size = new System.Drawing.Size(692, 562);
            this.loadControl1.TabIndex = 0;
            this.loadControl1.ShowDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ShowDataEventArgs>(this.Control_ShowDataEvent);
            this.loadControl1.HideDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.HideDataEventArgs>(this.Control_HideDataEvent);
            this.loadControl1.CheckDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.CheckDataEventArgs>(this.Control_CheckDataEvent);
            this.loadControl1.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.loadControl1.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.loadControl1.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.loadControl1.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
            // 
            // pdgPlanner
            // 
            this.pdgPlanner.BackColor = System.Drawing.SystemColors.Control;
            this.pdgPlanner.Controls.Add(this.taskPlannerControl1);
            this.pdgPlanner.ImageIndex = 6;
            this.pdgPlanner.Location = new System.Drawing.Point(4, 34);
            this.pdgPlanner.Name = "pdgPlanner";
            this.pdgPlanner.Size = new System.Drawing.Size(692, 562);
            this.pdgPlanner.TabIndex = 6;
            this.pdgPlanner.Text = "Планировщик";
            // 
            // taskPlannerControl1
            // 
            this.taskPlannerControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.AddButtonImage")));
            this.taskPlannerControl1.AutoScroll = true;
            this.taskPlannerControl1.AutoSize = true;
            this.taskPlannerControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.ClearButtonImage")));
            this.taskPlannerControl1.CurentSelectedRowInfo = null;
            this.taskPlannerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPlannerControl1.Location = new System.Drawing.Point(0, 0);
            this.taskPlannerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.taskPlannerControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.taskPlannerControl1.Name = "taskPlannerControl1";
            this.taskPlannerControl1.ProjPath = null;
            this.taskPlannerControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.RefreshButtonImage")));
            this.taskPlannerControl1.Size = new System.Drawing.Size(692, 562);
            this.taskPlannerControl1.TabIndex = 0;
            this.taskPlannerControl1.AddDataUseTaskConditionsEvent += new System.Action<object, System.EventArgs>(this.TaskPlannerControl1_AddDataUseTaskConditionsEvent);
            this.taskPlannerControl1.StartComputationEvent += new System.Action<object, System.EventArgs>(this.TaskPlannerControl_StartComputationEvent);
            this.taskPlannerControl1.StopComputationEvent += new System.Action<object, System.EventArgs>(this.TaskPlannerControl1_StopComputationEvent);
            this.taskPlannerControl1.GenerateTCFEvent += new System.Action<object, TaskModule.BasicAdvisorControls.TaskPlannerControls.GenerateTCFEventArgs>(this.TaskPlannerControl_GenerateTCFEvent);
            this.taskPlannerControl1.AddDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.AddDataEventArgs>(this.Control_AddDataEvent);
            this.taskPlannerControl1.DeleteDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteDataEventArgs>(this.Control_DeleteDataEvent);
            this.taskPlannerControl1.DeleteAllDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.DeleteAllDataEventArgs>(this.Control_DeleteAllDataEvent);
            this.taskPlannerControl1.ChangeDataEvent += new System.Action<object, TaskModule.BasicAdvisorControls.Events.ChangeDataEventArgs>(this.Control_ChangeDataEvent);
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
            this.Controls.Add(this.tabControl1);
            this.Name = "WeldingAdvisor";
            this.Size = new System.Drawing.Size(700, 600);
            this.tabControl1.ResumeLayout(false);
            this.pdgTaskType.ResumeLayout(false);
            this.pdgMaterials.ResumeLayout(false);
            this.pdgMaterials.PerformLayout();
            this.pgMedia.ResumeLayout(false);
            this.pdgWelding.ResumeLayout(false);
            this.pdgClamps.ResumeLayout(false);
            this.pdgClamps.PerformLayout();
            this.pdgLoad.ResumeLayout(false);
            this.pdgPlanner.ResumeLayout(false);
            this.pdgPlanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pdgClamps;
        private System.Windows.Forms.TabPage pdgMaterials;
        private ClampControl clampControl;
        private MaterialsControl materialsControl1;
        private System.Windows.Forms.TabPage pdgLoad;
        private LoadControl loadControl1;
        private System.Windows.Forms.TabPage pdgWelding;
        private WeldingControl weldingControl1;
        private System.Windows.Forms.TabPage pgMedia;
        private WeldingMediaControl mediaControl1;
        private System.Windows.Forms.TabPage pdgTaskType;
        private TaskTypeControl taskTypeControl1;
        private System.Windows.Forms.TabPage pdgPlanner;
        private TaskPlannerControl taskPlannerControl1;
        private System.Windows.Forms.ImageList imageList;
    }
}
