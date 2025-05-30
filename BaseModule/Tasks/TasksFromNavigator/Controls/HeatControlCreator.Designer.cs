using BaseModule.Properties;
using System.Drawing;
using System.Windows.Forms;
using TaskModule.WeldingModule.WeldingTypeControls;
using UserControlsEx;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    partial class HeatControlCreator
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
            panelRadioButton2 = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            currentLabel = new System.Windows.Forms.Label();
            voltageLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            widthLabel = new System.Windows.Forms.Label();
            powerLabel = new System.Windows.Forms.Label();
            depthLabel = new System.Windows.Forms.Label();
            baseDiameterLabel = new System.Windows.Forms.Label();
            endDiameterLabel = new System.Windows.Forms.Label();
            txbWidth = new TextBoxEx();
            txbCurrent = new TextBoxEx();
            txbVoltage = new TextBoxEx();
            txbMediaTemp = new TextBoxEx();
            txbPower = new TextBoxEx();
            txbDepth = new TextBoxEx();
            txbBaseDiameter = new TextBoxEx();
            txbEndDiameter = new TextBoxEx();
            groupBox3 = new System.Windows.Forms.GroupBox();
            grbGroup = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBoxSelect = new System.Windows.Forms.GroupBox();
            rbtARC = new System.Windows.Forms.RadioButton();
            rbtFS = new System.Windows.Forms.RadioButton();
            rbtLW = new System.Windows.Forms.RadioButton();
            cmbEl = new ComboBoxEx();
            cmbFunc = new ComboBoxEx();
            cmbTermoCycle = new ComboBoxEx();
            cmbNode = new ComboBoxEx();


            this.btnInfo = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbFrictionModule = new UserControlsEx.ComboBoxEx(this.components);
            this.txbAxisForce = new UserControlsEx.TextBoxEx(this.components);
            this.txbPinUpperDiam = new UserControlsEx.TextBoxEx(this.components);
            this.txbPinBottomDiam = new UserControlsEx.TextBoxEx(this.components);
            this.txbPinLenght = new UserControlsEx.TextBoxEx(this.components);
            this.txbShoulderDiam = new UserControlsEx.TextBoxEx(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txbRotSpeed = new UserControlsEx.TextBoxEx(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbYield = new UserControlsEx.ComboBoxEx(this.components);
            this.rbtPin = new System.Windows.Forms.RadioButton();
            this.rbtShoulder = new System.Windows.Forms.RadioButton();


            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            generalTableLayoutPanel.SuspendLayout();
            panelRadioButton.SuspendLayout();
            panelRadioButton2.SuspendLayout();
            groupBoxSelect.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            grbGroup.SuspendLayout();
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
            generalTableLayoutPanel.RowCount = 3;
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            generalTableLayoutPanel.TabIndex = 0;
            generalTableLayoutPanel.Controls.Add(groupBoxSelect, 0, 0);
            generalTableLayoutPanel.Controls.Add(grbGroup, 0, 1);
            generalTableLayoutPanel.Controls.Add(groupBox3, 0, 2);
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
            panelRadioButton.Controls.Add(rbtARC);
            panelRadioButton.Controls.Add(rbtLW);
            panelRadioButton.Controls.Add(rbtFS);
            // 
            // rbtARC
            // 
            rbtARC.AutoSize = true;
            rbtARC.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            rbtARC.Name = "rbtARC";
            rbtARC.AccessibleName = "rbtARC";
            rbtARC.TabIndex = 21;
            rbtARC.TabStop = true;
            rbtARC.Text = "Дуговая сварка";
            rbtARC.Checked = true;
            rbtARC.UseVisualStyleBackColor = true;
            rbtARC.CheckedChanged += SelectingHeatingSource;
            // 
            // rbtLW
            // 
            rbtLW.AutoSize = true;
            rbtLW.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            rbtLW.Name = "rbtLW";
            rbtLW.AccessibleName = "rbtLW";
            rbtLW.TabIndex = 20;
            rbtLW.TabStop = true;
            rbtLW.Text = "Лазерная сварка";
            rbtLW.Checked = false;
            rbtLW.UseVisualStyleBackColor = true;
            rbtLW.CheckedChanged += SelectingHeatingSource;
            // 
            // rbtFS
            // 
            rbtFS.AutoSize = true;
            rbtFS.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            rbtFS.Name = "rbtFS";
            rbtFS.AccessibleName = "rbtFS";
            rbtFS.TabIndex = 20;
            rbtFS.TabStop = true;
            rbtFS.Text = "Трением с перемешиванием";
            rbtFS.UseVisualStyleBackColor = true;
            rbtFS.CheckedChanged += SelectingHeatingSource;
            #endregion
            #region "Область действия"
            // 
            // grbHeatFlux
            // 
            grbGroup.AutoSize = true;
            grbGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            grbGroup.Controls.Add(this.tableLayoutPanel1);
            grbGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            grbGroup.Margin = new Padding(4, 3, 4, 3);
            grbGroup.MinimumSize = new System.Drawing.Size(0, 10);
            grbGroup.Name = "grbHeatFlux";
            grbGroup.Padding = new Padding(4, 3, 4, 3);
            grbGroup.TabIndex = 18;
            grbGroup.TabStop = false;
            grbGroup.Text = "Область действия";
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
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbEl, 1, 0);
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
            cmbEl.AccessibleName = "cmbEl";
            cmbEl.TabIndex = 14;
            cmbEl.UserRegExCheck = null;
            cmbEl.UserRegExCheckErrorMessage = null;
            #endregion
            #region "Параметры источников"
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
            groupBox3.Text = "Параметры источника";
            #region "ARC"
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
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            tableLayoutPanel3.TabIndex = 0;
            tableLayoutPanel3.Controls.Add(currentLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(txbCurrent, 1, 0);
            tableLayoutPanel3.Controls.Add(voltageLabel, 0, 1);
            tableLayoutPanel3.Controls.Add(txbVoltage, 1, 1);
            tableLayoutPanel3.Controls.Add(widthLabel, 0, 2);
            tableLayoutPanel3.Controls.Add(txbWidth, 1, 2);
            // 
            // currentLabel
            // 
            currentLabel.AutoSize = true;
            currentLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            currentLabel.Name = "currentLabel";
            currentLabel.TabIndex = 3;
            currentLabel.Text = "Ток, А";
            currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbCurrent
            // 
            txbCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbCurrent.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbCurrent.IsValidating = true;
            txbCurrent.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbCurrent.Name = "txbCurrent";
            txbCurrent.AccessibleName = "txbCurrent";
            txbCurrent.TabIndex = 0;
            txbCurrent.UserRegExCheck = null;
            txbCurrent.UserRegExCheckErrorMessage = null;
            // 
            // voltageLabel
            // 
            voltageLabel.AutoSize = true;
            voltageLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            voltageLabel.Name = "voltageLabel";
            voltageLabel.TabIndex = 4;
            voltageLabel.Text = "Напряжение, В";
            voltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbVoltage
            // 
            txbVoltage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbVoltage.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbVoltage.IsValidating = true;
            txbVoltage.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbVoltage.Name = "txbVoltage";
            txbVoltage.AccessibleName = "txbVoltage";
            txbVoltage.TabIndex = 1;
            txbVoltage.UserRegExCheck = null;
            txbVoltage.UserRegExCheckErrorMessage = null;
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            widthLabel.Name = "widthLabel";
            widthLabel.TabIndex = 3;
            widthLabel.Text = "Ширина шва (L), мм";
            widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbCurrent
            // 
            txbWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbWidth.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbWidth.IsValidating = true;
            txbWidth.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbWidth.Name = "txbWidth";
            txbWidth.AccessibleName = "txbWidth";
            txbWidth.TabIndex = 0;
            txbWidth.UserRegExCheck = null;
            txbWidth.UserRegExCheckErrorMessage = null;
            #endregion
            #region "LW"
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
            tableLayoutPanel2.Name = "tableLayoutPanel3";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.Controls.Add(powerLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(txbPower, 1, 0);
            tableLayoutPanel2.Controls.Add(depthLabel, 0, 1);
            tableLayoutPanel2.Controls.Add(txbDepth, 1, 1);
            tableLayoutPanel2.Controls.Add(baseDiameterLabel, 0, 2);
            tableLayoutPanel2.Controls.Add(txbBaseDiameter, 1, 2);
            tableLayoutPanel2.Controls.Add(endDiameterLabel, 0, 3);
            tableLayoutPanel2.Controls.Add(txbEndDiameter, 1, 3);
            // 
            // currentLabel
            // 
            powerLabel.AutoSize = true;
            powerLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            powerLabel.Name = "powerLabel";
            powerLabel.TabIndex = 3;
            powerLabel.Text = "Мощность излучения, Дж";
            powerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbCurrent
            // 
            txbPower.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbPower.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbPower.IsValidating = true;
            txbPower.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbPower.Name = "txbPower";
            txbPower.AccessibleName = "txbPower";
            txbPower.TabIndex = 0;
            txbPower.UserRegExCheck = null;
            txbPower.UserRegExCheckErrorMessage = null;
            // 
            // depthLabel
            // 
            depthLabel.AutoSize = true;
            depthLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            depthLabel.Name = "depthLabel";
            depthLabel.TabIndex = 4;
            depthLabel.Text = "Глубина проплавления (L), мм";
            depthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbDepth
            // 
            txbDepth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbDepth.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbDepth.IsValidating = true;
            txbDepth.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbDepth.Name = "txbDepth";
            txbDepth.AccessibleName = "txbDepth";
            txbDepth.TabIndex = 1;
            txbDepth.UserRegExCheck = null;
            txbDepth.UserRegExCheckErrorMessage = null;
            // 
            // baseDiameterLabel
            // 
            baseDiameterLabel.AutoSize = true;
            baseDiameterLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            baseDiameterLabel.Name = "baseDiameterLabel";
            baseDiameterLabel.TabIndex = 3;
            baseDiameterLabel.Text = "Диаметр основания (D2), мм";
            baseDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbBaseDiameter
            // 
            txbBaseDiameter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbBaseDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbBaseDiameter.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbBaseDiameter.IsValidating = true;
            txbBaseDiameter.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbBaseDiameter.Name = "txbBaseDiameter";
            txbBaseDiameter.AccessibleName = "txbBaseDiameter";
            txbBaseDiameter.TabIndex = 0;
            txbBaseDiameter.UserRegExCheck = null;
            txbBaseDiameter.UserRegExCheckErrorMessage = null;
            // 
            // endDiameterLabel
            // 
            endDiameterLabel.AutoSize = true;
            endDiameterLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            endDiameterLabel.Name = "endDiameterLabel";
            endDiameterLabel.TabIndex = 3;
            endDiameterLabel.Text = "Диаметр конца (D3), мм";
            endDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbEndDiameter
            // 
            txbEndDiameter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbEndDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbEndDiameter.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbEndDiameter.IsValidating = true;
            txbEndDiameter.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbEndDiameter.Name = "txbEndDiameter";
            txbEndDiameter.AccessibleName = "txbEndDiameter";
            txbEndDiameter.TabIndex = 0;
            txbEndDiameter.UserRegExCheck = null;
            txbEndDiameter.UserRegExCheckErrorMessage = null;
            #endregion
            #region "FSW"
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanel4.Name = "tableLayoutPanel3";
            tableLayoutPanel4.RowCount = 10;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());

            tableLayoutPanel4.TabIndex = 0;
            tableLayoutPanel4.Controls.Add(panelRadioButton2, 0, 0);
            tableLayoutPanel4.SetColumnSpan(panelRadioButton2, 2);
            tableLayoutPanel4.Controls.Add(label11, 0, 1);
            tableLayoutPanel4.Controls.Add(txbRotSpeed, 1, 1);
            tableLayoutPanel4.Controls.Add(label18, 0, 2);
            tableLayoutPanel4.Controls.Add(txbAxisForce, 1, 2);
            tableLayoutPanel4.Controls.Add(label3, 0, 3);
            tableLayoutPanel4.Controls.Add(txbShoulderDiam, 1, 3);
            tableLayoutPanel4.Controls.Add(label12, 0, 4);
            tableLayoutPanel4.Controls.Add(txbPinLenght, 1, 4);
            tableLayoutPanel4.Controls.Add(label15, 0, 5);
            tableLayoutPanel4.Controls.Add(txbPinUpperDiam, 1, 5);
            tableLayoutPanel4.Controls.Add(label16, 0, 6);
            tableLayoutPanel4.Controls.Add(txbPinBottomDiam, 1, 6);
            tableLayoutPanel4.Controls.Add(label17, 0, 7);
            tableLayoutPanel4.Controls.Add(cmbFrictionModule, 1, 7);
            tableLayoutPanel4.Controls.Add(label19, 0, 8);
            tableLayoutPanel4.Controls.Add(cmbYield, 1, 8);
            tableLayoutPanel4.Controls.Add(btnInfo, 0, 9);
            //
            // panelRadioButton2
            //
            panelRadioButton2.AutoSize = true;
            panelRadioButton2.FlowDirection = FlowDirection.LeftToRight;
            panelRadioButton2.WrapContents = false;
            panelRadioButton2.Name = "panelRadioButton2";
            panelRadioButton2.Dock = DockStyle.Fill;
            panelRadioButton2.Controls.Add(rbtPin);
            panelRadioButton2.Controls.Add(rbtShoulder);
            // 
            // btnInfo
            // 
            Icon ic = SystemIcons.Question;
            Bitmap scale = new Bitmap(ic.ToBitmap(), new Size(18, 18));
            this.btnInfo.Image = scale;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(27, 27);
            this.btnInfo.TabIndex = 64;
            this.btnInfo.UseVisualStyleBackColor = true;
            //this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label17.Name = "label2";
            this.label17.TabIndex = 63;
            this.label17.Text = "Коэффициент трения";
            // 
            // cmbFrictionModule
            // 
            this.cmbFrictionModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFrictionModule.FormattingEnabled = true;
            this.cmbFrictionModule.InputType = ((UserControlsEx.CMBInputType)((UserControlsEx.CMBInputType.Items | UserControlsEx.CMBInputType.Float)));
            this.cmbFrictionModule.IsValidating = true;
            this.cmbFrictionModule.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbFrictionModule.Name = "cmbFrictionModule";
            this.cmbFrictionModule.AccessibleName = "cmbFrictionModule";
            this.cmbFrictionModule.TabIndex = 62;
            this.cmbFrictionModule.UserRegExCheck = null;
            this.cmbFrictionModule.UserRegExCheckErrorMessage = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label18.Name = "label18";
            this.label18.TabIndex = 60;
            this.label18.Text = "Осевое усилие, Н";
            // 
            // txbAxisForce
            // 
            this.txbAxisForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAxisForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAxisForce.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbAxisForce.IsValidating = true;
            this.txbAxisForce.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbAxisForce.Name = "txbAxisForce";
            this.txbAxisForce.AccessibleName = "txbAxisForce";
            this.txbAxisForce.TabIndex = 59;
            this.txbAxisForce.UserRegExCheck = null;
            this.txbAxisForce.UserRegExCheckErrorMessage = null;
            // 
            // txbPinUpperDiam
            // 
            this.txbPinUpperDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinUpperDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinUpperDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinUpperDiam.IsValidating = true;
            this.txbPinUpperDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinUpperDiam.Name = "txbPinUpperDiam";
            this.txbPinUpperDiam.AccessibleName = "txbPinUpperDiam";
            this.txbPinUpperDiam.TabIndex = 58;
            this.txbPinUpperDiam.UserRegExCheck = null;
            this.txbPinUpperDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbPinBottomDiam
            // 
            this.txbPinBottomDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinBottomDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinBottomDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinBottomDiam.IsValidating = true;
            this.txbPinBottomDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinBottomDiam.Name = "txbPinBottomDiam";
            this.txbPinBottomDiam.AccessibleName = "txbPinBottomDiam";
            this.txbPinBottomDiam.TabIndex = 57;
            this.txbPinBottomDiam.UserRegExCheck = null;
            this.txbPinBottomDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbPinLenght
            // 
            this.txbPinLenght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinLenght.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinLenght.IsValidating = true;
            this.txbPinLenght.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinLenght.Name = "txbPinLenght";
            this.txbPinLenght.AccessibleName = "txbPinLenght";
            this.txbPinLenght.TabIndex = 56;
            this.txbPinLenght.UserRegExCheck = null;
            this.txbPinLenght.UserRegExCheckErrorMessage = null;
            // 
            // txbShoulderDiam
            // 
            this.txbShoulderDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbShoulderDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbShoulderDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbShoulderDiam.IsValidating = true;
            this.txbShoulderDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbShoulderDiam.Name = "txbShoulderDiam";
            this.txbShoulderDiam.AccessibleName = "txbShoulderDiam";
            this.txbShoulderDiam.TabIndex = 55;
            this.txbShoulderDiam.UserRegExCheck = null;
            this.txbShoulderDiam.UserRegExCheckErrorMessage = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label16.Name = "label16";
            this.label16.TabIndex = 54;
            this.label16.Text = "Диаметр конца (D3)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Name = "label15";
            this.label15.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label15.TabIndex = 53;
            this.label15.Text = "Диаметр основания (D2), мм";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label12.Name = "label12";
            this.label12.TabIndex = 52;
            this.label12.Text = "Длина бура (L), мм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.TabIndex = 51;
            this.label3.Text = "Диаметр плеча (D1), мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label11.Name = "label11";
            this.label11.TabIndex = 49;
            this.label11.Text = "Скорость вращения, об/cек.";
            // 
            // txbRotSpeed
            // 
            this.txbRotSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRotSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRotSpeed.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbRotSpeed.IsValidating = true;
            this.txbRotSpeed.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbRotSpeed.Name = "txbRotSpeed";
            this.txbRotSpeed.AccessibleName = "txbRotSpeed";
            this.txbRotSpeed.TabIndex = 50;
            this.txbRotSpeed.UserRegExCheck = null;
            this.txbRotSpeed.UserRegExCheckErrorMessage = null;
            // 
            // label5
            // 
            this.label19.AutoSize = true;
            this.label19.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label19.Name = "label5";
            this.label19.TabIndex = 63;
            this.label19.Text = "Предел текучести, МПа";
            // 
            // cmbYield
            // 
            this.cmbYield.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYield.FormattingEnabled = true;
            this.cmbYield.InputType = ((UserControlsEx.CMBInputType)((UserControlsEx.CMBInputType.Items | UserControlsEx.CMBInputType.Float)));
            this.cmbYield.IsValidating = true;
            this.cmbYield.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbYield.Name = "cmbYield";
            cmbYield.AccessibleName = "cmbYield";
            this.cmbYield.TabIndex = 62;
            this.cmbYield.UserRegExCheck = null;
            this.cmbYield.UserRegExCheckErrorMessage = null;
            // 
            // rbtPin
            // 
            this.rbtPin.AutoSize = true;
            this.rbtPin.Margin = new System.Windows.Forms.Padding(2);
            this.rbtPin.Name = "rbtPin";
            rbtPin.AccessibleName = "rbtPin";
            this.rbtPin.TabIndex = 65;
            this.rbtPin.TabStop = true;
            this.rbtPin.Text = "Рабочая часть";
            this.rbtPin.UseVisualStyleBackColor = true;
            this.rbtPin.Checked = true;
            this.rbtPin.Click += SelectingFSWMode;
            // 
            // rbtShoulder
            // 
            this.rbtShoulder.AutoSize = true;
            this.rbtShoulder.Margin = new System.Windows.Forms.Padding(2);
            this.rbtShoulder.Name = "rbtShoulder";
            rbtShoulder.AccessibleName = "rbtShoulder";
            this.rbtShoulder.TabIndex = 66;
            this.rbtShoulder.TabStop = true;
            this.rbtShoulder.Text = "Опорный бурт";
            this.rbtShoulder.UseVisualStyleBackColor = true;
            this.rbtShoulder.Click += SelectingFSWMode;
            #endregion
            #endregion
            // 
            // HeatControlCreator
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(generalTableLayoutPanel);
            Name = "MediaControlCreator";
            generalTableLayoutPanel.ResumeLayout(false);
            generalTableLayoutPanel.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelRadioButton.ResumeLayout(false);
            panelRadioButton.PerformLayout();
            panelRadioButton2.ResumeLayout(false);
            panelRadioButton2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grbGroup.ResumeLayout(false);
            grbGroup.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel panelRadioButton;
        private FlowLayoutPanel panelRadioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.GroupBox grbGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtARC;
        private System.Windows.Forms.RadioButton rbtFS;
        private System.Windows.Forms.RadioButton rbtLW;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label voltageLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Label baseDiameterLabel;
        private System.Windows.Forms.Label endDiameterLabel;
        private TextBoxEx txbCurrent;
        private TextBoxEx txbMediaTemp;
        private TextBoxEx txbVoltage;
        private TextBoxEx txbWidth;
        private TextBoxEx  txbPower;
        private TextBoxEx txbDepth;
        private TextBoxEx txbBaseDiameter;
        private TextBoxEx txbEndDiameter;
        private ComboBoxEx cmbEl;
        private ComboBoxEx cmbFunc;
        private ComboBoxEx cmbTermoCycle;
        private ComboBoxEx cmbNode;

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label label17;
        private ComboBoxEx cmbFrictionModule;
        private System.Windows.Forms.Label label18;
        private TextBoxEx txbAxisForce;
        private TextBoxEx txbPinUpperDiam;
        private TextBoxEx txbPinBottomDiam;
        private TextBoxEx txbPinLenght;
        private TextBoxEx txbShoulderDiam;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private TextBoxEx txbRotSpeed;
        private System.Windows.Forms.Label label19;
        private ComboBoxEx cmbYield;
        private System.Windows.Forms.RadioButton rbtPin;
        private System.Windows.Forms.RadioButton rbtShoulder;
    }
}
