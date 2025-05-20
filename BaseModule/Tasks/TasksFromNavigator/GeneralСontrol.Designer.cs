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
            this.tableLayoutPanelAngle = new TableLayoutPanel();
            this.baseLineLabel = new System.Windows.Forms.Label();
            this.refLineLabel = new System.Windows.Forms.Label();
            this.startNodeLabel = new System.Windows.Forms.Label();
            this.sourcePositionLabel = new System.Windows.Forms.Label();
            this.sourceVelocityLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelAngle = new System.Windows.Forms.Label();
            this.txbX = new TextBoxEx();
            this.txbY = new TextBoxEx();
            this.txbZ = new TextBoxEx();
            this.txbAngle = new TextBoxEx();
            this.cmbRef = new ComboBoxEx();
            this.cmbTraj = new ComboBoxEx();
            this.cmbStartPoint = new ComboBoxEx();
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
            this.trajectoryTableLayoutPanel.ColumnCount = 5;
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.trajectoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
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
            this.trajectoryTableLayoutPanel.SetColumnSpan(cmbTraj, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(refLineLabel, 0, 1);
            this.trajectoryTableLayoutPanel.Controls.Add(cmbRef, 1, 1);
            this.trajectoryTableLayoutPanel.SetColumnSpan(cmbRef, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(startNodeLabel, 0, 2);
            this.trajectoryTableLayoutPanel.Controls.Add(cmbStartPoint, 1, 2);
            this.trajectoryTableLayoutPanel.SetColumnSpan(cmbStartPoint, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(sourcePositionLabel, 0, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(sourceVelocityLabel, 0, 4);
            this.trajectoryTableLayoutPanel.Controls.Add(startLabel, 0, 5);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelX, 1, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelY, 2, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelZ, 3, 3);
            this.trajectoryTableLayoutPanel.Controls.Add(tableLayoutPanelAngle, 4, 3);
            //
            // tableLayoutPanelX
            //
            tableLayoutPanelX.Dock = DockStyle.Fill;
            tableLayoutPanelX.AutoSize = true;
            tableLayoutPanelX.ColumnCount = 2;
            tableLayoutPanelX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
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
            tableLayoutPanelY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelY.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
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
            tableLayoutPanelZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelZ.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelZ.RowCount = 1;
            tableLayoutPanelZ.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelZ.Controls.Add(labelZ, 0, 0);
            tableLayoutPanelZ.Controls.Add(txbZ, 1, 0);
            //
            // tableLayoutPanelAngle
            //
            tableLayoutPanelAngle.Dock = DockStyle.Fill;
            tableLayoutPanelAngle.AutoSize = true;
            tableLayoutPanelAngle.ColumnCount = 2;
            tableLayoutPanelAngle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAngle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAngle.RowCount = 1;
            tableLayoutPanelAngle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAngle.Controls.Add(labelAngle, 0, 0);
            tableLayoutPanelAngle.Controls.Add(txbAngle, 1, 0);
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
            // labelAngle
            // 
            labelAngle.Margin = new Padding(10, 10, 0, 0);
            labelAngle.AutoSize = true;
            labelAngle.Name = "labelAngle";
            labelAngle.TabIndex = 0;
            labelAngle.Text = "Угол: ";
            // 
            // txbAngle
            // 
            txbAngle.AccessibleName = "txbAngle";
            txbAngle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbAngle.InputType = TXTBoxInputType.Float;
            txbAngle.IsValidating = true;
            txbAngle.Margin = new Padding(0, 5, 15, 0);
            txbAngle.Name = "txbAngle";
            txbAngle.TabIndex = 0;
            txbAngle.UserRegExCheck = null;
            txbAngle.UserRegExCheckErrorMessage = null;
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
            // startNodeLabel
            // 
            startNodeLabel.Margin = new Padding(10, 10, 0, 0);
            startNodeLabel.AutoSize = true;
            startNodeLabel.Name = "startNodeLabel";
            startNodeLabel.TabIndex = 0;
            startNodeLabel.Text = "Точка начала";
            // 
            // sourceositionLabel
            // 
            sourcePositionLabel.Margin = new Padding(10, 10, 0, 0);
            sourcePositionLabel.AutoSize = true;
            sourcePositionLabel.Name = "sourceositionLabel";
            sourcePositionLabel.TabIndex = 0;
            sourcePositionLabel.Text = "Смещение источника";
            // 
            // sourceVelocityLabel
            // 
            sourceVelocityLabel.Margin = new Padding(10, 10, 0, 0);
            sourceVelocityLabel.AutoSize = true;
            sourceVelocityLabel.Name = "sourceVelocityLabel";
            sourceVelocityLabel.TabIndex = 0;
            sourceVelocityLabel.Text = "Скорость источника";
            // 
            // startLabel
            // 
            startLabel.Margin = new Padding(10, 10, 0, 0);
            startLabel.AutoSize = true;
            startLabel.Name = "startLabel";
            startLabel.TabIndex = 0;
            startLabel.Text = "Старт, сек.";
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
            this.cmbTraj.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbTraj.FormattingEnabled = true;
            this.cmbTraj.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbTraj.IsValidating = true;
            this.cmbTraj.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbTraj.Name = "cmbTraj";
            this.cmbTraj.TabIndex = 29;
            this.cmbTraj.UserRegExCheck = null;
            this.cmbTraj.UserRegExCheckErrorMessage = null;
            // 
            // cmbStartPoint
            // 
            this.cmbStartPoint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbStartPoint.FormattingEnabled = true;
            this.cmbStartPoint.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbStartPoint.IsValidating = true;
            this.cmbStartPoint.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbStartPoint.Name = "cmbStartPoint";
            this.cmbStartPoint.TabIndex = 35;
            this.cmbStartPoint.UserRegExCheck = null;
            this.cmbStartPoint.UserRegExCheckErrorMessage = null;
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
        private TableLayoutPanel tableLayoutPanelAngle;
        private GroupBox movementParametersGroupBox;
        private System.Windows.Forms.Label baseLineLabel;
        private System.Windows.Forms.Label refLineLabel;
        private System.Windows.Forms.Label startNodeLabel;
        private System.Windows.Forms.Label sourcePositionLabel;
        private System.Windows.Forms.Label sourceVelocityLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelAngle;
        private TextBoxEx txbX;
        private TextBoxEx txbY;
        private TextBoxEx txbZ;
        private TextBoxEx txbAngle;
        private ComboBoxEx cmbRef;
        private ComboBoxEx cmbTraj;
        private ComboBoxEx cmbStartPoint;
    }
}
