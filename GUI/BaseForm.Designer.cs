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
            this.label1 = new System.Windows.Forms.Label();
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
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новостиВерсииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лицензияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сведенияMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьЛицензиюMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1100, 557);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1100, 613);
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
            this.statusStrip.Size = new System.Drawing.Size(1100, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(855, 21);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = false;
            this.lblVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(100, 20);
            // 
            // webPageLabel
            // 
            this.webPageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.webPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.webPageLabel.IsLink = true;
            this.webPageLabel.LinkColor = System.Drawing.Color.OrangeRed;
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(125, 20);
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
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.24722F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.43737F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.31541F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1100, 557);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::BazisGUI.Properties.Resources.ScreenSaver;
            this.pictureBox.Location = new System.Drawing.Point(3, 2);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1094, 437);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // releaseNoteslinkLabel
            // 
            this.releaseNoteslinkLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.releaseNoteslinkLabel.AutoSize = true;
            this.releaseNoteslinkLabel.Location = new System.Drawing.Point(469, 522);
            this.releaseNoteslinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.releaseNoteslinkLabel.Name = "releaseNoteslinkLabel";
            this.releaseNoteslinkLabel.Size = new System.Drawing.Size(161, 16);
            this.releaseNoteslinkLabel.TabIndex = 1;
            this.releaseNoteslinkLabel.TabStop = true;
            this.releaseNoteslinkLabel.Text = "Узнать новости версии";
            this.releaseNoteslinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.releaseNoteslinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(215, 460);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(669, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добро пожаловать! Создайте проект, а затем выберите \"Модуль\"";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модулиMenuItem,
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.лицензияToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1100, 28);
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
            this.модулиMenuItem.Name = "модулиMenuItem";
            this.модулиMenuItem.Size = new System.Drawing.Size(85, 24);
            this.модулиMenuItem.Text = "Модули  ";
            this.модулиMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.модулиMenuItem_Paint);
            // 
            // построениеСетки
            // 
            this.построениеСетки.Image = ((System.Drawing.Image)(resources.GetObject("построениеСетки.Image")));
            this.построениеСетки.Name = "построениеСетки";
            this.построениеСетки.Size = new System.Drawing.Size(231, 26);
            this.построениеСетки.Text = "Построение сетки";
            this.построениеСетки.Click += new System.EventHandler(this.построениеСетки_Click);
            // 
            // анализРезультатов
            // 
            this.анализРезультатов.Image = ((System.Drawing.Image)(resources.GetObject("анализРезультатов.Image")));
            this.анализРезультатов.Name = "анализРезультатов";
            this.анализРезультатов.Size = new System.Drawing.Size(231, 26);
            this.анализРезультатов.Text = "Анализ результатов";
            this.анализРезультатов.Click += new System.EventHandler(this.анализРезультатов_Click);
            // 
            // сварка
            // 
            this.сварка.Image = ((System.Drawing.Image)(resources.GetObject("сварка.Image")));
            this.сварка.Name = "сварка";
            this.сварка.Size = new System.Drawing.Size(231, 26);
            this.сварка.Text = "Сварка";
            this.сварка.Click += new System.EventHandler(this.сварка_Click);
            // 
            // термообработка
            // 
            this.термообработка.Image = ((System.Drawing.Image)(resources.GetObject("термообработка.Image")));
            this.термообработка.Name = "термообработка";
            this.термообработка.Size = new System.Drawing.Size(231, 26);
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
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьToolStripMenuItem.Image")));
            this.создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.создатьToolStripMenuItem.Text = "&Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьToolStripMenuItem.Image")));
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(267, 6);
            // 
            // импортСеткиToolStripMenuItem
            // 
            this.импортСеткиToolStripMenuItem.Name = "импортСеткиToolStripMenuItem";
            this.импортСеткиToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.импортСеткиToolStripMenuItem.Text = "Импорт сетки";
            this.импортСеткиToolStripMenuItem.Click += new System.EventHandler(this.импортСеткиToolStripMenuItem_Click);
            // 
            // импортГеометрииToolStripMenuItem
            // 
            this.импортГеометрииToolStripMenuItem.Name = "импортГеометрииToolStripMenuItem";
            this.импортГеометрииToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.импортГеометрииToolStripMenuItem.Text = "Импорт геометрии (CAD)";
            this.импортГеометрииToolStripMenuItem.Click += new System.EventHandler(this.импортГеометрииToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.сохранитькакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.выходToolStripMenuItem.Text = "Вы&ход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
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
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // содержаниеToolStripMenuItem
            // 
            this.содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            this.содержаниеToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.содержаниеToolStripMenuItem.Text = "&Содержание";
            this.содержаниеToolStripMenuItem.Click += new System.EventHandler(this.содержаниеToolStripMenuItem_Click);
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.опрограммеToolStripMenuItem_Click);
            // 
            // новостиВерсииToolStripMenuItem
            // 
            this.новостиВерсииToolStripMenuItem.Name = "новостиВерсииToolStripMenuItem";
            this.новостиВерсииToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.новостиВерсииToolStripMenuItem.Text = "Новости версии";
            this.новостиВерсииToolStripMenuItem.Click += new System.EventHandler(this.новостиВерсииToolStripMenuItem_Click);
            // 
            // лицензияToolStripMenuItem
            // 
            this.лицензияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сведенияMenuItem,
            this.получитьЛицензиюMenuItem});
            this.лицензияToolStripMenuItem.Name = "лицензияToolStripMenuItem";
            this.лицензияToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.лицензияToolStripMenuItem.Text = "Лицензия";
            // 
            // сведенияMenuItem
            // 
            this.сведенияMenuItem.Name = "сведенияMenuItem";
            this.сведенияMenuItem.Size = new System.Drawing.Size(233, 26);
            this.сведенияMenuItem.Text = "Сведения";
            this.сведенияMenuItem.Click += new System.EventHandler(this.сведенияMenuItem_Click);
            // 
            // получитьЛицензиюMenuItem
            // 
            this.получитьЛицензиюMenuItem.Name = "получитьЛицензиюMenuItem";
            this.получитьЛицензиюMenuItem.Size = new System.Drawing.Size(233, 26);
            this.получитьЛицензиюMenuItem.Text = "Получить лицензию";
            this.получитьЛицензиюMenuItem.Click += new System.EventHandler(this.получитьЛицензиюMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 613);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BaseForm";
            this.Text = "Bazis. Система технологического анализа";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        

        private System.Windows.Forms.ToolStripMenuItem сведенияMenuItem;
        private System.Windows.Forms.ToolStripMenuItem получитьЛицензиюMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сварка;
        private System.Windows.Forms.ToolStripMenuItem термообработка;
        private System.Windows.Forms.ToolStripMenuItem новостиВерсииToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.LinkLabel releaseNoteslinkLabel;
        private System.Windows.Forms.Label label1;
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
    }
}

