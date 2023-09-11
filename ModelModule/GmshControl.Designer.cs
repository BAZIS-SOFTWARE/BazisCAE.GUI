using GmshApi;
using GmshApi.Api;
namespace ModelModule
{
    partial class GmshControl
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
            GmshWrapperConnection.Finalize();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.meshDelBtn = new System.Windows.Forms.Button();
            this.algoChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.meshDensityValue = new System.Windows.Forms.TextBox();
            this.meshGenBtn = new System.Windows.Forms.Button();
            this.meshGenBox = new System.Windows.Forms.GroupBox();
            this.densityLabel = new System.Windows.Forms.Label();
            this.meshLayout = new System.Windows.Forms.TableLayoutPanel();
            this.meshElBox = new System.Windows.Forms.GroupBox();
            this.meshOptLayout = new System.Windows.Forms.TableLayoutPanel();
            this.elemsTree = new System.Windows.Forms.TreeView();
            this.meshElPanel = new System.Windows.Forms.Panel();
            this.elemDelBtn = new System.Windows.Forms.Button();
            this.meshOpBox = new System.Windows.Forms.GroupBox();
            this.meshExit = new System.Windows.Forms.Button();
            this.quadBtn = new System.Windows.Forms.Button();
            this.refineBtn = new System.Windows.Forms.Button();
            this.meshPage = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.algoCoef = new System.Windows.Forms.TextBox();
            this.algoNPoints = new System.Windows.Forms.TextBox();
            this.progAlgo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bumpAlgo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.betaAlgo = new System.Windows.Forms.RadioButton();
            this.algoBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pointsControlBox = new System.Windows.Forms.GroupBox();
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volExit = new System.Windows.Forms.Button();
            this.volDelBtn = new System.Windows.Forms.Button();
            this.volumesTree = new System.Windows.Forms.TreeView();
            this.volElPanel = new System.Windows.Forms.Panel();
            this.volumeOptLayout = new System.Windows.Forms.TableLayoutPanel();
            this.volElBox = new System.Windows.Forms.GroupBox();
            this.entTree = new System.Windows.Forms.TreeView();
            this.volumeBox = new System.Windows.Forms.GroupBox();
            this.delVolBtn = new System.Windows.Forms.Button();
            this.volGenBtn = new System.Windows.Forms.Button();
            this.volumePage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.geometryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.filterBox = new System.Windows.Forms.TabControl();
            this.boundFilter = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.betaBox = new System.Windows.Forms.GroupBox();
            this.beta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nbLayers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fanBox = new System.Windows.Forms.GroupBox();
            this.fanPointsSizesList = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.anisoMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fanPointsList = new System.Windows.Forms.TextBox();
            this.layersBox = new System.Windows.Forms.GroupBox();
            this.ratio = new System.Windows.Forms.TextBox();
            this.thickness = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.excludedSurfacesList = new System.Windows.Forms.TextBox();
            this.curvesList = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pointsList = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flagsBetaPnl = new System.Windows.Forms.Panel();
            this.addFilter = new System.Windows.Forms.Button();
            this.quads = new System.Windows.Forms.CheckBox();
            this.intersectMetrics = new System.Windows.Forms.CheckBox();
            this.betaLaw = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sizesList = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.sizeFar = new System.Windows.Forms.TextBox();
            this.loadModelBox = new System.Windows.Forms.GroupBox();
            this.geoDelBtn = new System.Windows.Forms.Button();
            this.geoLoadBtn = new System.Windows.Forms.Button();
            this.geoElBox = new System.Windows.Forms.GroupBox();
            this.elementsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.gmshTab = new System.Windows.Forms.TabControl();
            this.meshGenBox.SuspendLayout();
            this.meshLayout.SuspendLayout();
            this.meshElBox.SuspendLayout();
            this.meshOptLayout.SuspendLayout();
            this.meshElPanel.SuspendLayout();
            this.meshOpBox.SuspendLayout();
            this.meshPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.algoBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pointsControlBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.volElPanel.SuspendLayout();
            this.volumeOptLayout.SuspendLayout();
            this.volElBox.SuspendLayout();
            this.volumeBox.SuspendLayout();
            this.volumePage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.geometryLayout.SuspendLayout();
            this.filterBox.SuspendLayout();
            this.boundFilter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.betaBox.SuspendLayout();
            this.fanBox.SuspendLayout();
            this.layersBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flagsBetaPnl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.loadModelBox.SuspendLayout();
            this.geoElBox.SuspendLayout();
            this.elementsLayout.SuspendLayout();
            this.geometryPage.SuspendLayout();
            this.gmshTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // meshDelBtn
            // 
            this.meshDelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshDelBtn.Enabled = false;
            this.meshDelBtn.Location = new System.Drawing.Point(323, 71);
            this.meshDelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshDelBtn.Name = "meshDelBtn";
            this.meshDelBtn.Size = new System.Drawing.Size(131, 32);
            this.meshDelBtn.TabIndex = 9;
            this.meshDelBtn.Text = "Удалить";
            this.meshDelBtn.UseVisualStyleBackColor = true;
            this.meshDelBtn.Click += new System.EventHandler(this.OnDeleteMesh);
            // 
            // algoChoice
            // 
            this.algoChoice.FormattingEnabled = true;
            this.algoChoice.Items.AddRange(new object[] {
            "MeshAdapt",
            "Automatic",
            "Delaunay",
            "FrontalDelaunay",
            "FrontalDelaunayQuad"});
            this.algoChoice.Location = new System.Drawing.Point(323, 25);
            this.algoChoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoChoice.Name = "algoChoice";
            this.algoChoice.Size = new System.Drawing.Size(151, 24);
            this.algoChoice.TabIndex = 8;
            this.algoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Алгоритм построения сетки:";
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.meshDensityValue.Location = new System.Drawing.Point(7, 81);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(120, 22);
            this.meshDensityValue.TabIndex = 6;
            this.meshDensityValue.Text = "1";
            this.meshDensityValue.TextChanged += new System.EventHandler(this.OnDencityChange);
            // 
            // meshGenBtn
            // 
            this.meshGenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshGenBtn.Location = new System.Drawing.Point(161, 71);
            this.meshGenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshGenBtn.Name = "meshGenBtn";
            this.meshGenBtn.Size = new System.Drawing.Size(131, 32);
            this.meshGenBtn.TabIndex = 5;
            this.meshGenBtn.Text = "Сгенерировать";
            this.meshGenBtn.UseVisualStyleBackColor = true;
            this.meshGenBtn.Click += new System.EventHandler(this.OnGenerateMesh);
            // 
            // meshGenBox
            // 
            this.meshGenBox.Controls.Add(this.meshDelBtn);
            this.meshGenBox.Controls.Add(this.algoChoice);
            this.meshGenBox.Controls.Add(this.label1);
            this.meshGenBox.Controls.Add(this.meshDensityValue);
            this.meshGenBox.Controls.Add(this.densityLabel);
            this.meshGenBox.Controls.Add(this.meshGenBtn);
            this.meshGenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshGenBox.Enabled = false;
            this.meshGenBox.Location = new System.Drawing.Point(3, 2);
            this.meshGenBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshGenBox.Name = "meshGenBox";
            this.meshGenBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshGenBox.Size = new System.Drawing.Size(480, 107);
            this.meshGenBox.TabIndex = 3;
            this.meshGenBox.TabStop = false;
            this.meshGenBox.Text = "Управление сеткой";
            // 
            // densityLabel
            // 
            this.densityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(4, 53);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(135, 16);
            this.densityLabel.TabIndex = 0;
            this.densityLabel.Text = "Размер элементов:";
            // 
            // meshLayout
            // 
            this.meshLayout.ColumnCount = 1;
            this.meshLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.meshLayout.Controls.Add(this.meshGenBox, 0, 0);
            this.meshLayout.Controls.Add(this.meshElBox, 0, 1);
            this.meshLayout.Controls.Add(this.meshOpBox, 0, 2);
            this.meshLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshLayout.Location = new System.Drawing.Point(3, 2);
            this.meshLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshLayout.Name = "meshLayout";
            this.meshLayout.RowCount = 3;
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.72122F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.73601F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.40376F));
            this.meshLayout.Size = new System.Drawing.Size(486, 947);
            this.meshLayout.TabIndex = 0;
            // 
            // meshElBox
            // 
            this.meshElBox.Controls.Add(this.meshOptLayout);
            this.meshElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshElBox.Enabled = false;
            this.meshElBox.Location = new System.Drawing.Point(3, 113);
            this.meshElBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshElBox.Name = "meshElBox";
            this.meshElBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshElBox.Size = new System.Drawing.Size(480, 467);
            this.meshElBox.TabIndex = 5;
            this.meshElBox.TabStop = false;
            this.meshElBox.Text = "Элементы сетки";
            // 
            // meshOptLayout
            // 
            this.meshOptLayout.ColumnCount = 2;
            this.meshOptLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.meshOptLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.meshOptLayout.Controls.Add(this.elemsTree, 0, 0);
            this.meshOptLayout.Controls.Add(this.meshElPanel, 1, 0);
            this.meshOptLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshOptLayout.Location = new System.Drawing.Point(3, 17);
            this.meshOptLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshOptLayout.Name = "meshOptLayout";
            this.meshOptLayout.RowCount = 1;
            this.meshOptLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.meshOptLayout.Size = new System.Drawing.Size(474, 448);
            this.meshOptLayout.TabIndex = 4;
            // 
            // elemsTree
            // 
            this.elemsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elemsTree.Location = new System.Drawing.Point(3, 2);
            this.elemsTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elemsTree.Name = "elemsTree";
            this.elemsTree.Size = new System.Drawing.Size(278, 444);
            this.elemsTree.TabIndex = 0;
            this.elemsTree.Tag = "elemsTree";
            this.elemsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeChange);
            // 
            // meshElPanel
            // 
            this.meshElPanel.Controls.Add(this.elemDelBtn);
            this.meshElPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshElPanel.Location = new System.Drawing.Point(287, 2);
            this.meshElPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshElPanel.Name = "meshElPanel";
            this.meshElPanel.Size = new System.Drawing.Size(184, 444);
            this.meshElPanel.TabIndex = 1;
            // 
            // elemDelBtn
            // 
            this.elemDelBtn.Location = new System.Drawing.Point(33, 398);
            this.elemDelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elemDelBtn.Name = "elemDelBtn";
            this.elemDelBtn.Size = new System.Drawing.Size(131, 32);
            this.elemDelBtn.TabIndex = 10;
            this.elemDelBtn.Text = "Удалить";
            this.elemDelBtn.UseVisualStyleBackColor = true;
            this.elemDelBtn.Click += new System.EventHandler(this.OnDeleteElement);
            // 
            // meshOpBox
            // 
            this.meshOpBox.Controls.Add(this.meshExit);
            this.meshOpBox.Controls.Add(this.quadBtn);
            this.meshOpBox.Controls.Add(this.refineBtn);
            this.meshOpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshOpBox.Enabled = false;
            this.meshOpBox.Location = new System.Drawing.Point(3, 584);
            this.meshOpBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshOpBox.Name = "meshOpBox";
            this.meshOpBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshOpBox.Size = new System.Drawing.Size(480, 361);
            this.meshOpBox.TabIndex = 6;
            this.meshOpBox.TabStop = false;
            this.meshOpBox.Text = "Операции с сеткой";
            // 
            // meshExit
            // 
            this.meshExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshExit.Location = new System.Drawing.Point(329, 21);
            this.meshExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshExit.Name = "meshExit";
            this.meshExit.Size = new System.Drawing.Size(145, 32);
            this.meshExit.TabIndex = 12;
            this.meshExit.Text = "Ок";
            this.meshExit.UseVisualStyleBackColor = true;
            this.meshExit.Click += new System.EventHandler(this.OnExit);
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quadBtn.Location = new System.Drawing.Point(168, 21);
            this.quadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quadBtn.Name = "quadBtn";
            this.quadBtn.Size = new System.Drawing.Size(145, 32);
            this.quadBtn.TabIndex = 11;
            this.quadBtn.Text = "Квадратизировать";
            this.quadBtn.UseVisualStyleBackColor = true;
            this.quadBtn.Click += new System.EventHandler(this.OnQuadrangulate);
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refineBtn.Location = new System.Drawing.Point(6, 21);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(145, 32);
            this.refineBtn.TabIndex = 10;
            this.refineBtn.Text = "Уплотнить";
            this.refineBtn.UseVisualStyleBackColor = true;
            this.refineBtn.Click += new System.EventHandler(this.OnRefine);
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 25);
            this.meshPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshPage.Name = "meshPage";
            this.meshPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshPage.Size = new System.Drawing.Size(492, 951);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(32, 12);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 32);
            this.button6.TabIndex = 9;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 225);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 65);
            this.panel3.TabIndex = 0;
            // 
            // algoCoef
            // 
            this.algoCoef.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.algoCoef.Location = new System.Drawing.Point(42, 135);
            this.algoCoef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoCoef.Name = "algoCoef";
            this.algoCoef.Size = new System.Drawing.Size(100, 22);
            this.algoCoef.TabIndex = 4;
            this.algoCoef.Tag = "algoCoef";
            this.algoCoef.Text = "1.0";
            this.algoCoef.Validated += new System.EventHandler(this.OnTransfiniteCurve);
            // 
            // algoNPoints
            // 
            this.algoNPoints.Location = new System.Drawing.Point(42, 189);
            this.algoNPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoNPoints.Name = "algoNPoints";
            this.algoNPoints.Size = new System.Drawing.Size(100, 22);
            this.algoNPoints.TabIndex = 5;
            this.algoNPoints.Tag = "algoNPoints";
            this.algoNPoints.Validated += new System.EventHandler(this.OnTransfiniteCurve);
            // 
            // progAlgo
            // 
            this.progAlgo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progAlgo.AutoSize = true;
            this.progAlgo.Checked = true;
            this.progAlgo.Location = new System.Drawing.Point(43, 22);
            this.progAlgo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progAlgo.Name = "progAlgo";
            this.progAlgo.Size = new System.Drawing.Size(101, 20);
            this.progAlgo.TabIndex = 0;
            this.progAlgo.TabStop = true;
            this.progAlgo.Tag = "Progressive";
            this.progAlgo.Text = "Progressive";
            this.progAlgo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Число точек:";
            // 
            // bumpAlgo
            // 
            this.bumpAlgo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bumpAlgo.AutoSize = true;
            this.bumpAlgo.Location = new System.Drawing.Point(43, 53);
            this.bumpAlgo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bumpAlgo.Name = "bumpAlgo";
            this.bumpAlgo.Size = new System.Drawing.Size(63, 20);
            this.bumpAlgo.TabIndex = 1;
            this.bumpAlgo.Tag = "Bump";
            this.bumpAlgo.Text = "Bump";
            this.bumpAlgo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Коэффициент:";
            // 
            // betaAlgo
            // 
            this.betaAlgo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.betaAlgo.AutoSize = true;
            this.betaAlgo.Location = new System.Drawing.Point(43, 85);
            this.betaAlgo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.betaAlgo.Name = "betaAlgo";
            this.betaAlgo.Size = new System.Drawing.Size(56, 20);
            this.betaAlgo.TabIndex = 2;
            this.betaAlgo.Tag = "Beta";
            this.betaAlgo.Text = "Beta";
            this.betaAlgo.UseVisualStyleBackColor = true;
            // 
            // algoBox
            // 
            this.algoBox.Controls.Add(this.algoCoef);
            this.algoBox.Controls.Add(this.algoNPoints);
            this.algoBox.Controls.Add(this.progAlgo);
            this.algoBox.Controls.Add(this.label2);
            this.algoBox.Controls.Add(this.bumpAlgo);
            this.algoBox.Controls.Add(this.label3);
            this.algoBox.Controls.Add(this.betaAlgo);
            this.algoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algoBox.Location = new System.Drawing.Point(3, 2);
            this.algoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoBox.Name = "algoBox";
            this.algoBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoBox.Size = new System.Drawing.Size(194, 218);
            this.algoBox.TabIndex = 2;
            this.algoBox.TabStop = false;
            this.algoBox.Text = "Уточнение кривых";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.algoBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.10921F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.89079F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 293);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pointsControlBox
            // 
            this.pointsControlBox.Controls.Add(this.tableLayoutPanel4);
            this.pointsControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointsControlBox.Enabled = false;
            this.pointsControlBox.Location = new System.Drawing.Point(3, 2);
            this.pointsControlBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pointsControlBox.Name = "pointsControlBox";
            this.pointsControlBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pointsControlBox.Size = new System.Drawing.Size(206, 312);
            this.pointsControlBox.TabIndex = 12;
            this.pointsControlBox.TabStop = false;
            this.pointsControlBox.Text = "Кривые";
            // 
            // loadFileDialog
            // 
            this.loadFileDialog.FileName = "untitled.geo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.volExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 420);
            this.panel1.TabIndex = 7;
            // 
            // volExit
            // 
            this.volExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volExit.Location = new System.Drawing.Point(314, 45);
            this.volExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volExit.Name = "volExit";
            this.volExit.Size = new System.Drawing.Size(149, 32);
            this.volExit.TabIndex = 13;
            this.volExit.Text = "Ок";
            this.volExit.UseVisualStyleBackColor = true;
            // 
            // volDelBtn
            // 
            this.volDelBtn.Location = new System.Drawing.Point(17, 384);
            this.volDelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volDelBtn.Name = "volDelBtn";
            this.volDelBtn.Size = new System.Drawing.Size(149, 32);
            this.volDelBtn.TabIndex = 11;
            this.volDelBtn.Text = "Удалить";
            this.volDelBtn.UseVisualStyleBackColor = true;
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(3, 2);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(282, 426);
            this.volumesTree.TabIndex = 0;
            // 
            // volElPanel
            // 
            this.volElPanel.Controls.Add(this.volDelBtn);
            this.volElPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volElPanel.Location = new System.Drawing.Point(291, 2);
            this.volElPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volElPanel.Name = "volElPanel";
            this.volElPanel.Size = new System.Drawing.Size(186, 426);
            this.volElPanel.TabIndex = 1;
            // 
            // volumeOptLayout
            // 
            this.volumeOptLayout.ColumnCount = 2;
            this.volumeOptLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.volumeOptLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.volumeOptLayout.Controls.Add(this.volumesTree, 0, 0);
            this.volumeOptLayout.Controls.Add(this.volElPanel, 1, 0);
            this.volumeOptLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeOptLayout.Location = new System.Drawing.Point(3, 17);
            this.volumeOptLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumeOptLayout.Name = "volumeOptLayout";
            this.volumeOptLayout.RowCount = 1;
            this.volumeOptLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeOptLayout.Size = new System.Drawing.Size(480, 430);
            this.volumeOptLayout.TabIndex = 5;
            // 
            // volElBox
            // 
            this.volElBox.Controls.Add(this.volumeOptLayout);
            this.volElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volElBox.Enabled = false;
            this.volElBox.Location = new System.Drawing.Point(3, 74);
            this.volElBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volElBox.Name = "volElBox";
            this.volElBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volElBox.Size = new System.Drawing.Size(486, 449);
            this.volElBox.TabIndex = 6;
            this.volElBox.TabStop = false;
            this.volElBox.Text = "Элементы объемов";
            // 
            // entTree
            // 
            this.entTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entTree.HideSelection = false;
            this.entTree.Location = new System.Drawing.Point(3, 2);
            this.entTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entTree.Name = "entTree";
            this.entTree.Size = new System.Drawing.Size(250, 306);
            this.entTree.TabIndex = 6;
            this.entTree.Tag = "entTree";
            this.entTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeChange);
            // 
            // volumeBox
            // 
            this.volumeBox.Controls.Add(this.delVolBtn);
            this.volumeBox.Controls.Add(this.volGenBtn);
            this.volumeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeBox.Enabled = false;
            this.volumeBox.Location = new System.Drawing.Point(3, 2);
            this.volumeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumeBox.Size = new System.Drawing.Size(486, 68);
            this.volumeBox.TabIndex = 4;
            this.volumeBox.TabStop = false;
            this.volumeBox.Text = "Управление объемами";
            // 
            // delVolBtn
            // 
            this.delVolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delVolBtn.Enabled = false;
            this.delVolBtn.Location = new System.Drawing.Point(307, 28);
            this.delVolBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delVolBtn.Name = "delVolBtn";
            this.delVolBtn.Size = new System.Drawing.Size(149, 32);
            this.delVolBtn.TabIndex = 6;
            this.delVolBtn.Text = "Удалить";
            this.delVolBtn.UseVisualStyleBackColor = true;
            this.delVolBtn.Click += new System.EventHandler(this.OnDeleteVolume);
            // 
            // volGenBtn
            // 
            this.volGenBtn.Location = new System.Drawing.Point(21, 28);
            this.volGenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volGenBtn.Name = "volGenBtn";
            this.volGenBtn.Size = new System.Drawing.Size(149, 32);
            this.volGenBtn.TabIndex = 5;
            this.volGenBtn.Text = "Сгенерировать";
            this.volGenBtn.UseVisualStyleBackColor = true;
            this.volGenBtn.Click += new System.EventHandler(this.OnGenerateVolume);
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.tableLayoutPanel1);
            this.volumePage.Location = new System.Drawing.Point(4, 25);
            this.volumePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(492, 951);
            this.volumePage.TabIndex = 2;
            this.volumePage.Text = "3D";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.volumeBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.volElBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.656396F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.63119F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 951);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pointsControlBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(259, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 316F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(212, 306);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // geometryLayout
            // 
            this.geometryLayout.ColumnCount = 1;
            this.geometryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.Controls.Add(this.filterBox, 0, 2);
            this.geometryLayout.Controls.Add(this.loadModelBox, 0, 0);
            this.geometryLayout.Controls.Add(this.geoElBox, 0, 1);
            this.geometryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryLayout.Location = new System.Drawing.Point(3, 2);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 3;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 333F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.geometryLayout.Size = new System.Drawing.Size(486, 947);
            this.geometryLayout.TabIndex = 0;
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.boundFilter);
            this.filterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterBox.Enabled = false;
            this.filterBox.Location = new System.Drawing.Point(3, 396);
            this.filterBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterBox.Name = "filterBox";
            this.filterBox.SelectedIndex = 0;
            this.filterBox.Size = new System.Drawing.Size(480, 549);
            this.filterBox.TabIndex = 6;
            // 
            // boundFilter
            // 
            this.boundFilter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.boundFilter.Controls.Add(this.tableLayoutPanel2);
            this.boundFilter.Location = new System.Drawing.Point(4, 25);
            this.boundFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boundFilter.Name = "boundFilter";
            this.boundFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boundFilter.Size = new System.Drawing.Size(472, 520);
            this.boundFilter.TabIndex = 0;
            this.boundFilter.Text = "Граничный";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.betaBox, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.fanBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.layersBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flagsBetaPnl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 516);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // betaBox
            // 
            this.betaBox.Controls.Add(this.beta);
            this.betaBox.Controls.Add(this.label5);
            this.betaBox.Controls.Add(this.nbLayers);
            this.betaBox.Controls.Add(this.label4);
            this.betaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.betaBox.Enabled = false;
            this.betaBox.Location = new System.Drawing.Point(3, 421);
            this.betaBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.betaBox.Name = "betaBox";
            this.betaBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.betaBox.Size = new System.Drawing.Size(460, 93);
            this.betaBox.TabIndex = 13;
            this.betaBox.TabStop = false;
            this.betaBox.Text = "Закон бета";
            // 
            // beta
            // 
            this.beta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.beta.Location = new System.Drawing.Point(317, 42);
            this.beta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(131, 22);
            this.beta.TabIndex = 3;
            this.beta.Tag = "Beta 1,01";
            this.beta.Text = "1,01";
            this.beta.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Коэффициент:";
            // 
            // nbLayers
            // 
            this.nbLayers.Location = new System.Drawing.Point(11, 42);
            this.nbLayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbLayers.Name = "nbLayers";
            this.nbLayers.Size = new System.Drawing.Size(131, 22);
            this.nbLayers.TabIndex = 1;
            this.nbLayers.Tag = "NbLayers 10";
            this.nbLayers.Text = "10";
            this.nbLayers.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Количество слоев:";
            // 
            // fanBox
            // 
            this.fanBox.Controls.Add(this.fanPointsSizesList);
            this.fanBox.Controls.Add(this.label8);
            this.fanBox.Controls.Add(this.anisoMax);
            this.fanBox.Controls.Add(this.label6);
            this.fanBox.Controls.Add(this.label7);
            this.fanBox.Controls.Add(this.fanPointsList);
            this.fanBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fanBox.Location = new System.Drawing.Point(3, 330);
            this.fanBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fanBox.Name = "fanBox";
            this.fanBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fanBox.Size = new System.Drawing.Size(460, 87);
            this.fanBox.TabIndex = 11;
            this.fanBox.TabStop = false;
            this.fanBox.Text = "Настройки скруглений:";
            // 
            // fanPointsSizesList
            // 
            this.fanPointsSizesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fanPointsSizesList.Location = new System.Drawing.Point(317, 54);
            this.fanPointsSizesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fanPointsSizesList.Name = "fanPointsSizesList";
            this.fanPointsSizesList.Size = new System.Drawing.Size(131, 22);
            this.fanPointsSizesList.TabIndex = 8;
            this.fanPointsSizesList.Tag = "FanPointsSizesList";
            this.fanPointsSizesList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Пороговый угол:";
            // 
            // anisoMax
            // 
            this.anisoMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.anisoMax.Location = new System.Drawing.Point(18, 54);
            this.anisoMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.anisoMax.Name = "anisoMax";
            this.anisoMax.Size = new System.Drawing.Size(131, 22);
            this.anisoMax.TabIndex = 4;
            this.anisoMax.Tag = "AnisoMax 10000000000";
            this.anisoMax.Text = "10000000000";
            this.anisoMax.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Элем. на точку:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Список точек:";
            // 
            // fanPointsList
            // 
            this.fanPointsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fanPointsList.Location = new System.Drawing.Point(165, 54);
            this.fanPointsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fanPointsList.Name = "fanPointsList";
            this.fanPointsList.Size = new System.Drawing.Size(131, 22);
            this.fanPointsList.TabIndex = 6;
            this.fanPointsList.Tag = "FanPointsList";
            this.fanPointsList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // layersBox
            // 
            this.layersBox.Controls.Add(this.ratio);
            this.layersBox.Controls.Add(this.thickness);
            this.layersBox.Controls.Add(this.label10);
            this.layersBox.Controls.Add(this.label9);
            this.layersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersBox.Location = new System.Drawing.Point(3, 248);
            this.layersBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layersBox.Name = "layersBox";
            this.layersBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layersBox.Size = new System.Drawing.Size(460, 78);
            this.layersBox.TabIndex = 10;
            this.layersBox.TabStop = false;
            this.layersBox.Text = "Настройки слоев:";
            // 
            // ratio
            // 
            this.ratio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratio.Location = new System.Drawing.Point(317, 44);
            this.ratio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ratio.Name = "ratio";
            this.ratio.Size = new System.Drawing.Size(131, 22);
            this.ratio.TabIndex = 10;
            this.ratio.Tag = "Ratio 1,1";
            this.ratio.Text = "1,1";
            this.ratio.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // thickness
            // 
            this.thickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thickness.Location = new System.Drawing.Point(18, 44);
            this.thickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(131, 22);
            this.thickness.TabIndex = 9;
            this.thickness.Tag = "Thickness 0,01";
            this.thickness.Text = "0,01";
            this.thickness.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Толщина слоя макс:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Соотнош. размеров:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.excludedSurfacesList);
            this.groupBox2.Controls.Add(this.curvesList);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.pointsList);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(460, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Общие настройки:";
            // 
            // excludedSurfacesList
            // 
            this.excludedSurfacesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.excludedSurfacesList.Location = new System.Drawing.Point(317, 47);
            this.excludedSurfacesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excludedSurfacesList.Name = "excludedSurfacesList";
            this.excludedSurfacesList.Size = new System.Drawing.Size(131, 22);
            this.excludedSurfacesList.TabIndex = 8;
            this.excludedSurfacesList.Tag = "ExcludedSurfacesList";
            this.excludedSurfacesList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // curvesList
            // 
            this.curvesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.curvesList.Location = new System.Drawing.Point(165, 47);
            this.curvesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.curvesList.Name = "curvesList";
            this.curvesList.Size = new System.Drawing.Size(131, 22);
            this.curvesList.TabIndex = 6;
            this.curvesList.Tag = "CurvesList";
            this.curvesList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Список кривых:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Список искл. поверхн:";
            // 
            // pointsList
            // 
            this.pointsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointsList.Location = new System.Drawing.Point(18, 47);
            this.pointsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pointsList.Name = "pointsList";
            this.pointsList.Size = new System.Drawing.Size(131, 22);
            this.pointsList.TabIndex = 4;
            this.pointsList.Tag = "PointsList";
            this.pointsList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Список точек:";
            // 
            // flagsBetaPnl
            // 
            this.flagsBetaPnl.Controls.Add(this.addFilter);
            this.flagsBetaPnl.Controls.Add(this.quads);
            this.flagsBetaPnl.Controls.Add(this.intersectMetrics);
            this.flagsBetaPnl.Controls.Add(this.betaLaw);
            this.flagsBetaPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flagsBetaPnl.Location = new System.Drawing.Point(3, 2);
            this.flagsBetaPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flagsBetaPnl.Name = "flagsBetaPnl";
            this.flagsBetaPnl.Size = new System.Drawing.Size(460, 74);
            this.flagsBetaPnl.TabIndex = 3;
            // 
            // addFilter
            // 
            this.addFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilter.Location = new System.Drawing.Point(303, 32);
            this.addFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addFilter.Name = "addFilter";
            this.addFilter.Size = new System.Drawing.Size(141, 32);
            this.addFilter.TabIndex = 3;
            this.addFilter.Text = "Добавить";
            this.addFilter.UseVisualStyleBackColor = true;
            this.addFilter.Click += new System.EventHandler(this.OnAddBoundFilter);
            // 
            // quads
            // 
            this.quads.AutoSize = true;
            this.quads.Location = new System.Drawing.Point(15, 37);
            this.quads.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quads.Name = "quads";
            this.quads.Size = new System.Drawing.Size(165, 20);
            this.quads.TabIndex = 2;
            this.quads.Tag = "Quads";
            this.quads.Text = "Генерировать квады";
            this.quads.UseVisualStyleBackColor = true;
            this.quads.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // intersectMetrics
            // 
            this.intersectMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.intersectMetrics.AutoSize = true;
            this.intersectMetrics.Location = new System.Drawing.Point(255, 7);
            this.intersectMetrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.intersectMetrics.Name = "intersectMetrics";
            this.intersectMetrics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.intersectMetrics.Size = new System.Drawing.Size(193, 20);
            this.intersectMetrics.TabIndex = 1;
            this.intersectMetrics.Tag = "IntersectMetrics";
            this.intersectMetrics.Text = "Пересеч метрик поверхн";
            this.intersectMetrics.UseVisualStyleBackColor = true;
            this.intersectMetrics.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // betaLaw
            // 
            this.betaLaw.AutoSize = true;
            this.betaLaw.Location = new System.Drawing.Point(15, 7);
            this.betaLaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.betaLaw.Name = "betaLaw";
            this.betaLaw.Size = new System.Drawing.Size(103, 20);
            this.betaLaw.TabIndex = 0;
            this.betaLaw.Tag = "BetaLaw";
            this.betaLaw.Text = "Закон бета";
            this.betaLaw.UseVisualStyleBackColor = true;
            this.betaLaw.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sizesList);
            this.groupBox1.Controls.Add(this.size);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.sizeFar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(460, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки размеров:";
            // 
            // sizesList
            // 
            this.sizesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizesList.Location = new System.Drawing.Point(317, 44);
            this.sizesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sizesList.Name = "sizesList";
            this.sizesList.Size = new System.Drawing.Size(131, 22);
            this.sizesList.TabIndex = 13;
            this.sizesList.Tag = "SizesList";
            this.sizesList.Validated += new System.EventHandler(this.OnFilterListEnter);
            // 
            // size
            // 
            this.size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.size.Location = new System.Drawing.Point(18, 44);
            this.size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(131, 22);
            this.size.TabIndex = 9;
            this.size.Tag = "Size 0,1";
            this.size.Text = "0,1";
            this.size.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 16);
            this.label16.TabIndex = 9;
            this.label16.Text = "Возле кривых:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(319, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Список по точкам:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(162, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "Вдали от кривых:";
            // 
            // sizeFar
            // 
            this.sizeFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeFar.Location = new System.Drawing.Point(165, 44);
            this.sizeFar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sizeFar.Name = "sizeFar";
            this.sizeFar.Size = new System.Drawing.Size(131, 22);
            this.sizeFar.TabIndex = 10;
            this.sizeFar.Tag = "SizeFar 1,0";
            this.sizeFar.Text = "1.0";
            this.sizeFar.Validated += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // loadModelBox
            // 
            this.loadModelBox.Controls.Add(this.geoDelBtn);
            this.loadModelBox.Controls.Add(this.geoLoadBtn);
            this.loadModelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadModelBox.Location = new System.Drawing.Point(3, 2);
            this.loadModelBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadModelBox.Name = "loadModelBox";
            this.loadModelBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadModelBox.Size = new System.Drawing.Size(480, 57);
            this.loadModelBox.TabIndex = 1;
            this.loadModelBox.TabStop = false;
            this.loadModelBox.Text = "Загрузка";
            // 
            // geoDelBtn
            // 
            this.geoDelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.geoDelBtn.Enabled = false;
            this.geoDelBtn.Location = new System.Drawing.Point(328, 22);
            this.geoDelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geoDelBtn.Name = "geoDelBtn";
            this.geoDelBtn.Size = new System.Drawing.Size(120, 32);
            this.geoDelBtn.TabIndex = 1;
            this.geoDelBtn.Text = "Удалить";
            this.geoDelBtn.UseVisualStyleBackColor = true;
            this.geoDelBtn.Click += new System.EventHandler(this.OnDeleteGeometry);
            // 
            // geoLoadBtn
            // 
            this.geoLoadBtn.Location = new System.Drawing.Point(35, 22);
            this.geoLoadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geoLoadBtn.Name = "geoLoadBtn";
            this.geoLoadBtn.Size = new System.Drawing.Size(120, 32);
            this.geoLoadBtn.TabIndex = 0;
            this.geoLoadBtn.Text = "Загрузить";
            this.geoLoadBtn.UseVisualStyleBackColor = true;
            this.geoLoadBtn.Click += new System.EventHandler(this.OnLoadFile);
            // 
            // geoElBox
            // 
            this.geoElBox.Controls.Add(this.elementsLayout);
            this.geoElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoElBox.Enabled = false;
            this.geoElBox.Location = new System.Drawing.Point(3, 63);
            this.geoElBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geoElBox.Name = "geoElBox";
            this.geoElBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geoElBox.Size = new System.Drawing.Size(480, 329);
            this.geoElBox.TabIndex = 3;
            this.geoElBox.TabStop = false;
            this.geoElBox.Text = "Элементы геометрии";
            // 
            // elementsLayout
            // 
            this.elementsLayout.ColumnCount = 2;
            this.elementsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.0107F));
            this.elementsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.9893F));
            this.elementsLayout.Controls.Add(this.entTree, 0, 0);
            this.elementsLayout.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.elementsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementsLayout.Location = new System.Drawing.Point(3, 17);
            this.elementsLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementsLayout.Name = "elementsLayout";
            this.elementsLayout.RowCount = 1;
            this.elementsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementsLayout.Size = new System.Drawing.Size(474, 310);
            this.elementsLayout.TabIndex = 0;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 25);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geometryPage.Size = new System.Drawing.Size(492, 951);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // gmshTab
            // 
            this.gmshTab.Controls.Add(this.geometryPage);
            this.gmshTab.Controls.Add(this.meshPage);
            this.gmshTab.Controls.Add(this.volumePage);
            this.gmshTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshTab.Location = new System.Drawing.Point(0, 0);
            this.gmshTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gmshTab.Name = "gmshTab";
            this.gmshTab.SelectedIndex = 0;
            this.gmshTab.Size = new System.Drawing.Size(500, 980);
            this.gmshTab.TabIndex = 1;
            // 
            // GmshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.MinimumSize = new System.Drawing.Size(500, 980);
            this.Name = "GmshControl";
            this.Size = new System.Drawing.Size(500, 980);
            this.Load += new System.EventHandler(this.OnLoad);
            this.meshGenBox.ResumeLayout(false);
            this.meshGenBox.PerformLayout();
            this.meshLayout.ResumeLayout(false);
            this.meshElBox.ResumeLayout(false);
            this.meshOptLayout.ResumeLayout(false);
            this.meshElPanel.ResumeLayout(false);
            this.meshOpBox.ResumeLayout(false);
            this.meshPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.algoBox.ResumeLayout(false);
            this.algoBox.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.pointsControlBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.volElPanel.ResumeLayout(false);
            this.volumeOptLayout.ResumeLayout(false);
            this.volElBox.ResumeLayout(false);
            this.volumeBox.ResumeLayout(false);
            this.volumePage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.geometryLayout.ResumeLayout(false);
            this.filterBox.ResumeLayout(false);
            this.boundFilter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.betaBox.ResumeLayout(false);
            this.betaBox.PerformLayout();
            this.fanBox.ResumeLayout(false);
            this.fanBox.PerformLayout();
            this.layersBox.ResumeLayout(false);
            this.layersBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flagsBetaPnl.ResumeLayout(false);
            this.flagsBetaPnl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.loadModelBox.ResumeLayout(false);
            this.geoElBox.ResumeLayout(false);
            this.elementsLayout.ResumeLayout(false);
            this.geometryPage.ResumeLayout(false);
            this.gmshTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button meshDelBtn;
        private System.Windows.Forms.ComboBox algoChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox meshDensityValue;
        private System.Windows.Forms.Button meshGenBtn;
        private System.Windows.Forms.GroupBox meshGenBox;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TableLayoutPanel meshLayout;
        private System.Windows.Forms.GroupBox meshElBox;
        private System.Windows.Forms.TableLayoutPanel meshOptLayout;
        private System.Windows.Forms.TreeView elemsTree;
        private System.Windows.Forms.Panel meshElPanel;
        private System.Windows.Forms.Button elemDelBtn;
        private System.Windows.Forms.GroupBox meshOpBox;
        private System.Windows.Forms.Button meshExit;
        private System.Windows.Forms.Button quadBtn;
        private System.Windows.Forms.Button refineBtn;
        private System.Windows.Forms.TabPage meshPage;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox algoCoef;
        private System.Windows.Forms.TextBox algoNPoints;
        private System.Windows.Forms.RadioButton progAlgo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton bumpAlgo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton betaAlgo;
        private System.Windows.Forms.GroupBox algoBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox pointsControlBox;
        private System.Windows.Forms.OpenFileDialog loadFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button volExit;
        private System.Windows.Forms.Button volDelBtn;
        private System.Windows.Forms.TreeView volumesTree;
        private System.Windows.Forms.Panel volElPanel;
        private System.Windows.Forms.TableLayoutPanel volumeOptLayout;
        private System.Windows.Forms.GroupBox volElBox;
        private System.Windows.Forms.TreeView entTree;
        private System.Windows.Forms.GroupBox volumeBox;
        private System.Windows.Forms.Button delVolBtn;
        private System.Windows.Forms.Button volGenBtn;
        private System.Windows.Forms.TabPage volumePage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel geometryLayout;
        private System.Windows.Forms.GroupBox loadModelBox;
        private System.Windows.Forms.Button geoDelBtn;
        private System.Windows.Forms.Button geoLoadBtn;
        private System.Windows.Forms.GroupBox geoElBox;
        private System.Windows.Forms.TableLayoutPanel elementsLayout;
        private System.Windows.Forms.TabPage geometryPage;
        private System.Windows.Forms.TabControl gmshTab;
        private System.Windows.Forms.TabControl filterBox;
        private System.Windows.Forms.TabPage boundFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox betaBox;
        private System.Windows.Forms.TextBox beta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nbLayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox fanBox;
        private System.Windows.Forms.TextBox fanPointsSizesList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox anisoMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fanPointsList;
        private System.Windows.Forms.GroupBox layersBox;
        private System.Windows.Forms.TextBox ratio;
        private System.Windows.Forms.TextBox thickness;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox excludedSurfacesList;
        private System.Windows.Forms.TextBox curvesList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox pointsList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel flagsBetaPnl;
        private System.Windows.Forms.Button addFilter;
        private System.Windows.Forms.CheckBox quads;
        private System.Windows.Forms.CheckBox intersectMetrics;
        private System.Windows.Forms.CheckBox betaLaw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sizesList;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox sizeFar;
    }
}
