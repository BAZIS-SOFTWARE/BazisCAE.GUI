namespace BaseModule
{
    partial class EmbendentPage
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
            this.splitContainerEx = new UserControlsEx.SplitContainerEx();
            this.basePage = new BaseModule.BasePage();
            this.pinnedWeldingAdvisorControl = new TaskModule.BasicTaskAdvisor.PinnedWAdvControl();
            this.pinnedAnimationControl = new BaseModule.Results.Animation.PinnedAnimationControl();
            this.pinnedMeshGenControl = new BaseModule.Mesh.PinnedMeshGenControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx)).BeginInit();
            this.splitContainerEx.Panel1.SuspendLayout();
            this.splitContainerEx.Panel2.SuspendLayout();
            this.splitContainerEx.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerEx
            // 
            this.splitContainerEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEx.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainerEx.IncrementShifting = 50;
            this.splitContainerEx.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEx.Name = "splitContainerEx";
            // 
            // splitContainerEx.Panel1
            // 
            this.splitContainerEx.Panel1.Controls.Add(this.basePage);
            // 
            // splitContainerEx.Panel2
            // 
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedMeshGenControl);
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedWeldingAdvisorControl);
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedAnimationControl);
            this.splitContainerEx.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.splitContainerEx.Size = new System.Drawing.Size(959, 594);
            this.splitContainerEx.SplitterDistance = 611;
            this.splitContainerEx.SwitchShifting = false;
            this.splitContainerEx.TabIndex = 2;
            // 
            // basePage
            // 
            this.basePage.BackColor = System.Drawing.SystemColors.Control;
            this.basePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePage.Location = new System.Drawing.Point(0, 0);
            this.basePage.Margin = new System.Windows.Forms.Padding(0);
            this.basePage.Name = "basePage";
            this.basePage.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.basePage.PressedKey = System.Windows.Forms.Keys.None;
            this.basePage.SelectionGroupColor = System.Drawing.Color.Lime;
            this.basePage.Size = new System.Drawing.Size(611, 594);
            this.basePage.SplitterWidthEx = 10;
            this.basePage.TabIndex = 0;
            // 
            // pinnedWeldingAdvisorControl
            // 
            this.pinnedWeldingAdvisorControl.BackColor = System.Drawing.Color.Gainsboro;
            this.pinnedWeldingAdvisorControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedWeldingAdvisorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedWeldingAdvisorControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedWeldingAdvisorControl.HeaderName = "Постановщик задачи";
            this.pinnedWeldingAdvisorControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedWeldingAdvisorControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pinnedWeldingAdvisorControl.Name = "pinnedWeldingAdvisorControl";
            this.pinnedWeldingAdvisorControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedWeldingAdvisorControl.Size = new System.Drawing.Size(339, 589);
            this.pinnedWeldingAdvisorControl.TabIndex = 1;
            this.pinnedWeldingAdvisorControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedWeldingAdvisorControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedAnimationControl
            // 
            this.pinnedAnimationControl.BackColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedAnimationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedAnimationControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.HeaderName = "Построить поле";
            this.pinnedAnimationControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedAnimationControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.pinnedAnimationControl.Name = "pinnedAnimationControl";
            this.pinnedAnimationControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedAnimationControl.Size = new System.Drawing.Size(339, 589);
            this.pinnedAnimationControl.TabIndex = 0;
            this.pinnedAnimationControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedMeshGenControl
            // 
            this.pinnedMeshGenControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedMeshGenControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedMeshGenControl.HeaderName = "Сеточный генератор";
            this.pinnedMeshGenControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedMeshGenControl.Margin = new System.Windows.Forms.Padding(0);
            this.pinnedMeshGenControl.Name = "pinnedMeshGenControl";
            this.pinnedMeshGenControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedMeshGenControl.Size = new System.Drawing.Size(339, 589);
            this.pinnedMeshGenControl.TabIndex = 2;
            this.pinnedMeshGenControl.UpColor = System.Drawing.Color.Gainsboro;
            // 
            // EmbendentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerEx);
            this.Name = "EmbendentPage";
            this.Size = new System.Drawing.Size(959, 594);
            this.splitContainerEx.Panel1.ResumeLayout(false);
            this.splitContainerEx.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx)).EndInit();
            this.splitContainerEx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UserControlsEx.SplitContainerEx splitContainerEx;
        protected BasePage basePage;
        private TaskModule.BasicTaskAdvisor.PinnedWAdvControl pinnedWeldingAdvisorControl;
        private Results.Animation.PinnedAnimationControl pinnedAnimationControl;
        private Mesh.PinnedMeshGenControl pinnedMeshGenControl;
    }
}
