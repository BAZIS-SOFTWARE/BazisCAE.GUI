
using Scene.Interfaces;

namespace Viewer
{
    partial class ViewerForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sceneControl = new Scene.SceneControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.sceneControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(856, 562);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.Color.LightGray;
            this.sceneControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sceneControl.DisplayBasis = true;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsClipPlane = false;
            this.sceneControl.IsLighting = true;
            this.sceneControl.IsSmoothShadow = false;
            this.sceneControl.LightAttenuation = 0F;
            this.sceneControl.LightTranslateX = 0F;
            this.sceneControl.LightTranslateY = 0F;
            this.sceneControl.LightTranslateZ = 0F;
            this.sceneControl.Location = new System.Drawing.Point(4, 4);
            this.sceneControl.Margin = new System.Windows.Forms.Padding(4);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.Projection = Scene.Interfaces.ViewProjection.Perspective;
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = Scene.Interfaces.ViewAxis.XYZ;
            this.sceneControl.ScaleFactor = 1F;
            this.sceneControl.SelectionColor = System.Drawing.Color.Green;
            this.sceneControl.ShadowAngle = 0F;
            this.sceneControl.ShowSurfaceBackEdges = false;
            this.sceneControl.Size = new System.Drawing.Size(591, 554);
            this.sceneControl.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.checkBox9, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(602, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 556);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 182);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отображение:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.69112F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.07722F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.79923F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.43243F));
            this.tableLayoutPanel3.Controls.Add(this.checkBox3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBox4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButton3, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.radioButton2, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.radioButton1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBox8, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(239, 163);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(97, 11);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 31);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Tag = "Элемент2D";
            this.checkBox3.Text = "2D эл-ты";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.OnShowElements);
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox4.Location = new System.Drawing.Point(171, 11);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(56, 31);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Tag = "Элемент3D";
            this.checkBox4.Text = "3D эл-ты";
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.OnShowElements);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(50, 11);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(41, 31);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Tag = "Элемент1D";
            this.checkBox2.Text = "Линии";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.OnShowElements);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.AutoSize = true;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radioButton3.Checked = true;
            this.tableLayoutPanel3.SetColumnSpan(this.radioButton3, 2);
            this.radioButton3.Location = new System.Drawing.Point(50, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(107, 30);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "Ребра и поверхности";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.OnViewModeChange);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radioButton2.Location = new System.Drawing.Point(163, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 30);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Tag = "3";
            this.radioButton2.Text = "Поверхности";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.OnViewModeChange);
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radioButton1.Location = new System.Drawing.Point(3, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 30);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "Ребра";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.OnViewModeChange);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(41, 31);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Tag = "Узел";
            this.checkBox1.Text = "Узлы";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.OnShowElements);
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox8.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBox8, 3);
            this.checkBox8.Location = new System.Drawing.Point(50, 127);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(186, 17);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Tag = "Элементы2D";
            this.checkBox8.Text = "Показывать 3D внутри";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.Click += new System.EventHandler(this.OnShowInside3D);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 182);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прозрачность:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.71815F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.28185F));
            this.tableLayoutPanel4.Controls.Add(this.checkBox6, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.trackBar2, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkBox5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.trackBar1, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.trackBar3, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.trackBar4, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(239, 163);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(131, 7);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(87, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Задн. ребра";
            this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.OnChangeBackEdges);
            // 
            // trackBar2
            // 
            this.trackBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar2.Enabled = false;
            this.trackBar2.Location = new System.Drawing.Point(114, 67);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(122, 26);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.Tag = "2";
            this.trackBar2.Value = 100;
            this.trackBar2.ValueChanged += new System.EventHandler(this.OnChangeTrackbar);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Tag = "Элемент1D";
            this.label2.Text = "Линии: 1.00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(18, 7);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(75, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Включить";
            this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.OnEnableTransparency);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Узел";
            this.label1.Text = "Узлы: 1.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(114, 35);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(122, 26);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Tag = "1";
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.OnChangeTrackbar);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 9;
            this.label3.Tag = "Элемент2D";
            this.label3.Text = "Элементы2D: 1.00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(5, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 10;
            this.label4.Tag = "Элемент3D";
            this.label4.Text = "Элементы3D: 1.00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar3
            // 
            this.trackBar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar3.Enabled = false;
            this.trackBar3.Location = new System.Drawing.Point(114, 99);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(122, 26);
            this.trackBar3.TabIndex = 10;
            this.trackBar3.Tag = "3";
            this.trackBar3.Value = 100;
            this.trackBar3.ValueChanged += new System.EventHandler(this.OnChangeTrackbar);
            // 
            // trackBar4
            // 
            this.trackBar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar4.Enabled = false;
            this.trackBar4.Location = new System.Drawing.Point(114, 131);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(122, 29);
            this.trackBar4.TabIndex = 11;
            this.trackBar4.Tag = "4";
            this.trackBar4.Value = 100;
            this.trackBar4.ValueChanged += new System.EventHandler(this.OnChangeTrackbar);
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(41, 427);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(168, 17);
            this.checkBox7.TabIndex = 5;
            this.checkBox7.Text = "Ортографическая проекция";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.Click += new System.EventHandler(this.OnChangeProjection);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(86, 458);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 27);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сечение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClipPlaneShow);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(86, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 27);
            this.button3.TabIndex = 7;
            this.button3.Text = "Отражение";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnReflectPlaneShow);
            // 
            // checkBox9
            // 
            this.checkBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(60, 527);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(130, 26);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Text = "Выбирать элементы";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.Click += new System.EventHandler(this.OnChangeSelectState);
            // 
            // ViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(856, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ViewerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Scene.SceneControl scene;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Scene.SceneControl sceneControl;
        private System.Windows.Forms.CheckBox checkBox9;
    }
}

