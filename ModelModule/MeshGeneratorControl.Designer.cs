using GmshApi;
using System.Windows.Forms;

namespace ModelModule
{
    partial class GmshControl : UserControl
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
            this.meshDelBtn = new System.Windows.Forms.Button();
            this.algoChoice = new System.Windows.Forms.ComboBox();
            this.algoLabel = new System.Windows.Forms.Label();
            this.meshDensityValue = new System.Windows.Forms.TextBox();
            this.mesh2DGenBtn = new System.Windows.Forms.Button();
            this.meshGenBox = new System.Windows.Forms.GroupBox();
            this.meshSaveBtn = new System.Windows.Forms.Button();
            this.meshLoadBtn = new System.Windows.Forms.Button();
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
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
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
            this.grpFieldBeta = new System.Windows.Forms.GroupBox();
            this.txtBetaCoef = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBetaLayers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpFieldFan = new System.Windows.Forms.GroupBox();
            this.txtFanListSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFanAngle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFanListPoints = new System.Windows.Forms.TextBox();
            this.grpFieldLayer = new System.Windows.Forms.GroupBox();
            this.txtLayerRatio = new System.Windows.Forms.TextBox();
            this.txtLayerThickness = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpFieldGeneral = new System.Windows.Forms.GroupBox();
            this.txtGenListSurfaces = new System.Windows.Forms.TextBox();
            this.txtGenListCurves = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGenListPoints = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlFieldInit = new System.Windows.Forms.Panel();
            this.btnFieldDelete = new System.Windows.Forms.Button();
            this.btnFieldAdd = new System.Windows.Forms.Button();
            this.chkQuad = new System.Windows.Forms.CheckBox();
            this.chkMetrics = new System.Windows.Forms.CheckBox();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            this.grpFieldSize = new System.Windows.Forms.GroupBox();
            this.txtSizeListPoints = new System.Windows.Forms.TextBox();
            this.txtSizeListNear = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSizeListFar = new System.Windows.Forms.TextBox();
            this.loadModelBox = new System.Windows.Forms.GroupBox();
            this.geoScriptBtn = new System.Windows.Forms.Button();
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
            this.grpFieldBeta.SuspendLayout();
            this.grpFieldFan.SuspendLayout();
            this.grpFieldLayer.SuspendLayout();
            this.grpFieldGeneral.SuspendLayout();
            this.pnlFieldInit.SuspendLayout();
            this.grpFieldSize.SuspendLayout();
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
            this.meshDelBtn.Location = new System.Drawing.Point(241, 58);
            this.meshDelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.meshDelBtn.Name = "meshDelBtn";
            this.meshDelBtn.Size = new System.Drawing.Size(98, 26);
            this.meshDelBtn.TabIndex = 9;
            this.meshDelBtn.Text = "Удалить";
            this.meshDelBtn.UseVisualStyleBackColor = true;
            this.meshDelBtn.Click += new System.EventHandler(this.OnDeleteMesh2D);
            // 
            // algoChoice
            // 
            this.algoChoice.Enabled = false;
            this.algoChoice.FormattingEnabled = true;
            this.algoChoice.Items.AddRange(new object[] {
            "MeshAdapt",
            "Automatic",
            "Delaunay",
            "FrontalDelaunay",
            "FrontalDelaunayQuad"});
            this.algoChoice.Location = new System.Drawing.Point(242, 20);
            this.algoChoice.Margin = new System.Windows.Forms.Padding(2);
            this.algoChoice.Name = "algoChoice";
            this.algoChoice.Size = new System.Drawing.Size(114, 21);
            this.algoChoice.TabIndex = 8;
            this.algoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // algoLabel
            // 
            this.algoLabel.AutoSize = true;
            this.algoLabel.Enabled = false;
            this.algoLabel.Location = new System.Drawing.Point(3, 23);
            this.algoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(153, 13);
            this.algoLabel.TabIndex = 7;
            this.algoLabel.Text = "Алгоритм построения сетки:";
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.meshDensityValue.Enabled = false;
            this.meshDensityValue.Location = new System.Drawing.Point(5, 60);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(2);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(91, 20);
            this.meshDensityValue.TabIndex = 6;
            this.meshDensityValue.Text = "1";
            this.meshDensityValue.TextChanged += new System.EventHandler(this.OnDencityChange);
            // 
            // mesh2DGenBtn
            // 
            this.mesh2DGenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mesh2DGenBtn.Enabled = false;
            this.mesh2DGenBtn.Location = new System.Drawing.Point(120, 58);
            this.mesh2DGenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.mesh2DGenBtn.Name = "mesh2DGenBtn";
            this.mesh2DGenBtn.Size = new System.Drawing.Size(98, 26);
            this.mesh2DGenBtn.TabIndex = 5;
            this.mesh2DGenBtn.Text = "Сгенерировать";
            this.mesh2DGenBtn.UseVisualStyleBackColor = true;
            this.mesh2DGenBtn.Click += new System.EventHandler(this.OnGenerateMesh2D);
            // 
            // meshGenBox
            // 
            this.meshGenBox.Controls.Add(this.meshSaveBtn);
            this.meshGenBox.Controls.Add(this.meshLoadBtn);
            this.meshGenBox.Controls.Add(this.meshDelBtn);
            this.meshGenBox.Controls.Add(this.algoChoice);
            this.meshGenBox.Controls.Add(this.algoLabel);
            this.meshGenBox.Controls.Add(this.meshDensityValue);
            this.meshGenBox.Controls.Add(this.densityLabel);
            this.meshGenBox.Controls.Add(this.mesh2DGenBtn);
            this.meshGenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshGenBox.Location = new System.Drawing.Point(2, 2);
            this.meshGenBox.Margin = new System.Windows.Forms.Padding(2);
            this.meshGenBox.Name = "meshGenBox";
            this.meshGenBox.Padding = new System.Windows.Forms.Padding(2);
            this.meshGenBox.Size = new System.Drawing.Size(359, 121);
            this.meshGenBox.TabIndex = 3;
            this.meshGenBox.TabStop = false;
            this.meshGenBox.Text = "Управление сеткой";
            // 
            // meshSaveBtn
            // 
            this.meshSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshSaveBtn.Enabled = false;
            this.meshSaveBtn.Location = new System.Drawing.Point(241, 93);
            this.meshSaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.meshSaveBtn.Name = "meshSaveBtn";
            this.meshSaveBtn.Size = new System.Drawing.Size(98, 26);
            this.meshSaveBtn.TabIndex = 11;
            this.meshSaveBtn.Text = "Сохранить";
            this.meshSaveBtn.UseVisualStyleBackColor = true;
            // 
            // meshLoadBtn
            // 
            this.meshLoadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshLoadBtn.Enabled = false;
            this.meshLoadBtn.Location = new System.Drawing.Point(120, 93);
            this.meshLoadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.meshLoadBtn.Name = "meshLoadBtn";
            this.meshLoadBtn.Size = new System.Drawing.Size(98, 26);
            this.meshLoadBtn.TabIndex = 10;
            this.meshLoadBtn.Text = "Загрузить";
            this.meshLoadBtn.UseVisualStyleBackColor = true;
            // 
            // densityLabel
            // 
            this.densityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.densityLabel.AutoSize = true;
            this.densityLabel.Enabled = false;
            this.densityLabel.Location = new System.Drawing.Point(3, 43);
            this.densityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(107, 13);
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
            this.meshLayout.Location = new System.Drawing.Point(2, 2);
            this.meshLayout.Margin = new System.Windows.Forms.Padding(2);
            this.meshLayout.Name = "meshLayout";
            this.meshLayout.RowCount = 3;
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.36748F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.08976F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.40376F));
            this.meshLayout.Size = new System.Drawing.Size(363, 766);
            this.meshLayout.TabIndex = 0;
            // 
            // meshElBox
            // 
            this.meshElBox.Controls.Add(this.meshOptLayout);
            this.meshElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshElBox.Enabled = false;
            this.meshElBox.Location = new System.Drawing.Point(2, 127);
            this.meshElBox.Margin = new System.Windows.Forms.Padding(2);
            this.meshElBox.Name = "meshElBox";
            this.meshElBox.Padding = new System.Windows.Forms.Padding(2);
            this.meshElBox.Size = new System.Drawing.Size(359, 341);
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
            this.meshOptLayout.Location = new System.Drawing.Point(2, 15);
            this.meshOptLayout.Margin = new System.Windows.Forms.Padding(2);
            this.meshOptLayout.Name = "meshOptLayout";
            this.meshOptLayout.RowCount = 1;
            this.meshOptLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.meshOptLayout.Size = new System.Drawing.Size(355, 324);
            this.meshOptLayout.TabIndex = 4;
            // 
            // elemsTree
            // 
            this.elemsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elemsTree.Location = new System.Drawing.Point(2, 2);
            this.elemsTree.Margin = new System.Windows.Forms.Padding(2);
            this.elemsTree.Name = "elemsTree";
            this.elemsTree.Size = new System.Drawing.Size(209, 320);
            this.elemsTree.TabIndex = 0;
            this.elemsTree.Tag = "elemsTree";
            this.elemsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // meshElPanel
            // 
            this.meshElPanel.Controls.Add(this.elemDelBtn);
            this.meshElPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshElPanel.Location = new System.Drawing.Point(215, 2);
            this.meshElPanel.Margin = new System.Windows.Forms.Padding(2);
            this.meshElPanel.Name = "meshElPanel";
            this.meshElPanel.Size = new System.Drawing.Size(138, 320);
            this.meshElPanel.TabIndex = 1;
            // 
            // elemDelBtn
            // 
            this.elemDelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elemDelBtn.Location = new System.Drawing.Point(25, 282);
            this.elemDelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.elemDelBtn.Name = "elemDelBtn";
            this.elemDelBtn.Size = new System.Drawing.Size(98, 26);
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
            this.meshOpBox.Location = new System.Drawing.Point(2, 472);
            this.meshOpBox.Margin = new System.Windows.Forms.Padding(2);
            this.meshOpBox.Name = "meshOpBox";
            this.meshOpBox.Padding = new System.Windows.Forms.Padding(2);
            this.meshOpBox.Size = new System.Drawing.Size(359, 292);
            this.meshOpBox.TabIndex = 6;
            this.meshOpBox.TabStop = false;
            this.meshOpBox.Text = "Операции с сеткой";
            // 
            // meshExit
            // 
            this.meshExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.meshExit.Location = new System.Drawing.Point(246, 17);
            this.meshExit.Margin = new System.Windows.Forms.Padding(2);
            this.meshExit.Name = "meshExit";
            this.meshExit.Size = new System.Drawing.Size(109, 26);
            this.meshExit.TabIndex = 12;
            this.meshExit.Text = "Ок";
            this.meshExit.UseVisualStyleBackColor = true;
            this.meshExit.Click += new System.EventHandler(this.OnSaveData);
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quadBtn.Location = new System.Drawing.Point(122, 17);
            this.quadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.quadBtn.Name = "quadBtn";
            this.quadBtn.Size = new System.Drawing.Size(112, 26);
            this.quadBtn.TabIndex = 11;
            this.quadBtn.Text = "Квадратизировать";
            this.quadBtn.UseVisualStyleBackColor = true;
            this.quadBtn.Click += new System.EventHandler(this.OnQuadrangulate);
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refineBtn.Location = new System.Drawing.Point(3, 17);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(109, 26);
            this.refineBtn.TabIndex = 10;
            this.refineBtn.Text = "Уплотнить";
            this.refineBtn.UseVisualStyleBackColor = true;
            this.refineBtn.Click += new System.EventHandler(this.OnRefine);
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 22);
            this.meshPage.Margin = new System.Windows.Forms.Padding(2);
            this.meshPage.Name = "meshPage";
            this.meshPage.Padding = new System.Windows.Forms.Padding(2);
            this.meshPage.Size = new System.Drawing.Size(367, 770);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(24, 10);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 26);
            this.button6.TabIndex = 9;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 181);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 53);
            this.panel3.TabIndex = 0;
            // 
            // algoCoef
            // 
            this.algoCoef.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.algoCoef.Location = new System.Drawing.Point(32, 108);
            this.algoCoef.Margin = new System.Windows.Forms.Padding(2);
            this.algoCoef.Name = "algoCoef";
            this.algoCoef.Size = new System.Drawing.Size(76, 20);
            this.algoCoef.TabIndex = 4;
            this.algoCoef.Tag = "algoCoef";
            this.algoCoef.Text = "1.0";
            this.algoCoef.Validated += new System.EventHandler(this.OnTransfiniteCurve);
            // 
            // algoNPoints
            // 
            this.algoNPoints.Location = new System.Drawing.Point(32, 154);
            this.algoNPoints.Margin = new System.Windows.Forms.Padding(2);
            this.algoNPoints.Name = "algoNPoints";
            this.algoNPoints.Size = new System.Drawing.Size(76, 20);
            this.algoNPoints.TabIndex = 5;
            this.algoNPoints.Tag = "algoNPoints";
            this.algoNPoints.Validated += new System.EventHandler(this.OnTransfiniteCurve);
            // 
            // rbtnProgressive
            // 
            this.rbtnProgressive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnProgressive.AutoSize = true;
            this.rbtnProgressive.Checked = true;
            this.rbtnProgressive.Location = new System.Drawing.Point(32, 17);
            this.rbtnProgressive.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnProgressive.Name = "rbtnProgressive";
            this.rbtnProgressive.Size = new System.Drawing.Size(80, 17);
            this.rbtnProgressive.TabIndex = 0;
            this.rbtnProgressive.TabStop = true;
            this.rbtnProgressive.Tag = "Progressive";
            this.rbtnProgressive.Text = "Progressive";
            this.rbtnProgressive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Число точек:";
            // 
            // rbtnBump
            // 
            this.rbtnBump.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBump.AutoSize = true;
            this.rbtnBump.Location = new System.Drawing.Point(32, 42);
            this.rbtnBump.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnBump.Name = "rbtnBump";
            this.rbtnBump.Size = new System.Drawing.Size(52, 17);
            this.rbtnBump.TabIndex = 1;
            this.rbtnBump.Tag = "Bump";
            this.rbtnBump.Text = "Bump";
            this.rbtnBump.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Коэффициент:";
            // 
            // rbtnBeta
            // 
            this.rbtnBeta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBeta.AutoSize = true;
            this.rbtnBeta.Location = new System.Drawing.Point(32, 68);
            this.rbtnBeta.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnBeta.Name = "rbtnBeta";
            this.rbtnBeta.Size = new System.Drawing.Size(47, 17);
            this.rbtnBeta.TabIndex = 2;
            this.rbtnBeta.Tag = "Beta";
            this.rbtnBeta.Text = "Beta";
            this.rbtnBeta.UseVisualStyleBackColor = true;
            // 
            // algoBox
            // 
            this.algoBox.Controls.Add(this.algoCoef);
            this.algoBox.Controls.Add(this.algoNPoints);
            this.algoBox.Controls.Add(this.rbtnProgressive);
            this.algoBox.Controls.Add(this.label2);
            this.algoBox.Controls.Add(this.rbtnBump);
            this.algoBox.Controls.Add(this.label3);
            this.algoBox.Controls.Add(this.rbtnBeta);
            this.algoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algoBox.Location = new System.Drawing.Point(2, 2);
            this.algoBox.Margin = new System.Windows.Forms.Padding(2);
            this.algoBox.Name = "algoBox";
            this.algoBox.Padding = new System.Windows.Forms.Padding(2);
            this.algoBox.Size = new System.Drawing.Size(148, 175);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.10921F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.89079F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(152, 236);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pointsControlBox
            // 
            this.pointsControlBox.Controls.Add(this.tableLayoutPanel4);
            this.pointsControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointsControlBox.Enabled = false;
            this.pointsControlBox.Location = new System.Drawing.Point(2, 2);
            this.pointsControlBox.Margin = new System.Windows.Forms.Padding(2);
            this.pointsControlBox.Name = "pointsControlBox";
            this.pointsControlBox.Padding = new System.Windows.Forms.Padding(2);
            this.pointsControlBox.Size = new System.Drawing.Size(156, 253);
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
            this.panel1.Location = new System.Drawing.Point(2, 428);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 340);
            this.panel1.TabIndex = 7;
            // 
            // volExit
            // 
            this.volExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volExit.Location = new System.Drawing.Point(235, 37);
            this.volExit.Margin = new System.Windows.Forms.Padding(2);
            this.volExit.Name = "volExit";
            this.volExit.Size = new System.Drawing.Size(112, 26);
            this.volExit.TabIndex = 13;
            this.volExit.Text = "Ок";
            this.volExit.UseVisualStyleBackColor = true;
            this.volExit.Click += new System.EventHandler(this.OnSaveData);
            // 
            // volDelBtn
            // 
            this.volDelBtn.Location = new System.Drawing.Point(13, 312);
            this.volDelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.volDelBtn.Name = "volDelBtn";
            this.volDelBtn.Size = new System.Drawing.Size(112, 26);
            this.volDelBtn.TabIndex = 11;
            this.volDelBtn.Text = "Удалить";
            this.volDelBtn.UseVisualStyleBackColor = true;
            this.volDelBtn.Click += new System.EventHandler(this.OnDeleteVolElement);
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(2, 2);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(2);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(211, 342);
            this.volumesTree.TabIndex = 0;
            this.volumesTree.Tag = "volElemsTree";
            this.volumesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // volElPanel
            // 
            this.volElPanel.Controls.Add(this.volDelBtn);
            this.volElPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volElPanel.Location = new System.Drawing.Point(217, 2);
            this.volElPanel.Margin = new System.Windows.Forms.Padding(2);
            this.volElPanel.Name = "volElPanel";
            this.volElPanel.Size = new System.Drawing.Size(140, 342);
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
            this.volumeOptLayout.Location = new System.Drawing.Point(2, 15);
            this.volumeOptLayout.Margin = new System.Windows.Forms.Padding(2);
            this.volumeOptLayout.Name = "volumeOptLayout";
            this.volumeOptLayout.RowCount = 1;
            this.volumeOptLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeOptLayout.Size = new System.Drawing.Size(359, 346);
            this.volumeOptLayout.TabIndex = 5;
            // 
            // volElBox
            // 
            this.volElBox.Controls.Add(this.volumeOptLayout);
            this.volElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volElBox.Enabled = false;
            this.volElBox.Location = new System.Drawing.Point(2, 61);
            this.volElBox.Margin = new System.Windows.Forms.Padding(2);
            this.volElBox.Name = "volElBox";
            this.volElBox.Padding = new System.Windows.Forms.Padding(2);
            this.volElBox.Size = new System.Drawing.Size(363, 363);
            this.volElBox.TabIndex = 6;
            this.volElBox.TabStop = false;
            this.volElBox.Text = "Элементы объемов";
            // 
            // entTree
            // 
            this.entTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entTree.HideSelection = false;
            this.entTree.Location = new System.Drawing.Point(2, 2);
            this.entTree.Margin = new System.Windows.Forms.Padding(2);
            this.entTree.Name = "entTree";
            this.entTree.Size = new System.Drawing.Size(187, 246);
            this.entTree.TabIndex = 6;
            this.entTree.Tag = "entTree";
            this.entTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.entTree_BeforeSelect);
            this.entTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // volumeBox
            // 
            this.volumeBox.Controls.Add(this.delVolBtn);
            this.volumeBox.Controls.Add(this.volGenBtn);
            this.volumeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeBox.Enabled = false;
            this.volumeBox.Location = new System.Drawing.Point(2, 2);
            this.volumeBox.Margin = new System.Windows.Forms.Padding(2);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Padding = new System.Windows.Forms.Padding(2);
            this.volumeBox.Size = new System.Drawing.Size(363, 55);
            this.volumeBox.TabIndex = 4;
            this.volumeBox.TabStop = false;
            this.volumeBox.Text = "Управление объемами";
            // 
            // delVolBtn
            // 
            this.delVolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delVolBtn.Enabled = false;
            this.delVolBtn.Location = new System.Drawing.Point(229, 23);
            this.delVolBtn.Margin = new System.Windows.Forms.Padding(2);
            this.delVolBtn.Name = "delVolBtn";
            this.delVolBtn.Size = new System.Drawing.Size(112, 26);
            this.delVolBtn.TabIndex = 6;
            this.delVolBtn.Text = "Удалить";
            this.delVolBtn.UseVisualStyleBackColor = true;
            this.delVolBtn.Click += new System.EventHandler(this.OnDeleteVolume);
            // 
            // volGenBtn
            // 
            this.volGenBtn.Location = new System.Drawing.Point(16, 23);
            this.volGenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.volGenBtn.Name = "volGenBtn";
            this.volGenBtn.Size = new System.Drawing.Size(112, 26);
            this.volGenBtn.TabIndex = 5;
            this.volGenBtn.Text = "Сгенерировать";
            this.volGenBtn.UseVisualStyleBackColor = true;
            this.volGenBtn.Click += new System.EventHandler(this.OnGenerateMesh3D);
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.tableLayoutPanel1);
            this.volumePage.Location = new System.Drawing.Point(4, 22);
            this.volumePage.Margin = new System.Windows.Forms.Padding(2);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(367, 770);
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.656396F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.63119F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 770);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pointsControlBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(193, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(160, 246);
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
            this.geometryLayout.Location = new System.Drawing.Point(2, 2);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(2);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 3;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.geometryLayout.Size = new System.Drawing.Size(363, 766);
            this.geometryLayout.TabIndex = 0;
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.boundFilter);
            this.filterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterBox.Enabled = false;
            this.filterBox.Location = new System.Drawing.Point(2, 323);
            this.filterBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterBox.Name = "filterBox";
            this.filterBox.SelectedIndex = 0;
            this.filterBox.Size = new System.Drawing.Size(359, 441);
            this.filterBox.TabIndex = 6;
            // 
            // boundFilter
            // 
            this.boundFilter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.boundFilter.Controls.Add(this.tableLayoutPanel2);
            this.boundFilter.Location = new System.Drawing.Point(4, 22);
            this.boundFilter.Margin = new System.Windows.Forms.Padding(2);
            this.boundFilter.Name = "boundFilter";
            this.boundFilter.Padding = new System.Windows.Forms.Padding(2);
            this.boundFilter.Size = new System.Drawing.Size(351, 415);
            this.boundFilter.TabIndex = 0;
            this.boundFilter.Text = "Граничный";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grpFieldBeta, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldFan, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldLayer, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldGeneral, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlFieldInit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldSize, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(347, 411);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // grpFieldBeta
            // 
            this.grpFieldBeta.Controls.Add(this.txtBetaCoef);
            this.grpFieldBeta.Controls.Add(this.label5);
            this.grpFieldBeta.Controls.Add(this.txtBetaLayers);
            this.grpFieldBeta.Controls.Add(this.label4);
            this.grpFieldBeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldBeta.Enabled = false;
            this.grpFieldBeta.Location = new System.Drawing.Point(2, 342);
            this.grpFieldBeta.Margin = new System.Windows.Forms.Padding(2);
            this.grpFieldBeta.Name = "grpFieldBeta";
            this.grpFieldBeta.Padding = new System.Windows.Forms.Padding(2);
            this.grpFieldBeta.Size = new System.Drawing.Size(343, 69);
            this.grpFieldBeta.TabIndex = 13;
            this.grpFieldBeta.TabStop = false;
            this.grpFieldBeta.Text = "Закон бета";
            // 
            // txtBetaCoef
            // 
            this.txtBetaCoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetaCoef.Location = new System.Drawing.Point(236, 34);
            this.txtBetaCoef.Margin = new System.Windows.Forms.Padding(2);
            this.txtBetaCoef.Name = "txtBetaCoef";
            this.txtBetaCoef.Size = new System.Drawing.Size(99, 20);
            this.txtBetaCoef.TabIndex = 3;
            this.txtBetaCoef.Tag = "Beta 1,01";
            this.txtBetaCoef.Text = "1.01";
            this.txtBetaCoef.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Коэффициент:";
            // 
            // txtBetaLayers
            // 
            this.txtBetaLayers.Location = new System.Drawing.Point(8, 34);
            this.txtBetaLayers.Margin = new System.Windows.Forms.Padding(2);
            this.txtBetaLayers.Name = "txtBetaLayers";
            this.txtBetaLayers.Size = new System.Drawing.Size(99, 20);
            this.txtBetaLayers.TabIndex = 1;
            this.txtBetaLayers.Tag = "NbLayers 10";
            this.txtBetaLayers.Text = "10";
            this.txtBetaLayers.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Количество слоев:";
            // 
            // grpFieldFan
            // 
            this.grpFieldFan.Controls.Add(this.txtFanListSize);
            this.grpFieldFan.Controls.Add(this.label8);
            this.grpFieldFan.Controls.Add(this.txtFanAngle);
            this.grpFieldFan.Controls.Add(this.label6);
            this.grpFieldFan.Controls.Add(this.label7);
            this.grpFieldFan.Controls.Add(this.txtFanListPoints);
            this.grpFieldFan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldFan.Enabled = false;
            this.grpFieldFan.Location = new System.Drawing.Point(2, 268);
            this.grpFieldFan.Margin = new System.Windows.Forms.Padding(2);
            this.grpFieldFan.Name = "grpFieldFan";
            this.grpFieldFan.Padding = new System.Windows.Forms.Padding(2);
            this.grpFieldFan.Size = new System.Drawing.Size(343, 70);
            this.grpFieldFan.TabIndex = 11;
            this.grpFieldFan.TabStop = false;
            this.grpFieldFan.Text = "Настройки скруглений:";
            // 
            // txtFanListSize
            // 
            this.txtFanListSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListSize.Location = new System.Drawing.Point(236, 44);
            this.txtFanListSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtFanListSize.Name = "txtFanListSize";
            this.txtFanListSize.Size = new System.Drawing.Size(99, 20);
            this.txtFanListSize.TabIndex = 8;
            this.txtFanListSize.Tag = "FanPointsSizesList";
            this.txtFanListSize.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Пороговый угол:";
            // 
            // txtFanAngle
            // 
            this.txtFanAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanAngle.Location = new System.Drawing.Point(12, 44);
            this.txtFanAngle.Margin = new System.Windows.Forms.Padding(2);
            this.txtFanAngle.Name = "txtFanAngle";
            this.txtFanAngle.Size = new System.Drawing.Size(99, 20);
            this.txtFanAngle.TabIndex = 4;
            this.txtFanAngle.Tag = "AnisoMax 10000000000";
            this.txtFanAngle.Text = "10000000000";
            this.txtFanAngle.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Элем. на точку:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Список точек:";
            // 
            // txtFanListPoints
            // 
            this.txtFanListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListPoints.Location = new System.Drawing.Point(122, 44);
            this.txtFanListPoints.Margin = new System.Windows.Forms.Padding(2);
            this.txtFanListPoints.Name = "txtFanListPoints";
            this.txtFanListPoints.Size = new System.Drawing.Size(99, 20);
            this.txtFanListPoints.TabIndex = 6;
            this.txtFanListPoints.Tag = "FanPointsList";
            this.txtFanListPoints.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // grpFieldLayer
            // 
            this.grpFieldLayer.Controls.Add(this.txtLayerRatio);
            this.grpFieldLayer.Controls.Add(this.txtLayerThickness);
            this.grpFieldLayer.Controls.Add(this.label10);
            this.grpFieldLayer.Controls.Add(this.label9);
            this.grpFieldLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldLayer.Enabled = false;
            this.grpFieldLayer.Location = new System.Drawing.Point(2, 201);
            this.grpFieldLayer.Margin = new System.Windows.Forms.Padding(2);
            this.grpFieldLayer.Name = "grpFieldLayer";
            this.grpFieldLayer.Padding = new System.Windows.Forms.Padding(2);
            this.grpFieldLayer.Size = new System.Drawing.Size(343, 63);
            this.grpFieldLayer.TabIndex = 10;
            this.grpFieldLayer.TabStop = false;
            this.grpFieldLayer.Text = "Настройки слоев:";
            // 
            // txtLayerRatio
            // 
            this.txtLayerRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerRatio.Location = new System.Drawing.Point(236, 36);
            this.txtLayerRatio.Margin = new System.Windows.Forms.Padding(2);
            this.txtLayerRatio.Name = "txtLayerRatio";
            this.txtLayerRatio.Size = new System.Drawing.Size(99, 20);
            this.txtLayerRatio.TabIndex = 10;
            this.txtLayerRatio.Tag = "Ratio 1,1";
            this.txtLayerRatio.Text = "1.1";
            this.txtLayerRatio.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // txtLayerThickness
            // 
            this.txtLayerThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerThickness.Location = new System.Drawing.Point(12, 36);
            this.txtLayerThickness.Margin = new System.Windows.Forms.Padding(2);
            this.txtLayerThickness.Name = "txtLayerThickness";
            this.txtLayerThickness.Size = new System.Drawing.Size(99, 20);
            this.txtLayerThickness.TabIndex = 9;
            this.txtLayerThickness.Tag = "Thickness 0,01";
            this.txtLayerThickness.Text = "0.01";
            this.txtLayerThickness.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Толщина слоя макс:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Соотнош. размеров:";
            // 
            // grpFieldGeneral
            // 
            this.grpFieldGeneral.Controls.Add(this.txtGenListSurfaces);
            this.grpFieldGeneral.Controls.Add(this.txtGenListCurves);
            this.grpFieldGeneral.Controls.Add(this.label12);
            this.grpFieldGeneral.Controls.Add(this.label11);
            this.grpFieldGeneral.Controls.Add(this.txtGenListPoints);
            this.grpFieldGeneral.Controls.Add(this.label13);
            this.grpFieldGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldGeneral.Enabled = false;
            this.grpFieldGeneral.Location = new System.Drawing.Point(2, 65);
            this.grpFieldGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.grpFieldGeneral.Name = "grpFieldGeneral";
            this.grpFieldGeneral.Padding = new System.Windows.Forms.Padding(2);
            this.grpFieldGeneral.Size = new System.Drawing.Size(343, 64);
            this.grpFieldGeneral.TabIndex = 9;
            this.grpFieldGeneral.TabStop = false;
            this.grpFieldGeneral.Text = "Общие настройки:";
            // 
            // txtGenListSurfaces
            // 
            this.txtGenListSurfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListSurfaces.Location = new System.Drawing.Point(236, 38);
            this.txtGenListSurfaces.Margin = new System.Windows.Forms.Padding(2);
            this.txtGenListSurfaces.Name = "txtGenListSurfaces";
            this.txtGenListSurfaces.Size = new System.Drawing.Size(99, 20);
            this.txtGenListSurfaces.TabIndex = 8;
            this.txtGenListSurfaces.Tag = "ExcludedSurfacesList";
            this.txtGenListSurfaces.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // txtGenListCurves
            // 
            this.txtGenListCurves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListCurves.Location = new System.Drawing.Point(122, 38);
            this.txtGenListCurves.Margin = new System.Windows.Forms.Padding(2);
            this.txtGenListCurves.Name = "txtGenListCurves";
            this.txtGenListCurves.Size = new System.Drawing.Size(99, 20);
            this.txtGenListCurves.TabIndex = 6;
            this.txtGenListCurves.Tag = "CurvesList";
            this.txtGenListCurves.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(130, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Список кривых:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Список искл. поверхн:";
            // 
            // txtGenListPoints
            // 
            this.txtGenListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListPoints.Location = new System.Drawing.Point(12, 38);
            this.txtGenListPoints.Margin = new System.Windows.Forms.Padding(2);
            this.txtGenListPoints.Name = "txtGenListPoints";
            this.txtGenListPoints.Size = new System.Drawing.Size(99, 20);
            this.txtGenListPoints.TabIndex = 4;
            this.txtGenListPoints.Tag = "PointsList";
            this.txtGenListPoints.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Список точек:";
            // 
            // pnlFieldInit
            // 
            this.pnlFieldInit.Controls.Add(this.btnFieldDelete);
            this.pnlFieldInit.Controls.Add(this.btnFieldAdd);
            this.pnlFieldInit.Controls.Add(this.chkQuad);
            this.pnlFieldInit.Controls.Add(this.chkMetrics);
            this.pnlFieldInit.Controls.Add(this.chkBeta);
            this.pnlFieldInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldInit.Location = new System.Drawing.Point(2, 2);
            this.pnlFieldInit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFieldInit.Name = "pnlFieldInit";
            this.pnlFieldInit.Size = new System.Drawing.Size(343, 59);
            this.pnlFieldInit.TabIndex = 3;
            // 
            // btnFieldDelete
            // 
            this.btnFieldDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldDelete.Enabled = false;
            this.btnFieldDelete.Location = new System.Drawing.Point(139, 25);
            this.btnFieldDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnFieldDelete.Name = "btnFieldDelete";
            this.btnFieldDelete.Size = new System.Drawing.Size(90, 26);
            this.btnFieldDelete.TabIndex = 4;
            this.btnFieldDelete.Text = "Удалить";
            this.btnFieldDelete.UseVisualStyleBackColor = true;
            this.btnFieldDelete.Click += new System.EventHandler(this.OnRemoveBoundFilter);
            // 
            // btnFieldAdd
            // 
            this.btnFieldAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldAdd.Location = new System.Drawing.Point(242, 25);
            this.btnFieldAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnFieldAdd.Name = "btnFieldAdd";
            this.btnFieldAdd.Size = new System.Drawing.Size(90, 26);
            this.btnFieldAdd.TabIndex = 3;
            this.btnFieldAdd.Text = "Добавить";
            this.btnFieldAdd.UseVisualStyleBackColor = true;
            this.btnFieldAdd.Click += new System.EventHandler(this.OnAddBoundFilter);
            // 
            // chkQuad
            // 
            this.chkQuad.AutoSize = true;
            this.chkQuad.Enabled = false;
            this.chkQuad.Location = new System.Drawing.Point(11, 30);
            this.chkQuad.Margin = new System.Windows.Forms.Padding(2);
            this.chkQuad.Name = "chkQuad";
            this.chkQuad.Size = new System.Drawing.Size(132, 17);
            this.chkQuad.TabIndex = 2;
            this.chkQuad.Tag = "Quads";
            this.chkQuad.Text = "Генерировать квады";
            this.chkQuad.UseVisualStyleBackColor = true;
            this.chkQuad.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // chkMetrics
            // 
            this.chkMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMetrics.AutoSize = true;
            this.chkMetrics.Enabled = false;
            this.chkMetrics.Location = new System.Drawing.Point(181, 6);
            this.chkMetrics.Margin = new System.Windows.Forms.Padding(2);
            this.chkMetrics.Name = "chkMetrics";
            this.chkMetrics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMetrics.Size = new System.Drawing.Size(153, 17);
            this.chkMetrics.TabIndex = 1;
            this.chkMetrics.Tag = "IntersectMetrics";
            this.chkMetrics.Text = "Пересеч метрик поверхн";
            this.chkMetrics.UseVisualStyleBackColor = true;
            this.chkMetrics.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Enabled = false;
            this.chkBeta.Location = new System.Drawing.Point(11, 6);
            this.chkBeta.Margin = new System.Windows.Forms.Padding(2);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(83, 17);
            this.chkBeta.TabIndex = 0;
            this.chkBeta.Tag = "BetaLaw";
            this.chkBeta.Text = "Закон бета";
            this.chkBeta.UseVisualStyleBackColor = true;
            this.chkBeta.Click += new System.EventHandler(this.OnBoundFilterCheck);
            // 
            // grpFieldSize
            // 
            this.grpFieldSize.Controls.Add(this.txtSizeListPoints);
            this.grpFieldSize.Controls.Add(this.txtSizeListNear);
            this.grpFieldSize.Controls.Add(this.label16);
            this.grpFieldSize.Controls.Add(this.label14);
            this.grpFieldSize.Controls.Add(this.label15);
            this.grpFieldSize.Controls.Add(this.txtSizeListFar);
            this.grpFieldSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldSize.Enabled = false;
            this.grpFieldSize.Location = new System.Drawing.Point(2, 133);
            this.grpFieldSize.Margin = new System.Windows.Forms.Padding(2);
            this.grpFieldSize.Name = "grpFieldSize";
            this.grpFieldSize.Padding = new System.Windows.Forms.Padding(2);
            this.grpFieldSize.Size = new System.Drawing.Size(343, 64);
            this.grpFieldSize.TabIndex = 8;
            this.grpFieldSize.TabStop = false;
            this.grpFieldSize.Text = "Настройки размеров:";
            // 
            // txtSizeListPoints
            // 
            this.txtSizeListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListPoints.Location = new System.Drawing.Point(236, 36);
            this.txtSizeListPoints.Margin = new System.Windows.Forms.Padding(2);
            this.txtSizeListPoints.Name = "txtSizeListPoints";
            this.txtSizeListPoints.Size = new System.Drawing.Size(99, 20);
            this.txtSizeListPoints.TabIndex = 13;
            this.txtSizeListPoints.Tag = "SizesList";
            this.txtSizeListPoints.TextChanged += new System.EventHandler(this.OnFilterListEnter);
            // 
            // txtSizeListNear
            // 
            this.txtSizeListNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListNear.Location = new System.Drawing.Point(12, 36);
            this.txtSizeListNear.Margin = new System.Windows.Forms.Padding(2);
            this.txtSizeListNear.Name = "txtSizeListNear";
            this.txtSizeListNear.Size = new System.Drawing.Size(99, 20);
            this.txtSizeListNear.TabIndex = 9;
            this.txtSizeListNear.Tag = "Size 0,1";
            this.txtSizeListNear.Text = "0.1";
            this.txtSizeListNear.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 18);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Возле кривых:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(239, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Список по точкам:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(122, 18);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Вдали от кривых:";
            // 
            // txtSizeListFar
            // 
            this.txtSizeListFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListFar.Location = new System.Drawing.Point(122, 36);
            this.txtSizeListFar.Margin = new System.Windows.Forms.Padding(2);
            this.txtSizeListFar.Name = "txtSizeListFar";
            this.txtSizeListFar.Size = new System.Drawing.Size(99, 20);
            this.txtSizeListFar.TabIndex = 10;
            this.txtSizeListFar.Tag = "SizeFar 1,0";
            this.txtSizeListFar.Text = "1.0";
            this.txtSizeListFar.TextChanged += new System.EventHandler(this.OnFilterValueEnter);
            // 
            // loadModelBox
            // 
            this.loadModelBox.Controls.Add(this.geoScriptBtn);
            this.loadModelBox.Controls.Add(this.geoDelBtn);
            this.loadModelBox.Controls.Add(this.geoLoadBtn);
            this.loadModelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadModelBox.Location = new System.Drawing.Point(2, 2);
            this.loadModelBox.Margin = new System.Windows.Forms.Padding(2);
            this.loadModelBox.Name = "loadModelBox";
            this.loadModelBox.Padding = new System.Windows.Forms.Padding(2);
            this.loadModelBox.Size = new System.Drawing.Size(359, 46);
            this.loadModelBox.TabIndex = 1;
            this.loadModelBox.TabStop = false;
            this.loadModelBox.Text = "Загрузка";
            // 
            // geoScriptBtn
            // 
            this.geoScriptBtn.Location = new System.Drawing.Point(124, 18);
            this.geoScriptBtn.Margin = new System.Windows.Forms.Padding(2);
            this.geoScriptBtn.Name = "geoScriptBtn";
            this.geoScriptBtn.Size = new System.Drawing.Size(105, 26);
            this.geoScriptBtn.TabIndex = 2;
            this.geoScriptBtn.Text = "Загрузить скрипт";
            this.geoScriptBtn.UseVisualStyleBackColor = true;
            this.geoScriptBtn.Click += new System.EventHandler(this.OnLoadFile);
            // 
            // geoDelBtn
            // 
            this.geoDelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.geoDelBtn.Enabled = false;
            this.geoDelBtn.Location = new System.Drawing.Point(245, 18);
            this.geoDelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.geoDelBtn.Name = "geoDelBtn";
            this.geoDelBtn.Size = new System.Drawing.Size(105, 26);
            this.geoDelBtn.TabIndex = 1;
            this.geoDelBtn.Text = "Удалить";
            this.geoDelBtn.UseVisualStyleBackColor = true;
            this.geoDelBtn.Click += new System.EventHandler(this.OnDeleteGeometry);
            // 
            // geoLoadBtn
            // 
            this.geoLoadBtn.Location = new System.Drawing.Point(8, 18);
            this.geoLoadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.geoLoadBtn.Name = "geoLoadBtn";
            this.geoLoadBtn.Size = new System.Drawing.Size(105, 26);
            this.geoLoadBtn.TabIndex = 0;
            this.geoLoadBtn.Text = "Загрузить CAD";
            this.geoLoadBtn.UseVisualStyleBackColor = true;
            this.geoLoadBtn.Click += new System.EventHandler(this.OnLoadFile);
            // 
            // geoElBox
            // 
            this.geoElBox.Controls.Add(this.elementsLayout);
            this.geoElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoElBox.Enabled = false;
            this.geoElBox.Location = new System.Drawing.Point(2, 52);
            this.geoElBox.Margin = new System.Windows.Forms.Padding(2);
            this.geoElBox.Name = "geoElBox";
            this.geoElBox.Padding = new System.Windows.Forms.Padding(2);
            this.geoElBox.Size = new System.Drawing.Size(359, 267);
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
            this.elementsLayout.Location = new System.Drawing.Point(2, 15);
            this.elementsLayout.Margin = new System.Windows.Forms.Padding(2);
            this.elementsLayout.Name = "elementsLayout";
            this.elementsLayout.RowCount = 1;
            this.elementsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementsLayout.Size = new System.Drawing.Size(355, 250);
            this.elementsLayout.TabIndex = 0;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 22);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(2);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Padding = new System.Windows.Forms.Padding(2);
            this.geometryPage.Size = new System.Drawing.Size(367, 770);
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
            this.gmshTab.Margin = new System.Windows.Forms.Padding(2);
            this.gmshTab.Name = "gmshTab";
            this.gmshTab.SelectedIndex = 0;
            this.gmshTab.Size = new System.Drawing.Size(375, 796);
            this.gmshTab.TabIndex = 1;
            // 
            // GmshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(375, 796);
            this.Name = "GmshControl";
            this.Size = new System.Drawing.Size(375, 796);
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
            this.grpFieldBeta.ResumeLayout(false);
            this.grpFieldBeta.PerformLayout();
            this.grpFieldFan.ResumeLayout(false);
            this.grpFieldFan.PerformLayout();
            this.grpFieldLayer.ResumeLayout(false);
            this.grpFieldLayer.PerformLayout();
            this.grpFieldGeneral.ResumeLayout(false);
            this.grpFieldGeneral.PerformLayout();
            this.pnlFieldInit.ResumeLayout(false);
            this.pnlFieldInit.PerformLayout();
            this.grpFieldSize.ResumeLayout(false);
            this.grpFieldSize.PerformLayout();
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
        private System.Windows.Forms.Label algoLabel;
        private System.Windows.Forms.TextBox meshDensityValue;
        private System.Windows.Forms.Button mesh2DGenBtn;
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
        private System.Windows.Forms.RadioButton rbtnProgressive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnBump;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnBeta;
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
        private System.Windows.Forms.GroupBox grpFieldBeta;
        private System.Windows.Forms.TextBox txtBetaCoef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBetaLayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpFieldFan;
        private System.Windows.Forms.TextBox txtFanListSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFanAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFanListPoints;
        private System.Windows.Forms.GroupBox grpFieldLayer;
        private System.Windows.Forms.TextBox txtLayerRatio;
        private System.Windows.Forms.TextBox txtLayerThickness;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpFieldGeneral;
        private System.Windows.Forms.TextBox txtGenListSurfaces;
        private System.Windows.Forms.TextBox txtGenListCurves;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGenListPoints;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlFieldInit;
        private System.Windows.Forms.Button btnFieldAdd;
        private System.Windows.Forms.CheckBox chkQuad;
        private System.Windows.Forms.CheckBox chkMetrics;
        private System.Windows.Forms.CheckBox chkBeta;
        private System.Windows.Forms.GroupBox grpFieldSize;
        private System.Windows.Forms.TextBox txtSizeListPoints;
        private System.Windows.Forms.TextBox txtSizeListNear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSizeListFar;
        private System.Windows.Forms.Button btnFieldDelete;
        private Button geoScriptBtn;
        private Button meshSaveBtn;
        private Button meshLoadBtn;
    }
}