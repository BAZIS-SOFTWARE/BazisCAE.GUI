using System;
using System.Windows.Forms;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    partial class MaterialControlCreator
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
            this.materialGroupBox = new System.Windows.Forms.GroupBox();
            this.matTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gropElementsLabel = new System.Windows.Forms.Label();
            this.cmbEl = new UserControlsEx.ComboBoxEx(this.components);
            this.matLabel = new System.Windows.Forms.Label();
            this.cmbMat = new UserControlsEx.ComboBoxEx(this.components);
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.timeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startLabel = new System.Windows.Forms.Label();
            this.txbStartTime = new UserControlsEx.TextBoxEx(this.components);
            this.stopLabel = new System.Windows.Forms.Label();
            this.txbStopTime = new UserControlsEx.TextBoxEx(this.components);
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialGroupBox.SuspendLayout();
            this.matTableLayoutPanel.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            this.timeTableLayoutPanel.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialGroupBox
            // 
            this.materialGroupBox.AutoSize = true;
            this.materialGroupBox.Controls.Add(this.matTableLayoutPanel);
            this.materialGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialGroupBox.Location = new System.Drawing.Point(4, 3);
            this.materialGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.materialGroupBox.Name = "materialGroupBox";
            this.materialGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.materialGroupBox.Size = new System.Drawing.Size(520, 73);
            this.materialGroupBox.TabIndex = 1;
            this.materialGroupBox.TabStop = false;
            this.materialGroupBox.Text = "Выбор материала";
            // 
            // matTableLayoutPanel
            // 
            this.matTableLayoutPanel.AutoSize = true;
            this.matTableLayoutPanel.ColumnCount = 2;
            this.matTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.matTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.matTableLayoutPanel.Controls.Add(this.gropElementsLabel, 0, 0);
            this.matTableLayoutPanel.Controls.Add(this.cmbEl, 1, 0);
            this.matTableLayoutPanel.Controls.Add(this.matLabel, 0, 1);
            this.matTableLayoutPanel.Controls.Add(this.cmbMat, 1, 1);
            this.matTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matTableLayoutPanel.Location = new System.Drawing.Point(4, 16);
            this.matTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.matTableLayoutPanel.Name = "matTableLayoutPanel";
            this.matTableLayoutPanel.RowCount = 2;
            this.matTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.matTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.matTableLayoutPanel.Size = new System.Drawing.Size(512, 54);
            this.matTableLayoutPanel.TabIndex = 0;
            // 
            // gropElementsLabel
            // 
            this.gropElementsLabel.AutoSize = true;
            this.gropElementsLabel.Location = new System.Drawing.Point(10, 10);
            this.gropElementsLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.gropElementsLabel.Name = "gropElementsLabel";
            this.gropElementsLabel.Size = new System.Drawing.Size(100, 13);
            this.gropElementsLabel.TabIndex = 16;
            this.gropElementsLabel.Text = "Группа элементов";
            this.gropElementsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbEl.IsValidating = true;
            this.cmbEl.Location = new System.Drawing.Point(153, 3);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(344, 21);
            this.cmbEl.TabIndex = 14;
            this.cmbEl.UserRegExCheck = null;
            this.cmbEl.UserRegExCheckErrorMessage = null;
            // 
            // matLabel
            // 
            this.matLabel.AutoSize = true;
            this.matLabel.Location = new System.Drawing.Point(10, 37);
            this.matLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.matLabel.Name = "matLabel";
            this.matLabel.Size = new System.Drawing.Size(57, 13);
            this.matLabel.TabIndex = 15;
            this.matLabel.Text = "Материал";
            this.matLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMat
            // 
            this.cmbMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMat.FormattingEnabled = true;
            this.cmbMat.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbMat.IsValidating = true;
            this.cmbMat.Location = new System.Drawing.Point(153, 30);
            this.cmbMat.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.cmbMat.Name = "cmbMat";
            this.cmbMat.Size = new System.Drawing.Size(344, 21);
            this.cmbMat.TabIndex = 13;
            this.cmbMat.UserRegExCheck = null;
            this.cmbMat.UserRegExCheckErrorMessage = null;
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.AutoSize = true;
            this.timeGroupBox.Controls.Add(this.timeTableLayoutPanel);
            this.timeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeGroupBox.Location = new System.Drawing.Point(4, 82);
            this.timeGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeGroupBox.Size = new System.Drawing.Size(520, 73);
            this.timeGroupBox.TabIndex = 1;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Время действия";
            // 
            // timeTableLayoutPanel
            // 
            this.timeTableLayoutPanel.AutoSize = true;
            this.timeTableLayoutPanel.ColumnCount = 2;
            this.timeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.timeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.timeTableLayoutPanel.Controls.Add(this.startLabel, 0, 0);
            this.timeTableLayoutPanel.Controls.Add(this.txbStartTime, 1, 0);
            this.timeTableLayoutPanel.Controls.Add(this.stopLabel, 0, 1);
            this.timeTableLayoutPanel.Controls.Add(this.txbStopTime, 1, 1);
            this.timeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTableLayoutPanel.Location = new System.Drawing.Point(4, 16);
            this.timeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.timeTableLayoutPanel.Name = "timeTableLayoutPanel";
            this.timeTableLayoutPanel.RowCount = 2;
            this.timeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeTableLayoutPanel.Size = new System.Drawing.Size(512, 54);
            this.timeTableLayoutPanel.TabIndex = 0;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(10, 10);
            this.startLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(63, 13);
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
            this.txbStartTime.Location = new System.Drawing.Point(153, 3);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(344, 20);
            this.txbStartTime.TabIndex = 0;
            this.txbStartTime.UserRegExCheck = null;
            this.txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Location = new System.Drawing.Point(10, 37);
            this.stopLabel.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(58, 13);
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
            this.txbStopTime.Location = new System.Drawing.Point(153, 30);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(10, 3, 15, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(344, 20);
            this.txbStopTime.TabIndex = 1;
            this.txbStopTime.UserRegExCheck = null;
            this.txbStopTime.UserRegExCheckErrorMessage = null;
            // 
            // generalTableLayoutPanel
            // 
            this.generalTableLayoutPanel.AutoSize = true;
            this.generalTableLayoutPanel.ColumnCount = 1;
            this.generalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalTableLayoutPanel.Controls.Add(this.materialGroupBox, 0, 0);
            this.generalTableLayoutPanel.Controls.Add(this.timeGroupBox, 0, 1);
            this.generalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            this.generalTableLayoutPanel.RowCount = 2;
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.generalTableLayoutPanel.Size = new System.Drawing.Size(528, 158);
            this.generalTableLayoutPanel.TabIndex = 0;
            // 
            // MaterialControlCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.generalTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MaterialControlCreator";
            this.Size = new System.Drawing.Size(528, 158);
            this.materialGroupBox.ResumeLayout(false);
            this.materialGroupBox.PerformLayout();
            this.matTableLayoutPanel.ResumeLayout(false);
            this.matTableLayoutPanel.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            this.timeTableLayoutPanel.ResumeLayout(false);
            this.timeTableLayoutPanel.PerformLayout();
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private GroupBox materialGroupBox;
        private GroupBox timeGroupBox;
        private TableLayoutPanel generalTableLayoutPanel;
        private TableLayoutPanel matTableLayoutPanel;
        private TableLayoutPanel timeTableLayoutPanel;
        private Label gropElementsLabel;
        private Label matLabel;
        private Label startLabel;
        private Label stopLabel;        
        private ComboBoxEx cmbEl;
        private ComboBoxEx cmbMat;
        private TextBoxEx txbStartTime;
        private TextBoxEx txbStopTime;
    }
}
