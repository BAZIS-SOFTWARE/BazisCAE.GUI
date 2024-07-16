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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sceneControl = new Scene.SceneControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.navigator = new BaseModule.Navigator.NavigatorControl();
            this.consoleControl = new BaseModule.Console.ConsoleControl();
            this.instrumentToolStrip = new BaseModule.ControlsLib.InstrumentToolStrip();
            this.displayToolStrip = new BaseModule.ControlsLib.DisplayToolStrip();
            this.selectToolStrip = new BaseModule.ControlsLib.ToolStripEx();
            this.spb_Select = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.viewToolStrip = new BaseModule.ControlsLib.ViewToolStrip();
            this.toolStripEx1 = new BaseModule.ControlsLib.ToolStripEx();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
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
            this.selectToolStrip.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
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
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1308, 540);
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
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripEx1);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 250);
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
            this.splitContainer1.Size = new System.Drawing.Size(1298, 530);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.SplitterIncrement = 15;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            this.splitContainer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseClick);
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
            this.splitContainer2.Size = new System.Drawing.Size(984, 530);
            this.splitContainer2.SplitterDistance = 357;
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
            this.sceneControl.Size = new System.Drawing.Size(984, 356);
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // navigator
            // 
            this.navigator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.navigator.BackColor = System.Drawing.SystemColors.Control;
            this.navigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigator.CollapseIndex = 1;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.DownColor = System.Drawing.Color.Silver;
            this.navigator.ExpandIndex = 2;
            this.navigator.HeaderName = "Навигатор";
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.navigator.Name = "navigator";
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(307, 530);
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
            this.consoleControl.Size = new System.Drawing.Size(984, 168);
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
            // selectToolStrip
            // 
            this.selectToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.selectToolStrip.BackGroundColor = System.Drawing.Color.LightGray;
            this.selectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip.FrameColor = System.Drawing.Color.Silver;
            this.selectToolStrip.GeneralFrame = true;
            this.selectToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.selectToolStrip.IconLocation = new System.Drawing.Point(0, 8);
            this.selectToolStrip.ItemBackGroundColor = System.Drawing.Color.Silver;
            this.selectToolStrip.ItemFrame = true;
            this.selectToolStrip.ItemLocation = new System.Drawing.Point(4, 4);
            this.selectToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.selectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spb_Select,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton1});
            this.selectToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.selectToolStrip.Location = new System.Drawing.Point(405, 0);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.Size = new System.Drawing.Size(289, 54);
            this.selectToolStrip.SplitButtonClickWidth = 16;
            this.selectToolStrip.SplitButtonHeight = 34;
            this.selectToolStrip.SplitButtonTriangleSize = 7;
            this.selectToolStrip.TabIndex = 5;
            this.selectToolStrip.Text = "Выбор";
            this.selectToolStrip.TextBoxFrame = true;
            this.selectToolStrip.TextBoxHeight = 14;
            // 
            // spb_Select
            // 
            this.spb_Select.AutoSize = false;
            this.spb_Select.BackColor = System.Drawing.SystemColors.Control;
            this.spb_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.spb_Select.Image = ((System.Drawing.Image)(resources.GetObject("spb_Select.Image")));
            this.spb_Select.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.spb_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spb_Select.Name = "spb_Select";
            this.spb_Select.Size = new System.Drawing.Size(150, 51);
            this.spb_Select.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.spb_Select_DropDownItemClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 51);
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
            this.toolStripButton3.Size = new System.Drawing.Size(34, 51);
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
            this.toolStripButton4.Size = new System.Drawing.Size(34, 51);
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
            this.toolStripButton1.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.FitImage = ((System.Drawing.Image)(resources.GetObject("viewToolStrip.FitImage")));
            this.viewToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.viewToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.viewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.viewToolStrip.Location = new System.Drawing.Point(446, 54);
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
            // toolStripEx1
            // 
            this.toolStripEx1.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.FrameColor = System.Drawing.Color.DarkGray;
            this.toolStripEx1.GeneralFrame = true;
            this.toolStripEx1.IconLocation = new System.Drawing.Point(0, 8);
            this.toolStripEx1.ItemBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.toolStripEx1.ItemFrame = true;
            this.toolStripEx1.ItemLocation = new System.Drawing.Point(4, 4);
            this.toolStripEx1.ItemPressColor = System.Drawing.Color.Black;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripButton13});
            this.toolStripEx1.ItemSelectColor = System.Drawing.Color.Gray;
            this.toolStripEx1.Location = new System.Drawing.Point(3, 54);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(349, 54);
            this.toolStripEx1.SplitButtonClickWidth = 16;
            this.toolStripEx1.SplitButtonHeight = 34;
            this.toolStripEx1.SplitButtonTriangleSize = 6;
            this.toolStripEx1.TabIndex = 6;
            this.toolStripEx1.Text = "Вид";
            this.toolStripEx1.TextBoxFrame = true;
            this.toolStripEx1.TextBoxHeight = 14;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AutoSize = false;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.AutoSize = false;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton9.Text = "toolStripButton9";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.AutoSize = false;
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton10.Text = "toolStripButton10";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.AutoSize = false;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton11.Text = "toolStripButton11";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.AutoSize = false;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton12.Text = "toolStripButton12";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.AutoSize = false;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(34, 51);
            this.toolStripButton13.Text = "toolStripButton13";
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.selectToolStrip.ResumeLayout(false);
            this.selectToolStrip.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
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
        private ToolStripEx selectToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton spb_Select;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
    }
}
