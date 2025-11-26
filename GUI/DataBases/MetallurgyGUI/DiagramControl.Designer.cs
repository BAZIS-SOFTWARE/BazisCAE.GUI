using UserControlsEx.Graph;

namespace BazisGUI.DataBases.MetallurgyGUI
{
    partial class DiagramControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtCCT = new System.Windows.Forms.RadioButton();
            this.rbtTTT = new System.Windows.Forms.RadioButton();
            this.btnCalcDiag = new System.Windows.Forms.Button();
            this.graphContainer = new GraphContainer();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCalcDiag, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.graphContainer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 466);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 44);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rbtCCT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbtTTT, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(644, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // rbtCCT
            // 
            this.rbtCCT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtCCT.AutoSize = true;
            this.rbtCCT.Checked = true;
            this.rbtCCT.Location = new System.Drawing.Point(460, 13);
            this.rbtCCT.Name = "rbtCCT";
            this.rbtCCT.Size = new System.Drawing.Size(46, 17);
            this.rbtCCT.TabIndex = 0;
            this.rbtCCT.TabStop = true;
            this.rbtCCT.Text = "CCT";
            this.rbtCCT.UseVisualStyleBackColor = true;
            this.rbtCCT.CheckedChanged += new System.EventHandler(this.rbtCCT_CheckedChanged);
            // 
            // rbtTTT
            // 
            this.rbtTTT.AccessibleName = "TTT";
            this.rbtTTT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtTTT.AutoSize = true;
            this.rbtTTT.Location = new System.Drawing.Point(138, 13);
            this.rbtTTT.Name = "rbtTTT";
            this.rbtTTT.Size = new System.Drawing.Size(46, 17);
            this.rbtTTT.TabIndex = 0;
            this.rbtTTT.Text = "TTT";
            this.rbtTTT.UseVisualStyleBackColor = true;
            this.rbtTTT.CheckedChanged += new System.EventHandler(this.rbtTTT_CheckedChanged);
            // 
            // btnCalcDiag
            // 
            this.btnCalcDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalcDiag.Location = new System.Drawing.Point(454, 428);
            this.btnCalcDiag.Name = "btnCalcDiag";
            this.btnCalcDiag.Size = new System.Drawing.Size(194, 34);
            this.btnCalcDiag.TabIndex = 3;
            this.btnCalcDiag.Text = "Рассчитать";
            this.btnCalcDiag.UseVisualStyleBackColor = true;
            this.btnCalcDiag.Click += new System.EventHandler(this.btnCalcDiag_Click);
            // 
            // graphContainer
            // 
            this.graphContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphContainer.Location = new System.Drawing.Point(1, 52);
            this.graphContainer.Margin = new System.Windows.Forms.Padding(0);
            this.graphContainer.Name = "graphContainer";
            this.graphContainer.Size = new System.Drawing.Size(449, 372);
            this.graphContainer.TabIndex = 4;
            // 
            // DiagramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DiagramControl";
            this.Size = new System.Drawing.Size(652, 466);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbtCCT;
        private System.Windows.Forms.RadioButton rbtTTT;
        private System.Windows.Forms.Button btnCalcDiag;
        private GraphContainer graphContainer;
    }
}
