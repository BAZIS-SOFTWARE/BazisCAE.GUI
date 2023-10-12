namespace ModelModule
{
    partial class UserControl1
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
            this.gmshTab = new System.Windows.Forms.TabControl();
            this.geometryPage = new System.Windows.Forms.TabPage();
            this.meshPage = new System.Windows.Forms.TabPage();
            this.volumePage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.geoElBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.entTree = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.geoLoadBtn = new System.Windows.Forms.Button();
            this.geoDelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFieldInit = new System.Windows.Forms.Panel();
            this.btnFieldDelete = new System.Windows.Forms.Button();
            this.btnFieldAdd = new System.Windows.Forms.Button();
            this.chkQuad = new System.Windows.Forms.CheckBox();
            this.chkMetrics = new System.Windows.Forms.CheckBox();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            this.grpFieldGeneral = new System.Windows.Forms.GroupBox();
            this.txtGenListSurfaces = new System.Windows.Forms.TextBox();
            this.txtGenListCurves = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGenListPoints = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpFieldSize = new System.Windows.Forms.GroupBox();
            this.txtSizeListPoints = new System.Windows.Forms.TextBox();
            this.txtSizeListNear = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSizeListFar = new System.Windows.Forms.TextBox();
            this.grpFieldLayer = new System.Windows.Forms.GroupBox();
            this.txtLayerRatio = new System.Windows.Forms.TextBox();
            this.txtLayerThickness = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpFieldFan = new System.Windows.Forms.GroupBox();
            this.txtFanListSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFanAngle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFanListPoints = new System.Windows.Forms.TextBox();
            this.grpFieldBeta = new System.Windows.Forms.GroupBox();
            this.txtBetaCoef = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBetaLayers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gmshTab.SuspendLayout();
            this.geometryPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.geoElBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlFieldInit.SuspendLayout();
            this.grpFieldGeneral.SuspendLayout();
            this.grpFieldSize.SuspendLayout();
            this.grpFieldLayer.SuspendLayout();
            this.grpFieldFan.SuspendLayout();
            this.grpFieldBeta.SuspendLayout();
            this.SuspendLayout();
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
            this.gmshTab.Size = new System.Drawing.Size(500, 930);
            this.gmshTab.TabIndex = 2;
            // 
            // geometryPage
            // 
            this.geometryPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.geometryPage.Controls.Add(this.tableLayoutPanel1);
            this.geometryPage.Location = new System.Drawing.Point(4, 25);
            this.geometryPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geometryPage.Name = "geometryPage";
            this.geometryPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.geometryPage.Size = new System.Drawing.Size(492, 901);
            this.geometryPage.TabIndex = 0;
            this.geometryPage.Text = "CAD";
            // 
            // meshPage
            // 
            this.meshPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.meshPage.Location = new System.Drawing.Point(4, 25);
            this.meshPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshPage.Name = "meshPage";
            this.meshPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meshPage.Size = new System.Drawing.Size(492, 901);
            this.meshPage.TabIndex = 1;
            this.meshPage.Text = "2D";
            // 
            // volumePage
            // 
            this.volumePage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumePage.Location = new System.Drawing.Point(4, 25);
            this.volumePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumePage.Name = "volumePage";
            this.volumePage.Size = new System.Drawing.Size(442, 871);
            this.volumePage.TabIndex = 2;
            this.volumePage.Text = "3D";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.geoElBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 537F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 897);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // geoElBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.geoElBox, 3);
            this.geoElBox.Controls.Add(this.tableLayoutPanel2);
            this.geoElBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoElBox.Location = new System.Drawing.Point(3, 56);
            this.geoElBox.Name = "geoElBox";
            this.geoElBox.Size = new System.Drawing.Size(480, 301);
            this.geoElBox.TabIndex = 3;
            this.geoElBox.TabStop = false;
            this.geoElBox.Text = "Элементы геометрии:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.49398F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.50602F));
            this.tableLayoutPanel2.Controls.Add(this.button6, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.entTree, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.21053F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 280);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Location = new System.Drawing.Point(298, 241);
            this.button6.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 32);
            this.button6.TabIndex = 3;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // entTree
            // 
            this.entTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entTree.HideSelection = false;
            this.entTree.Location = new System.Drawing.Point(3, 2);
            this.entTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entTree.Name = "entTree";
            this.tableLayoutPanel2.SetRowSpan(this.entTree, 2);
            this.entTree.Size = new System.Drawing.Size(247, 276);
            this.entTree.TabIndex = 8;
            this.entTree.Tag = "entTree";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 363);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 531);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Граничный";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.geoDelBtn);
            this.panel1.Controls.Add(this.geoLoadBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 53);
            this.panel1.TabIndex = 5;
            // 
            // geoLoadBtn
            // 
            this.geoLoadBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.geoLoadBtn.Location = new System.Drawing.Point(10, 11);
            this.geoLoadBtn.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.geoLoadBtn.Name = "geoLoadBtn";
            this.geoLoadBtn.Size = new System.Drawing.Size(120, 32);
            this.geoLoadBtn.TabIndex = 1;
            this.geoLoadBtn.Text = "Загрузить";
            this.geoLoadBtn.UseVisualStyleBackColor = true;
            // 
            // geoDelBtn
            // 
            this.geoDelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.geoDelBtn.Location = new System.Drawing.Point(353, 11);
            this.geoDelBtn.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.geoDelBtn.Name = "geoDelBtn";
            this.geoDelBtn.Size = new System.Drawing.Size(120, 32);
            this.geoDelBtn.TabIndex = 2;
            this.geoDelBtn.Text = "Удалить";
            this.geoDelBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.Controls.Add(this.grpFieldBeta, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.pnlFieldInit, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.grpFieldGeneral, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.grpFieldSize, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.grpFieldLayer, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.grpFieldFan, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(466, 496);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // pnlFieldInit
            // 
            this.pnlFieldInit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel3.SetColumnSpan(this.pnlFieldInit, 3);
            this.pnlFieldInit.Controls.Add(this.btnFieldDelete);
            this.pnlFieldInit.Controls.Add(this.btnFieldAdd);
            this.pnlFieldInit.Controls.Add(this.chkQuad);
            this.pnlFieldInit.Controls.Add(this.chkMetrics);
            this.pnlFieldInit.Controls.Add(this.chkBeta);
            this.pnlFieldInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldInit.Location = new System.Drawing.Point(0, 0);
            this.pnlFieldInit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFieldInit.Name = "pnlFieldInit";
            this.pnlFieldInit.Size = new System.Drawing.Size(466, 75);
            this.pnlFieldInit.TabIndex = 4;
            // 
            // btnFieldDelete
            // 
            this.btnFieldDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldDelete.Enabled = false;
            this.btnFieldDelete.Location = new System.Drawing.Point(194, 33);
            this.btnFieldDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFieldDelete.Name = "btnFieldDelete";
            this.btnFieldDelete.Size = new System.Drawing.Size(120, 32);
            this.btnFieldDelete.TabIndex = 4;
            this.btnFieldDelete.Text = "Удалить";
            this.btnFieldDelete.UseVisualStyleBackColor = true;
            // 
            // btnFieldAdd
            // 
            this.btnFieldAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldAdd.Location = new System.Drawing.Point(331, 33);
            this.btnFieldAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFieldAdd.Name = "btnFieldAdd";
            this.btnFieldAdd.Size = new System.Drawing.Size(120, 32);
            this.btnFieldAdd.TabIndex = 3;
            this.btnFieldAdd.Text = "Добавить";
            this.btnFieldAdd.UseVisualStyleBackColor = true;
            // 
            // chkQuad
            // 
            this.chkQuad.AutoSize = true;
            this.chkQuad.Enabled = false;
            this.chkQuad.Location = new System.Drawing.Point(15, 37);
            this.chkQuad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkQuad.Name = "chkQuad";
            this.chkQuad.Size = new System.Drawing.Size(165, 20);
            this.chkQuad.TabIndex = 2;
            this.chkQuad.Tag = "Quads";
            this.chkQuad.Text = "Генерировать квады";
            this.chkQuad.UseVisualStyleBackColor = true;
            // 
            // chkMetrics
            // 
            this.chkMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMetrics.AutoSize = true;
            this.chkMetrics.Enabled = false;
            this.chkMetrics.Location = new System.Drawing.Point(261, 7);
            this.chkMetrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMetrics.Name = "chkMetrics";
            this.chkMetrics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMetrics.Size = new System.Drawing.Size(193, 20);
            this.chkMetrics.TabIndex = 1;
            this.chkMetrics.Tag = "IntersectMetrics";
            this.chkMetrics.Text = "Пересеч метрик поверхн";
            this.chkMetrics.UseVisualStyleBackColor = true;
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Enabled = false;
            this.chkBeta.Location = new System.Drawing.Point(15, 7);
            this.chkBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(103, 20);
            this.chkBeta.TabIndex = 0;
            this.chkBeta.Tag = "BetaLaw";
            this.chkBeta.Text = "Закон бета";
            this.chkBeta.UseVisualStyleBackColor = true;
            // 
            // grpFieldGeneral
            // 
            this.grpFieldGeneral.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel3.SetColumnSpan(this.grpFieldGeneral, 3);
            this.grpFieldGeneral.Controls.Add(this.txtGenListSurfaces);
            this.grpFieldGeneral.Controls.Add(this.txtGenListCurves);
            this.grpFieldGeneral.Controls.Add(this.label12);
            this.grpFieldGeneral.Controls.Add(this.label11);
            this.grpFieldGeneral.Controls.Add(this.txtGenListPoints);
            this.grpFieldGeneral.Controls.Add(this.label13);
            this.grpFieldGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldGeneral.Enabled = false;
            this.grpFieldGeneral.Location = new System.Drawing.Point(3, 78);
            this.grpFieldGeneral.Name = "grpFieldGeneral";
            this.grpFieldGeneral.Padding = new System.Windows.Forms.Padding(0);
            this.grpFieldGeneral.Size = new System.Drawing.Size(460, 81);
            this.grpFieldGeneral.TabIndex = 10;
            this.grpFieldGeneral.TabStop = false;
            this.grpFieldGeneral.Text = "Общие настройки:";
            // 
            // txtGenListSurfaces
            // 
            this.txtGenListSurfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListSurfaces.Location = new System.Drawing.Point(320, 45);
            this.txtGenListSurfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListSurfaces.Name = "txtGenListSurfaces";
            this.txtGenListSurfaces.Size = new System.Drawing.Size(131, 22);
            this.txtGenListSurfaces.TabIndex = 8;
            this.txtGenListSurfaces.Tag = "ExcludedSurfacesList";
            // 
            // txtGenListCurves
            // 
            this.txtGenListCurves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListCurves.Location = new System.Drawing.Point(168, 45);
            this.txtGenListCurves.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListCurves.Name = "txtGenListCurves";
            this.txtGenListCurves.Size = new System.Drawing.Size(131, 22);
            this.txtGenListCurves.TabIndex = 6;
            this.txtGenListCurves.Tag = "CurvesList";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Список кривых:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Список искл. поверхн:";
            // 
            // txtGenListPoints
            // 
            this.txtGenListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListPoints.Location = new System.Drawing.Point(21, 45);
            this.txtGenListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListPoints.Name = "txtGenListPoints";
            this.txtGenListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtGenListPoints.TabIndex = 4;
            this.txtGenListPoints.Tag = "PointsList";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Список точек:";
            // 
            // grpFieldSize
            // 
            this.grpFieldSize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpFieldSize.Controls.Add(this.txtSizeListPoints);
            this.grpFieldSize.Controls.Add(this.txtSizeListNear);
            this.grpFieldSize.Controls.Add(this.label16);
            this.grpFieldSize.Controls.Add(this.label14);
            this.grpFieldSize.Controls.Add(this.label15);
            this.grpFieldSize.Controls.Add(this.txtSizeListFar);
            this.grpFieldSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldSize.Enabled = false;
            this.grpFieldSize.Location = new System.Drawing.Point(3, 165);
            this.grpFieldSize.Name = "grpFieldSize";
            this.grpFieldSize.Padding = new System.Windows.Forms.Padding(0);
            this.grpFieldSize.Size = new System.Drawing.Size(460, 80);
            this.grpFieldSize.TabIndex = 11;
            this.grpFieldSize.TabStop = false;
            this.grpFieldSize.Text = "Настройки размеров:";
            // 
            // txtSizeListPoints
            // 
            this.txtSizeListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListPoints.Location = new System.Drawing.Point(320, 42);
            this.txtSizeListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListPoints.Name = "txtSizeListPoints";
            this.txtSizeListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListPoints.TabIndex = 13;
            this.txtSizeListPoints.Tag = "SizesList";
            // 
            // txtSizeListNear
            // 
            this.txtSizeListNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListNear.Location = new System.Drawing.Point(21, 42);
            this.txtSizeListNear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListNear.Name = "txtSizeListNear";
            this.txtSizeListNear.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListNear.TabIndex = 9;
            this.txtSizeListNear.Tag = "Size 0,1";
            this.txtSizeListNear.Text = "0,1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 16);
            this.label16.TabIndex = 9;
            this.label16.Text = "Возле кривых:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(316, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Список по точкам:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(159, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "Вдали от кривых:";
            // 
            // txtSizeListFar
            // 
            this.txtSizeListFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListFar.Location = new System.Drawing.Point(168, 42);
            this.txtSizeListFar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListFar.Name = "txtSizeListFar";
            this.txtSizeListFar.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListFar.TabIndex = 10;
            this.txtSizeListFar.Tag = "SizeFar 1,0";
            this.txtSizeListFar.Text = "1.0";
            // 
            // grpFieldLayer
            // 
            this.grpFieldLayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpFieldLayer.Controls.Add(this.txtLayerRatio);
            this.grpFieldLayer.Controls.Add(this.txtLayerThickness);
            this.grpFieldLayer.Controls.Add(this.label10);
            this.grpFieldLayer.Controls.Add(this.label9);
            this.grpFieldLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldLayer.Enabled = false;
            this.grpFieldLayer.Location = new System.Drawing.Point(3, 251);
            this.grpFieldLayer.Name = "grpFieldLayer";
            this.grpFieldLayer.Padding = new System.Windows.Forms.Padding(0);
            this.grpFieldLayer.Size = new System.Drawing.Size(460, 72);
            this.grpFieldLayer.TabIndex = 12;
            this.grpFieldLayer.TabStop = false;
            this.grpFieldLayer.Text = "Настройки слоев:";
            // 
            // txtLayerRatio
            // 
            this.txtLayerRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerRatio.Location = new System.Drawing.Point(320, 42);
            this.txtLayerRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerRatio.Name = "txtLayerRatio";
            this.txtLayerRatio.Size = new System.Drawing.Size(131, 22);
            this.txtLayerRatio.TabIndex = 10;
            this.txtLayerRatio.Tag = "Ratio 1,1";
            this.txtLayerRatio.Text = "1,1";
            // 
            // txtLayerThickness
            // 
            this.txtLayerThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerThickness.Location = new System.Drawing.Point(21, 42);
            this.txtLayerThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerThickness.Name = "txtLayerThickness";
            this.txtLayerThickness.Size = new System.Drawing.Size(131, 22);
            this.txtLayerThickness.TabIndex = 9;
            this.txtLayerThickness.Tag = "Thickness 0,01";
            this.txtLayerThickness.Text = "0,01";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Толщина слоя макс:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Соотнош. размеров:";
            // 
            // grpFieldFan
            // 
            this.grpFieldFan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpFieldFan.Controls.Add(this.txtFanListSize);
            this.grpFieldFan.Controls.Add(this.label8);
            this.grpFieldFan.Controls.Add(this.txtFanAngle);
            this.grpFieldFan.Controls.Add(this.label6);
            this.grpFieldFan.Controls.Add(this.label7);
            this.grpFieldFan.Controls.Add(this.txtFanListPoints);
            this.grpFieldFan.Enabled = false;
            this.grpFieldFan.Location = new System.Drawing.Point(3, 329);
            this.grpFieldFan.Name = "grpFieldFan";
            this.grpFieldFan.Padding = new System.Windows.Forms.Padding(0);
            this.grpFieldFan.Size = new System.Drawing.Size(460, 88);
            this.grpFieldFan.TabIndex = 13;
            this.grpFieldFan.TabStop = false;
            this.grpFieldFan.Text = "Настройки скруглений:";
            // 
            // txtFanListSize
            // 
            this.txtFanListSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListSize.Location = new System.Drawing.Point(320, 52);
            this.txtFanListSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFanListSize.Name = "txtFanListSize";
            this.txtFanListSize.Size = new System.Drawing.Size(131, 22);
            this.txtFanListSize.TabIndex = 8;
            this.txtFanListSize.Tag = "FanPointsSizesList";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Пороговый угол:";
            // 
            // txtFanAngle
            // 
            this.txtFanAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanAngle.Location = new System.Drawing.Point(21, 52);
            this.txtFanAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFanAngle.Name = "txtFanAngle";
            this.txtFanAngle.Size = new System.Drawing.Size(131, 22);
            this.txtFanAngle.TabIndex = 4;
            this.txtFanAngle.Tag = "AnisoMax 10000000000";
            this.txtFanAngle.Text = "10000000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Элем. на точку:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Список точек:";
            // 
            // txtFanListPoints
            // 
            this.txtFanListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListPoints.Location = new System.Drawing.Point(168, 52);
            this.txtFanListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFanListPoints.Name = "txtFanListPoints";
            this.txtFanListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtFanListPoints.TabIndex = 6;
            this.txtFanListPoints.Tag = "FanPointsList";
            // 
            // grpFieldBeta
            // 
            this.grpFieldBeta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpFieldBeta.Controls.Add(this.txtBetaCoef);
            this.grpFieldBeta.Controls.Add(this.label5);
            this.grpFieldBeta.Controls.Add(this.txtBetaLayers);
            this.grpFieldBeta.Controls.Add(this.label4);
            this.grpFieldBeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldBeta.Enabled = false;
            this.grpFieldBeta.Location = new System.Drawing.Point(3, 422);
            this.grpFieldBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldBeta.Name = "grpFieldBeta";
            this.grpFieldBeta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldBeta.Size = new System.Drawing.Size(460, 72);
            this.grpFieldBeta.TabIndex = 14;
            this.grpFieldBeta.TabStop = false;
            this.grpFieldBeta.Text = "Закон бета";
            // 
            // txtBetaCoef
            // 
            this.txtBetaCoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetaCoef.Location = new System.Drawing.Point(317, 42);
            this.txtBetaCoef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBetaCoef.Name = "txtBetaCoef";
            this.txtBetaCoef.Size = new System.Drawing.Size(131, 22);
            this.txtBetaCoef.TabIndex = 3;
            this.txtBetaCoef.Tag = "Beta 1,01";
            this.txtBetaCoef.Text = "1,01";
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
            // txtBetaLayers
            // 
            this.txtBetaLayers.Location = new System.Drawing.Point(11, 42);
            this.txtBetaLayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBetaLayers.Name = "txtBetaLayers";
            this.txtBetaLayers.Size = new System.Drawing.Size(131, 22);
            this.txtBetaLayers.TabIndex = 1;
            this.txtBetaLayers.Tag = "NbLayers 10";
            this.txtBetaLayers.Text = "10";
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
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshTab);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(500, 930);
            this.gmshTab.ResumeLayout(false);
            this.geometryPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.geoElBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlFieldInit.ResumeLayout(false);
            this.pnlFieldInit.PerformLayout();
            this.grpFieldGeneral.ResumeLayout(false);
            this.grpFieldGeneral.PerformLayout();
            this.grpFieldSize.ResumeLayout(false);
            this.grpFieldSize.PerformLayout();
            this.grpFieldLayer.ResumeLayout(false);
            this.grpFieldLayer.PerformLayout();
            this.grpFieldFan.ResumeLayout(false);
            this.grpFieldFan.PerformLayout();
            this.grpFieldBeta.ResumeLayout(false);
            this.grpFieldBeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl gmshTab;
        private System.Windows.Forms.TabPage geometryPage;
        private System.Windows.Forms.TabPage meshPage;
        private System.Windows.Forms.TabPage volumePage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox geoElBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TreeView entTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button geoDelBtn;
        private System.Windows.Forms.Button geoLoadBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlFieldInit;
        private System.Windows.Forms.Button btnFieldDelete;
        private System.Windows.Forms.Button btnFieldAdd;
        private System.Windows.Forms.CheckBox chkQuad;
        private System.Windows.Forms.CheckBox chkMetrics;
        private System.Windows.Forms.CheckBox chkBeta;
        private System.Windows.Forms.GroupBox grpFieldGeneral;
        private System.Windows.Forms.TextBox txtGenListSurfaces;
        private System.Windows.Forms.TextBox txtGenListCurves;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGenListPoints;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpFieldSize;
        private System.Windows.Forms.TextBox txtSizeListPoints;
        private System.Windows.Forms.TextBox txtSizeListNear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSizeListFar;
        private System.Windows.Forms.GroupBox grpFieldLayer;
        private System.Windows.Forms.TextBox txtLayerRatio;
        private System.Windows.Forms.TextBox txtLayerThickness;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpFieldFan;
        private System.Windows.Forms.TextBox txtFanListSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFanAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFanListPoints;
        private System.Windows.Forms.GroupBox grpFieldBeta;
        private System.Windows.Forms.TextBox txtBetaCoef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBetaLayers;
        private System.Windows.Forms.Label label4;
    }
}
