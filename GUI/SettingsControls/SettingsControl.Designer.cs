using UserControlsEx;

namespace BazisGUI.SettingsControls
{
    partial class SettingsControl
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
            this.lblSolverPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbLighting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbBackRibbers = new System.Windows.Forms.CheckBox();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.panelBackGroundColor = new System.Windows.Forms.Panel();
            this.clslLigthingIntensity = new UserControlsEx.ColorSlider();
            this.label2 = new System.Windows.Forms.Label();
            this.clslTransparency = new UserControlsEx.ColorSlider();
            this.chbTransparency = new System.Windows.Forms.CheckBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.tabControlEx1 = new UserControlsEx.TabControlEx();
            this.tbScene = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbObjects = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectNodeColor = new System.Windows.Forms.Button();
            this.btnSelect2DElemColor = new System.Windows.Forms.Button();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.btnSelectGroupColor = new System.Windows.Forms.Button();
            this.pnlSelectionObjsColor = new System.Windows.Forms.Panel();
            this.pnlSelectionGroupColor = new System.Windows.Forms.Panel();
            this.btnSelect3DElemColor = new System.Windows.Forms.Button();
            this.pnl3DElemColor = new System.Windows.Forms.Panel();
            this.pnl2DElemColor = new System.Windows.Forms.Panel();
            this.pnlNodeColor = new System.Windows.Forms.Panel();
            this.tbSolver = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lightingControl = new BazisGUI.SettingsControls.LightingControl();
            this.tabControlEx1.SuspendLayout();
            this.tbScene.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbObjects.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tbSolver.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSolverPath
            // 
            this.lblSolverPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSolverPath.AutoSize = true;
            this.lblSolverPath.Location = new System.Drawing.Point(230, 307);
            this.lblSolverPath.Name = "lblSolverPath";
            this.lblSolverPath.Size = new System.Drawing.Size(13, 13);
            this.lblSolverPath.TabIndex = 20;
            this.lblSolverPath.Text = "?";
            this.lblSolverPath.Click += new System.EventHandler(this.btnSetSolverPath_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Прозрачность";
            // 
            // chbLighting
            // 
            this.chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbLighting.AutoSize = true;
            this.chbLighting.Location = new System.Drawing.Point(245, 145);
            this.chbLighting.Name = "chbLighting";
            this.chbLighting.Size = new System.Drawing.Size(75, 17);
            this.chbLighting.TabIndex = 8;
            this.chbLighting.Text = "Включить";
            this.chbLighting.UseVisualStyleBackColor = true;
            this.chbLighting.Click += new System.EventHandler(this.chbLighting_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Внутренние ребра элементов";
            // 
            // chbBackRibbers
            // 
            this.chbBackRibbers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbBackRibbers.AutoSize = true;
            this.chbBackRibbers.Location = new System.Drawing.Point(245, 106);
            this.chbBackRibbers.Name = "chbBackRibbers";
            this.chbBackRibbers.Size = new System.Drawing.Size(75, 17);
            this.chbBackRibbers.TabIndex = 5;
            this.chbBackRibbers.Text = "Включить";
            this.chbBackRibbers.UseVisualStyleBackColor = true;
            this.chbBackRibbers.Click += new System.EventHandler(this.chbBackRibbers_Click);
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackGroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackGroundColor.Location = new System.Drawing.Point(7, 34);
            this.btnBackGroundColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackGroundColor.Size = new System.Drawing.Size(214, 27);
            this.btnBackGroundColor.TabIndex = 2;
            this.btnBackGroundColor.Text = "выбрать цвет заднего фона";
            this.btnBackGroundColor.UseVisualStyleBackColor = true;
            this.btnBackGroundColor.Click += new System.EventHandler(this.btnBackGroundColor_Click);
            // 
            // panelBackGroundColor
            // 
            this.panelBackGroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBackGroundColor.BackColor = System.Drawing.Color.White;
            this.panelBackGroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackGroundColor.Location = new System.Drawing.Point(235, 34);
            this.panelBackGroundColor.Margin = new System.Windows.Forms.Padding(7);
            this.panelBackGroundColor.Name = "panelBackGroundColor";
            this.panelBackGroundColor.Size = new System.Drawing.Size(96, 27);
            this.panelBackGroundColor.TabIndex = 4;
            // 
            // clslLigthingIntensity
            // 
            this.clslLigthingIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clslLigthingIntensity.BackColor = System.Drawing.Color.Transparent;
            this.clslLigthingIntensity.BarPenColor = System.Drawing.Color.Black;
            this.clslLigthingIntensity.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.clslLigthingIntensity, 2);
            this.clslLigthingIntensity.LargeChange = ((uint)(5u));
            this.clslLigthingIntensity.Location = new System.Drawing.Point(3, 519);
            this.clslLigthingIntensity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clslLigthingIntensity.Name = "clslLigthingIntensity";
            this.clslLigthingIntensity.Size = new System.Drawing.Size(332, 23);
            this.clslLigthingIntensity.SmallChange = ((uint)(1u));
            this.clslLigthingIntensity.TabIndex = 12;
            this.clslLigthingIntensity.Text = "colorSlider";
            this.clslLigthingIntensity.ThumbPenColor = System.Drawing.Color.Black;
            this.clslLigthingIntensity.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.clslLigthingIntensity.ThumbSize = 12;
            this.clslLigthingIntensity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.clslLigthingIntensity_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Освещение";
            // 
            // clslTransparency
            // 
            this.clslTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clslTransparency.BackColor = System.Drawing.Color.Transparent;
            this.clslTransparency.BarPenColor = System.Drawing.Color.Black;
            this.clslTransparency.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.clslTransparency, 2);
            this.clslTransparency.LargeChange = ((uint)(50u));
            this.clslTransparency.Location = new System.Drawing.Point(3, 596);
            this.clslTransparency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clslTransparency.Maximum = 99;
            this.clslTransparency.Name = "clslTransparency";
            this.clslTransparency.Size = new System.Drawing.Size(332, 25);
            this.clslTransparency.SmallChange = ((uint)(1u));
            this.clslTransparency.TabIndex = 14;
            this.clslTransparency.Text = "colorSlider1";
            this.clslTransparency.ThumbPenColor = System.Drawing.Color.Black;
            this.clslTransparency.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.clslTransparency.ThumbSize = 12;
            this.clslTransparency.Scroll += new System.Windows.Forms.ScrollEventHandler(this.clslTransparency_Scroll);
            // 
            // chbTransparency
            // 
            this.chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbTransparency.AutoSize = true;
            this.chbTransparency.Location = new System.Drawing.Point(245, 561);
            this.chbTransparency.Name = "chbTransparency";
            this.chbTransparency.Size = new System.Drawing.Size(75, 17);
            this.chbTransparency.TabIndex = 18;
            this.chbTransparency.Text = "Включить";
            this.chbTransparency.UseVisualStyleBackColor = true;
            this.chbTransparency.Click += new System.EventHandler(this.chbTransparency_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Location = new System.Drawing.Point(209, 687);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(7);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(136, 27);
            this.btnSaveConfig.TabIndex = 22;
            this.btnSaveConfig.Text = "Сохранить";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // tabControlEx1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.tabControlEx1, 2);
            this.tabControlEx1.Controls.Add(this.tbScene);
            this.tabControlEx1.Controls.Add(this.tbObjects);
            this.tabControlEx1.Controls.Add(this.tbSolver);
            this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEx1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlEx1.FontColor = System.Drawing.Color.Black;
            this.tabControlEx1.ItemSize = new System.Drawing.Size(43, 30);
            this.tabControlEx1.Location = new System.Drawing.Point(3, 3);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectColor = System.Drawing.SystemColors.Control;
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(346, 666);
            this.tabControlEx1.TabIndex = 3;
            this.tabControlEx1.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // tbScene
            // 
            this.tbScene.Controls.Add(this.tableLayoutPanel1);
            this.tbScene.Location = new System.Drawing.Point(4, 34);
            this.tbScene.Margin = new System.Windows.Forms.Padding(0);
            this.tbScene.Name = "tbScene";
            this.tbScene.Size = new System.Drawing.Size(338, 628);
            this.tbScene.TabIndex = 0;
            this.tbScene.Text = "Сцена";
            this.tbScene.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chbTransparency, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lightingControl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chbLighting, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnBackGroundColor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelBackGroundColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbBackRibbers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clslLigthingIntensity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.clslTransparency, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbObjects
            // 
            this.tbObjects.Controls.Add(this.tableLayoutPanel4);
            this.tbObjects.Location = new System.Drawing.Point(4, 34);
            this.tbObjects.Margin = new System.Windows.Forms.Padding(0);
            this.tbObjects.Name = "tbObjects";
            this.tbObjects.Size = new System.Drawing.Size(215, 396);
            this.tbObjects.TabIndex = 1;
            this.tbObjects.Text = "Объекты";
            this.tbObjects.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.Controls.Add(this.btnSelectNodeColor, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.btnSelect2DElemColor, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnSelectColor, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSelectGroupColor, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.pnlSelectionObjsColor, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.pnlSelectionGroupColor, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnSelect3DElemColor, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.pnl3DElemColor, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.pnl2DElemColor, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.pnlNodeColor, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(338, 628);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnSelectNodeColor
            // 
            this.btnSelectNodeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNodeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNodeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectNodeColor.Location = new System.Drawing.Point(7, 550);
            this.btnSelectNodeColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectNodeColor.Name = "btnSelectNodeColor";
            this.btnSelectNodeColor.Size = new System.Drawing.Size(214, 27);
            this.btnSelectNodeColor.TabIndex = 15;
            this.btnSelectNodeColor.Text = "выбрать цвет узлов";
            this.btnSelectNodeColor.UseVisualStyleBackColor = true;
            this.btnSelectNodeColor.Click += new System.EventHandler(this.btnSelectNodeColor_Click);
            // 
            // btnSelect2DElemColor
            // 
            this.btnSelect2DElemColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect2DElemColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect2DElemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect2DElemColor.Location = new System.Drawing.Point(7, 424);
            this.btnSelect2DElemColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelect2DElemColor.Name = "btnSelect2DElemColor";
            this.btnSelect2DElemColor.Size = new System.Drawing.Size(214, 27);
            this.btnSelect2DElemColor.TabIndex = 14;
            this.btnSelect2DElemColor.Text = "выбрать цвет 2D элементов";
            this.btnSelect2DElemColor.UseVisualStyleBackColor = true;
            this.btnSelect2DElemColor.Click += new System.EventHandler(this.btnSelect2DElemColor_Click);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectColor.Location = new System.Drawing.Point(7, 49);
            this.btnSelectColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectColor.Size = new System.Drawing.Size(214, 27);
            this.btnSelectColor.TabIndex = 1;
            this.btnSelectColor.Text = "выбрать цвет выделения объектов";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectObjectColor_Click);
            // 
            // btnSelectGroupColor
            // 
            this.btnSelectGroupColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectGroupColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectGroupColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectGroupColor.Location = new System.Drawing.Point(7, 174);
            this.btnSelectGroupColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectGroupColor.Name = "btnSelectGroupColor";
            this.btnSelectGroupColor.Size = new System.Drawing.Size(214, 27);
            this.btnSelectGroupColor.TabIndex = 10;
            this.btnSelectGroupColor.Text = "выбрать цвет выделения групп";
            this.btnSelectGroupColor.UseVisualStyleBackColor = true;
            this.btnSelectGroupColor.Click += new System.EventHandler(this.btnSelectGroupColor_Click);
            // 
            // pnlSelectionObjsColor
            // 
            this.pnlSelectionObjsColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectionObjsColor.BackColor = System.Drawing.Color.LawnGreen;
            this.pnlSelectionObjsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectionObjsColor.Location = new System.Drawing.Point(235, 49);
            this.pnlSelectionObjsColor.Margin = new System.Windows.Forms.Padding(7);
            this.pnlSelectionObjsColor.Name = "pnlSelectionObjsColor";
            this.pnlSelectionObjsColor.Size = new System.Drawing.Size(96, 27);
            this.pnlSelectionObjsColor.TabIndex = 11;
            // 
            // pnlSelectionGroupColor
            // 
            this.pnlSelectionGroupColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectionGroupColor.BackColor = System.Drawing.Color.Yellow;
            this.pnlSelectionGroupColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectionGroupColor.Location = new System.Drawing.Point(235, 174);
            this.pnlSelectionGroupColor.Margin = new System.Windows.Forms.Padding(7);
            this.pnlSelectionGroupColor.Name = "pnlSelectionGroupColor";
            this.pnlSelectionGroupColor.Size = new System.Drawing.Size(96, 27);
            this.pnlSelectionGroupColor.TabIndex = 12;
            // 
            // btnSelect3DElemColor
            // 
            this.btnSelect3DElemColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect3DElemColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect3DElemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect3DElemColor.Location = new System.Drawing.Point(7, 299);
            this.btnSelect3DElemColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelect3DElemColor.Name = "btnSelect3DElemColor";
            this.btnSelect3DElemColor.Size = new System.Drawing.Size(214, 27);
            this.btnSelect3DElemColor.TabIndex = 13;
            this.btnSelect3DElemColor.Text = "выбрать цвет 3D элементов";
            this.btnSelect3DElemColor.UseVisualStyleBackColor = true;
            this.btnSelect3DElemColor.Click += new System.EventHandler(this.btnSelect3DElemColor_Click);
            // 
            // pnl3DElemColor
            // 
            this.pnl3DElemColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl3DElemColor.BackColor = System.Drawing.Color.Yellow;
            this.pnl3DElemColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl3DElemColor.Location = new System.Drawing.Point(235, 299);
            this.pnl3DElemColor.Margin = new System.Windows.Forms.Padding(7);
            this.pnl3DElemColor.Name = "pnl3DElemColor";
            this.pnl3DElemColor.Size = new System.Drawing.Size(96, 27);
            this.pnl3DElemColor.TabIndex = 16;
            // 
            // pnl2DElemColor
            // 
            this.pnl2DElemColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl2DElemColor.BackColor = System.Drawing.Color.Yellow;
            this.pnl2DElemColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl2DElemColor.Location = new System.Drawing.Point(235, 424);
            this.pnl2DElemColor.Margin = new System.Windows.Forms.Padding(7);
            this.pnl2DElemColor.Name = "pnl2DElemColor";
            this.pnl2DElemColor.Size = new System.Drawing.Size(96, 27);
            this.pnl2DElemColor.TabIndex = 18;
            // 
            // pnlNodeColor
            // 
            this.pnlNodeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNodeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNodeColor.Location = new System.Drawing.Point(235, 550);
            this.pnlNodeColor.Margin = new System.Windows.Forms.Padding(7);
            this.pnlNodeColor.Name = "pnlNodeColor";
            this.pnlNodeColor.Size = new System.Drawing.Size(96, 27);
            this.pnlNodeColor.TabIndex = 19;
            // 
            // tbSolver
            // 
            this.tbSolver.Controls.Add(this.tableLayoutPanel5);
            this.tbSolver.Location = new System.Drawing.Point(4, 34);
            this.tbSolver.Margin = new System.Windows.Forms.Padding(0);
            this.tbSolver.Name = "tbSolver";
            this.tbSolver.Size = new System.Drawing.Size(215, 396);
            this.tbSolver.TabIndex = 2;
            this.tbSolver.Text = "Решатель";
            this.tbSolver.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.Controls.Add(this.lblSolverPath, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(338, 628);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Путь до решателя";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.58929F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.41071F));
            this.tableLayoutPanel3.Controls.Add(this.btnSaveConfig, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tabControlEx1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.26519F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.734807F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(352, 729);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lightingControl
            // 
            this.lightingControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lightingControl.BallPosition = new System.Drawing.Point(0, 0);
            this.lightingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.lightingControl, 2);
            this.lightingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightingControl.Location = new System.Drawing.Point(0, 173);
            this.lightingControl.Margin = new System.Windows.Forms.Padding(0);
            this.lightingControl.Name = "lightingControl";
            this.lightingControl.Size = new System.Drawing.Size(338, 338);
            this.lightingControl.TabIndex = 11;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(352, 729);
            this.tabControlEx1.ResumeLayout(false);
            this.tbScene.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbObjects.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tbSolver.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbLighting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbBackRibbers;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Panel panelBackGroundColor;
        private LightingControl lightingControl;
        private ColorSlider clslLigthingIntensity;
        private ColorSlider clslTransparency;
        private System.Windows.Forms.CheckBox chbTransparency;
        private System.Windows.Forms.Label lblSolverPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveConfig;
        private TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tbScene;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tbObjects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Button btnSelectGroupColor;
        private System.Windows.Forms.Panel pnlSelectionObjsColor;
        private System.Windows.Forms.Panel pnlSelectionGroupColor;
        private System.Windows.Forms.Button btnSelectNodeColor;
        private System.Windows.Forms.Button btnSelect2DElemColor;
        private System.Windows.Forms.Button btnSelect3DElemColor;
        private System.Windows.Forms.Panel pnl2DElemColor;
        private System.Windows.Forms.Panel pnl3DElemColor;
        private System.Windows.Forms.Panel pnlNodeColor;
        private System.Windows.Forms.TabPage tbSolver;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
    }
}
