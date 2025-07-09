using BazisGUI.Scene.EventsArgs;
using System;
using System.Collections.Generic;

namespace BazisGUI
{
    partial class BaseForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.webPageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer3 = new UserControlsEx.SplitContainerEx();
            this.splitContainer1 = new UserControlsEx.SplitContainerEx();
            this.navigator = new BaseModule.Navigator.NavigatorControl();
            this.propertiesPanel = new BaseModule.PropertiesPanel.PropertiesPanelControl();
            this.splitContainer2 = new UserControlsEx.SplitContainerEx();
            this.scene = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.console = new BaseModule.Console.ConsoleControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.импортСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортГеометрииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.meshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSurfaceElementsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создать1DПо2DЭлементамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesh3DGeneratorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьПлотностьСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arcWeldingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lazerWeldingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsWeldingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quenchingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBasesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadResultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNodeValueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЗначенияВЭлементахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.усреднитьРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новостиВерсииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лицензияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сведенияMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStrip = new UserControlsEx.ToolStripEx();
            this.spbSelectObject = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSelectNodes = new System.Windows.Forms.ToolStripButton();
            this.btnSelectElements = new System.Windows.Forms.ToolStripButton();
            this.btnSelectObjects = new System.Windows.Forms.ToolStripButton();
            this.btnAdvanceSelection = new System.Windows.Forms.ToolStripButton();
            this.displayToolStrip = new UserControlsEx.ToolStripEx();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnShowOpenSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaceAndRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowRibbers = new System.Windows.Forms.ToolStripButton();
            this.btnShowSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnShowBasis = new System.Windows.Forms.ToolStripButton();
            this.btnShowNormals = new System.Windows.Forms.ToolStripButton();
            this.btnShowCountours = new System.Windows.Forms.ToolStripButton();
            this.instrumentalToolStrip = new UserControlsEx.ToolStripEx();
            this.btnMeasuring = new System.Windows.Forms.ToolStripButton();
            this.btnCrossSection = new System.Windows.Forms.ToolStripButton();
            this.btnScreenShot = new System.Windows.Forms.ToolStripButton();
            this.btnReflect = new System.Windows.Forms.ToolStripButton();
            this.btnClipPlane = new System.Windows.Forms.ToolStripButton();
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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьГруппуItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьВыбранноеItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьСкрытыеItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_InfoSelectedObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SetRotPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_DeleteSelectedObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.selectToolStrip.SuspendLayout();
            this.displayToolStrip.SuspendLayout();
            this.instrumentalToolStrip.SuspendLayout();
            this.viewToolStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer3);
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1058, 350);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1058, 624);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentalToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblVersion,
            this.webPageLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1058, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(933, 21);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(4, 21);
            // 
            // webPageLabel
            // 
            this.webPageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.webPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.webPageLabel.IsLink = true;
            this.webPageLabel.LinkColor = System.Drawing.Color.OrangeRed;
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(101, 21);
            this.webPageLabel.Text = "www.bazisnet.ru";
            this.webPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.webPageLabel.Click += new System.EventHandler(this.webPageLabel_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainer3.IncrementShifting = 50;
            this.splitContainer3.Location = new System.Drawing.Point(5, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(1048, 340);
            this.splitContainer3.SplitterDistance = 444;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.SwitchShifting = false;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainer1.IncrementShifting = 50;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.navigator);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertiesPanel);
            this.splitContainer1.Size = new System.Drawing.Size(444, 340);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.SwitchShifting = false;
            this.splitContainer1.TabIndex = 0;
            // 
            // navigator
            // 
            this.navigator.BackColor = System.Drawing.Color.Gainsboro;
            this.navigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigator.CollapseIndex = 14;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.DownColor = System.Drawing.Color.Gainsboro;
            this.navigator.ExpandIndex = 15;
            this.navigator.HeaderColor = System.Drawing.Color.Black;
            this.navigator.HeaderName = "Навигатор";
            this.navigator.IsPinndable = false;
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.navigator.Name = "navigator";
            this.navigator.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.navigator.ProjectInfoIndex = 0;
            this.navigator.Size = new System.Drawing.Size(444, 265);
            this.navigator.TabIndex = 0;
            this.navigator.UpColor = System.Drawing.Color.Gainsboro;
            this.navigator.HideResultsEvent += new System.Action(this.navigator_HideResultsEvent);
            this.navigator.RemoveResultsEvent += new System.Action(this.navigator_RemoveResultsEvent);
            this.navigator.ShowGantChartEvent += new System.Action(this.navigator_ShowGantChartEvent);
            this.navigator.RemoveAllConditionsEvent += new System.Action(this.navigator_RemoveAllConditionsEvent);
            this.navigator.DelAllGroupsEvent += new System.Action(this.navigator_DelAllGroupsEvent);
            this.navigator.ShowAllGroupsEvent += new System.Action(this.navigator_ShowAllGroupsEvent);
            this.navigator.HideAllGroupsEvent += new System.Action(this.navigator_HideAllGroupsEvent);
            this.navigator.ShowAllObjectsEvent += new System.Action(this.navigator_ShowAllObjectsEvent);
            this.navigator.HideAllObjectsEvent += new System.Action(this.navigator_HideAllObjectsEvent);
            this.navigator.DelAllObjectsEvent += new System.Action(this.navigator_DelAllObjectsEvent);
            this.navigator.ChangeSetViewEvent += new System.Action<string, BaseModule.Navigator.ViewRegime>(this.navigator_ChangeSetViewEvent);
            this.navigator.ShowSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_ShowSetEvent);
            this.navigator.HideSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_HideSetEvent);
            this.navigator.DelSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_DelSetEvent);
            this.navigator.SelectSetEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectSetEvent);
            this.navigator.SelectGroupEvent += new System.Action<int>(this.navigator_SelectGroupEvent);
            this.navigator.DelGroupEvent += new System.Action<int>(this.navigator_DelGroupEvent);
            this.navigator.HideGroupEvent += new System.Action<int>(this.navigator_HideGroupEvent);
            this.navigator.ShowGroupEvent += new System.Action<int>(this.navigator_ShowGroupEvent);
            this.navigator.EditGroupEvent += new System.Action<int>(this.navigator_EditGroupEvent);
            this.navigator.InfoGroupEvent += new System.Action<int>(this.navigator_InfoGroupEvent);
            this.navigator.ShowGroupWithNodesEvent += new System.Action<int>(this.navigator_ShowGroupWithNodesEvent);
            this.navigator.GetObjectsInfoEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_GetObjectsInfoEvent);
            this.navigator.DelObjectsEvent += new System.Action<BaseModule.Navigator.NodeType>(this.navigator_DelObjectsEvent);
            this.navigator.ShowObjectsEvent += new System.Action<BaseModule.Navigator.NodeType>(this.navigator_ShowObjectsEvent);
            this.navigator.HideObjectsEvent += new System.Action<BaseModule.Navigator.NodeType>(this.navigator_HideObjectsEvent);
            this.navigator.SelectObjectEvent += new System.Action<BaseModule.Navigator.NodeType, string, int>(this.navigator_SelectObjectEvent);
            this.navigator.DelObjectEvent += new System.Action<BaseModule.Navigator.NodeType, string, int>(this.navigator_DelObjectEvent);
            this.navigator.ShowObjectEvent += new System.Action<BaseModule.Navigator.NodeType, string, int>(this.navigator_ShowObjectEvent);
            this.navigator.HideObjectEvent += new System.Action<BaseModule.Navigator.NodeType, string, int>(this.navigator_HideObjectEvent);
            this.navigator.SelectCondEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectCondEvent);
            this.navigator.SelectTaskEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectTaskEvent);
            this.navigator.SelectGeneralInfoEvent += new System.Action<BaseModule.Navigator.NodeType, string>(this.navigator_SelectGeneralInfoEvent);
            this.navigator.SelectTimeEvent += new System.Action<string, double>(this.navigator_SelectTimeEvent);
            this.navigator.GetSetsInfoEvent += new System.Action<BaseModule.Navigator.NodeType>(this.navigator_GetSetsInfoEvent);
            this.navigator.GetResultInfoEvent += new System.Action<string>(this.navigator_GetResultInfoEvent);
            this.navigator.AddConditionEvent += new System.Action<object, BaseModule.Navigator.NodeType>(this.navigator_AddConditionEvent);
            this.navigator.GenerateTSFEvent += new System.Action(this.navigator_GenerateTSFEvent);
            this.navigator.GenerateTCFEvent += new System.Action(this.navigator_GenerateTCFEvent);
            this.navigator.StopComputationEvent += new System.Action(this.navigator_StopComputationEvent);
            this.navigator.SetCompPriority += new System.Action<object, BaseModule.Navigator.Priority>(this.navigator_SetCompPriority);
            this.navigator.CreateAnimationEvent += new System.Action<object, string, System.Collections.Generic.List<string>>(this.navigator_CreateAnimationEvent);
            this.navigator.ControlCollapseEvent += new System.Action(this.navigator_ControlCollapseEvent);
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propertiesPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.propertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesPanel.DownColor = System.Drawing.Color.Gainsboro;
            this.propertiesPanel.HeaderColor = System.Drawing.Color.Black;
            this.propertiesPanel.HeaderName = "Свойства";
            this.propertiesPanel.IsPinndable = false;
            this.propertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.propertiesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.propertiesPanel.Size = new System.Drawing.Size(444, 67);
            this.propertiesPanel.TabIndex = 0;
            this.propertiesPanel.UpColor = System.Drawing.Color.Gainsboro;
            this.propertiesPanel.OnPropertyUpdate += new System.Action<BaseModule.PropertiesPanel.PropertyChangedEventArgs>(this.propertiesPanel_OnPropertyUpdate);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IncrementButtonSize = new System.Drawing.Size(50, 5);
            this.splitContainer2.IncrementShifting = 50;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.scene);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.console);
            this.splitContainer2.Size = new System.Drawing.Size(596, 340);
            this.splitContainer2.SplitterDistance = 301;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.SwitchShifting = false;
            this.splitContainer2.TabIndex = 0;
            // 
            // scene
            // 
            this.scene.AccumBits = ((byte)(0));
            this.scene.AutoCheckErrors = false;
            this.scene.AutoFinish = false;
            this.scene.AutoMakeCurrent = true;
            this.scene.AutoSwapBuffers = false;
            this.scene.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.scene.BackColor = System.Drawing.Color.Silver;
            this.scene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scene.ColorBits = ((byte)(32));
            this.scene.DepthBits = ((byte)(16));
            this.scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scene.Location = new System.Drawing.Point(0, 0);
            this.scene.Margin = new System.Windows.Forms.Padding(5);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(596, 301);
            this.scene.StencilBits = ((byte)(0));
            this.scene.TabIndex = 1;
            this.scene.SizeChanged += new System.EventHandler(this.GlControl_Resize);
            this.scene.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GlControl_KeyDown);
            this.scene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scene_MouseClick);
            this.scene.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GlControl_MouseDown);
            this.scene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GlControl_MouseMove);
            this.scene.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GlControl_MouseUp);
            this.scene.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GlControl_MouseWheel);
            // 
            // console
            // 
            this.console.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.console.CheckPrintElemsInfo = false;
            this.console.CheckPrintNodesInfo = false;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.DownColor = System.Drawing.Color.Gainsboro;
            this.console.HeaderColor = System.Drawing.Color.Black;
            this.console.HeaderName = "Консоль";
            this.console.IsPinndable = false;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Margin = new System.Windows.Forms.Padding(0);
            this.console.Name = "console";
            this.console.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.console.Size = new System.Drawing.Size(596, 31);
            this.console.TabIndex = 0;
            this.console.UpColor = System.Drawing.Color.Gainsboro;
            this.console.ControlCollapseEvent += new System.Action(this.console_ControlCollapseEvent);
            this.console.InEvent += new System.Action<object, System.EventArgs>(this.console_InEvent);
            this.console.FindFreeNodesEvent += new System.Action(this.console_FindFreeNodesEvent);
            this.console.RenumberMeshEvent += new System.Action<object, BaseModule.Console.Events.ModelRenumberEventArgs>(this.console_RenumberMeshEvent);
            this.console.ModelShiftCoordinateEvent += new System.Action<object, BaseModule.Console.Events.ModelShiftCoordinateEventArgs>(this.console_ModelShiftCoordinateEvent);
            this.console.ModelRotateEvent += new System.Action<object, BaseModule.Console.ModelRotateEventArgs>(this.console_ModelRotateEvent);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.viewMenuItem,
            this.meshMenuItem,
            this.tasksMenuItem,
            this.dataBasesMenuItem,
            this.resultsMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.лицензияToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.импортСеткиToolStripMenuItem,
            this.импортГеометрииToolStripMenuItem,
            this.добавитьСеткуToolStripMenuItem,
            this.экспортСеткиToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитькакToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьToolStripMenuItem.Image")));
            this.создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.создатьToolStripMenuItem.Text = "&Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьToolStripMenuItem.Image")));
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(205, 6);
            // 
            // импортСеткиToolStripMenuItem
            // 
            this.импортСеткиToolStripMenuItem.Name = "импортСеткиToolStripMenuItem";
            this.импортСеткиToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.импортСеткиToolStripMenuItem.Text = "Импорт сетки";
            this.импортСеткиToolStripMenuItem.Click += new System.EventHandler(this.импортСеткиToolStripMenuItem_Click);
            // 
            // импортГеометрииToolStripMenuItem
            // 
            this.импортГеометрииToolStripMenuItem.Name = "импортГеометрииToolStripMenuItem";
            this.импортГеометрииToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.импортГеометрииToolStripMenuItem.Text = "Импорт геометрии (CAD)";
            this.импортГеометрииToolStripMenuItem.Click += new System.EventHandler(this.импортГеометрииToolStripMenuItem_Click);
            // 
            // добавитьСеткуToolStripMenuItem
            // 
            this.добавитьСеткуToolStripMenuItem.Name = "добавитьСеткуToolStripMenuItem";
            this.добавитьСеткуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.добавитьСеткуToolStripMenuItem.Text = "Добавить сетку";
            this.добавитьСеткуToolStripMenuItem.Click += new System.EventHandler(this.добавитьСеткуToolStripMenuItem_Click);
            // 
            // экспортСеткиToolStripMenuItem
            // 
            this.экспортСеткиToolStripMenuItem.Name = "экспортСеткиToolStripMenuItem";
            this.экспортСеткиToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.экспортСеткиToolStripMenuItem.Text = "Экспорт сетки";
            this.экспортСеткиToolStripMenuItem.Click += new System.EventHandler(this.экспортСеткиToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.сохранитькакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выходToolStripMenuItem.Text = "Вы&ход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewMenuItem.Text = "Вид";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem2.Text = "Навигатор";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem3.Text = "Консоль";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // meshMenuItem
            // 
            this.meshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSurfaceElementsMenuItem,
            this.создать1DПо2DЭлементамToolStripMenuItem,
            this.mesh3DGeneratorMenuItem,
            this.показатьПлотностьСеткиToolStripMenuItem});
            this.meshMenuItem.Name = "meshMenuItem";
            this.meshMenuItem.Size = new System.Drawing.Size(49, 20);
            this.meshMenuItem.Text = "Сетка";
            // 
            // createSurfaceElementsMenuItem
            // 
            this.createSurfaceElementsMenuItem.Name = "createSurfaceElementsMenuItem";
            this.createSurfaceElementsMenuItem.Size = new System.Drawing.Size(213, 22);
            this.createSurfaceElementsMenuItem.Text = "Создать 2D из 3D";
            this.createSurfaceElementsMenuItem.Click += new System.EventHandler(this.createSurfaceElementsMenuItem_Click);
            // 
            // создать1DПо2DЭлементамToolStripMenuItem
            // 
            this.создать1DПо2DЭлементамToolStripMenuItem.Name = "создать1DПо2DЭлементамToolStripMenuItem";
            this.создать1DПо2DЭлементамToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.создать1DПо2DЭлементамToolStripMenuItem.Text = "Создать 1D из 2D";
            this.создать1DПо2DЭлементамToolStripMenuItem.Click += new System.EventHandler(this.создать1DПо2DЭлементамToolStripMenuItem_Click);
            // 
            // mesh3DGeneratorMenuItem
            // 
            this.mesh3DGeneratorMenuItem.CheckOnClick = true;
            this.mesh3DGeneratorMenuItem.Name = "mesh3DGeneratorMenuItem";
            this.mesh3DGeneratorMenuItem.Size = new System.Drawing.Size(213, 22);
            this.mesh3DGeneratorMenuItem.Text = "Генератор 3D сетки";
            this.mesh3DGeneratorMenuItem.Click += new System.EventHandler(this.mesh3DGeneratorMenuItem_Click);
            // 
            // показатьПлотностьСеткиToolStripMenuItem
            // 
            this.показатьПлотностьСеткиToolStripMenuItem.Name = "показатьПлотностьСеткиToolStripMenuItem";
            this.показатьПлотностьСеткиToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.показатьПлотностьСеткиToolStripMenuItem.Text = "Показать плотность сетки";
            this.показатьПлотностьСеткиToolStripMenuItem.Click += new System.EventHandler(this.показатьПлотностьСеткиToolStripMenuItem_Click);
            // 
            // tasksMenuItem
            // 
            this.tasksMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arcWeldingMenuItem,
            this.lazerWeldingMenuItem,
            this.fsWeldingMenuItem,
            this.heatingMenuItem,
            this.temperingMenuItem,
            this.quenchingMenuItem});
            this.tasksMenuItem.Name = "tasksMenuItem";
            this.tasksMenuItem.Size = new System.Drawing.Size(57, 20);
            this.tasksMenuItem.Text = "Задачи";
            // 
            // arcWeldingMenuItem
            // 
            this.arcWeldingMenuItem.CheckOnClick = true;
            this.arcWeldingMenuItem.Name = "arcWeldingMenuItem";
            this.arcWeldingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.arcWeldingMenuItem.Text = "Дуговая сварка";
            this.arcWeldingMenuItem.Click += new System.EventHandler(this.arcWeldingMenuItem_Click);
            // 
            // lazerWeldingMenuItem
            // 
            this.lazerWeldingMenuItem.CheckOnClick = true;
            this.lazerWeldingMenuItem.Name = "lazerWeldingMenuItem";
            this.lazerWeldingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.lazerWeldingMenuItem.Text = "Лазерная сварка";
            this.lazerWeldingMenuItem.Click += new System.EventHandler(this.lazerWeldingMenuItem_Click);
            // 
            // fsWeldingMenuItem
            // 
            this.fsWeldingMenuItem.CheckOnClick = true;
            this.fsWeldingMenuItem.Name = "fsWeldingMenuItem";
            this.fsWeldingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.fsWeldingMenuItem.Text = "Трением с перемешиванием";
            this.fsWeldingMenuItem.Click += new System.EventHandler(this.fsWeldingMenuItem_Click);
            // 
            // heatingMenuItem
            // 
            this.heatingMenuItem.CheckOnClick = true;
            this.heatingMenuItem.Name = "heatingMenuItem";
            this.heatingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.heatingMenuItem.Text = "Нагрев";
            this.heatingMenuItem.Click += new System.EventHandler(this.heatingMenuItem_Click);
            // 
            // temperingMenuItem
            // 
            this.temperingMenuItem.CheckOnClick = true;
            this.temperingMenuItem.Name = "temperingMenuItem";
            this.temperingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.temperingMenuItem.Text = "Отпуск | Отжиг | Старение";
            this.temperingMenuItem.Click += new System.EventHandler(this.temperingMenuItem_Click);
            // 
            // quenchingMenuItem
            // 
            this.quenchingMenuItem.CheckOnClick = true;
            this.quenchingMenuItem.Name = "quenchingMenuItem";
            this.quenchingMenuItem.Size = new System.Drawing.Size(227, 22);
            this.quenchingMenuItem.Text = "Закалка";
            this.quenchingMenuItem.Click += new System.EventHandler(this.quenchingMenuItem_Click);
            // 
            // dataBasesMenuItem
            // 
            this.dataBasesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалыMenuItem,
            this.функцииMenuItem});
            this.dataBasesMenuItem.Name = "dataBasesMenuItem";
            this.dataBasesMenuItem.Size = new System.Drawing.Size(86, 20);
            this.dataBasesMenuItem.Text = "Базы данных";
            // 
            // материалыMenuItem
            // 
            this.материалыMenuItem.Name = "материалыMenuItem";
            this.материалыMenuItem.Size = new System.Drawing.Size(135, 22);
            this.материалыMenuItem.Text = "Материалы";
            this.материалыMenuItem.Click += new System.EventHandler(this.материалыMenuItem_Click);
            // 
            // функцииMenuItem
            // 
            this.функцииMenuItem.Name = "функцииMenuItem";
            this.функцииMenuItem.Size = new System.Drawing.Size(135, 22);
            this.функцииMenuItem.Text = "Функции";
            this.функцииMenuItem.Click += new System.EventHandler(this.функцииMenuItem_Click);
            // 
            // resultsMenuItem
            // 
            this.resultsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadResultsMenuItem,
            this.showNodeValueMenuItem,
            this.показатьЗначенияВЭлементахToolStripMenuItem,
            this.createFieldMenuItem,
            this.createPlotMenuItem,
            this.scaleSettingsMenuItem,
            this.усреднитьРезультатыToolStripMenuItem});
            this.resultsMenuItem.Name = "resultsMenuItem";
            this.resultsMenuItem.Size = new System.Drawing.Size(77, 20);
            this.resultsMenuItem.Text = "Результаты";
            // 
            // loadResultsMenuItem
            // 
            this.loadResultsMenuItem.Name = "loadResultsMenuItem";
            this.loadResultsMenuItem.Size = new System.Drawing.Size(243, 22);
            this.loadResultsMenuItem.Text = "Загрузить результаты";
            this.loadResultsMenuItem.Click += new System.EventHandler(this.loadResultsMenuItem_Click);
            // 
            // showNodeValueMenuItem
            // 
            this.showNodeValueMenuItem.CheckOnClick = true;
            this.showNodeValueMenuItem.Name = "showNodeValueMenuItem";
            this.showNodeValueMenuItem.Size = new System.Drawing.Size(243, 22);
            this.showNodeValueMenuItem.Text = "Показать значения в узлах";
            this.showNodeValueMenuItem.Click += new System.EventHandler(this.showNodeValueMenuItem_Click);
            // 
            // показатьЗначенияВЭлементахToolStripMenuItem
            // 
            this.показатьЗначенияВЭлементахToolStripMenuItem.CheckOnClick = true;
            this.показатьЗначенияВЭлементахToolStripMenuItem.Name = "показатьЗначенияВЭлементахToolStripMenuItem";
            this.показатьЗначенияВЭлементахToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.показатьЗначенияВЭлементахToolStripMenuItem.Text = "Показать значения в элементах";
            this.показатьЗначенияВЭлементахToolStripMenuItem.Click += new System.EventHandler(this.показатьЗначенияВЭлементахToolStripMenuItem_Click);
            // 
            // createFieldMenuItem
            // 
            this.createFieldMenuItem.Checked = true;
            this.createFieldMenuItem.CheckOnClick = true;
            this.createFieldMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createFieldMenuItem.Name = "createFieldMenuItem";
            this.createFieldMenuItem.Size = new System.Drawing.Size(243, 22);
            this.createFieldMenuItem.Text = "Построить поле";
            this.createFieldMenuItem.Click += new System.EventHandler(this.createFieldMenuItem_Click);
            // 
            // createPlotMenuItem
            // 
            this.createPlotMenuItem.Name = "createPlotMenuItem";
            this.createPlotMenuItem.Size = new System.Drawing.Size(243, 22);
            this.createPlotMenuItem.Text = "Построить график";
            this.createPlotMenuItem.Click += new System.EventHandler(this.createPlotMenuItem_Click);
            // 
            // scaleSettingsMenuItem
            // 
            this.scaleSettingsMenuItem.Name = "scaleSettingsMenuItem";
            this.scaleSettingsMenuItem.Size = new System.Drawing.Size(243, 22);
            this.scaleSettingsMenuItem.Text = "Настройки шкалы";
            this.scaleSettingsMenuItem.Click += new System.EventHandler(this.настройкиШкалыMenuItem_Click);
            // 
            // усреднитьРезультатыToolStripMenuItem
            // 
            this.усреднитьРезультатыToolStripMenuItem.Checked = true;
            this.усреднитьРезультатыToolStripMenuItem.CheckOnClick = true;
            this.усреднитьРезультатыToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.усреднитьРезультатыToolStripMenuItem.Name = "усреднитьРезультатыToolStripMenuItem";
            this.усреднитьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.усреднитьРезультатыToolStripMenuItem.Text = "Усреднить результаты";
            this.усреднитьРезультатыToolStripMenuItem.Click += new System.EventHandler(this.усреднитьРезультатыToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.настройкиToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.содержаниеToolStripMenuItem,
            this.опрограммеToolStripMenuItem,
            this.новостиВерсииToolStripMenuItem});
            this.справкаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // содержаниеToolStripMenuItem
            // 
            this.содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            this.содержаниеToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.содержаниеToolStripMenuItem.Text = "&Содержание";
            this.содержаниеToolStripMenuItem.Click += new System.EventHandler(this.содержаниеToolStripMenuItem_Click);
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.опрограммеToolStripMenuItem_Click);
            // 
            // новостиВерсииToolStripMenuItem
            // 
            this.новостиВерсииToolStripMenuItem.Name = "новостиВерсииToolStripMenuItem";
            this.новостиВерсииToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.новостиВерсииToolStripMenuItem.Text = "Новости версии";
            this.новостиВерсииToolStripMenuItem.Click += new System.EventHandler(this.новостиВерсииToolStripMenuItem_Click);
            // 
            // лицензияToolStripMenuItem
            // 
            this.лицензияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сведенияMenuItem});
            this.лицензияToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            this.лицензияToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.лицензияToolStripMenuItem.Text = "Лицензия";
            // 
            // сведенияMenuItem
            // 
            this.сведенияMenuItem.Name = "сведенияMenuItem";
            this.сведенияMenuItem.Size = new System.Drawing.Size(125, 22);
            this.сведенияMenuItem.Text = "Сведения";
            this.сведенияMenuItem.Click += new System.EventHandler(this.сведенияMenuItem_Click);
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
            this.selectToolStrip.Location = new System.Drawing.Point(3, 24);
            this.selectToolStrip.Name = "selectToolStrip";
            this.selectToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.selectToolStrip.Size = new System.Drawing.Size(298, 56);
            this.selectToolStrip.SplitButtonClickWidth = 16;
            this.selectToolStrip.SplitButtonHeight = 36;
            this.selectToolStrip.SplitButtonTriangleSize = 7;
            this.selectToolStrip.TabIndex = 7;
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
            this.spbSelectObject.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.spbSelectObject_DropDownItemClicked);
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
            this.btnAdvanceSelection.Click += new System.EventHandler(this.btnAdvanceSelection_Click);
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
            this.displayToolStrip.Location = new System.Drawing.Point(3, 80);
            this.displayToolStrip.Name = "displayToolStrip";
            this.displayToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.displayToolStrip.Size = new System.Drawing.Size(292, 56);
            this.displayToolStrip.SplitButtonClickWidth = 16;
            this.displayToolStrip.SplitButtonHeight = 34;
            this.displayToolStrip.SplitButtonTriangleSize = 6;
            this.displayToolStrip.TabIndex = 12;
            this.displayToolStrip.Text = "Отображение";
            this.displayToolStrip.TextBoxFrame = false;
            this.displayToolStrip.TextBoxHeight = 14;
            this.displayToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.displayToolStrip_ItemClicked);
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
            this.btnShowNormals.ToolTipText = "Показать нормали";
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
            this.btnShowCountours.ToolTipText = "Показать контуры";
            this.btnShowCountours.Click += new System.EventHandler(this.btnShowCountours_Click);
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
            this.instrumentalToolStrip.Location = new System.Drawing.Point(3, 136);
            this.instrumentalToolStrip.Name = "instrumentalToolStrip";
            this.instrumentalToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.instrumentalToolStrip.Size = new System.Drawing.Size(184, 56);
            this.instrumentalToolStrip.SplitButtonClickWidth = 16;
            this.instrumentalToolStrip.SplitButtonHeight = 34;
            this.instrumentalToolStrip.SplitButtonTriangleSize = 6;
            this.instrumentalToolStrip.TabIndex = 13;
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
            this.btnCrossSection.ToolTipText = "Сделать сечение";
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
            this.btnScreenShot.ToolTipText = "Снимок экрана";
            this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
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
            this.btnReflect.Click += new System.EventHandler(this.btnReflect_Click);
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
            this.btnClipPlane.Click += new System.EventHandler(this.btnClipPlane_Click);
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
            this.viewToolStrip.Location = new System.Drawing.Point(3, 192);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.viewToolStrip.Size = new System.Drawing.Size(328, 56);
            this.viewToolStrip.SplitButtonClickWidth = 16;
            this.viewToolStrip.SplitButtonHeight = 34;
            this.viewToolStrip.SplitButtonTriangleSize = 6;
            this.viewToolStrip.TabIndex = 14;
            this.viewToolStrip.Text = "Вид";
            this.viewToolStrip.TextBoxFrame = false;
            this.viewToolStrip.TextBoxHeight = 14;
            this.viewToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.viewToolStrip_ItemClicked);
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
            this.btnSetRotY.ToolTipText = "Вращение  по Y";
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
            this.btnSetRotZ.ToolTipText = "Вращение  по Z";
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
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьГруппуItem,
            this.скрытьВыбранноеItem,
            this.показатьСкрытыеItem,
            this.menuItem_InfoSelectedObjects,
            this.menuItem_SetRotPoint,
            this.menuItem_DeleteSelectedObjects});
            this.contextMenu.Name = "sceneContextMenu";
            this.contextMenu.Size = new System.Drawing.Size(204, 136);
            // 
            // создатьГруппуItem
            // 
            this.создатьГруппуItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьГруппуItem.Image")));
            this.создатьГруппуItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.создатьГруппуItem.Name = "создатьГруппуItem";
            this.создатьГруппуItem.Size = new System.Drawing.Size(203, 22);
            this.создатьГруппуItem.Text = "Создать новую группу";
            this.создатьГруппуItem.Click += new System.EventHandler(this.создатьГруппуItem_Click);
            // 
            // скрытьВыбранноеItem
            // 
            this.скрытьВыбранноеItem.Image = ((System.Drawing.Image)(resources.GetObject("скрытьВыбранноеItem.Image")));
            this.скрытьВыбранноеItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.скрытьВыбранноеItem.Name = "скрытьВыбранноеItem";
            this.скрытьВыбранноеItem.Size = new System.Drawing.Size(203, 22);
            this.скрытьВыбранноеItem.Text = "Скрыть выбранное";
            this.скрытьВыбранноеItem.Click += new System.EventHandler(this.скрытьВыбранноеItem_Click);
            // 
            // показатьСкрытыеItem
            // 
            this.показатьСкрытыеItem.Image = ((System.Drawing.Image)(resources.GetObject("показатьСкрытыеItem.Image")));
            this.показатьСкрытыеItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.показатьСкрытыеItem.Name = "показатьСкрытыеItem";
            this.показатьСкрытыеItem.Size = new System.Drawing.Size(203, 22);
            this.показатьСкрытыеItem.Text = "Показать все скрытые";
            this.показатьСкрытыеItem.Click += new System.EventHandler(this.показатьСкрытыеItem_Click);
            // 
            // menuItem_InfoSelectedObjects
            // 
            this.menuItem_InfoSelectedObjects.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_InfoSelectedObjects.Image")));
            this.menuItem_InfoSelectedObjects.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_InfoSelectedObjects.Name = "menuItem_InfoSelectedObjects";
            this.menuItem_InfoSelectedObjects.Size = new System.Drawing.Size(203, 22);
            this.menuItem_InfoSelectedObjects.Text = "Инфо";
            this.menuItem_InfoSelectedObjects.Click += new System.EventHandler(this.menuItem_InfoSelectedObjects_Click);
            // 
            // menuItem_SetRotPoint
            // 
            this.menuItem_SetRotPoint.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_SetRotPoint.Image")));
            this.menuItem_SetRotPoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_SetRotPoint.Name = "menuItem_SetRotPoint";
            this.menuItem_SetRotPoint.Size = new System.Drawing.Size(203, 22);
            this.menuItem_SetRotPoint.Text = "Задать точку вращения";
            this.menuItem_SetRotPoint.Click += new System.EventHandler(this.menuItem_SetRotPoint_Click);
            // 
            // menuItem_DeleteSelectedObjects
            // 
            this.menuItem_DeleteSelectedObjects.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_DeleteSelectedObjects.Image")));
            this.menuItem_DeleteSelectedObjects.Name = "menuItem_DeleteSelectedObjects";
            this.menuItem_DeleteSelectedObjects.Size = new System.Drawing.Size(203, 22);
            this.menuItem_DeleteSelectedObjects.Text = "Удалить выбранное";
            this.menuItem_DeleteSelectedObjects.Click += new System.EventHandler(this.menuItem_DeleteSelectedObjects_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 624);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(415, 320);
            this.Name = "BaseForm";
            this.Text = "Bazis. Система технологического анализа";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingForm);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyDown);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.selectToolStrip.ResumeLayout(false);
            this.selectToolStrip.PerformLayout();
            this.displayToolStrip.ResumeLayout(false);
            this.displayToolStrip.PerformLayout();
            this.instrumentalToolStrip.ResumeLayout(false);
            this.instrumentalToolStrip.PerformLayout();
            this.viewToolStrip.ResumeLayout(false);
            this.viewToolStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem содержаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лицензияToolStripMenuItem;
        

        private System.Windows.Forms.ToolStripMenuItem сведенияMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новостиВерсииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитькакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортСеткиToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel webPageLabel;
        private System.Windows.Forms.ToolStripMenuItem импортГеометрииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem meshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSurfaceElementsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesh3DGeneratorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arcWeldingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lazerWeldingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsWeldingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heatingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quenchingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadResultsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNodeValueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBasesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалыMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцииMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFieldMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPlotMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создать1DПо2DЭлементамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортСеткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьЗначенияВЭлементахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem усреднитьРезультатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСеткуToolStripMenuItem;
        public UserControlsEx.ToolStripEx selectToolStrip;
        protected System.Windows.Forms.ToolStripSplitButton spbSelectObject;
        protected System.Windows.Forms.ToolStripButton btnSelectNodes;
        protected System.Windows.Forms.ToolStripButton btnSelectElements;
        protected System.Windows.Forms.ToolStripButton btnSelectObjects;
        protected System.Windows.Forms.ToolStripButton btnAdvanceSelection;
        public UserControlsEx.ToolStripEx instrumentalToolStrip;
        protected System.Windows.Forms.ToolStripButton btnMeasuring;
        protected System.Windows.Forms.ToolStripButton btnCrossSection;
        protected System.Windows.Forms.ToolStripButton btnScreenShot;
        private System.Windows.Forms.ToolStripButton btnReflect;
        private System.Windows.Forms.ToolStripButton btnClipPlane;
        public UserControlsEx.ToolStripEx displayToolStrip;
        protected System.Windows.Forms.ToolStripButton btnShowAll;
        protected System.Windows.Forms.ToolStripButton btnShowOpenSurfaces;
        protected System.Windows.Forms.ToolStripButton btnShowSurfaceAndRibbers;
        protected System.Windows.Forms.ToolStripButton btnShowRibbers;
        protected System.Windows.Forms.ToolStripButton btnShowSurfaces;
        protected System.Windows.Forms.ToolStripButton btnShowBasis;
        protected System.Windows.Forms.ToolStripButton btnShowNormals;
        protected System.Windows.Forms.ToolStripButton btnShowCountours;
        public UserControlsEx.ToolStripEx viewToolStrip;
        protected System.Windows.Forms.ToolStripButton btnSetXY;
        protected System.Windows.Forms.ToolStripButton btnSetZX;
        protected System.Windows.Forms.ToolStripButton btnSetZY;
        protected System.Windows.Forms.ToolStripButton btnSetRotX;
        protected System.Windows.Forms.ToolStripButton btnSetRotY;
        protected System.Windows.Forms.ToolStripButton btnSetRotZ;
        protected System.Windows.Forms.ToolStripButton btnSetRotHor90;
        protected System.Windows.Forms.ToolStripButton btnSetRotVer90;
        protected System.Windows.Forms.ToolStripButton btnFitObjs;
        private UserControlsEx.SplitContainerEx splitContainer3;
        private UserControlsEx.SplitContainerEx splitContainer1;
        private BaseModule.Navigator.NavigatorControl navigator;
        private BaseModule.PropertiesPanel.PropertiesPanelControl propertiesPanel;
        private UserControlsEx.SplitContainerEx splitContainer2;
        private Tao.Platform.Windows.SimpleOpenGlControl scene;
        private BaseModule.Console.ConsoleControl console;
        private System.Windows.Forms.ToolStripMenuItem показатьПлотностьСеткиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem создатьГруппуItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьВыбранноеItem;
        private System.Windows.Forms.ToolStripMenuItem показатьСкрытыеItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_InfoSelectedObjects;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetRotPoint;
        private System.Windows.Forms.ToolStripMenuItem menuItem_DeleteSelectedObjects;
    }
}

