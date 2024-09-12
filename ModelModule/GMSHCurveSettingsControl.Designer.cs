namespace ModelModule
{
    partial class GMSHCurveSettingsControl
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
            this.curvesControlBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAlgoCoef = new UserControlsEx.TextBoxEx(this.components);
            this.txbAlgoNPoints = new UserControlsEx.TextBoxEx(this.components);
            this.btnDel = new System.Windows.Forms.Button();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.curvesControlBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // curvesControlBox
            // 
            this.curvesControlBox.AutoSize = true;
            this.curvesControlBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.curvesControlBox.BackColor = System.Drawing.SystemColors.Control;
            this.curvesControlBox.Controls.Add(this.tableLayoutPanel2);
            this.curvesControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curvesControlBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.curvesControlBox.Location = new System.Drawing.Point(0, 0);
            this.curvesControlBox.Margin = new System.Windows.Forms.Padding(7);
            this.curvesControlBox.Name = "curvesControlBox";
            this.curvesControlBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.curvesControlBox.Size = new System.Drawing.Size(450, 157);
            this.curvesControlBox.TabIndex = 3;
            this.curvesControlBox.TabStop = false;
            this.curvesControlBox.Text = "Настройки разметки кривых";
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
            this.tableLayoutPanel2.Controls.Add(this.txbAlgoCoef, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbAlgoNPoints, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDel, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBeta, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtnBump, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(444, 141);
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
            // txbAlgoCoef
            // 
            this.txbAlgoCoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAlgoCoef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.txbAlgoCoef, 2);
            this.txbAlgoCoef.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbAlgoCoef.IsValidating = true;
            this.txbAlgoCoef.Location = new System.Drawing.Point(229, 14);
            this.txbAlgoCoef.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbAlgoCoef.Name = "txbAlgoCoef";
            this.txbAlgoCoef.Size = new System.Drawing.Size(195, 20);
            this.txbAlgoCoef.TabIndex = 4;
            this.txbAlgoCoef.Tag = "algoCoef";
            this.txbAlgoCoef.Text = "1.0";
            this.txbAlgoCoef.UserRegExCheck = null;
            this.txbAlgoCoef.UserRegExCheckErrorMessage = "Введите чило с плавающей запятой.";
            // 
            // txbAlgoNPoints
            // 
            this.txbAlgoNPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAlgoNPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.txbAlgoNPoints, 2);
            this.txbAlgoNPoints.InputType = UserControlsEx.TXTBoxInputType.Integer;
            this.txbAlgoNPoints.IsValidating = true;
            this.txbAlgoNPoints.Location = new System.Drawing.Point(229, 62);
            this.txbAlgoNPoints.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbAlgoNPoints.Name = "txbAlgoNPoints";
            this.txbAlgoNPoints.Size = new System.Drawing.Size(195, 20);
            this.txbAlgoNPoints.TabIndex = 5;
            this.txbAlgoNPoints.Tag = "algoNPoints";
            this.txbAlgoNPoints.UserRegExCheck = null;
            this.txbAlgoNPoints.UserRegExCheckErrorMessage = null;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.Location = new System.Drawing.Point(346, 102);
            this.btnDel.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(78, 32);
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
            this.btnOK.Location = new System.Drawing.Point(229, 102);
            this.btnOK.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // GMSHCurveSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.curvesControlBox);
            this.Name = "GMSHCurveSettingsControl";
            this.Size = new System.Drawing.Size(450, 157);
            this.curvesControlBox.ResumeLayout(false);
            this.curvesControlBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox curvesControlBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbtnProgressive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UserControlsEx.TextBoxEx txbAlgoCoef;
        private UserControlsEx.TextBoxEx txbAlgoNPoints;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.RadioButton rbtnBeta;
        private System.Windows.Forms.RadioButton rbtnBump;
        private System.Windows.Forms.Button btnOK;
    }
}
