using System.Windows.Forms;
using System.Drawing;
using TaskModule.BasicAdvisorControls;
using System.Reflection.Emit;
using MathNet.Numerics;
using UserControlsEx;

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
            this.movementParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.trajectoryTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelX = new TableLayoutPanel();
            this.tableLayoutPanelY = new TableLayoutPanel();
            this.tableLayoutPanelZ = new TableLayoutPanel();
            this.tableLayoutPanelAngleX = new TableLayoutPanel();
            this.tableLayoutPanelAngleY = new TableLayoutPanel();
            this.tableLayoutPanelAngleZ = new TableLayoutPanel();
            this.baseLineLabel = new System.Windows.Forms.Label();
            this.refLineLabel = new System.Windows.Forms.Label();
            this.sourcePositionLabel = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.sourceVelocityLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelAngleX = new System.Windows.Forms.Label();
            this.labelAngleY = new System.Windows.Forms.Label();
            this.labelAngleZ = new System.Windows.Forms.Label();
            this.txbX = new TextBoxEx();
            this.txbY = new TextBoxEx();
            this.txbZ = new TextBoxEx();
            this.txbAngleX = new TextBoxEx();
            this.txbAngleY = new TextBoxEx();
            this.txbAngleZ = new TextBoxEx();
            this.txbVelosity = new TextBoxEx();
            this.txbStartTime = new TextBoxEx();
            this.cmbRef = new ComboBoxEx();
            this.cmbTraj = new ComboBoxEx();
            this.btnCreatePhysicalData = new Button();
            this.movementParametersGroupBox.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // movementParametersGroupBox
            // 
            this.movementParametersGroupBox.AutoSize = true;
            this.movementParametersGroupBox.Controls.Add(this.trajectoryTableLayoutPanel);
            this.movementParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movementParametersGroupBox.Location = new System.Drawing.Point(4, 119);
            this.movementParametersGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.movementParametersGroupBox.Name = "movementParametersGroupBox";
            this.movementParametersGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.movementParametersGroupBox.Size = new System.Drawing.Size(442, 170);
            this.movementParametersGroupBox.TabIndex = 1;
            this.movementParametersGroupBox.TabStop = false;
            this.movementParametersGroupBox.Text = "Параметры движения";
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.AutoSize = true;
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.generalTableLayoutPanel.Controls.Add(this.movementParametersGroupBox, 0, 1);
            this.generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 2;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.generalTableLayoutPanel.Size = new System.Drawing.Size(450, 292);
            this.generalTableLayoutPanel.TabIndex = 0;
            // 
            // trajectoryTableLayoutPanel
            // 
            this.trajectoryTableLayoutPanel.AutoSize = true;
            this.trajectoryTableLayoutPanel.ColumnCount = 4;
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.trajectoryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trajectoryTableLayoutPanel.Location = new System.Drawing.Point(4, 16);
            this.trajectoryTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trajectoryTableLayoutPanel.Name = "trajectoryTableLayoutPanel";
            this.trajectoryTableLayoutPanel.RowCount = 7;
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.trajectoryTableLayoutPanel.TabIndex = 0;
            this.trajectoryTableLayoutPanel.Controls.Add(baseLineLabel, 0, 0);
            this.trajectoryTableLayoutPanel.Controls.Add(cmbTraj, 1, 0);
            this.trajectoryTableLayoutPanel.SetColumnSpan(cmbTraj, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(refLineLabel, 0, 1);
            this.trajectoryTableLayoutPanel.Controls.Add(cmbRef, 1, 1);
            this.trajectoryTableLayoutPanel.SetColumnSpan(cmbRef, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(sourcePositionLabel, 0, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelX, 1, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelY, 2, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelZ, 3, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(rotationLabel, 0, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelAngleX, 1, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelAngleY, 2, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelAngleZ, 3, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(sourceVelocityLabel, 0, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(txbVelosity, 1, 4);
            this.trajectoryTableLayoutPanel.SetColumnSpan(txbVelosity, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(startLabel, 0, 5);
            this.trajectoryTableLayoutPanel.Controls.Add(txbStartTime, 1, 5);
            this.trajectoryTableLayoutPanel.SetColumnSpan(txbStartTime, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(btnCreatePhysicalData, 3, 6);
            //
            // tableLayoutPanelX
            //
            tableLayoutPanelX.Dock = DockStyle.Fill;
            tableLayoutPanelX.AutoSize = true;
            tableLayoutPanelX.ColumnCount = 2;
            tableLayoutPanelX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelX.RowCount = 1;
            tableLayoutPanelX.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelX.Controls.Add(labelX, 0, 0);
            tableLayoutPanelX.Controls.Add(txbX, 1, 0);
            //
            // tableLayoutPanelY
            //
            tableLayoutPanelY.Dock = DockStyle.Fill;
            tableLayoutPanelY.AutoSize = true;
            tableLayoutPanelY.ColumnCount = 2;
            tableLayoutPanelY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelY.RowCount = 1;
            tableLayoutPanelY.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelY.Controls.Add(labelY, 0, 0);
            tableLayoutPanelY.Controls.Add(txbY, 1, 0);
            //
            // tableLayoutPanelZ
            //
            tableLayoutPanelZ.Dock = DockStyle.Fill;
            tableLayoutPanelZ.AutoSize = true;
            tableLayoutPanelZ.ColumnCount = 2;
            tableLayoutPanelZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelZ.RowCount = 1;
            tableLayoutPanelZ.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelZ.Controls.Add(labelZ, 0, 0);
            tableLayoutPanelZ.Controls.Add(txbZ, 1, 0);
            //
            // tableLayoutPanelAngleX
            //
            tableLayoutPanelAngleX.Dock = DockStyle.Fill;
            tableLayoutPanelAngleX.AutoSize = true;
            tableLayoutPanelAngleX.ColumnCount = 2;
            tableLayoutPanelAngleX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelAngleX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelAngleX.RowCount = 1;
            tableLayoutPanelAngleX.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAngleX.Controls.Add(labelAngleX, 0, 0);
            tableLayoutPanelAngleX.Controls.Add(txbAngleX, 1, 0);
            //
            // tableLayoutPanelAngleY
            //
            tableLayoutPanelAngleY.Dock = DockStyle.Fill;
            tableLayoutPanelAngleY.AutoSize = true;
            tableLayoutPanelAngleY.ColumnCount = 2;
            tableLayoutPanelAngleY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelAngleY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelAngleY.RowCount = 1;
            tableLayoutPanelAngleY.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAngleY.Controls.Add(labelAngleY, 0, 0);
            tableLayoutPanelAngleY.Controls.Add(txbAngleY, 1, 0);
            //
            // tableLayoutPanelAngleZ
            //
            tableLayoutPanelAngleZ.Dock = DockStyle.Fill;
            tableLayoutPanelAngleZ.AutoSize = true;
            tableLayoutPanelAngleZ.ColumnCount = 2;
            tableLayoutPanelAngleZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelAngleZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelAngleZ.RowCount = 1;
            tableLayoutPanelAngleZ.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAngleZ.Controls.Add(labelAngleZ, 0, 0);
            tableLayoutPanelAngleZ.Controls.Add(txbAngleZ, 1, 0);
            // 
            // labelX
            // 
            labelX.Margin = new Padding(10, 10, 0, 0);
            labelX.AutoSize = true;
            labelX.Name = "labelX";
            labelX.TabIndex = 0;
            labelX.Text = "dX:";
            // 
            // txbX
            // 
            txbX.AccessibleName = "txbX";
            txbX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbX.InputType = TXTBoxInputType.Float;
            txbX.IsValidating = true;
            txbX.Margin = new Padding(0, 5, 15, 0);
            txbX.Name = "txbX";
            txbX.TabIndex = 0;
            txbX.UserRegExCheck = null;
            txbX.UserRegExCheckErrorMessage = null;
            // 
            // labelY
            // 
            labelY.Margin = new Padding(10, 10, 0, 0);
            labelY.AutoSize = true;
            labelY.Name = "labelY";
            labelY.TabIndex = 0;
            labelY.Text = "dY: ";
            // 
            // txbY
            // 
            txbY.AccessibleName = "txbY";
            txbY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbY.InputType = TXTBoxInputType.Float;
            txbY.IsValidating = true;
            txbY.Margin = new Padding(0, 5, 15, 0);
            txbY.Name = "txbY";
            txbY.TabIndex = 0;
            txbY.UserRegExCheck = null;
            txbY.UserRegExCheckErrorMessage = null;
            // 
            // labelZ
            // 
            labelZ.Margin = new Padding(10, 10, 0, 0);
            labelZ.AutoSize = true;
            labelZ.Name = "labelZ";
            labelZ.TabIndex = 0;
            labelZ.Text = "dZ: ";
            // 
            // txbZ
            // 
            txbZ.AccessibleName = "txbZ";
            txbZ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbZ.InputType = TXTBoxInputType.Float;
            txbZ.IsValidating = true;
            txbZ.Margin = new Padding(0, 5, 15, 0);
            txbZ.Name = "txbZ";
            txbZ.TabIndex = 0;
            txbZ.UserRegExCheck = null;
            txbZ.UserRegExCheckErrorMessage = null;
            // 
            // labelAngleX
            // 
            labelAngleX.Margin = new Padding(10, 10, 0, 0);
            labelAngleX.AutoSize = true;
            labelAngleX.Name = "labelAngleX";
            labelAngleX.TabIndex = 0;
            labelAngleX.Text = "Ось Х:";
            // 
            // txbAngleX
            // 
            txbAngleX.AccessibleName = "txbAngleX";
            txbAngleX.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbAngleX.InputType = TXTBoxInputType.Float;
            txbAngleX.IsValidating = true;
            txbAngleX.Margin = new Padding(0, 5, 15, 0);
            txbAngleX.Name = "txbAngleX";
            txbAngleX.TabIndex = 0;
            txbAngleX.UserRegExCheck = null;
            txbAngleX.UserRegExCheckErrorMessage = null;
            // 
            // labelAngleY
            // 
            labelAngleY.Margin = new Padding(10, 10, 0, 0);
            labelAngleY.AutoSize = true;
            labelAngleY.Name = "labelAngleY";
            labelAngleY.TabIndex = 0;
            labelAngleY.Text = "Ось Y:";
            // 
            // txbAngleY
            // 
            txbAngleY.AccessibleName = "txbAngleY";
            txbAngleY.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbAngleY.InputType = TXTBoxInputType.Float;
            txbAngleY.IsValidating = true;
            txbAngleY.Margin = new Padding(0, 5, 15, 0);
            txbAngleY.Name = "txbAngleY";
            txbAngleY.TabIndex = 0;
            txbAngleY.UserRegExCheck = null;
            txbAngleY.UserRegExCheckErrorMessage = null;
            // 
            // labelAngleZ
            // 
            labelAngleZ.Margin = new Padding(10, 10, 0, 0);
            labelAngleZ.AutoSize = true;
            labelAngleZ.Name = "labelAngleZ";
            labelAngleZ.TabIndex = 0;
            labelAngleZ.Text = "Ось Z:";
            // 
            // txbAngleZ
            // 
            txbAngleZ.AccessibleName = "txbAngle";
            txbAngleZ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbAngleZ.InputType = TXTBoxInputType.Float;
            txbAngleZ.IsValidating = true;
            txbAngleZ.Margin = new Padding(0, 5, 15, 0);
            txbAngleZ.Name = "txbAngle";
            txbAngleZ.TabIndex = 0;
            txbAngleZ.UserRegExCheck = null;
            txbAngleZ.UserRegExCheckErrorMessage = null;
            // 
            // baseLineLabel
            // 
            baseLineLabel.Margin = new Padding(10, 10, 0, 0);
            baseLineLabel.AutoSize = true;
            baseLineLabel.Name = "baseLineLabel";
            baseLineLabel.TabIndex = 0;
            baseLineLabel.Text = "Линия движения";
            // 
            // refLineLabel
            // 
            refLineLabel.Margin = new Padding(10, 10, 0, 0);
            refLineLabel.AutoSize = true;
            refLineLabel.Name = "refLineLabel";
            refLineLabel.TabIndex = 0;
            refLineLabel.Text = "Опорная линия";
            // 
            // sourcePositionLabel
            // 
            sourcePositionLabel.Margin = new Padding(10, 10, 0, 0);
            sourcePositionLabel.AutoSize = true;
            sourcePositionLabel.Name = "sourceositionLabel";
            sourcePositionLabel.TabIndex = 0;
            sourcePositionLabel.Text = "Смещение";
            // 
            // rotationLabel
            // 
            rotationLabel.Margin = new Padding(10, 10, 0, 0);
            rotationLabel.AutoSize = true;
            rotationLabel.Name = "RotationLabel";
            rotationLabel.TabIndex = 0;
            rotationLabel.Text = "Поворот";
            // 
            // sourceVelocityLabel
            // 
            sourceVelocityLabel.Margin = new Padding(10, 10, 0, 0);
            sourceVelocityLabel.AutoSize = true;
            sourceVelocityLabel.Name = "sourceVelocityLabel";
            sourceVelocityLabel.TabIndex = 0;
            sourceVelocityLabel.Text = "Скорость, мм/сек.";
            // 
            // txbVelosity
            // 
            txbVelosity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbVelosity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbVelosity.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            txbVelosity.IsValidating = true;
            txbVelosity.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbVelosity.Name = "txbVelosity";
            txbVelosity.TabIndex = 31;
            txbVelosity.UserRegExCheck = null;
            txbVelosity.UserRegExCheckErrorMessage = null;
            // 
            // startLabel
            // 
            startLabel.Margin = new Padding(10, 10, 0, 0);
            startLabel.AutoSize = true;
            startLabel.Name = "startLabel";
            startLabel.TabIndex = 0;
            startLabel.Text = "Старт, сек.";
            // 
            // txbStartTime
            //
            txbStartTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbStartTime.InputType = UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive;
            txbStartTime.IsValidating = true;
            txbStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            txbStartTime.Name = "txbStartTime";
            txbStartTime.TabIndex = 43;
            txbStartTime.UserRegExCheck = null;
            txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // cmbRef
            // 
            cmbRef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRef.FormattingEnabled = true;
            cmbRef.InputType = UserControlsEx.CMBInputType.Items;
            cmbRef.IsValidating = true;
            cmbRef.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbRef.Name = "cmbRef";
            cmbRef.TabIndex = 29;
            cmbRef.UserRegExCheck = null;
            cmbRef.UserRegExCheckErrorMessage = null;
            // 
            // cmbTraj
            // 
            cmbTraj.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTraj.FormattingEnabled = true;
            cmbTraj.InputType = UserControlsEx.CMBInputType.Items;
            cmbTraj.IsValidating = true;
            cmbTraj.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            cmbTraj.Name = "cmbTraj";
            cmbTraj.TabIndex = 29;
            cmbTraj.UserRegExCheck = null;
            cmbTraj.UserRegExCheckErrorMessage = null;
            // 
            // btnStartComp
            // 
            btnCreatePhysicalData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreatePhysicalData.Enabled = true;
            btnCreatePhysicalData.Margin = new Padding(10, 0, 15, 0);
            btnCreatePhysicalData.MinimumSize = new System.Drawing.Size(90, 35);
            btnCreatePhysicalData.Name = "btnCreatePhysicalData";
            btnCreatePhysicalData.Size = new System.Drawing.Size(110, 35);
            btnCreatePhysicalData.TabIndex = 0;
            btnCreatePhysicalData.Text = "Создать";
            btnCreatePhysicalData.UseVisualStyleBackColor = true;
            //btnStartComp.Click += btnStartComp_Click;
            // 
            // GeneralСontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.generalTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GeneralСontrol";
            this.Size = new System.Drawing.Size(600, 450);
            this.movementParametersGroupBox.ResumeLayout(false);
            this.movementParametersGroupBox.PerformLayout();
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
    }
}
