namespace BaseModule.Results.GraphCreation
{
    partial class GraphCreationPage
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
            this.layOutGraph = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.btnCreatePlot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtTime = new System.Windows.Forms.RadioButton();
            this.rbtPath = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtNodes = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtElements = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.layOutGraph.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // layOutGraph
            // 
            this.layOutGraph.ColumnCount = 2;
            this.layOutGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layOutGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layOutGraph.Controls.Add(this.panel1, 1, 0);
            this.layOutGraph.Controls.Add(this.btnCreatePlot, 1, 2);
            this.layOutGraph.Controls.Add(this.groupBox1, 0, 0);
            this.layOutGraph.Controls.Add(this.groupBox2, 0, 1);
            this.layOutGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layOutGraph.Location = new System.Drawing.Point(0, 0);
            this.layOutGraph.Margin = new System.Windows.Forms.Padding(0);
            this.layOutGraph.Name = "layOutGraph";
            this.layOutGraph.RowCount = 3;
            this.layOutGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.92592F));
            this.layOutGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.07408F));
            this.layOutGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.layOutGraph.Size = new System.Drawing.Size(551, 466);
            this.layOutGraph.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(418, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.layOutGraph.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(133, 420);
            this.panel1.TabIndex = 49;
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(7, 4);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(7, 4, 7, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(119, 416);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            // 
            // btnCreatePlot
            // 
            this.btnCreatePlot.AutoSize = true;
            this.btnCreatePlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreatePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreatePlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePlot.Location = new System.Drawing.Point(425, 427);
            this.btnCreatePlot.Margin = new System.Windows.Forms.Padding(7);
            this.btnCreatePlot.Name = "btnCreatePlot";
            this.btnCreatePlot.Size = new System.Drawing.Size(119, 32);
            this.btnCreatePlot.TabIndex = 31;
            this.btnCreatePlot.Text = "Построить";
            this.btnCreatePlot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreatePlot.UseVisualStyleBackColor = true;
            this.btnCreatePlot.Click += new System.EventHandler(this.btnCreatePlot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(410, 227);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид графика";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 206);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(114, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 206);
            this.label1.TabIndex = 50;
            this.label1.Text = "Время";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtTime
            // 
            this.rbtTime.AutoSize = true;
            this.rbtTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtTime.Location = new System.Drawing.Point(0, 0);
            this.rbtTime.Margin = new System.Windows.Forms.Padding(0);
            this.rbtTime.Name = "rbtTime";
            this.rbtTime.Size = new System.Drawing.Size(110, 206);
            this.rbtTime.TabIndex = 49;
            this.rbtTime.UseVisualStyleBackColor = true;
            this.rbtTime.Click += new System.EventHandler(this.rbtTime_Click);
            // 
            // rbtPath
            // 
            this.rbtPath.AutoSize = true;
            this.rbtPath.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtPath.Location = new System.Drawing.Point(220, 0);
            this.rbtPath.Margin = new System.Windows.Forms.Padding(0);
            this.rbtPath.Name = "rbtPath";
            this.rbtPath.Size = new System.Drawing.Size(81, 206);
            this.rbtPath.TabIndex = 47;
            this.rbtPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtPath.UseVisualStyleBackColor = true;
            this.rbtPath.Click += new System.EventHandler(this.rbtPath_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Путь";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 239);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.layOutGraph.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(410, 223);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип объектов";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.99338F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.00662F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Controls.Add(this.rbtNodes, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbtElements, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(402, 202);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rbtNodes
            // 
            this.rbtNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtNodes.AutoSize = true;
            this.rbtNodes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtNodes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtNodes.Location = new System.Drawing.Point(89, 94);
            this.rbtNodes.Margin = new System.Windows.Forms.Padding(0);
            this.rbtNodes.Name = "rbtNodes";
            this.rbtNodes.Size = new System.Drawing.Size(14, 13);
            this.rbtNodes.TabIndex = 33;
            this.rbtNodes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtNodes.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Узлы";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtElements
            // 
            this.rbtElements.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtElements.AutoSize = true;
            this.rbtElements.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtElements.Location = new System.Drawing.Point(275, 94);
            this.rbtElements.Margin = new System.Windows.Forms.Padding(0);
            this.rbtElements.Name = "rbtElements";
            this.rbtElements.Size = new System.Drawing.Size(14, 13);
            this.rbtElements.TabIndex = 42;
            this.rbtElements.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Элементы";
            // 
            // GraphCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layOutGraph);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GraphCreationPage";
            this.Size = new System.Drawing.Size(551, 466);
            this.layOutGraph.ResumeLayout(false);
            this.layOutGraph.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layOutGraph;
        private System.Windows.Forms.Button btnCreatePlot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbtNodes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtElements;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtTime;
        private System.Windows.Forms.RadioButton rbtPath;
        private System.Windows.Forms.Label label2;
    }
}
