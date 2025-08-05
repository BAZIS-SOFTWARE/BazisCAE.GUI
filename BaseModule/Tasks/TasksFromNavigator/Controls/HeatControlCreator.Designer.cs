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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatControlCreator));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.currentLabel = new System.Windows.Forms.Label();
            this.txbCurrent = new UserControlsEx.TextBoxEx(this.components);
            this.voltageLabel = new System.Windows.Forms.Label();
            this.txbVoltage = new UserControlsEx.TextBoxEx(this.components);
            this.widthLabel = new System.Windows.Forms.Label();
            this.txbWidth = new UserControlsEx.TextBoxEx(this.components);
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSelect = new System.Windows.Forms.GroupBox();
            this.grbGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEl = new UserControlsEx.ComboBoxEx(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelRadioButton2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtPin = new System.Windows.Forms.RadioButton();
            this.rbtShoulder = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.powerLabel = new System.Windows.Forms.Label();
            this.txbPower = new UserControlsEx.TextBoxEx(this.components);
            this.depthLabel = new System.Windows.Forms.Label();
            this.txbDepth = new UserControlsEx.TextBoxEx(this.components);
            this.baseDiameterLabel = new System.Windows.Forms.Label();
            this.txbBaseDiameter = new UserControlsEx.TextBoxEx(this.components);
            this.endDiameterLabel = new System.Windows.Forms.Label();
            this.txbEndDiameter = new UserControlsEx.TextBoxEx(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txbRotSpeed = new UserControlsEx.TextBoxEx(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.txbAxisForce = new UserControlsEx.TextBoxEx(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txbShoulderDiam = new UserControlsEx.TextBoxEx(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txbPinLenght = new UserControlsEx.TextBoxEx(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txbPinUpperDiam = new UserControlsEx.TextBoxEx(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.txbPinBottomDiam = new UserControlsEx.TextBoxEx(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.cmbFrictionModule = new UserControlsEx.ComboBoxEx(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.cmbYield = new UserControlsEx.ComboBoxEx(this.components);
            this.btnInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMediaTemp = new UserControlsEx.TextBoxEx(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFunc = new UserControlsEx.ComboBoxEx(this.components);
            this.cmbTermoCycle = new UserControlsEx.ComboBoxEx(this.components);
            this.cmbNode = new UserControlsEx.ComboBoxEx(this.components);
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtSPH = new System.Windows.Forms.RadioButton();
            this.rbtCIL = new System.Windows.Forms.RadioButton();
            this.rbtCustom = new System.Windows.Forms.RadioButton();
            this.rbtNone = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.groupBoxSelect.SuspendLayout();
            this.grbGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelRadioButton2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel3.Controls.Add(this.currentLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbCurrent, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.voltageLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txbVoltage, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.widthLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txbWidth, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(433, 81);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(10, 10);
            this.currentLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(88, 13);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.Text = "Скорость, мм/с";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbCurrent
            // 
            this.txbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCurrent.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbCurrent.IsValidating = true;
            this.txbCurrent.Location = new System.Drawing.Point(131, 3);
            this.txbCurrent.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbCurrent.Name = "txbCurrent";
            this.txbCurrent.Size = new System.Drawing.Size(287, 20);
            this.txbCurrent.TabIndex = 0;
            this.txbCurrent.UserRegExCheck = null;
            this.txbCurrent.UserRegExCheckErrorMessage = null;
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.Location = new System.Drawing.Point(10, 37);
            this.voltageLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(83, 13);
            this.voltageLabel.TabIndex = 4;
            this.voltageLabel.Text = "Смещение, мм";
            this.voltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbVoltage
            // 
            this.txbVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbVoltage.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbVoltage.IsValidating = true;
            this.txbVoltage.Location = new System.Drawing.Point(131, 30);
            this.txbVoltage.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbVoltage.Name = "txbVoltage";
            this.txbVoltage.Size = new System.Drawing.Size(287, 20);
            this.txbVoltage.TabIndex = 1;
            this.txbVoltage.UserRegExCheck = null;
            this.txbVoltage.UserRegExCheckErrorMessage = null;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(10, 64);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(79, 13);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Поворот, град";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbWidth
            // 
            this.txbWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbWidth.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbWidth.IsValidating = true;
            this.txbWidth.Location = new System.Drawing.Point(131, 57);
            this.txbWidth.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbWidth.Name = "txbWidth";
            this.txbWidth.Size = new System.Drawing.Size(287, 20);
            this.txbWidth.TabIndex = 0;
            this.txbWidth.UserRegExCheck = null;
            this.txbWidth.UserRegExCheckErrorMessage = null;
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.AutoSize = true;
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalTableLayoutPanel.Controls.Add(this.groupBoxSelect, 0, 0);
            this.generalTableLayoutPanel.Controls.Add(this.grbGroup, 0, 1);
            this.generalTableLayoutPanel.Controls.Add(this.groupBox3, 0, 2);
            this.generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 3;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.Size = new System.Drawing.Size(449, 213);
            this.generalTableLayoutPanel.TabIndex = 0;
            // 
            // groupBoxSelect
            // 
            this.groupBoxSelect.AutoSize = true;
            this.groupBoxSelect.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSelect.Location = new System.Drawing.Point(4, 3);
            this.groupBoxSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSelect.Size = new System.Drawing.Size(441, 49);
            this.groupBoxSelect.TabIndex = 21;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "Вид источника";
            // 
            // grbGroup
            // 
            this.grbGroup.AutoSize = true;
            this.grbGroup.Controls.Add(this.tableLayoutPanel1);
            this.grbGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGroup.Location = new System.Drawing.Point(4, 58);
            this.grbGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbGroup.MinimumSize = new System.Drawing.Size(0, 10);
            this.grbGroup.Name = "grbGroup";
            this.grbGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbGroup.Size = new System.Drawing.Size(441, 46);
            this.grbGroup.TabIndex = 18;
            this.grbGroup.TabStop = false;
            this.grbGroup.Text = "Область действия";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Группа элементов";
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbEl.IsValidating = true;
            this.cmbEl.Location = new System.Drawing.Point(131, 3);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(287, 21);
            this.cmbEl.TabIndex = 14;
            this.cmbEl.UserRegExCheck = null;
            this.cmbEl.UserRegExCheckErrorMessage = null;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 110);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.MinimumSize = new System.Drawing.Size(0, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(441, 100);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры источника";
            // 
            // panelRadioButton2
            // 
            this.panelRadioButton2.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.panelRadioButton2, 2);
            this.panelRadioButton2.Controls.Add(this.rbtPin);
            this.panelRadioButton2.Controls.Add(this.rbtShoulder);
            this.panelRadioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRadioButton2.Location = new System.Drawing.Point(3, 3);
            this.panelRadioButton2.Name = "panelRadioButton2";
            this.panelRadioButton2.Size = new System.Drawing.Size(194, 21);
            this.panelRadioButton2.TabIndex = 0;
            this.panelRadioButton2.WrapContents = false;
            // 
            // rbtPin
            // 
            this.rbtPin.AutoSize = true;
            this.rbtPin.Checked = true;
            this.rbtPin.Location = new System.Drawing.Point(2, 2);
            this.rbtPin.Margin = new System.Windows.Forms.Padding(2);
            this.rbtPin.Name = "rbtPin";
            this.rbtPin.Size = new System.Drawing.Size(98, 17);
            this.rbtPin.TabIndex = 65;
            this.rbtPin.TabStop = true;
            this.rbtPin.Text = "Рабочая часть";
            this.rbtPin.UseVisualStyleBackColor = true;
            // 
            // rbtShoulder
            // 
            this.rbtShoulder.AutoSize = true;
            this.rbtShoulder.Location = new System.Drawing.Point(104, 2);
            this.rbtShoulder.Margin = new System.Windows.Forms.Padding(2);
            this.rbtShoulder.Name = "rbtShoulder";
            this.rbtShoulder.Size = new System.Drawing.Size(96, 17);
            this.rbtShoulder.TabIndex = 66;
            this.rbtShoulder.TabStop = true;
            this.rbtShoulder.Text = "Опорный бурт";
            this.rbtShoulder.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel2.Controls.Add(this.powerLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbPower, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.depthLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txbDepth, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.baseDiameterLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txbBaseDiameter, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.endDiameterLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txbEndDiameter, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(10, 10);
            this.powerLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(43, 15);
            this.powerLabel.TabIndex = 3;
            this.powerLabel.Text = "Мощность излучения, Дж";
            this.powerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPower
            // 
            this.txbPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPower.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPower.IsValidating = true;
            this.txbPower.Location = new System.Drawing.Point(66, 3);
            this.txbPower.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPower.Name = "txbPower";
            this.txbPower.Size = new System.Drawing.Size(119, 20);
            this.txbPower.TabIndex = 0;
            this.txbPower.UserRegExCheck = null;
            this.txbPower.UserRegExCheckErrorMessage = null;
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(10, 35);
            this.depthLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(43, 15);
            this.depthLabel.TabIndex = 4;
            this.depthLabel.Text = "Глубина проплавления (L), мм";
            this.depthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbDepth
            // 
            this.txbDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDepth.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbDepth.IsValidating = true;
            this.txbDepth.Location = new System.Drawing.Point(66, 28);
            this.txbDepth.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbDepth.Name = "txbDepth";
            this.txbDepth.Size = new System.Drawing.Size(119, 20);
            this.txbDepth.TabIndex = 1;
            this.txbDepth.UserRegExCheck = null;
            this.txbDepth.UserRegExCheckErrorMessage = null;
            // 
            // baseDiameterLabel
            // 
            this.baseDiameterLabel.AutoSize = true;
            this.baseDiameterLabel.Location = new System.Drawing.Point(10, 60);
            this.baseDiameterLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.baseDiameterLabel.Name = "baseDiameterLabel";
            this.baseDiameterLabel.Size = new System.Drawing.Size(43, 15);
            this.baseDiameterLabel.TabIndex = 3;
            this.baseDiameterLabel.Text = "Диаметр основания (D2), мм";
            this.baseDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbBaseDiameter
            // 
            this.txbBaseDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBaseDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBaseDiameter.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbBaseDiameter.IsValidating = true;
            this.txbBaseDiameter.Location = new System.Drawing.Point(66, 53);
            this.txbBaseDiameter.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbBaseDiameter.Name = "txbBaseDiameter";
            this.txbBaseDiameter.Size = new System.Drawing.Size(119, 20);
            this.txbBaseDiameter.TabIndex = 0;
            this.txbBaseDiameter.UserRegExCheck = null;
            this.txbBaseDiameter.UserRegExCheckErrorMessage = null;
            // 
            // endDiameterLabel
            // 
            this.endDiameterLabel.AutoSize = true;
            this.endDiameterLabel.Location = new System.Drawing.Point(10, 85);
            this.endDiameterLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.endDiameterLabel.Name = "endDiameterLabel";
            this.endDiameterLabel.Size = new System.Drawing.Size(42, 15);
            this.endDiameterLabel.TabIndex = 3;
            this.endDiameterLabel.Text = "Диаметр конца (D3), мм";
            this.endDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbEndDiameter
            // 
            this.txbEndDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEndDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbEndDiameter.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbEndDiameter.IsValidating = true;
            this.txbEndDiameter.Location = new System.Drawing.Point(66, 78);
            this.txbEndDiameter.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbEndDiameter.Name = "txbEndDiameter";
            this.txbEndDiameter.Size = new System.Drawing.Size(119, 20);
            this.txbEndDiameter.TabIndex = 0;
            this.txbEndDiameter.UserRegExCheck = null;
            this.txbEndDiameter.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel4.Controls.Add(this.panelRadioButton2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbRotSpeed, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txbAxisForce, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txbShoulderDiam, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.txbPinLenght, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.txbPinUpperDiam, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.txbPinBottomDiam, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label17, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.cmbFrictionModule, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.label19, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.cmbYield, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.btnInfo, 0, 9);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 78);
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
            this.txbRotSpeed.Location = new System.Drawing.Point(66, 30);
            this.txbRotSpeed.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbRotSpeed.Name = "txbRotSpeed";
            this.txbRotSpeed.Size = new System.Drawing.Size(119, 20);
            this.txbRotSpeed.TabIndex = 50;
            this.txbRotSpeed.UserRegExCheck = null;
            this.txbRotSpeed.UserRegExCheckErrorMessage = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 125);
            this.label18.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 52);
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
            this.txbAxisForce.Location = new System.Drawing.Point(66, 118);
            this.txbAxisForce.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbAxisForce.Name = "txbAxisForce";
            this.txbAxisForce.Size = new System.Drawing.Size(119, 20);
            this.txbAxisForce.TabIndex = 59;
            this.txbAxisForce.UserRegExCheck = null;
            this.txbAxisForce.UserRegExCheckErrorMessage = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 65);
            this.label3.TabIndex = 51;
            this.label3.Text = "Диаметр плеча (D1), мм";
            // 
            // txbShoulderDiam
            // 
            this.txbShoulderDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbShoulderDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbShoulderDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbShoulderDiam.IsValidating = true;
            this.txbShoulderDiam.Location = new System.Drawing.Point(66, 180);
            this.txbShoulderDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbShoulderDiam.Name = "txbShoulderDiam";
            this.txbShoulderDiam.Size = new System.Drawing.Size(119, 20);
            this.txbShoulderDiam.TabIndex = 55;
            this.txbShoulderDiam.UserRegExCheck = null;
            this.txbShoulderDiam.UserRegExCheckErrorMessage = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 262);
            this.label12.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 39);
            this.label12.TabIndex = 52;
            this.label12.Text = "Длина бура (L), мм";
            // 
            // txbPinLenght
            // 
            this.txbPinLenght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinLenght.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinLenght.IsValidating = true;
            this.txbPinLenght.Location = new System.Drawing.Point(66, 255);
            this.txbPinLenght.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinLenght.Name = "txbPinLenght";
            this.txbPinLenght.Size = new System.Drawing.Size(119, 20);
            this.txbPinLenght.TabIndex = 56;
            this.txbPinLenght.UserRegExCheck = null;
            this.txbPinLenght.UserRegExCheckErrorMessage = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 311);
            this.label15.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 78);
            this.label15.TabIndex = 53;
            this.label15.Text = "Диаметр основания (D2), мм";
            // 
            // txbPinUpperDiam
            // 
            this.txbPinUpperDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinUpperDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinUpperDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinUpperDiam.IsValidating = true;
            this.txbPinUpperDiam.Location = new System.Drawing.Point(66, 304);
            this.txbPinUpperDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinUpperDiam.Name = "txbPinUpperDiam";
            this.txbPinUpperDiam.Size = new System.Drawing.Size(119, 20);
            this.txbPinUpperDiam.TabIndex = 58;
            this.txbPinUpperDiam.UserRegExCheck = null;
            this.txbPinUpperDiam.UserRegExCheckErrorMessage = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 399);
            this.label16.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 52);
            this.label16.TabIndex = 54;
            this.label16.Text = "Диаметр конца (D3)";
            // 
            // txbPinBottomDiam
            // 
            this.txbPinBottomDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinBottomDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinBottomDiam.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPinBottomDiam.IsValidating = true;
            this.txbPinBottomDiam.Location = new System.Drawing.Point(66, 392);
            this.txbPinBottomDiam.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbPinBottomDiam.Name = "txbPinBottomDiam";
            this.txbPinBottomDiam.Size = new System.Drawing.Size(119, 20);
            this.txbPinBottomDiam.TabIndex = 57;
            this.txbPinBottomDiam.UserRegExCheck = null;
            this.txbPinBottomDiam.UserRegExCheckErrorMessage = null;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 461);
            this.label17.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 39);
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
            this.cmbFrictionModule.Location = new System.Drawing.Point(66, 454);
            this.cmbFrictionModule.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbFrictionModule.Name = "cmbFrictionModule";
            this.cmbFrictionModule.Size = new System.Drawing.Size(119, 21);
            this.cmbFrictionModule.TabIndex = 62;
            this.cmbFrictionModule.UserRegExCheck = null;
            this.cmbFrictionModule.UserRegExCheckErrorMessage = null;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 510);
            this.label19.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 65);
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
            this.cmbYield.Location = new System.Drawing.Point(66, 503);
            this.cmbYield.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbYield.Name = "cmbYield";
            this.cmbYield.Size = new System.Drawing.Size(119, 21);
            this.cmbYield.TabIndex = 62;
            this.cmbYield.UserRegExCheck = null;
            this.cmbYield.UserRegExCheckErrorMessage = null;
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(3, 578);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(27, 27);
            this.btnInfo.TabIndex = 64;
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 0;
            // 
            // txbMediaTemp
            // 
            this.txbMediaTemp.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbMediaTemp.IsValidating = true;
            this.txbMediaTemp.Location = new System.Drawing.Point(0, 0);
            this.txbMediaTemp.Name = "txbMediaTemp";
            this.txbMediaTemp.Size = new System.Drawing.Size(100, 20);
            this.txbMediaTemp.TabIndex = 0;
            this.txbMediaTemp.UserRegExCheck = null;
            this.txbMediaTemp.UserRegExCheckErrorMessage = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cmbFunc
            // 
            this.cmbFunc.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbFunc.IsValidating = true;
            this.cmbFunc.Location = new System.Drawing.Point(0, 0);
            this.cmbFunc.Name = "cmbFunc";
            this.cmbFunc.Size = new System.Drawing.Size(121, 21);
            this.cmbFunc.TabIndex = 0;
            this.cmbFunc.UserRegExCheck = null;
            this.cmbFunc.UserRegExCheckErrorMessage = null;
            // 
            // cmbTermoCycle
            // 
            this.cmbTermoCycle.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbTermoCycle.IsValidating = true;
            this.cmbTermoCycle.Location = new System.Drawing.Point(0, 0);
            this.cmbTermoCycle.Name = "cmbTermoCycle";
            this.cmbTermoCycle.Size = new System.Drawing.Size(121, 21);
            this.cmbTermoCycle.TabIndex = 0;
            this.cmbTermoCycle.UserRegExCheck = null;
            this.cmbTermoCycle.UserRegExCheckErrorMessage = null;
            // 
            // cmbNode
            // 
            this.cmbNode.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbNode.IsValidating = true;
            this.cmbNode.Location = new System.Drawing.Point(0, 0);
            this.cmbNode.Name = "cmbNode";
            this.cmbNode.Size = new System.Drawing.Size(121, 21);
            this.cmbNode.TabIndex = 0;
            this.cmbNode.UserRegExCheck = null;
            this.cmbNode.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.rbtSPH, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.rbtCIL, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.rbtCustom, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.rbtNone, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 16);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.MinimumSize = new System.Drawing.Size(0, 30);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(433, 30);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // rbtSPH
            // 
            this.rbtSPH.AutoSize = true;
            this.rbtSPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtSPH.Location = new System.Drawing.Point(3, 3);
            this.rbtSPH.Name = "rbtSPH";
            this.rbtSPH.Size = new System.Drawing.Size(102, 24);
            this.rbtSPH.TabIndex = 0;
            this.rbtSPH.TabStop = true;
            this.rbtSPH.Text = "radioButton1";
            this.rbtSPH.UseVisualStyleBackColor = true;
            // 
            // rbtCIL
            // 
            this.rbtCIL.AutoSize = true;
            this.rbtCIL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtCIL.Location = new System.Drawing.Point(111, 3);
            this.rbtCIL.Name = "rbtCIL";
            this.rbtCIL.Size = new System.Drawing.Size(102, 24);
            this.rbtCIL.TabIndex = 1;
            this.rbtCIL.TabStop = true;
            this.rbtCIL.Text = "radioButton2";
            this.rbtCIL.UseVisualStyleBackColor = true;
            // 
            // rbtCustom
            // 
            this.rbtCustom.AutoSize = true;
            this.rbtCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtCustom.Location = new System.Drawing.Point(219, 3);
            this.rbtCustom.Name = "rbtCustom";
            this.rbtCustom.Size = new System.Drawing.Size(102, 24);
            this.rbtCustom.TabIndex = 1;
            this.rbtCustom.TabStop = true;
            this.rbtCustom.Text = "radioButton2";
            this.rbtCustom.UseVisualStyleBackColor = true;
            // 
            // rbtNone
            // 
            this.rbtNone.AutoSize = true;
            this.rbtNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtNone.Location = new System.Drawing.Point(327, 3);
            this.rbtNone.Name = "rbtNone";
            this.rbtNone.Size = new System.Drawing.Size(103, 24);
            this.rbtNone.TabIndex = 1;
            this.rbtNone.TabStop = true;
            this.rbtNone.Text = "radioButton2";
            this.rbtNone.UseVisualStyleBackColor = true;
            // 
            // HeatControlCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.generalTableLayoutPanel);
            this.Name = "HeatControlCreator";
            this.Size = new System.Drawing.Size(449, 213);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxSelect.PerformLayout();
            this.grbGroup.ResumeLayout(false);
            this.grbGroup.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelRadioButton2.ResumeLayout(false);
            this.panelRadioButton2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel generalTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel panelRadioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.GroupBox grbGroup;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private TableLayoutPanel tableLayoutPanel5;
        private RadioButton rbtSPH;
        private RadioButton rbtCIL;
        private RadioButton rbtCustom;
        private RadioButton rbtNone;
    }
}
