using BaseModule.Console;
using BazisGUI.Navigator;
using UserControlsEx;

namespace BazisGUI
{
    partial class BasePage
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1 = new UserControlsEx.SplitContainerEx();
            this.navigator = new BazisGUI.Navigator.NavigatorPage();
            this.splitContainer2 = new UserControlsEx.SplitContainerEx();
            this.scenePage = new BazisGUI.ScenePage();
            this.consoleControl = new BaseModule.Console.ConsoleControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IncrementButtonSize = new System.Drawing.Size(10, 50);
            this.splitContainer1.IncrementShifting = 50;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.navigator);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1308, 643);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.SplitterIncrement = 15;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.SwitchShifting = false;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // navigator
            // 
            this.navigator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navigator.BackColor = System.Drawing.SystemColors.Control;
            this.navigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigator.CollapseIndex = 14;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.DownColor = System.Drawing.Color.Gainsboro;
            this.navigator.ExpandIndex = 15;
            this.navigator.HeaderName = "Навигатор";
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Margin = new System.Windows.Forms.Padding(0);
            this.navigator.Name = "navigator";
            this.navigator.ProjectInfoIndex = 16;
            this.navigator.Size = new System.Drawing.Size(307, 643);
            this.navigator.TabIndex = 0;
            this.navigator.UpColor = System.Drawing.Color.Gainsboro;
            this.navigator.RenameGroupEvent += new System.Action<string, string>(this.navigator_RenameGroup);
            this.navigator.SelectGroupEvent += new System.Action<string>(this.navigator_SelectGroupEvent);
            this.navigator.DelGroupEvent += new System.Action<System.Windows.Forms.TreeNode>(this.navigator_DelGroupEvent);
            this.navigator.DelAllGroupsEvent += new System.Action(this.navigator_DelAllGroupsEvent);
            this.navigator.HideGroupEvent += new System.Action<int>(this.navigator_HideGroupEvent);
            this.navigator.ShowGroupEvent += new System.Action<int>(this.navigator_ShowGroupEvent);
            this.navigator.EditGroupEvent += new System.Action<int>(this.navigator_EditGroupEvent);
            this.navigator.InfoGroupEvent += new System.Action<int>(this.navigator_InfoGroupEvent);
            this.navigator.ShowGroupWithNodesEvent += new System.Action<int>(this.navigator_ShowGroupWithNodesEvent);
            this.navigator.ShowAllGroupsEvent += new System.Action(this.navigator_ShowAllGroupsEvent);
            this.navigator.HideAllGroupsEvent += new System.Action(this.navigator_HideAllGroupsEvent);
            this.navigator.ShowAllObjectsEvent += new System.Action(this.navigator_ShowAllObjectsEvent);
            this.navigator.HideAllObjectsEvent += new System.Action(this.navigator_HideAllObjectsEvent);
            this.navigator.ShowObjectsEvent += new System.Action<string, string>(this.navigator_ShowObjectsEvent);
            this.navigator.ChangeObjectsViewEvent += new System.Action<string, BazisGUI.Navigator.ViewRegime>(this.navigator_ChangeViewModeEventHandler);
            this.navigator.HideObjectsEvent += new System.Action<string, string>(this.navigator_HideObjectsEvent);
            this.navigator.DelObjectsEvent += new System.Action<System.Windows.Forms.TreeNode>(this.navigator_DelObjectsEvent);
            this.navigator.DelAllObjectsEvent += new System.Action(this.navigator_DelAllObjectsEvent);
            this.navigator.ControlCollapseEvent += new System.Action(this.navigator_NavigatorPanelCollapseEvent);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IncrementButtonSize = new System.Drawing.Size(50, 11);
            this.splitContainer2.IncrementShifting = 50;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.scenePage);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.consoleControl);
            this.splitContainer2.Size = new System.Drawing.Size(995, 643);
            this.splitContainer2.SplitterDistance = 429;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.SwitchShifting = false;
            this.splitContainer2.TabIndex = 0;
            // 
            // scenePage
            // 
            this.scenePage.AutoSize = true;
            this.scenePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scenePage.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.scenePage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scenePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scenePage.Location = new System.Drawing.Point(0, 0);
            this.scenePage.Margin = new System.Windows.Forms.Padding(0);
            this.scenePage.Name = "scenePage";
            this.scenePage.SelectedObjects = null;
            this.scenePage.Size = new System.Drawing.Size(995, 428);
            this.scenePage.TabIndex = 0;
            this.scenePage.TransparencyValue = 0;
            this.scenePage.MeshGroupCreatedEvent += new System.Action<object, string>(this.scenePage_CreateMeshGroupEvent);
            this.scenePage.SceneInfoEvent += new System.Action<object, string, System.Drawing.Color>(this.scenePage_SceneInfoEvent);
            this.scenePage.ShowAllObjectsEvent += new System.Action<object>(this.scenePage_ShowAllObjectsEvent);
            this.scenePage.SelectionDeletedEvent += new System.Action<object>(this.scenePage_SelectionDeletedEvent);
            this.scenePage.SceneExpandEvent += new System.Action(this.scenePage_SceneExpandEvent);
            this.scenePage.SceneFoldEvent += new System.Action(this.scenePage_SceneFoldEvent);
            this.scenePage.Load += new System.EventHandler(this.sceneControl_Load);
            // 
            // consoleControl
            // 
            this.consoleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.consoleControl.BackColor = System.Drawing.SystemColors.Control;
            this.consoleControl.CheckPrintElemsInfo = false;
            this.consoleControl.CheckPrintNodesInfo = false;
            this.consoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl.DownColor = System.Drawing.Color.Gainsboro;
            this.consoleControl.HeaderName = "Консоль";
            this.consoleControl.Location = new System.Drawing.Point(0, 0);
            this.consoleControl.Margin = new System.Windows.Forms.Padding(0);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(995, 208);
            this.consoleControl.TabIndex = 4;
            this.consoleControl.UpColor = System.Drawing.Color.Gainsboro;
            this.consoleControl.ControlCollapseEvent += new System.Action(this.consoleControl_ConsolePanelCollapseEvent);
            this.consoleControl.InEvent += new System.Action<object, System.EventArgs>(this.ConsoleControl_InEvent);
            this.consoleControl.FindFreeNodesEvent += new System.Action(this.consoleControl_FindFreeNodesEvent);
            this.consoleControl.RenumberMeshEvent += new System.Action<object, BaseModule.Console.Events.ModelRenumberEventArgs>(this.ConsoleControl_RenumberMeshEvent);
            this.consoleControl.ModelShiftCoordinateEvent += new System.Action<object, BaseModule.Console.Events.ModelShiftCoordinateEventArgs>(this.ConsoleControl_ModelShiftCoordinateEvent);
            this.consoleControl.ModelRotateEvent += new System.Action<object, BaseModule.Console.ModelRotateEventArgs>(this.ConsoleControl_ModelRotateEvent);
            // 
            // BasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BasePage";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Size = new System.Drawing.Size(1318, 648);
            this.Load += new System.EventHandler(this.BasePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private SplitContainerEx splitContainer1;
        protected NavigatorPage navigator;
        private SplitContainerEx splitContainer2;
        protected ScenePage scenePage;
        protected ConsoleControl consoleControl;
    }
}
