using BaseModule.Mesh.SettingsControls;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.Mesh
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
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsRemoveMesh2D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem3DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveMesh3D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem2DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gmshTab = new UserControlsEx.TabControlEx();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.geometryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.geomTree = new System.Windows.Forms.TreeView();
            this.entitieSettingsBox = new UserControlsEx.GroupBoxEx();
            this.volSettingsControl = new BaseModule.Mesh.SettingsControls.GMSHVolSettingsControl();
            this.curveSettingsControl = new BaseModule.Mesh.SettingsControls.GMSHCurveSettingsControl();
            this.pointSettingsControl = new BaseModule.Mesh.SettingsControls.GMSHPointSettingsControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMinMaxSizes = new System.Windows.Forms.Button();
            this.txbMinMaxSizes = new UserControlsEx.TextBoxEx(this.components);
            this.chbShowNodesOnCurves = new System.Windows.Forms.CheckBox();
            this.chbShowHeatMap = new System.Windows.Forms.CheckBox();
            this.chbShowSurfaceNumbers = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbShowNumberOfCurveNodes = new System.Windows.Forms.CheckBox();
            this.meshPage = new System.Windows.Forms.TabPage();
            this.meshLayout = new System.Windows.Forms.TableLayoutPanel();
            this.surfsTree = new System.Windows.Forms.TreeView();
            this.meshGenBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.refineBtn = new System.Windows.Forms.Button();
            this.algoLabel = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            this.btnMesh2DDel = new System.Windows.Forms.Button();
            this.quadBtn = new System.Windows.Forms.Button();
            this.cmbAlgoChoice = new UserControlsEx.ComboBoxEx(this.components);
            this.meshDensityValue = new UserControlsEx.TextBoxEx(this.components);
            this.mesh2DGenBtn = new System.Windows.Forms.Button();
            this.volumePage = new System.Windows.Forms.TabPage();
            this.volumeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.volumesTree = new System.Windows.Forms.TreeView();
            this.grbVolControlBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenVolMesh = new System.Windows.Forms.Button();
            this.btnDelVolMesh = new System.Windows.Forms.Button();
            this.cmsRemoveMesh2D.SuspendLayout();
            this.cmsRemoveMesh3D.SuspendLayout();
            this.gmshTab.SuspendLayout();
            this.geometryPage.SuspendLayout();
            this.geometryLayout.SuspendLayout();
            this.entitieSettingsBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.meshPage.SuspendLayout();
            this.meshLayout.SuspendLayout();
            this.meshGenBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.volumePage.SuspendLayout();
            this.volumeLayout.SuspendLayout();
            this.grbVolControlBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFileDialog
            // 
            this.loadFileDialog.FileName = "untitled.geo";
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
            this.gmshTab.Size = new System.Drawing.Size(694, 745);
            this.gmshTab.TabIndex = 1;
            this.gmshTab.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.Control;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 34);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(0);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Size = new System.Drawing.Size(686, 707);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // geometryLayout
            // 
            this.geometryLayout.BackColor = System.Drawing.SystemColors.Control;
            this.geometryLayout.ColumnCount = 1;
            this.geometryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.Controls.Add(this.geomTree, 0, 1);
            this.geometryLayout.Controls.Add(this.entitieSettingsBox, 0, 0);
            this.geometryLayout.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.geometryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryLayout.Location = new System.Drawing.Point(0, 0);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 3;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.geometryLayout.Size = new System.Drawing.Size(686, 707);
            this.geometryLayout.TabIndex = 0;
            // 
            // geomTree
            // 
            this.geomTree.BackColor = System.Drawing.SystemColors.Window;
            this.geomTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geomTree.HideSelection = false;
            this.geomTree.Location = new System.Drawing.Point(7, 257);
            this.geomTree.Margin = new System.Windows.Forms.Padding(7);
            this.geomTree.Name = "geomTree";
            this.geomTree.Size = new System.Drawing.Size(672, 305);
            this.geomTree.TabIndex = 14;
            this.geomTree.Tag = "entTree";
            this.geomTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.entTree_BeforeSelect);
            this.geomTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // entitieSettingsBox
            // 
            this.entitieSettingsBox.CheckState = true;
            this.entitieSettingsBox.Controls.Add(this.volSettingsControl);
            this.entitieSettingsBox.Controls.Add(this.curveSettingsControl);
            this.entitieSettingsBox.Controls.Add(this.pointSettingsControl);
            this.entitieSettingsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitieSettingsBox.IsCheckable = false;
            this.entitieSettingsBox.IsExpanded = false;
            this.entitieSettingsBox.IsRollable = false;
            this.entitieSettingsBox.Location = new System.Drawing.Point(7, 7);
            this.entitieSettingsBox.Margin = new System.Windows.Forms.Padding(7);
            this.entitieSettingsBox.MinimumSize = new System.Drawing.Size(0, 100);
            this.entitieSettingsBox.Name = "entitieSettingsBox";
            this.entitieSettingsBox.Size = new System.Drawing.Size(672, 236);
            this.entitieSettingsBox.TabIndex = 18;
            this.entitieSettingsBox.TabStop = false;
            this.entitieSettingsBox.Text = "Настройки разметки";
            // 
            // volSettingsControl
            // 
            this.volSettingsControl.Location = new System.Drawing.Point(202, 174);
            this.volSettingsControl.Margin = new System.Windows.Forms.Padding(0);
            this.volSettingsControl.Name = "volSettingsControl";
            this.volSettingsControl.Size = new System.Drawing.Size(467, 195);
            this.volSettingsControl.TabIndex = 3;
            this.volSettingsControl.setMeshGradientEvent += new System.Action<object, BaseModule.Mesh.MeshGradientSettingsEventArgs>(this.gmshVolSettingsControl_setMeshGradientSettingsEventHandler);
            this.volSettingsControl.delMeshGradientEvent += new System.Action<object>(this.gmshVolSettingsControl_delMeshGradientEventHandler);
            // 
            // curveSettingsControl
            // 
            this.curveSettingsControl.Location = new System.Drawing.Point(53, 155);
            this.curveSettingsControl.Margin = new System.Windows.Forms.Padding(0);
            this.curveSettingsControl.Name = "curveSettingsControl";
            this.curveSettingsControl.Size = new System.Drawing.Size(517, 127);
            this.curveSettingsControl.TabIndex = 2;
            this.curveSettingsControl.pressOkEvent += new System.Action<object, string[]>(this.CurveSettingsControl_pressOkEvent);
            this.curveSettingsControl.pressDelEvent += new System.Action<object>(this.CurveSettingsControl_pressDelEvent);
            // 
            // pointSettingsControl
            // 
            this.pointSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointSettingsControl.Location = new System.Drawing.Point(3, 16);
            this.pointSettingsControl.Name = "pointSettingsControl";
            this.pointSettingsControl.Size = new System.Drawing.Size(666, 217);
            this.pointSettingsControl.TabIndex = 1;
            this.pointSettingsControl.pressOkEvent += new System.Action<object, double[]>(this.PointSettingsControl_pressOkEvent);
            this.pointSettingsControl.pressDelEvent += new System.Action<object>(this.PointSettingsControl_pressDelEvent);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnMinMaxSizes, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txbMinMaxSizes, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.chbShowNodesOnCurves, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbShowHeatMap, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chbShowSurfaceNumbers, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbShowNumberOfCurveNodes, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 569);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(686, 138);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Мин.\\Макс. размер элементов:";
            // 
            // btnMinMaxSizes
            // 
            this.btnMinMaxSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinMaxSizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinMaxSizes.Location = new System.Drawing.Point(476, 101);
            this.btnMinMaxSizes.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnMinMaxSizes.Name = "btnMinMaxSizes";
            this.btnMinMaxSizes.Size = new System.Drawing.Size(190, 27);
            this.btnMinMaxSizes.TabIndex = 8;
            this.btnMinMaxSizes.Text = "Задать";
            this.btnMinMaxSizes.UseVisualStyleBackColor = true;
            this.btnMinMaxSizes.Click += new System.EventHandler(this.BtnMinMaxSizes_Click);
            // 
            // txbMinMaxSizes
            // 
            this.txbMinMaxSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinMaxSizes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMinMaxSizes.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbMinMaxSizes.IsValidating = true;
            this.txbMinMaxSizes.Location = new System.Drawing.Point(248, 104);
            this.txbMinMaxSizes.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.txbMinMaxSizes.Name = "txbMinMaxSizes";
            this.txbMinMaxSizes.Size = new System.Drawing.Size(188, 20);
            this.txbMinMaxSizes.TabIndex = 6;
            this.txbMinMaxSizes.Text = "0 , 1e+22";
            this.txbMinMaxSizes.UserRegExCheck = null;
            this.txbMinMaxSizes.UserRegExCheckErrorMessage = null;
            // 
            // chbShowNodesOnCurves
            // 
            this.chbShowNodesOnCurves.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowNodesOnCurves.AutoSize = true;
            this.chbShowNodesOnCurves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowNodesOnCurves.Location = new System.Drawing.Point(248, 15);
            this.chbShowNodesOnCurves.Margin = new System.Windows.Forms.Padding(20, 5, 3, 2);
            this.chbShowNodesOnCurves.Name = "chbShowNodesOnCurves";
            this.chbShowNodesOnCurves.Size = new System.Drawing.Size(158, 17);
            this.chbShowNodesOnCurves.TabIndex = 3;
            this.chbShowNodesOnCurves.Text = "Показать узлы на кривых";
            this.chbShowNodesOnCurves.UseVisualStyleBackColor = true;
            this.chbShowNodesOnCurves.Click += new System.EventHandler(this.chbShowNodesOnCurves_Click);
            // 
            // chbShowHeatMap
            // 
            this.chbShowHeatMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowHeatMap.AutoSize = true;
            this.chbShowHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowHeatMap.Location = new System.Drawing.Point(248, 59);
            this.chbShowHeatMap.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.chbShowHeatMap.Name = "chbShowHeatMap";
            this.chbShowHeatMap.Size = new System.Drawing.Size(166, 17);
            this.chbShowHeatMap.TabIndex = 4;
            this.chbShowHeatMap.Text = "Построить карту плотности";
            this.chbShowHeatMap.UseVisualStyleBackColor = true;
            this.chbShowHeatMap.Click += new System.EventHandler(this.chbShowHeatMap_Click);
            // 
            // chbShowSurfaceNumbers
            // 
            this.chbShowSurfaceNumbers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowSurfaceNumbers.AutoSize = true;
            this.chbShowSurfaceNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowSurfaceNumbers.Location = new System.Drawing.Point(20, 59);
            this.chbShowSurfaceNumbers.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.chbShowSurfaceNumbers.Name = "chbShowSurfaceNumbers";
            this.chbShowSurfaceNumbers.Size = new System.Drawing.Size(189, 17);
            this.chbShowSurfaceNumbers.TabIndex = 5;
            this.chbShowSurfaceNumbers.Text = "Показать номера поверхностей";
            this.chbShowSurfaceNumbers.UseVisualStyleBackColor = true;
            this.chbShowSurfaceNumbers.Click += new System.EventHandler(this.chbShowSurfaceNumbers_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(463, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 17;
            // 
            // chbShowNumberOfCurveNodes
            // 
            this.chbShowNumberOfCurveNodes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowNumberOfCurveNodes.AutoSize = true;
            this.chbShowNumberOfCurveNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowNumberOfCurveNodes.Location = new System.Drawing.Point(20, 15);
            this.chbShowNumberOfCurveNodes.Margin = new System.Windows.Forms.Padding(20, 5, 3, 2);
            this.chbShowNumberOfCurveNodes.Name = "chbShowNumberOfCurveNodes";
            this.chbShowNumberOfCurveNodes.Size = new System.Drawing.Size(198, 17);
            this.chbShowNumberOfCurveNodes.TabIndex = 3;
            this.chbShowNumberOfCurveNodes.Text = "Показать кол-во узлов на кривых";
            this.chbShowNumberOfCurveNodes.UseVisualStyleBackColor = true;
            this.chbShowNumberOfCurveNodes.Click += new System.EventHandler(this.chbShowNumberOfCurveNodes_Click);
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 34);
            this.meshPage.Margin = new System.Windows.Forms.Padding(0);
            this.meshPage.Name = "meshPage";
            this.meshPage.Size = new System.Drawing.Size(686, 707);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
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
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.meshLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.meshLayout.Size = new System.Drawing.Size(686, 707);
            this.meshLayout.TabIndex = 0;
            // 
            // surfsTree
            // 
            this.surfsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfsTree.FullRowSelect = true;
            this.surfsTree.Location = new System.Drawing.Point(7, 187);
            this.surfsTree.Margin = new System.Windows.Forms.Padding(7);
            this.surfsTree.Name = "surfsTree";
            this.surfsTree.Size = new System.Drawing.Size(672, 513);
            this.surfsTree.TabIndex = 4;
            this.surfsTree.Tag = "elemsTree";
            this.surfsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
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
            this.meshGenBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.meshGenBox.Size = new System.Drawing.Size(672, 166);
            this.meshGenBox.TabIndex = 3;
            this.meshGenBox.TabStop = false;
            this.meshGenBox.Text = "Управление сеткой";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.refineBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.algoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.densityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMesh2DDel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbAlgoChoice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.meshDensityValue, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mesh2DGenBtn, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 150);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.refineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refineBtn.Location = new System.Drawing.Point(153, 113);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(226, 27);
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
            this.densityLabel.Location = new System.Drawing.Point(16, 72);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(101, 13);
            this.densityLabel.TabIndex = 0;
            this.densityLabel.Text = "Фактор масштаба";
            this.densityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMesh2DDel
            // 
            this.btnMesh2DDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMesh2DDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesh2DDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMesh2DDel.Location = new System.Drawing.Point(419, 65);
            this.btnMesh2DDel.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnMesh2DDel.Name = "btnMesh2DDel";
            this.btnMesh2DDel.Size = new System.Drawing.Size(227, 27);
            this.btnMesh2DDel.TabIndex = 9;
            this.btnMesh2DDel.Text = "Удалить";
            this.btnMesh2DDel.UseVisualStyleBackColor = true;
            this.btnMesh2DDel.Click += new System.EventHandler(this.OnDeleteMesh2D);
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.quadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quadBtn.Location = new System.Drawing.Point(419, 113);
            this.quadBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.quadBtn.Name = "quadBtn";
            this.quadBtn.Size = new System.Drawing.Size(227, 27);
            this.quadBtn.TabIndex = 11;
            this.quadBtn.Text = "Квадратная сетка";
            this.quadBtn.UseVisualStyleBackColor = true;
            this.quadBtn.Click += new System.EventHandler(this.OnQuadrangulate);
            // 
            // cmbAlgoChoice
            // 
            this.cmbAlgoChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbAlgoChoice, 2);
            this.cmbAlgoChoice.FormattingEnabled = true;
            this.cmbAlgoChoice.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbAlgoChoice.IsValidating = true;
            this.cmbAlgoChoice.Items.AddRange(new object[] {
            "MeshAdapt",
            "Automatic",
            "Delaunay",
            "FrontalDelaunay",
            "FrontalDelaunayQuad"});
            this.cmbAlgoChoice.Location = new System.Drawing.Point(153, 20);
            this.cmbAlgoChoice.Margin = new System.Windows.Forms.Padding(20);
            this.cmbAlgoChoice.Name = "cmbAlgoChoice";
            this.cmbAlgoChoice.Size = new System.Drawing.Size(493, 21);
            this.cmbAlgoChoice.TabIndex = 12;
            this.cmbAlgoChoice.UserRegExCheck = null;
            this.cmbAlgoChoice.UserRegExCheckErrorMessage = null;
            this.cmbAlgoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.meshDensityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.meshDensityValue.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.meshDensityValue.IsValidating = true;
            this.meshDensityValue.Location = new System.Drawing.Point(20, 116);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(93, 20);
            this.meshDensityValue.TabIndex = 13;
            this.meshDensityValue.Text = "1";
            this.meshDensityValue.UserRegExCheck = null;
            this.meshDensityValue.UserRegExCheckErrorMessage = null;
            // 
            // mesh2DGenBtn
            // 
            this.mesh2DGenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mesh2DGenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mesh2DGenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mesh2DGenBtn.Location = new System.Drawing.Point(153, 65);
            this.mesh2DGenBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.mesh2DGenBtn.Name = "mesh2DGenBtn";
            this.mesh2DGenBtn.Size = new System.Drawing.Size(226, 27);
            this.mesh2DGenBtn.TabIndex = 5;
            this.mesh2DGenBtn.Text = "Треугольная сетка";
            this.mesh2DGenBtn.UseVisualStyleBackColor = true;
            this.mesh2DGenBtn.Click += new System.EventHandler(this.OnGenerateMesh2D);
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.volumeLayout);
            this.volumePage.Location = new System.Drawing.Point(4, 34);
            this.volumePage.Margin = new System.Windows.Forms.Padding(0);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(686, 707);
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
            this.volumeLayout.Size = new System.Drawing.Size(686, 707);
            this.volumeLayout.TabIndex = 0;
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(7, 92);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(7);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(672, 608);
            this.volumesTree.TabIndex = 5;
            this.volumesTree.Tag = "volElemsTree";
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
            this.grbVolControlBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grbVolControlBox.Size = new System.Drawing.Size(672, 71);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(666, 55);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnGenVolMesh
            // 
            this.btnGenVolMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenVolMesh.Location = new System.Drawing.Point(20, 14);
            this.btnGenVolMesh.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnGenVolMesh.Name = "btnGenVolMesh";
            this.btnGenVolMesh.Size = new System.Drawing.Size(293, 27);
            this.btnGenVolMesh.TabIndex = 5;
            this.btnGenVolMesh.Text = "Сгенерировать";
            this.btnGenVolMesh.UseVisualStyleBackColor = true;
            this.btnGenVolMesh.Click += new System.EventHandler(this.OnGenerateMesh3D);
            // 
            // btnDelVolMesh
            // 
            this.btnDelVolMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelVolMesh.Location = new System.Drawing.Point(353, 14);
            this.btnDelVolMesh.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDelVolMesh.Name = "btnDelVolMesh";
            this.btnDelVolMesh.Size = new System.Drawing.Size(293, 27);
            this.btnDelVolMesh.TabIndex = 6;
            this.btnDelVolMesh.Text = "Удалить";
            this.btnDelVolMesh.UseVisualStyleBackColor = true;
            this.btnDelVolMesh.Click += new System.EventHandler(this.OnDeleteMesh3D);
            // 
            // GMSHGeneralMeshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GMSHGeneralMeshControl";
            this.Size = new System.Drawing.Size(694, 745);
            this.cmsRemoveMesh2D.ResumeLayout(false);
            this.cmsRemoveMesh3D.ResumeLayout(false);
            this.gmshTab.ResumeLayout(false);
            this.geometryPage.ResumeLayout(false);
            this.geometryLayout.ResumeLayout(false);
            this.entitieSettingsBox.ResumeLayout(false);
            this.entitieSettingsBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.meshPage.ResumeLayout(false);
            this.meshLayout.ResumeLayout(false);
            this.meshLayout.PerformLayout();
            this.meshGenBox.ResumeLayout(false);
            this.meshGenBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.volumePage.ResumeLayout(false);
            this.volumeLayout.ResumeLayout(false);
            this.volumeLayout.PerformLayout();
            this.grbVolControlBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMesh2DDel;
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
        private TreeView geomTree;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private TabControlEx gmshTab;
        private TreeView surfsTree;
        private TreeView volumesTree;
        private Label algoLabel;
        private ComboBoxEx cmbAlgoChoice;
        private TextBoxEx meshDensityValue;
        private GroupBoxEx entitieSettingsBox;
        private GMSHPointSettingsControl pointSettingsControl;
        private GMSHCurveSettingsControl curveSettingsControl;
        private GMSHVolSettingsControl volSettingsControl;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Button btnMinMaxSizes;
        private TextBoxEx txbMinMaxSizes;
        private CheckBox chbShowNodesOnCurves;
        private CheckBox chbShowHeatMap;
        private CheckBox chbShowSurfaceNumbers;
        private Panel panel2;
        private CheckBox chbShowNumberOfCurveNodes;
    }
}