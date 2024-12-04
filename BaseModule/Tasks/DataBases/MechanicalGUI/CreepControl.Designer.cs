using UserControlsEx.Graph;

namespace BaseModule.Tasks.DataBases.MechanicalGUI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.graphContainer1 = new GraphContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTime = new System.Windows.Forms.TextBox();
            this.txbForce = new System.Windows.Forms.TextBox();
            this.txbLength = new System.Windows.Forms.TextBox();
            this.txbDiam = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txbTemp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPhases = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.75F));
            this.tableLayoutPanel1.Controls.Add(this.graphContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCalc, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.88937F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.110629F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // graphContainer1
            // 
            this.graphContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphContainer1.Location = new System.Drawing.Point(0, 0);
            this.graphContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.graphContainer1.Name = "graphContainer1";
            this.tableLayoutPanel1.SetRowSpan(this.graphContainer1, 2);
            this.graphContainer1.Size = new System.Drawing.Size(333, 461);
            this.graphContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbPhases);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbTemp);
            this.panel1.Controls.Add(this.txbTime);
            this.panel1.Controls.Add(this.txbForce);
            this.panel1.Controls.Add(this.txbLength);
            this.panel1.Controls.Add(this.txbDiam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(336, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 413);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Время, ч";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Нагрузка, Н";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Длина, мм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Диаметр, мм";
            // 
            // txbTime
            // 
            this.txbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTime.Location = new System.Drawing.Point(112, 92);
            this.txbTime.Name = "txbTime";
            this.txbTime.Size = new System.Drawing.Size(128, 20);
            this.txbTime.TabIndex = 0;
            // 
            // txbForce
            // 
            this.txbForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForce.Location = new System.Drawing.Point(112, 66);
            this.txbForce.Name = "txbForce";
            this.txbForce.Size = new System.Drawing.Size(128, 20);
            this.txbForce.TabIndex = 0;
            // 
            // txbLength
            // 
            this.txbLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbLength.Location = new System.Drawing.Point(112, 40);
            this.txbLength.Name = "txbLength";
            this.txbLength.Size = new System.Drawing.Size(128, 20);
            this.txbLength.TabIndex = 0;
            // 
            // txbDiam
            // 
            this.txbDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDiam.Location = new System.Drawing.Point(112, 14);
            this.txbDiam.Name = "txbDiam";
            this.txbDiam.Size = new System.Drawing.Size(128, 20);
            this.txbDiam.TabIndex = 0;
            // 
            // btnCalc
            // 
            this.btnCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalc.Location = new System.Drawing.Point(336, 422);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(253, 36);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "Рассчитать";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txbTemp
            // 
            this.txbTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTemp.Location = new System.Drawing.Point(112, 118);
            this.txbTemp.Name = "txbTemp";
            this.txbTemp.Size = new System.Drawing.Size(128, 20);
            this.txbTemp.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Температура, °С";
            // 
            // cmbPhases
            // 
            this.cmbPhases.FormattingEnabled = true;
            this.cmbPhases.Location = new System.Drawing.Point(112, 144);
            this.cmbPhases.Name = "cmbPhases";
            this.cmbPhases.Size = new System.Drawing.Size(128, 21);
            this.cmbPhases.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Фаза";
            // 
            // CreepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreepControl";
            this.Size = new System.Drawing.Size(592, 461);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
