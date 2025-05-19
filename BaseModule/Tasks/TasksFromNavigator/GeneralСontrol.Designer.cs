using System.Windows.Forms;
using System.Drawing;
using TaskModule.BasicAdvisorControls;
using System.Reflection.Emit;
using MathNet.Numerics;

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
            this.baseLineLabel = new System.Windows.Forms.Label();
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
            this.trajectoryTableLayoutPanel.RowCount = 8;
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.trajectoryTableLayoutPanel.TabIndex = 0;
            this.trajectoryTableLayoutPanel.Controls.Add(baseLineLabel, 0, 0);
            // 
            // baseLineLabel
            // 
            baseLineLabel.Margin = new Padding(10, 10, 0, 0);
            baseLineLabel.AutoSize = true;
            baseLineLabel.Name = "baseLineLabel";
            baseLineLabel.TabIndex = 0;
            baseLineLabel.Text = "Линия движения";
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
        private GroupBox movementParametersGroupBox;
        private System.Windows.Forms.Label baseLineLabel;
    }
}
