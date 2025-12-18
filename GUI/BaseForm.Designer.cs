
using BazisGUI.Navigator;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.SettingsControls;
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            toolStripContainer = new ToolStripContainer();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblVersion = new ToolStripStatusLabel();
            webPageLabel = new ToolStripStatusLabel();
            splitContainer3 = new UserControlsEx.SplitContainerEx();
            btnTabНастройки = new Button();
            btnTabГант = new Button();
            btnTabФункции = new Button();
            btnTabМатериалы = new Button();
            btnTabНавигатор = new Button();
            cntrНавигатор = new UserControlsEx.SplitContainerEx();
            navigator = new NavigatorControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            checkPlayerControl = new BazisGUI.Player.PlayerControl();
            propertiesPanel = new BazisGUI.PropertiesPanel.PropertiesPanelControl();
            splitContainer2 = new UserControlsEx.SplitContainerEx();
            btnSelect = new Button();
            btnDisplayStates = new Button();
            btnRotVert90 = new Button();
            sceneImageList = new ImageList(components);
            btnRotHor90 = new Button();
            btnRotZ = new Button();
            btnRotY = new Button();
            btnRotX = new Button();
            btnZY = new Button();
            btnZX = new Button();
            btnXY = new Button();
            btnDisplayViews = new Button();
            btnShowInsideObjects = new Button();
            btnFitToScreen = new Button();
            btnShowSidesRibs = new Button();
            btnShowRibs = new Button();
            btnShowSides = new Button();
            btnBazis = new Button();
            btnBorder = new Button();
            btnMakeScreenShot = new Button();
            btnAdvSelection = new Button();
            scene = new OpenTK.GLControl.GLControl();
            console = new BazisGUI.Console.ConsoleControl();
            menuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитькакToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            viewMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            сеткаToolStripMenuItem = new ToolStripMenuItem();
            загрузитьgeoToolStripMenuItem = new ToolStripMenuItem();
            сформироватьgeoToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripMenuItem();
            наToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem1 = new ToolStripMenuItem();
            уплотнитьToolStripMenuItem = new ToolStripMenuItem();
            наПоверхности3DToolStripMenuItem = new ToolStripMenuItem();
            наПоверхностиГеометрииToolStripMenuItem = new ToolStripMenuItem();
            квадратизацияСуществующейToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem2 = new ToolStripMenuItem();
            dataBasesMenuItem = new ToolStripMenuItem();
            материалыMenuItem = new ToolStripMenuItem();
            функцииMenuItem = new ToolStripMenuItem();
            tasksMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem1 = new ToolStripMenuItem();
            мастерToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            трениемСПеремешиваниемToolStripMenuItem = new ToolStripMenuItem();
            термообработкаToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            загрузитьМастерToolStripMenuItem = new ToolStripMenuItem();
            показатьНаДиаграммеToolStripMenuItem = new ToolStripMenuItem();
            расчетыToolStripMenuItem = new ToolStripMenuItem();
            открытьИнструкцииToolStripMenuItem = new ToolStripMenuItem();
            сформироватьИнструкцииToolStripMenuItem = new ToolStripMenuItem();
            запуститьToolStripMenuItem = new ToolStripMenuItem();
            остановитьToolStripMenuItem = new ToolStripMenuItem();
            результатыMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem1 = new ToolStripMenuItem();
            объединитьToolStripMenuItem = new ToolStripMenuItem();
            построитьГрафикToolStripMenuItem = new ToolStripMenuItem();
            построитьДиаграммуToolStripMenuItem = new ToolStripMenuItem();
            создатьАнимациюToolStripMenuItem = new ToolStripMenuItem();
            экспортироватьРезультатыToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            инструментыToolStripMenuItem = new ToolStripMenuItem();
            измеритьToolStripMenuItem = new ToolStripMenuItem();
            скрытьПлоскостьюToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            содержаниеToolStripMenuItem = new ToolStripMenuItem();
            опрограммеToolStripMenuItem = new ToolStripMenuItem();
            лицензияToolStripMenuItem = new ToolStripMenuItem();
            сведенияMenuItem = new ToolStripMenuItem();
            contextMenu = new ContextMenuStrip(components);
            создатьГруппуItem = new ToolStripMenuItem();
            скрытьВыбранноеItem = new ToolStripMenuItem();
            показатьСкрытыеItem = new ToolStripMenuItem();
            menuItem_InfoSelectedObjects = new ToolStripMenuItem();
            menuItem_SetRotPoint = new ToolStripMenuItem();
            menuItem_DeleteSelectedObjects = new ToolStripMenuItem();
            toolStripContainer.BottomToolStripPanel.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cntrНавигатор).BeginInit();
            cntrНавигатор.Panel1.SuspendLayout();
            cntrНавигатор.Panel2.SuspendLayout();
            cntrНавигатор.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            menuStrip.SuspendLayout();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            toolStripContainer.BottomToolStripPanel.Controls.Add(statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            toolStripContainer.ContentPanel.Controls.Add(splitContainer3);
            toolStripContainer.ContentPanel.Margin = new Padding(2);
            toolStripContainer.ContentPanel.Padding = new Padding(5);
            toolStripContainer.ContentPanel.Size = new System.Drawing.Size(942, 569);
            toolStripContainer.Dock = DockStyle.Fill;
            toolStripContainer.Location = new System.Drawing.Point(0, 0);
            toolStripContainer.Margin = new Padding(2);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new System.Drawing.Size(942, 625);
            toolStripContainer.TabIndex = 0;
            toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            toolStripContainer.TopToolStripPanel.Controls.Add(menuStrip);
            toolStripContainer.TopToolStripPanel.Padding = new Padding(2, 0, 0, 0);
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Dock = DockStyle.None;
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblVersion, webPageLabel });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(942, 32);
            statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = false;
            lblStatus.BackColor = System.Drawing.SystemColors.Control;
            lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblStatus.Margin = new Padding(5, 3, 0, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(817, 27);
            lblStatus.Spring = true;
            lblStatus.Text = "Создайте или загрузите проект или сетку";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            lblVersion.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            lblVersion.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(4, 27);
            // 
            // webPageLabel
            // 
            webPageLabel.BackColor = System.Drawing.SystemColors.Control;
            webPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            webPageLabel.IsLink = true;
            webPageLabel.LinkColor = System.Drawing.Color.OrangeRed;
            webPageLabel.Name = "webPageLabel";
            webPageLabel.Size = new System.Drawing.Size(101, 27);
            webPageLabel.Text = "www.bazisnet.ru";
            webPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            webPageLabel.Click += webPageLabel_Click;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.IncrementButtonSize = new System.Drawing.Size(50, 5);
            splitContainer3.IncrementShifting = 50;
            splitContainer3.Location = new System.Drawing.Point(5, 5);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(btnTabНастройки);
            splitContainer3.Panel1.Controls.Add(btnTabГант);
            splitContainer3.Panel1.Controls.Add(btnTabФункции);
            splitContainer3.Panel1.Controls.Add(btnTabМатериалы);
            splitContainer3.Panel1.Controls.Add(btnTabНавигатор);
            splitContainer3.Panel1.Controls.Add(cntrНавигатор);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer2);
            splitContainer3.Size = new System.Drawing.Size(932, 559);
            splitContainer3.SplitterDistance = 304;
            splitContainer3.SplitterWidth = 8;
            splitContainer3.SwitchShifting = false;
            splitContainer3.TabIndex = 0;
            // 
            // btnTabНастройки
            // 
            btnTabНастройки.FlatStyle = FlatStyle.Flat;
            btnTabНастройки.Location = new System.Drawing.Point(0, 532);
            btnTabНастройки.Margin = new Padding(0, 0, 3, 3);
            btnTabНастройки.Name = "btnTabНастройки";
            btnTabНастройки.Size = new System.Drawing.Size(27, 130);
            btnTabНастройки.TabIndex = 1;
            btnTabНастройки.Tag = "True";
            btnTabНастройки.UseVisualStyleBackColor = true;
            btnTabНастройки.Visible = false;
            btnTabНастройки.Paint += buttonTab_Paint;
            btnTabНастройки.MouseDown += button_MouseDown;
            // 
            // btnTabГант
            // 
            btnTabГант.FlatStyle = FlatStyle.Flat;
            btnTabГант.Location = new System.Drawing.Point(0, 399);
            btnTabГант.Margin = new Padding(0, 0, 3, 3);
            btnTabГант.Name = "btnTabГант";
            btnTabГант.Size = new System.Drawing.Size(27, 130);
            btnTabГант.TabIndex = 1;
            btnTabГант.Tag = "True";
            btnTabГант.UseVisualStyleBackColor = true;
            btnTabГант.Visible = false;
            btnTabГант.Paint += buttonTab_Paint;
            btnTabГант.MouseDown += button_MouseDown;
            // 
            // btnTabФункции
            // 
            btnTabФункции.FlatStyle = FlatStyle.Flat;
            btnTabФункции.Location = new System.Drawing.Point(0, 266);
            btnTabФункции.Margin = new Padding(0, 0, 3, 3);
            btnTabФункции.Name = "btnTabФункции";
            btnTabФункции.Size = new System.Drawing.Size(27, 130);
            btnTabФункции.TabIndex = 1;
            btnTabФункции.Tag = "True";
            btnTabФункции.UseVisualStyleBackColor = true;
            btnTabФункции.Visible = false;
            btnTabФункции.Paint += buttonTab_Paint;
            btnTabФункции.MouseDown += button_MouseDown;
            // 
            // btnTabМатериалы
            // 
            btnTabМатериалы.FlatStyle = FlatStyle.Flat;
            btnTabМатериалы.Location = new System.Drawing.Point(0, 133);
            btnTabМатериалы.Margin = new Padding(0, 0, 3, 3);
            btnTabМатериалы.Name = "btnTabМатериалы";
            btnTabМатериалы.Size = new System.Drawing.Size(27, 130);
            btnTabМатериалы.TabIndex = 1;
            btnTabМатериалы.Tag = "True";
            btnTabМатериалы.UseVisualStyleBackColor = true;
            btnTabМатериалы.Visible = false;
            btnTabМатериалы.Paint += buttonTab_Paint;
            btnTabМатериалы.MouseDown += button_MouseDown;
            // 
            // btnTabНавигатор
            // 
            btnTabНавигатор.FlatStyle = FlatStyle.Flat;
            btnTabНавигатор.Location = new System.Drawing.Point(0, 0);
            btnTabНавигатор.Margin = new Padding(0, 0, 3, 3);
            btnTabНавигатор.Name = "btnTabНавигатор";
            btnTabНавигатор.Size = new System.Drawing.Size(27, 130);
            btnTabНавигатор.TabIndex = 1;
            btnTabНавигатор.Tag = "True";
            btnTabНавигатор.UseVisualStyleBackColor = true;
            btnTabНавигатор.Paint += buttonTab_Paint;
            btnTabНавигатор.MouseDown += button_MouseDown;
            // 
            // cntrНавигатор
            // 
            cntrНавигатор.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cntrНавигатор.IncrementButtonSize = new System.Drawing.Size(50, 5);
            cntrНавигатор.IncrementShifting = 50;
            cntrНавигатор.Location = new System.Drawing.Point(30, 0);
            cntrНавигатор.Margin = new Padding(26, 0, 0, 0);
            cntrНавигатор.Name = "cntrНавигатор";
            cntrНавигатор.Orientation = Orientation.Horizontal;
            // 
            // cntrНавигатор.Panel1
            // 
            cntrНавигатор.Panel1.Controls.Add(navigator);
            // 
            // cntrНавигатор.Panel2
            // 
            cntrНавигатор.Panel2.Controls.Add(tableLayoutPanel1);
            cntrНавигатор.Size = new System.Drawing.Size(274, 559);
            cntrНавигатор.SplitterDistance = 298;
            cntrНавигатор.SplitterWidth = 8;
            cntrНавигатор.SwitchShifting = false;
            cntrНавигатор.TabIndex = 0;
            // 
            // navigator
            // 
            navigator.BackColor = System.Drawing.Color.Gainsboro;
            navigator.BorderStyle = BorderStyle.FixedSingle;
            navigator.CollapseIndex = 7;
            navigator.Dock = DockStyle.Fill;
            navigator.DownColor = System.Drawing.Color.Gainsboro;
            navigator.DrawNodeFrozen = false;
            navigator.ExpandIndex = 8;
            navigator.HeaderColor = System.Drawing.Color.Black;
            navigator.HeaderName = "Навигатор";
            navigator.IsPinndable = false;
            navigator.Location = new System.Drawing.Point(0, 0);
            navigator.Margin = new Padding(0, 5, 5, 0);
            navigator.Name = "navigator";
            navigator.Padding = new Padding(0, 15, 0, 0);
            navigator.ProjectInfoIndex = 0;
            navigator.Size = new System.Drawing.Size(274, 298);
            navigator.TabIndex = 0;
            navigator.UpColor = System.Drawing.Color.Gainsboro;
            navigator.HideResultsEvent += navigator_HideResultsEvent;
            navigator.RemoveResultsEvent += navigator_RemoveResultsEvent;
            navigator.RemoveAllConditionsEvent += navigator_RemoveAllConditionsEvent;
            navigator.DelAllGroupsEvent += navigator_DelAllGroupsEvent;
            navigator.ShowAllGroupsEvent += navigator_ShowAllGroupsEvent;
            navigator.HideAllGroupsEvent += navigator_HideAllGroupsEvent;
            navigator.ChangeAllGeoViewStateEvent += navigator_ChangeAllObjectsViewStateEvent;
            navigator.DelAllGeoEvent += navigator_DelAllObjectsEvent;
            navigator.DelAllMeshEvent += navigator_DelAllObjectsEvent;
            navigator.ChangeAllMeshViewStateEvent += navigator_ChangeAllObjectsViewStateEvent;
            navigator.ShowSetEvent += navigator_ShowSetEvent;
            navigator.HideSetEvent += navigator_HideSetEvent;
            navigator.DelSetEvent += navigator_DelSetEvent;
            navigator.SelectSetEvent += navigator_SelectSetEvent;
            navigator.GetSetsInfoEvent += navigator_GetSetsInfoEvent;
            navigator.SelectGroupEvent += navigator_SelectGroupEvent;
            navigator.DelGroupEvent += navigator_DelGroupEvent;
            navigator.HideGroupEvent += navigator_HideGroupEvent;
            navigator.ShowGroupEvent += navigator_ShowGroupEvent;
            navigator.EditGroupEvent += EditGroup;
            navigator.InfoGroupEvent += navigator_InfoGroupEvent;
            navigator.GetObjectsInfoEvent += navigator_GetObjectsInfoEvent;
            navigator.SelectObjectEvent += navigator_SelectObjectEvent;
            navigator.ShowObjectEvent += navigator_ShowObjectEvent;
            navigator.HideObjectEvent += navigator_HideObjectEvent;
            navigator.SelectCondEvent += navigator_SelectCondEvent;
            navigator.SelectTaskEvent += navigator_SelectTaskEvent;
            navigator.SelectGeoEvent += navigator_SelectGeoEvent;
            navigator.SelectMeshEvent += navigator_SelectMeshEvent;
            navigator.SelectResultsEvent += navigator_SelectResultsEvent;
            navigator.SelectCompEvent += Navigator_SelectCompEvent;
            navigator.SelectCompsEvent += Navigator_SelectCompsEvent;
            navigator.SelectGeneralInfoEvent += navigator_SelectGeneralInfoEvent;
            navigator.SelectTimeEvent += navigator_SelectTimeEvent;
            navigator.SelectResultEvent += navigator_SelectResultEvent;
            navigator.GetResultInfoEvent += navigator_GetResultInfoEvent;
            navigator.DelCondEvent += navigator_DelCondEvent;
            navigator.ControlCollapseEvent += navigator_ControlCollapseEvent;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(checkPlayerControl, 0, 1);
            tableLayoutPanel1.Controls.Add(propertiesPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(274, 253);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // checkPlayerControl
            // 
            checkPlayerControl.AutoSize = true;
            checkPlayerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            checkPlayerControl.BorderStyle = BorderStyle.FixedSingle;
            checkPlayerControl.Cancelation = false;
            checkPlayerControl.CheckState = Player.CheckState.start;
            checkPlayerControl.CurrentValue = 50;
            checkPlayerControl.Dock = DockStyle.Fill;
            checkPlayerControl.Location = new System.Drawing.Point(0, 218);
            checkPlayerControl.Margin = new Padding(0);
            checkPlayerControl.MinimumSize = new System.Drawing.Size(215, 35);
            checkPlayerControl.Name = "checkPlayerControl";
            checkPlayerControl.ShowTextValue = true;
            checkPlayerControl.Size = new System.Drawing.Size(274, 35);
            checkPlayerControl.SliderBarInnerColor = System.Drawing.Color.Silver;
            checkPlayerControl.SliderBarOuterColor = System.Drawing.Color.Silver;
            checkPlayerControl.SliderElapsedInnerColor = System.Drawing.Color.Silver;
            checkPlayerControl.SliderElapsedOuterColor = System.Drawing.Color.Silver;
            checkPlayerControl.SpeedValue = 500;
            checkPlayerControl.StartValue = 0;
            checkPlayerControl.StopValue = 100;
            checkPlayerControl.TabIndex = 2;
            checkPlayerControl.TextValueColor = System.Drawing.Color.Black;
            checkPlayerControl.CheckingEvent += checkPlayerControl_CheckingEvent;
            checkPlayerControl.StopCheckingEvent += checkPlayerControl_StopCheckingEvent;
            checkPlayerControl.StartCheckingEvent += checkPlayerControl_StartCheckingEvent;
            // 
            // propertiesPanel
            // 
            propertiesPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            propertiesPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            propertiesPanel.BorderStyle = BorderStyle.FixedSingle;
            propertiesPanel.Dock = DockStyle.Fill;
            propertiesPanel.DownColor = System.Drawing.Color.Gainsboro;
            propertiesPanel.HeaderColor = System.Drawing.Color.Black;
            propertiesPanel.HeaderName = "Свойства";
            propertiesPanel.IsPinndable = false;
            propertiesPanel.Location = new System.Drawing.Point(0, 0);
            propertiesPanel.Margin = new Padding(0, 0, 0, 8);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Padding = new Padding(0, 15, 0, 0);
            propertiesPanel.Size = new System.Drawing.Size(274, 210);
            propertiesPanel.TabIndex = 0;
            propertiesPanel.UpColor = System.Drawing.Color.Gainsboro;
            propertiesPanel.PropertyUpdateEvent += propertiesPanel_OnPropertyUpdate;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IncrementButtonSize = new System.Drawing.Size(50, 5);
            splitContainer2.IncrementShifting = 50;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnSelect);
            splitContainer2.Panel1.Controls.Add(btnDisplayStates);
            splitContainer2.Panel1.Controls.Add(btnRotVert90);
            splitContainer2.Panel1.Controls.Add(btnRotHor90);
            splitContainer2.Panel1.Controls.Add(btnRotZ);
            splitContainer2.Panel1.Controls.Add(btnRotY);
            splitContainer2.Panel1.Controls.Add(btnRotX);
            splitContainer2.Panel1.Controls.Add(btnZY);
            splitContainer2.Panel1.Controls.Add(btnZX);
            splitContainer2.Panel1.Controls.Add(btnXY);
            splitContainer2.Panel1.Controls.Add(btnDisplayViews);
            splitContainer2.Panel1.Controls.Add(btnShowInsideObjects);
            splitContainer2.Panel1.Controls.Add(btnFitToScreen);
            splitContainer2.Panel1.Controls.Add(btnShowSidesRibs);
            splitContainer2.Panel1.Controls.Add(btnShowRibs);
            splitContainer2.Panel1.Controls.Add(btnShowSides);
            splitContainer2.Panel1.Controls.Add(btnBazis);
            splitContainer2.Panel1.Controls.Add(btnBorder);
            splitContainer2.Panel1.Controls.Add(btnMakeScreenShot);
            splitContainer2.Panel1.Controls.Add(btnAdvSelection);
            splitContainer2.Panel1.Controls.Add(scene);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(console);
            splitContainer2.Size = new System.Drawing.Size(620, 559);
            splitContainer2.SplitterDistance = 411;
            splitContainer2.SplitterWidth = 8;
            splitContainer2.SwitchShifting = false;
            splitContainer2.TabIndex = 0;
            // 
            // btnSelect
            // 
            btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Image = Properties.Resources.arrow_r;
            btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSelect.Location = new System.Drawing.Point(3, 3);
            btnSelect.Margin = new Padding(3, 3, 2, 0);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(108, 27);
            btnSelect.TabIndex = 5;
            btnSelect.Tag = "False";
            btnSelect.Text = "Выбрать";
            btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            btnSelect.Leave += btnSelect_Leave;
            // 
            // btnDisplayStates
            // 
            btnDisplayStates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisplayStates.Enabled = false;
            btnDisplayStates.FlatStyle = FlatStyle.Flat;
            btnDisplayStates.Image = Properties.Resources.arrow_d;
            btnDisplayStates.Location = new System.Drawing.Point(421, 3);
            btnDisplayStates.Margin = new Padding(6, 4, 6, 4);
            btnDisplayStates.Name = "btnDisplayStates";
            btnDisplayStates.Size = new System.Drawing.Size(18, 27);
            btnDisplayStates.TabIndex = 4;
            btnDisplayStates.Tag = "False";
            btnDisplayStates.UseVisualStyleBackColor = true;
            btnDisplayStates.Click += btnDisplayStates_Click;
            // 
            // btnRotVert90
            // 
            btnRotVert90.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRotVert90.FlatStyle = FlatStyle.Flat;
            btnRotVert90.ImageIndex = 8;
            btnRotVert90.ImageList = sceneImageList;
            btnRotVert90.Location = new System.Drawing.Point(589, 253);
            btnRotVert90.Margin = new Padding(3, 3, 4, 0);
            btnRotVert90.Name = "btnRotVert90";
            btnRotVert90.Size = new System.Drawing.Size(27, 27);
            btnRotVert90.TabIndex = 3;
            btnRotVert90.UseVisualStyleBackColor = true;
            btnRotVert90.Visible = false;
            btnRotVert90.Click += btnRotVert90_Click;
            // 
            // sceneImageList
            // 
            sceneImageList.ColorDepth = ColorDepth.Depth8Bit;
            sceneImageList.ImageStream = (ImageListStreamer)resources.GetObject("sceneImageList.ImageStream");
            sceneImageList.TransparentColor = System.Drawing.Color.Transparent;
            sceneImageList.Images.SetKeyName(0, "вп 12.png");
            sceneImageList.Images.SetKeyName(1, "вп 25.png");
            sceneImageList.Images.SetKeyName(2, "вп 26.png");
            sceneImageList.Images.SetKeyName(3, "вп 27.png");
            sceneImageList.Images.SetKeyName(4, "вп 28.png");
            sceneImageList.Images.SetKeyName(5, "вп 29.png");
            sceneImageList.Images.SetKeyName(6, "вп 30.png");
            sceneImageList.Images.SetKeyName(7, "вп 31.png");
            sceneImageList.Images.SetKeyName(8, "вп 32.png");
            sceneImageList.Images.SetKeyName(9, "вп 16.png");
            sceneImageList.Images.SetKeyName(10, "вп 17.png");
            sceneImageList.Images.SetKeyName(11, "вп 18.png");
            sceneImageList.Images.SetKeyName(12, "вп 21.png");
            sceneImageList.Images.SetKeyName(13, "вп 24.png");
            sceneImageList.Images.SetKeyName(14, "вп 33.png");
            sceneImageList.Images.SetKeyName(15, "вп 19.png");
            sceneImageList.Images.SetKeyName(16, "вп 21.png");
            sceneImageList.Images.SetKeyName(17, "вп 14.png");
            // 
            // btnRotHor90
            // 
            btnRotHor90.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRotHor90.FlatStyle = FlatStyle.Flat;
            btnRotHor90.ImageIndex = 7;
            btnRotHor90.ImageList = sceneImageList;
            btnRotHor90.Location = new System.Drawing.Point(589, 223);
            btnRotHor90.Margin = new Padding(3, 3, 4, 0);
            btnRotHor90.Name = "btnRotHor90";
            btnRotHor90.Size = new System.Drawing.Size(27, 27);
            btnRotHor90.TabIndex = 3;
            btnRotHor90.UseVisualStyleBackColor = true;
            btnRotHor90.Visible = false;
            btnRotHor90.Click += btnRotHor90_Click;
            // 
            // btnRotZ
            // 
            btnRotZ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRotZ.FlatStyle = FlatStyle.Flat;
            btnRotZ.ImageIndex = 6;
            btnRotZ.ImageList = sceneImageList;
            btnRotZ.Location = new System.Drawing.Point(589, 193);
            btnRotZ.Margin = new Padding(3, 3, 4, 0);
            btnRotZ.Name = "btnRotZ";
            btnRotZ.Size = new System.Drawing.Size(27, 27);
            btnRotZ.TabIndex = 3;
            btnRotZ.Tag = "False";
            btnRotZ.UseVisualStyleBackColor = true;
            btnRotZ.Visible = false;
            btnRotZ.Click += btnRotZ_Click;
            btnRotZ.Paint += btnRot_Paint;
            // 
            // btnRotY
            // 
            btnRotY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRotY.FlatStyle = FlatStyle.Flat;
            btnRotY.ImageIndex = 5;
            btnRotY.ImageList = sceneImageList;
            btnRotY.Location = new System.Drawing.Point(589, 163);
            btnRotY.Margin = new Padding(3, 3, 4, 0);
            btnRotY.Name = "btnRotY";
            btnRotY.Size = new System.Drawing.Size(27, 27);
            btnRotY.TabIndex = 3;
            btnRotY.Tag = "False";
            btnRotY.UseVisualStyleBackColor = true;
            btnRotY.Visible = false;
            btnRotY.Click += btnRotY_Click;
            btnRotY.Paint += btnRot_Paint;
            // 
            // btnRotX
            // 
            btnRotX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRotX.FlatStyle = FlatStyle.Flat;
            btnRotX.ImageIndex = 4;
            btnRotX.ImageList = sceneImageList;
            btnRotX.Location = new System.Drawing.Point(589, 133);
            btnRotX.Margin = new Padding(3, 3, 4, 0);
            btnRotX.Name = "btnRotX";
            btnRotX.Size = new System.Drawing.Size(27, 27);
            btnRotX.TabIndex = 3;
            btnRotX.Tag = "False";
            btnRotX.UseVisualStyleBackColor = true;
            btnRotX.Visible = false;
            btnRotX.Click += btnRotX_Click;
            btnRotX.Paint += btnRot_Paint;
            // 
            // btnZY
            // 
            btnZY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnZY.FlatStyle = FlatStyle.Flat;
            btnZY.ImageIndex = 3;
            btnZY.ImageList = sceneImageList;
            btnZY.Location = new System.Drawing.Point(589, 103);
            btnZY.Margin = new Padding(3, 3, 4, 0);
            btnZY.Name = "btnZY";
            btnZY.Size = new System.Drawing.Size(27, 27);
            btnZY.TabIndex = 3;
            btnZY.UseVisualStyleBackColor = true;
            btnZY.Visible = false;
            btnZY.Click += btnZY_Click;
            // 
            // btnZX
            // 
            btnZX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnZX.FlatStyle = FlatStyle.Flat;
            btnZX.ImageIndex = 2;
            btnZX.ImageList = sceneImageList;
            btnZX.Location = new System.Drawing.Point(589, 73);
            btnZX.Margin = new Padding(3, 3, 4, 0);
            btnZX.Name = "btnZX";
            btnZX.Size = new System.Drawing.Size(27, 27);
            btnZX.TabIndex = 3;
            btnZX.UseVisualStyleBackColor = true;
            btnZX.Visible = false;
            btnZX.Click += btnZX_Click;
            // 
            // btnXY
            // 
            btnXY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXY.FlatStyle = FlatStyle.Flat;
            btnXY.ImageIndex = 1;
            btnXY.ImageList = sceneImageList;
            btnXY.Location = new System.Drawing.Point(589, 43);
            btnXY.Margin = new Padding(4, 4, 4, 0);
            btnXY.Name = "btnXY";
            btnXY.Size = new System.Drawing.Size(27, 27);
            btnXY.TabIndex = 3;
            btnXY.UseVisualStyleBackColor = true;
            btnXY.Visible = false;
            btnXY.Click += btnXY_Click;
            // 
            // btnDisplayViews
            // 
            btnDisplayViews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisplayViews.Enabled = false;
            btnDisplayViews.FlatStyle = FlatStyle.Flat;
            btnDisplayViews.Image = Properties.Resources.arrow_r;
            btnDisplayViews.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnDisplayViews.Location = new System.Drawing.Point(541, 3);
            btnDisplayViews.Margin = new Padding(3, 4, 24, 4);
            btnDisplayViews.Name = "btnDisplayViews";
            btnDisplayViews.Size = new System.Drawing.Size(55, 27);
            btnDisplayViews.TabIndex = 3;
            btnDisplayViews.Tag = "False";
            btnDisplayViews.Text = "Вид";
            btnDisplayViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDisplayViews.UseVisualStyleBackColor = true;
            btnDisplayViews.Click += btnDisplayViews_Click;
            // 
            // btnShowInsideObjects
            // 
            btnShowInsideObjects.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowInsideObjects.Enabled = false;
            btnShowInsideObjects.FlatStyle = FlatStyle.Flat;
            btnShowInsideObjects.ImageIndex = 17;
            btnShowInsideObjects.ImageList = sceneImageList;
            btnShowInsideObjects.Location = new System.Drawing.Point(508, 3);
            btnShowInsideObjects.Margin = new Padding(0, 4, 3, 4);
            btnShowInsideObjects.Name = "btnShowInsideObjects";
            btnShowInsideObjects.Size = new System.Drawing.Size(27, 27);
            btnShowInsideObjects.TabIndex = 3;
            btnShowInsideObjects.Tag = "False";
            btnShowInsideObjects.UseVisualStyleBackColor = true;
            btnShowInsideObjects.Click += btnShowInsideObjects_Click;
            // 
            // btnFitToScreen
            // 
            btnFitToScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFitToScreen.Enabled = false;
            btnFitToScreen.FlatStyle = FlatStyle.Flat;
            btnFitToScreen.ImageIndex = 14;
            btnFitToScreen.ImageList = sceneImageList;
            btnFitToScreen.Location = new System.Drawing.Point(478, 3);
            btnFitToScreen.Margin = new Padding(0, 3, 3, 3);
            btnFitToScreen.Name = "btnFitToScreen";
            btnFitToScreen.Size = new System.Drawing.Size(27, 27);
            btnFitToScreen.TabIndex = 3;
            btnFitToScreen.UseVisualStyleBackColor = true;
            btnFitToScreen.Click += btnFitToScreen_Click;
            // 
            // btnShowSidesRibs
            // 
            btnShowSidesRibs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowSidesRibs.BackColor = System.Drawing.SystemColors.Control;
            btnShowSidesRibs.FlatStyle = FlatStyle.Flat;
            btnShowSidesRibs.ImageIndex = 9;
            btnShowSidesRibs.ImageList = sceneImageList;
            btnShowSidesRibs.Location = new System.Drawing.Point(265, 3);
            btnShowSidesRibs.Margin = new Padding(0, 3, 3, 3);
            btnShowSidesRibs.Name = "btnShowSidesRibs";
            btnShowSidesRibs.Size = new System.Drawing.Size(27, 27);
            btnShowSidesRibs.TabIndex = 3;
            btnShowSidesRibs.UseVisualStyleBackColor = false;
            btnShowSidesRibs.Visible = false;
            btnShowSidesRibs.Click += btnShowSidesRibs_Click;
            // 
            // btnShowRibs
            // 
            btnShowRibs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowRibs.BackColor = System.Drawing.SystemColors.Control;
            btnShowRibs.FlatStyle = FlatStyle.Flat;
            btnShowRibs.ImageIndex = 10;
            btnShowRibs.ImageList = sceneImageList;
            btnShowRibs.Location = new System.Drawing.Point(295, 3);
            btnShowRibs.Margin = new Padding(0, 3, 3, 3);
            btnShowRibs.Name = "btnShowRibs";
            btnShowRibs.Size = new System.Drawing.Size(27, 27);
            btnShowRibs.TabIndex = 3;
            btnShowRibs.UseVisualStyleBackColor = false;
            btnShowRibs.Visible = false;
            btnShowRibs.Click += btnShowRibs_Click;
            // 
            // btnShowSides
            // 
            btnShowSides.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowSides.FlatStyle = FlatStyle.Flat;
            btnShowSides.ImageIndex = 11;
            btnShowSides.ImageList = sceneImageList;
            btnShowSides.Location = new System.Drawing.Point(325, 3);
            btnShowSides.Margin = new Padding(0, 3, 3, 3);
            btnShowSides.Name = "btnShowSides";
            btnShowSides.Size = new System.Drawing.Size(27, 27);
            btnShowSides.TabIndex = 3;
            btnShowSides.UseVisualStyleBackColor = true;
            btnShowSides.Visible = false;
            btnShowSides.Click += btnShowSides_Click;
            // 
            // btnBazis
            // 
            btnBazis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBazis.FlatStyle = FlatStyle.Flat;
            btnBazis.ImageIndex = 15;
            btnBazis.ImageList = sceneImageList;
            btnBazis.Location = new System.Drawing.Point(355, 3);
            btnBazis.Margin = new Padding(0, 3, 3, 3);
            btnBazis.Name = "btnBazis";
            btnBazis.Size = new System.Drawing.Size(27, 27);
            btnBazis.TabIndex = 3;
            btnBazis.Tag = "False";
            btnBazis.UseVisualStyleBackColor = true;
            btnBazis.Visible = false;
            btnBazis.Click += btnBazis_Click;
            btnBazis.Paint += btnBazis_Paint;
            // 
            // btnBorder
            // 
            btnBorder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBorder.FlatStyle = FlatStyle.Flat;
            btnBorder.ImageIndex = 16;
            btnBorder.ImageList = sceneImageList;
            btnBorder.Location = new System.Drawing.Point(385, 3);
            btnBorder.Margin = new Padding(0, 3, 3, 3);
            btnBorder.Name = "btnBorder";
            btnBorder.Size = new System.Drawing.Size(27, 27);
            btnBorder.TabIndex = 3;
            btnBorder.Tag = "False";
            btnBorder.UseVisualStyleBackColor = true;
            btnBorder.Visible = false;
            btnBorder.Click += btnBorder_Click;
            // 
            // btnMakeScreenShot
            // 
            btnMakeScreenShot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMakeScreenShot.Enabled = false;
            btnMakeScreenShot.FlatStyle = FlatStyle.Flat;
            btnMakeScreenShot.ImageIndex = 13;
            btnMakeScreenShot.ImageList = sceneImageList;
            btnMakeScreenShot.Location = new System.Drawing.Point(448, 3);
            btnMakeScreenShot.Name = "btnMakeScreenShot";
            btnMakeScreenShot.Size = new System.Drawing.Size(27, 27);
            btnMakeScreenShot.TabIndex = 3;
            btnMakeScreenShot.UseVisualStyleBackColor = true;
            btnMakeScreenShot.Click += btnMakeScreenShot_Click;
            // 
            // btnAdvSelection
            // 
            btnAdvSelection.Enabled = false;
            btnAdvSelection.FlatStyle = FlatStyle.Flat;
            btnAdvSelection.ImageIndex = 0;
            btnAdvSelection.ImageList = sceneImageList;
            btnAdvSelection.Location = new System.Drawing.Point(114, 3);
            btnAdvSelection.Margin = new Padding(1, 8, 4, 4);
            btnAdvSelection.Name = "btnAdvSelection";
            btnAdvSelection.Size = new System.Drawing.Size(27, 27);
            btnAdvSelection.TabIndex = 3;
            btnAdvSelection.Tag = "False";
            btnAdvSelection.UseVisualStyleBackColor = true;
            btnAdvSelection.Click += btnAdvSelection_Click;
            btnAdvSelection.Paint += btnSelection_Paint;
            // 
            // scene
            // 
            scene.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            scene.APIVersion = new Version(3, 3, 0, 0);
            scene.BackColor = System.Drawing.Color.Silver;
            scene.Dock = DockStyle.Fill;
            scene.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            scene.IsEventDriven = true;
            scene.Location = new System.Drawing.Point(0, 0);
            scene.Margin = new Padding(0);
            scene.Name = "scene";
            scene.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            scene.SharedContext = null;
            scene.Size = new System.Drawing.Size(620, 411);
            scene.TabIndex = 1;
            scene.KeyDown += GlControl_KeyDown;
            scene.MouseWheel += GlControl_MouseWheel;
            // 
            // console
            // 
            console.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            console.BorderStyle = BorderStyle.FixedSingle;
            console.CheckPrintElemsInfo = false;
            console.CheckPrintNodesInfo = false;
            console.Dock = DockStyle.Fill;
            console.DownColor = System.Drawing.Color.Gainsboro;
            console.Enabled = false;
            console.HeaderColor = System.Drawing.Color.Black;
            console.HeaderName = "Консоль";
            console.IsPinndable = false;
            console.Location = new System.Drawing.Point(0, 0);
            console.Margin = new Padding(0);
            console.Name = "console";
            console.Padding = new Padding(0, 15, 0, 0);
            console.Size = new System.Drawing.Size(620, 140);
            console.TabIndex = 0;
            console.UpColor = System.Drawing.Color.Gainsboro;
            console.InEvent += console_InEvent;
            console.FindFreeNodesEvent += console_FindFreeNodesEvent;
            console.RenumberMeshEvent += console_RenumberMeshEvent;
            console.ModelShiftCoordinateEvent += console_ModelShiftCoordinateEvent;
            console.ModelRotateEvent += console_ModelRotateEvent;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = System.Drawing.SystemColors.Control;
            menuStrip.Dock = DockStyle.None;
            menuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, viewMenuItem, сеткаToolStripMenuItem, dataBasesMenuItem, tasksMenuItem, расчетыToolStripMenuItem, результатыMenuItem, инструментыToolStripMenuItem, настройкиToolStripMenuItem, справкаToolStripMenuItem, лицензияToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Size = new System.Drawing.Size(942, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, добавитьToolStripMenuItem, toolStripSeparator, сохранитьToolStripMenuItem, сохранитькакToolStripMenuItem, toolStripSeparator1, toolStripSeparator2, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            файлToolStripMenuItem.Text = "&Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("создатьToolStripMenuItem.Image");
            создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            создатьToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            создатьToolStripMenuItem.Text = "&Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("открытьToolStripMenuItem.Image");
            открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            открытьToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            открытьToolStripMenuItem.Text = "&Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            добавитьToolStripMenuItem.Text = "Добавить";
            добавитьToolStripMenuItem.Click += добавитьСеткуToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(171, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("сохранитьToolStripMenuItem.Image");
            сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            сохранитьToolStripMenuItem.Text = "&Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // сохранитькакToolStripMenuItem
            // 
            сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            сохранитькакToolStripMenuItem.Click += сохранитькакToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            выходToolStripMenuItem.Text = "Вы&ход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // viewMenuItem
            // 
            viewMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            viewMenuItem.Name = "viewMenuItem";
            viewMenuItem.Size = new System.Drawing.Size(38, 20);
            viewMenuItem.Text = "Вид";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            toolStripMenuItem2.Text = "Навигатор";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(131, 22);
            toolStripMenuItem3.Text = "Консоль";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // сеткаToolStripMenuItem
            // 
            сеткаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { загрузитьgeoToolStripMenuItem, сформироватьgeoToolStripMenuItem, dToolStripMenuItem, dToolStripMenuItem1, dToolStripMenuItem2 });
            сеткаToolStripMenuItem.Enabled = false;
            сеткаToolStripMenuItem.Name = "сеткаToolStripMenuItem";
            сеткаToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            сеткаToolStripMenuItem.Text = "Сетка";
            // 
            // загрузитьgeoToolStripMenuItem
            // 
            загрузитьgeoToolStripMenuItem.Name = "загрузитьgeoToolStripMenuItem";
            загрузитьgeoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            загрузитьgeoToolStripMenuItem.Text = "Загрузить *.gscript";
            загрузитьgeoToolStripMenuItem.Click += загрузитьgeoToolStripMenuItem_Click;
            // 
            // сформироватьgeoToolStripMenuItem
            // 
            сформироватьgeoToolStripMenuItem.Name = "сформироватьgeoToolStripMenuItem";
            сформироватьgeoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            сформироватьgeoToolStripMenuItem.Text = "Сформировать *.gscript";
            сформироватьgeoToolStripMenuItem.Click += сформироватьgeoToolStripMenuItem_Click;
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { наToolStripMenuItem });
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            dToolStripMenuItem.Text = "1D";
            // 
            // наToolStripMenuItem
            // 
            наToolStripMenuItem.Name = "наToolStripMenuItem";
            наToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            наToolStripMenuItem.Text = "На границах 2D элементов";
            наToolStripMenuItem.Click += наПоверхности2DToolStripMenuItem_Click;
            // 
            // dToolStripMenuItem1
            // 
            dToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { уплотнитьToolStripMenuItem, наПоверхности3DToolStripMenuItem, наПоверхностиГеометрииToolStripMenuItem, квадратизацияСуществующейToolStripMenuItem });
            dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            dToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            dToolStripMenuItem1.Text = "2D";
            // 
            // уплотнитьToolStripMenuItem
            // 
            уплотнитьToolStripMenuItem.Enabled = false;
            уплотнитьToolStripMenuItem.Name = "уплотнитьToolStripMenuItem";
            уплотнитьToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            уплотнитьToolStripMenuItem.Text = "Уплотнить существующую";
            уплотнитьToolStripMenuItem.Click += уплотнитьToolStripMenuItem_Click;
            // 
            // наПоверхности3DToolStripMenuItem
            // 
            наПоверхности3DToolStripMenuItem.Name = "наПоверхности3DToolStripMenuItem";
            наПоверхности3DToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            наПоверхности3DToolStripMenuItem.Text = "На открытых 3D элементах";
            наПоверхности3DToolStripMenuItem.Click += наПоверхности3DToolStripMenuItem_Click;
            // 
            // наПоверхностиГеометрииToolStripMenuItem
            // 
            наПоверхностиГеометрииToolStripMenuItem.Name = "наПоверхностиГеометрииToolStripMenuItem";
            наПоверхностиГеометрииToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            наПоверхностиГеометрииToolStripMenuItem.Text = "На поверхностях геометрии";
            наПоверхностиГеометрииToolStripMenuItem.Click += наПоверхностиГеометрииToolStripMenuItem_Click;
            // 
            // квадратизацияСуществующейToolStripMenuItem
            // 
            квадратизацияСуществующейToolStripMenuItem.Enabled = false;
            квадратизацияСуществующейToolStripMenuItem.Name = "квадратизацияСуществующейToolStripMenuItem";
            квадратизацияСуществующейToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            квадратизацияСуществующейToolStripMenuItem.Text = "Квадратизация существующей";
            квадратизацияСуществующейToolStripMenuItem.Click += квадратизацияСуществующейToolStripMenuItem_Click;
            // 
            // dToolStripMenuItem2
            // 
            dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            dToolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
            dToolStripMenuItem2.Text = "3D";
            dToolStripMenuItem2.Click += создать3DСеткуToolStripMenuItem_Click;
            // 
            // dataBasesMenuItem
            // 
            dataBasesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { материалыMenuItem, функцииMenuItem });
            dataBasesMenuItem.Enabled = false;
            dataBasesMenuItem.Name = "dataBasesMenuItem";
            dataBasesMenuItem.Size = new System.Drawing.Size(86, 20);
            dataBasesMenuItem.Text = "Базы данных";
            // 
            // материалыMenuItem
            // 
            материалыMenuItem.CheckOnClick = true;
            материалыMenuItem.Name = "материалыMenuItem";
            материалыMenuItem.Size = new System.Drawing.Size(135, 22);
            материалыMenuItem.Text = "Материалы";
            материалыMenuItem.Click += материалыMenuItem_Click;
            // 
            // функцииMenuItem
            // 
            функцииMenuItem.CheckOnClick = true;
            функцииMenuItem.Name = "функцииMenuItem";
            функцииMenuItem.Size = new System.Drawing.Size(135, 22);
            функцииMenuItem.Text = "Функции";
            функцииMenuItem.Click += функцииMenuItem_Click;
            // 
            // tasksMenuItem
            // 
            tasksMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem1, мастерToolStripMenuItem, показатьНаДиаграммеToolStripMenuItem });
            tasksMenuItem.Enabled = false;
            tasksMenuItem.Name = "tasksMenuItem";
            tasksMenuItem.Size = new System.Drawing.Size(56, 20);
            tasksMenuItem.Text = "Задача";
            // 
            // создатьToolStripMenuItem1
            // 
            создатьToolStripMenuItem1.Name = "создатьToolStripMenuItem1";
            создатьToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            создатьToolStripMenuItem1.Text = "Создать";
            создатьToolStripMenuItem1.Click += создатьЗадачуToolStripMenuItem_Click;
            // 
            // мастерToolStripMenuItem
            // 
            мастерToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, трениемСПеремешиваниемToolStripMenuItem, термообработкаToolStripMenuItem, toolStripSeparator3, загрузитьМастерToolStripMenuItem, toolStripSeparator4 });
            мастерToolStripMenuItem.Name = "мастерToolStripMenuItem";
            мастерToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            мастерToolStripMenuItem.Text = "Мастер";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            toolStripMenuItem1.Text = "Сварка плавлением";
            toolStripMenuItem1.Visible = false;
            // 
            // трениемСПеремешиваниемToolStripMenuItem
            // 
            трениемСПеремешиваниемToolStripMenuItem.Name = "трениемСПеремешиваниемToolStripMenuItem";
            трениемСПеремешиваниемToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            трениемСПеремешиваниемToolStripMenuItem.Text = "Трением с перемешиванием";
            трениемСПеремешиваниемToolStripMenuItem.Visible = false;
            // 
            // термообработкаToolStripMenuItem
            // 
            термообработкаToolStripMenuItem.Name = "термообработкаToolStripMenuItem";
            термообработкаToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            термообработкаToolStripMenuItem.Text = "Термообработка";
            термообработкаToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // загрузитьМастерToolStripMenuItem
            // 
            загрузитьМастерToolStripMenuItem.Name = "загрузитьМастерToolStripMenuItem";
            загрузитьМастерToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            загрузитьМастерToolStripMenuItem.Text = "Пользовательский мастер";
            загрузитьМастерToolStripMenuItem.Click += загрузитьМастерToolStripMenuItem_Click;
            // 
            // показатьНаДиаграммеToolStripMenuItem
            // 
            показатьНаДиаграммеToolStripMenuItem.CheckOnClick = true;
            показатьНаДиаграммеToolStripMenuItem.Name = "показатьНаДиаграммеToolStripMenuItem";
            показатьНаДиаграммеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            показатьНаДиаграммеToolStripMenuItem.Text = "Показать на диаграмме";
            показатьНаДиаграммеToolStripMenuItem.Click += показатьНаДиаграммеToolStripMenuItem_Click;
            // 
            // расчетыToolStripMenuItem
            // 
            расчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьИнструкцииToolStripMenuItem, сформироватьИнструкцииToolStripMenuItem, запуститьToolStripMenuItem, остановитьToolStripMenuItem });
            расчетыToolStripMenuItem.Enabled = false;
            расчетыToolStripMenuItem.Name = "расчетыToolStripMenuItem";
            расчетыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            расчетыToolStripMenuItem.Text = "Расчеты";
            // 
            // открытьИнструкцииToolStripMenuItem
            // 
            открытьИнструкцииToolStripMenuItem.Name = "открытьИнструкцииToolStripMenuItem";
            открытьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            открытьИнструкцииToolStripMenuItem.Text = "Открыть";
            открытьИнструкцииToolStripMenuItem.Click += открытьИнструкцииToolStripMenuItem_Click;
            // 
            // сформироватьИнструкцииToolStripMenuItem
            // 
            сформироватьИнструкцииToolStripMenuItem.Name = "сформироватьИнструкцииToolStripMenuItem";
            сформироватьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            сформироватьИнструкцииToolStripMenuItem.Text = "Сформировать";
            сформироватьИнструкцииToolStripMenuItem.Click += сформироватьИнструкцииToolStripMenuItem_Click;
            // 
            // запуститьToolStripMenuItem
            // 
            запуститьToolStripMenuItem.Name = "запуститьToolStripMenuItem";
            запуститьToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            запуститьToolStripMenuItem.Text = "Запустить";
            запуститьToolStripMenuItem.Click += запуститьToolStripMenuItem_Click;
            // 
            // остановитьToolStripMenuItem
            // 
            остановитьToolStripMenuItem.Name = "остановитьToolStripMenuItem";
            остановитьToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            остановитьToolStripMenuItem.Text = "Остановить";
            остановитьToolStripMenuItem.Click += остановитьToolStripMenuItem_Click;
            // 
            // результатыMenuItem
            // 
            результатыMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem1, объединитьToolStripMenuItem, построитьГрафикToolStripMenuItem, построитьДиаграммуToolStripMenuItem, создатьАнимациюToolStripMenuItem, экспортироватьРезультатыToolStripMenuItem, toolStripMenuItem4 });
            результатыMenuItem.Enabled = false;
            результатыMenuItem.Name = "результатыMenuItem";
            результатыMenuItem.Size = new System.Drawing.Size(77, 20);
            результатыMenuItem.Text = "Результаты";
            // 
            // открытьToolStripMenuItem1
            // 
            открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            открытьToolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
            открытьToolStripMenuItem1.Text = "Открыть";
            открытьToolStripMenuItem1.Click += открытьToolStripMenuItem1_Click;
            // 
            // объединитьToolStripMenuItem
            // 
            объединитьToolStripMenuItem.Enabled = false;
            объединитьToolStripMenuItem.Name = "объединитьToolStripMenuItem";
            объединитьToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            объединитьToolStripMenuItem.Text = "Объединить";
            // 
            // построитьГрафикToolStripMenuItem
            // 
            построитьГрафикToolStripMenuItem.Name = "построитьГрафикToolStripMenuItem";
            построитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            построитьГрафикToolStripMenuItem.Text = "Построить график";
            построитьГрафикToolStripMenuItem.Click += построитьГрафикToolStripMenuItem_Click;
            // 
            // построитьДиаграммуToolStripMenuItem
            // 
            построитьДиаграммуToolStripMenuItem.Name = "построитьДиаграммуToolStripMenuItem";
            построитьДиаграммуToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            построитьДиаграммуToolStripMenuItem.Text = "Построить диаграмму";
            построитьДиаграммуToolStripMenuItem.Click += построитьДиаграммуToolStripMenuItem_Click;
            // 
            // создатьАнимациюToolStripMenuItem
            // 
            создатьАнимациюToolStripMenuItem.CheckOnClick = true;
            создатьАнимациюToolStripMenuItem.Name = "создатьАнимациюToolStripMenuItem";
            создатьАнимациюToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            создатьАнимациюToolStripMenuItem.Text = "Создать анимацию";
            создатьАнимациюToolStripMenuItem.Click += создатьАнимациюToolStripMenuItem_Click;
            // 
            // экспортироватьРезультатыToolStripMenuItem
            // 
            экспортироватьРезультатыToolStripMenuItem.Enabled = false;
            экспортироватьРезультатыToolStripMenuItem.Name = "экспортироватьРезультатыToolStripMenuItem";
            экспортироватьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            экспортироватьРезультатыToolStripMenuItem.Text = "Экспортировать результаты";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.CheckOnClick = true;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(224, 22);
            toolStripMenuItem4.Text = "Отразить результаты";
            toolStripMenuItem4.Click += отзеркаливаниеToolStripMenuItem_Click;
            // 
            // инструментыToolStripMenuItem
            // 
            инструментыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { измеритьToolStripMenuItem, скрытьПлоскостьюToolStripMenuItem });
            инструментыToolStripMenuItem.Enabled = false;
            инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            инструментыToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // измеритьToolStripMenuItem
            // 
            измеритьToolStripMenuItem.CheckOnClick = true;
            измеритьToolStripMenuItem.Name = "измеритьToolStripMenuItem";
            измеритьToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            измеритьToolStripMenuItem.Text = "Измерить";
            измеритьToolStripMenuItem.Click += измеритьToolStripMenuItem_Click;
            // 
            // скрытьПлоскостьюToolStripMenuItem
            // 
            скрытьПлоскостьюToolStripMenuItem.CheckOnClick = true;
            скрытьПлоскостьюToolStripMenuItem.Name = "скрытьПлоскостьюToolStripMenuItem";
            скрытьПлоскостьюToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            скрытьПлоскостьюToolStripMenuItem.Text = "Скрыть плоскостью";
            скрытьПлоскостьюToolStripMenuItem.Click += скрытьПлоскостьюToolStripMenuItem_Click;
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.CheckOnClick = true;
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            настройкиToolStripMenuItem.Text = "&Настройки";
            настройкиToolStripMenuItem.Click += настройкиToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { содержаниеToolStripMenuItem, опрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // содержаниеToolStripMenuItem
            // 
            содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            содержаниеToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            содержаниеToolStripMenuItem.Text = "&Содержание";
            содержаниеToolStripMenuItem.Click += содержаниеToolStripMenuItem_Click;
            // 
            // опрограммеToolStripMenuItem
            // 
            опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            опрограммеToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            опрограммеToolStripMenuItem.Text = "&О программе...";
            опрограммеToolStripMenuItem.Click += опрограммеToolStripMenuItem_Click;
            // 
            // лицензияToolStripMenuItem
            // 
            лицензияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сведенияMenuItem });
            лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            лицензияToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            лицензияToolStripMenuItem.Text = "Лицензия";
            // 
            // сведенияMenuItem
            // 
            сведенияMenuItem.Name = "сведенияMenuItem";
            сведенияMenuItem.Size = new System.Drawing.Size(125, 22);
            сведенияMenuItem.Text = "Сведения";
            сведенияMenuItem.Click += сведенияMenuItem_Click;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { создатьГруппуItem, скрытьВыбранноеItem, показатьСкрытыеItem, menuItem_InfoSelectedObjects, menuItem_SetRotPoint, menuItem_DeleteSelectedObjects });
            contextMenu.Name = "sceneContextMenu";
            contextMenu.Size = new System.Drawing.Size(204, 136);
            // 
            // создатьГруппуItem
            // 
            создатьГруппуItem.Image = (System.Drawing.Image)resources.GetObject("создатьГруппуItem.Image");
            создатьГруппуItem.ImageScaling = ToolStripItemImageScaling.None;
            создатьГруппуItem.Name = "создатьГруппуItem";
            создатьГруппуItem.Size = new System.Drawing.Size(203, 22);
            создатьГруппуItem.Text = "Создать новую группу";
            создатьГруппуItem.Click += создатьГруппуItem_Click;
            // 
            // скрытьВыбранноеItem
            // 
            скрытьВыбранноеItem.Image = Properties.Resources.hide_w;
            скрытьВыбранноеItem.ImageScaling = ToolStripItemImageScaling.None;
            скрытьВыбранноеItem.Name = "скрытьВыбранноеItem";
            скрытьВыбранноеItem.Size = new System.Drawing.Size(203, 22);
            скрытьВыбранноеItem.Text = "Скрыть выбранное";
            скрытьВыбранноеItem.Click += скрытьВыбранноеItem_Click;
            // 
            // показатьСкрытыеItem
            // 
            показатьСкрытыеItem.Image = Properties.Resources.show_w;
            показатьСкрытыеItem.ImageScaling = ToolStripItemImageScaling.None;
            показатьСкрытыеItem.Name = "показатьСкрытыеItem";
            показатьСкрытыеItem.Size = new System.Drawing.Size(203, 22);
            показатьСкрытыеItem.Text = "Показать все скрытые";
            показатьСкрытыеItem.Click += показатьСкрытыеItem_Click;
            // 
            // menuItem_InfoSelectedObjects
            // 
            menuItem_InfoSelectedObjects.Image = Properties.Resources.info_w;
            menuItem_InfoSelectedObjects.ImageScaling = ToolStripItemImageScaling.None;
            menuItem_InfoSelectedObjects.Name = "menuItem_InfoSelectedObjects";
            menuItem_InfoSelectedObjects.Size = new System.Drawing.Size(203, 22);
            menuItem_InfoSelectedObjects.Text = "Выбранные объекты";
            menuItem_InfoSelectedObjects.Click += menuItem_InfoSelectedObjects_Click;
            // 
            // menuItem_SetRotPoint
            // 
            menuItem_SetRotPoint.Image = (System.Drawing.Image)resources.GetObject("menuItem_SetRotPoint.Image");
            menuItem_SetRotPoint.ImageScaling = ToolStripItemImageScaling.None;
            menuItem_SetRotPoint.Name = "menuItem_SetRotPoint";
            menuItem_SetRotPoint.Size = new System.Drawing.Size(203, 22);
            menuItem_SetRotPoint.Text = "Задать точку вращения";
            menuItem_SetRotPoint.Click += menuItem_SetRotPoint_Click;
            // 
            // menuItem_DeleteSelectedObjects
            // 
            menuItem_DeleteSelectedObjects.Image = (System.Drawing.Image)resources.GetObject("menuItem_DeleteSelectedObjects.Image");
            menuItem_DeleteSelectedObjects.ImageScaling = ToolStripItemImageScaling.None;
            menuItem_DeleteSelectedObjects.Name = "menuItem_DeleteSelectedObjects";
            menuItem_DeleteSelectedObjects.Size = new System.Drawing.Size(203, 22);
            menuItem_DeleteSelectedObjects.Text = "Удалить выбранное";
            menuItem_DeleteSelectedObjects.Click += menuItem_DeleteSelectedObjects_Click;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(942, 625);
            Controls.Add(toolStripContainer);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(2);
            MinimumSize = new System.Drawing.Size(415, 320);
            Name = "BaseForm";
            Text = "Bazis. Система инженерного анализа";
            WindowState = FormWindowState.Maximized;
            FormClosing += OnClosingForm;
            FormClosed += BaseForm_FormClosed;
            Load += BaseForm_Load;
            KeyDown += BaseForm_KeyDown;
            toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer.BottomToolStripPanel.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            cntrНавигатор.Panel1.ResumeLayout(false);
            cntrНавигатор.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cntrНавигатор).EndInit();
            cntrНавигатор.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитькакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
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
        private UserControlsEx.SplitContainerEx cntrНавигатор;
        private NavigatorControl navigator;
        private BazisGUI.PropertiesPanel.PropertiesPanelControl propertiesPanel;
        private UserControlsEx.SplitContainerEx splitContainer2;
        private BazisGUI.Console.ConsoleControl console;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem создатьГруппуItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьВыбранноеItem;
        private System.Windows.Forms.ToolStripMenuItem показатьСкрытыеItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_InfoSelectedObjects;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetRotPoint;
        private System.Windows.Forms.ToolStripMenuItem menuItem_DeleteSelectedObjects;
        private BazisGUI.Player.PlayerControl checkPlayerControl;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripMenuItem открытьToolStripMenuItem1;
        private ToolStripMenuItem мастерToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
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
        private Button btnTabНавигатор;
        private Button btnTabГант;
        private Button btnTabФункции;
        private Button btnTabМатериалы;
        private OpenTK.GLControl.GLControl scene;
        private Button btnTabНастройки;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem загрузитьМастерToolStripMenuItem;
    }
}

