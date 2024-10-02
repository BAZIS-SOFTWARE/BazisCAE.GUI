namespace BaseModule
{
    partial class AdvanceSelectionSet
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
            this.rbtNodes = new System.Windows.Forms.RadioButton();
            this.rbtElements = new System.Windows.Forms.RadioButton();
            this.chbChangeDirection = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.rbtInPlain = new System.Windows.Forms.RadioButton();
            this.rbtInDirection = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtNodes
            // 
            this.rbtNodes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtNodes.AutoSize = true;
            this.rbtNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtNodes.Location = new System.Drawing.Point(181, 6);
            this.rbtNodes.Name = "rbtNodes";
            this.rbtNodes.Size = new System.Drawing.Size(53, 17);
            this.rbtNodes.TabIndex = 8;
            this.rbtNodes.TabStop = true;
            this.rbtNodes.Text = "Узлы";
            this.rbtNodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtNodes.UseVisualStyleBackColor = true;
            this.rbtNodes.Click += new System.EventHandler(this.rbtNodes_Click);
            // 
            // rbtElements
            // 
            this.rbtElements.AutoSize = true;
            this.rbtElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtElements.Location = new System.Drawing.Point(29, 6);
            this.rbtElements.Name = "rbtElements";
            this.rbtElements.Size = new System.Drawing.Size(77, 17);
            this.rbtElements.TabIndex = 5;
            this.rbtElements.TabStop = true;
            this.rbtElements.Text = "Элементы";
            this.rbtElements.UseVisualStyleBackColor = true;
            this.rbtElements.Click += new System.EventHandler(this.rbtElements_Click);
            // 
            // chbChangeDirection
            // 
            this.chbChangeDirection.AutoSize = true;
            this.chbChangeDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbChangeDirection.Location = new System.Drawing.Point(29, 37);
            this.chbChangeDirection.Name = "chbChangeDirection";
            this.chbChangeDirection.Size = new System.Drawing.Size(139, 17);
            this.chbChangeDirection.TabIndex = 10;
            this.chbChangeDirection.Text = "Сменить направление";
            this.chbChangeDirection.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.txbAngle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chbChangeDirection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 69);
            this.panel1.TabIndex = 9;
            // 
            // txbAngle
            // 
            this.txbAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAngle.Location = new System.Drawing.Point(68, 14);
            this.txbAngle.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.txbAngle.Name = "txbAngle";
            this.txbAngle.Size = new System.Drawing.Size(233, 20);
            this.txbAngle.TabIndex = 6;
            this.txbAngle.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Угол";
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect.Location = new System.Drawing.Point(199, 151);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(105, 32);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // rbtInPlain
            // 
            this.rbtInPlain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtInPlain.AutoSize = true;
            this.rbtInPlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtInPlain.Location = new System.Drawing.Point(181, 9);
            this.rbtInPlain.Name = "rbtInPlain";
            this.rbtInPlain.Size = new System.Drawing.Size(88, 17);
            this.rbtInPlain.TabIndex = 1;
            this.rbtInPlain.TabStop = true;
            this.rbtInPlain.Text = "В плоскости";
            this.rbtInPlain.UseVisualStyleBackColor = true;
            // 
            // rbtInDirection
            // 
            this.rbtInDirection.AutoSize = true;
            this.rbtInDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtInDirection.Location = new System.Drawing.Point(29, 11);
            this.rbtInDirection.Name = "rbtInDirection";
            this.rbtInDirection.Size = new System.Drawing.Size(110, 17);
            this.rbtInDirection.TabIndex = 0;
            this.rbtInDirection.TabStop = true;
            this.rbtInDirection.Text = "По направлению";
            this.rbtInDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtInDirection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbtInDirection.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.95373F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.04627F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelect, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 190);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.rbtElements);
            this.panel2.Controls.Add(this.rbtNodes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 26);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.rbtInDirection);
            this.panel3.Controls.Add(this.rbtInPlain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 31);
            this.panel3.TabIndex = 11;
            // 
            // SelectionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SelectionSet";
            this.Size = new System.Drawing.Size(311, 190);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtNodes;
        private System.Windows.Forms.RadioButton rbtElements;
        private System.Windows.Forms.CheckBox chbChangeDirection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtInDirection;
        private System.Windows.Forms.RadioButton rbtInPlain;
        private System.Windows.Forms.TextBox txbAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnSelect;
    }
}
