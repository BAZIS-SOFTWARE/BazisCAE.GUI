using BaseModule.Mesh;
using BaseModule.Results.Animation;
using BaseModule.Tasks.HeatTreatmentModule;
using BaseModule.Tasks.WeldingModule;
using Model.Interfaces;

namespace BazisGUI
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
            this.pinnedMeshGenControl = new BaseModule.Mesh.PinnedMeshGenControl();
            this.pinnedAnimationControl = new BaseModule.Results.Animation.PinnedAnimationControl();
            this.pinnedWAdvControl = new BaseModule.Tasks.WeldingModule.PinnedWAdvControl();
            this.pinnedHTAdvControl = new BaseModule.Tasks.HeatTreatmentModule.PinnedHTAdvControl();
            this.pinnedCTAdvControl = new BaseModule.Tasks.HeatTreatmentModule.PinnedCTAdvControl();
            this.basePage = new BazisGUI.BasePage();
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
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedAnimationControl);
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedWAdvControl);
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedHTAdvControl);
            this.splitContainerEx.Panel2.Controls.Add(this.pinnedCTAdvControl);
            this.splitContainerEx.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.splitContainerEx.Size = new System.Drawing.Size(998, 576);
            this.splitContainerEx.SplitterDistance = 635;
            this.splitContainerEx.SwitchShifting = false;
            this.splitContainerEx.TabIndex = 2;
            // 
            // pinnedMeshGenControl
            // 
            this.pinnedMeshGenControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedMeshGenControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedMeshGenControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedMeshGenControl.HeaderName = "Сеточный генератор";
            this.pinnedMeshGenControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedMeshGenControl.Margin = new System.Windows.Forms.Padding(0);
            this.pinnedMeshGenControl.Name = "pinnedMeshGenControl";
            this.pinnedMeshGenControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedMeshGenControl.Size = new System.Drawing.Size(354, 571);
            this.pinnedMeshGenControl.TabIndex = 7;
            this.pinnedMeshGenControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedMeshGenControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedAnimationControl
            // 
            this.pinnedAnimationControl.BackColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedAnimationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedAnimationControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.HeaderName = "Анимация результатов";
            this.pinnedAnimationControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedAnimationControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.pinnedAnimationControl.Name = "pinnedAnimationControl";
            this.pinnedAnimationControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedAnimationControl.Size = new System.Drawing.Size(354, 571);
            this.pinnedAnimationControl.TabIndex = 6;
            this.pinnedAnimationControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedAnimationControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedWAdvControl
            // 
            this.pinnedWAdvControl.BackColor = System.Drawing.Color.Gainsboro;
            this.pinnedWAdvControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedWAdvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedWAdvControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedWAdvControl.HeaderName = "Постановщик задачи сварки";
            this.pinnedWAdvControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedWAdvControl.Margin = new System.Windows.Forms.Padding(0);
            this.pinnedWAdvControl.Name = "pinnedWAdvControl";
            this.pinnedWAdvControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedWAdvControl.Size = new System.Drawing.Size(354, 571);
            this.pinnedWAdvControl.TabIndex = 5;
            this.pinnedWAdvControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedWAdvControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedHTAdvControl
            // 
            this.pinnedHTAdvControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedHTAdvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedHTAdvControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedHTAdvControl.HeaderName = "Постановка задачи ТО";
            this.pinnedHTAdvControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedHTAdvControl.Margin = new System.Windows.Forms.Padding(0);
            this.pinnedHTAdvControl.Name = "pinnedHTAdvControl";
            this.pinnedHTAdvControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedHTAdvControl.Size = new System.Drawing.Size(354, 571);
            this.pinnedHTAdvControl.TabIndex = 4;
            this.pinnedHTAdvControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedHTAdvControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
            // 
            // pinnedCTAdvControl
            // 
            this.pinnedCTAdvControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pinnedCTAdvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pinnedCTAdvControl.DownColor = System.Drawing.Color.Gainsboro;
            this.pinnedCTAdvControl.HeaderName = "Постановка задачи диффузии";
            this.pinnedCTAdvControl.Location = new System.Drawing.Point(0, 5);
            this.pinnedCTAdvControl.Margin = new System.Windows.Forms.Padding(0);
            this.pinnedCTAdvControl.Name = "pinnedCTAdvControl";
            this.pinnedCTAdvControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pinnedCTAdvControl.Size = new System.Drawing.Size(354, 571);
            this.pinnedCTAdvControl.TabIndex = 3;
            this.pinnedCTAdvControl.UpColor = System.Drawing.Color.Gainsboro;
            this.pinnedCTAdvControl.ControlCollapseEvent += new System.Action(this.pinnedControl_ControlCollapseEvent);
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
            this.basePage.Size = new System.Drawing.Size(635, 576);
            this.basePage.SplitterWidthEx = 10;
            this.basePage.TabIndex = 0;
            this.basePage.DeleteGroupEvent += new System.Action<object, int>(this.basePage_DeleteGroupEvent);
            this.basePage.DeleteAllGroupsEvent += new System.Action<object>(this.basePage_DeleteAllGroupsEvent);
            this.basePage.DeleteObjectsEvent += new System.Action<object, Model.Interfaces.ObjType, string>(this.basePage_DeleteObjectsEvent);
            this.basePage.ShowAllGroupsEvent += new System.Action<object, bool>(this.basePage_HideAllGroupsEvent);
            this.basePage.ShowGroupEvent += new System.Action<object, int, bool>(this.basePage_ShowGroupEvent);
            this.basePage.SelectObjectsEvent += new System.Action<object, Scene.Events.SelectObjectsEventArgs, Model.Interfaces.ObjType>(this.basePage_SelectObjectsEvent);
            this.basePage.FindFreeNodesEvent += new System.Action<object>(this.basePage_FindFreeNodesEvent);
            // 
            // EmbendentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerEx);
            this.Name = "EmbendentPage";
            this.Size = new System.Drawing.Size(998, 576);
            this.splitContainerEx.Panel1.ResumeLayout(false);
            this.splitContainerEx.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx)).EndInit();
            this.splitContainerEx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UserControlsEx.SplitContainerEx splitContainerEx;
        protected BasePage basePage;
        private PinnedCTAdvControl pinnedCTAdvControl;
        private PinnedHTAdvControl pinnedHTAdvControl;
        private PinnedWAdvControl pinnedWAdvControl;
        private PinnedAnimationControl pinnedAnimationControl;
        private PinnedMeshGenControl pinnedMeshGenControl;
    }
}
