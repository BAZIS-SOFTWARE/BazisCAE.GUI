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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            rbtCCT = new System.Windows.Forms.RadioButton();
            rbtTTT = new System.Windows.Forms.RadioButton();
            btnCalcDiag = new System.Windows.Forms.Button();
            graphContainer = new GraphContainer();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCalcDiag, 1, 2);
            tableLayoutPanel1.Controls.Add(graphContainer, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            tableLayoutPanel1.Size = new System.Drawing.Size(761, 538);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(5, 4);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(751, 52);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(rbtCCT, 1, 0);
            tableLayoutPanel2.Controls.Add(rbtTTT, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(751, 52);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // rbtCCT
            // 
            rbtCCT.Anchor = System.Windows.Forms.AnchorStyles.None;
            rbtCCT.AutoSize = true;
            rbtCCT.Checked = true;
            rbtCCT.Location = new System.Drawing.Point(539, 16);
            rbtCCT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbtCCT.Name = "rbtCCT";
            rbtCCT.Size = new System.Drawing.Size(48, 19);
            rbtCCT.TabIndex = 0;
            rbtCCT.TabStop = true;
            rbtCCT.Text = "CCT";
            rbtCCT.UseVisualStyleBackColor = true;
            rbtCCT.CheckedChanged += rbtCCT_CheckedChanged;
            // 
            // rbtTTT
            // 
            rbtTTT.AccessibleName = "TTT";
            rbtTTT.Anchor = System.Windows.Forms.AnchorStyles.None;
            rbtTTT.AutoSize = true;
            rbtTTT.Location = new System.Drawing.Point(164, 16);
            rbtTTT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbtTTT.Name = "rbtTTT";
            rbtTTT.Size = new System.Drawing.Size(46, 19);
            rbtTTT.TabIndex = 0;
            rbtTTT.Text = "TTT";
            rbtTTT.UseVisualStyleBackColor = true;
            rbtTTT.CheckedChanged += rbtTTT_CheckedChanged;
            // 
            // btnCalcDiag
            // 
            btnCalcDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCalcDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalcDiag.Location = new System.Drawing.Point(531, 494);
            btnCalcDiag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCalcDiag.Name = "btnCalcDiag";
            btnCalcDiag.Size = new System.Drawing.Size(225, 40);
            btnCalcDiag.TabIndex = 3;
            btnCalcDiag.Text = "Рассчитать";
            btnCalcDiag.UseVisualStyleBackColor = true;
            btnCalcDiag.Click += btnCalcDiag_Click;
            // 
            // graphContainer
            // 
            graphContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            graphContainer.Location = new System.Drawing.Point(1, 60);
            graphContainer.Margin = new System.Windows.Forms.Padding(0);
            graphContainer.Name = "graphContainer";
            graphContainer.Size = new System.Drawing.Size(525, 430);
            graphContainer.TabIndex = 4;
            // 
            // DiagramControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DiagramControl";
            Size = new System.Drawing.Size(761, 538);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
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
