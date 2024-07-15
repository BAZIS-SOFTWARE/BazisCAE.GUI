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
            this.instrumentToolStrip = new BaseModule.ControlsLib.InstrumentToolStrip();
            this.displayToolStrip = new BaseModule.ControlsLib.DisplayToolStrip();
            this.viewToolStrip = new BaseModule.ControlsLib.ViewToolStrip();
            this.selectToolStrip = new BaseModule.ControlsLib.ToolStripEx();
            this.spb_Select = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.selectToolStrip_1 = new BaseModule.ControlsLib.SelectToolStrip();
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
            this.selectToolStrip.SuspendLayout();
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
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1308, 595);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(5, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1308, 648);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip_1);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 81);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
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
            this.splitContainer1.Size = new System.Drawing.Size(1298, 585);
            this.splitContainer1.SplitterDistance = 309;
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
            this.navigator.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.navigator.Name = "navigator";
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(307, 585);
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
            this.splitContainer2.Size = new System.Drawing.Size(984, 585);
            this.splitContainer2.SplitterDistance = 396;
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
            this.sceneControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sceneControl.DisplayBasis = true;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsClipPlane = false;
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
            this.sceneControl.ScaleFactor = 1F;
            this.sceneControl.SelectionColor = System.Drawing.Color.Green;
            this.sceneControl.ShadowAngle = 0F;
            this.sceneControl.ShowSurfaceBackEdges = false;
            this.sceneControl.Size = new System.Drawing.Size(984, 395);
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
            this.consoleControl.Size = new System.Drawing.Size(984, 184);
            this.consoleControl.TabIndex = 4;
            this.consoleControl.UpColor = System.Drawing.Color.Silver;
            this.consoleControl.InEvent += new System.Action<object, System.EventArgs>(this.ConsoleControl_InEvent);
            // 
            // instrumentToolStrip
            // 
            this.instrumentToolStrip.CrossSectionImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.CrossSectionImage")));
            this.instrumentToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.instrumentToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.instrumentToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.instrumentToolStrip.Location = new System.Drawing.Point(3, 0);
            this.instrumentToolStrip.MakePhotoImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.MakePhotoImage")));
            this.instrumentToolStrip.MeasureImage = ((System.Drawing.Image)(resources.GetObject("instrumentToolStrip.MeasureImage")));
            this.instrumentToolStrip.Name = "instrumentToolStrip";
            this.instrumentToolStrip.Size = new System.Drawing.Size(111, 53);
            this.instrumentToolStrip.TabIndex = 4;
            this.instrumentToolStrip.Text = "Инструменты";
            this.instrumentToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.InstrumentalToolStrip_ItemClicked);
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
            this.displayToolStrip.Location = new System.Drawing.Point(114, 0);
            this.displayToolStrip.Name = "displayToolStrip";
            this.displayToolStrip.ShowBasisImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.ShowBasisImage")));
            this.displayToolStrip.Size = new System.Drawing.Size(291, 53);
            this.displayToolStrip.SurfaceNodesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.SurfaceNodesImage")));
            this.displayToolStrip.TabIndex = 3;
            this.displayToolStrip.Text = "Отображение";
            this.displayToolStrip.VolumeNodesImage = ((System.Drawing.Image)(resources.GetObject("displayToolStrip.VolumeNodesImage")));
            this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStrip_ItemClick);
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.FitImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.FitImage")));
            this.viewToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.viewToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.viewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.viewToolStrip.Location = new System.Drawing.Point(405, 0);
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
            // selectToolStrip
            // 
            this.selectToolStrip.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.selectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.selectToolStrip.IconLocation = new System.Drawing.Point(0, 3);
            this.selectToolStrip.ItemBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.selectToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.selectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spb_Select,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton1});
            this.selectToolStrip.ItemSelectColor = System.Drawing.Color.DarkGray;
            this.selectToolStrip.Location = new System.Drawing.Point(732, 0);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.Size = new System.Drawing.Size(306, 53);
            this.selectToolStrip.SplitButtonTriangleSize = 7;
            this.selectToolStrip.SplitButtonWidth = 24;
            this.selectToolStrip.TabIndex = 5;
            this.selectToolStrip.Text = "Выбор";
            this.selectToolStrip.TextBoxHeight = 16;
            this.selectToolStrip.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            // 
            // spb_Select
            // 
            this.spb_Select.AutoSize = false;
            this.spb_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.spb_Select.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.spb_Select.Image = ((System.Drawing.Image)(resources.GetObject("spb_Select.Image")));
            this.spb_Select.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.spb_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spb_Select.Name = "spb_Select";
            this.spb_Select.Size = new System.Drawing.Size(150, 50);
            this.spb_Select.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.spb_Select_DropDownItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItem1.Text = "rrr";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItem2.Text = "fff";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItem3.Text = "ddd";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItem4.Text = "ggg";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 50);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 50);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 50);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 50);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // selectToolStrip_1
            // 
            this.selectToolStrip_1.AllowDrop = true;
            this.selectToolStrip_1.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip_1.ElementsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip_1.ElementsImage")));
            this.selectToolStrip_1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.selectToolStrip_1.GeomsImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip_1.GeomsImage")));
            this.selectToolStrip_1.GripMargin = new System.Windows.Forms.Padding(0);
            this.selectToolStrip_1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.selectToolStrip_1.HelperImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip_1.HelperImage")));
            this.selectToolStrip_1.Location = new System.Drawing.Point(1038, 0);
            this.selectToolStrip_1.Name = "selectToolStrip_1";
            this.selectToolStrip_1.NodeImage = ((System.Drawing.Image)(resources.GetObject("selectToolStrip_1.NodeImage")));
            this.selectToolStrip_1.SelectObjectsType = ModelInterfaces.ObjType.Объект;
            this.selectToolStrip_1.Size = new System.Drawing.Size(270, 53);
            this.selectToolStrip_1.TabIndex = 1;
            this.selectToolStrip_1.Text = "Выбор";
            this.selectToolStrip_1.SelectObjectEvent += new System.Action<object, BaseModule.ControlsLib.SelectObjectEventArgs>(this.SelectToolStrip_SelectObjectEvent);
            this.selectToolStrip_1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectToolStrip_ItemClicked);
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
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
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
            this.selectToolStrip.ResumeLayout(false);
            this.selectToolStrip.PerformLayout();
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
        private ViewToolStrip viewToolStrip;
        private InstrumentToolStrip instrumentToolStrip;
        protected DisplayToolStrip displayToolStrip;
        protected SelectToolStrip selectToolStrip_1;
        private ToolStripEx selectToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton spb_Select;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
