namespace TaskModule.HeatTreatmentModule
{
    partial class ChemicalTreatmentAdvisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChemicalTreatmentAdvisor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.taskTypeControl1 = new TaskModule.BasicAdvisorControls.TaskTypeControl();
            this.diffusionСontrol1 = new TaskModule.HeatTreatmentModule.DiffusionСontrol();
            this.taskPlannerControl1 = new TaskModule.BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.ItemSize = new System.Drawing.Size(91, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 281);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.taskTypeControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.diffusionСontrol1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.taskPlannerControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(595, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // taskTypeControl1
            // 
            this.taskTypeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.taskTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTypeControl1.Location = new System.Drawing.Point(3, 3);
            this.taskTypeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.taskTypeControl1.MinimumSize = new System.Drawing.Size(400, 0);
            this.taskTypeControl1.Name = "taskTypeControl1";
            this.taskTypeControl1.Size = new System.Drawing.Size(589, 249);
            this.taskTypeControl1.TabIndex = 0;
            this.taskTypeControl1.Task2DAxiImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task2DAxiImage")));
            this.taskTypeControl1.Task2DImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task2DImage")));
            this.taskTypeControl1.Task3DImage = ((System.Drawing.Image)(resources.GetObject("taskTypeControl1.Task3DImage")));
            // 
            // diffusionСontrol1
            // 
            this.diffusionСontrol1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.AddButtonImage")));
            this.diffusionСontrol1.AutoScroll = true;
            this.diffusionСontrol1.BackColor = System.Drawing.SystemColors.Control;
            this.diffusionСontrol1.CheckCurrentTime = 0F;
            this.diffusionСontrol1.CheckDinamicButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.CheckDinamicButtonImage")));
            this.diffusionСontrol1.CheckStartTime = 0F;
            this.diffusionСontrol1.CheckState = TaskModule.BasicAdvisorControls.BasicControls.CheckState.start;
            this.diffusionСontrol1.CheckStepTime = 0;
            this.diffusionСontrol1.CheckStopTime = 0F;
            this.diffusionСontrol1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.ClearButtonImage")));
            this.diffusionСontrol1.CurentSelectedRowInfo = null;
            this.diffusionСontrol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diffusionСontrol1.HideAllButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.HideAllButtonImage")));
            this.diffusionСontrol1.Location = new System.Drawing.Point(3, 3);
            this.diffusionСontrol1.MinimumSize = new System.Drawing.Size(400, 0);
            this.diffusionСontrol1.Name = "diffusionСontrol1";
            this.diffusionСontrol1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.RefreshButtonImage")));
            this.diffusionСontrol1.ShowAllButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.ShowAllButtonImage")));
            this.diffusionСontrol1.Size = new System.Drawing.Size(589, 249);
            this.diffusionСontrol1.SliderBarInnerColor = System.Drawing.Color.Gold;
            this.diffusionСontrol1.SliderBarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.diffusionСontrol1.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.diffusionСontrol1.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.diffusionСontrol1.StopCheckingButtonImage = ((System.Drawing.Image)(resources.GetObject("diffusionСontrol1.StopCheckingButtonImage")));
            this.diffusionСontrol1.TabIndex = 0;
            // 
            // taskPlannerControl1
            // 
            this.taskPlannerControl1.AddButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.AddButtonImage")));
            this.taskPlannerControl1.AutoScroll = true;
            this.taskPlannerControl1.ClearButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.ClearButtonImage")));
            this.taskPlannerControl1.CurentSelectedRowInfo = null;
            this.taskPlannerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPlannerControl1.Location = new System.Drawing.Point(3, 3);
            this.taskPlannerControl1.MinimumSize = new System.Drawing.Size(400, 700);
            this.taskPlannerControl1.Name = "taskPlannerControl1";
            this.taskPlannerControl1.RefreshButtonImage = ((System.Drawing.Image)(resources.GetObject("taskPlannerControl1.RefreshButtonImage")));
            this.taskPlannerControl1.Size = new System.Drawing.Size(589, 700);
            this.taskPlannerControl1.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Num1.png");
            this.imageList.Images.SetKeyName(1, "Num2.png");
            this.imageList.Images.SetKeyName(2, "Num3.png");
            // 
            // ChemicalTreatmentAdvisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ChemicalTreatmentAdvisor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BasicAdvisorControls.TaskTypeControl taskTypeControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private DiffusionСontrol diffusionСontrol1;
        private BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl taskPlannerControl1;
        private System.Windows.Forms.ImageList imageList;
    }
}
