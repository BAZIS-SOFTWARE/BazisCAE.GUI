using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UserControlsEx;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    partial class LoadControlCreator
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
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKind = new UserControlsEx.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.chbX = new System.Windows.Forms.CheckBox();
            this.chbY = new System.Windows.Forms.CheckBox();
            this.chbZ = new System.Windows.Forms.CheckBox();
            this.chbLRF = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGr = new UserControlsEx.ComboBoxEx();
            this.cmbLoadFunction = new ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new Label();
            this.startLabel = new Label();
            this.stopLabel = new Label();
            this.txbStartTime = new TextBoxEx();
            this.txbStopTime = new TextBoxEx();
            this.txbValue = new UserControlsEx.TextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new GroupBox();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "generalTableLayoutPanel";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.6F));
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            #region "Параметры нагрузки"
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 13);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbKind, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chbX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chbY, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.chbZ, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.chbLRF, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbGr, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txbValue, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbLoadFunction, 1, 4);
            this.tableLayoutPanel2.SetColumnSpan(cmbLoadFunction, 4);
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
            this.cmbKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbKind, 4);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.TabIndex = 42;
            this.label3.Text = "Направление";
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Margin = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.chbX.Name = "chbX";
            this.chbX.TabIndex = 0;
            this.chbX.Tag = "0";
            this.chbX.Text = "X";
            this.chbX.UseVisualStyleBackColor = true;
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Margin = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.chbY.Name = "chbY";
            this.chbY.TabIndex = 0;
            this.chbY.Tag = "1";
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            // 
            // chbZ
            // 
            this.chbZ.AutoSize = true;
            this.chbZ.Margin = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.chbZ.Name = "chbZ";
            this.chbZ.TabIndex = 0;
            this.chbZ.Tag = "2";
            this.chbZ.Text = "Z";
            this.chbZ.UseVisualStyleBackColor = true;
            // 
            // chbLRF
            // 
            this.chbLRF.AutoSize = true;
            this.chbLRF.Margin = new System.Windows.Forms.Padding(0, 10, 15, 0);
            this.chbLRF.Name = "chbLRF";
            this.chbLRF.TabIndex = 0;
            this.chbLRF.Tag = "3";
            this.chbLRF.Text = "Произвольное";
            this.chbLRF.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.TabIndex = 42;
            this.label1.Text = "Группа объектов";
            // 
            // cmbGr
            // 
            this.cmbGr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbGr, 4);
            this.cmbGr.FormattingEnabled = true;
            this.cmbGr.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbGr.IsValidating = true;
            this.cmbGr.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbGr.Name = "cmbGr";
            this.cmbGr.TabIndex = 43;
            this.cmbGr.UserRegExCheck = null;
            this.cmbGr.UserRegExCheckErrorMessage = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.TabIndex = 42;
            this.label4.Text = "Величина, Н";
            // 
            // txbValue
            // 
            this.txbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.txbValue, 4);
            this.txbValue.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbValue.IsValidating = true;
            this.txbValue.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbValue.Name = "txbValue";
            this.txbValue.TabIndex = 0;
            this.txbValue.UserRegExCheck = null;
            this.txbValue.UserRegExCheckErrorMessage = null;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.MinimumSize = new System.Drawing.Size(350, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры нагрузки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label5.Name = "label10";
            this.label5.TabIndex = 32;
            this.label5.Text = "Функция, F(t), Н - сек.";
            // 
            // cmbLoadFunction
            // 
            this.cmbLoadFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLoadFunction.FormattingEnabled = true;
            this.cmbLoadFunction.InputType = ((UserControlsEx.CMBInputType)(((UserControlsEx.CMBInputType.Items | UserControlsEx.CMBInputType.Float)
            | UserControlsEx.CMBInputType.Empty)));
            this.cmbLoadFunction.IsValidating = true;
            this.cmbLoadFunction.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbLoadFunction.Name = "cmbLoadFunction";
            this.cmbLoadFunction.TabIndex = 36;
            this.cmbLoadFunction.UserRegExCheck = null;
            this.cmbLoadFunction.UserRegExCheckErrorMessage = null;
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
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox3.MinimumSize = new System.Drawing.Size(350, 0);
            this.groupBox3.Name = "groupBox1";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
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
            // LoadControlCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoadControlCreator";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label startLabel;
        private Label stopLabel;
        private System.Windows.Forms.CheckBox chbX;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbZ;
        private System.Windows.Forms.CheckBox chbLRF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private TextBoxEx txbValue;
        private TextBoxEx txbStartTime;
        private TextBoxEx txbStopTime;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBoxEx cmbKind;
        private ComboBoxEx cmbGr;
        private ComboBoxEx cmbLoadFunction;
    }
}
