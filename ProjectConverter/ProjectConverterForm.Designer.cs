namespace ProjectConverter
{
    partial class ProjectConverterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            generalPanel = new TableLayoutPanel();
            label1 = new Label();
            txbPath = new TextBox();
            btnConvert = new Button();
            btnSelect = new Button();
            separatorLine = new Panel();
            lbStatus = new Label();
            txbStatus = new RichTextBox();
            generalPanel.SuspendLayout();
            SuspendLayout();
            // 
            // generalPanel
            // 
            generalPanel.ColumnCount = 2;
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            generalPanel.Controls.Add(label1, 0, 0);
            generalPanel.Controls.Add(txbPath, 0, 1);
            generalPanel.Controls.Add(btnConvert, 0, 2);
            generalPanel.Controls.Add(btnSelect, 1, 1);
            generalPanel.Controls.Add(separatorLine, 0, 3);
            generalPanel.Controls.Add(lbStatus, 0, 4);
            generalPanel.Controls.Add(txbStatus, 0, 5);
            generalPanel.Dock = DockStyle.Fill;
            generalPanel.Location = new Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.Padding = new Padding(20);
            generalPanel.RowCount = 6;
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.RowStyles.Add(new RowStyle());
            generalPanel.Size = new Size(450, 250);
            generalPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Margin = new Padding(0, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "Путь к проекту: ";
            // 
            // txbPath
            // 
            txbPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbPath.BorderStyle = BorderStyle.FixedSingle;
            txbPath.Location = new Point(20, 43);
            txbPath.Margin = new Padding(0, 8, 3, 0);
            txbPath.Multiline = true;
            txbPath.Name = "txbPath";
            txbPath.ReadOnly = true;
            txbPath.Size = new Size(284, 30);
            txbPath.TabIndex = 1;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConvert.BackColor = Color.Gainsboro;
            generalPanel.SetColumnSpan(btnConvert, 2);
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Location = new Point(80, 83);
            btnConvert.Margin = new Padding(60, 10, 60, 10);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(290, 50);
            btnConvert.TabIndex = 2;
            btnConvert.Text = "Конвертировать";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConverter_Click;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Location = new Point(310, 43);
            btnSelect.Margin = new Padding(3, 8, 0, 0);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(120, 30);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Выбрать проект";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // separatorLine
            // 
            separatorLine.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            separatorLine.BackColor = Color.Gray;
            generalPanel.SetColumnSpan(separatorLine, 2);
            separatorLine.Location = new Point(20, 143);
            separatorLine.Margin = new Padding(0);
            separatorLine.Name = "separatorLine";
            separatorLine.Size = new Size(410, 2);
            separatorLine.TabIndex = 4;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(20, 148);
            lbStatus.Margin = new Padding(0, 3, 0, 0);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(46, 15);
            lbStatus.TabIndex = 0;
            lbStatus.Text = "Статус:";
            // 
            // txbStatus
            // 
            txbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txbStatus.BorderStyle = BorderStyle.FixedSingle;
            generalPanel.SetColumnSpan(txbStatus, 2);
            txbStatus.Location = new Point(20, 166);
            txbStatus.Margin = new Padding(0, 3, 0, 20);
            txbStatus.Name = "txbStatus";
            txbStatus.ReadOnly = true;
            txbStatus.Size = new Size(410, 71);
            txbStatus.TabIndex = 1;
            txbStatus.Text = "Конвертация не выполнялась...";
            // 
            // ProjectConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 250);
            Controls.Add(generalPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProjectConverterForm";
            Text = "Конвертер проектов";
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel generalPanel;
        private Panel separatorLine;
        private Label label1;
        private TextBox txbPath;
        private RichTextBox txbStatus;
        private Button btnConvert;
        private Button btnSelect;
        private Label lbStatus;
    }
}
