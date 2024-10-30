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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.webPageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.releaseNoteslinkLabel = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.модулиMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построениеСетки = new System.Windows.Forms.ToolStripMenuItem();
            this.анализРезультатов = new System.Windows.Forms.ToolStripMenuItem();
            this.сварка = new System.Windows.Forms.ToolStripMenuItem();
            this.термообработка = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.импортСеткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортГеометрииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.addResultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadResultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showValueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новостиВерсииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лицензияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сведенияMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьЛицензиюMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.toolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(709, 435);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(709, 481);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
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
            this.statusStrip.Size = new System.Drawing.Size(709, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(584, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(4, 17);
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
            this.webPageLabel.Click += new System.EventHandler(this.webPageLabel_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.releaseNoteslinkLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.17194F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.03974F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.788314F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(709, 435);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::BazisGUI.Properties.Resources.ScreenSaver;
            this.pictureBox.Location = new System.Drawing.Point(2, 2);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(705, 279);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // releaseNoteslinkLabel
            // 
            this.releaseNoteslinkLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.releaseNoteslinkLabel.AutoSize = true;
            this.releaseNoteslinkLabel.Location = new System.Drawing.Point(291, 406);
            this.releaseNoteslinkLabel.Name = "releaseNoteslinkLabel";
            this.releaseNoteslinkLabel.Size = new System.Drawing.Size(127, 13);
            this.releaseNoteslinkLabel.TabIndex = 1;
            this.releaseNoteslinkLabel.TabStop = true;
            this.releaseNoteslinkLabel.Text = "Узнать новости версии";
            this.releaseNoteslinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.releaseNoteslinkLabel_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 286);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 102);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(156, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать проект";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(366, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 90);
            this.button2.TabIndex = 1;
            this.button2.Text = "Открыть проект";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модулиMenuItem,
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
            this.menuStrip.Size = new System.Drawing.Size(709, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // модулиMenuItem
            // 
            this.модулиMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.модулиMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построениеСетки,
            this.анализРезультатов,
            this.сварка,
            this.термообработка});
            this.модулиMenuItem.Enabled = false;
            this.модулиMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.модулиMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.модулиMenuItem.Name = "модулиMenuItem";
            this.модулиMenuItem.Size = new System.Drawing.Size(60, 20);
            this.модулиMenuItem.Text = "Модули";
            this.модулиMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.модулиMenuItem_Paint);
            // 
            // построениеСетки
            // 
            this.построениеСетки.Image = ((System.Drawing.Image)(resources.GetObject("построениеСетки.Image")));
            this.построениеСетки.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.построениеСетки.Name = "построениеСетки";
            this.построениеСетки.Size = new System.Drawing.Size(183, 26);
            this.построениеСетки.Text = "Построение сетки";
            this.построениеСетки.Click += new System.EventHandler(this.построениеСетки_Click);
            // 
            // анализРезультатов
            // 
            this.анализРезультатов.Image = ((System.Drawing.Image)(resources.GetObject("анализРезультатов.Image")));
            this.анализРезультатов.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.анализРезультатов.Name = "анализРезультатов";
            this.анализРезультатов.Size = new System.Drawing.Size(183, 26);
            this.анализРезультатов.Text = "Анализ результатов";
            this.анализРезультатов.Click += new System.EventHandler(this.анализРезультатов_Click);
            // 
            // сварка
            // 
            this.сварка.Image = ((System.Drawing.Image)(resources.GetObject("сварка.Image")));
            this.сварка.Name = "сварка";
            this.сварка.Size = new System.Drawing.Size(183, 26);
            this.сварка.Text = "Сварка";
            this.сварка.Click += new System.EventHandler(this.сварка_Click);
            // 
            // термообработка
            // 
            this.термообработка.Image = ((System.Drawing.Image)(resources.GetObject("термообработка.Image")));
            this.термообработка.Name = "термообработка";
            this.термообработка.Size = new System.Drawing.Size(183, 26);
            this.термообработка.Text = "Термообработка";
            this.термообработка.Click += new System.EventHandler(this.термообработка_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.импортСеткиToolStripMenuItem,
            this.импортГеометрииToolStripMenuItem,
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
            this.viewMenuItem.Size = new System.Drawing.Size(38, 20);
            this.viewMenuItem.Text = "Вид";
            this.viewMenuItem.Visible = false;
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
            this.mesh3DGeneratorMenuItem});
            this.meshMenuItem.Enabled = false;
            this.meshMenuItem.Name = "meshMenuItem";
            this.meshMenuItem.Size = new System.Drawing.Size(49, 20);
            this.meshMenuItem.Text = "Сетка";
            this.meshMenuItem.Visible = false;
            // 
            // createSurfaceElementsMenuItem
            // 
            this.createSurfaceElementsMenuItem.Name = "createSurfaceElementsMenuItem";
            this.createSurfaceElementsMenuItem.Size = new System.Drawing.Size(179, 22);
            this.createSurfaceElementsMenuItem.Text = "Создать 2D из 3D";
            this.createSurfaceElementsMenuItem.Click += new System.EventHandler(this.createSurfaceElementsMenuItem_Click);
            // 
            // создать1DПо2DЭлементамToolStripMenuItem
            // 
            this.создать1DПо2DЭлементамToolStripMenuItem.Name = "создать1DПо2DЭлементамToolStripMenuItem";
            this.создать1DПо2DЭлементамToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.создать1DПо2DЭлементамToolStripMenuItem.Text = "Создать 1D из 2D";
            this.создать1DПо2DЭлементамToolStripMenuItem.Click += new System.EventHandler(this.создать1DПо2DЭлементамToolStripMenuItem_Click);
            // 
            // mesh3DGeneratorMenuItem
            // 
            this.mesh3DGeneratorMenuItem.Name = "mesh3DGeneratorMenuItem";
            this.mesh3DGeneratorMenuItem.Size = new System.Drawing.Size(179, 22);
            this.mesh3DGeneratorMenuItem.Text = "Генератор 3D сетки";
            this.mesh3DGeneratorMenuItem.Click += new System.EventHandler(this.mesh3DGeneratorMenuItem_Click);
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
            this.tasksMenuItem.Enabled = false;
            this.tasksMenuItem.Name = "tasksMenuItem";
            this.tasksMenuItem.Size = new System.Drawing.Size(57, 20);
            this.tasksMenuItem.Text = "Задачи";
            this.tasksMenuItem.Visible = false;
            // 
            // arcWeldingMenuItem
            // 
            this.arcWeldingMenuItem.CheckOnClick = true;
            this.arcWeldingMenuItem.Name = "arcWeldingMenuItem";
            this.arcWeldingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.arcWeldingMenuItem.Text = "Дуговая сварка";
            this.arcWeldingMenuItem.Click += new System.EventHandler(this.arcWeldingMenuItem_Click);
            // 
            // lazerWeldingMenuItem
            // 
            this.lazerWeldingMenuItem.CheckOnClick = true;
            this.lazerWeldingMenuItem.Name = "lazerWeldingMenuItem";
            this.lazerWeldingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.lazerWeldingMenuItem.Text = "Лазерная сварка";
            this.lazerWeldingMenuItem.Click += new System.EventHandler(this.lazerWeldingMenuItem_Click);
            // 
            // fsWeldingMenuItem
            // 
            this.fsWeldingMenuItem.CheckOnClick = true;
            this.fsWeldingMenuItem.Name = "fsWeldingMenuItem";
            this.fsWeldingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.fsWeldingMenuItem.Text = "Трением с перемешиванием";
            this.fsWeldingMenuItem.Click += new System.EventHandler(this.fsWeldingMenuItem_Click);
            // 
            // heatingMenuItem
            // 
            this.heatingMenuItem.CheckOnClick = true;
            this.heatingMenuItem.Name = "heatingMenuItem";
            this.heatingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.heatingMenuItem.Text = "Нагрев";
            this.heatingMenuItem.Click += new System.EventHandler(this.heatingMenuItem_Click);
            // 
            // temperingMenuItem
            // 
            this.temperingMenuItem.CheckOnClick = true;
            this.temperingMenuItem.Name = "temperingMenuItem";
            this.temperingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.temperingMenuItem.Text = "Отпуск | Отжиг | Старение";
            this.temperingMenuItem.Click += new System.EventHandler(this.temperingMenuItem_Click);
            // 
            // quenchingMenuItem
            // 
            this.quenchingMenuItem.CheckOnClick = true;
            this.quenchingMenuItem.Name = "quenchingMenuItem";
            this.quenchingMenuItem.Size = new System.Drawing.Size(228, 22);
            this.quenchingMenuItem.Text = "Закалка";
            this.quenchingMenuItem.Click += new System.EventHandler(this.quenchingMenuItem_Click);
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
            this.dataBasesMenuItem.Visible = false;
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
            this.addResultsMenuItem,
            this.loadResultsMenuItem,
            this.showValueMenuItem,
            this.createFieldMenuItem,
            this.createPlotMenuItem,
            this.scaleSettingsMenuItem,
            this.exportResultsMenuItem});
            this.resultsMenuItem.Enabled = false;
            this.resultsMenuItem.Name = "resultsMenuItem";
            this.resultsMenuItem.Size = new System.Drawing.Size(77, 20);
            this.resultsMenuItem.Text = "Результаты";
            this.resultsMenuItem.Visible = false;
            // 
            // addResultsMenuItem
            // 
            this.addResultsMenuItem.Name = "addResultsMenuItem";
            this.addResultsMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addResultsMenuItem.Text = "Добавить результаты";
            this.addResultsMenuItem.Click += new System.EventHandler(this.addResultsMenuItem_Click);
            // 
            // loadResultsMenuItem
            // 
            this.loadResultsMenuItem.Name = "loadResultsMenuItem";
            this.loadResultsMenuItem.Size = new System.Drawing.Size(188, 22);
            this.loadResultsMenuItem.Text = "Загрузить результаты";
            this.loadResultsMenuItem.Click += new System.EventHandler(this.loadResultsMenuItem_Click);
            // 
            // showValueMenuItem
            // 
            this.showValueMenuItem.CheckOnClick = true;
            this.showValueMenuItem.Name = "showValueMenuItem";
            this.showValueMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showValueMenuItem.Text = "Показать значения";
            this.showValueMenuItem.Click += new System.EventHandler(this.showValueMenuItem_Click);
            // 
            // createFieldMenuItem
            // 
            this.createFieldMenuItem.Name = "createFieldMenuItem";
            this.createFieldMenuItem.Size = new System.Drawing.Size(188, 22);
            this.createFieldMenuItem.Text = "Построить поле";
            this.createFieldMenuItem.Click += new System.EventHandler(this.createFieldMenuItem_Click);
            // 
            // createPlotMenuItem
            // 
            this.createPlotMenuItem.Name = "createPlotMenuItem";
            this.createPlotMenuItem.Size = new System.Drawing.Size(188, 22);
            this.createPlotMenuItem.Text = "Построить график";
            this.createPlotMenuItem.Click += new System.EventHandler(this.createPlotMenuItem_Click);
            // 
            // scaleSettingsMenuItem
            // 
            this.scaleSettingsMenuItem.Name = "scaleSettingsMenuItem";
            this.scaleSettingsMenuItem.Size = new System.Drawing.Size(188, 22);
            this.scaleSettingsMenuItem.Text = "Настройки шкалы";
            this.scaleSettingsMenuItem.Click += new System.EventHandler(this.scaleSettingsMenuItem_Click);
            // 
            // exportResultsMenuItem
            // 
            this.exportResultsMenuItem.Name = "exportResultsMenuItem";
            this.exportResultsMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exportResultsMenuItem.Text = "Экспорт результатов";
            this.exportResultsMenuItem.Click += new System.EventHandler(this.exportResultsMenuItem_Click);
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
            this.сведенияMenuItem,
            this.получитьЛицензиюMenuItem});
            this.лицензияToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            this.лицензияToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.лицензияToolStripMenuItem.Text = "Лицензия";
            // 
            // сведенияMenuItem
            // 
            this.сведенияMenuItem.Name = "сведенияMenuItem";
            this.сведенияMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сведенияMenuItem.Text = "Сведения";
            this.сведенияMenuItem.Click += new System.EventHandler(this.сведенияMenuItem_Click);
            // 
            // получитьЛицензиюMenuItem
            // 
            this.получитьЛицензиюMenuItem.Name = "получитьЛицензиюMenuItem";
            this.получитьЛицензиюMenuItem.Size = new System.Drawing.Size(182, 22);
            this.получитьЛицензиюMenuItem.Text = "Получить лицензию";
            this.получитьЛицензиюMenuItem.Click += new System.EventHandler(this.получитьЛицензиюMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 481);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(725, 520);
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
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem модулиMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem содержаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лицензияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построениеСетки;
        private System.Windows.Forms.ToolStripMenuItem анализРезультатов;
        private System.Windows.Forms.PictureBox pictureBox;
        

        private System.Windows.Forms.ToolStripMenuItem сведенияMenuItem;
        private System.Windows.Forms.ToolStripMenuItem получитьЛицензиюMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сварка;
        private System.Windows.Forms.ToolStripMenuItem термообработка;
        private System.Windows.Forms.ToolStripMenuItem новостиВерсииToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.LinkLabel releaseNoteslinkLabel;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.ToolStripMenuItem addResultsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadResultsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showValueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBasesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалыMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцииMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFieldMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPlotMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создать1DПо2DЭлементамToolStripMenuItem;
    }
}

