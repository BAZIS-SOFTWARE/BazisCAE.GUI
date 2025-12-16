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
            lblSolverPath = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            chbLighting = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            chbBackRibbers = new System.Windows.Forms.CheckBox();
            btnBackGroundColor = new System.Windows.Forms.Button();
            panelBackGroundColor = new System.Windows.Forms.Panel();
            clslLigthingIntensity = new ColorSlider();
            label2 = new System.Windows.Forms.Label();
            clslTransparency = new ColorSlider();
            chbTransparency = new System.Windows.Forms.CheckBox();
            tabControlEx1 = new TabControlEx();
            tbScene = new System.Windows.Forms.TabPage();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            lightingControl = new LightingControl();
            chbOrtoProjection = new System.Windows.Forms.CheckBox();
            label5 = new System.Windows.Forms.Label();
            tbObjects = new System.Windows.Forms.TabPage();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            btnSelectNodeColor = new System.Windows.Forms.Button();
            btnSelect2DElemColor = new System.Windows.Forms.Button();
            btnSelectColor = new System.Windows.Forms.Button();
            btnSelectGroupColor = new System.Windows.Forms.Button();
            pnlSelectionObjsColor = new System.Windows.Forms.Panel();
            pnlSelectionGroupColor = new System.Windows.Forms.Panel();
            btnSelect3DElemColor = new System.Windows.Forms.Button();
            pnl3DElemColor = new System.Windows.Forms.Panel();
            pnl2DElemColor = new System.Windows.Forms.Panel();
            pnlNodeColor = new System.Windows.Forms.Panel();
            tbSolver = new System.Windows.Forms.TabPage();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            tabControlEx1.SuspendLayout();
            tbScene.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tbObjects.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tbSolver.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // lblSolverPath
            // 
            lblSolverPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblSolverPath.AutoSize = true;
            lblSolverPath.Location = new System.Drawing.Point(276, 394);
            lblSolverPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSolverPath.Name = "lblSolverPath";
            lblSolverPath.Size = new System.Drawing.Size(12, 15);
            lblSolverPath.TabIndex = 20;
            lblSolverPath.Text = "?";
            lblSolverPath.Click += btnSetSolverPath_Click;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(94, 680);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 15);
            label4.TabIndex = 1;
            label4.Text = "Прозрачность";
            // 
            // chbLighting
            // 
            chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            chbLighting.AutoSize = true;
            chbLighting.Location = new System.Drawing.Point(297, 189);
            chbLighting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbLighting.Name = "chbLighting";
            chbLighting.Size = new System.Drawing.Size(81, 19);
            chbLighting.TabIndex = 8;
            chbLighting.Text = "Включить";
            chbLighting.UseVisualStyleBackColor = true;
            chbLighting.Click += chbLighting_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(52, 134);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(170, 15);
            label1.TabIndex = 6;
            label1.Text = "Внутренние ребра элементов";
            // 
            // chbBackRibbers
            // 
            chbBackRibbers.Anchor = System.Windows.Forms.AnchorStyles.None;
            chbBackRibbers.AutoSize = true;
            chbBackRibbers.Location = new System.Drawing.Point(297, 132);
            chbBackRibbers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbBackRibbers.Name = "chbBackRibbers";
            chbBackRibbers.Size = new System.Drawing.Size(81, 19);
            chbBackRibbers.TabIndex = 5;
            chbBackRibbers.Text = "Включить";
            chbBackRibbers.UseVisualStyleBackColor = true;
            chbBackRibbers.Click += chbBackRibbers_Click;
            // 
            // btnBackGroundColor
            // 
            btnBackGroundColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackGroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnBackGroundColor.Location = new System.Drawing.Point(9, 41);
            btnBackGroundColor.Margin = new System.Windows.Forms.Padding(8);
            btnBackGroundColor.Name = "btnBackGroundColor";
            btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnBackGroundColor.Size = new System.Drawing.Size(256, 31);
            btnBackGroundColor.TabIndex = 2;
            btnBackGroundColor.Text = "выбрать цвет заднего фона";
            btnBackGroundColor.UseVisualStyleBackColor = true;
            btnBackGroundColor.Click += btnBackGroundColor_Click;
            // 
            // panelBackGroundColor
            // 
            panelBackGroundColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBackGroundColor.BackColor = System.Drawing.Color.White;
            panelBackGroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBackGroundColor.Location = new System.Drawing.Point(282, 41);
            panelBackGroundColor.Margin = new System.Windows.Forms.Padding(8);
            panelBackGroundColor.Name = "panelBackGroundColor";
            panelBackGroundColor.Size = new System.Drawing.Size(112, 31);
            panelBackGroundColor.TabIndex = 4;
            // 
            // clslLigthingIntensity
            // 
            clslLigthingIntensity.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            clslLigthingIntensity.BackColor = System.Drawing.Color.Transparent;
            clslLigthingIntensity.BarPenColor = System.Drawing.Color.Black;
            clslLigthingIntensity.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            tableLayoutPanel1.SetColumnSpan(clslLigthingIntensity, 2);
            clslLigthingIntensity.LargeChange = 5U;
            clslLigthingIntensity.Location = new System.Drawing.Point(5, 628);
            clslLigthingIntensity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            clslLigthingIntensity.Name = "clslLigthingIntensity";
            clslLigthingIntensity.ShowTextValue = true;
            clslLigthingIntensity.Size = new System.Drawing.Size(393, 27);
            clslLigthingIntensity.SmallChange = 1U;
            clslLigthingIntensity.TabIndex = 12;
            clslLigthingIntensity.Text = "colorSlider";
            clslLigthingIntensity.TextValueColor = System.Drawing.Color.Black;
            clslLigthingIntensity.ThumbPenColor = System.Drawing.Color.Black;
            clslLigthingIntensity.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            clslLigthingIntensity.ThumbSize = 12;
            clslLigthingIntensity.Scroll += clslLigthingIntensity_Scroll;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(101, 191);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 15);
            label2.TabIndex = 0;
            label2.Text = "Освещение";
            // 
            // clslTransparency
            // 
            clslTransparency.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            clslTransparency.BackColor = System.Drawing.Color.Transparent;
            clslTransparency.BarPenColor = System.Drawing.Color.Black;
            clslTransparency.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            tableLayoutPanel1.SetColumnSpan(clslTransparency, 2);
            clslTransparency.LargeChange = 50U;
            clslTransparency.Location = new System.Drawing.Point(5, 719);
            clslTransparency.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            clslTransparency.Name = "clslTransparency";
            clslTransparency.ShowTextValue = true;
            clslTransparency.Size = new System.Drawing.Size(393, 29);
            clslTransparency.SmallChange = 1U;
            clslTransparency.TabIndex = 14;
            clslTransparency.Text = "colorSlider1";
            clslTransparency.TextValueColor = System.Drawing.Color.Black;
            clslTransparency.ThumbPenColor = System.Drawing.Color.Black;
            clslTransparency.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            clslTransparency.ThumbSize = 12;
            clslTransparency.Scroll += clslTransparency_Scroll;
            // 
            // chbTransparency
            // 
            chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            chbTransparency.AutoSize = true;
            chbTransparency.Location = new System.Drawing.Point(297, 678);
            chbTransparency.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbTransparency.Name = "chbTransparency";
            chbTransparency.Size = new System.Drawing.Size(81, 19);
            chbTransparency.TabIndex = 18;
            chbTransparency.Text = "Включить";
            chbTransparency.UseVisualStyleBackColor = true;
            chbTransparency.Click += chbTransparency_Click;
            // 
            // tabControlEx1
            // 
            tabControlEx1.Controls.Add(tbScene);
            tabControlEx1.Controls.Add(tbObjects);
            tabControlEx1.Controls.Add(tbSolver);
            tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlEx1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControlEx1.FontColor = System.Drawing.Color.Black;
            tabControlEx1.ItemSize = new System.Drawing.Size(43, 30);
            tabControlEx1.Location = new System.Drawing.Point(0, 0);
            tabControlEx1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControlEx1.Name = "tabControlEx1";
            tabControlEx1.SelectColor = System.Drawing.SystemColors.Control;
            tabControlEx1.SelectedIndex = 0;
            tabControlEx1.Size = new System.Drawing.Size(411, 841);
            tabControlEx1.TabIndex = 3;
            tabControlEx1.UnSelectColor = System.Drawing.Color.LightGray;
            // 
            // tbScene
            // 
            tbScene.Controls.Add(tableLayoutPanel1);
            tbScene.Location = new System.Drawing.Point(4, 34);
            tbScene.Margin = new System.Windows.Forms.Padding(0);
            tbScene.Name = "tbScene";
            tbScene.Size = new System.Drawing.Size(403, 803);
            tbScene.TabIndex = 0;
            tbScene.Text = "Сцена";
            tbScene.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 735);
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            tableLayoutPanel1.Controls.Add(label4, 0, 5);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(chbTransparency, 1, 5);
            tableLayoutPanel1.Controls.Add(lightingControl, 0, 3);
            tableLayoutPanel1.Controls.Add(chbLighting, 1, 2);
            tableLayoutPanel1.Controls.Add(btnBackGroundColor, 0, 0);
            tableLayoutPanel1.Controls.Add(panelBackGroundColor, 1, 0);
            tableLayoutPanel1.Controls.Add(chbBackRibbers, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(clslLigthingIntensity, 0, 4);
            tableLayoutPanel1.Controls.Add(clslTransparency, 0, 6);
            tableLayoutPanel1.Controls.Add(chbOrtoProjection, 1, 7);
            tableLayoutPanel1.Controls.Add(label5, 0, 7);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.Size = new System.Drawing.Size(403, 803);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lightingControl
            // 
            lightingControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lightingControl.BallPosition = new System.Drawing.Point(0, 0);
            lightingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(lightingControl, 2);
            lightingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            lightingControl.Location = new System.Drawing.Point(1, 228);
            lightingControl.Margin = new System.Windows.Forms.Padding(0);
            lightingControl.Name = "lightingControl";
            lightingControl.Size = new System.Drawing.Size(401, 390);
            lightingControl.TabIndex = 11;
            // 
            // chbOrtoProjection
            // 
            chbOrtoProjection.Anchor = System.Windows.Forms.AnchorStyles.None;
            chbOrtoProjection.AutoSize = true;
            chbOrtoProjection.Location = new System.Drawing.Point(297, 770);
            chbOrtoProjection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbOrtoProjection.Name = "chbOrtoProjection";
            chbOrtoProjection.Size = new System.Drawing.Size(81, 19);
            chbOrtoProjection.TabIndex = 19;
            chbOrtoProjection.Text = "Включить";
            chbOrtoProjection.UseVisualStyleBackColor = true;
            chbOrtoProjection.Click += chbOrtoProjection_Click;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(56, 772);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(162, 15);
            label5.TabIndex = 20;
            label5.Text = "Ортографическая проекция";
            // 
            // tbObjects
            // 
            tbObjects.Controls.Add(tableLayoutPanel4);
            tbObjects.Location = new System.Drawing.Point(4, 34);
            tbObjects.Margin = new System.Windows.Forms.Padding(0);
            tbObjects.Name = "tbObjects";
            tbObjects.Size = new System.Drawing.Size(403, 803);
            tbObjects.TabIndex = 1;
            tbObjects.Text = "Объекты";
            tbObjects.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            tableLayoutPanel4.Controls.Add(btnSelectNodeColor, 0, 4);
            tableLayoutPanel4.Controls.Add(btnSelect2DElemColor, 0, 3);
            tableLayoutPanel4.Controls.Add(btnSelectColor, 0, 0);
            tableLayoutPanel4.Controls.Add(btnSelectGroupColor, 0, 1);
            tableLayoutPanel4.Controls.Add(pnlSelectionObjsColor, 1, 0);
            tableLayoutPanel4.Controls.Add(pnlSelectionGroupColor, 1, 1);
            tableLayoutPanel4.Controls.Add(btnSelect3DElemColor, 0, 2);
            tableLayoutPanel4.Controls.Add(pnl3DElemColor, 1, 2);
            tableLayoutPanel4.Controls.Add(pnl2DElemColor, 1, 3);
            tableLayoutPanel4.Controls.Add(pnlNodeColor, 1, 4);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel4.Size = new System.Drawing.Size(403, 803);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // btnSelectNodeColor
            // 
            btnSelectNodeColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSelectNodeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectNodeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnSelectNodeColor.Location = new System.Drawing.Point(9, 706);
            btnSelectNodeColor.Margin = new System.Windows.Forms.Padding(8);
            btnSelectNodeColor.Name = "btnSelectNodeColor";
            btnSelectNodeColor.Size = new System.Drawing.Size(256, 31);
            btnSelectNodeColor.TabIndex = 15;
            btnSelectNodeColor.Text = "выбрать цвет узлов";
            btnSelectNodeColor.UseVisualStyleBackColor = true;
            btnSelectNodeColor.Click += btnSelectNodeColor_Click;
            // 
            // btnSelect2DElemColor
            // 
            btnSelect2DElemColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSelect2DElemColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelect2DElemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnSelect2DElemColor.Location = new System.Drawing.Point(9, 545);
            btnSelect2DElemColor.Margin = new System.Windows.Forms.Padding(8);
            btnSelect2DElemColor.Name = "btnSelect2DElemColor";
            btnSelect2DElemColor.Size = new System.Drawing.Size(256, 31);
            btnSelect2DElemColor.TabIndex = 14;
            btnSelect2DElemColor.Text = "выбрать цвет 2D элементов";
            btnSelect2DElemColor.UseVisualStyleBackColor = true;
            btnSelect2DElemColor.Click += btnSelect2DElemColor_Click;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnSelectColor.Location = new System.Drawing.Point(9, 65);
            btnSelectColor.Margin = new System.Windows.Forms.Padding(8);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnSelectColor.Size = new System.Drawing.Size(256, 31);
            btnSelectColor.TabIndex = 1;
            btnSelectColor.Text = "выбрать цвет выделения объектов";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectObjectColor_Click;
            // 
            // btnSelectGroupColor
            // 
            btnSelectGroupColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSelectGroupColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectGroupColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnSelectGroupColor.Location = new System.Drawing.Point(9, 225);
            btnSelectGroupColor.Margin = new System.Windows.Forms.Padding(8);
            btnSelectGroupColor.Name = "btnSelectGroupColor";
            btnSelectGroupColor.Size = new System.Drawing.Size(256, 31);
            btnSelectGroupColor.TabIndex = 10;
            btnSelectGroupColor.Text = "выбрать цвет выделения групп";
            btnSelectGroupColor.UseVisualStyleBackColor = true;
            btnSelectGroupColor.Click += btnSelectGroupColor_Click;
            // 
            // pnlSelectionObjsColor
            // 
            pnlSelectionObjsColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlSelectionObjsColor.BackColor = System.Drawing.Color.LawnGreen;
            pnlSelectionObjsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSelectionObjsColor.Location = new System.Drawing.Point(282, 65);
            pnlSelectionObjsColor.Margin = new System.Windows.Forms.Padding(8);
            pnlSelectionObjsColor.Name = "pnlSelectionObjsColor";
            pnlSelectionObjsColor.Size = new System.Drawing.Size(112, 31);
            pnlSelectionObjsColor.TabIndex = 11;
            // 
            // pnlSelectionGroupColor
            // 
            pnlSelectionGroupColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlSelectionGroupColor.BackColor = System.Drawing.Color.Yellow;
            pnlSelectionGroupColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSelectionGroupColor.Location = new System.Drawing.Point(282, 225);
            pnlSelectionGroupColor.Margin = new System.Windows.Forms.Padding(8);
            pnlSelectionGroupColor.Name = "pnlSelectionGroupColor";
            pnlSelectionGroupColor.Size = new System.Drawing.Size(112, 31);
            pnlSelectionGroupColor.TabIndex = 12;
            // 
            // btnSelect3DElemColor
            // 
            btnSelect3DElemColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSelect3DElemColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelect3DElemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnSelect3DElemColor.Location = new System.Drawing.Point(9, 385);
            btnSelect3DElemColor.Margin = new System.Windows.Forms.Padding(8);
            btnSelect3DElemColor.Name = "btnSelect3DElemColor";
            btnSelect3DElemColor.Size = new System.Drawing.Size(256, 31);
            btnSelect3DElemColor.TabIndex = 13;
            btnSelect3DElemColor.Text = "выбрать цвет 3D элементов";
            btnSelect3DElemColor.UseVisualStyleBackColor = true;
            btnSelect3DElemColor.Click += btnSelect3DElemColor_Click;
            // 
            // pnl3DElemColor
            // 
            pnl3DElemColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnl3DElemColor.BackColor = System.Drawing.Color.Yellow;
            pnl3DElemColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnl3DElemColor.Location = new System.Drawing.Point(282, 385);
            pnl3DElemColor.Margin = new System.Windows.Forms.Padding(8);
            pnl3DElemColor.Name = "pnl3DElemColor";
            pnl3DElemColor.Size = new System.Drawing.Size(112, 31);
            pnl3DElemColor.TabIndex = 16;
            // 
            // pnl2DElemColor
            // 
            pnl2DElemColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnl2DElemColor.BackColor = System.Drawing.Color.Yellow;
            pnl2DElemColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnl2DElemColor.Location = new System.Drawing.Point(282, 545);
            pnl2DElemColor.Margin = new System.Windows.Forms.Padding(8);
            pnl2DElemColor.Name = "pnl2DElemColor";
            pnl2DElemColor.Size = new System.Drawing.Size(112, 31);
            pnl2DElemColor.TabIndex = 18;
            // 
            // pnlNodeColor
            // 
            pnlNodeColor.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlNodeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlNodeColor.Location = new System.Drawing.Point(282, 706);
            pnlNodeColor.Margin = new System.Windows.Forms.Padding(8);
            pnlNodeColor.Name = "pnlNodeColor";
            pnlNodeColor.Size = new System.Drawing.Size(112, 31);
            pnlNodeColor.TabIndex = 19;
            // 
            // tbSolver
            // 
            tbSolver.Controls.Add(tableLayoutPanel5);
            tbSolver.Location = new System.Drawing.Point(4, 34);
            tbSolver.Margin = new System.Windows.Forms.Padding(0);
            tbSolver.Name = "tbSolver";
            tbSolver.Size = new System.Drawing.Size(403, 803);
            tbSolver.TabIndex = 2;
            tbSolver.Text = "Решатель";
            tbSolver.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tableLayoutPanel5.Controls.Add(lblSolverPath, 1, 0);
            tableLayoutPanel5.Controls.Add(label3, 0, 0);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new System.Drawing.Size(403, 803);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 394);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(153, 15);
            label3.TabIndex = 21;
            label3.Text = "Путь до решателя";
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(tabControlEx1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "SettingsControl";
            Size = new System.Drawing.Size(411, 841);
            tabControlEx1.ResumeLayout(false);
            tbScene.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tbObjects.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tbSolver.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
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
        private TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tbScene;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tbObjects;
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
        private System.Windows.Forms.CheckBox chbOrtoProjection;
        private System.Windows.Forms.Label label5;
    }
}
