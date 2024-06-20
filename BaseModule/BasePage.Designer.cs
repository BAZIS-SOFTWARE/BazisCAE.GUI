using BaseModule.Console;
using BaseModule.ControlsLib;
using ModelInterfaces;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePage));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.navigator = new BaseModule.Navigator.NavigatorControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sceneControl = new Scene.SceneControl();
            this.consoleControl = new BaseModule.Console.ConsoleControl();
            this.selectToolStrip = new BaseModule.ControlsLib.SelectToolStrip();
            this.viewToolStrip = new BaseModule.ControlsLib.ViewToolStrip();
            this.displayToolStrip = new BaseModule.ControlsLib.DisplayToolStrip();
            this.instrumentToolStrip = new BaseModule.ControlsLib.InstrumentToolStrip();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1318, 595);
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
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentToolStrip);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 81);
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
            this.splitContainer1.Panel1.Controls.Add(this.navigator);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1308, 585);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.SplitterIncrement = 15;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            this.splitContainer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseClick);
            // 
            // navigator
            // 
            this.navigator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navigator.BackColor = System.Drawing.SystemColors.Control;
            this.navigator.CollapseIndex = 1;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.DownColor = System.Drawing.Color.WhiteSmoke;
            this.navigator.ExpandIndex = 2;
            this.navigator.HeaderName = "Навигатор";
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Name = "navigator";
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(311, 585);
            this.navigator.TabIndex = 0;
            this.navigator.UpColor = System.Drawing.Color.Silver;
            this.navigator.RenameGroupEvent += new System.Action<string, string>(this.navigator_RenameGroup);
            this.navigator.SelectGroupEvent += new System.Action<string>(this.navigator_SelectGroupEvent);
            this.navigator.DelGroupEvent += new System.Action<int>(this.navigator_DelGroupEvent);
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
            this.navigator.ShowObjectsEvent += new System.Action<string>(this.navigator_ShowObjectsEvent);
            this.navigator.ChangeObjectsViewEvent += new System.Action<string, BaseModule.Navigator.ViewRegime>(this.navigator_ChangeViewModeEventHandler);
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
            this.splitContainer2.Panel1.Controls.Add(this.sceneControl);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.consoleControl);
            this.splitContainer2.Size = new System.Drawing.Size(990, 585);
            this.splitContainer2.SplitterDistance = 397;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Paint);
            this.splitContainer2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer2_MouseClick);
            // 
            // sceneControl
            // 
            this.sceneControl.AutoSize = true;
            this.sceneControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.Color.Green;
            this.sceneControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sceneControl.DisplayBasis = true;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsSmoothShadow = false;
            this.sceneControl.LightAttenuation = 0F;
            this.sceneControl.LightTranslateX = 0F;
            this.sceneControl.LightTranslateY = 0F;
            this.sceneControl.LightTranslateZ = 0F;
            this.sceneControl.Location = new System.Drawing.Point(0, 0);
            this.sceneControl.Margin = new System.Windows.Forms.Padding(0);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.Projection = SceneInterface.ViewProjection.Perspective;
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = SceneInterface.ViewAxis.XYZ;
            this.sceneControl.SelectionColor = System.Drawing.Color.Green;
            this.sceneControl.ShadowAngle = 0F;
            this.sceneControl.ShowSurfaceBackEdges = false;
            this.sceneControl.Size = new System.Drawing.Size(990, 396);
            this.sceneControl.TabIndex = 0;
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
            this.sceneControl.Load += new System.EventHandler(this.sceneControl_Load);
            // 
            // consoleControl
            // 
            this.consoleControl.AutoSize = true;
            this.consoleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.consoleControl.BackColor = System.Drawing.SystemColors.Control;
            this.consoleControl.CheckPrintElemsInfo = false;
            this.consoleControl.CheckPrintNodesInfo = false;
            this.consoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl.DownColor = System.Drawing.Color.WhiteSmoke;
            this.consoleControl.HeaderName = "Консоль";
            this.consoleControl.Location = new System.Drawing.Point(0, 0);
            this.consoleControl.Margin = new System.Windows.Forms.Padding(4);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(990, 183);
            this.consoleControl.TabIndex = 4;
            this.consoleControl.UpColor = System.Drawing.Color.Silver;
            this.consoleControl.InEvent += new System.Action<object, System.EventArgs>(this.ConsoleControl_InEvent);
            // 
            // selectToolStrip
            // 
            this.selectToolStrip.AllowDrop = true;
            this.selectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip.ElementsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.ElementsImage")));
            this.selectToolStrip.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.selectToolStrip.GeomsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.GeomsImage")));
            this.selectToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.selectToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.selectToolStrip.HelperImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.HelperImage")));
            this.selectToolStrip.Location = new System.Drawing.Point(3, 0);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.NodeImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip.NodeImage")));
            this.selectToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.selectToolStrip.SelectObjectsType = ModelInterfaces.ObjType.Объект;
            this.selectToolStrip.Size = new System.Drawing.Size(302, 53);
            this.selectToolStrip.TabIndex = 1;
            this.selectToolStrip.Text = "Выбор";
            this.selectToolStrip.SelectObjectEvent += new System.Action<object, BaseModule.ControlsLib.SelectObjectEventArgs>(this.SelectToolStrip_SelectObjectEvent);
            this.selectToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectToolStrip_ItemClicked);
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.FitImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.FitImage")));
            this.viewToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.viewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.viewToolStrip.Location = new System.Drawing.Point(305, 0);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.PlaneXYImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.PlaneXYImage")));
            this.viewToolStrip.PlaneXZImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.PlaneXZImage")));
            this.viewToolStrip.PlaneYZImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.PlaneYZImage")));
            this.viewToolStrip.Rot90HorImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.Rot90HorImage")));
            this.viewToolStrip.Rot90VerImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.Rot90VerImage")));
            this.viewToolStrip.RotXImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.RotXImage")));
            this.viewToolStrip.RotYImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.RotYImage")));
            this.viewToolStrip.RotZImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.RotZImage")));
            this.viewToolStrip.Size = new System.Drawing.Size(327, 53);
            this.viewToolStrip.TabIndex = 2;
            this.viewToolStrip.Text = "Вид";
            this.viewToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewToolStrip_ItemClicked);
            // 
            // displayToolStrip
            // 
            this.displayToolStrip.BoundaryContoursImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.BoundaryContoursImage")));
            this.displayToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.displayToolStrip.ElementsFramesAndSurfacesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ElementsFramesAndSurfacesImage")));
            this.displayToolStrip.ElementsFramesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ElementsFramesImage")));
            this.displayToolStrip.ElementsNormalsImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ElementsNormalsImage")));
            this.displayToolStrip.ElementsSurfacesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ElementsSurfacesImage")));
            this.displayToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.displayToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.displayToolStrip.Location = new System.Drawing.Point(632, 0);
            this.displayToolStrip.Name = "displayToolStrip";
            this.displayToolStrip.ShowBasisImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ShowBasisImage")));
            this.displayToolStrip.Size = new System.Drawing.Size(291, 53);
            this.displayToolStrip.SurfaceNodesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.SurfaceNodesImage")));
            this.displayToolStrip.TabIndex = 3;
            this.displayToolStrip.Text = "Отображение";
            this.displayToolStrip.VolumeNodesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.VolumeNodesImage")));
            this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStrip_ItemClick);
            // 
            // instrumentToolStrip
            // 
            this.instrumentToolStrip.CrossSectionImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.CrossSectionImage")));
            this.instrumentToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.instrumentToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.instrumentToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.instrumentToolStrip.Location = new System.Drawing.Point(923, 0);
            this.instrumentToolStrip.MakePhotoImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.MakePhotoImage")));
            this.instrumentToolStrip.MeasureImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.MeasureImage")));
            this.instrumentToolStrip.Name = "instrumentToolStrip";
            this.instrumentToolStrip.Size = new System.Drawing.Size(111, 53);
            this.instrumentToolStrip.TabIndex = 4;
            this.instrumentToolStrip.Text = "Инструменты";
            this.instrumentToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.InstrumentalToolStrip_ItemClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "BasePage";
            this.Size = new System.Drawing.Size(1318, 648);
            this.Load += new System.EventHandler(this.BasePage_Load);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ConsoleControl consoleControl;
        private Navigator.NavigatorControl navigator;
        private Scene.SceneControl sceneControl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private SelectToolStrip selectToolStrip;
        private ViewToolStrip viewToolStrip;
        private DisplayToolStrip displayToolStrip;
        private InstrumentToolStrip instrumentToolStrip;
    }
}
