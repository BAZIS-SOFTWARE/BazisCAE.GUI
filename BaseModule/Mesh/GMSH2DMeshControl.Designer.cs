namespace BazisGUI.Mesh
{
    partial class GMSH2DMeshControl
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
            this.chkQuad = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGenListPoints = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkMetrics = new System.Windows.Forms.CheckBox();
            this.grpFieldSize = new System.Windows.Forms.GroupBox();
            this.txtSizeListPoints = new System.Windows.Forms.TextBox();
            this.txtSizeListNear = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSizeListFar = new System.Windows.Forms.TextBox();
            this.filterBox.SuspendLayout();
            this.boundFilter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpFieldBeta.SuspendLayout();
            this.grpFieldFan.SuspendLayout();
            this.grpFieldLayer.SuspendLayout();
            this.grpFieldGeneral.SuspendLayout();
            this.grpFieldSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.boundFilter);
            this.filterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterBox.Enabled = false;
            this.filterBox.Location = new System.Drawing.Point(0, 0);
            this.filterBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterBox.Name = "filterBox";
            this.filterBox.SelectedIndex = 0;
            this.filterBox.Size = new System.Drawing.Size(553, 609);
            this.filterBox.TabIndex = 7;
            // 
            // boundFilter
            // 
            this.boundFilter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.boundFilter.Controls.Add(this.tableLayoutPanel2);
            this.boundFilter.Location = new System.Drawing.Point(4, 25);
            this.boundFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boundFilter.Name = "boundFilter";
            this.boundFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boundFilter.Size = new System.Drawing.Size(545, 580);
            this.boundFilter.TabIndex = 0;
            this.boundFilter.Text = "Граничный";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grpFieldBeta, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldFan, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldLayer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldGeneral, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grpFieldSize, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 576);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // grpFieldBeta
            // 
            this.grpFieldBeta.AutoSize = true;
            this.grpFieldBeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpFieldBeta.Controls.Add(this.chkMetrics);
            this.grpFieldBeta.Controls.Add(this.txtBetaCoef);
            this.grpFieldBeta.Controls.Add(this.label5);
            this.grpFieldBeta.Controls.Add(this.txtBetaLayers);
            this.grpFieldBeta.Controls.Add(this.label4);
            this.grpFieldBeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldBeta.Enabled = false;
            this.grpFieldBeta.Location = new System.Drawing.Point(3, 462);
            this.grpFieldBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldBeta.Name = "grpFieldBeta";
            this.grpFieldBeta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldBeta.Size = new System.Drawing.Size(533, 112);
            this.grpFieldBeta.TabIndex = 13;
            this.grpFieldBeta.TabStop = false;
            this.grpFieldBeta.Text = "Закон бета";
            // 
            // txtBetaCoef
            // 
            this.txtBetaCoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetaCoef.Location = new System.Drawing.Point(316, 29);
            this.txtBetaCoef.Margin = new System.Windows.Forms.Padding(3, 2, 20, 2);
            this.txtBetaCoef.Name = "txtBetaCoef";
            this.txtBetaCoef.Size = new System.Drawing.Size(125, 22);
            this.txtBetaCoef.TabIndex = 3;
            this.txtBetaCoef.Tag = "Beta 1,01";
            this.txtBetaCoef.Text = "1.01";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(699, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Коэффициент:";
            // 
            // txtBetaLayers
            // 
            this.txtBetaLayers.Location = new System.Drawing.Point(156, 29);
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
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Количество слоев:";
            // 
            // grpFieldFan
            // 
            this.grpFieldFan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpFieldFan.Controls.Add(this.txtFanListSize);
            this.grpFieldFan.Controls.Add(this.label8);
            this.grpFieldFan.Controls.Add(this.txtFanAngle);
            this.grpFieldFan.Controls.Add(this.label6);
            this.grpFieldFan.Controls.Add(this.label7);
            this.grpFieldFan.Controls.Add(this.txtFanListPoints);
            this.grpFieldFan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldFan.Enabled = false;
            this.grpFieldFan.Location = new System.Drawing.Point(3, 347);
            this.grpFieldFan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldFan.Name = "grpFieldFan";
            this.grpFieldFan.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldFan.Size = new System.Drawing.Size(533, 111);
            this.grpFieldFan.TabIndex = 11;
            this.grpFieldFan.TabStop = false;
            this.grpFieldFan.Text = "Настройки скруглений:";
            // 
            // txtFanListSize
            // 
            this.txtFanListSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListSize.Location = new System.Drawing.Point(363, 55);
            this.txtFanListSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFanListSize.Name = "txtFanListSize";
            this.txtFanListSize.Size = new System.Drawing.Size(131, 22);
            this.txtFanListSize.TabIndex = 8;
            this.txtFanListSize.Tag = "FanPointsSizesList";
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
            // txtFanAngle
            // 
            this.txtFanAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanAngle.Location = new System.Drawing.Point(36, 55);
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
            // txtFanListPoints
            // 
            this.txtFanListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanListPoints.Location = new System.Drawing.Point(205, 55);
            this.txtFanListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFanListPoints.Name = "txtFanListPoints";
            this.txtFanListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtFanListPoints.TabIndex = 6;
            this.txtFanListPoints.Tag = "FanPointsList";
            // 
            // grpFieldLayer
            // 
            this.grpFieldLayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpFieldLayer.Controls.Add(this.txtLayerRatio);
            this.grpFieldLayer.Controls.Add(this.txtLayerThickness);
            this.grpFieldLayer.Controls.Add(this.label10);
            this.grpFieldLayer.Controls.Add(this.label9);
            this.grpFieldLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldLayer.Enabled = false;
            this.grpFieldLayer.Location = new System.Drawing.Point(3, 232);
            this.grpFieldLayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldLayer.Name = "grpFieldLayer";
            this.grpFieldLayer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldLayer.Size = new System.Drawing.Size(533, 111);
            this.grpFieldLayer.TabIndex = 10;
            this.grpFieldLayer.TabStop = false;
            this.grpFieldLayer.Text = "Настройки слоев:";
            // 
            // txtLayerRatio
            // 
            this.txtLayerRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerRatio.Location = new System.Drawing.Point(277, 44);
            this.txtLayerRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerRatio.Name = "txtLayerRatio";
            this.txtLayerRatio.Size = new System.Drawing.Size(131, 22);
            this.txtLayerRatio.TabIndex = 10;
            this.txtLayerRatio.Tag = "Ratio 1,1";
            this.txtLayerRatio.Text = "1.1";
            // 
            // txtLayerThickness
            // 
            this.txtLayerThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerThickness.Location = new System.Drawing.Point(19, 44);
            this.txtLayerThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLayerThickness.Name = "txtLayerThickness";
            this.txtLayerThickness.Size = new System.Drawing.Size(131, 22);
            this.txtLayerThickness.TabIndex = 9;
            this.txtLayerThickness.Tag = "Thickness 0,01";
            this.txtLayerThickness.Text = "0.01";
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
            this.label9.Location = new System.Drawing.Point(307, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Соотнош. размеров:";
            // 
            // grpFieldGeneral
            // 
            this.grpFieldGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpFieldGeneral.Controls.Add(this.txtGenListSurfaces);
            this.grpFieldGeneral.Controls.Add(this.txtGenListCurves);
            this.grpFieldGeneral.Controls.Add(this.chkQuad);
            this.grpFieldGeneral.Controls.Add(this.label12);
            this.grpFieldGeneral.Controls.Add(this.label11);
            this.grpFieldGeneral.Controls.Add(this.txtGenListPoints);
            this.grpFieldGeneral.Controls.Add(this.label13);
            this.grpFieldGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldGeneral.Enabled = false;
            this.grpFieldGeneral.Location = new System.Drawing.Point(3, 2);
            this.grpFieldGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldGeneral.Name = "grpFieldGeneral";
            this.grpFieldGeneral.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldGeneral.Size = new System.Drawing.Size(533, 111);
            this.grpFieldGeneral.TabIndex = 9;
            this.grpFieldGeneral.TabStop = false;
            this.grpFieldGeneral.Text = "Общие настройки:";
            // 
            // txtGenListSurfaces
            // 
            this.txtGenListSurfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListSurfaces.Location = new System.Drawing.Point(316, 43);
            this.txtGenListSurfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListSurfaces.Name = "txtGenListSurfaces";
            this.txtGenListSurfaces.Size = new System.Drawing.Size(131, 22);
            this.txtGenListSurfaces.TabIndex = 8;
            this.txtGenListSurfaces.Tag = "ExcludedSurfacesList";
            // 
            // txtGenListCurves
            // 
            this.txtGenListCurves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListCurves.Location = new System.Drawing.Point(166, 43);
            this.txtGenListCurves.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListCurves.Name = "txtGenListCurves";
            this.txtGenListCurves.Size = new System.Drawing.Size(131, 22);
            this.txtGenListCurves.TabIndex = 6;
            this.txtGenListCurves.Tag = "CurvesList";
            // 
            // chkQuad
            // 
            this.chkQuad.AutoSize = true;
            this.chkQuad.Enabled = false;
            this.chkQuad.Location = new System.Drawing.Point(162, 3);
            this.chkQuad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkQuad.Name = "chkQuad";
            this.chkQuad.Size = new System.Drawing.Size(165, 20);
            this.chkQuad.TabIndex = 2;
            this.chkQuad.Tag = "Quads";
            this.chkQuad.Text = "Генерировать квады";
            this.chkQuad.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(173, 25);
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
            // txtGenListPoints
            // 
            this.txtGenListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenListPoints.Location = new System.Drawing.Point(20, 43);
            this.txtGenListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenListPoints.Name = "txtGenListPoints";
            this.txtGenListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtGenListPoints.TabIndex = 4;
            this.txtGenListPoints.Tag = "PointsList";
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
            // chkMetrics
            // 
            this.chkMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMetrics.AutoSize = true;
            this.chkMetrics.Enabled = false;
            this.chkMetrics.Location = new System.Drawing.Point(9, 55);
            this.chkMetrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMetrics.Name = "chkMetrics";
            this.chkMetrics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMetrics.Size = new System.Drawing.Size(193, 20);
            this.chkMetrics.TabIndex = 1;
            this.chkMetrics.Tag = "IntersectMetrics";
            this.chkMetrics.Text = "Пересеч метрик поверхн";
            this.chkMetrics.UseVisualStyleBackColor = true;
            // 
            // grpFieldSize
            // 
            this.grpFieldSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpFieldSize.Controls.Add(this.txtSizeListPoints);
            this.grpFieldSize.Controls.Add(this.txtSizeListNear);
            this.grpFieldSize.Controls.Add(this.label16);
            this.grpFieldSize.Controls.Add(this.label14);
            this.grpFieldSize.Controls.Add(this.label15);
            this.grpFieldSize.Controls.Add(this.txtSizeListFar);
            this.grpFieldSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFieldSize.Enabled = false;
            this.grpFieldSize.Location = new System.Drawing.Point(3, 117);
            this.grpFieldSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldSize.Name = "grpFieldSize";
            this.grpFieldSize.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFieldSize.Size = new System.Drawing.Size(533, 111);
            this.grpFieldSize.TabIndex = 8;
            this.grpFieldSize.TabStop = false;
            this.grpFieldSize.Text = "Настройки размеров:";
            // 
            // txtSizeListPoints
            // 
            this.txtSizeListPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListPoints.Location = new System.Drawing.Point(316, 55);
            this.txtSizeListPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListPoints.Name = "txtSizeListPoints";
            this.txtSizeListPoints.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListPoints.TabIndex = 13;
            this.txtSizeListPoints.Tag = "SizesList";
            // 
            // txtSizeListNear
            // 
            this.txtSizeListNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListNear.Location = new System.Drawing.Point(20, 55);
            this.txtSizeListNear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListNear.Name = "txtSizeListNear";
            this.txtSizeListNear.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListNear.TabIndex = 9;
            this.txtSizeListNear.Tag = "Size 0,1";
            this.txtSizeListNear.Text = "0.1";
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
            this.label15.Location = new System.Drawing.Point(163, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "Вдали от кривых:";
            // 
            // txtSizeListFar
            // 
            this.txtSizeListFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeListFar.Location = new System.Drawing.Point(162, 55);
            this.txtSizeListFar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSizeListFar.Name = "txtSizeListFar";
            this.txtSizeListFar.Size = new System.Drawing.Size(131, 22);
            this.txtSizeListFar.TabIndex = 10;
            this.txtSizeListFar.Tag = "SizeFar 1,0";
            this.txtSizeListFar.Text = "1.0";
            // 
            // GMSH2DMeshControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filterBox);
            this.Name = "GMSH2DMeshControl";
            this.Size = new System.Drawing.Size(553, 609);
            this.filterBox.ResumeLayout(false);
            this.boundFilter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.grpFieldBeta.ResumeLayout(false);
            this.grpFieldBeta.PerformLayout();
            this.grpFieldFan.ResumeLayout(false);
            this.grpFieldFan.PerformLayout();
            this.grpFieldLayer.ResumeLayout(false);
            this.grpFieldLayer.PerformLayout();
            this.grpFieldGeneral.ResumeLayout(false);
            this.grpFieldGeneral.PerformLayout();
            this.grpFieldSize.ResumeLayout(false);
            this.grpFieldSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.CheckBox chkQuad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGenListPoints;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkMetrics;
        private System.Windows.Forms.GroupBox grpFieldSize;
        private System.Windows.Forms.TextBox txtSizeListPoints;
        private System.Windows.Forms.TextBox txtSizeListNear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSizeListFar;
    }
}
