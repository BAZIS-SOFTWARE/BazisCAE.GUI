using System.Windows.Forms;
using System.Drawing;
using TaskModule.BasicAdvisorControls;
using System.Reflection.Emit;
using MathNet.Numerics;
using UserControlsEx;
using BaseModule.Tasks.TasksFromNavigator.Controls;

namespace BaseModule.Tasks.TasksFromNavigator
{
    partial class GeneralСontrol
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
            this.movementParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.trajectoryTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.baseLineLabel = new System.Windows.Forms.Label();
            this.cmbTraj = new UserControlsEx.ComboBoxEx(this.components);
            this.refLineLabel = new System.Windows.Forms.Label();
            this.cmbRef = new UserControlsEx.ComboBoxEx(this.components);
            this.sourcePositionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelX = new System.Windows.Forms.TableLayoutPanel();
            this.labelX = new System.Windows.Forms.Label();
            this.txbX = new UserControlsEx.TextBoxEx(this.components);
            this.tableLayoutPanelY = new System.Windows.Forms.TableLayoutPanel();
            this.labelY = new System.Windows.Forms.Label();
            this.txbY = new UserControlsEx.TextBoxEx(this.components);
            this.tableLayoutPanelZ = new System.Windows.Forms.TableLayoutPanel();
            this.labelZ = new System.Windows.Forms.Label();
            this.txbZ = new UserControlsEx.TextBoxEx(this.components);
            this.rotationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelAngleX = new System.Windows.Forms.TableLayoutPanel();
            this.labelAngleX = new System.Windows.Forms.Label();
            this.txbAngleX = new UserControlsEx.TextBoxEx(this.components);
            this.tableLayoutPanelAngleY = new System.Windows.Forms.TableLayoutPanel();
            this.labelAngleY = new System.Windows.Forms.Label();
            this.txbAngleY = new UserControlsEx.TextBoxEx(this.components);
            this.tableLayoutPanelAngleZ = new System.Windows.Forms.TableLayoutPanel();
            this.labelAngleZ = new System.Windows.Forms.Label();
            this.txbAngleZ = new UserControlsEx.TextBoxEx(this.components);
            this.sourceVelocityLabel = new System.Windows.Forms.Label();
            this.txbVelosity = new UserControlsEx.TextBoxEx(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.txbStartTime = new UserControlsEx.TextBoxEx(this.components);
            this.btnCreatePhysicalData = new System.Windows.Forms.Button();
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.matControl = new BaseModule.Tasks.TasksFromNavigator.Controls.MaterialControl();
            this.clampControl = new BaseModule.Tasks.TasksFromNavigator.Controls.ClampControl();
            this.movementParametersGroupBox.SuspendLayout();
            this.trajectoryTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelX.SuspendLayout();
            this.tableLayoutPanelY.SuspendLayout();
            this.tableLayoutPanelZ.SuspendLayout();
            this.tableLayoutPanelAngleX.SuspendLayout();
            this.tableLayoutPanelAngleY.SuspendLayout();
            this.tableLayoutPanelAngleZ.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // movementParametersGroupBox
            // 
            this.movementParametersGroupBox.AutoSize = true;
            this.movementParametersGroupBox.Controls.Add(this.trajectoryTableLayoutPanel);
            this.movementParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movementParametersGroupBox.Location = new System.Drawing.Point(4, 169);
            this.movementParametersGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.movementParametersGroupBox.Name = "movementParametersGroupBox";
            this.movementParametersGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.movementParametersGroupBox.TabIndex = 1;
            this.movementParametersGroupBox.TabStop = false;
            this.movementParametersGroupBox.Text = "Параметры движения";
            // 
            // trajectoryTableLayoutPanel
            // 
            this.trajectoryTableLayoutPanel.AutoSize = true;
            this.trajectoryTableLayoutPanel.ColumnCount = 4;
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.Controls.Add(this.baseLineLabel, 0, 0);
            this.trajectoryTableLayoutPanel.Controls.Add(this.cmbTraj, 1, 0);
            this.trajectoryTableLayoutPanel.Controls.Add(this.refLineLabel, 0, 1);
            this.trajectoryTableLayoutPanel.Controls.Add(this.cmbRef, 1, 1);
            this.trajectoryTableLayoutPanel.Controls.Add(this.sourcePositionLabel, 0, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelX, 1, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelY, 2, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelZ, 3, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(this.rotationLabel, 0, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelAngleX, 1, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelAngleY, 2, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(this.tableLayoutPanelAngleZ, 3, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(this.sourceVelocityLabel, 0, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(this.txbVelosity, 1, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(this.startLabel, 0, 5);
            this.trajectoryTableLayoutPanel.Controls.Add(this.txbStartTime, 1, 5);
            this.trajectoryTableLayoutPanel.Controls.Add(this.btnCreatePhysicalData, 3, 6);
            this.trajectoryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trajectoryTableLayoutPanel.Location = new System.Drawing.Point(4, 16);
            this.trajectoryTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.trajectoryTableLayoutPanel.Name = "trajectoryTableLayoutPanel";
            this.trajectoryTableLayoutPanel.RowCount = 7;
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.trajectoryTableLayoutPanel.TabIndex = 0;
            // 
            // baseLineLabel
            // 
            this.baseLineLabel.AutoSize = true;
            this.baseLineLabel.Location = new System.Drawing.Point(10, 10);
            this.baseLineLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.baseLineLabel.Name = "baseLineLabel";
            this.baseLineLabel.Size = new System.Drawing.Size(92, 13);
            this.baseLineLabel.TabIndex = 0;
            this.baseLineLabel.Text = "Линия движения";
            // 
            // cmbTraj
            // 
            this.cmbTraj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trajectoryTableLayoutPanel.SetColumnSpan(this.cmbTraj, 3);
            this.cmbTraj.FormattingEnabled = true;
            this.cmbTraj.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbTraj.IsValidating = true;
            this.cmbTraj.Location = new System.Drawing.Point(174, 3);
            this.cmbTraj.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbTraj.Name = "cmbTraj";
            this.cmbTraj.TabIndex = 29;
            this.cmbTraj.UserRegExCheck = null;
            this.cmbTraj.UserRegExCheckErrorMessage = null;
            // 
            // refLineLabel
            // 
            this.refLineLabel.AutoSize = true;
            this.refLineLabel.Location = new System.Drawing.Point(10, 45);
            this.refLineLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.refLineLabel.Name = "refLineLabel";
            this.refLineLabel.TabIndex = 0;
            this.refLineLabel.Text = "Опорная линия";
            // 
            // cmbRef
            // 
            this.cmbRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trajectoryTableLayoutPanel.SetColumnSpan(this.cmbRef, 3);
            this.cmbRef.FormattingEnabled = true;
            this.cmbRef.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbRef.IsValidating = true;
            this.cmbRef.Location = new System.Drawing.Point(174, 38);
            this.cmbRef.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbRef.Name = "cmbRef";
            this.cmbRef.Size = new System.Drawing.Size(399, 21);
            this.cmbRef.TabIndex = 29;
            this.cmbRef.UserRegExCheck = null;
            this.cmbRef.UserRegExCheckErrorMessage = null;
            // 
            // sourcePositionLabel
            // 
            this.sourcePositionLabel.AutoSize = true;
            this.sourcePositionLabel.Location = new System.Drawing.Point(10, 80);
            this.sourcePositionLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.sourcePositionLabel.Name = "sourcePositionLabel";
            this.sourcePositionLabel.Size = new System.Drawing.Size(61, 13);
            this.sourcePositionLabel.TabIndex = 0;
            this.sourcePositionLabel.Text = "Смещение";
            // 
            // tableLayoutPanelX
            // 
            this.tableLayoutPanelX.AutoSize = true;
            this.tableLayoutPanelX.ColumnCount = 2;
            this.tableLayoutPanelX.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelX.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelX.Controls.Add(this.labelX, 0, 0);
            this.tableLayoutPanelX.Controls.Add(this.txbX, 1, 0);
            this.tableLayoutPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelX.Name = "tableLayoutPanelX";
            this.tableLayoutPanelX.RowCount = 1;
            this.tableLayoutPanelX.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelX.TabIndex = 30;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(10, 10);
            this.labelX.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelX.Name = "labelX";
            this.labelX.TabIndex = 0;
            this.labelX.Text = "dX:";
            // 
            // txbX
            // 
            this.txbX.AccessibleName = "txbX";
            this.txbX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbX.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbX.IsValidating = true;
            this.txbX.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbX.Name = "txbX";
            this.txbX.TabIndex = 0;
            this.txbX.UserRegExCheck = null;
            this.txbX.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanelY
            // 
            this.tableLayoutPanelY.AutoSize = true;
            this.tableLayoutPanelY.ColumnCount = 2;
            this.tableLayoutPanelY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelY.Controls.Add(this.labelY, 0, 0);
            this.tableLayoutPanelY.Controls.Add(this.txbY, 1, 0);
            this.tableLayoutPanelY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelY.Name = "tableLayoutPanelY";
            this.tableLayoutPanelY.RowCount = 1;
            this.tableLayoutPanelY.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelY.TabIndex = 31;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(10, 10);
            this.labelY.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelY.Name = "labelY";
            this.labelY.TabIndex = 0;
            this.labelY.Text = "dY: ";
            // 
            // txbY
            // 
            this.txbY.AccessibleName = "txbY";
            this.txbY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbY.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbY.IsValidating = true;
            this.txbY.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbY.Name = "txbY";
            this.txbY.TabIndex = 0;
            this.txbY.UserRegExCheck = null;
            this.txbY.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanelZ
            // 
            this.tableLayoutPanelZ.AutoSize = true;
            this.tableLayoutPanelZ.ColumnCount = 2;
            this.tableLayoutPanelZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelZ.Controls.Add(this.labelZ, 0, 0);
            this.tableLayoutPanelZ.Controls.Add(this.txbZ, 1, 0);
            this.tableLayoutPanelZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelZ.Name = "tableLayoutPanelZ";
            this.tableLayoutPanelZ.RowCount = 1;
            this.tableLayoutPanelZ.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelZ.TabIndex = 32;
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelZ.Name = "labelZ";
            this.labelZ.TabIndex = 0;
            this.labelZ.Text = "dZ: ";
            // 
            // txbZ
            // 
            this.txbZ.AccessibleName = "txbZ";
            this.txbZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbZ.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbZ.IsValidating = true;
            this.txbZ.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbZ.Name = "txbZ";
            this.txbZ.TabIndex = 0;
            this.txbZ.UserRegExCheck = null;
            this.txbZ.UserRegExCheckErrorMessage = null;
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.TabIndex = 0;
            this.rotationLabel.Text = "Поворот";
            // 
            // tableLayoutPanelAngleX
            // 
            this.tableLayoutPanelAngleX.AutoSize = true;
            this.tableLayoutPanelAngleX.ColumnCount = 2;
            this.tableLayoutPanelAngleX.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelAngleX.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelAngleX.Controls.Add(this.labelAngleX, 0, 0);
            this.tableLayoutPanelAngleX.Controls.Add(this.txbAngleX, 1, 0);
            this.tableLayoutPanelAngleX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAngleX.Name = "tableLayoutPanelAngleX";
            this.tableLayoutPanelAngleX.RowCount = 1;
            this.tableLayoutPanelAngleX.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAngleX.TabIndex = 33;
            // 
            // labelAngleX
            // 
            this.labelAngleX.AutoSize = true;
            this.labelAngleX.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelAngleX.Name = "labelAngleX";
            this.labelAngleX.TabIndex = 0;
            this.labelAngleX.Text = "Ось Х:";
            // 
            // txbAngleX
            // 
            this.txbAngleX.AccessibleName = "txbAngleX";
            this.txbAngleX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAngleX.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbAngleX.IsValidating = true;
            this.txbAngleX.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbAngleX.Name = "txbAngleX";
            this.txbAngleX.TabIndex = 0;
            this.txbAngleX.UserRegExCheck = null;
            this.txbAngleX.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanelAngleY
            // 
            this.tableLayoutPanelAngleY.AutoSize = true;
            this.tableLayoutPanelAngleY.ColumnCount = 2;
            this.tableLayoutPanelAngleY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelAngleY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelAngleY.Controls.Add(this.labelAngleY, 0, 0);
            this.tableLayoutPanelAngleY.Controls.Add(this.txbAngleY, 1, 0);
            this.tableLayoutPanelAngleY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAngleY.Name = "tableLayoutPanelAngleY";
            this.tableLayoutPanelAngleY.RowCount = 1;
            this.tableLayoutPanelAngleY.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAngleY.TabIndex = 34;
            // 
            // labelAngleY
            // 
            this.labelAngleY.AutoSize = true;
            this.labelAngleY.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelAngleY.Name = "labelAngleY";
            this.labelAngleY.TabIndex = 0;
            this.labelAngleY.Text = "Ось Y:";
            // 
            // txbAngleY
            // 
            this.txbAngleY.AccessibleName = "txbAngleY";
            this.txbAngleY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAngleY.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbAngleY.IsValidating = true;
            this.txbAngleY.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbAngleY.Name = "txbAngleY";
            this.txbAngleY.TabIndex = 0;
            this.txbAngleY.UserRegExCheck = null;
            this.txbAngleY.UserRegExCheckErrorMessage = null;
            // 
            // tableLayoutPanelAngleZ
            // 
            this.tableLayoutPanelAngleZ.AutoSize = true;
            this.tableLayoutPanelAngleZ.ColumnCount = 2;
            this.tableLayoutPanelAngleZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelAngleZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelAngleZ.Controls.Add(this.labelAngleZ, 0, 0);
            this.tableLayoutPanelAngleZ.Controls.Add(this.txbAngleZ, 1, 0);
            this.tableLayoutPanelAngleZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAngleZ.Name = "tableLayoutPanelAngleZ";
            this.tableLayoutPanelAngleZ.RowCount = 1;
            this.tableLayoutPanelAngleZ.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAngleZ.TabIndex = 35;
            // 
            // labelAngleZ
            // 
            this.labelAngleZ.AutoSize = true;
            this.labelAngleZ.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.labelAngleZ.Name = "labelAngleZ";
            this.labelAngleZ.TabIndex = 0;
            this.labelAngleZ.Text = "Ось Z:";
            // 
            // txbAngleZ
            // 
            this.txbAngleZ.AccessibleName = "txbAngle";
            this.txbAngleZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAngleZ.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbAngleZ.IsValidating = true;
            this.txbAngleZ.Margin = new System.Windows.Forms.Padding(0, 5, 15, 0);
            this.txbAngleZ.Name = "txbAngleZ";
            this.txbAngleZ.TabIndex = 0;
            this.txbAngleZ.UserRegExCheck = null;
            this.txbAngleZ.UserRegExCheckErrorMessage = null;
            // 
            // sourceVelocityLabel
            // 
            this.sourceVelocityLabel.AutoSize = true;
            this.sourceVelocityLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.sourceVelocityLabel.Name = "sourceVelocityLabel";
            this.sourceVelocityLabel.TabIndex = 0;
            this.sourceVelocityLabel.Text = "Скорость, мм/сек.";
            // 
            // txbVelosity
            // 
            this.txbVelosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVelosity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trajectoryTableLayoutPanel.SetColumnSpan(this.txbVelosity, 3);
            this.txbVelosity.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbVelosity.IsValidating = true;
            this.txbVelosity.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbVelosity.Name = "txbVelosity";
            this.txbVelosity.TabIndex = 31;
            this.txbVelosity.UserRegExCheck = null;
            this.txbVelosity.UserRegExCheckErrorMessage = null;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Старт, сек.";
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trajectoryTableLayoutPanel.SetColumnSpan(this.txbStartTime, 3);
            this.txbStartTime.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStartTime.IsValidating = true;
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.TabIndex = 43;
            this.txbStartTime.UserRegExCheck = null;
            this.txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // btnCreatePhysicalData
            // 
            this.btnCreatePhysicalData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePhysicalData.Margin = new System.Windows.Forms.Padding(10, 5, 15, 5);
            this.btnCreatePhysicalData.MinimumSize = new System.Drawing.Size(90, 25);
            this.btnCreatePhysicalData.Name = "btnCreatePhysicalData";
            this.btnCreatePhysicalData.Size = new System.Drawing.Size(100, 25);
            this.btnCreatePhysicalData.TabIndex = 0;
            this.btnCreatePhysicalData.Text = "Создать";
            this.btnCreatePhysicalData.UseVisualStyleBackColor = true;
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.AutoSize = true;
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.generalTableLayoutPanel.Controls.Add(this.matControl, 0, 0);
            this.generalTableLayoutPanel.Controls.Add(this.clampControl, 0, 0);
            this.generalTableLayoutPanel.Controls.Add(this.movementParametersGroupBox, 0, 1);
            this.generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 2;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalTableLayoutPanel.TabIndex = 0;
            // 
            // matControl
            // 
            this.matControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.matControl.AutoSize = true;
            this.matControl.Location = new System.Drawing.Point(2, 6);
            this.matControl.Margin = new System.Windows.Forms.Padding(2);
            this.matControl.Name = "matControl";
            this.matControl.TabIndex = 0;
            // 
            // clampControl
            // 
            this.clampControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clampControl.AutoSize = true;
            this.clampControl.Location = new System.Drawing.Point(2, 6);
            this.clampControl.Margin = new System.Windows.Forms.Padding(2);
            this.clampControl.Name = "clampControl";
            this.clampControl.TabIndex = 0;

            // 
            // GeneralСontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.generalTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GeneralСontrol";
            this.movementParametersGroupBox.ResumeLayout(false);
            this.movementParametersGroupBox.PerformLayout();
            this.trajectoryTableLayoutPanel.ResumeLayout(false);
            this.trajectoryTableLayoutPanel.PerformLayout();
            this.tableLayoutPanelX.ResumeLayout(false);
            this.tableLayoutPanelX.PerformLayout();
            this.tableLayoutPanelY.ResumeLayout(false);
            this.tableLayoutPanelY.PerformLayout();
            this.tableLayoutPanelZ.ResumeLayout(false);
            this.tableLayoutPanelZ.PerformLayout();
            this.tableLayoutPanelAngleX.ResumeLayout(false);
            this.tableLayoutPanelAngleX.PerformLayout();
            this.tableLayoutPanelAngleY.ResumeLayout(false);
            this.tableLayoutPanelAngleY.PerformLayout();
            this.tableLayoutPanelAngleZ.ResumeLayout(false);
            this.tableLayoutPanelAngleZ.PerformLayout();
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TableLayoutPanel generalTableLayoutPanel;
        private TableLayoutPanel trajectoryTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanelX;
        private TableLayoutPanel tableLayoutPanelY;
        private TableLayoutPanel tableLayoutPanelZ;
        private TableLayoutPanel tableLayoutPanelAngleX;
        private TableLayoutPanel tableLayoutPanelAngleY;
        private TableLayoutPanel tableLayoutPanelAngleZ;
        private GroupBox movementParametersGroupBox;
        private System.Windows.Forms.Label baseLineLabel;
        private System.Windows.Forms.Label refLineLabel;
        private System.Windows.Forms.Label sourcePositionLabel;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.Label sourceVelocityLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelAngleX;
        private System.Windows.Forms.Label labelAngleY;
        private System.Windows.Forms.Label labelAngleZ;
        private TextBoxEx txbX;
        private TextBoxEx txbY;
        private TextBoxEx txbZ;
        private TextBoxEx txbAngleX;
        private TextBoxEx txbAngleY;
        private TextBoxEx txbAngleZ;
        private TextBoxEx txbVelosity;
        private TextBoxEx txbStartTime;
        private ComboBoxEx cmbRef;
        private ComboBoxEx cmbTraj;
        private System.Windows.Forms.Button btnCreatePhysicalData;

        private BaseModule.Tasks.TasksFromNavigator.Controls.MaterialControl matControl;
        private BaseModule.Tasks.TasksFromNavigator.Controls.ClampControl clampControl;
    }
}
