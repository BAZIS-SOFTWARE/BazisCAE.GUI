using UserControlsEx.Graph;

namespace BazisGUI.DataBases.MechanicalGUI
{
    partial class CreepControl
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            graphContainer1 = new GraphContainer();
            panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            cmbPhases = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txbTemp = new System.Windows.Forms.TextBox();
            txbTime = new System.Windows.Forms.TextBox();
            txbForce = new System.Windows.Forms.TextBox();
            txbLength = new System.Windows.Forms.TextBox();
            txbDiam = new System.Windows.Forms.TextBox();
            btnCalc = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.75F));
            tableLayoutPanel1.Controls.Add(graphContainer1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(btnCalc, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.88937F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.110629F));
            tableLayoutPanel1.Size = new System.Drawing.Size(691, 532);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // graphContainer1
            // 
            graphContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            graphContainer1.Location = new System.Drawing.Point(0, 0);
            graphContainer1.Margin = new System.Windows.Forms.Padding(0);
            graphContainer1.Name = "graphContainer1";
            tableLayoutPanel1.SetRowSpan(graphContainer1, 2);
            graphContainer1.Size = new System.Drawing.Size(388, 532);
            graphContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cmbPhases);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txbTemp);
            panel1.Controls.Add(txbTime);
            panel1.Controls.Add(txbForce);
            panel1.Controls.Add(txbLength);
            panel1.Controls.Add(txbDiam);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(392, 3);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(295, 477);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(82, 170);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(33, 15);
            label6.TabIndex = 3;
            label6.Text = "Фаза";
            // 
            // cmbPhases
            // 
            cmbPhases.FormattingEnabled = true;
            cmbPhases.Location = new System.Drawing.Point(131, 166);
            cmbPhases.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbPhases.Name = "cmbPhases";
            cmbPhases.Size = new System.Drawing.Size(149, 23);
            cmbPhases.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(18, 140);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(98, 15);
            label5.TabIndex = 1;
            label5.Text = "Температура, °С";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(64, 110);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 15);
            label4.TabIndex = 1;
            label4.Text = "Время, ч";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(43, 80);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 15);
            label3.TabIndex = 1;
            label3.Text = "Нагрузка, Н";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(51, 50);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Длина, мм";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Диаметр, мм";
            // 
            // txbTemp
            // 
            txbTemp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbTemp.Location = new System.Drawing.Point(131, 136);
            txbTemp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbTemp.Name = "txbTemp";
            txbTemp.Size = new System.Drawing.Size(149, 23);
            txbTemp.TabIndex = 0;
            // 
            // txbTime
            // 
            txbTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbTime.Location = new System.Drawing.Point(131, 106);
            txbTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbTime.Name = "txbTime";
            txbTime.Size = new System.Drawing.Size(149, 23);
            txbTime.TabIndex = 0;
            // 
            // txbForce
            // 
            txbForce.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbForce.Location = new System.Drawing.Point(131, 76);
            txbForce.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbForce.Name = "txbForce";
            txbForce.Size = new System.Drawing.Size(149, 23);
            txbForce.TabIndex = 0;
            // 
            // txbLength
            // 
            txbLength.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbLength.Location = new System.Drawing.Point(131, 46);
            txbLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbLength.Name = "txbLength";
            txbLength.Size = new System.Drawing.Size(149, 23);
            txbLength.TabIndex = 0;
            // 
            // txbDiam
            // 
            txbDiam.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbDiam.Location = new System.Drawing.Point(131, 16);
            txbDiam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbDiam.Name = "txbDiam";
            txbDiam.Size = new System.Drawing.Size(149, 23);
            txbDiam.TabIndex = 0;
            // 
            // btnCalc
            // 
            btnCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalc.Location = new System.Drawing.Point(392, 486);
            btnCalc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new System.Drawing.Size(295, 43);
            btnCalc.TabIndex = 2;
            btnCalc.Text = "Рассчитать";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // CreepControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CreepControl";
            Size = new System.Drawing.Size(691, 532);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GraphContainer graphContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTime;
        private System.Windows.Forms.TextBox txbForce;
        private System.Windows.Forms.TextBox txbLength;
        private System.Windows.Forms.TextBox txbDiam;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTemp;
        private System.Windows.Forms.ComboBox cmbPhases;
        private System.Windows.Forms.Label label6;
    }
}
