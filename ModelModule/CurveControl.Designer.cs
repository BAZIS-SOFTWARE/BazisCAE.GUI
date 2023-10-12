namespace ModelModule
{
    partial class CurveControl
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
            this.boxCurve = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCoef = new System.Windows.Forms.TextBox();
            this.algoNPoints = new System.Windows.Forms.TextBox();
            this.boxCurve.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxCurve
            // 
            this.boxCurve.Controls.Add(this.tableLayoutPanel1);
            this.boxCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxCurve.Location = new System.Drawing.Point(5, 5);
            this.boxCurve.Margin = new System.Windows.Forms.Padding(0);
            this.boxCurve.Name = "boxCurve";
            this.boxCurve.Size = new System.Drawing.Size(220, 270);
            this.boxCurve.TabIndex = 0;
            this.boxCurve.TabStop = false;
            this.boxCurve.Text = "Настройки кривой";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.algoNPoints, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCoef, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(214, 249);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rbtnBump
            // 
            this.rbtnBump.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBump.AutoSize = true;
            this.rbtnBump.Location = new System.Drawing.Point(27, 103);
            this.rbtnBump.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnBump.Name = "rbtnBump";
            this.rbtnBump.Size = new System.Drawing.Size(124, 20);
            this.rbtnBump.TabIndex = 2;
            this.rbtnBump.Tag = "Bump";
            this.rbtnBump.Text = "Выталкивание";
            this.rbtnBump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBump.UseVisualStyleBackColor = true;
            // 
            // rbtnProgressive
            // 
            this.rbtnProgressive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnProgressive.AutoSize = true;
            this.rbtnProgressive.Checked = true;
            this.rbtnProgressive.Location = new System.Drawing.Point(27, 48);
            this.rbtnProgressive.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnProgressive.Name = "rbtnProgressive";
            this.rbtnProgressive.Size = new System.Drawing.Size(105, 20);
            this.rbtnProgressive.TabIndex = 1;
            this.rbtnProgressive.TabStop = true;
            this.rbtnProgressive.Tag = "Progressive";
            this.rbtnProgressive.Text = "Прогрессия";
            this.rbtnProgressive.UseVisualStyleBackColor = true;
            // 
            // rbtnBeta
            // 
            this.rbtnBeta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBeta.AutoSize = true;
            this.rbtnBeta.Location = new System.Drawing.Point(27, 76);
            this.rbtnBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBeta.Name = "rbtnBeta";
            this.rbtnBeta.Size = new System.Drawing.Size(60, 20);
            this.rbtnBeta.TabIndex = 3;
            this.rbtnBeta.Tag = "Beta";
            this.rbtnBeta.Text = "Бета";
            this.rbtnBeta.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnBump);
            this.panel1.Controls.Add(this.rbtnProgressive);
            this.panel1.Controls.Add(this.rbtnBeta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 150);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм уточнения:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Коэффициент:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Число точек:";
            // 
            // txtCoef
            // 
            this.txtCoef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoef.Location = new System.Drawing.Point(0, 175);
            this.txtCoef.Margin = new System.Windows.Forms.Padding(0);
            this.txtCoef.Multiline = true;
            this.txtCoef.Name = "txtCoef";
            this.txtCoef.Size = new System.Drawing.Size(214, 23);
            this.txtCoef.TabIndex = 10;
            this.txtCoef.Tag = "algoCoef";
            this.txtCoef.Text = "1.0";
            // 
            // algoNPoints
            // 
            this.algoNPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algoNPoints.Location = new System.Drawing.Point(3, 225);
            this.algoNPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algoNPoints.Multiline = true;
            this.algoNPoints.Name = "algoNPoints";
            this.algoNPoints.Size = new System.Drawing.Size(208, 22);
            this.algoNPoints.TabIndex = 11;
            this.algoNPoints.Tag = "algoNPoints";
            // 
            // CurveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxCurve);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CurveControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(230, 280);
            this.boxCurve.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxCurve;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtnProgressive;
        private System.Windows.Forms.RadioButton rbtnBump;
        private System.Windows.Forms.RadioButton rbtnBeta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCoef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox algoNPoints;
    }
}
