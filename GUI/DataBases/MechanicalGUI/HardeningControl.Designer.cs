using UserControlsEx.Graph;

namespace BazisGUI.DataBases.MechanicalGUI
{
    partial class HardeningControl
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
            graphContainer = new GraphContainer();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            btnCalc = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            chbTemp = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cmbPhases = new System.Windows.Forms.ComboBox();
            txbTemp = new System.Windows.Forms.TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // graphContainer
            // 
            graphContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            graphContainer.Location = new System.Drawing.Point(0, 0);
            graphContainer.Margin = new System.Windows.Forms.Padding(0);
            graphContainer.Name = "graphContainer";
            graphContainer.Size = new System.Drawing.Size(412, 488);
            graphContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.69649F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.30351F));
            tableLayoutPanel1.Controls.Add(graphContainer, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(638, 488);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnCalc, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(414, 3);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            tableLayoutPanel2.Size = new System.Drawing.Size(222, 482);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnCalc
            // 
            btnCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalc.Location = new System.Drawing.Point(2, 448);
            btnCalc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new System.Drawing.Size(218, 31);
            btnCalc.TabIndex = 0;
            btnCalc.Text = "Рассчитать";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(chbTemp);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbPhases);
            panel1.Controls.Add(txbTemp);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(2, 3);
            panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(218, 439);
            panel1.TabIndex = 1;
            // 
            // chbTemp
            // 
            chbTemp.AutoSize = true;
            chbTemp.Location = new System.Drawing.Point(99, 59);
            chbTemp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            chbTemp.Name = "chbTemp";
            chbTemp.Size = new System.Drawing.Size(140, 19);
            chbTemp.TabIndex = 3;
            chbTemp.Text = "Указать температуру";
            chbTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            chbTemp.UseVisualStyleBackColor = true;
            chbTemp.CheckedChanged += chbTemp_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 87);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "Температура";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 31);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 15);
            label1.TabIndex = 2;
            label1.Text = "Фаза";
            // 
            // cmbPhases
            // 
            cmbPhases.AccessibleDescription = "";
            cmbPhases.AccessibleName = "Phases";
            cmbPhases.FormattingEnabled = true;
            cmbPhases.Location = new System.Drawing.Point(99, 28);
            cmbPhases.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cmbPhases.Name = "cmbPhases";
            cmbPhases.Size = new System.Drawing.Size(81, 23);
            cmbPhases.TabIndex = 1;
            // 
            // txbTemp
            // 
            txbTemp.AccessibleName = "Temp";
            txbTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbTemp.Enabled = false;
            txbTemp.Location = new System.Drawing.Point(99, 83);
            txbTemp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txbTemp.Name = "txbTemp";
            txbTemp.Size = new System.Drawing.Size(81, 23);
            txbTemp.TabIndex = 0;
            // 
            // HardeningControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "HardeningControl";
            Size = new System.Drawing.Size(638, 488);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GraphContainer graphContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPhases;
        private System.Windows.Forms.TextBox txbTemp;
        private System.Windows.Forms.CheckBox chbTemp;
    }
}
