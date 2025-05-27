using System;
using System.Windows.Forms;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    partial class ClampControlCreator
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
            this.components = new System.ComponentModel.Container();
            generalTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            startLabel = new Label();
            stopLabel = new Label();
            txbStartTime = new TextBoxEx();
            txbStopTime = new TextBoxEx();
            chbX = new System.Windows.Forms.CheckBox();
            chbY = new System.Windows.Forms.CheckBox();
            chbZ = new System.Windows.Forms.CheckBox();
            chbLRF = new System.Windows.Forms.CheckBox();
            cmbNodeGr = new ComboBoxEx();
            cmbKind = new ComboBoxEx();
            cmbStiffnessFunc = new ComboBoxEx();
            this.generalTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.AutoSize = true;
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 3;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.generalTableLayoutPanel.TabIndex = 0;
            this.generalTableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this.generalTableLayoutPanel.Controls.Add(this.groupBox2, 0, 1);
            this.generalTableLayoutPanel.Controls.Add(this.groupBox3, 0, 2);
            #region "Вид закрепления"
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "generalTableLayoutPanel";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbNodeGr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbKind, 1, 1);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид закрепления";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.TabIndex = 42;
            this.label1.Text = "Группа узлов";
            // 
            // cmbNodeGr
            // 
            this.cmbNodeGr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbNodeGr.FormattingEnabled = true;
            this.cmbNodeGr.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbNodeGr.IsValidating = true;
            this.cmbNodeGr.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbNodeGr.Name = "cmbNodeGr";
            this.cmbNodeGr.TabIndex = 43;
            this.cmbNodeGr.UserRegExCheck = null;
            this.cmbNodeGr.UserRegExCheckErrorMessage = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.TabIndex = 37;
            this.label2.Text = "Вид";
            // 
            // cmbKind
            // 
            this.cmbKind.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbKind.FormattingEnabled = true;
            this.cmbKind.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbKind.IsValidating = true;
            this.cmbKind.Items.AddRange(new object[] {
            "Жесткое"});
            this.cmbKind.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.TabIndex = 36;
            this.cmbKind.UserRegExCheck = null;
            this.cmbKind.UserRegExCheckErrorMessage = null;
            this.cmbKind.SelectedIndexChanged += new System.EventHandler(this.kindComboBox_SelectedIndexChanged);
            #endregion
            #region "Параметры закрепления"
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbY, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbZ, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbLRF, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbStiffnessFunc, 1, 1);
            this.tableLayoutPanel2.SetColumnSpan(cmbStiffnessFunc, 4);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.MinimumSize = new System.Drawing.Size(350, 0);
            this.groupBox2.Name = "groupBox1";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид закрепления";
            // 
            // label1
            // 
            this.label3.AutoSize = true;
            this.label3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.TabIndex = 42;
            this.label3.Text = "Направление";
            // 
            // chbLRF
            // 
            this.chbLRF.AutoSize = true;
            this.chbLRF.Name = "chbLRF";
            this.chbLRF.Margin = new Padding(0, 10, 15, 0);
            this.chbLRF.TabIndex = 0;
            this.chbLRF.Tag = "3";
            this.chbLRF.Text = "Произвольное";
            this.chbLRF.UseVisualStyleBackColor = true;
            this.chbLRF.EnabledChanged += new System.EventHandler(this.chbLRF_EnabledChanged);
            this.chbLRF.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbZ
            // 
            this.chbZ.AutoSize = true;
            this.chbZ.Name = "chbZ";
            this.chbZ.Margin = new Padding(15, 10, 0, 0);
            this.chbZ.TabIndex = 0;
            this.chbZ.Tag = "2";
            this.chbZ.Text = "Z";
            this.chbZ.UseVisualStyleBackColor = true;
            this.chbZ.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Name = "chbY";
            this.chbY.Margin = new Padding(15, 10, 0, 0);
            this.chbY.TabIndex = 0;
            this.chbY.Tag = "1";
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            this.chbY.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Name = "chbX";
            this.chbX.Margin = new Padding(15, 10, 0, 0);
            this.chbX.TabIndex = 0;
            this.chbX.Tag = "0";
            this.chbX.Text = "X";
            this.chbX.UseVisualStyleBackColor = true;
            this.chbX.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.TabIndex = 37;
            this.label4.Text = "Функция, F(u) , Н.мм - у.ед.";
            // 
            // cmbStiffnessFunc
            // 
            this.cmbStiffnessFunc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbStiffnessFunc.Enabled = false;
            this.cmbStiffnessFunc.FormattingEnabled = true;
            this.cmbStiffnessFunc.InputType = ((UserControlsEx.CMBInputType)(((UserControlsEx.CMBInputType.Items | UserControlsEx.CMBInputType.Float)
            | UserControlsEx.CMBInputType.Empty)));
            this.cmbStiffnessFunc.IsValidating = true;
            this.cmbStiffnessFunc.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cmbStiffnessFunc.Name = "cmbStiffnessFunc";
            this.cmbStiffnessFunc.TabIndex = 1;
            this.cmbStiffnessFunc.UserRegExCheck = null;
            this.cmbStiffnessFunc.UserRegExCheckErrorMessage = null;
            #endregion
            #region "Время действия"
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.TabIndex = 0;
            this.tableLayoutPanel3.Controls.Add(this.startLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbStartTime, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.stopLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txbStopTime, 1, 1);

            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.MinimumSize = new System.Drawing.Size(350, 0);
            this.groupBox3.Name = "groupBox1";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Время действия";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.TabIndex = 3;
            this.startLabel.Text = "Старт, сек.";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStartTime.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStartTime.IsValidating = true;
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.TabIndex = 0;
            this.txbStartTime.UserRegExCheck = null;
            this.txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.TabIndex = 4;
            this.stopLabel.Text = "Стоп, сек.";
            this.stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStopTime.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStopTime.IsValidating = true;
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.TabIndex = 1;
            this.txbStopTime.UserRegExCheck = null;
            this.txbStopTime.UserRegExCheckErrorMessage = null;
            #endregion
            //
            // ClampControl
            //
            this.AutoSize = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.generalTableLayoutPanel);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
        }

        #endregion
        private TableLayoutPanel generalTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label startLabel;
        private Label stopLabel;
        private ComboBoxEx cmbNodeGr;
        private ComboBoxEx cmbKind;
        private ComboBoxEx cmbStiffnessFunc;
        private TextBoxEx txbStartTime;
        private TextBoxEx txbStopTime;
        private System.Windows.Forms.CheckBox chbX;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbZ;
        private System.Windows.Forms.CheckBox chbLRF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
