namespace ResultControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphCreationPage));
            this.pnlGraph = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCreatePlot = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSelectObjs = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtPath = new System.Windows.Forms.RadioButton();
            this.rbtTime = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtNodes = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtElements = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlGraph.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGraph
            // 
            this.pnlGraph.ColumnCount = 6;
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlGraph.Controls.Add(this.groupBox2, 0, 1);
            this.pnlGraph.Controls.Add(this.label19, 2, 2);
            this.pnlGraph.Controls.Add(this.btnCreatePlot, 3, 2);
            this.pnlGraph.Controls.Add(this.label16, 0, 2);
            this.pnlGraph.Controls.Add(this.btnSelectObjs, 1, 2);
            this.pnlGraph.Controls.Add(this.panel1, 4, 0);
            this.pnlGraph.Controls.Add(this.groupBox1, 0, 0);
            this.pnlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraph.Location = new System.Drawing.Point(0, 0);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.RowCount = 3;
            this.pnlGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlGraph.Size = new System.Drawing.Size(450, 441);
            this.pnlGraph.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(166, 361);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Построить";
            // 
            // btnCreatePlot
            // 
            this.btnCreatePlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreatePlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreatePlot.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatePlot.Image")));
            this.btnCreatePlot.Location = new System.Drawing.Point(252, 354);
            this.btnCreatePlot.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreatePlot.Name = "btnCreatePlot";
            this.btnCreatePlot.Size = new System.Drawing.Size(26, 26);
            this.btnCreatePlot.TabIndex = 31;
            this.btnCreatePlot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreatePlot.UseVisualStyleBackColor = true;
            this.btnCreatePlot.Click += new System.EventHandler(this.btnCreatePlot_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 361);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Выбрать объект";
            // 
            // btnSelectObjs
            // 
            this.btnSelectObjs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectObjs.AutoSize = true;
            this.btnSelectObjs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectObjs.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectObjs.Image")));
            this.btnSelectObjs.Location = new System.Drawing.Point(112, 354);
            this.btnSelectObjs.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectObjs.Name = "btnSelectObjs";
            this.btnSelectObjs.Size = new System.Drawing.Size(26, 26);
            this.btnSelectObjs.TabIndex = 34;
            this.btnSelectObjs.UseVisualStyleBackColor = true;
            this.btnSelectObjs.Click += new System.EventHandler(this.btnSelectObjs_Click);
            // 
            // panel1
            // 
            this.pnlGraph.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.richTextBox);
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(303, 3);
            this.panel1.Name = "panel1";
            this.pnlGraph.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(144, 435);
            this.panel1.TabIndex = 49;
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(3, 30);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(138, 402);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            // 
            // comboBox
            // 
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox.Enabled = false;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(3, 3);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(138, 21);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.pnlGraph.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 141);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид графика";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rbtPath
            // 
            this.rbtPath.AutoSize = true;
            this.rbtPath.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtPath.Location = new System.Drawing.Point(154, 0);
            this.rbtPath.Margin = new System.Windows.Forms.Padding(0);
            this.rbtPath.Name = "rbtPath";
            this.rbtPath.Size = new System.Drawing.Size(61, 122);
            this.rbtPath.TabIndex = 47;
            this.rbtPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtPath.UseVisualStyleBackColor = true;
            this.rbtPath.Click += new System.EventHandler(this.rbtPath_Click);
            // 
            // rbtTime
            // 
            this.rbtTime.AutoSize = true;
            this.rbtTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtTime.Location = new System.Drawing.Point(0, 0);
            this.rbtTime.Margin = new System.Windows.Forms.Padding(0);
            this.rbtTime.Name = "rbtTime";
            this.rbtTime.Size = new System.Drawing.Size(77, 122);
            this.rbtTime.TabIndex = 49;
            this.rbtTime.UseVisualStyleBackColor = true;
            this.rbtTime.Click += new System.EventHandler(this.rbtTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(80, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 122);
            this.label1.TabIndex = 50;
            this.label1.Text = "Время";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Путь";
            // 
            // groupBox2
            // 
            this.pnlGraph.SetColumnSpan(this.groupBox2, 4);
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 141);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип элементов";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.99338F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.00662F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel2.Controls.Add(this.rbtNodes, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbtElements, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(288, 122);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rbtNodes
            // 
            this.rbtNodes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtNodes.AutoSize = true;
            this.rbtNodes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtNodes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtNodes.Location = new System.Drawing.Point(63, 54);
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
            this.label6.Location = new System.Drawing.Point(77, 54);
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
            this.rbtElements.Location = new System.Drawing.Point(202, 54);
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
            this.label3.Location = new System.Drawing.Point(216, 54);
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
            this.Controls.Add(this.pnlGraph);
            this.Name = "GraphCreationPage";
            this.Size = new System.Drawing.Size(450, 441);
            this.pnlGraph.ResumeLayout(false);
            this.pnlGraph.PerformLayout();
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

        private System.Windows.Forms.TableLayoutPanel pnlGraph;
        private System.Windows.Forms.Button btnSelectObjs;
        private System.Windows.Forms.Button btnCreatePlot;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ComboBox comboBox;
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
