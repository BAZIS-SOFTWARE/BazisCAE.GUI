using UserControlsEx;

namespace BaseModule.Console
{
    partial class ConsoleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleControl));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.grbConsole = new System.Windows.Forms.Panel();
            this.tlscOut = new System.Windows.Forms.ToolStripContainer();
            this.rtxbField = new System.Windows.Forms.RichTextBox();
            this.toolStripEx1 = new UserControlsEx.ToolStripEx();
            this.spbDictionary = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem48 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem49 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem52 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem53 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem54 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem55 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem56 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem57 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem58 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem59 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem60 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem61 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem62 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem63 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem64 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem65 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem66 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnStartMacro = new System.Windows.Forms.ToolStripButton();
            this.grbConsole.SuspendLayout();
            this.tlscOut.ContentPanel.SuspendLayout();
            this.tlscOut.RightToolStripPanel.SuspendLayout();
            this.tlscOut.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem14.Text = "toolStripMenuItem14";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem15.Text = "toolStripMenuItem15";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem16.Text = "toolStripMenuItem16";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // grbConsole
            // 
            this.grbConsole.BackColor = System.Drawing.SystemColors.Control;
            this.grbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbConsole.Controls.Add(this.tlscOut);
            this.grbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConsole.Location = new System.Drawing.Point(0, 0);
            this.grbConsole.Name = "grbConsole";
            this.grbConsole.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbConsole.Size = new System.Drawing.Size(706, 205);
            this.grbConsole.TabIndex = 6;
            this.grbConsole.Paint += new System.Windows.Forms.PaintEventHandler(this.grbConsole_Paint);
            this.grbConsole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbConsole_MouseClick);
            this.grbConsole.Resize += new System.EventHandler(this.grbConsole_Resize);
            // 
            // tlscOut
            // 
            this.tlscOut.BottomToolStripPanelVisible = false;
            // 
            // tlscOut.ContentPanel
            // 
            this.tlscOut.ContentPanel.Controls.Add(this.rtxbField);
            this.tlscOut.ContentPanel.Size = new System.Drawing.Size(673, 188);
            this.tlscOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlscOut.LeftToolStripPanelVisible = false;
            this.tlscOut.Location = new System.Drawing.Point(0, 15);
            this.tlscOut.Margin = new System.Windows.Forms.Padding(0);
            this.tlscOut.Name = "tlscOut";
            // 
            // tlscOut.RightToolStripPanel
            // 
            this.tlscOut.RightToolStripPanel.Controls.Add(this.toolStripEx1);
            this.tlscOut.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlscOut.Size = new System.Drawing.Size(704, 188);
            this.tlscOut.TabIndex = 4;
            this.tlscOut.Text = "toolStripContainer1";
            // 
            // tlscOut.TopToolStripPanel
            // 
            this.tlscOut.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
            this.tlscOut.TopToolStripPanelVisible = false;
            // 
            // rtxbField
            // 
            this.rtxbField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxbField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxbField.Location = new System.Drawing.Point(0, 0);
            this.rtxbField.Margin = new System.Windows.Forms.Padding(1);
            this.rtxbField.Name = "rtxbField";
            this.rtxbField.Size = new System.Drawing.Size(673, 188);
            this.rtxbField.TabIndex = 2;
            this.rtxbField.Text = "";
            this.rtxbField.WordWrap = false;
            this.rtxbField.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtxbOut_LinkClicked);
            this.rtxbField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxbField_KeyDown);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.FrameColor = System.Drawing.Color.DarkGray;
            this.toolStripEx1.GeneralFrame = true;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.IconLocation = new System.Drawing.Point(3, 3);
            this.toolStripEx1.ImageRectangleSize = new System.Drawing.Point(16, 16);
            this.toolStripEx1.ItemBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.toolStripEx1.ItemFrame = true;
            this.toolStripEx1.ItemLocation = new System.Drawing.Point(1, 1);
            this.toolStripEx1.ItemPressColor = System.Drawing.Color.Black;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spbDictionary,
            this.toolStripButton1,
            this.toolStripButton2,
            this.btnStartMacro});
            this.toolStripEx1.ItemSelectColor = System.Drawing.Color.Gray;
            this.toolStripEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripEx1.Size = new System.Drawing.Size(31, 188);
            this.toolStripEx1.SplitButtonClickWidth = 13;
            this.toolStripEx1.SplitButtonHeight = 40;
            this.toolStripEx1.SplitButtonTriangleSize = 6;
            this.toolStripEx1.Stretch = true;
            this.toolStripEx1.TabIndex = 10;
            this.toolStripEx1.TextBoxFrame = true;
            this.toolStripEx1.TextBoxHeight = 0;
            // 
            // spbDictionary
            // 
            this.spbDictionary.AutoSize = false;
            this.spbDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.spbDictionary.DropDownButtonWidth = 10;
            this.spbDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem32,
            this.toolStripMenuItem34,
            this.toolStripMenuItem36,
            this.toolStripMenuItem37,
            this.toolStripMenuItem38,
            this.toolStripMenuItem40,
            this.toolStripMenuItem47,
            this.toolStripMenuItem54,
            this.toolStripMenuItem61,
            this.toolStripMenuItem62,
            this.toolStripMenuItem64,
            this.toolStripMenuItem66});
            this.spbDictionary.Image = ((System.Drawing.Image)(resources.GetObject("spbDictionary.Image")));
            this.spbDictionary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.spbDictionary.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.spbDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spbDictionary.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.spbDictionary.Name = "spbDictionary";
            this.spbDictionary.Size = new System.Drawing.Size(25, 40);
            this.spbDictionary.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.spbDictionary.ButtonClick += new System.EventHandler(this.btnDictionary_Click);
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem33});
            this.toolStripMenuItem32.Enabled = false;
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem32.Text = "Загрузить проект";
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem33.Text = "Укажите путь";
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem35});
            this.toolStripMenuItem34.Enabled = false;
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem34.Text = "Сохранить проект";
            // 
            // toolStripMenuItem35
            // 
            this.toolStripMenuItem35.Name = "toolStripMenuItem35";
            this.toolStripMenuItem35.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem35.Text = "Укажите путь";
            // 
            // toolStripMenuItem36
            // 
            this.toolStripMenuItem36.Enabled = false;
            this.toolStripMenuItem36.Name = "toolStripMenuItem36";
            this.toolStripMenuItem36.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem36.Text = "Новый проект";
            // 
            // toolStripMenuItem37
            // 
            this.toolStripMenuItem37.Enabled = false;
            this.toolStripMenuItem37.Name = "toolStripMenuItem37";
            this.toolStripMenuItem37.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem37.Text = "Рассчитать проект";
            // 
            // toolStripMenuItem38
            // 
            this.toolStripMenuItem38.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem39});
            this.toolStripMenuItem38.Name = "toolStripMenuItem38";
            this.toolStripMenuItem38.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem38.Text = "Перенумерация сетки";
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem39.Text = "тип и номер";
            this.toolStripMenuItem39.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem41,
            this.toolStripMenuItem43,
            this.toolStripMenuItem45});
            this.toolStripMenuItem40.Enabled = false;
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem40.Text = "Изменить координаты модели";
            // 
            // toolStripMenuItem41
            // 
            this.toolStripMenuItem41.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem42});
            this.toolStripMenuItem41.Name = "toolStripMenuItem41";
            this.toolStripMenuItem41.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem41.Text = "Переместить";
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem42.Text = "Укажите вектор : a,b,c";
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem44});
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem43.Text = "Повернуть";
            // 
            // toolStripMenuItem44
            // 
            this.toolStripMenuItem44.Name = "toolStripMenuItem44";
            this.toolStripMenuItem44.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem44.Text = "Укажите угол : a";
            // 
            // toolStripMenuItem45
            // 
            this.toolStripMenuItem45.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem46});
            this.toolStripMenuItem45.Name = "toolStripMenuItem45";
            this.toolStripMenuItem45.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem45.Text = "Масштабировать";
            // 
            // toolStripMenuItem46
            // 
            this.toolStripMenuItem46.Name = "toolStripMenuItem46";
            this.toolStripMenuItem46.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem46.Text = "Укажите фактор : a";
            // 
            // toolStripMenuItem47
            // 
            this.toolStripMenuItem47.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem48,
            this.toolStripMenuItem50,
            this.toolStripMenuItem52});
            this.toolStripMenuItem47.Enabled = false;
            this.toolStripMenuItem47.Name = "toolStripMenuItem47";
            this.toolStripMenuItem47.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem47.Text = "Изменить координаты объекта";
            // 
            // toolStripMenuItem48
            // 
            this.toolStripMenuItem48.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem49});
            this.toolStripMenuItem48.Name = "toolStripMenuItem48";
            this.toolStripMenuItem48.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem48.Text = "Переместить";
            // 
            // toolStripMenuItem49
            // 
            this.toolStripMenuItem49.Name = "toolStripMenuItem49";
            this.toolStripMenuItem49.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem49.Text = "Укажите вектор : a,b,c";
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem51});
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem50.Text = "Повернуть";
            // 
            // toolStripMenuItem51
            // 
            this.toolStripMenuItem51.Name = "toolStripMenuItem51";
            this.toolStripMenuItem51.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem51.Text = "Укажите угол : a";
            // 
            // toolStripMenuItem52
            // 
            this.toolStripMenuItem52.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem53});
            this.toolStripMenuItem52.Name = "toolStripMenuItem52";
            this.toolStripMenuItem52.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem52.Text = "Масштабировать";
            // 
            // toolStripMenuItem53
            // 
            this.toolStripMenuItem53.Name = "toolStripMenuItem53";
            this.toolStripMenuItem53.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem53.Text = "Укажите фактор : a";
            // 
            // toolStripMenuItem54
            // 
            this.toolStripMenuItem54.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem55,
            this.toolStripMenuItem57,
            this.toolStripMenuItem59});
            this.toolStripMenuItem54.Enabled = false;
            this.toolStripMenuItem54.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripMenuItem54.Name = "toolStripMenuItem54";
            this.toolStripMenuItem54.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem54.Text = "Изменить вид";
            // 
            // toolStripMenuItem55
            // 
            this.toolStripMenuItem55.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem56});
            this.toolStripMenuItem55.Name = "toolStripMenuItem55";
            this.toolStripMenuItem55.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem55.Text = "Переместить";
            // 
            // toolStripMenuItem56
            // 
            this.toolStripMenuItem56.Name = "toolStripMenuItem56";
            this.toolStripMenuItem56.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem56.Text = "Укажите вектор : a,b,c";
            // 
            // toolStripMenuItem57
            // 
            this.toolStripMenuItem57.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem58});
            this.toolStripMenuItem57.Name = "toolStripMenuItem57";
            this.toolStripMenuItem57.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem57.Text = "Повернуть";
            // 
            // toolStripMenuItem58
            // 
            this.toolStripMenuItem58.Name = "toolStripMenuItem58";
            this.toolStripMenuItem58.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem58.Text = "Укажите угол : a";
            // 
            // toolStripMenuItem59
            // 
            this.toolStripMenuItem59.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem60});
            this.toolStripMenuItem59.Name = "toolStripMenuItem59";
            this.toolStripMenuItem59.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem59.Text = "Масштабировать";
            // 
            // toolStripMenuItem60
            // 
            this.toolStripMenuItem60.Name = "toolStripMenuItem60";
            this.toolStripMenuItem60.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem60.Text = "Укажите фактор : a";
            // 
            // toolStripMenuItem61
            // 
            this.toolStripMenuItem61.Name = "toolStripMenuItem61";
            this.toolStripMenuItem61.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem61.Text = "Найти свободные узлы";
            this.toolStripMenuItem61.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // toolStripMenuItem62
            // 
            this.toolStripMenuItem62.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem63});
            this.toolStripMenuItem62.Name = "toolStripMenuItem62";
            this.toolStripMenuItem62.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem62.Text = "Найти объект";
            // 
            // toolStripMenuItem63
            // 
            this.toolStripMenuItem63.Name = "toolStripMenuItem63";
            this.toolStripMenuItem63.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem63.Text = "тип : номер";
            this.toolStripMenuItem63.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // toolStripMenuItem64
            // 
            this.toolStripMenuItem64.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem65});
            this.toolStripMenuItem64.Name = "toolStripMenuItem64";
            this.toolStripMenuItem64.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem64.Text = "Найти совпадающие";
            // 
            // toolStripMenuItem65
            // 
            this.toolStripMenuItem65.Name = "toolStripMenuItem65";
            this.toolStripMenuItem65.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem65.Text = "Узлы";
            this.toolStripMenuItem65.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // toolStripMenuItem66
            // 
            this.toolStripMenuItem66.Name = "toolStripMenuItem66";
            this.toolStripMenuItem66.Size = new System.Drawing.Size(245, 22);
            this.toolStripMenuItem66.Text = "Выход";
            this.toolStripMenuItem66.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.btnBackGroundInfo_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // btnStartMacro
            // 
            this.btnStartMacro.AutoSize = false;
            this.btnStartMacro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartMacro.Image = global::BaseModule.Properties.Resources.StartCheck;
            this.btnStartMacro.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStartMacro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartMacro.Name = "btnStartMacro";
            this.btnStartMacro.Size = new System.Drawing.Size(25, 25);
            this.btnStartMacro.Text = "toolStripButton4";
            this.btnStartMacro.Click += new System.EventHandler(this.btnStartMacro_Click);
            // 
            // ConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.grbConsole);
            this.Name = "ConsoleControl";
            this.Size = new System.Drawing.Size(706, 205);
            this.Load += new System.EventHandler(this.ConsoleControl_Load);
            this.grbConsole.ResumeLayout(false);
            this.tlscOut.ContentPanel.ResumeLayout(false);
            this.tlscOut.RightToolStripPanel.ResumeLayout(false);
            this.tlscOut.RightToolStripPanel.PerformLayout();
            this.tlscOut.ResumeLayout(false);
            this.tlscOut.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Panel grbConsole;
        private System.Windows.Forms.ToolStripContainer tlscOut;
        private System.Windows.Forms.RichTextBox rtxbField;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem32;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem33;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem34;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem35;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem36;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem37;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem38;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem39;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem40;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem41;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem42;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem43;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem44;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem45;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem46;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem47;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem48;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem49;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem51;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem52;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem53;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem54;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem55;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem56;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem57;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem58;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem59;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem60;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem61;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem62;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem63;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem64;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem65;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem66;
        private ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripSplitButton spbDictionary;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnStartMacro;
    }
}
