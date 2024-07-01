
using BaseModule.ControlsLib;
using System.Windows.Forms;

namespace ModelModule
{
    partial class GMSHGeneralMeshControl : UserControl
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
            this.btnMesh2DDel = new System.Windows.Forms.Button();
            this.meshDensityValue = new System.Windows.Forms.TextBox();
            this.mesh2DGenBtn = new System.Windows.Forms.Button();
            this.meshGenBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.refineBtn = new System.Windows.Forms.Button();
            this.algoLabel = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            this.algoChoice = new System.Windows.Forms.ComboBox();
            this.quadBtn = new System.Windows.Forms.Button();
            this.meshLayout = new System.Windows.Forms.TableLayoutPanel();
            this.surfsTree = new System.Windows.Forms.TreeView();
            this.meshPage = new System.Windows.Forms.TabPage();
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grbVolControlBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenVolMesh = new System.Windows.Forms.Button();
            this.btnDelVolMesh = new System.Windows.Forms.Button();
            this.volumePage = new System.Windows.Forms.TabPage();
            this.volumeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.volumesTree = new System.Windows.Forms.TreeView();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.geometryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pointsControlBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.algoCoef = new System.Windows.Forms.TextBox();
            this.txbAlgoNPoints = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbShowTranfPoints = new System.Windows.Forms.CheckBox();
            this.chbShowCurvesInfo = new System.Windows.Forms.CheckBox();
            this.chbShowSurfacesInfo = new System.Windows.Forms.CheckBox();
            this.chbShowHeatMap = new System.Windows.Forms.CheckBox();
            this.geomTree = new System.Windows.Forms.TreeView();
            this.grbGradientMeshSettings = new BaseModule.ControlsLib.GroupBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSecondLayerMeshSize = new System.Windows.Forms.TextBox();
            this.txbFirstLayerMeshSize = new System.Windows.Forms.TextBox();
            this.txbThickness = new System.Windows.Forms.TextBox();
            this.gmshTab = new BaseModule.ControlsLib.TabControlEx();
            this.cmsRemoveMesh2D = new System.Windows.Forms.ContextMenuStrip();
            this.rem3DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveMesh3D = new System.Windows.Forms.ContextMenuStrip();
            this.rem2DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshGenBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.meshLayout.SuspendLayout();
            this.meshPage.SuspendLayout();
            this.grbVolControlBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.volumePage.SuspendLayout();
            this.volumeLayout.SuspendLayout();
            this.geometryPage.SuspendLayout();
            this.geometryLayout.SuspendLayout();
            this.pointsControlBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbGradientMeshSettings.SuspendLayout();
            this.gmshTab.SuspendLayout();
            this.cmsRemoveMesh2D.SuspendLayout();
            this.cmsRemoveMesh3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMesh2DDel
            // 
            this.btnMesh2DDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMesh2DDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesh2DDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMesh2DDel.Location = new System.Drawing.Point(294, 63);
            this.btnMesh2DDel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnMesh2DDel.Name = "btnMesh2DDel";
            this.btnMesh2DDel.Size = new System.Drawing.Size(154, 32);
            this.btnMesh2DDel.TabIndex = 9;
            this.btnMesh2DDel.Text = "Удалить";
            this.btnMesh2DDel.UseVisualStyleBackColor = true;
            this.btnMesh2DDel.Click += new System.EventHandler(this.OnDeleteMesh2D);
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.meshDensityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.meshDensityValue.Enabled = false;
            this.meshDensityValue.Location = new System.Drawing.Point(7, 118);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(119, 20);
            this.meshDensityValue.TabIndex = 6;
            this.meshDensityValue.Text = "1";
            // 
            // mesh2DGenBtn
            // 
            this.mesh2DGenBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mesh2DGenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mesh2DGenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mesh2DGenBtn.Location = new System.Drawing.Point(140, 63);
            this.mesh2DGenBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.mesh2DGenBtn.Name = "mesh2DGenBtn";
            this.mesh2DGenBtn.Size = new System.Drawing.Size(131, 32);
            this.mesh2DGenBtn.TabIndex = 5;
            this.mesh2DGenBtn.Text = "Сгенерировать";
            this.mesh2DGenBtn.UseVisualStyleBackColor = true;
            this.mesh2DGenBtn.Click += new System.EventHandler(this.OnGenerateMesh2D);
            // 
            // meshGenBox
            // 
            this.meshGenBox.AutoSize = true;
            this.meshGenBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.meshGenBox.BackColor = System.Drawing.SystemColors.Control;
            this.meshGenBox.Controls.Add(this.tableLayoutPanel1);
            this.meshGenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshGenBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meshGenBox.Location = new System.Drawing.Point(7, 7);
            this.meshGenBox.Margin = new System.Windows.Forms.Padding(7);
            this.meshGenBox.Name = "meshGenBox";
            this.meshGenBox.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.meshGenBox.Size = new System.Drawing.Size(478, 174);
            this.meshGenBox.TabIndex = 3;
            this.meshGenBox.TabStop = false;
            this.meshGenBox.Text = "Управление сеткой";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.97297F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.02703F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.Controls.Add(this.refineBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.meshDensityValue, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.algoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.densityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.algoChoice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMesh2DDel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.mesh2DGenBtn, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 13);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 154);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refineBtn.Location = new System.Drawing.Point(140, 112);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(131, 32);
            this.refineBtn.TabIndex = 10;
            this.refineBtn.Text = "Уплотнить";
            this.refineBtn.UseVisualStyleBackColor = true;
            this.refineBtn.Click += new System.EventHandler(this.OnRefine);
            // 
            // algoLabel
            // 
            this.algoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.algoLabel.AutoSize = true;
            this.algoLabel.Enabled = false;
            this.algoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.algoLabel.Location = new System.Drawing.Point(7, 14);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(118, 26);
            this.algoLabel.TabIndex = 7;
            this.algoLabel.Text = "Алгоритм построения сетки:";
            this.algoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // densityLabel
            // 
            this.densityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.densityLabel.AutoSize = true;
            this.densityLabel.Enabled = false;
            this.densityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.densityLabel.Location = new System.Drawing.Point(13, 72);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(107, 13);
            this.densityLabel.TabIndex = 0;
            this.densityLabel.Text = "Размер элементов:";
            this.densityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algoChoice
            // 
            this.algoChoice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.algoChoice, 2);
            this.algoChoice.Enabled = false;
            this.algoChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.algoChoice.FormattingEnabled = true;
            this.algoChoice.Items.AddRange(new object[] {
            "MeshAdapt",
            "Automatic",
            "Delaunay",
            "FrontalDelaunay",
            "FrontalDelaunayQuad"});
            this.algoChoice.Location = new System.Drawing.Point(147, 17);
            this.algoChoice.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.algoChoice.Name = "algoChoice";
            this.algoChoice.Size = new System.Drawing.Size(310, 21);
            this.algoChoice.TabIndex = 8;
            this.algoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quadBtn.Location = new System.Drawing.Point(295, 112);
            this.quadBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.quadBtn.Name = "quadBtn";
            this.quadBtn.Size = new System.Drawing.Size(152, 32);
            this.quadBtn.TabIndex = 11;
            this.quadBtn.Text = "Удвоить";
            this.quadBtn.UseVisualStyleBackColor = true;
            this.quadBtn.Click += new System.EventHandler(this.OnQuadrangulate);
            // 
            // meshLayout
            // 
            this.meshLayout.BackColor = System.Drawing.SystemColors.Control;
            this.meshLayout.ColumnCount = 1;
            this.meshLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.meshLayout.Controls.Add(this.surfsTree, 0, 1);
            this.meshLayout.Controls.Add(this.meshGenBox, 0, 0);
            this.meshLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshLayout.Location = new System.Drawing.Point(0, 0);
            this.meshLayout.Margin = new System.Windows.Forms.Padding(0);
            this.meshLayout.Name = "meshLayout";
            this.meshLayout.RowCount = 2;
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28846F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.71154F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.meshLayout.Size = new System.Drawing.Size(492, 624);
            this.meshLayout.TabIndex = 0;
            // 
            // surfsTree
            // 
            this.surfsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfsTree.FullRowSelect = true;
            this.surfsTree.Location = new System.Drawing.Point(7, 195);
            this.surfsTree.Margin = new System.Windows.Forms.Padding(7);
            this.surfsTree.Name = "surfsTree";
            this.surfsTree.Size = new System.Drawing.Size(478, 422);
            this.surfsTree.TabIndex = 4;
            this.surfsTree.Tag = "elemsTree";
            this.surfsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 34);
            this.meshPage.Margin = new System.Windows.Forms.Padding(0);
            this.meshPage.Name = "meshPage";
            this.meshPage.Size = new System.Drawing.Size(492, 624);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
            // 
            // loadFileDialog
            // 
            this.loadFileDialog.FileName = "untitled.geo";
            // 
            // grbVolControlBox
            // 
            this.grbVolControlBox.AutoSize = true;
            this.grbVolControlBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbVolControlBox.BackColor = System.Drawing.SystemColors.Control;
            this.grbVolControlBox.Controls.Add(this.tableLayoutPanel3);
            this.grbVolControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbVolControlBox.Location = new System.Drawing.Point(7, 7);
            this.grbVolControlBox.Margin = new System.Windows.Forms.Padding(7);
            this.grbVolControlBox.Name = "grbVolControlBox";
            this.grbVolControlBox.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.grbVolControlBox.Size = new System.Drawing.Size(478, 71);
            this.grbVolControlBox.TabIndex = 4;
            this.grbVolControlBox.TabStop = false;
            this.grbVolControlBox.Text = "Управление сеткой";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnGenVolMesh, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDelVolMesh, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 13);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(464, 51);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnGenVolMesh
            // 
            this.btnGenVolMesh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGenVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenVolMesh.Location = new System.Drawing.Point(7, 9);
            this.btnGenVolMesh.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnGenVolMesh.Name = "btnGenVolMesh";
            this.btnGenVolMesh.Size = new System.Drawing.Size(218, 32);
            this.btnGenVolMesh.TabIndex = 5;
            this.btnGenVolMesh.Text = "Сгенерировать";
            this.btnGenVolMesh.UseVisualStyleBackColor = true;
            this.btnGenVolMesh.Click += new System.EventHandler(this.OnGenerateMesh3D);
            // 
            // btnDelVolMesh
            // 
            this.btnDelVolMesh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelVolMesh.Location = new System.Drawing.Point(239, 9);
            this.btnDelVolMesh.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDelVolMesh.Name = "btnDelVolMesh";
            this.btnDelVolMesh.Size = new System.Drawing.Size(218, 32);
            this.btnDelVolMesh.TabIndex = 6;
            this.btnDelVolMesh.Text = "Удалить";
            this.btnDelVolMesh.UseVisualStyleBackColor = true;
            this.btnDelVolMesh.Click += new System.EventHandler(this.OnDeleteMesh3D);
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.volumeLayout);
            this.volumePage.Location = new System.Drawing.Point(4, 34);
            this.volumePage.Margin = new System.Windows.Forms.Padding(0);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(492, 624);
            this.volumePage.TabIndex = 2;
            this.volumePage.Text = "3D";
            // 
            // volumeLayout
            // 
            this.volumeLayout.BackColor = System.Drawing.SystemColors.Control;
            this.volumeLayout.ColumnCount = 1;
            this.volumeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeLayout.Controls.Add(this.volumesTree, 0, 1);
            this.volumeLayout.Controls.Add(this.grbVolControlBox, 0, 0);
            this.volumeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeLayout.Location = new System.Drawing.Point(0, 0);
            this.volumeLayout.Margin = new System.Windows.Forms.Padding(0);
            this.volumeLayout.Name = "volumeLayout";
            this.volumeLayout.RowCount = 2;
            this.volumeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.volumeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeLayout.Size = new System.Drawing.Size(492, 624);
            this.volumeLayout.TabIndex = 0;
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(7, 92);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(7);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(478, 525);
            this.volumesTree.TabIndex = 5;
            this.volumesTree.Tag = "volElemsTree";
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 34);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(0);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Size = new System.Drawing.Size(492, 624);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // geometryLayout
            // 
            this.geometryLayout.BackColor = System.Drawing.SystemColors.Control;
            this.geometryLayout.ColumnCount = 1;
            this.geometryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.Controls.Add(this.pointsControlBox, 0, 0);
            this.geometryLayout.Controls.Add(this.panel2, 0, 3);
            this.geometryLayout.Controls.Add(this.geomTree, 0, 2);
            this.geometryLayout.Controls.Add(this.grbGradientMeshSettings, 0, 1);
            this.geometryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryLayout.Location = new System.Drawing.Point(0, 0);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 4;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.Size = new System.Drawing.Size(492, 624);
            this.geometryLayout.TabIndex = 0;
            // 
            // pointsControlBox
            // 
            this.pointsControlBox.AutoSize = true;
            this.pointsControlBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pointsControlBox.BackColor = System.Drawing.SystemColors.Control;
            this.pointsControlBox.Controls.Add(this.tableLayoutPanel2);
            this.pointsControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointsControlBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsControlBox.Location = new System.Drawing.Point(7, 7);
            this.pointsControlBox.Margin = new System.Windows.Forms.Padding(7);
            this.pointsControlBox.Name = "pointsControlBox";
            this.pointsControlBox.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.pointsControlBox.Size = new System.Drawing.Size(478, 161);
            this.pointsControlBox.TabIndex = 2;
            this.pointsControlBox.TabStop = false;
            this.pointsControlBox.Text = "Настройки разметки кривых";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rbtnProgressive, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.algoCoef, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbAlgoNPoints, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDel, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBeta, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBump, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 141);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // rbtnProgressive
            // 
            this.rbtnProgressive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnProgressive.AutoSize = true;
            this.rbtnProgressive.Checked = true;
            this.rbtnProgressive.Location = new System.Drawing.Point(5, 15);
            this.rbtnProgressive.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.rbtnProgressive.Name = "rbtnProgressive";
            this.rbtnProgressive.Size = new System.Drawing.Size(80, 17);
            this.rbtnProgressive.TabIndex = 0;
            this.rbtnProgressive.TabStop = true;
            this.rbtnProgressive.Tag = "Прогрессия";
            this.rbtnProgressive.Text = "Progressive";
            this.rbtnProgressive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(110, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Коэффициент:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(114, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Число точек:";
            // 
            // algoCoef
            // 
            this.algoCoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.algoCoef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.algoCoef, 2);
            this.algoCoef.Location = new System.Drawing.Point(216, 14);
            this.algoCoef.Margin = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.algoCoef.Name = "algoCoef";
            this.algoCoef.Size = new System.Drawing.Size(241, 20);
            this.algoCoef.TabIndex = 4;
            this.algoCoef.Tag = "algoCoef";
            this.algoCoef.Text = "1.0";
            // 
            // txbAlgoNPoints
            // 
            this.txbAlgoNPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAlgoNPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.txbAlgoNPoints, 2);
            this.txbAlgoNPoints.Location = new System.Drawing.Point(216, 62);
            this.txbAlgoNPoints.Margin = new System.Windows.Forms.Padding(7, 14, 7, 14);
            this.txbAlgoNPoints.Name = "txbAlgoNPoints";
            this.txbAlgoNPoints.Size = new System.Drawing.Size(241, 20);
            this.txbAlgoNPoints.TabIndex = 5;
            this.txbAlgoNPoints.Tag = "algoNPoints";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.Location = new System.Drawing.Point(345, 102);
            this.btnDel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(110, 32);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // rbtnBeta
            // 
            this.rbtnBeta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBeta.AutoSize = true;
            this.rbtnBeta.Location = new System.Drawing.Point(5, 110);
            this.rbtnBeta.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.rbtnBeta.Name = "rbtnBeta";
            this.rbtnBeta.Size = new System.Drawing.Size(47, 17);
            this.rbtnBeta.TabIndex = 2;
            this.rbtnBeta.Tag = "Бета";
            this.rbtnBeta.Text = "Beta";
            this.rbtnBeta.UseVisualStyleBackColor = true;
            // 
            // rbtnBump
            // 
            this.rbtnBump.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBump.AutoSize = true;
            this.rbtnBump.Location = new System.Drawing.Point(5, 63);
            this.rbtnBump.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.rbtnBump.Name = "rbtnBump";
            this.rbtnBump.Size = new System.Drawing.Size(52, 17);
            this.rbtnBump.TabIndex = 1;
            this.rbtnBump.Tag = "Колокол";
            this.rbtnBump.Text = "Bump";
            this.rbtnBump.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(216, 102);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.chbShowTranfPoints);
            this.panel2.Controls.Add(this.chbShowCurvesInfo);
            this.panel2.Controls.Add(this.chbShowSurfacesInfo);
            this.panel2.Controls.Add(this.chbShowHeatMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 568);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 49);
            this.panel2.TabIndex = 16;
            // 
            // chbShowTranfPoints
            // 
            this.chbShowTranfPoints.AutoSize = true;
            this.chbShowTranfPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowTranfPoints.Location = new System.Drawing.Point(224, 5);
            this.chbShowTranfPoints.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.chbShowTranfPoints.Name = "chbShowTranfPoints";
            this.chbShowTranfPoints.Size = new System.Drawing.Size(187, 17);
            this.chbShowTranfPoints.TabIndex = 3;
            this.chbShowTranfPoints.Text = "Показать разбиение на кривых";
            this.chbShowTranfPoints.UseVisualStyleBackColor = true;
            this.chbShowTranfPoints.Click += new System.EventHandler(this.chbShowTranfPoints_Click);
            // 
            // chbShowCurvesInfo
            // 
            this.chbShowCurvesInfo.AutoSize = true;
            this.chbShowCurvesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowCurvesInfo.Location = new System.Drawing.Point(12, 5);
            this.chbShowCurvesInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.chbShowCurvesInfo.Name = "chbShowCurvesInfo";
            this.chbShowCurvesInfo.Size = new System.Drawing.Size(156, 17);
            this.chbShowCurvesInfo.TabIndex = 3;
            this.chbShowCurvesInfo.Text = "Показать номера кривых";
            this.chbShowCurvesInfo.UseVisualStyleBackColor = true;
            this.chbShowCurvesInfo.Click += new System.EventHandler(this.chbShowCurvesInfo_Click);
            // 
            // chbShowSurfacesInfo
            // 
            this.chbShowSurfacesInfo.AutoSize = true;
            this.chbShowSurfacesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowSurfacesInfo.Location = new System.Drawing.Point(12, 30);
            this.chbShowSurfacesInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbShowSurfacesInfo.Name = "chbShowSurfacesInfo";
            this.chbShowSurfacesInfo.Size = new System.Drawing.Size(189, 17);
            this.chbShowSurfacesInfo.TabIndex = 5;
            this.chbShowSurfacesInfo.Text = "Показать номера поверхностей";
            this.chbShowSurfacesInfo.UseVisualStyleBackColor = true;
            this.chbShowSurfacesInfo.Click += new System.EventHandler(this.chbShowSurfacesInfo_Click);
            // 
            // chbShowHeatMap
            // 
            this.chbShowHeatMap.AutoSize = true;
            this.chbShowHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowHeatMap.Location = new System.Drawing.Point(224, 30);
            this.chbShowHeatMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbShowHeatMap.Name = "chbShowHeatMap";
            this.chbShowHeatMap.Size = new System.Drawing.Size(166, 17);
            this.chbShowHeatMap.TabIndex = 4;
            this.chbShowHeatMap.Text = "Построить карту плотности";
            this.chbShowHeatMap.UseVisualStyleBackColor = true;
            this.chbShowHeatMap.Click += new System.EventHandler(this.chbShowHeatMap_Click);
            // 
            // geomTree
            // 
            this.geomTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geomTree.HideSelection = false;
            this.geomTree.Location = new System.Drawing.Point(7, 323);
            this.geomTree.Margin = new System.Windows.Forms.Padding(7);
            this.geomTree.Name = "geomTree";
            this.geomTree.Size = new System.Drawing.Size(478, 231);
            this.geomTree.TabIndex = 14;
            this.geomTree.Tag = "entTree";
            this.geomTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.entTree_BeforeSelect);
            this.geomTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // grbGradientMeshSettings
            // 
            this.grbGradientMeshSettings.AutoSize = true;
            this.grbGradientMeshSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbGradientMeshSettings.CheckState = true;
            this.grbGradientMeshSettings.Controls.Add(this.label5);
            this.grbGradientMeshSettings.Controls.Add(this.label4);
            this.grbGradientMeshSettings.Controls.Add(this.label1);
            this.grbGradientMeshSettings.Controls.Add(this.txbSecondLayerMeshSize);
            this.grbGradientMeshSettings.Controls.Add(this.txbFirstLayerMeshSize);
            this.grbGradientMeshSettings.Controls.Add(this.txbThickness);
            this.grbGradientMeshSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGradientMeshSettings.IsCheckable = true;
            this.grbGradientMeshSettings.IsRollable = false;
            this.grbGradientMeshSettings.Location = new System.Drawing.Point(7, 182);
            this.grbGradientMeshSettings.Margin = new System.Windows.Forms.Padding(7);
            this.grbGradientMeshSettings.MinimumSize = new System.Drawing.Size(0, 10);
            this.grbGradientMeshSettings.Name = "grbGradientMeshSettings";
            this.grbGradientMeshSettings.Size = new System.Drawing.Size(478, 127);
            this.grbGradientMeshSettings.TabIndex = 17;
            this.grbGradientMeshSettings.TabStop = false;
            this.grbGradientMeshSettings.Text = "Настройки градиента сетки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер элементов в 2-м слое";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Размер элементов в 1-м слое";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Толщина слоя";
            // 
            // txbSecondLayerMeshSize
            // 
            this.txbSecondLayerMeshSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSecondLayerMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSecondLayerMeshSize.Location = new System.Drawing.Point(224, 91);
            this.txbSecondLayerMeshSize.Margin = new System.Windows.Forms.Padding(7, 7, 7, 0);
            this.txbSecondLayerMeshSize.Name = "txbSecondLayerMeshSize";
            this.txbSecondLayerMeshSize.Size = new System.Drawing.Size(240, 20);
            this.txbSecondLayerMeshSize.TabIndex = 2;
            // 
            // txbFirstLayerMeshSize
            // 
            this.txbFirstLayerMeshSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFirstLayerMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbFirstLayerMeshSize.Location = new System.Drawing.Point(224, 57);
            this.txbFirstLayerMeshSize.Margin = new System.Windows.Forms.Padding(7);
            this.txbFirstLayerMeshSize.Name = "txbFirstLayerMeshSize";
            this.txbFirstLayerMeshSize.Size = new System.Drawing.Size(240, 20);
            this.txbFirstLayerMeshSize.TabIndex = 2;
            // 
            // txbThickness
            // 
            this.txbThickness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbThickness.Location = new System.Drawing.Point(224, 23);
            this.txbThickness.Margin = new System.Windows.Forms.Padding(7);
            this.txbThickness.Name = "txbThickness";
            this.txbThickness.Size = new System.Drawing.Size(240, 20);
            this.txbThickness.TabIndex = 1;
            // 
            // gmshTab
            // 
            this.gmshTab.Controls.Add(this.geometryPage);
            this.gmshTab.Controls.Add(this.meshPage);
            this.gmshTab.Controls.Add(this.volumePage);
            this.gmshTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.gmshTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gmshTab.FontColor = System.Drawing.Color.Black;
            this.gmshTab.ItemSize = new System.Drawing.Size(50, 30);
            this.gmshTab.Location = new System.Drawing.Point(0, 0);
            this.gmshTab.Margin = new System.Windows.Forms.Padding(0);
            this.gmshTab.Name = "gmshTab";
            this.gmshTab.SelectColor = System.Drawing.SystemColors.Control;
            this.gmshTab.SelectedIndex = 0;
            this.gmshTab.Size = new System.Drawing.Size(500, 662);
            this.gmshTab.TabIndex = 1;
            this.gmshTab.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // cmsRemoveMesh2D
            // 
            this.cmsRemoveMesh2D.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRemoveMesh2D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rem3DItem});
            this.cmsRemoveMesh2D.Name = "cmsRemoveMesh2D";
            this.cmsRemoveMesh2D.Size = new System.Drawing.Size(119, 26);
            // 
            // rem3DItem
            // 
            this.rem3DItem.Name = "rem3DItem";
            this.rem3DItem.Size = new System.Drawing.Size(118, 22);
            this.rem3DItem.Text = "Удалить";
            this.rem3DItem.Click += new System.EventHandler(this.OnDeleteElement2D);
            // 
            // cmsRemoveMesh3D
            // 
            this.cmsRemoveMesh3D.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRemoveMesh3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rem2DItem});
            this.cmsRemoveMesh3D.Name = "cmsRemoveMesh3D";
            this.cmsRemoveMesh3D.Size = new System.Drawing.Size(119, 26);
            // 
            // rem2DItem
            // 
            this.rem2DItem.Name = "rem2DItem";
            this.rem2DItem.Size = new System.Drawing.Size(118, 22);
            this.rem2DItem.Text = "Удалить";
            this.rem2DItem.Click += new System.EventHandler(this.OnDeleteElement3D);
            // 
            // GMSHGeneralMeshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GMSHGeneralMeshControl";
            this.Size = new System.Drawing.Size(500, 662);
            this.meshGenBox.ResumeLayout(false);
            this.meshGenBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.meshLayout.ResumeLayout(false);
            this.meshLayout.PerformLayout();
            this.meshPage.ResumeLayout(false);
            this.grbVolControlBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.volumePage.ResumeLayout(false);
            this.volumeLayout.ResumeLayout(false);
            this.volumeLayout.PerformLayout();
            this.geometryPage.ResumeLayout(false);
            this.geometryLayout.ResumeLayout(false);
            this.geometryLayout.PerformLayout();
            this.pointsControlBox.ResumeLayout(false);
            this.pointsControlBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbGradientMeshSettings.ResumeLayout(false);
            this.grbGradientMeshSettings.PerformLayout();
            this.gmshTab.ResumeLayout(false);
            this.cmsRemoveMesh2D.ResumeLayout(false);
            this.cmsRemoveMesh3D.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMesh2DDel;
        private System.Windows.Forms.TextBox meshDensityValue;
        private System.Windows.Forms.Button mesh2DGenBtn;
        private System.Windows.Forms.GroupBox meshGenBox;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TableLayoutPanel meshLayout;
        private System.Windows.Forms.Button quadBtn;
        private System.Windows.Forms.Button refineBtn;
        private System.Windows.Forms.TabPage meshPage;
        private System.Windows.Forms.OpenFileDialog loadFileDialog;
        private System.Windows.Forms.GroupBox grbVolControlBox;
        private System.Windows.Forms.Button btnDelVolMesh;
        private System.Windows.Forms.Button btnGenVolMesh;
        private System.Windows.Forms.TabPage volumePage;
        private System.Windows.Forms.TableLayoutPanel volumeLayout;
        private System.Windows.Forms.TabPage geometryPage;
        private ContextMenuStrip cmsRemoveMesh2D;
        private ToolStripMenuItem rem3DItem;
        private ContextMenuStrip cmsRemoveMesh3D;
        private ToolStripMenuItem rem2DItem;
        private TableLayoutPanel geometryLayout;
        private GroupBox pointsControlBox;
        private Button btnDel;
        private TextBox algoCoef;
        private Button btnOK;
        private TextBox txbAlgoNPoints;
        private RadioButton rbtnProgressive;
        private Label label2;
        private RadioButton rbtnBump;
        private Label label3;
        private RadioButton rbtnBeta;
        private TreeView geomTree;
        private Panel panel2;
        private CheckBox chbShowCurvesInfo;
        private CheckBox chbShowSurfacesInfo;
        private CheckBox chbShowHeatMap;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TabControlEx gmshTab;
        private CheckBox chbShowTranfPoints;
        private TreeView surfsTree;
        private TreeView volumesTree;
        private Label algoLabel;
        private ComboBox algoChoice;
        private GroupBoxEx grbGradientMeshSettings;
        private TextBox txbThickness;
        private Label label1;
        private TextBox txbFirstLayerMeshSize;
        private Label label5;
        private Label label4;
        private TextBox txbSecondLayerMeshSize;
    }
}