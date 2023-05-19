namespace AdvisorControls
{
    partial class DiffusionСontrol
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiffusionСontrol));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ClmnElem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDiffCoef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnConcentration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnTherm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnStop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckVelocitySlider = new MB.Controls.ColorSlider();
            this.btnStopCheck = new System.Windows.Forms.Button();
            this.btnCheckDinamic = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.txbStop = new System.Windows.Forms.TextBox();
            this.txbStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbDiffCoefNitro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbConcentrNitro = new System.Windows.Forms.TextBox();
            this.txbConcentrCarbon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtFunction = new System.Windows.Forms.RadioButton();
            this.rbtParam = new System.Windows.Forms.RadioButton();
            this.cmbEl = new System.Windows.Forms.ComboBox();
            this.cmbTempreture = new System.Windows.Forms.ComboBox();
            this.txbDiffCoefCarbon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtNitrocarburizing = new System.Windows.Forms.RadioButton();
            this.rbtCarburization = new System.Windows.Forms.RadioButton();
            this.rbtNitritization = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtAlphaFe = new System.Windows.Forms.RadioButton();
            this.rbtGammaFe = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnElem,
            this.ClmnDiffCoef,
            this.ClmnConcentration,
            this.ClmnTherm,
            this.ClmStart,
            this.ClmnStop});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 418);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(613, 224);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            // 
            // ClmnElem
            // 
            this.ClmnElem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmnElem.HeaderText = "Группа элементов";
            this.ClmnElem.Name = "ClmnElem";
            this.ClmnElem.ReadOnly = true;
            // 
            // ClmnDiffCoef
            // 
            this.ClmnDiffCoef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmnDiffCoef.HeaderText = "Коэф. диффузии";
            this.ClmnDiffCoef.Name = "ClmnDiffCoef";
            this.ClmnDiffCoef.ReadOnly = true;
            // 
            // ClmnConcentration
            // 
            this.ClmnConcentration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmnConcentration.HeaderText = "Концентрация";
            this.ClmnConcentration.Name = "ClmnConcentration";
            this.ClmnConcentration.ReadOnly = true;
            // 
            // ClmnTherm
            // 
            this.ClmnTherm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmnTherm.FillWeight = 69.16307F;
            this.ClmnTherm.HeaderText = "Термоцикл";
            this.ClmnTherm.Name = "ClmnTherm";
            this.ClmnTherm.ReadOnly = true;
            // 
            // ClmStart
            // 
            this.ClmStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmStart.FillWeight = 70F;
            this.ClmStart.HeaderText = "Старт";
            this.ClmStart.Name = "ClmStart";
            this.ClmStart.ReadOnly = true;
            // 
            // ClmnStop
            // 
            this.ClmnStop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmnStop.FillWeight = 70F;
            this.ClmnStop.HeaderText = "Стоп";
            this.ClmnStop.Name = "ClmnStop";
            this.ClmnStop.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(400, 400);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 645);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.CheckVelocitySlider);
            this.groupBox3.Controls.Add(this.btnStopCheck);
            this.groupBox3.Controls.Add(this.btnCheckDinamic);
            this.groupBox3.Controls.Add(this.btnHideAll);
            this.groupBox3.Controls.Add(this.btnShowAll);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnClearAll);
            this.groupBox3.Controls.Add(this.btnAddNewRow);
            this.groupBox3.Controls.Add(this.txbStop);
            this.groupBox3.Controls.Add(this.txbStart);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 118);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Время действия";
            // 
            // CheckVelocitySlider
            // 
            this.CheckVelocitySlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckVelocitySlider.BackColor = System.Drawing.Color.Transparent;
            this.CheckVelocitySlider.BarInnerColor = System.Drawing.Color.Gold;
            this.CheckVelocitySlider.BarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.CheckVelocitySlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.CheckVelocitySlider.LargeChange = ((uint)(5u));
            this.CheckVelocitySlider.Location = new System.Drawing.Point(229, 79);
            this.CheckVelocitySlider.Margin = new System.Windows.Forms.Padding(3, 3, 28, 0);
            this.CheckVelocitySlider.Maximum = 5000;
            this.CheckVelocitySlider.Minimum = 1;
            this.CheckVelocitySlider.Name = "CheckVelocitySlider";
            this.CheckVelocitySlider.Size = new System.Drawing.Size(365, 26);
            this.CheckVelocitySlider.SmallChange = ((uint)(1u));
            this.CheckVelocitySlider.TabIndex = 49;
            this.CheckVelocitySlider.Text = "colorSlider";
            this.CheckVelocitySlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.CheckVelocitySlider.Value = 500;
            this.CheckVelocitySlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CheckVelocitySlider_Scroll);
            // 
            // btnStopCheck
            // 
            this.btnStopCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnStopCheck.Image")));
            this.btnStopCheck.Location = new System.Drawing.Point(197, 79);
            this.btnStopCheck.Name = "btnStopCheck";
            this.btnStopCheck.Size = new System.Drawing.Size(26, 26);
            this.btnStopCheck.TabIndex = 15;
            this.btnStopCheck.UseVisualStyleBackColor = true;
            this.btnStopCheck.Click += new System.EventHandler(this.StopChecking_Click);
            // 
            // btnCheckDinamic
            // 
            this.btnCheckDinamic.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckDinamic.Image")));
            this.btnCheckDinamic.Location = new System.Drawing.Point(165, 79);
            this.btnCheckDinamic.Name = "btnCheckDinamic";
            this.btnCheckDinamic.Size = new System.Drawing.Size(26, 26);
            this.btnCheckDinamic.TabIndex = 14;
            this.btnCheckDinamic.UseVisualStyleBackColor = true;
            this.btnCheckDinamic.Click += new System.EventHandler(this.StartChecking_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.Location = new System.Drawing.Point(133, 79);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(26, 26);
            this.btnHideAll.TabIndex = 13;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.Location = new System.Drawing.Point(101, 79);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(26, 26);
            this.btnShowAll.TabIndex = 12;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(69, 79);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 26);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.Location = new System.Drawing.Point(37, 79);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(26, 26);
            this.btnClearAll.TabIndex = 10;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.Image")));
            this.btnAddNewRow.Location = new System.Drawing.Point(5, 79);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(26, 26);
            this.btnAddNewRow.TabIndex = 9;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStop
            // 
            this.txbStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStop.Location = new System.Drawing.Point(154, 45);
            this.txbStop.Name = "txbStop";
            this.txbStop.Size = new System.Drawing.Size(436, 20);
            this.txbStop.TabIndex = 6;
            // 
            // txbStart
            // 
            this.txbStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStart.Location = new System.Drawing.Point(154, 21);
            this.txbStart.Name = "txbStart";
            this.txbStart.Size = new System.Drawing.Size(435, 20);
            this.txbStart.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Стоп,с";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Старт,с";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.txbDiffCoefNitro);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txbConcentrNitro);
            this.groupBox2.Controls.Add(this.txbConcentrCarbon);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rbtFunction);
            this.groupBox2.Controls.Add(this.rbtParam);
            this.groupBox2.Controls.Add(this.cmbEl);
            this.groupBox2.Controls.Add(this.cmbTempreture);
            this.groupBox2.Controls.Add(this.txbDiffCoefCarbon);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 114);
            this.groupBox2.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 174);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // txbDiffCoefNitro
            // 
            this.txbDiffCoefNitro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDiffCoefNitro.Location = new System.Drawing.Point(154, 70);
            this.txbDiffCoefNitro.Name = "txbDiffCoefNitro";
            this.txbDiffCoefNitro.Size = new System.Drawing.Size(436, 20);
            this.txbDiffCoefNitro.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Коэф. диффузии N, %";
            // 
            // txbConcentrNitro
            // 
            this.txbConcentrNitro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbConcentrNitro.Location = new System.Drawing.Point(154, 96);
            this.txbConcentrNitro.Name = "txbConcentrNitro";
            this.txbConcentrNitro.Size = new System.Drawing.Size(435, 20);
            this.txbConcentrNitro.TabIndex = 18;
            // 
            // txbConcentrCarbon
            // 
            this.txbConcentrCarbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbConcentrCarbon.Location = new System.Drawing.Point(154, 44);
            this.txbConcentrCarbon.Name = "txbConcentrCarbon";
            this.txbConcentrCarbon.Size = new System.Drawing.Size(436, 20);
            this.txbConcentrCarbon.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Концентрация N, %";
            // 
            // rbtFunction
            // 
            this.rbtFunction.AutoSize = true;
            this.rbtFunction.Location = new System.Drawing.Point(236, 122);
            this.rbtFunction.Name = "rbtFunction";
            this.rbtFunction.Size = new System.Drawing.Size(71, 17);
            this.rbtFunction.TabIndex = 11;
            this.rbtFunction.TabStop = true;
            this.rbtFunction.Text = "Функция";
            this.rbtFunction.UseVisualStyleBackColor = true;
            this.rbtFunction.Click += new System.EventHandler(this.rbtFunction_Click);
            // 
            // rbtParam
            // 
            this.rbtParam.AutoSize = true;
            this.rbtParam.Location = new System.Drawing.Point(154, 122);
            this.rbtParam.Name = "rbtParam";
            this.rbtParam.Size = new System.Drawing.Size(76, 17);
            this.rbtParam.TabIndex = 10;
            this.rbtParam.TabStop = true;
            this.rbtParam.Text = "Параметр";
            this.rbtParam.UseVisualStyleBackColor = true;
            this.rbtParam.Click += new System.EventHandler(this.rbtParam_Click);
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.Location = new System.Drawing.Point(154, 149);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(436, 21);
            this.cmbEl.TabIndex = 9;
            // 
            // cmbTempreture
            // 
            this.cmbTempreture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTempreture.FormattingEnabled = true;
            this.cmbTempreture.Location = new System.Drawing.Point(313, 122);
            this.cmbTempreture.Name = "cmbTempreture";
            this.cmbTempreture.Size = new System.Drawing.Size(276, 21);
            this.cmbTempreture.TabIndex = 8;
            // 
            // txbDiffCoefCarbon
            // 
            this.txbDiffCoefCarbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDiffCoefCarbon.Location = new System.Drawing.Point(154, 19);
            this.txbDiffCoefCarbon.Name = "txbDiffCoefCarbon";
            this.txbDiffCoefCarbon.Size = new System.Drawing.Size(436, 20);
            this.txbDiffCoefCarbon.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Группа элементов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Температура, °С";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Концентрация C, %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэф. диффузии C, %";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.rbtNitrocarburizing);
            this.groupBox1.Controls.Add(this.rbtCarburization);
            this.groupBox1.Controls.Add(this.rbtNitritization);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид процесса";
            // 
            // rbtNitrocarburizing
            // 
            this.rbtNitrocarburizing.AutoSize = true;
            this.rbtNitrocarburizing.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtNitrocarburizing.Location = new System.Drawing.Point(188, 16);
            this.rbtNitrocarburizing.Name = "rbtNitrocarburizing";
            this.rbtNitrocarburizing.Size = new System.Drawing.Size(117, 36);
            this.rbtNitrocarburizing.TabIndex = 6;
            this.rbtNitrocarburizing.TabStop = true;
            this.rbtNitrocarburizing.Text = "Нитроцементация";
            this.rbtNitrocarburizing.UseVisualStyleBackColor = true;
            this.rbtNitrocarburizing.Click += new System.EventHandler(this.rbtNitrocarburizing_Click);
            // 
            // rbtCarburization
            // 
            this.rbtCarburization.AutoSize = true;
            this.rbtCarburization.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtCarburization.Location = new System.Drawing.Point(100, 16);
            this.rbtCarburization.Name = "rbtCarburization";
            this.rbtCarburization.Size = new System.Drawing.Size(88, 36);
            this.rbtCarburization.TabIndex = 5;
            this.rbtCarburization.TabStop = true;
            this.rbtCarburization.Text = "Цементация";
            this.rbtCarburization.UseVisualStyleBackColor = true;
            this.rbtCarburization.Click += new System.EventHandler(this.rbtCarburization_Click);
            // 
            // rbtNitritization
            // 
            this.rbtNitritization.AutoSize = true;
            this.rbtNitritization.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtNitritization.Location = new System.Drawing.Point(3, 16);
            this.rbtNitritization.Name = "rbtNitritization";
            this.rbtNitritization.Size = new System.Drawing.Size(97, 36);
            this.rbtNitritization.TabIndex = 4;
            this.rbtNitritization.TabStop = true;
            this.rbtNitritization.Text = "Азотирование";
            this.rbtNitritization.UseVisualStyleBackColor = true;
            this.rbtNitritization.Click += new System.EventHandler(this.rbtNitritization_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtAlphaFe);
            this.groupBox4.Controls.Add(this.rbtGammaFe);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(613, 44);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Материал";
            // 
            // rbtAlphaFe
            // 
            this.rbtAlphaFe.AutoSize = true;
            this.rbtAlphaFe.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtAlphaFe.Location = new System.Drawing.Point(3, 16);
            this.rbtAlphaFe.Name = "rbtAlphaFe";
            this.rbtAlphaFe.Size = new System.Drawing.Size(47, 25);
            this.rbtAlphaFe.TabIndex = 15;
            this.rbtAlphaFe.TabStop = true;
            this.rbtAlphaFe.Text = "α Fe";
            this.rbtAlphaFe.UseVisualStyleBackColor = true;
            this.rbtAlphaFe.Click += new System.EventHandler(this.rbtAlphaFe_Click);
            // 
            // rbtGammaFe
            // 
            this.rbtGammaFe.AutoSize = true;
            this.rbtGammaFe.Location = new System.Drawing.Point(100, 20);
            this.rbtGammaFe.Name = "rbtGammaFe";
            this.rbtGammaFe.Size = new System.Drawing.Size(46, 17);
            this.rbtGammaFe.TabIndex = 15;
            this.rbtGammaFe.TabStop = true;
            this.rbtGammaFe.Text = "γ Fe";
            this.rbtGammaFe.UseVisualStyleBackColor = true;
            this.rbtGammaFe.Click += new System.EventHandler(this.rbtGammaFe_Click);
            // 
            // DiffusionСontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(400, 0);
            this.Name = "DiffusionСontrol";
            this.Size = new System.Drawing.Size(619, 645);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEl;
        private System.Windows.Forms.ComboBox cmbTempreture;
        private System.Windows.Forms.TextBox txbDiffCoefCarbon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtNitritization;
        private System.Windows.Forms.RadioButton rbtNitrocarburizing;
        private System.Windows.Forms.RadioButton rbtCarburization;
        private System.Windows.Forms.RadioButton rbtFunction;
        private System.Windows.Forms.RadioButton rbtParam;
        private System.Windows.Forms.GroupBox groupBox3;
        private MB.Controls.ColorSlider CheckVelocitySlider;
        private System.Windows.Forms.Button btnStopCheck;
        private System.Windows.Forms.Button btnCheckDinamic;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.TextBox txbStop;
        private System.Windows.Forms.TextBox txbStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtGammaFe;
        private System.Windows.Forms.TextBox txbConcentrNitro;
        private System.Windows.Forms.TextBox txbConcentrCarbon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbDiffCoefNitro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtAlphaFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnElem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnDiffCoef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnConcentration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnTherm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnStop;
    }
}
