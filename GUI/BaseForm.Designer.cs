using BaseModule.Navigator;
using BazisGUI.Scene.EventsArgs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkPlayerControl = new BaseModule.Player.PlayerControl();
            this.propertiesPanel = new BaseModule.PropertiesPanel.PropertiesPanelControl();
            this.splitContainer2 = new UserControlsEx.SplitContainerEx();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDisplayStates = new System.Windows.Forms.Button();
            this.btnRotVert90 = new System.Windows.Forms.Button();
            this.sceneImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnRotHor90 = new System.Windows.Forms.Button();
            this.btnRotZ = new System.Windows.Forms.Button();
            this.btnRotY = new System.Windows.Forms.Button();
            this.btnRotX = new System.Windows.Forms.Button();
            this.btnZY = new System.Windows.Forms.Button();
            this.btnZX = new System.Windows.Forms.Button();
            this.btnXY = new System.Windows.Forms.Button();
            this.btnDisplayViews = new System.Windows.Forms.Button();
            this.btnShowInsideObjects = new System.Windows.Forms.Button();
            this.btnFitToScreen = new System.Windows.Forms.Button();
            this.btnShowSidesRibs = new System.Windows.Forms.Button();
            this.btnShowRibs = new System.Windows.Forms.Button();
            this.btnShowSides = new System.Windows.Forms.Button();
            this.btnBazis = new System.Windows.Forms.Button();
            this.btnBorder = new System.Windows.Forms.Button();
            this.btnMakeScreenShot = new System.Windows.Forms.Button();
            this.btnAdvSelection = new System.Windows.Forms.Button();
            this.scene = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.console = new BaseModule.Console.ConsoleControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.геометрияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьgeoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьgeoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сеткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.уплотнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наПоверхности3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наПоверхностиГеометрииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квадратизацияСуществующейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBasesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьУсловиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закреплениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мастерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.трениемСПеремешиваниемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.термообработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьНаДиаграммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИнструкцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьИнструкцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.объединитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьДиаграммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьАнимациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортироватьРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.измеритьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отзеркаливаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьПлоскостьюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новостиВерсииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лицензияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сведенияMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(942, 530);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(942, 580);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
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
            this.statusStrip.Size = new System.Drawing.Size(942, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(817, 21);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Создайте или загрузите проект или сетку";
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
            this.splitContainer3.Size = new System.Drawing.Size(932, 520);
            this.splitContainer3.SplitterDistance = 262;
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(262, 520);
            this.splitContainer1.SplitterDistance = 280;
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
            this.navigator.Size = new System.Drawing.Size(262, 280);
            this.navigator.TabIndex = 0;
            this.navigator.UpColor = System.Drawing.Color.Gainsboro;
            this.navigator.HideResultsEvent += new System.Action(this.navigator_HideResultsEvent);
            this.navigator.RemoveResultsEvent += new System.Action(this.navigator_RemoveResultsEvent);
            this.navigator.RemoveAllConditionsEvent += new System.Action(this.navigator_RemoveAllConditionsEvent);
            this.navigator.DelAllGroupsEvent += new System.Action(this.navigator_DelAllGroupsEvent);
            this.navigator.ShowAllGroupsEvent += new System.Action(this.navigator_ShowAllGroupsEvent);
            this.navigator.HideAllGroupsEvent += new System.Action(this.navigator_HideAllGroupsEvent);
            this.navigator.ChangeAllGeoObjectsViewStateEvent += new System.Action<bool>(this.navigator_ChangeAllObjectsViewStateEvent);
            this.navigator.DelAllGeoObjectsEvent += new System.Action(this.navigator_DelAllObjectsEvent);
            this.navigator.ShowMeshEvent += new System.Action<int, bool>(this.navigator_ShowElementsEvent);
            this.navigator.DelMeshEvent += new System.Action<int>(this.navigator_DelElementsEvent);
            this.navigator.ShowSetEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_ShowSetEvent);
            this.navigator.HideSetEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_HideSetEvent);
            this.navigator.DelSetEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_DelSetEvent);
            this.navigator.SelectSetEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_SelectSetEvent);
            this.navigator.GetSetsInfoEvent += new System.Action<System.Windows.Forms.TreeNode>(this.navigator_GetSetsInfoEvent);
            this.navigator.SelectGroupEvent += new System.Action<int>(this.navigator_SelectGroupEvent);
            this.navigator.DelGroupEvent += new System.Action<int>(this.navigator_DelGroupEvent);
            this.navigator.HideGroupEvent += new System.Action<int>(this.navigator_HideGroupEvent);
            this.navigator.ShowGroupEvent += new System.Action<int>(this.navigator_ShowGroupEvent);
            this.navigator.EditGroupEvent += new System.Action<int>(this.EditGroup);
            this.navigator.InfoGroupEvent += new System.Action<int>(this.navigator_InfoGroupEvent);
            this.navigator.ShowGroupWithNodesEvent += new System.Action<int>(this.navigator_ShowGroupWithNodesEvent);
            this.navigator.GetObjectsInfoEvent += new System.Action<System.Windows.Forms.TreeNode>(this.navigator_GetObjectsInfoEvent);
            this.navigator.SelectObjectEvent += new System.Action<BaseModule.Navigator.NodeName, int>(this.navigator_SelectObjectEvent);
            //this.navigator.ShowAdjacenciesEvent += new System.Action(this.ShowAdjacencies);
            //this.navigator.ShowAdjacenciesSetEvent += new System.Action(this.navigator_ShowAdjacenciesSetEvent);
            this.navigator.DelObjectEvent += new System.Action<BaseModule.Navigator.NodeName, int>(this.navigator_DelObjectEvent);
            this.navigator.ShowObjectEvent += new System.Action<BaseModule.Navigator.NodeName, int>(this.navigator_ShowObjectEvent);
            this.navigator.HideObjectEvent += new System.Action<BaseModule.Navigator.NodeName, int>(this.navigator_HideObjectEvent);
            this.navigator.SelectCondEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_SelectCondEvent);
            this.navigator.SelectTaskEvent += new System.Action(this.navigator_SelectTaskEvent);
            this.navigator.SelectGeoEvent += new System.Action(this.navigator_SelectGeoEvent);
            this.navigator.SelectMeshEvent += new System.Action(this.navigator_SelectMeshEvent);
            this.navigator.SelectResultsEvent += new System.Action(this.navigator_SelectResultsEvent);
            this.navigator.SelectCompEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.Navigator_SelectCompEvent);
            this.navigator.SelectCompsEvent += new System.Action(this.Navigator_SelectCompsEvent);
            this.navigator.SelectGeneralInfoEvent += new System.Action(this.navigator_SelectGeneralInfoEvent);
            this.navigator.SelectTimeEvent += new System.Action<string, double>(this.navigator_SelectTimeEvent);
            this.navigator.SelectResultEvent += new System.Action<BaseModule.Navigator.NodeName, string>(this.navigator_SelectResultEvent);
            this.navigator.GetResultInfoEvent += new System.Action<System.Windows.Forms.TreeNode>(this.navigator_GetResultInfoEvent);
            this.navigator.DelCondEvent += new System.Action(this.navigator_DelCondEvent);
            this.navigator.CreateAnimationEvent += new System.Action<object, string, System.Collections.Generic.List<double>>(this.navigator_CreateAnimationEvent);
            this.navigator.ControlCollapseEvent += new System.Action(this.navigator_ControlCollapseEvent);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkPlayerControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertiesPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 232);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // checkPlayerControl
            // 
            this.checkPlayerControl.AutoSize = true;
            this.checkPlayerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkPlayerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkPlayerControl.Cancelation = false;
            this.checkPlayerControl.CheckState = BaseModule.Player.CheckState.start;
            this.checkPlayerControl.CurrentValue = 50;
            this.checkPlayerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkPlayerControl.Location = new System.Drawing.Point(0, 197);
            this.checkPlayerControl.Margin = new System.Windows.Forms.Padding(0);
            this.checkPlayerControl.MinimumSize = new System.Drawing.Size(215, 35);
            this.checkPlayerControl.Name = "checkPlayerControl";
            this.checkPlayerControl.ShowTextValue = true;
            this.checkPlayerControl.Size = new System.Drawing.Size(262, 35);
            this.checkPlayerControl.SliderBarInnerColor = System.Drawing.Color.Silver;
            this.checkPlayerControl.SliderBarOuterColor = System.Drawing.Color.Silver;
            this.checkPlayerControl.SliderElapsedInnerColor = System.Drawing.Color.Silver;
            this.checkPlayerControl.SliderElapsedOuterColor = System.Drawing.Color.Silver;
            this.checkPlayerControl.SpeedValue = 500;
            this.checkPlayerControl.StartValue = 0;
            this.checkPlayerControl.StopValue = 100;
            this.checkPlayerControl.TabIndex = 2;
            this.checkPlayerControl.TextValueColor = System.Drawing.Color.Black;
            this.checkPlayerControl.CheckingEvent += new System.Action<object, int>(this.checkPlayerControl_CheckingEvent);
            this.checkPlayerControl.StopCheckingEvent += new System.Action<object>(this.checkPlayerControl_StopCheckingEvent);
            this.checkPlayerControl.StartCheckingEvent += new System.Action<object>(this.checkPlayerControl_StartCheckingEvent);
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
            this.propertiesPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.propertiesPanel.Size = new System.Drawing.Size(262, 189);
            this.propertiesPanel.TabIndex = 0;
            this.propertiesPanel.UpColor = System.Drawing.Color.Gainsboro;
            this.propertiesPanel.PropertyUpdateEvent += new System.Action<BaseModule.PropertiesPanel.PropertyChangedEventArgs>(this.propertiesPanel_OnPropertyUpdate);
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
            this.splitContainer2.Panel1.Controls.Add(this.btnSelect);
            this.splitContainer2.Panel1.Controls.Add(this.btnDisplayStates);
            this.splitContainer2.Panel1.Controls.Add(this.btnRotVert90);
            this.splitContainer2.Panel1.Controls.Add(this.btnRotHor90);
            this.splitContainer2.Panel1.Controls.Add(this.btnRotZ);
            this.splitContainer2.Panel1.Controls.Add(this.btnRotY);
            this.splitContainer2.Panel1.Controls.Add(this.btnRotX);
            this.splitContainer2.Panel1.Controls.Add(this.btnZY);
            this.splitContainer2.Panel1.Controls.Add(this.btnZX);
            this.splitContainer2.Panel1.Controls.Add(this.btnXY);
            this.splitContainer2.Panel1.Controls.Add(this.btnDisplayViews);
            this.splitContainer2.Panel1.Controls.Add(this.btnShowInsideObjects);
            this.splitContainer2.Panel1.Controls.Add(this.btnFitToScreen);
            this.splitContainer2.Panel1.Controls.Add(this.btnShowSidesRibs);
            this.splitContainer2.Panel1.Controls.Add(this.btnShowRibs);
            this.splitContainer2.Panel1.Controls.Add(this.btnShowSides);
            this.splitContainer2.Panel1.Controls.Add(this.btnBazis);
            this.splitContainer2.Panel1.Controls.Add(this.btnBorder);
            this.splitContainer2.Panel1.Controls.Add(this.btnMakeScreenShot);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdvSelection);
            this.splitContainer2.Panel1.Controls.Add(this.scene);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.console);
            this.splitContainer2.Size = new System.Drawing.Size(662, 520);
            this.splitContainer2.SplitterDistance = 384;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.SwitchShifting = false;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Image = global::BazisGUI.Properties.Resources.arrow_r;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(3, 3);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 3, 2, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 27);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Tag = "False";
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.Leave += new System.EventHandler(this.btnSelect_Leave);
            // 
            // btnDisplayStates
            // 
            this.btnDisplayStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplayStates.Enabled = false;
            this.btnDisplayStates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayStates.Image = global::BazisGUI.Properties.Resources.arrow_d;
            this.btnDisplayStates.Location = new System.Drawing.Point(463, 3);
            this.btnDisplayStates.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDisplayStates.Name = "btnDisplayStates";
            this.btnDisplayStates.Size = new System.Drawing.Size(18, 27);
            this.btnDisplayStates.TabIndex = 4;
            this.btnDisplayStates.Tag = "False";
            this.btnDisplayStates.UseVisualStyleBackColor = true;
            this.btnDisplayStates.Click += new System.EventHandler(this.btnDisplayStates_Click);
            // 
            // btnRotVert90
            // 
            this.btnRotVert90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotVert90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotVert90.ImageIndex = 8;
            this.btnRotVert90.ImageList = this.sceneImageList;
            this.btnRotVert90.Location = new System.Drawing.Point(631, 253);
            this.btnRotVert90.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnRotVert90.Name = "btnRotVert90";
            this.btnRotVert90.Size = new System.Drawing.Size(27, 27);
            this.btnRotVert90.TabIndex = 3;
            this.btnRotVert90.UseVisualStyleBackColor = true;
            this.btnRotVert90.Visible = false;
            this.btnRotVert90.Click += new System.EventHandler(this.btnRotVert90_Click);
            // 
            // sceneImageList
            // 
            this.sceneImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sceneImageList.ImageStream")));
            this.sceneImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.sceneImageList.Images.SetKeyName(0, "вп 12.png");
            this.sceneImageList.Images.SetKeyName(1, "вп 25.png");
            this.sceneImageList.Images.SetKeyName(2, "вп 26.png");
            this.sceneImageList.Images.SetKeyName(3, "вп 27.png");
            this.sceneImageList.Images.SetKeyName(4, "вп 28.png");
            this.sceneImageList.Images.SetKeyName(5, "вп 29.png");
            this.sceneImageList.Images.SetKeyName(6, "вп 30.png");
            this.sceneImageList.Images.SetKeyName(7, "вп 31.png");
            this.sceneImageList.Images.SetKeyName(8, "вп 32.png");
            this.sceneImageList.Images.SetKeyName(9, "вп 16.png");
            this.sceneImageList.Images.SetKeyName(10, "вп 17.png");
            this.sceneImageList.Images.SetKeyName(11, "вп 18.png");
            this.sceneImageList.Images.SetKeyName(12, "вп 21.png");
            this.sceneImageList.Images.SetKeyName(13, "вп 24.png");
            this.sceneImageList.Images.SetKeyName(14, "вп 33.png");
            this.sceneImageList.Images.SetKeyName(15, "вп 19.png");
            this.sceneImageList.Images.SetKeyName(16, "вп 21.png");
            this.sceneImageList.Images.SetKeyName(17, "вп 14.png");
            // 
            // btnRotHor90
            // 
            this.btnRotHor90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotHor90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotHor90.ImageIndex = 7;
            this.btnRotHor90.ImageList = this.sceneImageList;
            this.btnRotHor90.Location = new System.Drawing.Point(631, 223);
            this.btnRotHor90.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnRotHor90.Name = "btnRotHor90";
            this.btnRotHor90.Size = new System.Drawing.Size(27, 27);
            this.btnRotHor90.TabIndex = 3;
            this.btnRotHor90.UseVisualStyleBackColor = true;
            this.btnRotHor90.Visible = false;
            this.btnRotHor90.Click += new System.EventHandler(this.btnRotHor90_Click);
            // 
            // btnRotZ
            // 
            this.btnRotZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotZ.ImageIndex = 6;
            this.btnRotZ.ImageList = this.sceneImageList;
            this.btnRotZ.Location = new System.Drawing.Point(631, 193);
            this.btnRotZ.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnRotZ.Name = "btnRotZ";
            this.btnRotZ.Size = new System.Drawing.Size(27, 27);
            this.btnRotZ.TabIndex = 3;
            this.btnRotZ.Tag = "False";
            this.btnRotZ.UseVisualStyleBackColor = true;
            this.btnRotZ.Visible = false;
            this.btnRotZ.Click += new System.EventHandler(this.btnRotZ_Click);
            this.btnRotZ.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRot_Paint);
            // 
            // btnRotY
            // 
            this.btnRotY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotY.ImageIndex = 5;
            this.btnRotY.ImageList = this.sceneImageList;
            this.btnRotY.Location = new System.Drawing.Point(631, 163);
            this.btnRotY.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnRotY.Name = "btnRotY";
            this.btnRotY.Size = new System.Drawing.Size(27, 27);
            this.btnRotY.TabIndex = 3;
            this.btnRotY.Tag = "False";
            this.btnRotY.UseVisualStyleBackColor = true;
            this.btnRotY.Visible = false;
            this.btnRotY.Click += new System.EventHandler(this.btnRotY_Click);
            this.btnRotY.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRot_Paint);
            // 
            // btnRotX
            // 
            this.btnRotX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotX.ImageIndex = 4;
            this.btnRotX.ImageList = this.sceneImageList;
            this.btnRotX.Location = new System.Drawing.Point(631, 133);
            this.btnRotX.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnRotX.Name = "btnRotX";
            this.btnRotX.Size = new System.Drawing.Size(27, 27);
            this.btnRotX.TabIndex = 3;
            this.btnRotX.Tag = "False";
            this.btnRotX.UseVisualStyleBackColor = true;
            this.btnRotX.Visible = false;
            this.btnRotX.Click += new System.EventHandler(this.btnRotX_Click);
            this.btnRotX.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRot_Paint);
            // 
            // btnZY
            // 
            this.btnZY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZY.ImageIndex = 3;
            this.btnZY.ImageList = this.sceneImageList;
            this.btnZY.Location = new System.Drawing.Point(631, 103);
            this.btnZY.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnZY.Name = "btnZY";
            this.btnZY.Size = new System.Drawing.Size(27, 27);
            this.btnZY.TabIndex = 3;
            this.btnZY.UseVisualStyleBackColor = true;
            this.btnZY.Visible = false;
            this.btnZY.Click += new System.EventHandler(this.btnZY_Click);
            // 
            // btnZX
            // 
            this.btnZX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZX.ImageIndex = 2;
            this.btnZX.ImageList = this.sceneImageList;
            this.btnZX.Location = new System.Drawing.Point(631, 73);
            this.btnZX.Margin = new System.Windows.Forms.Padding(3, 3, 4, 0);
            this.btnZX.Name = "btnZX";
            this.btnZX.Size = new System.Drawing.Size(27, 27);
            this.btnZX.TabIndex = 3;
            this.btnZX.UseVisualStyleBackColor = true;
            this.btnZX.Visible = false;
            this.btnZX.Click += new System.EventHandler(this.btnZX_Click);
            // 
            // btnXY
            // 
            this.btnXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXY.ImageIndex = 1;
            this.btnXY.ImageList = this.sceneImageList;
            this.btnXY.Location = new System.Drawing.Point(631, 43);
            this.btnXY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.btnXY.Name = "btnXY";
            this.btnXY.Size = new System.Drawing.Size(27, 27);
            this.btnXY.TabIndex = 3;
            this.btnXY.UseVisualStyleBackColor = true;
            this.btnXY.Visible = false;
            this.btnXY.Click += new System.EventHandler(this.btnXY_Click);
            // 
            // btnDisplayViews
            // 
            this.btnDisplayViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplayViews.Enabled = false;
            this.btnDisplayViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayViews.Image = global::BazisGUI.Properties.Resources.arrow_r;
            this.btnDisplayViews.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisplayViews.Location = new System.Drawing.Point(583, 3);
            this.btnDisplayViews.Margin = new System.Windows.Forms.Padding(3, 4, 24, 4);
            this.btnDisplayViews.Name = "btnDisplayViews";
            this.btnDisplayViews.Size = new System.Drawing.Size(55, 27);
            this.btnDisplayViews.TabIndex = 3;
            this.btnDisplayViews.Tag = "False";
            this.btnDisplayViews.Text = "Вид";
            this.btnDisplayViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisplayViews.UseVisualStyleBackColor = true;
            this.btnDisplayViews.Click += new System.EventHandler(this.btnDisplayViews_Click);
            // 
            // btnShowInsideObjects
            // 
            this.btnShowInsideObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowInsideObjects.Enabled = false;
            this.btnShowInsideObjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInsideObjects.ImageIndex = 17;
            this.btnShowInsideObjects.ImageList = this.sceneImageList;
            this.btnShowInsideObjects.Location = new System.Drawing.Point(550, 3);
            this.btnShowInsideObjects.Margin = new System.Windows.Forms.Padding(0, 4, 3, 4);
            this.btnShowInsideObjects.Name = "btnShowInsideObjects";
            this.btnShowInsideObjects.Size = new System.Drawing.Size(27, 27);
            this.btnShowInsideObjects.TabIndex = 3;
            this.btnShowInsideObjects.Tag = "False";
            this.btnShowInsideObjects.UseVisualStyleBackColor = true;
            this.btnShowInsideObjects.Click += new System.EventHandler(this.btnShowInsideObjects_Click);
            // 
            // btnFitToScreen
            // 
            this.btnFitToScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFitToScreen.Enabled = false;
            this.btnFitToScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFitToScreen.ImageIndex = 14;
            this.btnFitToScreen.ImageList = this.sceneImageList;
            this.btnFitToScreen.Location = new System.Drawing.Point(520, 3);
            this.btnFitToScreen.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnFitToScreen.Name = "btnFitToScreen";
            this.btnFitToScreen.Size = new System.Drawing.Size(27, 27);
            this.btnFitToScreen.TabIndex = 3;
            this.btnFitToScreen.UseVisualStyleBackColor = true;
            this.btnFitToScreen.Click += new System.EventHandler(this.btnFitToScreen_Click);
            // 
            // btnShowSidesRibs
            // 
            this.btnShowSidesRibs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSidesRibs.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowSidesRibs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSidesRibs.ImageIndex = 9;
            this.btnShowSidesRibs.ImageList = this.sceneImageList;
            this.btnShowSidesRibs.Location = new System.Drawing.Point(307, 3);
            this.btnShowSidesRibs.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnShowSidesRibs.Name = "btnShowSidesRibs";
            this.btnShowSidesRibs.Size = new System.Drawing.Size(27, 27);
            this.btnShowSidesRibs.TabIndex = 3;
            this.btnShowSidesRibs.UseVisualStyleBackColor = false;
            this.btnShowSidesRibs.Visible = false;
            this.btnShowSidesRibs.Click += new System.EventHandler(this.btnShowSidesRibs_Click);
            // 
            // btnShowRibs
            // 
            this.btnShowRibs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRibs.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowRibs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRibs.ImageIndex = 10;
            this.btnShowRibs.ImageList = this.sceneImageList;
            this.btnShowRibs.Location = new System.Drawing.Point(337, 3);
            this.btnShowRibs.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnShowRibs.Name = "btnShowRibs";
            this.btnShowRibs.Size = new System.Drawing.Size(27, 27);
            this.btnShowRibs.TabIndex = 3;
            this.btnShowRibs.UseVisualStyleBackColor = false;
            this.btnShowRibs.Visible = false;
            this.btnShowRibs.Click += new System.EventHandler(this.btnShowRibs_Click);
            // 
            // btnShowSides
            // 
            this.btnShowSides.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSides.ImageIndex = 11;
            this.btnShowSides.ImageList = this.sceneImageList;
            this.btnShowSides.Location = new System.Drawing.Point(367, 3);
            this.btnShowSides.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnShowSides.Name = "btnShowSides";
            this.btnShowSides.Size = new System.Drawing.Size(27, 27);
            this.btnShowSides.TabIndex = 3;
            this.btnShowSides.UseVisualStyleBackColor = true;
            this.btnShowSides.Visible = false;
            this.btnShowSides.Click += new System.EventHandler(this.btnShowSides_Click);
            // 
            // btnBazis
            // 
            this.btnBazis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBazis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBazis.ImageIndex = 15;
            this.btnBazis.ImageList = this.sceneImageList;
            this.btnBazis.Location = new System.Drawing.Point(397, 3);
            this.btnBazis.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnBazis.Name = "btnBazis";
            this.btnBazis.Size = new System.Drawing.Size(27, 27);
            this.btnBazis.TabIndex = 3;
            this.btnBazis.Tag = "False";
            this.btnBazis.UseVisualStyleBackColor = true;
            this.btnBazis.Visible = false;
            this.btnBazis.Click += new System.EventHandler(this.btnBazis_Click);
            this.btnBazis.Paint += new System.Windows.Forms.PaintEventHandler(this.btnBazis_Paint);
            // 
            // btnBorder
            // 
            this.btnBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorder.ImageIndex = 16;
            this.btnBorder.ImageList = this.sceneImageList;
            this.btnBorder.Location = new System.Drawing.Point(427, 3);
            this.btnBorder.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnBorder.Name = "btnBorder";
            this.btnBorder.Size = new System.Drawing.Size(27, 27);
            this.btnBorder.TabIndex = 3;
            this.btnBorder.Tag = "False";
            this.btnBorder.UseVisualStyleBackColor = true;
            this.btnBorder.Visible = false;
            this.btnBorder.Click += new System.EventHandler(this.btnBorder_Click);
            // 
            // btnMakeScreenShot
            // 
            this.btnMakeScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeScreenShot.Enabled = false;
            this.btnMakeScreenShot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeScreenShot.ImageIndex = 13;
            this.btnMakeScreenShot.ImageList = this.sceneImageList;
            this.btnMakeScreenShot.Location = new System.Drawing.Point(490, 3);
            this.btnMakeScreenShot.Name = "btnMakeScreenShot";
            this.btnMakeScreenShot.Size = new System.Drawing.Size(27, 27);
            this.btnMakeScreenShot.TabIndex = 3;
            this.btnMakeScreenShot.UseVisualStyleBackColor = true;
            this.btnMakeScreenShot.Click += new System.EventHandler(this.btnMakeScreenShot_Click);
            // 
            // btnAdvSelection
            // 
            this.btnAdvSelection.Enabled = false;
            this.btnAdvSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvSelection.ImageIndex = 0;
            this.btnAdvSelection.ImageList = this.sceneImageList;
            this.btnAdvSelection.Location = new System.Drawing.Point(114, 3);
            this.btnAdvSelection.Margin = new System.Windows.Forms.Padding(1, 8, 4, 4);
            this.btnAdvSelection.Name = "btnAdvSelection";
            this.btnAdvSelection.Size = new System.Drawing.Size(27, 27);
            this.btnAdvSelection.TabIndex = 3;
            this.btnAdvSelection.Tag = "False";
            this.btnAdvSelection.UseVisualStyleBackColor = true;
            this.btnAdvSelection.Click += new System.EventHandler(this.btnAdvSelection_Click);
            this.btnAdvSelection.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSelection_Paint);
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
            this.scene.Enabled = false;
            this.scene.Location = new System.Drawing.Point(0, 0);
            this.scene.Margin = new System.Windows.Forms.Padding(5);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(662, 384);
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
            this.console.Enabled = false;
            this.console.HeaderColor = System.Drawing.Color.Black;
            this.console.HeaderName = "Консоль";
            this.console.IsPinndable = false;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Margin = new System.Windows.Forms.Padding(0);
            this.console.Name = "console";
            this.console.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.console.Size = new System.Drawing.Size(662, 128);
            this.console.TabIndex = 0;
            this.console.UpColor = System.Drawing.Color.Gainsboro;
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
            this.геометрияToolStripMenuItem,
            this.сеткаToolStripMenuItem,
            this.dataBasesMenuItem,
            this.tasksMenuItem,
            this.расчетыToolStripMenuItem,
            this.результатыMenuItem,
            this.инструментыToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.лицензияToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(942, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.toolStripSeparator,
            this.сохранитьToolStripMenuItem,
            this.сохранитькакToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
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
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.создатьToolStripMenuItem.Text = "&Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьToolStripMenuItem.Image")));
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьСеткуToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(181, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.сохранитькакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
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
            // геометрияToolStripMenuItem
            // 
            this.геометрияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьgeoToolStripMenuItem,
            this.сформироватьgeoToolStripMenuItem});
            this.геометрияToolStripMenuItem.Enabled = false;
            this.геометрияToolStripMenuItem.Name = "геометрияToolStripMenuItem";
            this.геометрияToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.геометрияToolStripMenuItem.Text = "Геометрия";
            // 
            // загрузитьgeoToolStripMenuItem
            // 
            this.загрузитьgeoToolStripMenuItem.Name = "загрузитьgeoToolStripMenuItem";
            this.загрузитьgeoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.загрузитьgeoToolStripMenuItem.Text = "Загрузить *.gscript";
            this.загрузитьgeoToolStripMenuItem.Click += new System.EventHandler(this.загрузитьgeoToolStripMenuItem_Click);
            // 
            // сформироватьgeoToolStripMenuItem
            // 
            this.сформироватьgeoToolStripMenuItem.Name = "сформироватьgeoToolStripMenuItem";
            this.сформироватьgeoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.сформироватьgeoToolStripMenuItem.Text = "Сформировать *.gscript";
            this.сформироватьgeoToolStripMenuItem.Click += new System.EventHandler(this.сформироватьgeoToolStripMenuItem_Click);
            // 
            // сеткаToolStripMenuItem
            // 
            this.сеткаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.dToolStripMenuItem1,
            this.dToolStripMenuItem2});
            this.сеткаToolStripMenuItem.Enabled = false;
            this.сеткаToolStripMenuItem.Name = "сеткаToolStripMenuItem";
            this.сеткаToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.сеткаToolStripMenuItem.Text = "Сетка";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.наToolStripMenuItem});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.dToolStripMenuItem.Text = "1D";
            // 
            // наToolStripMenuItem
            // 
            this.наToolStripMenuItem.Name = "наToolStripMenuItem";
            this.наToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.наToolStripMenuItem.Text = "На границах 2D элементов";
            this.наToolStripMenuItem.Click += new System.EventHandler(this.наПоверхности2DToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem1
            // 
            this.dToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.уплотнитьToolStripMenuItem,
            this.наПоверхности3DToolStripMenuItem,
            this.наПоверхностиГеометрииToolStripMenuItem,
            this.квадратизацияСуществующейToolStripMenuItem});
            this.dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            this.dToolStripMenuItem1.Size = new System.Drawing.Size(88, 22);
            this.dToolStripMenuItem1.Text = "2D";
            // 
            // уплотнитьToolStripMenuItem
            // 
            this.уплотнитьToolStripMenuItem.Enabled = false;
            this.уплотнитьToolStripMenuItem.Name = "уплотнитьToolStripMenuItem";
            this.уплотнитьToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.уплотнитьToolStripMenuItem.Text = "Уплотнить существующую";
            this.уплотнитьToolStripMenuItem.Click += new System.EventHandler(this.уплотнитьToolStripMenuItem_Click);
            // 
            // наПоверхности3DToolStripMenuItem
            // 
            this.наПоверхности3DToolStripMenuItem.Name = "наПоверхности3DToolStripMenuItem";
            this.наПоверхности3DToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.наПоверхности3DToolStripMenuItem.Text = "На открытых 3D элементах";
            this.наПоверхности3DToolStripMenuItem.Click += new System.EventHandler(this.наПоверхности3DToolStripMenuItem_Click);
            // 
            // наПоверхностиГеометрииToolStripMenuItem
            // 
            this.наПоверхностиГеометрииToolStripMenuItem.Name = "наПоверхностиГеометрииToolStripMenuItem";
            this.наПоверхностиГеометрииToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.наПоверхностиГеометрииToolStripMenuItem.Text = "На поверхностях геометрии";
            this.наПоверхностиГеометрииToolStripMenuItem.Click += new System.EventHandler(this.наПоверхностиГеометрииToolStripMenuItem_Click);
            // 
            // квадратизацияСуществующейToolStripMenuItem
            // 
            this.квадратизацияСуществующейToolStripMenuItem.Enabled = false;
            this.квадратизацияСуществующейToolStripMenuItem.Name = "квадратизацияСуществующейToolStripMenuItem";
            this.квадратизацияСуществующейToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.квадратизацияСуществующейToolStripMenuItem.Text = "Квадратизация существующей";
            this.квадратизацияСуществующейToolStripMenuItem.Click += new System.EventHandler(this.квадратизацияСуществующейToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem2
            // 
            this.dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            this.dToolStripMenuItem2.Size = new System.Drawing.Size(88, 22);
            this.dToolStripMenuItem2.Text = "3D";
            this.dToolStripMenuItem2.Click += new System.EventHandler(this.создать3DСеткуToolStripMenuItem_Click);
            // 
            // dataBasesMenuItem
            // 
            this.dataBasesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалыMenuItem,
            this.функцииMenuItem});
            this.dataBasesMenuItem.Enabled = false;
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
            // tasksMenuItem
            // 
            this.tasksMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem1,
            this.добавитьУсловиеToolStripMenuItem,
            this.мастерToolStripMenuItem,
            this.показатьНаДиаграммеToolStripMenuItem});
            this.tasksMenuItem.Enabled = false;
            this.tasksMenuItem.Name = "tasksMenuItem";
            this.tasksMenuItem.Size = new System.Drawing.Size(56, 20);
            this.tasksMenuItem.Text = "Задача";
            // 
            // создатьToolStripMenuItem1
            // 
            this.создатьToolStripMenuItem1.Name = "создатьToolStripMenuItem1";
            this.создатьToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.создатьToolStripMenuItem1.Text = "Создать";
            this.создатьToolStripMenuItem1.Click += new System.EventHandler(this.создатьЗадачуToolStripMenuItem_Click);
            // 
            // добавитьУсловиеToolStripMenuItem
            // 
            this.добавитьУсловиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалToolStripMenuItem,
            this.средаToolStripMenuItem,
            this.нагревToolStripMenuItem,
            this.закреплениеToolStripMenuItem,
            this.нагрузкаToolStripMenuItem});
            this.добавитьУсловиеToolStripMenuItem.Name = "добавитьУсловиеToolStripMenuItem";
            this.добавитьУсловиеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.добавитьУсловиеToolStripMenuItem.Text = "Добавить условие";
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.материалToolStripMenuItem.Text = "Материал";
            this.материалToolStripMenuItem.Click += new System.EventHandler(this.материалToolStripMenuItem_Click);
            // 
            // средаToolStripMenuItem
            // 
            this.средаToolStripMenuItem.Name = "средаToolStripMenuItem";
            this.средаToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.средаToolStripMenuItem.Text = "Среда";
            this.средаToolStripMenuItem.Click += new System.EventHandler(this.средаToolStripMenuItem_Click);
            // 
            // нагревToolStripMenuItem
            // 
            this.нагревToolStripMenuItem.Name = "нагревToolStripMenuItem";
            this.нагревToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.нагревToolStripMenuItem.Text = "Нагрев";
            this.нагревToolStripMenuItem.Click += new System.EventHandler(this.нагревToolStripMenuItem_Click);
            // 
            // закреплениеToolStripMenuItem
            // 
            this.закреплениеToolStripMenuItem.Name = "закреплениеToolStripMenuItem";
            this.закреплениеToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.закреплениеToolStripMenuItem.Text = "Закрепление";
            this.закреплениеToolStripMenuItem.Click += new System.EventHandler(this.закреплениеToolStripMenuItem_Click);
            // 
            // нагрузкаToolStripMenuItem
            // 
            this.нагрузкаToolStripMenuItem.Name = "нагрузкаToolStripMenuItem";
            this.нагрузкаToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.нагрузкаToolStripMenuItem.Text = "Нагрузка";
            this.нагрузкаToolStripMenuItem.Click += new System.EventHandler(this.нагрузкаToolStripMenuItem_Click);
            // 
            // мастерToolStripMenuItem
            // 
            this.мастерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.трениемСПеремешиваниемToolStripMenuItem,
            this.термообработкаToolStripMenuItem});
            this.мастерToolStripMenuItem.Enabled = false;
            this.мастерToolStripMenuItem.Name = "мастерToolStripMenuItem";
            this.мастерToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.мастерToolStripMenuItem.Text = "Мастер";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem1.Text = "Сварка плавлением";
            // 
            // трениемСПеремешиваниемToolStripMenuItem
            // 
            this.трениемСПеремешиваниемToolStripMenuItem.Name = "трениемСПеремешиваниемToolStripMenuItem";
            this.трениемСПеремешиваниемToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.трениемСПеремешиваниемToolStripMenuItem.Text = "Трением с перемешиванием";
            // 
            // термообработкаToolStripMenuItem
            // 
            this.термообработкаToolStripMenuItem.Name = "термообработкаToolStripMenuItem";
            this.термообработкаToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.термообработкаToolStripMenuItem.Text = "Термообработка";
            // 
            // показатьНаДиаграммеToolStripMenuItem
            // 
            this.показатьНаДиаграммеToolStripMenuItem.Name = "показатьНаДиаграммеToolStripMenuItem";
            this.показатьНаДиаграммеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.показатьНаДиаграммеToolStripMenuItem.Text = "Показать на диаграмме";
            this.показатьНаДиаграммеToolStripMenuItem.Click += new System.EventHandler(this.показатьНаДиаграммеToolStripMenuItem_Click);
            // 
            // расчетыToolStripMenuItem
            // 
            this.расчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИнструкцииToolStripMenuItem,
            this.сформироватьИнструкцииToolStripMenuItem,
            this.запуститьToolStripMenuItem,
            this.остановитьToolStripMenuItem});
            this.расчетыToolStripMenuItem.Enabled = false;
            this.расчетыToolStripMenuItem.Name = "расчетыToolStripMenuItem";
            this.расчетыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.расчетыToolStripMenuItem.Text = "Расчеты";
            // 
            // открытьИнструкцииToolStripMenuItem
            // 
            this.открытьИнструкцииToolStripMenuItem.Name = "открытьИнструкцииToolStripMenuItem";
            this.открытьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.открытьИнструкцииToolStripMenuItem.Text = "Открыть";
            this.открытьИнструкцииToolStripMenuItem.Click += new System.EventHandler(this.открытьИнструкцииToolStripMenuItem_Click);
            // 
            // сформироватьИнструкцииToolStripMenuItem
            // 
            this.сформироватьИнструкцииToolStripMenuItem.Name = "сформироватьИнструкцииToolStripMenuItem";
            this.сформироватьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.сформироватьИнструкцииToolStripMenuItem.Text = "Сформировать";
            this.сформироватьИнструкцииToolStripMenuItem.Click += new System.EventHandler(this.сформироватьИнструкцииToolStripMenuItem_Click);
            // 
            // запуститьToolStripMenuItem
            // 
            this.запуститьToolStripMenuItem.Name = "запуститьToolStripMenuItem";
            this.запуститьToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.запуститьToolStripMenuItem.Text = "Запустить";
            this.запуститьToolStripMenuItem.Click += new System.EventHandler(this.запуститьToolStripMenuItem_Click);
            // 
            // остановитьToolStripMenuItem
            // 
            this.остановитьToolStripMenuItem.Name = "остановитьToolStripMenuItem";
            this.остановитьToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.остановитьToolStripMenuItem.Text = "Остановить";
            this.остановитьToolStripMenuItem.Click += new System.EventHandler(this.остановитьToolStripMenuItem_Click);
            // 
            // результатыMenuItem
            // 
            this.результатыMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.объединитьToolStripMenuItem,
            this.построитьГрафикToolStripMenuItem,
            this.построитьДиаграммуToolStripMenuItem,
            this.создатьАнимациюToolStripMenuItem,
            this.экспортироватьРезультатыToolStripMenuItem});
            this.результатыMenuItem.Enabled = false;
            this.результатыMenuItem.Name = "результатыMenuItem";
            this.результатыMenuItem.Size = new System.Drawing.Size(77, 20);
            this.результатыMenuItem.Text = "Результаты";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
            this.открытьToolStripMenuItem1.Text = "Открыть";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // объединитьToolStripMenuItem
            // 
            this.объединитьToolStripMenuItem.Enabled = false;
            this.объединитьToolStripMenuItem.Name = "объединитьToolStripMenuItem";
            this.объединитьToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.объединитьToolStripMenuItem.Text = "Объединить";
            // 
            // построитьГрафикToolStripMenuItem
            // 
            this.построитьГрафикToolStripMenuItem.Name = "построитьГрафикToolStripMenuItem";
            this.построитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.построитьГрафикToolStripMenuItem.Text = "Построить график";
            this.построитьГрафикToolStripMenuItem.Click += new System.EventHandler(this.построитьГрафикToolStripMenuItem_Click);
            // 
            // построитьДиаграммуToolStripMenuItem
            // 
            this.построитьДиаграммуToolStripMenuItem.Name = "построитьДиаграммуToolStripMenuItem";
            this.построитьДиаграммуToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.построитьДиаграммуToolStripMenuItem.Text = "Построить диаграмму";
            this.построитьДиаграммуToolStripMenuItem.Click += new System.EventHandler(this.построитьДиаграммуToolStripMenuItem_Click);
            // 
            // создатьАнимациюToolStripMenuItem
            // 
            this.создатьАнимациюToolStripMenuItem.Enabled = false;
            this.создатьАнимациюToolStripMenuItem.Name = "создатьАнимациюToolStripMenuItem";
            this.создатьАнимациюToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.создатьАнимациюToolStripMenuItem.Text = "Создать анимацию";
            // 
            // экспортироватьРезультатыToolStripMenuItem
            // 
            this.экспортироватьРезультатыToolStripMenuItem.Enabled = false;
            this.экспортироватьРезультатыToolStripMenuItem.Name = "экспортироватьРезультатыToolStripMenuItem";
            this.экспортироватьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.экспортироватьРезультатыToolStripMenuItem.Text = "Экспортировать результаты";
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.измеритьToolStripMenuItem,
            this.отзеркаливаниеToolStripMenuItem,
            this.скрытьПлоскостьюToolStripMenuItem});
            this.инструментыToolStripMenuItem.Enabled = false;
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // измеритьToolStripMenuItem
            // 
            this.измеритьToolStripMenuItem.CheckOnClick = true;
            this.измеритьToolStripMenuItem.Name = "измеритьToolStripMenuItem";
            this.измеритьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.измеритьToolStripMenuItem.Text = "Измерить";
            this.измеритьToolStripMenuItem.Click += new System.EventHandler(this.измеритьToolStripMenuItem_Click);
            // 
            // отзеркаливаниеToolStripMenuItem
            // 
            this.отзеркаливаниеToolStripMenuItem.CheckOnClick = true;
            this.отзеркаливаниеToolStripMenuItem.Name = "отзеркаливаниеToolStripMenuItem";
            this.отзеркаливаниеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отзеркаливаниеToolStripMenuItem.Text = "Отзеркаливание";
            this.отзеркаливаниеToolStripMenuItem.Click += new System.EventHandler(this.отзеркаливаниеToolStripMenuItem_Click);
            // 
            // скрытьПлоскостьюToolStripMenuItem
            // 
            this.скрытьПлоскостьюToolStripMenuItem.CheckOnClick = true;
            this.скрытьПлоскостьюToolStripMenuItem.Name = "скрытьПлоскостьюToolStripMenuItem";
            this.скрытьПлоскостьюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.скрытьПлоскостьюToolStripMenuItem.Text = "Скрыть плоскостью";
            this.скрытьПлоскостьюToolStripMenuItem.Click += new System.EventHandler(this.скрытьПлоскостьюToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
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
            this.лицензияToolStripMenuItem.Enabled = false;
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
            this.ClientSize = new System.Drawing.Size(942, 580);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(415, 320);
            this.Name = "BaseForm";
            this.Text = "Bazis. Система инженерного анализа";
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel webPageLabel;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tasksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатыMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBasesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалыMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцииMenuItem;
        private UserControlsEx.SplitContainerEx splitContainer3;
        private UserControlsEx.SplitContainerEx splitContainer1;
        private BaseModule.Navigator.NavigatorControl navigator;
        private BaseModule.PropertiesPanel.PropertiesPanelControl propertiesPanel;
        private UserControlsEx.SplitContainerEx splitContainer2;
        private Tao.Platform.Windows.SimpleOpenGlControl scene;
        private BaseModule.Console.ConsoleControl console;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem создатьГруппуItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьВыбранноеItem;
        private System.Windows.Forms.ToolStripMenuItem показатьСкрытыеItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_InfoSelectedObjects;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetRotPoint;
        private System.Windows.Forms.ToolStripMenuItem menuItem_DeleteSelectedObjects;
        private BaseModule.Player.PlayerControl checkPlayerControl;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripMenuItem открытьToolStripMenuItem1;
        private ToolStripMenuItem добавитьУсловиеToolStripMenuItem;
        private ToolStripMenuItem мастерToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem материалToolStripMenuItem;
        private ToolStripMenuItem средаToolStripMenuItem;
        private ToolStripMenuItem нагревToolStripMenuItem;
        private ToolStripMenuItem закреплениеToolStripMenuItem;
        private ToolStripMenuItem нагрузкаToolStripMenuItem;
        private ToolStripMenuItem трениемСПеремешиваниемToolStripMenuItem;
        private ToolStripMenuItem термообработкаToolStripMenuItem;
        private ToolStripMenuItem расчетыToolStripMenuItem;
        private ToolStripMenuItem сформироватьИнструкцииToolStripMenuItem;
        private ToolStripMenuItem сеткаToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem наToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem1;
        private ToolStripMenuItem dToolStripMenuItem2;
        private ToolStripMenuItem уплотнитьToolStripMenuItem;
        private ToolStripMenuItem наПоверхности3DToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem открытьИнструкцииToolStripMenuItem;
        private ToolStripMenuItem объединитьToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem1;
        private ToolStripMenuItem построитьГрафикToolStripMenuItem;
        private ToolStripMenuItem построитьДиаграммуToolStripMenuItem;
        private ToolStripMenuItem геометрияToolStripMenuItem;
        private ToolStripMenuItem загрузитьgeoToolStripMenuItem;
        private ToolStripMenuItem сформироватьgeoToolStripMenuItem;
        private ToolStripMenuItem наПоверхностиГеометрииToolStripMenuItem;
        private ToolStripMenuItem показатьНаДиаграммеToolStripMenuItem;
        private ToolStripMenuItem запуститьToolStripMenuItem;
        private ToolStripMenuItem остановитьToolStripMenuItem;
        private ToolStripMenuItem создатьАнимациюToolStripMenuItem;
        private ToolStripMenuItem экспортироватьРезультатыToolStripMenuItem;
        private ToolStripMenuItem инструментыToolStripMenuItem;
        private ToolStripMenuItem квадратизацияСуществующейToolStripMenuItem;
        private ToolStripMenuItem измеритьToolStripMenuItem;
        private ToolStripMenuItem отзеркаливаниеToolStripMenuItem;
        private ToolStripMenuItem скрытьПлоскостьюToolStripMenuItem;
        private Button btnAdvSelection;
        private ImageList sceneImageList;
        private Button btnDisplayStates;
        private Button btnRotVert90;
        private Button btnRotHor90;
        private Button btnRotZ;
        private Button btnRotY;
        private Button btnRotX;
        private Button btnZY;
        private Button btnZX;
        private Button btnXY;
        private Button btnDisplayViews;
        private Button btnShowInsideObjects;
        private Button btnFitToScreen;
        private Button btnShowSidesRibs;
        private Button btnShowRibs;
        private Button btnShowSides;
        private Button btnBazis;
        private Button btnBorder;
        private Button btnMakeScreenShot;
        private Button btnSelect;
    }
}

