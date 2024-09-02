using BaseModule;

namespace BaseModule
{
    partial class ToolStripPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolStripPage));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.selectToolStrip = new UserControlsEx.ToolStripEx();
            this.spbSelectObject = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSelectNodes = new System.Windows.Forms.ToolStripButton();
            this.btnSelectElements = new System.Windows.Forms.ToolStripButton();
            this.btnSelectObjects = new System.Windows.Forms.ToolStripButton();
            this.btnAdvanceSelection = new System.Windows.Forms.ToolStripButton();
            this.instrumentalToolStrip = new UserControlsEx.ToolStripEx();
            this.btnMeasuring = new System.Windows.Forms.ToolStripButton();
            this.btnCrossSection = new System.Windows.Forms.ToolStripButton();
            this.btnScreenShot = new System.Windows.Forms.ToolStripButton();
            this.viewToolStrip = new UserControlsEx.ToolStripEx();
            this.btnSetXY = new System.Windows.Forms.ToolStripButton();
            this.btnSetZX = new System.Windows.Forms.ToolStripButton();
            this.btnSetZY = new System.Windows.Forms.ToolStripButton();
            this.btnSetRotX = new System.Windows.Forms.ToolStripButton();
            this.btnSetRotY = new System.Windows.Forms.ToolStripButton();
            this.btnSetRotZ = new System.Windows.Forms.ToolStripButton();
            this.btnSetRotHor90 = new System.Windows.Forms.ToolStripButton();
            this.btnSetRotVer90 = new System.Windows.Forms.ToolStripButton();
            this.btnFitObjs = new System.Windows.Forms.ToolStripButton();
            this.displayToolStrip = new UserControlsEx.ToolStripEx();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnShowOpenSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaceAndRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowBasis = new System.Windows.Forms.ToolStripButton();
            this.btnShowNormals = new System.Windows.Forms.ToolStripButton();
            this.btnShowCountours = new System.Windows.Forms.ToolStripButton();
            this.basePage = new BaseModule.BasePage();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.selectToolStrip.SuspendLayout();
            this.instrumentalToolStrip.SuspendLayout();
            this.viewToolStrip.SuspendLayout();
            this.displayToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.basePage);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1149, 583);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(5, 5);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1149, 639);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentalToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 80);
            // 
            // selectToolStrip
            // 
            this.selectToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.selectToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.selectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.selectToolStrip.GeneralFrame = true;
            this.selectToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.selectToolStrip.IconLocation = new System.Drawing.Point(0, 4);
            this.selectToolStrip.ImageRectangleSize = new System.Drawing.Point(26, 26);
            this.selectToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.selectToolStrip.ItemFrame = true;
            this.selectToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.selectToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.selectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spbSelectObject,
            this.btnSelectNodes,
            this.btnSelectElements,
            this.btnSelectObjects,
            this.btnAdvanceSelection});
            this.selectToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.selectToolStrip.Location = new System.Drawing.Point(3, 0);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.selectToolStrip.Size = new System.Drawing.Size(298, 56);
            this.selectToolStrip.SplitButtonClickWidth = 16;
            this.selectToolStrip.SplitButtonHeight = 36;
            this.selectToolStrip.SplitButtonTriangleSize = 7;
            this.selectToolStrip.TabIndex = 6;
            this.selectToolStrip.Text = "Выбор";
            this.selectToolStrip.TextBoxFrame = false;
            this.selectToolStrip.TextBoxHeight = 14;
            // 
            // spbSelectObject
            // 
            this.spbSelectObject.AutoSize = false;
            this.spbSelectObject.BackColor = System.Drawing.SystemColors.Control;
            this.spbSelectObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.spbSelectObject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.spbSelectObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spbSelectObject.Name = "spbSelectObject";
            this.spbSelectObject.Size = new System.Drawing.Size(150, 53);
            this.spbSelectObject.Tag = "0";
            this.spbSelectObject.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.spb_Select_DropDownItemClicked);
            // 
            // btnSelectNodes
            // 
            this.btnSelectNodes.AutoSize = false;
            this.btnSelectNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectNodes.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNodes.Image")));
            this.btnSelectNodes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectNodes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectNodes.Name = "btnSelectNodes";
            this.btnSelectNodes.Size = new System.Drawing.Size(36, 53);
            this.btnSelectNodes.Tag = "1";
            this.btnSelectNodes.Text = "toolStripButton2";
            this.btnSelectNodes.ToolTipText = "Выбор узлов";
            this.btnSelectNodes.Click += new System.EventHandler(this.btnSelectObjects_Click);
            // 
            // btnSelectElements
            // 
            this.btnSelectElements.AutoSize = false;
            this.btnSelectElements.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectElements.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectElements.Image")));
            this.btnSelectElements.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectElements.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectElements.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectElements.Name = "btnSelectElements";
            this.btnSelectElements.Size = new System.Drawing.Size(36, 53);
            this.btnSelectElements.Tag = "2";
            this.btnSelectElements.Text = "toolStripButton3";
            this.btnSelectElements.ToolTipText = "Выбор элементов";
            this.btnSelectElements.Click += new System.EventHandler(this.btnSelectObjects_Click);
            // 
            // btnSelectObjects
            // 
            this.btnSelectObjects.AutoSize = false;
            this.btnSelectObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectObjects.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectObjects.Image")));
            this.btnSelectObjects.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectObjects.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectObjects.Name = "btnSelectObjects";
            this.btnSelectObjects.Size = new System.Drawing.Size(36, 53);
            this.btnSelectObjects.Tag = "3";
            this.btnSelectObjects.Text = "toolStripButton4";
            this.btnSelectObjects.ToolTipText = "Выбор геометрии";
            this.btnSelectObjects.Click += new System.EventHandler(this.btnSelectObjects_Click);
            // 
            // btnAdvanceSelection
            // 
            this.btnAdvanceSelection.AutoSize = false;
            this.btnAdvanceSelection.CheckOnClick = true;
            this.btnAdvanceSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdvanceSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnAdvanceSelection.Image")));
            this.btnAdvanceSelection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdvanceSelection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdvanceSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdvanceSelection.Name = "btnAdvanceSelection";
            this.btnAdvanceSelection.Size = new System.Drawing.Size(36, 53);
            this.btnAdvanceSelection.Tag = "4";
            this.btnAdvanceSelection.Text = "toolStripButton1";
            this.btnAdvanceSelection.Click += new System.EventHandler(this.btnAdvanceSelection_Click);
            // 
            // instrumentalToolStrip
            // 
            this.instrumentalToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.instrumentalToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.instrumentalToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.instrumentalToolStrip.GeneralFrame = true;
            this.instrumentalToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.instrumentalToolStrip.IconLocation = new System.Drawing.Point(1, 6);
            this.instrumentalToolStrip.ImageRectangleSize = new System.Drawing.Point(26, 20);
            this.instrumentalToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.instrumentalToolStrip.ItemFrame = true;
            this.instrumentalToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.instrumentalToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.instrumentalToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMeasuring,
            this.btnCrossSection,
            this.btnScreenShot});
            this.instrumentalToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.instrumentalToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.instrumentalToolStrip.Location = new System.Drawing.Point(301, 0);
            this.instrumentalToolStrip.Name = "instrumentalToolStrip";
            this.instrumentalToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.instrumentalToolStrip.Size = new System.Drawing.Size(112, 56);
            this.instrumentalToolStrip.SplitButtonClickWidth = 16;
            this.instrumentalToolStrip.SplitButtonHeight = 34;
            this.instrumentalToolStrip.SplitButtonTriangleSize = 6;
            this.instrumentalToolStrip.TabIndex = 11;
            this.instrumentalToolStrip.Text = "Инструменты";
            this.instrumentalToolStrip.TextBoxFrame = false;
            this.instrumentalToolStrip.TextBoxHeight = 14;
            // 
            // btnMeasuring
            // 
            this.btnMeasuring.AutoSize = false;
            this.btnMeasuring.CheckOnClick = true;
            this.btnMeasuring.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMeasuring.Image = ((System.Drawing.Image)(resources.GetObject("btnMeasuring.Image")));
            this.btnMeasuring.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMeasuring.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMeasuring.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMeasuring.Name = "btnMeasuring";
            this.btnMeasuring.Size = new System.Drawing.Size(36, 53);
            this.btnMeasuring.Tag = "0";
            this.btnMeasuring.Text = "toolStripButton14";
            this.btnMeasuring.Click += new System.EventHandler(this.btnMeasuring_Click);
            // 
            // btnCrossSection
            // 
            this.btnCrossSection.AutoSize = false;
            this.btnCrossSection.CheckOnClick = true;
            this.btnCrossSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCrossSection.Image = ((System.Drawing.Image)(resources.GetObject("btnCrossSection.Image")));
            this.btnCrossSection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrossSection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCrossSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrossSection.Name = "btnCrossSection";
            this.btnCrossSection.Size = new System.Drawing.Size(36, 53);
            this.btnCrossSection.Tag = "1";
            this.btnCrossSection.Text = "toolStripButton15";
            this.btnCrossSection.Click += new System.EventHandler(this.btnCrossSection_Click);
            // 
            // btnScreenShot
            // 
            this.btnScreenShot.AutoSize = false;
            this.btnScreenShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("btnScreenShot.Image")));
            this.btnScreenShot.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScreenShot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScreenShot.Name = "btnScreenShot";
            this.btnScreenShot.Size = new System.Drawing.Size(36, 53);
            this.btnScreenShot.Tag = "2";
            this.btnScreenShot.Text = "toolStripButton16";
            this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.viewToolStrip.GeneralFrame = true;
            this.viewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.viewToolStrip.IconLocation = new System.Drawing.Point(0, 4);
            this.viewToolStrip.ImageRectangleSize = new System.Drawing.Point(26, 26);
            this.viewToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.viewToolStrip.ItemFrame = true;
            this.viewToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.viewToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetXY,
            this.btnSetZX,
            this.btnSetZY,
            this.btnSetRotX,
            this.btnSetRotY,
            this.btnSetRotZ,
            this.btnSetRotHor90,
            this.btnSetRotVer90,
            this.btnFitObjs});
            this.viewToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.viewToolStrip.Location = new System.Drawing.Point(413, 0);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.viewToolStrip.Size = new System.Drawing.Size(328, 56);
            this.viewToolStrip.SplitButtonClickWidth = 16;
            this.viewToolStrip.SplitButtonHeight = 34;
            this.viewToolStrip.SplitButtonTriangleSize = 6;
            this.viewToolStrip.TabIndex = 10;
            this.viewToolStrip.Text = "Вид";
            this.viewToolStrip.TextBoxFrame = false;
            this.viewToolStrip.TextBoxHeight = 14;
            this.viewToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewToolStrip_ItemClicked);
            // 
            // btnSetXY
            // 
            this.btnSetXY.AutoSize = false;
            this.btnSetXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetXY.Image = ((System.Drawing.Image)(resources.GetObject("btnSetXY.Image")));
            this.btnSetXY.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetXY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetXY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetXY.Name = "btnSetXY";
            this.btnSetXY.Size = new System.Drawing.Size(36, 53);
            this.btnSetXY.Tag = "0";
            this.btnSetXY.Text = "toolStripButton5";
            // 
            // btnSetZX
            // 
            this.btnSetZX.AutoSize = false;
            this.btnSetZX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetZX.Image = ((System.Drawing.Image)(resources.GetObject("btnSetZX.Image")));
            this.btnSetZX.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetZX.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetZX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetZX.Name = "btnSetZX";
            this.btnSetZX.Size = new System.Drawing.Size(36, 53);
            this.btnSetZX.Tag = "1";
            this.btnSetZX.Text = "toolStripButton6";
            // 
            // btnSetZY
            // 
            this.btnSetZY.AutoSize = false;
            this.btnSetZY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetZY.Image = ((System.Drawing.Image)(resources.GetObject("btnSetZY.Image")));
            this.btnSetZY.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetZY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetZY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetZY.Name = "btnSetZY";
            this.btnSetZY.Size = new System.Drawing.Size(36, 53);
            this.btnSetZY.Tag = "2";
            this.btnSetZY.Text = "toolStripButton7";
            // 
            // btnSetRotX
            // 
            this.btnSetRotX.AutoSize = false;
            this.btnSetRotX.CheckOnClick = true;
            this.btnSetRotX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetRotX.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRotX.Image")));
            this.btnSetRotX.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetRotX.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetRotX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetRotX.Name = "btnSetRotX";
            this.btnSetRotX.Size = new System.Drawing.Size(36, 53);
            this.btnSetRotX.Tag = "3";
            this.btnSetRotX.Text = "toolStripButton8";
            this.btnSetRotX.Click += new System.EventHandler(this.btnSetRotAxis_Click);
            // 
            // btnSetRotY
            // 
            this.btnSetRotY.AutoSize = false;
            this.btnSetRotY.CheckOnClick = true;
            this.btnSetRotY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetRotY.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRotY.Image")));
            this.btnSetRotY.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetRotY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetRotY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetRotY.Name = "btnSetRotY";
            this.btnSetRotY.Size = new System.Drawing.Size(36, 53);
            this.btnSetRotY.Tag = "4";
            this.btnSetRotY.Text = "toolStripButton9";
            this.btnSetRotY.Click += new System.EventHandler(this.btnSetRotAxis_Click);
            // 
            // btnSetRotZ
            // 
            this.btnSetRotZ.AutoSize = false;
            this.btnSetRotZ.CheckOnClick = true;
            this.btnSetRotZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetRotZ.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRotZ.Image")));
            this.btnSetRotZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetRotZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetRotZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetRotZ.Name = "btnSetRotZ";
            this.btnSetRotZ.Size = new System.Drawing.Size(36, 53);
            this.btnSetRotZ.Tag = "5";
            this.btnSetRotZ.Text = "toolStripButton10";
            this.btnSetRotZ.Click += new System.EventHandler(this.btnSetRotAxis_Click);
            // 
            // btnSetRotHor90
            // 
            this.btnSetRotHor90.AutoSize = false;
            this.btnSetRotHor90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetRotHor90.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRotHor90.Image")));
            this.btnSetRotHor90.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetRotHor90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetRotHor90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetRotHor90.Name = "btnSetRotHor90";
            this.btnSetRotHor90.Size = new System.Drawing.Size(36, 53);
            this.btnSetRotHor90.Tag = "6";
            this.btnSetRotHor90.Text = "toolStripButton11";
            // 
            // btnSetRotVer90
            // 
            this.btnSetRotVer90.AutoSize = false;
            this.btnSetRotVer90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetRotVer90.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRotVer90.Image")));
            this.btnSetRotVer90.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetRotVer90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetRotVer90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetRotVer90.Name = "btnSetRotVer90";
            this.btnSetRotVer90.Size = new System.Drawing.Size(36, 53);
            this.btnSetRotVer90.Tag = "7";
            this.btnSetRotVer90.Text = "toolStripButton12";
            // 
            // btnFitObjs
            // 
            this.btnFitObjs.AutoSize = false;
            this.btnFitObjs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFitObjs.Image = ((System.Drawing.Image)(resources.GetObject("btnFitObjs.Image")));
            this.btnFitObjs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFitObjs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFitObjs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFitObjs.Name = "btnFitObjs";
            this.btnFitObjs.Size = new System.Drawing.Size(36, 53);
            this.btnFitObjs.Tag = "8";
            this.btnFitObjs.Text = "toolStripButton13";
            // 
            // displayToolStrip
            // 
            this.displayToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.displayToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.displayToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.displayToolStrip.GeneralFrame = true;
            this.displayToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.displayToolStrip.IconLocation = new System.Drawing.Point(0, 4);
            this.displayToolStrip.ImageRectangleSize = new System.Drawing.Point(26, 26);
            this.displayToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.displayToolStrip.ItemFrame = true;
            this.displayToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.displayToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.displayToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowAll,
            this.btnShowOpenSurfaces,
            this.btnShowSurfaceAndRibbers,
            this.btnShowRibbers,
            this.btnShowSurfaces,
            this.btnShowBasis,
            this.btnShowNormals,
            this.btnShowCountours});
            this.displayToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.displayToolStrip.Location = new System.Drawing.Point(741, 0);
            this.displayToolStrip.Name = "displayToolStrip";
            this.displayToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.displayToolStrip.Size = new System.Drawing.Size(292, 56);
            this.displayToolStrip.SplitButtonClickWidth = 16;
            this.displayToolStrip.SplitButtonHeight = 34;
            this.displayToolStrip.SplitButtonTriangleSize = 6;
            this.displayToolStrip.TabIndex = 9;
            this.displayToolStrip.Text = "Отображение";
            this.displayToolStrip.TextBoxFrame = false;
            this.displayToolStrip.TextBoxHeight = 14;
            this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStrip_ItemClick);
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = false;
            this.btnShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(36, 53);
            this.btnShowAll.Tag = "0";
            this.btnShowAll.Text = "toolStripButton17";
            // 
            // btnShowOpenSurfaces
            // 
            this.btnShowOpenSurfaces.AutoSize = false;
            this.btnShowOpenSurfaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowOpenSurfaces.Image = ((System.Drawing.Image)(resources.GetObject("btnShowOpenSurfaces.Image")));
            this.btnShowOpenSurfaces.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowOpenSurfaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowOpenSurfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowOpenSurfaces.Name = "btnShowOpenSurfaces";
            this.btnShowOpenSurfaces.Size = new System.Drawing.Size(36, 53);
            this.btnShowOpenSurfaces.Tag = "1";
            this.btnShowOpenSurfaces.Text = "toolStripButton18";
            // 
            // btnShowSurfaceAndRibbers
            // 
            this.btnShowSurfaceAndRibbers.AutoSize = false;
            this.btnShowSurfaceAndRibbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowSurfaceAndRibbers.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSurfaceAndRibbers.Image")));
            this.btnShowSurfaceAndRibbers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowSurfaceAndRibbers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowSurfaceAndRibbers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowSurfaceAndRibbers.Name = "btnShowSurfaceAndRibbers";
            this.btnShowSurfaceAndRibbers.Size = new System.Drawing.Size(36, 53);
            this.btnShowSurfaceAndRibbers.Tag = "2";
            this.btnShowSurfaceAndRibbers.Text = "toolStripButton19";
            this.btnShowSurfaceAndRibbers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnShowRibbers
            // 
            this.btnShowRibbers.AutoSize = false;
            this.btnShowRibbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowRibbers.Image = ((System.Drawing.Image)(resources.GetObject("btnShowRibbers.Image")));
            this.btnShowRibbers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowRibbers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowRibbers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowRibbers.Name = "btnShowRibbers";
            this.btnShowRibbers.Size = new System.Drawing.Size(36, 53);
            this.btnShowRibbers.Tag = "3";
            this.btnShowRibbers.Text = "toolStripButton20";
            // 
            // btnShowSurfaces
            // 
            this.btnShowSurfaces.AutoSize = false;
            this.btnShowSurfaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowSurfaces.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSurfaces.Image")));
            this.btnShowSurfaces.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowSurfaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowSurfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowSurfaces.Name = "btnShowSurfaces";
            this.btnShowSurfaces.Size = new System.Drawing.Size(36, 53);
            this.btnShowSurfaces.Tag = "4";
            this.btnShowSurfaces.Text = "toolStripButton21";
            // 
            // btnShowBasis
            // 
            this.btnShowBasis.AutoSize = false;
            this.btnShowBasis.Checked = true;
            this.btnShowBasis.CheckOnClick = true;
            this.btnShowBasis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowBasis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowBasis.Image = ((System.Drawing.Image)(resources.GetObject("btnShowBasis.Image")));
            this.btnShowBasis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowBasis.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowBasis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowBasis.Name = "btnShowBasis";
            this.btnShowBasis.Size = new System.Drawing.Size(36, 53);
            this.btnShowBasis.Tag = "5";
            this.btnShowBasis.Text = "toolStripButton22";
            this.btnShowBasis.Click += new System.EventHandler(this.btnShowBasis_Click);
            // 
            // btnShowNormals
            // 
            this.btnShowNormals.AutoSize = false;
            this.btnShowNormals.CheckOnClick = true;
            this.btnShowNormals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowNormals.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNormals.Image")));
            this.btnShowNormals.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowNormals.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowNormals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowNormals.Name = "btnShowNormals";
            this.btnShowNormals.Size = new System.Drawing.Size(36, 53);
            this.btnShowNormals.Tag = "6";
            this.btnShowNormals.Text = "toolStripButton23";
            this.btnShowNormals.Click += new System.EventHandler(this.btnShowNormals_Click);
            // 
            // btnShowCountours
            // 
            this.btnShowCountours.AutoSize = false;
            this.btnShowCountours.CheckOnClick = true;
            this.btnShowCountours.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowCountours.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCountours.Image")));
            this.btnShowCountours.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowCountours.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowCountours.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowCountours.Name = "btnShowCountours";
            this.btnShowCountours.Size = new System.Drawing.Size(36, 53);
            this.btnShowCountours.Tag = "7";
            this.btnShowCountours.Text = "toolStripButton24";
            this.btnShowCountours.Click += new System.EventHandler(this.btnShowCountours_Click);
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
            this.basePage.Size = new System.Drawing.Size(1149, 583);
            this.basePage.SplitterWidthEx = 10;
            this.basePage.TabIndex = 0;
            this.basePage.DeleteGroupEvent += new System.Action(this.basePage_DeleteGroupEvent);
            this.basePage.DeleteAllGroupsEvent += new System.Action(this.basePage_DeleteAllGroupsEvent);
            this.basePage.DeleteObjectsEvent += new System.Action(this.basePage_DeleteObjectsEvent);
            this.basePage.DeleteSelectedObjectsEvent += new System.Action(this.basePage_DeleteSelectedObjectsEvent);
            this.basePage.CreatedMeshGroupEvent += new System.Action(this.basePage_CreatedMeshGroupEvent);
            this.basePage.ChangedGroupNameEvent += new System.Action(this.basePage_ChangedGroupNameEvent);
            // 
            // ToolStripPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "ToolStripPage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1159, 649);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.selectToolStrip.ResumeLayout(false);
            this.selectToolStrip.PerformLayout();
            this.instrumentalToolStrip.ResumeLayout(false);
            this.instrumentalToolStrip.PerformLayout();
            this.viewToolStrip.ResumeLayout(false);
            this.viewToolStrip.PerformLayout();
            this.displayToolStrip.ResumeLayout(false);
            this.displayToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        protected System.Windows.Forms.ToolStripSplitButton spbSelectObject;
        protected System.Windows.Forms.ToolStripButton btnSelectNodes;
        protected System.Windows.Forms.ToolStripButton btnSelectElements;
        protected System.Windows.Forms.ToolStripButton btnSelectObjects;
        protected System.Windows.Forms.ToolStripButton btnAdvanceSelection;
        protected System.Windows.Forms.ToolStripButton btnShowAll;
        protected System.Windows.Forms.ToolStripButton btnShowOpenSurfaces;
        protected System.Windows.Forms.ToolStripButton btnShowSurfaceAndRibbers;
        protected System.Windows.Forms.ToolStripButton btnShowRibbers;
        protected System.Windows.Forms.ToolStripButton btnShowSurfaces;
        protected System.Windows.Forms.ToolStripButton btnShowBasis;
        protected System.Windows.Forms.ToolStripButton btnShowNormals;
        protected System.Windows.Forms.ToolStripButton btnShowCountours;
        protected System.Windows.Forms.ToolStripButton btnSetXY;
        protected System.Windows.Forms.ToolStripButton btnSetZX;
        protected System.Windows.Forms.ToolStripButton btnSetZY;
        protected System.Windows.Forms.ToolStripButton btnSetRotX;
        protected System.Windows.Forms.ToolStripButton btnSetRotY;
        protected System.Windows.Forms.ToolStripButton btnSetRotZ;
        protected System.Windows.Forms.ToolStripButton btnSetRotHor90;
        protected System.Windows.Forms.ToolStripButton btnSetRotVer90;
        protected System.Windows.Forms.ToolStripButton btnFitObjs;
        protected System.Windows.Forms.ToolStripButton btnMeasuring;
        protected System.Windows.Forms.ToolStripButton btnCrossSection;
        protected System.Windows.Forms.ToolStripButton btnScreenShot;
        public UserControlsEx.ToolStripEx selectToolStrip;
        public UserControlsEx.ToolStripEx instrumentalToolStrip;
        public UserControlsEx.ToolStripEx displayToolStrip;
        public UserControlsEx.ToolStripEx viewToolStrip;
        protected BasePage basePage;
        //private BasePage basePage;
    }
}
