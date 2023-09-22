using BaseModule.Console;
using BaseModule.ToolStrips;
using System.Drawing;

namespace BaseModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePage));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInputCmd = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.webPageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbNavigator = new System.Windows.Forms.Panel();
            this.navigator = new BaseModule.Navigator.NavigatorControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grbScene = new System.Windows.Forms.Panel();
            this.sceneControl = new Scene.SceneControl();
            this.grbConsole = new System.Windows.Forms.Panel();
            this.consoleControl = new BaseModule.Console.ConsoleControl();
            this.standartToolStrip = new BaseModule.ToolStrips.StandartToolStrip();
            this.instrumentalToolStrip = new BaseModule.ToolStrips.InstrumentToolStrip();
            this.viewToolStrip = new BaseModule.ToolStrips.ViewToolStrip();
            this.displayToolStrip = new BaseModule.ToolStrips.DisplayToolStrip();
            this.selectToolStrip = new BaseModule.ToolStrips.SelectToolStrip();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grbScene.SuspendLayout();
            this.grbConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1318, 467);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1318, 648);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInputCmd,
            this.lblVersion,
            this.webPageLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1318, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblInputCmd
            // 
            this.lblInputCmd.AutoSize = false;
            this.lblInputCmd.BackColor = System.Drawing.SystemColors.Control;
            this.lblInputCmd.Name = "lblInputCmd";
            this.lblInputCmd.Size = new System.Drawing.Size(376, 17);
            this.lblInputCmd.Text = "Начните работу с загрузки проекта или импорта сеточной модели";
            this.lblInputCmd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInputCmd.TextChanged += new System.EventHandler(this.lblInputCmd_TextChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(826, 17);
            this.lblVersion.Spring = true;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // webPageLabel
            // 
            this.webPageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.webPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.webPageLabel.IsLink = true;
            this.webPageLabel.LinkColor = System.Drawing.Color.OrangeRed;
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(101, 17);
            this.webPageLabel.Text = "www.bazisnet.ru";
            this.webPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.webPageLabel.Click += new System.EventHandler(this.WebPageLabel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbNavigator);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1308, 457);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // grbNavigator
            // 
            this.grbNavigator.BackColor = System.Drawing.Color.Silver;
            this.grbNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbNavigator.Controls.Add(this.navigator);
            this.grbNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNavigator.Location = new System.Drawing.Point(0, 0);
            this.grbNavigator.Name = "grbNavigator";
            this.grbNavigator.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbNavigator.Size = new System.Drawing.Size(450, 457);
            this.grbNavigator.TabIndex = 0;
            this.grbNavigator.Paint += new System.Windows.Forms.PaintEventHandler(this.grbNavigator_Paint);
            // 
            // navigator
            // 
            this.navigator.CollapseIndex = 1;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.ExpandIndex = 2;
            this.navigator.Location = new System.Drawing.Point(0, 15);
            this.navigator.Name = "navigator";
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(448, 440);
            this.navigator.TabIndex = 0;
            this.navigator.RenameGroupEvent += new System.Action<string, string>(this.navigator_RenameGroup);
            this.navigator.SelectGroupEvent += new System.Action<string>(this.navigator_SelectGroupEvent);
            this.navigator.DelGroupEvent += new System.Action<int>(this.navigator_DelGroupEvent);
            this.navigator.HideGroupEvent += new System.Action<int>(this.navigator_HideGroupEvent);
            this.navigator.ShowGroupEvent += new System.Action<int>(this.navigator_ShowGroupEvent);
            this.navigator.EditGroupEvent += new System.Action<int>(this.navigator_EditGroupEvent);
            this.navigator.InfoGroupEvent += new System.Action<int>(this.navigator_InfoGroupEvent);
            this.navigator.ShowGroupWithNodesEvent += new System.Action<int>(this.navigator_ShowGroupWithNodesEvent);
            this.navigator.ShowAllGroupsEvent += new System.Action(this.navigator_ShowAllGroupsEvent);
            this.navigator.HideAllGroupsEvent += new System.Action(this.navigator_HideAllGroupsEvent);
            this.navigator.ShowAllObjectsEvent += new System.Action(this.navigator_ShowAllObjectsEvent);
            this.navigator.HideAllObjectsEvent += new System.Action(this.navigator_HideAllObjectsEvent);
            this.navigator.ShowObjectsEvent += new System.Action<string>(this.navigator_ShowObjectsEvent);
            this.navigator.ChangeObjectsViewEvent += new System.Action<string, BaseModule.Navigator.NavigatorControl.ViewRegime>(this.navigator_ChangeViewModeEvent);
            this.navigator.HideObjectsEvent += new System.Action<string>(this.navigator_HideObjectsEvent);
            this.navigator.DelObjectsEvent += new System.Action<string>(this.navigator_DelObjectsEvent);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grbScene);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbConsole);
            this.splitContainer2.Size = new System.Drawing.Size(853, 457);
            this.splitContainer2.SplitterDistance = 348;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // grbScene
            // 
            this.grbScene.BackColor = System.Drawing.Color.Silver;
            this.grbScene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbScene.Controls.Add(this.sceneControl);
            this.grbScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbScene.Location = new System.Drawing.Point(0, 0);
            this.grbScene.Name = "grbScene";
            this.grbScene.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbScene.Size = new System.Drawing.Size(853, 348);
            this.grbScene.TabIndex = 0;
            this.grbScene.Paint += new System.Windows.Forms.PaintEventHandler(this.grbScene_Paint);
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.Color.White;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsBlending = true;
            this.sceneControl.IsLighting = true;
            this.sceneControl.Location = new System.Drawing.Point(0, 15);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = SceneInterface.ViewAxis.XYZ;
            this.sceneControl.SelectionColor = System.Drawing.Color.LawnGreen;
            this.sceneControl.Size = new System.Drawing.Size(851, 331);
            this.sceneControl.TabIndex = 4;
            this.sceneControl.TitleColor = System.Drawing.Color.Black;
            this.sceneControl.TitleText = "";
            this.sceneControl.InfoObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_InfoObjectsEvent);
            this.sceneControl.SelectObjectsEvent += new System.Action<object, Scene.Events.SelectObjectsEventArgs>(this.sceneControl_SelectObjectsEvent);
            this.sceneControl.SetBackColorEvent += new System.Action<object, System.EventArgs>(this.sceneControl_SetBackColorEvent);
            this.sceneControl.ShowAllHiddenObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_ShowAllHiddenObjectsEvent);
            this.sceneControl.HideSelectedObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_HideSelectedObjectsEvent);
            this.sceneControl.CreateMeshGroupEvent += new System.Action<object, System.EventArgs>(this.sceneControl_CreateMeshGroupEvent);
            this.sceneControl.DeleteSelectionEvent += new System.Action<object, System.EventArgs>(this.sceneControl_DeleteSelectionEvent);
            this.sceneControl.MessageEvent += new System.Action<object, Scene.Events.MessageEventArgs>(this.sceneControl_MessageEvent);
            // 
            // grbConsole
            // 
            this.grbConsole.BackColor = System.Drawing.Color.Silver;
            this.grbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbConsole.Controls.Add(this.consoleControl);
            this.grbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConsole.Location = new System.Drawing.Point(0, 0);
            this.grbConsole.Name = "grbConsole";
            this.grbConsole.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbConsole.Size = new System.Drawing.Size(853, 104);
            this.grbConsole.TabIndex = 0;
            this.grbConsole.Paint += new System.Windows.Forms.PaintEventHandler(this.grbConsole_Paint);
            // 
            // consoleControl
            // 
            this.consoleControl.BackColor = System.Drawing.SystemColors.Control;
            this.consoleControl.CheckPrintElemsInfo = false;
            this.consoleControl.CheckPrintNodesInfo = false;
            this.consoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl.Location = new System.Drawing.Point(0, 15);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(851, 87);
            this.consoleControl.TabIndex = 4;
            this.consoleControl.InEvent += new System.Action<object, System.EventArgs>(this.ConsoleControl_InEvent);
            // 
            // standartToolStrip
            // 
            this.standartToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.standartToolStrip.Location = new System.Drawing.Point(0, 106);
            this.standartToolStrip.Name = "standartToolStrip";
            this.standartToolStrip.Size = new System.Drawing.Size(156, 53);
            this.standartToolStrip.TabIndex = 0;
            this.standartToolStrip.Text = "Стандартные элементы";
            this.standartToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StandartToolStrip_ItemClicked);
            // 
            // instrumentalToolStrip
            // 
            this.instrumentalToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.instrumentalToolStrip.Location = new System.Drawing.Point(0, 106);
            this.instrumentalToolStrip.Name = "instrumentalToolStrip";
            this.instrumentalToolStrip.Size = new System.Drawing.Size(120, 53);
            this.instrumentalToolStrip.TabIndex = 0;
            this.instrumentalToolStrip.Text = "Инструменты";
            this.instrumentalToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.InstrumentalToolStrip_ItemClicked);
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.Location = new System.Drawing.Point(0, 53);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Size = new System.Drawing.Size(336, 53);
            this.viewToolStrip.TabIndex = 0;
            this.viewToolStrip.Text = "Вид";
            this.viewToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewToolStrip_ItemClicked);
            // 
            // displayToolStrip
            // 
            this.displayToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.displayToolStrip.Location = new System.Drawing.Point(0, 53);
            this.displayToolStrip.Name = "displayToolStrip";
            this.displayToolStrip.Size = new System.Drawing.Size(348, 53);
            this.displayToolStrip.TabIndex = 0;
            this.displayToolStrip.Text = "Отображение";
            this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStrip_ItemClick);
            // 
            // selectToolStrip
            // 
            this.selectToolStrip.AllowDrop = true;
            this.selectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip.ElementsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.ElementsImage")));
            this.selectToolStrip.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.selectToolStrip.GeomsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.GeomsImage")));
            this.selectToolStrip.HelperImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.HelperImage")));
            this.selectToolStrip.Location = new System.Drawing.Point(0, 0);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.NodeImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.NodeImage")));
            this.selectToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.selectToolStrip.SelectObjectsType = "Выберите объект";
            this.selectToolStrip.Size = new System.Drawing.Size(311, 53);
            this.selectToolStrip.TabIndex = 0;
            this.selectToolStrip.Text = "Выбор";
            this.selectToolStrip.SelectObjectEvent += new System.Action<object, BaseModule.ToolStrips.SelectObjectEventArgs>(this.SelectToolStrip_SelectObjectEvent);
            this.selectToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectToolStrip_ItemClicked);
            // 
            // BasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "BasePage";
            this.Size = new System.Drawing.Size(1318, 648);
            this.Load += new System.EventHandler(this.BasePage_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbNavigator.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grbScene.ResumeLayout(false);
            this.grbConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInputCmd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripStatusLabel webPageLabel;
        private System.Windows.Forms.Panel grbConsole;
        private ConsoleControl consoleControl;
        private System.Windows.Forms.Panel grbNavigator;
        private System.Windows.Forms.Panel grbScene;
        //private Scene.SceneControl sceneControl;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private Scene.SceneControl sceneControl;
        DisplayToolStrip displayToolStrip;
        SelectToolStrip selectToolStrip;
        StandartToolStrip standartToolStrip;
        ViewToolStrip viewToolStrip;
        InstrumentToolStrip instrumentalToolStrip;
        private Navigator.NavigatorControl navigator;
    }
}
