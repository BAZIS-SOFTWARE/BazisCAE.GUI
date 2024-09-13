using System.Windows.Forms;
using UserControlsEx;

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
            this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsRemoveMesh2D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem3DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveMesh3D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rem2DItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gmshTab = new UserControlsEx.TabControlEx();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.geometryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbShowNodesOnCurves = new System.Windows.Forms.CheckBox();
            this.chbShowNumberOfCurveNodes = new System.Windows.Forms.CheckBox();
            this.chbShowSurfaceNumbers = new System.Windows.Forms.CheckBox();
            this.chbShowHeatMap = new System.Windows.Forms.CheckBox();
            this.geomTree = new System.Windows.Forms.TreeView();
            this.grbGradientMeshSettings = new UserControlsEx.GroupBoxEx();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txbLayerThickness = new UserControlsEx.TextBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txbSurfaceMeshSize = new UserControlsEx.TextBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txbCoreMeshSize = new UserControlsEx.TextBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetGradientSettings = new System.Windows.Forms.Button();
            this.txbMeshGradientPower = new UserControlsEx.TextBoxEx(this.components);
            this.entitieSettingsBox = new UserControlsEx.GroupBoxEx();
            this.gmshCurveSettingsControl1 = new ModelModule.GMSHCurveSettingsControl();
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
            this.mesh2DGenBtn = new System.Windows.Forms.Button();
            this.cmbAlgoChoice = new UserControlsEx.ComboBoxEx(this.components);
            this.meshDensityValue = new UserControlsEx.TextBoxEx(this.components);
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
            this.panel2.SuspendLayout();
            this.grbGradientMeshSettings.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.entitieSettingsBox.SuspendLayout();
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
            this.gmshTab.Size = new System.Drawing.Size(472, 676);
            this.gmshTab.TabIndex = 1;
            this.gmshTab.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.geometryLayout);
            this.geometryPage.Location = new System.Drawing.Point(4, 34);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(0);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Size = new System.Drawing.Size(464, 638);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // geometryLayout
            // 
            this.geometryLayout.BackColor = System.Drawing.SystemColors.Control;
            this.geometryLayout.ColumnCount = 1;
            this.geometryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.Controls.Add(this.panel2, 0, 3);
            this.geometryLayout.Controls.Add(this.geomTree, 0, 2);
            this.geometryLayout.Controls.Add(this.grbGradientMeshSettings, 0, 1);
            this.geometryLayout.Controls.Add(this.entitieSettingsBox, 0, 0);
            this.geometryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryLayout.Location = new System.Drawing.Point(0, 0);
            this.geometryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.geometryLayout.Name = "geometryLayout";
            this.geometryLayout.RowCount = 4;
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.geometryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.geometryLayout.Size = new System.Drawing.Size(464, 638);
            this.geometryLayout.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.chbShowNodesOnCurves);
            this.panel2.Controls.Add(this.chbShowNumberOfCurveNodes);
            this.panel2.Controls.Add(this.chbShowSurfaceNumbers);
            this.panel2.Controls.Add(this.chbShowHeatMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 582);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 49);
            this.panel2.TabIndex = 16;
            // 
            // chbShowNodesOnCurves
            // 
            this.chbShowNodesOnCurves.AutoSize = true;
            this.chbShowNodesOnCurves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowNodesOnCurves.Location = new System.Drawing.Point(224, 5);
            this.chbShowNodesOnCurves.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.chbShowNodesOnCurves.Name = "chbShowNodesOnCurves";
            this.chbShowNodesOnCurves.Size = new System.Drawing.Size(158, 17);
            this.chbShowNodesOnCurves.TabIndex = 3;
            this.chbShowNodesOnCurves.Text = "Показать узлы на кривых";
            this.chbShowNodesOnCurves.UseVisualStyleBackColor = true;
            this.chbShowNodesOnCurves.Click += new System.EventHandler(this.chbShowNodesOnCurves_Click);
            // 
            // chbShowNumberOfCurveNodes
            // 
            this.chbShowNumberOfCurveNodes.AutoSize = true;
            this.chbShowNumberOfCurveNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowNumberOfCurveNodes.Location = new System.Drawing.Point(12, 5);
            this.chbShowNumberOfCurveNodes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.chbShowNumberOfCurveNodes.Name = "chbShowNumberOfCurveNodes";
            this.chbShowNumberOfCurveNodes.Size = new System.Drawing.Size(198, 17);
            this.chbShowNumberOfCurveNodes.TabIndex = 3;
            this.chbShowNumberOfCurveNodes.Text = "Показать кол-во узлов на кривых";
            this.chbShowNumberOfCurveNodes.UseVisualStyleBackColor = true;
            this.chbShowNumberOfCurveNodes.Click += new System.EventHandler(this.chbShowNumberOfCurveNodes_Click);
            // 
            // chbShowSurfaceNumbers
            // 
            this.chbShowSurfaceNumbers.AutoSize = true;
            this.chbShowSurfaceNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbShowSurfaceNumbers.Location = new System.Drawing.Point(12, 30);
            this.chbShowSurfaceNumbers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbShowSurfaceNumbers.Name = "chbShowSurfaceNumbers";
            this.chbShowSurfaceNumbers.Size = new System.Drawing.Size(189, 17);
            this.chbShowSurfaceNumbers.TabIndex = 5;
            this.chbShowSurfaceNumbers.Text = "Показать номера поверхностей";
            this.chbShowSurfaceNumbers.UseVisualStyleBackColor = true;
            this.chbShowSurfaceNumbers.Click += new System.EventHandler(this.chbShowSurfaceNumbers_Click);
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
            this.geomTree.Location = new System.Drawing.Point(7, 442);
            this.geomTree.Margin = new System.Windows.Forms.Padding(7);
            this.geomTree.Name = "geomTree";
            this.geomTree.Size = new System.Drawing.Size(450, 126);
            this.geomTree.TabIndex = 14;
            this.geomTree.Tag = "entTree";
            this.geomTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.entTree_BeforeSelect);
            this.geomTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.entTree_AfterSelect);
            // 
            // grbGradientMeshSettings
            // 
            this.grbGradientMeshSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbGradientMeshSettings.CheckState = false;
            this.grbGradientMeshSettings.Controls.Add(this.tableLayoutPanel4);
            this.grbGradientMeshSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGradientMeshSettings.IsCheckable = true;
            this.grbGradientMeshSettings.IsExpanded = true;
            this.grbGradientMeshSettings.IsRollable = true;
            this.grbGradientMeshSettings.Location = new System.Drawing.Point(7, 178);
            this.grbGradientMeshSettings.Margin = new System.Windows.Forms.Padding(7);
            this.grbGradientMeshSettings.MinimumSize = new System.Drawing.Size(0, 10);
            this.grbGradientMeshSettings.Name = "grbGradientMeshSettings";
            this.grbGradientMeshSettings.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grbGradientMeshSettings.Size = new System.Drawing.Size(450, 250);
            this.grbGradientMeshSettings.TabIndex = 17;
            this.grbGradientMeshSettings.TabStop = false;
            this.grbGradientMeshSettings.Text = "Настройки градиента сетки";
            this.grbGradientMeshSettings.CheckBoxClickEvent += new System.Action<object>(this.grbGradientMeshSettings_CheckBoxClick);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.27966F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.72034F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txbLayerThickness, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txbSurfaceMeshSize, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbCoreMeshSize, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSetGradientSettings, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.txbMeshGradientPower, 1, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(444, 234);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Степень градиента";
            // 
            // txbLayerThickness
            // 
            this.txbLayerThickness.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbLayerThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbLayerThickness.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbLayerThickness.IsValidating = true;
            this.txbLayerThickness.Location = new System.Drawing.Point(216, 14);
            this.txbLayerThickness.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbLayerThickness.Name = "txbLayerThickness";
            this.txbLayerThickness.Size = new System.Drawing.Size(208, 20);
            this.txbLayerThickness.TabIndex = 11;
            this.txbLayerThickness.UserRegExCheck = null;
            this.txbLayerThickness.UserRegExCheckErrorMessage = null;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер элементов в центре";
            // 
            // txbSurfaceMeshSize
            // 
            this.txbSurfaceMeshSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbSurfaceMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSurfaceMeshSize.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbSurfaceMeshSize.IsValidating = true;
            this.txbSurfaceMeshSize.Location = new System.Drawing.Point(216, 59);
            this.txbSurfaceMeshSize.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbSurfaceMeshSize.Name = "txbSurfaceMeshSize";
            this.txbSurfaceMeshSize.Size = new System.Drawing.Size(208, 20);
            this.txbSurfaceMeshSize.TabIndex = 12;
            this.txbSurfaceMeshSize.UserRegExCheck = null;
            this.txbSurfaceMeshSize.UserRegExCheckErrorMessage = null;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Размер элементов на поверхности";
            // 
            // txbCoreMeshSize
            // 
            this.txbCoreMeshSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbCoreMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCoreMeshSize.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbCoreMeshSize.IsValidating = true;
            this.txbCoreMeshSize.Location = new System.Drawing.Point(216, 103);
            this.txbCoreMeshSize.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbCoreMeshSize.Name = "txbCoreMeshSize";
            this.txbCoreMeshSize.Size = new System.Drawing.Size(208, 20);
            this.txbCoreMeshSize.TabIndex = 13;
            this.txbCoreMeshSize.UserRegExCheck = null;
            this.txbCoreMeshSize.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Толщина слоя";
            // 
            // btnSetGradientSettings
            // 
            this.btnSetGradientSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetGradientSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetGradientSettings.Location = new System.Drawing.Point(216, 194);
            this.btnSetGradientSettings.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnSetGradientSettings.Name = "btnSetGradientSettings";
            this.btnSetGradientSettings.Size = new System.Drawing.Size(208, 32);
            this.btnSetGradientSettings.TabIndex = 14;
            this.btnSetGradientSettings.Text = "Задать настройки";
            this.btnSetGradientSettings.UseVisualStyleBackColor = true;
            this.btnSetGradientSettings.Click += new System.EventHandler(this.btnSetGradientSettings_Click);
            // 
            // txbMeshGradientPower
            // 
            this.txbMeshGradientPower.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbMeshGradientPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMeshGradientPower.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbMeshGradientPower.IsValidating = true;
            this.txbMeshGradientPower.Location = new System.Drawing.Point(216, 152);
            this.txbMeshGradientPower.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbMeshGradientPower.Name = "txbMeshGradientPower";
            this.txbMeshGradientPower.Size = new System.Drawing.Size(208, 20);
            this.txbMeshGradientPower.TabIndex = 15;
            this.txbMeshGradientPower.UserRegExCheck = null;
            this.txbMeshGradientPower.UserRegExCheckErrorMessage = null;
            // 
            // entitieSettingsBox
            // 
            this.entitieSettingsBox.CheckState = true;
            this.entitieSettingsBox.Controls.Add(this.gmshCurveSettingsControl1);
            this.entitieSettingsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitieSettingsBox.IsCheckable = false;
            this.entitieSettingsBox.IsExpanded = false;
            this.entitieSettingsBox.IsRollable = false;
            this.entitieSettingsBox.Location = new System.Drawing.Point(7, 7);
            this.entitieSettingsBox.Margin = new System.Windows.Forms.Padding(7);
            this.entitieSettingsBox.MinimumSize = new System.Drawing.Size(0, 10);
            this.entitieSettingsBox.Name = "entitieSettingsBox";
            this.entitieSettingsBox.Size = new System.Drawing.Size(450, 157);
            this.entitieSettingsBox.TabIndex = 18;
            this.entitieSettingsBox.TabStop = false;
            this.entitieSettingsBox.Text = "Настройки разметки кривых";
            // 
            // gmshCurveSettingsControl1
            // 
            this.gmshCurveSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshCurveSettingsControl1.Location = new System.Drawing.Point(3, 16);
            this.gmshCurveSettingsControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gmshCurveSettingsControl1.Name = "gmshCurveSettingsControl1";
            this.gmshCurveSettingsControl1.Size = new System.Drawing.Size(444, 138);
            this.gmshCurveSettingsControl1.TabIndex = 1;
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Controls.Add(this.meshLayout);
            this.meshPage.Location = new System.Drawing.Point(4, 34);
            this.meshPage.Margin = new System.Windows.Forms.Padding(0);
            this.meshPage.Name = "meshPage";
            this.meshPage.Size = new System.Drawing.Size(464, 638);
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
            this.meshLayout.Size = new System.Drawing.Size(464, 638);
            this.meshLayout.TabIndex = 0;
            // 
            // surfsTree
            // 
            this.surfsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfsTree.FullRowSelect = true;
            this.surfsTree.Location = new System.Drawing.Point(7, 187);
            this.surfsTree.Margin = new System.Windows.Forms.Padding(7);
            this.surfsTree.Name = "surfsTree";
            this.surfsTree.Size = new System.Drawing.Size(450, 444);
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
            this.meshGenBox.Size = new System.Drawing.Size(450, 166);
            this.meshGenBox.TabIndex = 3;
            this.meshGenBox.TabStop = false;
            this.meshGenBox.Text = "Управление сеткой";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.40146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.59854F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Controls.Add(this.refineBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.algoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.densityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMesh2DDel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.quadBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.mesh2DGenBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbAlgoChoice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.meshDensityValue, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 150);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // refineBtn
            // 
            this.refineBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refineBtn.Location = new System.Drawing.Point(116, 110);
            this.refineBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.refineBtn.Name = "refineBtn";
            this.refineBtn.Size = new System.Drawing.Size(135, 32);
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
            this.algoLabel.Location = new System.Drawing.Point(15, 8);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(66, 39);
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
            this.densityLabel.Location = new System.Drawing.Point(19, 66);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(58, 26);
            this.densityLabel.TabIndex = 0;
            this.densityLabel.Text = "Фактор масштаба";
            this.densityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMesh2DDel
            // 
            this.btnMesh2DDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMesh2DDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesh2DDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMesh2DDel.Location = new System.Drawing.Point(292, 63);
            this.btnMesh2DDel.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnMesh2DDel.Name = "btnMesh2DDel";
            this.btnMesh2DDel.Size = new System.Drawing.Size(130, 32);
            this.btnMesh2DDel.TabIndex = 9;
            this.btnMesh2DDel.Text = "Удалить";
            this.btnMesh2DDel.UseVisualStyleBackColor = true;
            this.btnMesh2DDel.Click += new System.EventHandler(this.OnDeleteMesh2D);
            // 
            // quadBtn
            // 
            this.quadBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quadBtn.Location = new System.Drawing.Point(292, 110);
            this.quadBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.quadBtn.Name = "quadBtn";
            this.quadBtn.Size = new System.Drawing.Size(130, 32);
            this.quadBtn.TabIndex = 11;
            this.quadBtn.Text = "Квадратная сетка";
            this.quadBtn.UseVisualStyleBackColor = true;
            this.quadBtn.Click += new System.EventHandler(this.OnQuadrangulate);
            // 
            // mesh2DGenBtn
            // 
            this.mesh2DGenBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mesh2DGenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mesh2DGenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mesh2DGenBtn.Location = new System.Drawing.Point(116, 63);
            this.mesh2DGenBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.mesh2DGenBtn.Name = "mesh2DGenBtn";
            this.mesh2DGenBtn.Size = new System.Drawing.Size(135, 32);
            this.mesh2DGenBtn.TabIndex = 5;
            this.mesh2DGenBtn.Text = "Треугольная сетка";
            this.mesh2DGenBtn.UseVisualStyleBackColor = true;
            this.mesh2DGenBtn.Click += new System.EventHandler(this.OnGenerateMesh2D);
            // 
            // cmbAlgoChoice
            // 
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
            this.cmbAlgoChoice.Location = new System.Drawing.Point(116, 20);
            this.cmbAlgoChoice.Margin = new System.Windows.Forms.Padding(20);
            this.cmbAlgoChoice.Name = "cmbAlgoChoice";
            this.cmbAlgoChoice.Size = new System.Drawing.Size(307, 21);
            this.cmbAlgoChoice.TabIndex = 12;
            this.cmbAlgoChoice.UserRegExCheck = null;
            this.cmbAlgoChoice.UserRegExCheckErrorMessage = null;
            this.cmbAlgoChoice.SelectedIndexChanged += new System.EventHandler(this.OnAlgorithmChoice);
            // 
            // meshDensityValue
            // 
            this.meshDensityValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.meshDensityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.meshDensityValue.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.meshDensityValue.IsValidating = true;
            this.meshDensityValue.Location = new System.Drawing.Point(21, 116);
            this.meshDensityValue.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.meshDensityValue.Name = "meshDensityValue";
            this.meshDensityValue.Size = new System.Drawing.Size(53, 20);
            this.meshDensityValue.TabIndex = 13;
            this.meshDensityValue.Text = "1";
            this.meshDensityValue.UserRegExCheck = null;
            this.meshDensityValue.UserRegExCheckErrorMessage = null;
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Controls.Add(this.volumeLayout);
            this.volumePage.Location = new System.Drawing.Point(4, 34);
            this.volumePage.Margin = new System.Windows.Forms.Padding(0);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(464, 638);
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
            this.volumeLayout.Size = new System.Drawing.Size(464, 638);
            this.volumeLayout.TabIndex = 0;
            // 
            // volumesTree
            // 
            this.volumesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumesTree.Location = new System.Drawing.Point(7, 92);
            this.volumesTree.Margin = new System.Windows.Forms.Padding(7);
            this.volumesTree.Name = "volumesTree";
            this.volumesTree.Size = new System.Drawing.Size(450, 539);
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
            this.grbVolControlBox.Size = new System.Drawing.Size(450, 71);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(444, 55);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnGenVolMesh
            // 
            this.btnGenVolMesh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGenVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenVolMesh.Location = new System.Drawing.Point(20, 11);
            this.btnGenVolMesh.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnGenVolMesh.Name = "btnGenVolMesh";
            this.btnGenVolMesh.Size = new System.Drawing.Size(182, 32);
            this.btnGenVolMesh.TabIndex = 5;
            this.btnGenVolMesh.Text = "Сгенерировать";
            this.btnGenVolMesh.UseVisualStyleBackColor = true;
            this.btnGenVolMesh.Click += new System.EventHandler(this.OnGenerateMesh3D);
            // 
            // btnDelVolMesh
            // 
            this.btnDelVolMesh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelVolMesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelVolMesh.Location = new System.Drawing.Point(242, 11);
            this.btnDelVolMesh.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDelVolMesh.Name = "btnDelVolMesh";
            this.btnDelVolMesh.Size = new System.Drawing.Size(182, 32);
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
            this.Size = new System.Drawing.Size(472, 676);
            this.cmsRemoveMesh2D.ResumeLayout(false);
            this.cmsRemoveMesh3D.ResumeLayout(false);
            this.gmshTab.ResumeLayout(false);
            this.geometryPage.ResumeLayout(false);
            this.geometryLayout.ResumeLayout(false);
            this.geometryLayout.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbGradientMeshSettings.ResumeLayout(false);
            this.grbGradientMeshSettings.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.entitieSettingsBox.ResumeLayout(false);
            this.entitieSettingsBox.PerformLayout();
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
        private Panel panel2;
        private CheckBox chbShowNumberOfCurveNodes;
        private CheckBox chbShowSurfaceNumbers;
        private CheckBox chbShowHeatMap;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private TabControlEx gmshTab;
        private CheckBox chbShowNodesOnCurves;
        private TreeView surfsTree;
        private TreeView volumesTree;
        private Label algoLabel;
        private GroupBoxEx grbGradientMeshSettings;
        private Label label1;
        private Label label5;
        private Label label4;
        private TextBoxEx txbLayerThickness;
        private TextBoxEx txbCoreMeshSize;
        private TextBoxEx txbSurfaceMeshSize;
        private ComboBoxEx cmbAlgoChoice;
        private TextBoxEx meshDensityValue;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnSetGradientSettings;
        private TextBoxEx txbMeshGradientPower;
        private Label label6;
        private GroupBoxEx entitieSettingsBox;
        private GMSHCurveSettingsControl gmshCurveSettingsControl1;
    }
}