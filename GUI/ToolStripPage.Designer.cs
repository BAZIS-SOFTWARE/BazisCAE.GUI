using BaseModule;
using BaseModule.Navigator;

namespace BazisGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolStripPage));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.embeddedSplitContainer = new UserControlsEx.SplitContainerEx();
            this.basePageSplitContainer = new UserControlsEx.SplitContainerEx();
            this.splitContainerEx2 = new UserControlsEx.SplitContainerEx();
            this.navigator = new BaseModule.Navigator.NavigatorControl();
            this.propertiesPanelControl = new BaseModule.PropertiesPanel.PropertiesPanelControl();
            this.splitContainerEx3 = new UserControlsEx.SplitContainerEx();
            this.scenePage = new BazisGUI.ScenePage();
            this.consoleControl = new BaseModule.Console.ConsoleControl();
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
            this.btnReflect = new System.Windows.Forms.ToolStripButton();
            this.btnClipPlane = new System.Windows.Forms.ToolStripButton();
            this.displayToolStrip = new UserControlsEx.ToolStripEx();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnShowOpenSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaceAndRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowBasis = new System.Windows.Forms.ToolStripButton();
            this.btnShowNormals = new System.Windows.Forms.ToolStripButton();
            this.btnShowCountours = new System.Windows.Forms.ToolStripButton();
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
            this.condsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagram_gantt_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закреплениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.низкийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.высокийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьИнструкцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.embeddedSplitContainer)).BeginInit();
            this.embeddedSplitContainer.Panel1.SuspendLayout();
            this.embeddedSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basePageSplitContainer)).BeginInit();
            this.basePageSplitContainer.Panel1.SuspendLayout();
            this.basePageSplitContainer.Panel2.SuspendLayout();
            this.basePageSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx2)).BeginInit();
            this.splitContainerEx2.Panel1.SuspendLayout();
            this.splitContainerEx2.Panel2.SuspendLayout();
            this.splitContainerEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx3)).BeginInit();
            this.splitContainerEx3.Panel1.SuspendLayout();
            this.splitContainerEx3.Panel2.SuspendLayout();
            this.splitContainerEx3.SuspendLayout();
            this.selectToolStrip.SuspendLayout();
            this.instrumentalToolStrip.SuspendLayout();
            this.displayToolStrip.SuspendLayout();
            this.viewToolStrip.SuspendLayout();
            this.condsMenuStrip.SuspendLayout();
            this.tasksMenuStrip.SuspendLayout();
            this.resultsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.embeddedSplitContainer);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1155, 556);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(5, 5);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1155, 612);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentalToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 80);
            // 
            // embeddedSplitContainer
            // 
            this.embeddedSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.embeddedSplitContainer.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.embeddedSplitContainer.IncrementShifting = 50;
            this.embeddedSplitContainer.Location = new System.Drawing.Point(0, 5);
            this.embeddedSplitContainer.Name = "embeddedSplitContainer";
            // 
            // embeddedSplitContainer.Panel1
            // 
            this.embeddedSplitContainer.Panel1.Controls.Add(this.basePageSplitContainer);
            // 
            // embeddedSplitContainer.Panel2
            // 
            this.embeddedSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.embeddedSplitContainer.Panel2Collapsed = true;
            this.embeddedSplitContainer.Size = new System.Drawing.Size(1155, 551);
            this.embeddedSplitContainer.SplitterDistance = 621;
            this.embeddedSplitContainer.SwitchShifting = true;
            this.embeddedSplitContainer.TabIndex = 3;
            // 
            // basePageSplitContainer
            // 
            this.basePageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePageSplitContainer.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.basePageSplitContainer.IncrementShifting = 50;
            this.basePageSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.basePageSplitContainer.Name = "basePageSplitContainer";
            // 
            // basePageSplitContainer.Panel1
            // 
            this.basePageSplitContainer.Panel1.Controls.Add(this.splitContainerEx2);
            // 
            // basePageSplitContainer.Panel2
            // 
            this.basePageSplitContainer.Panel2.Controls.Add(this.splitContainerEx3);
            this.basePageSplitContainer.Size = new System.Drawing.Size(1155, 551);
            this.basePageSplitContainer.SplitterDistance = 398;
            this.basePageSplitContainer.SplitterWidth = 8;
            this.basePageSplitContainer.SwitchShifting = false;
            this.basePageSplitContainer.TabIndex = 0;
            // 
            // splitContainerEx2
            // 
            this.splitContainerEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEx2.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainerEx2.IncrementShifting = 50;
            this.splitContainerEx2.IsSplitterFixed = true;
            this.splitContainerEx2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEx2.Name = "splitContainerEx2";
            this.splitContainerEx2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEx2.Panel1
            // 
            this.splitContainerEx2.Panel1.Controls.Add(this.navigator);
            // 
            // splitContainerEx2.Panel2
            // 
            this.splitContainerEx2.Panel2.Controls.Add(this.propertiesPanelControl);
            this.splitContainerEx2.Size = new System.Drawing.Size(398, 551);
            this.splitContainerEx2.SplitterDistance = 396;
            this.splitContainerEx2.SplitterWidth = 8;
            this.splitContainerEx2.SwitchShifting = false;
            this.splitContainerEx2.TabIndex = 0;
            // 
            // navigator
            // 
            this.navigator.BackColor = System.Drawing.Color.Gainsboro;
            this.navigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigator.CollapseIndex = 1;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.DownColor = System.Drawing.Color.Gainsboro;
            this.navigator.ExpandIndex = 2;
            this.navigator.HeaderColor = System.Drawing.Color.Black;
            this.navigator.HeaderName = "Навигатор";
            this.navigator.IsPinndable = false;
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.navigator.Name = "navigator";
            this.navigator.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(398, 396);
            this.navigator.TabIndex = 0;
            this.navigator.UpColor = System.Drawing.Color.Gainsboro;
            //this.navigator.DelGroupEvent += new System.Action<int>(this.navigator_DelGroupEvent);
            //this.navigator.DelAllGroupsEvent += new System.Action(this.navigator_DelAllGroupsEvent);
            //this.navigator.HideGroupEvent += new System.Action<int>(this.navigator_HideGroupEvent);
            //this.navigator.ShowGroupEvent += new System.Action<int>(this.navigator_ShowGroupEvent);
            //this.navigator.EditGroupEvent += new System.Action<int>(this.navigator_EditGroupEvent);
            //this.navigator.InfoGroupEvent += new System.Action<int>(this.navigator_InfoGroupEvent);
            //this.navigator.ShowGroupWithNodesEvent += new System.Action<int>(this.navigator_ShowGroupWithNodesEvent);
            //this.navigator.ShowAllGroupsEvent += new System.Action(this.navigator_ShowAllGroupsEvent);
            //this.navigator.HideAllGroupsEvent += new System.Action(this.navigator_HideAllGroupsEvent);
            //this.navigator.ShowAllObjectsEvent += new System.Action(this.navigator_ShowAllObjectsEvent);
            //this.navigator.HideAllObjectsEvent += new System.Action(this.navigator_HideAllObjectsEvent);
            //this.navigator.DelAllObjectsEvent += new System.Action(this.navigator_DelAllObjectsEvent);
            //this.navigator.ShowSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_ShowSetEvent);
            //this.navigator.ChangeSetViewEvent += new System.Action<string, BaseModule.Navigator.ViewRegime>(this.navigator_ChangeSetViewEvent);
            //this.navigator.HideSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_HideSetEvent);
            //this.navigator.DelSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_DelSetEvent);
            //this.navigator.SelectSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectSetEvent);
            //this.navigator.SelectGroupEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectGroupEvent);
            //this.navigator.SelectObjectEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectObjectEvent);
            //this.navigator.SelectCondEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectCondEvent);
            //this.navigator.SelectTaskEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectTaskEvent);
            //this.navigator.SelectGeneralInfoEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectGeneralInfoEvent);
            //this.navigator.SelectTimeEvent += new System.Action<string, double>(this.navigator_SelectTimeEvent);
            //this.navigator.GetObjectsInfoEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_GetObjectsInfoEvent);
            //this.navigator.GetSetsInfoEvent += new System.Action<BaseModule.Navigator.NodeType>(this.navigator_GetSetsInfoEvent);
            //this.navigator.GetResultInfoEvent += new System.Action<string>(this.navigator_GetResultInfoEvent);
            //this.navigator.ControlCollapseEvent += new System.Action(this.navigator_ControlCollapseEvent);
            //this.navigator.ControlUnpinnedEvent += new System.Action(this.navigator_ControlUnpinnedEvent);
            // 
            // propertiesPanelControl
            // 
            this.propertiesPanelControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propertiesPanelControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.propertiesPanelControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertiesPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesPanelControl.DownColor = System.Drawing.Color.WhiteSmoke;
            this.propertiesPanelControl.HeaderName = "Свойства";
            this.propertiesPanelControl.Location = new System.Drawing.Point(0, 0);
            this.propertiesPanelControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.propertiesPanelControl.Name = "propertiesPanelControl";
            this.propertiesPanelControl.Size = new System.Drawing.Size(398, 147);
            this.propertiesPanelControl.TabIndex = 0;
            this.propertiesPanelControl.UpColor = System.Drawing.Color.Silver;
            //this.propertiesPanelControl.OnPropertyUpdate += new System.Action<BaseModule.PropertiesPanel.PropertyChangedEventArgs>(this.propertiesPanelControl_OnPropertyUpdate);
            this.propertiesPanelControl.ControlCollapseEvent += new System.Action(this.propertiesPanelControl_ControlCollapseEvent);
            // 
            // splitContainerEx3
            // 
            this.splitContainerEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEx3.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainerEx3.IncrementShifting = 50;
            this.splitContainerEx3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEx3.Name = "splitContainerEx3";
            this.splitContainerEx3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEx3.Panel1
            // 
            this.splitContainerEx3.Panel1.Controls.Add(this.scenePage);
            // 
            // splitContainerEx3.Panel2
            // 
            this.splitContainerEx3.Panel2.Controls.Add(this.consoleControl);
            this.splitContainerEx3.Size = new System.Drawing.Size(749, 551);
            this.splitContainerEx3.SplitterDistance = 435;
            this.splitContainerEx3.SplitterWidth = 8;
            this.splitContainerEx3.SwitchShifting = false;
            this.splitContainerEx3.TabIndex = 0;
            // 
            // scenePage
            // 
            this.scenePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePage.Location = new System.Drawing.Point(0, 0);
            this.scenePage.Name = "scenePage";
            this.scenePage.ShowInsideObjects = false;
            this.scenePage.Size = new System.Drawing.Size(749, 435);
            this.scenePage.TabIndex = 0;
            this.scenePage.TransparencyValue = 0;
            //this.scenePage.MeshGroupCreatedEvent += new System.Action<object>(this.scenePage_MeshGroupCreatedEvent);
            //this.scenePage.SceneInfoEvent += new System.Action<object, string, System.Drawing.Color>(this.scenePage_SceneInfoEvent);
            //this.scenePage.ShowAllObjectsEvent += new System.Action<object>(this.scenePage_ShowAllObjectsEvent);
            //this.scenePage.SelectionDeletedEvent += new System.Action<object>(this.scenePage_SelectionDeletedEvent);
            //this.scenePage.SelectObjectsEvent += new System.Action<object, Scene.Events.SelectObjectsEventArgs>(this.scenePage_SelectObjectsEvent);
            //this.scenePage.HideSelectedObjects += new System.Action<object>(this.scenePage_HideSelectedObjects);
            //this.scenePage.SceneExpandEvent += new System.Action(this.scenePage_SceneExpandEvent);
            //this.scenePage.SceneFoldEvent += new System.Action(this.scenePage_SceneFoldEvent);
            //this.scenePage.SetBackColorToAllObjectsEvent += new System.Action<object>(this.scenePage_SetBackColorToAllObjectsEvent);
            // 
            // consoleControl
            // 
            this.consoleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.consoleControl.CheckPrintElemsInfo = false;
            this.consoleControl.CheckPrintNodesInfo = false;
            this.consoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl.DownColor = System.Drawing.Color.WhiteSmoke;
            this.consoleControl.HeaderName = "Консоль";
            this.consoleControl.Location = new System.Drawing.Point(0, 0);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(749, 108);
            this.consoleControl.TabIndex = 0;
            this.consoleControl.UpColor = System.Drawing.Color.Silver;
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
            //this.spbSelectObject.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.spb_Select_DropDownItemClicked);
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
            //this.btnSelectNodes.Click += new System.EventHandler(this.btnSelectObjects_Click);
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
            //this.btnSelectElements.Click += new System.EventHandler(this.btnSelectObjects_Click);
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
            //this.btnSelectObjects.Click += new System.EventHandler(this.btnSelectObjects_Click);
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
            this.btnAdvanceSelection.ToolTipText = "Дополненный выбор";
            //this.btnAdvanceSelection.Click += new System.EventHandler(this.btnAdvanceSelection_Click);
            // 
            // instrumentalToolStrip
            // 
            this.instrumentalToolStrip.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnScreenShot,
            this.btnReflect,
            this.btnClipPlane});
            this.instrumentalToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.instrumentalToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.instrumentalToolStrip.Location = new System.Drawing.Point(301, 0);
            this.instrumentalToolStrip.Name = "instrumentalToolStrip";
            this.instrumentalToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.instrumentalToolStrip.Size = new System.Drawing.Size(184, 56);
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
            this.btnMeasuring.ToolTipText = "Измерить";
            //this.btnMeasuring.Click += new System.EventHandler(this.btnMeasuring_Click);
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
            this.btnCrossSection.ToolTipText = "Сделать сечение";
            //this.btnCrossSection.Click += new System.EventHandler(this.btnCrossSection_Click);
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
            this.btnScreenShot.ToolTipText = "Снимок экрана";
            //this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
            // 
            // btnReflect
            // 
            this.btnReflect.AutoSize = false;
            this.btnReflect.CheckOnClick = true;
            this.btnReflect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReflect.Image = ((System.Drawing.Image)(resources.GetObject("btnReflect.Image")));
            this.btnReflect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReflect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReflect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReflect.Name = "btnReflect";
            this.btnReflect.Size = new System.Drawing.Size(36, 53);
            this.btnReflect.Text = "btnReflect";
            this.btnReflect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReflect.ToolTipText = "Зеркальное отображение";
            //this.btnReflect.Click += new System.EventHandler(this.btnReflect_Click);
            // 
            // btnClipPlane
            // 
            this.btnClipPlane.AutoSize = false;
            this.btnClipPlane.CheckOnClick = true;
            this.btnClipPlane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClipPlane.Image = ((System.Drawing.Image)(resources.GetObject("btnClipPlane.Image")));
            this.btnClipPlane.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClipPlane.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClipPlane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClipPlane.Name = "btnClipPlane";
            this.btnClipPlane.Size = new System.Drawing.Size(36, 53);
            this.btnClipPlane.Text = "btnClipPlane";
            this.btnClipPlane.ToolTipText = "Скрыть плоскостью";
            //this.btnClipPlane.Click += new System.EventHandler(this.btnClipPlane_Click);
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
            this.displayToolStrip.Location = new System.Drawing.Point(485, 0);
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
            //this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayToolStrip_ItemClick);
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
            this.btnShowAll.ToolTipText = "Показывать все объекты";
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
            this.btnShowOpenSurfaces.ToolTipText = "Показывать только поверхности";
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
            this.btnShowSurfaceAndRibbers.ToolTipText = "Ребра и поверхности";
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
            this.btnShowRibbers.ToolTipText = "Ребра";
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
            this.btnShowSurfaces.ToolTipText = "Поверхности";
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
            this.btnShowBasis.ToolTipText = "Базис СК";
            //this.btnShowBasis.Click += new System.EventHandler(this.btnShowBasis_Click);
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
            this.btnShowNormals.ToolTipText = "Показать нормали";
            //this.btnShowNormals.Click += new System.EventHandler(this.btnShowNormals_Click);
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
            this.btnShowCountours.ToolTipText = "Показать контуры";
            //this.btnShowCountours.Click += new System.EventHandler(this.btnShowCountours_Click);
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
            this.viewToolStrip.Location = new System.Drawing.Point(777, 0);
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
            //this.viewToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewToolStrip_ItemClicked);
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
            this.btnSetXY.ToolTipText = "Плоскость XY";
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
            this.btnSetZX.ToolTipText = "Плоскость ZX";
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
            this.btnSetZY.ToolTipText = "Плоскость ZY";
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
            this.btnSetRotX.ToolTipText = "Вращение  по X";
            //this.btnSetRotX.Click += new System.EventHandler(this.btnSetRotAxis_Click);
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
            this.btnSetRotY.ToolTipText = "Вращение  по Y";
            //this.btnSetRotY.Click += new System.EventHandler(this.btnSetRotAxis_Click);
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
            this.btnSetRotZ.ToolTipText = "Вращение  по Z";
            //this.btnSetRotZ.Click += new System.EventHandler(this.btnSetRotAxis_Click);
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
            this.btnSetRotHor90.ToolTipText = "Поворот по горизонтали";
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
            this.btnSetRotVer90.ToolTipText = "Поворот по вертикали";
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
            this.btnFitObjs.ToolTipText = "Вписать в экран";
            // 
            // condsMenuStrip
            // 
            this.condsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.condsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.diagram_gantt_toolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.condsMenuStrip.Name = "taskMenuStrip";
            this.condsMenuStrip.Size = new System.Drawing.Size(214, 70);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // diagram_gantt_toolStripMenuItem
            // 
            this.diagram_gantt_toolStripMenuItem.Name = "diagram_gantt_toolStripMenuItem";
            this.diagram_gantt_toolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.diagram_gantt_toolStripMenuItem.Text = "Показать на диаграммме";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалToolStripMenuItem,
            this.закреплениеToolStripMenuItem,
            this.нагрузкаToolStripMenuItem,
            this.нагревToolStripMenuItem,
            this.средаToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.материалToolStripMenuItem.Text = "Материал";
            // 
            // закреплениеToolStripMenuItem
            // 
            this.закреплениеToolStripMenuItem.Name = "закреплениеToolStripMenuItem";
            this.закреплениеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.закреплениеToolStripMenuItem.Text = "Закрепление";
            // 
            // нагрузкаToolStripMenuItem
            // 
            this.нагрузкаToolStripMenuItem.Name = "нагрузкаToolStripMenuItem";
            this.нагрузкаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагрузкаToolStripMenuItem.Text = "Нагрузка";
            // 
            // нагревToolStripMenuItem
            // 
            this.нагревToolStripMenuItem.Name = "нагревToolStripMenuItem";
            this.нагревToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагревToolStripMenuItem.Text = "Нагрев";
            // 
            // средаToolStripMenuItem
            // 
            this.средаToolStripMenuItem.Name = "средаToolStripMenuItem";
            this.средаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.средаToolStripMenuItem.Text = "Среда";
            // 
            // tasksMenuStrip
            // 
            this.tasksMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tasksMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.сформироватьИнструкцииToolStripMenuItem,
            this.запуститьРасчетToolStripMenuItem,
            this.остановитьРасчетToolStripMenuItem});
            this.tasksMenuStrip.Name = "taskMenuStrip";
            this.tasksMenuStrip.Size = new System.Drawing.Size(227, 92);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.низкийToolStripMenuItem,
            this.среднийToolStripMenuItem,
            this.высокийToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItem2.Text = "Задать приоритет";
            // 
            // низкийToolStripMenuItem
            // 
            this.низкийToolStripMenuItem.Name = "низкийToolStripMenuItem";
            this.низкийToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.низкийToolStripMenuItem.Text = "Низкий";
            //this.низкийToolStripMenuItem.Click += new System.EventHandler(this.низкийToolStripMenuItem_Click);
            // 
            // среднийToolStripMenuItem
            // 
            this.среднийToolStripMenuItem.Name = "среднийToolStripMenuItem";
            this.среднийToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.среднийToolStripMenuItem.Text = "Средний";
            //this.среднийToolStripMenuItem.Click += new System.EventHandler(this.среднийToolStripMenuItem_Click);
            // 
            // высокийToolStripMenuItem
            // 
            this.высокийToolStripMenuItem.Name = "высокийToolStripMenuItem";
            this.высокийToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.высокийToolStripMenuItem.Text = "Высокий";
            //this.высокийToolStripMenuItem.Click += new System.EventHandler(this.высокийToolStripMenuItem_Click);
            // 
            // сформироватьИнструкцииToolStripMenuItem
            // 
            this.сформироватьИнструкцииToolStripMenuItem.Name = "сформироватьИнструкцииToolStripMenuItem";
            this.сформироватьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.сформироватьИнструкцииToolStripMenuItem.Text = "Сформировать инструкции";
            //this.сформироватьИнструкцииToolStripMenuItem.Click += new System.EventHandler(this.сформироватьИнструкцииToolStripMenuItem_Click);
            // 
            // запуститьРасчетToolStripMenuItem
            // 
            this.запуститьРасчетToolStripMenuItem.Name = "запуститьРасчетToolStripMenuItem";
            this.запуститьРасчетToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.запуститьРасчетToolStripMenuItem.Text = "Запустить расчет";
            //this.запуститьРасчетToolStripMenuItem.Click += new System.EventHandler(this.запуститьРасчетToolStripMenuItem_Click);
            // 
            // остановитьРасчетToolStripMenuItem
            // 
            this.остановитьРасчетToolStripMenuItem.Name = "остановитьРасчетToolStripMenuItem";
            this.остановитьРасчетToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.остановитьРасчетToolStripMenuItem.Text = "Остановить расчет";
            //this.остановитьРасчетToolStripMenuItem.Click += new System.EventHandler(this.остановитьРасчетToolStripMenuItem_Click);
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьToolStripMenuItem,
            this.toolStripMenuItem1});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(119, 48);
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.скрытьToolStripMenuItem.Text = "Скрыть";
            //this.скрытьToolStripMenuItem.Click += new System.EventHandler(this.скрытьРезультатыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem1.Text = "Удалить";
            //this.toolStripMenuItem1.Click += new System.EventHandler(this.удалитьРезультатыToolStripMenuItem_Click);
            // 
            // ToolStripPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "ToolStripPage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1165, 622);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.embeddedSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.embeddedSplitContainer)).EndInit();
            this.embeddedSplitContainer.ResumeLayout(false);
            this.basePageSplitContainer.Panel1.ResumeLayout(false);
            this.basePageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.basePageSplitContainer)).EndInit();
            this.basePageSplitContainer.ResumeLayout(false);
            this.splitContainerEx2.Panel1.ResumeLayout(false);
            this.splitContainerEx2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx2)).EndInit();
            this.splitContainerEx2.ResumeLayout(false);
            this.splitContainerEx3.Panel1.ResumeLayout(false);
            this.splitContainerEx3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx3)).EndInit();
            this.splitContainerEx3.ResumeLayout(false);
            this.selectToolStrip.ResumeLayout(false);
            this.selectToolStrip.PerformLayout();
            this.instrumentalToolStrip.ResumeLayout(false);
            this.instrumentalToolStrip.PerformLayout();
            this.displayToolStrip.ResumeLayout(false);
            this.displayToolStrip.PerformLayout();
            this.viewToolStrip.ResumeLayout(false);
            this.viewToolStrip.PerformLayout();
            this.condsMenuStrip.ResumeLayout(false);
            this.tasksMenuStrip.ResumeLayout(false);
            this.resultsMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton btnReflect;
        private System.Windows.Forms.ToolStripButton btnClipPlane;
        private System.Windows.Forms.ContextMenuStrip condsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagram_gantt_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закреплениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нагрузкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нагревToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem средаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tasksMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem низкийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem высокийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьИнструкцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьРасчетToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private UserControlsEx.SplitContainerEx basePageSplitContainer;
        private UserControlsEx.SplitContainerEx splitContainerEx2;
        private UserControlsEx.SplitContainerEx splitContainerEx3;
        private NavigatorControl navigator;
        private BaseModule.PropertiesPanel.PropertiesPanelControl propertiesPanelControl;
        private ScenePage scenePage;
        private BaseModule.Console.ConsoleControl consoleControl;
        public UserControlsEx.SplitContainerEx embeddedSplitContainer;
        //private BasePage basePage;
    }
}
