
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
            this.components = new System.ComponentModel.Container();
            this.btnMesh2DDel = new System.Windows.Forms.Button();
            this.algoChoice = new System.Windows.Forms.ComboBox();
            this.algoLabel = new System.Windows.Forms.Label();
            this.meshDensityValue = new System.Windows.Forms.TextBox();
            this.mesh2DGenBtn = new System.Windows.Forms.Button();
            this.meshGenBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.refineBtn = new System.Windows.Forms.Button();
            this.densityLabel = new System.Windows.Forms.Label();
            this.quadBtn = new System.Windows.Forms.Button();
            this.meshLayout = new System.Windows.Forms.TableLayoutPanel();
            this.meshElBox = new System.Windows.Forms.GroupBox();
            this.surfsTree = new System.Windows.Forms.TreeView();
            this.meshPage = new System.Windows.Forms.TabPage();
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.volElBox = new System.Windows.Forms.GroupBox();
            this.volumesTree = new System.Windows.Forms.TreeView();
            this.volumeBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.volGenBtn = new System.Windows.Forms.Button();
            this.btnMesh3DDel = new System.Windows.Forms.Button();
            this.volumePage = new System.Windows.Forms.TabPage();
            this.volumeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.geometryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pointsControlBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.algoCoef = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
            this.txbAlgoNPoints = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbShowCurvesInfo = new System.Windows.Forms.CheckBox();
            this.chbShowSurfacesInfo = new System.Windows.Forms.CheckBox();
            this.chbShowHeatMap = new System.Windows.Forms.CheckBox();
            this.geomTree = new System.Windows.Forms.TreeView();
            this.gmshTab = new System.Windows.Forms.TabControl();
            this.cmsRemoveMesh2D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem3DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveMesh3D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem2DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshGenBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.meshLayout.SuspendLayout();
            this.meshElBox.SuspendLayout();
            this.meshPage.SuspendLayout();
            this.volElBox.SuspendLayout();
            this.volumeBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.volumePage.SuspendLayout();
            this.volumeLayout.SuspendLayout();
            this.geometryPage.SuspendLayout();
            this.geometryLayout.SuspendLayout();
            this.pointsControlBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gmshTab.SuspendLayout();
            this.cmsRemoveMesh2D.SuspendLayout();
            this.cmsRemoveMesh3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMesh2DDel
            // 
            this.btnMesh2DDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMesh2DDel.Enabled = false;
            this.btnMesh2DDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMesh2DDel.Location = new System.Drawing.Point(330, 60);
            this.btnMesh2DDel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnMesh2DDel.Name = "btnMesh2DDel";
            this.btnMesh2DDel.Size = new System.Drawing.Size(154, 32);
            this.btnMesh2DDel.TabIndex = 9;
            this.btnMesh2DDel.Text = "Удалить";
            this.btnMesh2DDel.UseVisualStyleBackColor = true;
            this.btnMesh2DDel.Click += new System.EventHandler(this.OnDeleteMesh2D);
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
            this.algoChoice.Location = new System.Drawing.Point(163, 14);
            this.algoChoice.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.algoChoice.Name = "algoChoice";
            this.algoChoice.Size = new System.Drawing.Size(322, 24);
            this.algoChoice.TabIndex = 8;
            this.algoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // algoLabel
            // 
            this.algoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.algoLabel.AutoSize = true;
            this.algoLabel.Enabled = false;
            this.algoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.algoLabel.Location = new System.Drawing.Point(12, 9);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(131, 34);
            this.algoLabel.TabIndex = 7;
            this.algoLabel.Text = "Алгоритм построения сетки:";
            this.algoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.meshDensityValue.Enabled = false;
            this.meshDensityValue.Location = new System.Drawing.Point(7, 112);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(141, 23);
            this.meshDensityValue.TabIndex = 6;
            this.meshDensityValue.Text = "1";
            this.meshDensityValue.TextChanged += new System.EventHandler(this.OnDencityChange);
            // 
            // mesh2DGenBtn
            // 
            this.mesh2DGenBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mesh2DGenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mesh2DGenBtn.Location = new System.Drawing.Point(163, 60);
            this.mesh2DGenBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.mesh2DGenBtn.Name = "mesh2DGenBtn";
            this.mesh2DGenBtn.Size = new System.Drawing.Size(151, 32);
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
            this.meshGenBox.Location = new System.Drawing.Point(0, 0);
            this.meshGenBox.Margin = new System.Windows.Forms.Padding(0);
            this.meshGenBox.Name = "meshGenBox";
            this.meshGenBox.Padding = new System.Windows.Forms.Padding(0);
            this.meshGenBox.Size = new System.Drawing.Size(492, 163);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.Controls.Add(this.refineBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.meshDensityValue, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.algoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.densityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.algoChoice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMesh2DDel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.mesh2DGenBtn, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 147);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refineBtn.Location = new System.Drawing.Point(163, 107);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(152, 32);
            this.refineBtn.TabIndex = 10;
            this.refineBtn.Text = "Уплотнить";
            this.refineBtn.UseVisualStyleBackColor = true;
            this.refineBtn.Click += new System.EventHandler(this.OnRefine);
            // 
            // densityLabel
            // 
            this.densityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.densityLabel.AutoSize = true;
            this.densityLabel.Enabled = false;
            this.densityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.densityLabel.Location = new System.Drawing.Point(10, 68);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(135, 17);
            this.densityLabel.TabIndex = 0;
            this.densityLabel.Text = "Размер элементов:";
            this.densityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quadBtn.Location = new System.Drawing.Point(331, 107);
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
            this.meshLayout.Controls.Add(this.meshGenBox, 0, 0);
            this.meshLayout.Controls.Add(this.meshElBox, 0, 1);
            this.meshLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshLayout.Location = new System.Drawing.Point(0, 0);
            this.meshLayout.Margin = new System.Windows.Forms.Padding(0);
            this.meshLayout.Name = "meshLayout";
            this.meshLayout.RowCount = 2;
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.54641F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.45359F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.meshLayout.Size = new System.Drawing.Size(492, 571);
            this.meshLayout.TabIndex = 0;
            // 
            // meshElBox
            // 
            this.meshElBox.BackColor = System.Drawing.SystemColors.Control;
            this.meshElBox.Controls.Add(this.surfsTree);
            this.meshElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshElBox.Enabled = false;
            this.meshElBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meshElBox.Location = new System.Drawing.Point(0, 163);
            this.meshElBox.Margin = new System.Windows.Forms.Padding(0);
            this.meshElBox.Name = "meshElBox";
            this.meshElBox.Padding = new System.Windows.Forms.Padding(0);
            this.meshElBox.Size = new System.Drawing.Size(492, 408);
            this.meshElBox.TabIndex = 5;
            this.meshElBox.TabStop = false;
            this.meshElBox.Text = "Элементы сетки";
            // 
            // surfsTree
            // 
            this.surfsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfsTree.FullRowSelect = true;
            this.surfsTree.Location = new System.Drawing.Point(0, 16);
            this.surfsTree.Margin = new System.Windows.Forms.Padding(0);
            this.surfsTree.Name = "surfsTree";
            this.surfsTree.Size = new System.Drawing.Size(492, 392);
            this.surfsTree.TabIndex = 1;
            this.surfsTree.Tag = "elemsTree";
            this.surfsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 25);
            this.meshPage.Margin = new System.Windows.Forms.Padding(0);
            this.meshPage.Name = "meshPage";
            this.meshPage.Size = new System.Drawing.Size(492, 571);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
            // 
            // loadFileDialog
            // 
            this.loadFileDialog.FileName = "untitled.geo";
            // 
            // volElBox
            // 
            this.volElBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.volElBox.BackColor = System.Drawing.SystemColors.Control;
            this.volElBox.Controls.Add(this.volumesTree);
            this.volElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volElBox.Enabled = false;
            this.volElBox.Location = new System.Drawing.Point(0, 64);
            this.volElBox.Margin = new System.Windows.Forms.Padding(0);
            this.volElBox.Name = "volElBox";
            this.volElBox.Padding = new System.Windows.Forms.Padding(0);
            this.volElBox.Size = new System.Drawing.Size(492, 507);
            this.volElBox.TabIndex = 6;
            this.volElBox.TabStop = false;
            this.volElBox.Text = "Элементы объемов";
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(0, 16);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(0);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(492, 491);
            this.volumesTree.TabIndex = 1;
            this.volumesTree.Tag = "volElemsTree";
            // 
            // volumeBox
            // 
            this.volumeBox.AutoSize = true;
            this.volumeBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.volumeBox.BackColor = System.Drawing.SystemColors.Control;
            this.volumeBox.Controls.Add(this.tableLayoutPanel3);
            this.volumeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeBox.Enabled = false;
            this.volumeBox.Location = new System.Drawing.Point(0, 0);
            this.volumeBox.Margin = new System.Windows.Forms.Padding(0);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Padding = new System.Windows.Forms.Padding(0);
            this.volumeBox.Size = new System.Drawing.Size(492, 64);
            this.volumeBox.TabIndex = 4;
            this.volumeBox.TabStop = false;
            this.volumeBox.Text = "Управление сеткой";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.volGenBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMesh3DDel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(492, 48);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // volGenBtn
            // 
            this.volGenBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.volGenBtn.Location = new System.Drawing.Point(10, 8);
            this.volGenBtn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.volGenBtn.Name = "volGenBtn";
            this.volGenBtn.Size = new System.Drawing.Size(229, 32);
            this.volGenBtn.TabIndex = 5;
            this.volGenBtn.Text = "Сгенерировать";
            this.volGenBtn.UseVisualStyleBackColor = true;
            this.volGenBtn.Click += new System.EventHandler(this.OnGenerateMesh3D);
            // 
            // btnMesh3DDel
            // 
            this.btnMesh3DDel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMesh3DDel.Enabled = false;
            this.btnMesh3DDel.Location = new System.Drawing.Point(254, 8);
            this.btnMesh3DDel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnMesh3DDel.Name = "btnMesh3DDel";
            this.btnMesh3DDel.Size = new System.Drawing.Size(231, 32);
            this.btnMesh3DDel.TabIndex = 6;
            this.btnMesh3DDel.Text = "Удалить";
            this.btnMesh3DDel.UseVisualStyleBackColor = true;
            this.btnMesh3DDel.Click += new System.EventHandler(this.OnDeleteMesh3D);
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.volumeLayout);
            this.volumePage.Location = new System.Drawing.Point(4, 25);
            this.volumePage.Margin = new System.Windows.Forms.Padding(0);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(492, 571);
            this.volumePage.TabIndex = 2;
            this.volumePage.Text = "3D";
            // 
            // volumeLayout
            // 
            this.volumeLayout.ColumnCount = 1;
            this.volumeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeLayout.Controls.Add(this.volumeBox, 0, 0);
            this.volumeLayout.Controls.Add(this.volElBox, 0, 1);
            this.volumeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeLayout.Location = new System.Drawing.Point(0, 0);
            this.volumeLayout.Margin = new System.Windows.Forms.Padding(0);
            this.volumeLayout.Name = "volumeLayout";
            this.volumeLayout.RowCount = 2;
            this.volumeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.volumeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volumeLayout.Size = new System.Drawing.Size(492, 571);
            this.volumeLayout.TabIndex = 0;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 25);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(0);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Size = new System.Drawing.Size(492, 571);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // geometryLayout
            // 
            this.geometryLayout.ColumnCount = 1;
            this.geometryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.Controls.Add(this.pointsControlBox, 0, 0);
            this.geometryLayout.Controls.Add(this.panel2, 0, 2);
            this.geometryLayout.Controls.Add(this.geomTree, 0, 1);
            this.geometryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryLayout.Location = new System.Drawing.Point(0, 0);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 3;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.Size = new System.Drawing.Size(492, 571);
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
            this.pointsControlBox.Location = new System.Drawing.Point(0, 0);
            this.pointsControlBox.Margin = new System.Windows.Forms.Padding(0);
            this.pointsControlBox.Name = "pointsControlBox";
            this.pointsControlBox.Padding = new System.Windows.Forms.Padding(0);
            this.pointsControlBox.Size = new System.Drawing.Size(492, 157);
            this.pointsControlBox.TabIndex = 2;
            this.pointsControlBox.TabStop = false;
            this.pointsControlBox.Text = "Управление разметкой кривых";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.7284F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.25203F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.42276F));
            this.tableLayoutPanel2.Controls.Add(this.rbtnProgressive, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.algoCoef, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBump, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBeta, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txbAlgoNPoints, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDel, 3, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(492, 141);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // rbtnProgressive
            // 
            this.rbtnProgressive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnProgressive.AutoSize = true;
            this.rbtnProgressive.Checked = true;
            this.rbtnProgressive.Location = new System.Drawing.Point(5, 13);
            this.rbtnProgressive.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.rbtnProgressive.Name = "rbtnProgressive";
            this.rbtnProgressive.Size = new System.Drawing.Size(78, 21);
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
            this.label3.Location = new System.Drawing.Point(102, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Коэффициент:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Число точек:";
            // 
            // algoCoef
            // 
            this.algoCoef.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.SetColumnSpan(this.algoCoef, 2);
            this.algoCoef.Location = new System.Drawing.Point(234, 12);
            this.algoCoef.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.algoCoef.Name = "algoCoef";
            this.algoCoef.Size = new System.Drawing.Size(251, 23);
            this.algoCoef.TabIndex = 4;
            this.algoCoef.Tag = "algoCoef";
            this.algoCoef.Text = "1.0";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.Location = new System.Drawing.Point(368, 101);
            this.btnDel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(116, 32);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(233, 101);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // rbtnBump
            // 
            this.rbtnBump.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBump.AutoSize = true;
            this.rbtnBump.Location = new System.Drawing.Point(3, 60);
            this.rbtnBump.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBump.Name = "rbtnBump";
            this.rbtnBump.Size = new System.Drawing.Size(65, 21);
            this.rbtnBump.TabIndex = 1;
            this.rbtnBump.Tag = "Колокол";
            this.rbtnBump.Text = "Bump";
            this.rbtnBump.UseVisualStyleBackColor = true;
            // 
            // rbtnBeta
            // 
            this.rbtnBeta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBeta.AutoSize = true;
            this.rbtnBeta.Location = new System.Drawing.Point(3, 107);
            this.rbtnBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBeta.Name = "rbtnBeta";
            this.rbtnBeta.Size = new System.Drawing.Size(58, 21);
            this.rbtnBeta.TabIndex = 2;
            this.rbtnBeta.Tag = "Бета";
            this.rbtnBeta.Text = "Beta";
            this.rbtnBeta.UseVisualStyleBackColor = true;
            // 
            // txbAlgoNPoints
            // 
            this.txbAlgoNPoints.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.SetColumnSpan(this.txbAlgoNPoints, 2);
            this.txbAlgoNPoints.Location = new System.Drawing.Point(234, 59);
            this.txbAlgoNPoints.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.txbAlgoNPoints.Name = "txbAlgoNPoints";
            this.txbAlgoNPoints.Size = new System.Drawing.Size(251, 23);
            this.txbAlgoNPoints.TabIndex = 5;
            this.txbAlgoNPoints.Tag = "algoNPoints";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.chbShowCurvesInfo);
            this.panel2.Controls.Add(this.chbShowSurfacesInfo);
            this.panel2.Controls.Add(this.chbShowHeatMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 76);
            this.panel2.TabIndex = 16;
            // 
            // chbShowCurvesInfo
            // 
            this.chbShowCurvesInfo.AutoSize = true;
            this.chbShowCurvesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowCurvesInfo.Location = new System.Drawing.Point(19, 5);
            this.chbShowCurvesInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.chbShowCurvesInfo.Name = "chbShowCurvesInfo";
            this.chbShowCurvesInfo.Size = new System.Drawing.Size(144, 21);
            this.chbShowCurvesInfo.TabIndex = 3;
            this.chbShowCurvesInfo.Text = "Показать кривые";
            this.chbShowCurvesInfo.UseVisualStyleBackColor = true;
            this.chbShowCurvesInfo.Click += new System.EventHandler(this.chbShowCurvesInfo_Click);
            // 
            // chbShowSurfacesInfo
            // 
            this.chbShowSurfacesInfo.AutoSize = true;
            this.chbShowSurfacesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowSurfacesInfo.Location = new System.Drawing.Point(19, 30);
            this.chbShowSurfacesInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbShowSurfacesInfo.Name = "chbShowSurfacesInfo";
            this.chbShowSurfacesInfo.Size = new System.Drawing.Size(179, 21);
            this.chbShowSurfacesInfo.TabIndex = 5;
            this.chbShowSurfacesInfo.Text = "Показать поверхности";
            this.chbShowSurfacesInfo.UseVisualStyleBackColor = true;
            this.chbShowSurfacesInfo.Click += new System.EventHandler(this.chbShowSurfacesInfo_Click);
            // 
            // chbShowHeatMap
            // 
            this.chbShowHeatMap.AutoSize = true;
            this.chbShowHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowHeatMap.Location = new System.Drawing.Point(19, 53);
            this.chbShowHeatMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbShowHeatMap.Name = "chbShowHeatMap";
            this.chbShowHeatMap.Size = new System.Drawing.Size(214, 21);
            this.chbShowHeatMap.TabIndex = 4;
            this.chbShowHeatMap.Text = "Построить карту плотности";
            this.chbShowHeatMap.UseVisualStyleBackColor = true;
            this.chbShowHeatMap.Click += new System.EventHandler(this.chbShowHeatMap_Click);
            // 
            // geomTree
            // 
            this.geomTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geomTree.HideSelection = false;
            this.geomTree.Location = new System.Drawing.Point(0, 157);
            this.geomTree.Margin = new System.Windows.Forms.Padding(0);
            this.geomTree.Name = "geomTree";
            this.geomTree.Size = new System.Drawing.Size(492, 338);
            this.geomTree.TabIndex = 14;
            this.geomTree.Tag = "entTree";
            this.geomTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.entTree_BeforeSelect);
            this.geomTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // gmshTab
            // 
            this.gmshTab.Controls.Add(this.geometryPage);
            this.gmshTab.Controls.Add(this.meshPage);
            this.gmshTab.Controls.Add(this.volumePage);
            this.gmshTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gmshTab.Location = new System.Drawing.Point(0, 0);
            this.gmshTab.Margin = new System.Windows.Forms.Padding(0);
            this.gmshTab.Name = "gmshTab";
            this.gmshTab.SelectedIndex = 0;
            this.gmshTab.Size = new System.Drawing.Size(500, 600);
            this.gmshTab.TabIndex = 1;
            // 
            // cmsRemoveMesh2D
            // 
            this.cmsRemoveMesh2D.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRemoveMesh2D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rem3DItem});
            this.cmsRemoveMesh2D.Name = "cmsRemoveMesh2D";
            this.cmsRemoveMesh2D.Size = new System.Drawing.Size(135, 28);
            // 
            // rem3DItem
            // 
            this.rem3DItem.Name = "rem3DItem";
            this.rem3DItem.Size = new System.Drawing.Size(134, 24);
            this.rem3DItem.Text = "Удалить";
            this.rem3DItem.Click += new System.EventHandler(this.OnDeleteElement2D);
            // 
            // cmsRemoveMesh3D
            // 
            this.cmsRemoveMesh3D.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRemoveMesh3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rem2DItem});
            this.cmsRemoveMesh3D.Name = "cmsRemoveMesh3D";
            this.cmsRemoveMesh3D.Size = new System.Drawing.Size(135, 28);
            // 
            // rem2DItem
            // 
            this.rem2DItem.Name = "rem2DItem";
            this.rem2DItem.Size = new System.Drawing.Size(134, 24);
            this.rem2DItem.Text = "Удалить";
            this.rem2DItem.Click += new System.EventHandler(this.OnDeleteElement3D);
            // 
            // GMSHGeneralMeshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GMSHGeneralMeshControl";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.OnLoad);
            this.meshGenBox.ResumeLayout(false);
            this.meshGenBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.meshLayout.ResumeLayout(false);
            this.meshLayout.PerformLayout();
            this.meshElBox.ResumeLayout(false);
            this.meshPage.ResumeLayout(false);
            this.volElBox.ResumeLayout(false);
            this.volumeBox.ResumeLayout(false);
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
            this.gmshTab.ResumeLayout(false);
            this.cmsRemoveMesh2D.ResumeLayout(false);
            this.cmsRemoveMesh3D.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMesh2DDel;
        private System.Windows.Forms.ComboBox algoChoice;
        private System.Windows.Forms.Label algoLabel;
        private System.Windows.Forms.TextBox meshDensityValue;
        private System.Windows.Forms.Button mesh2DGenBtn;
        private System.Windows.Forms.GroupBox meshGenBox;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TableLayoutPanel meshLayout;
        private System.Windows.Forms.GroupBox meshElBox;
        private System.Windows.Forms.Button quadBtn;
        private System.Windows.Forms.Button refineBtn;
        private System.Windows.Forms.TabPage meshPage;
        private System.Windows.Forms.OpenFileDialog loadFileDialog;
        private System.Windows.Forms.GroupBox volElBox;
        private System.Windows.Forms.GroupBox volumeBox;
        private System.Windows.Forms.Button btnMesh3DDel;
        private System.Windows.Forms.Button volGenBtn;
        private System.Windows.Forms.TabPage volumePage;
        private System.Windows.Forms.TableLayoutPanel volumeLayout;
        private System.Windows.Forms.TabPage geometryPage;
        private System.Windows.Forms.TabControl gmshTab;
        private ContextMenuStrip cmsRemoveMesh2D;
        private ToolStripMenuItem rem3DItem;
        private TreeView surfsTree;
        private ContextMenuStrip cmsRemoveMesh3D;
        private ToolStripMenuItem rem2DItem;
        private TreeView volumesTree;
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
    }
}