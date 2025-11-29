using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI.Tasks.TasksFromNavigator.Controls
{
    partial class MediaControlCreator
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel3 = new TableLayoutPanel();
            generalTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelRadioButton = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            startLabel = new System.Windows.Forms.Label();
            stopLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txbStartTime = new TextBoxEx();
            txbStopTime = new TextBoxEx();
            txbMediaTemp = new TextBoxEx();
            groupBox3 = new System.Windows.Forms.GroupBox();
            grbHeatFlux = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBoxSelect = new System.Windows.Forms.GroupBox();
            rbtTermoCycle = new System.Windows.Forms.RadioButton();
            rbtHeatFlow = new System.Windows.Forms.RadioButton();
            cmbEl = new ComboBoxEx();
            cmbFunc = new ComboBoxEx();
            cmbTermoCycle = new ComboBoxEx();
            cmbNode = new ComboBoxEx();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            generalTableLayoutPanel.SuspendLayout();
            panelRadioButton.SuspendLayout();
            groupBoxSelect.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            grbHeatFlux.SuspendLayout();
            // 
            // generalTableLayoutPanel
            // 
            generalTableLayoutPanel.AutoSize = true;
            generalTableLayoutPanel.ColumnCount = 1;
            generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            generalTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            generalTableLayoutPanel.RowCount = 4;
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.TabIndex = 0;
            generalTableLayoutPanel.Controls.Add(groupBoxSelect, 0, 0);
            generalTableLayoutPanel.Controls.Add(grbHeatFlux, 0, 1);
            generalTableLayoutPanel.Controls.Add(groupBox2, 0, 2);
            generalTableLayoutPanel.Controls.Add(groupBox3, 0, 3);
            #region "Вид условия"
            // 
            // groupBox4
            // 
            groupBoxSelect.AutoSize = true;
            groupBoxSelect.Controls.Add(panelRadioButton);
            groupBoxSelect.Dock = DockStyle.Fill;
            groupBoxSelect.Margin = new Padding(4, 3, 4, 3);
            groupBoxSelect.Name = "groupBoxSelect";
            groupBoxSelect.Padding = new Padding(4, 3, 4, 3);
            groupBoxSelect.TabIndex = 21;
            groupBoxSelect.TabStop = false;
            groupBoxSelect.Text = "Вид условия";
            //
            // panelRadioButton
            //
            panelRadioButton.AutoSize = true;
            panelRadioButton.FlowDirection = FlowDirection.LeftToRight;
            panelRadioButton.WrapContents = false;
            panelRadioButton.Name = "panelRadioButton";
            panelRadioButton.Dock = DockStyle.Fill;
            panelRadioButton.Controls.Add(rbtHeatFlow);
            panelRadioButton.Controls.Add(rbtTermoCycle);
            // 
            // rbtTermoCycle
            // 
            rbtTermoCycle.AutoSize = true;
            rbtTermoCycle.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            rbtTermoCycle.Name = "rbtTermoCycle";
            rbtTermoCycle.TabIndex = 21;
            rbtTermoCycle.TabStop = true;
            rbtTermoCycle.Text = "Термоцикл";
            rbtTermoCycle.UseVisualStyleBackColor = true;
            rbtTermoCycle.CheckedChanged += new System.EventHandler(this.termocycleRadioButton_CheckedChanged);
            // 
            // rbtHeatFlow
            // 
            rbtHeatFlow.AutoSize = true;
            rbtHeatFlow.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            rbtHeatFlow.Name = "rbtHeatFlow";
            rbtHeatFlow.TabIndex = 20;
            rbtHeatFlow.TabStop = true;
            rbtHeatFlow.Text = "Тепловой поток";
            rbtHeatFlow.Checked = true;
            rbtHeatFlow.UseVisualStyleBackColor = true;
            rbtHeatFlow.CheckedChanged += new System.EventHandler(this.mediaRadioButton_CheckedChanged);
            #endregion
            #region "Тепловой поток"
            // 
            // grbHeatFlux
            // 
            grbHeatFlux.AutoSize = true;
            grbHeatFlux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            grbHeatFlux.Controls.Add(this.tableLayoutPanel1);
            grbHeatFlux.Dock = System.Windows.Forms.DockStyle.Fill;
            grbHeatFlux.Margin = new Padding(4, 3, 4, 3);
            grbHeatFlux.MinimumSize = new System.Drawing.Size(0, 10);
            grbHeatFlux.Name = "grbHeatFlux";
            grbHeatFlux.Padding = new Padding(4, 3, 4, 3);
            grbHeatFlux.TabIndex = 18;
            grbHeatFlux.TabStop = false;
            grbHeatFlux.Text = "Параметры теплового потока";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel3";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbEl, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(cmbFunc, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(txbMediaTemp, 1, 2);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            label2.Name = "label2";
            label2.TabIndex = 20;
            label2.Text = "Группа элементов";
            // 
            // cmbEl
            // 
            cmbEl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbEl.FormattingEnabled = true;
            cmbEl.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEl.InputType = UserControlsEx.CMBInputType.Items;
            cmbEl.IsValidating = true;
            cmbEl.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbEl.Name = "cmbEl";
            cmbEl.TabIndex = 14;
            cmbEl.UserRegExCheck = null;
            cmbEl.UserRegExCheckErrorMessage = null;
            // 
            // cmbFunc
            // 
            cmbFunc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbFunc.FormattingEnabled = true;
            cmbFunc.InputType = UserControlsEx.CMBInputType.Items;
            cmbFunc.IsValidating = true;
            cmbFunc.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbFunc.Name = "cmbFunc";
            cmbFunc.TabIndex = 17;
            cmbFunc.UserRegExCheck = null;
            cmbFunc.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            label1.Name = "label1";
            label1.TabIndex = 19;
            label1.Text = "Коэф. теплоотдачи, Вт/мм2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            label5.Name = "label5";
            label5.TabIndex = 22;
            label5.Text = "Температура среды, °C";
            // 
            // txbMediaTemp
            // 
            txbMediaTemp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbMediaTemp.BackColor = System.Drawing.SystemColors.Window;
            txbMediaTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMediaTemp.InputType = UserControlsEx.TXTBoxInputType.Float;
            txbMediaTemp.IsValidating = true;
            txbMediaTemp.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbMediaTemp.Name = "txbMediaTemp";
            txbMediaTemp.TabIndex = 21;
            txbMediaTemp.UserRegExCheck = null;
            txbMediaTemp.UserRegExCheckErrorMessage = null;
            #endregion
            #region "Термоцикл"
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(cmbNode, 1, 0);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(cmbTermoCycle, 1, 1);
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры термоцикла";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            label7.Name = "label7";
            label7.TabIndex = 25;
            label7.Text = "Группа узлов";
            // 
            // cmbNode
            // 
            cmbNode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbNode.FormattingEnabled = true;
            cmbNode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNode.InputType = UserControlsEx.CMBInputType.Items;
            cmbNode.IsValidating = true;
            cmbNode.Items.AddRange(new object[] { "node" });
            cmbNode.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbNode.Name = "cmbNode";
            cmbNode.TabIndex = 19;
            cmbNode.UserRegExCheck = null;
            cmbNode.UserRegExCheckErrorMessage = null;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            label6.Name = "label6";
            label6.TabIndex = 24;
            label6.Text = "Функция, F(t), °С - сек.";
            // 
            // cmbTermoCycle
            // 
            cmbTermoCycle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTermoCycle.FormattingEnabled = true;
            cmbTermoCycle.InputType = UserControlsEx.CMBInputType.Items | UserControlsEx.CMBInputType.Float;
            cmbTermoCycle.IsValidating = true;
            cmbTermoCycle.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbTermoCycle.Name = "cmbTermoCycle";
            cmbTermoCycle.TabIndex = 26;
            cmbTermoCycle.UserRegExCheck = null;
            cmbTermoCycle.UserRegExCheckErrorMessage = null;
            #endregion
            #region "Время действия"
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.TabIndex = 0;
            tableLayoutPanel3.Controls.Add(startLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(txbStartTime, 1, 0);
            tableLayoutPanel3.Controls.Add(stopLabel, 0, 1);
            tableLayoutPanel3.Controls.Add(txbStopTime, 1, 1);

            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(tableLayoutPanel3);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "Время действия";
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            startLabel.Name = "startLabel";
            startLabel.TabIndex = 3;
            startLabel.Text = "Старт, сек.";
            startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStartTime
            // 
            txbStartTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbStartTime.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbStartTime.IsValidating = true;
            txbStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbStartTime.Name = "txbStartTime";
            txbStartTime.TabIndex = 0;
            txbStartTime.UserRegExCheck = null;
            txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // stopLabel
            // 
            stopLabel.AutoSize = true;
            stopLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            stopLabel.Name = "stopLabel";
            stopLabel.TabIndex = 4;
            stopLabel.Text = "Стоп, сек.";
            stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStopTime
            // 
            txbStopTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbStopTime.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbStopTime.IsValidating = true;
            txbStopTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbStopTime.Name = "txbStopTime";
            txbStopTime.TabIndex = 1;
            txbStopTime.UserRegExCheck = null;
            txbStopTime.UserRegExCheckErrorMessage = null;
            #endregion
            // 
            // MediaControlCreator
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            //Size = new System.Drawing.Size(600, 400);
            Controls.Add(generalTableLayoutPanel);
            Name = "MediaControlCreator";
            generalTableLayoutPanel.ResumeLayout(false);
            generalTableLayoutPanel.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelRadioButton.ResumeLayout(false);
            panelRadioButton.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grbHeatFlux.ResumeLayout(false);
            grbHeatFlux.PerformLayout();
            groupBoxSelect.ResumeLayout(false);
            groupBoxSelect.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel generalTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel panelRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.GroupBox grbHeatFlux;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtTermoCycle;
        private System.Windows.Forms.RadioButton rbtHeatFlow;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private TextBoxEx txbStartTime;
        private TextBoxEx txbMediaTemp;
        private TextBoxEx txbStopTime;
        private ComboBoxEx cmbEl;
        private ComboBoxEx cmbFunc;
        private ComboBoxEx cmbTermoCycle;
        private ComboBoxEx cmbNode;
    }
}
