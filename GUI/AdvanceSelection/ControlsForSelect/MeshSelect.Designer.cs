using System.Drawing;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    partial class MeshSelect
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
            generalPanel = new TableLayoutPanel();
            rbtSet = new RadioButton();
            rbtSurface = new RadioButton();
            rbtDirection = new RadioButton();
            lblAngle = new Label();
            txbAngle = new TextBoxEx();
            chbChangeDirection = new CheckBox();
            generalPanel.SuspendLayout();
            SuspendLayout();

            // 
            // generalPanel
            // 
            generalPanel.ColumnCount = 2;
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            generalPanel.RowCount = 5;
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.Controls.Add(rbtSet, 0, 0);
            generalPanel.Controls.Add(rbtSurface, 0, 1);
            generalPanel.Controls.Add(rbtDirection, 0 , 2);
            generalPanel.Controls.Add(lblAngle, 0, 3);
            generalPanel.Controls.Add(txbAngle, 1, 3);
            generalPanel.Controls.Add(chbChangeDirection, 0 , 4);
            generalPanel.SetColumnSpan(rbtSet, 2);
            generalPanel.SetColumnSpan(rbtSurface, 2);
            generalPanel.SetColumnSpan(rbtDirection, 2);
            generalPanel.SetColumnSpan(chbChangeDirection, 2);
            generalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            generalPanel.AutoSize = true;
            generalPanel.Location = new System.Drawing.Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.TabIndex = 0;

            //
            // rbtSet
            //
            rbtSet.Anchor = AnchorStyles.Left;
            rbtSet.AutoSize = true;
            rbtSet.Padding = new Padding(5,0,0,0);
            rbtSet.Name = "rbtSet";
            rbtSet.TabIndex = 8;
            rbtSet.TabStop = true;
            rbtSet.Text = "Наборы";
            rbtSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtSet.UseVisualStyleBackColor = true;
            //
            // rbtSurface
            //
            rbtSurface.Anchor = AnchorStyles.Left;
            rbtSurface.AutoSize = true;
            rbtSurface.Padding = new Padding(5, 0, 0, 0);
            rbtSurface.Name = "rbtSurface";
            rbtSurface.TabIndex = 8;
            rbtSurface.TabStop = true;
            rbtSurface.Text = "В плоскости";
            rbtSurface.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtSurface.UseVisualStyleBackColor = true;
            //
            // rbtDirection
            //
            rbtDirection.Anchor = AnchorStyles.Left;
            rbtDirection.AutoSize = true;
            rbtDirection.Padding = new Padding(5, 0, 0, 0);
            rbtDirection.Name = "rbtDirection";
            rbtDirection.TabIndex = 8;
            rbtDirection.TabStop = true;
            rbtDirection.Text = "По направлению";
            rbtDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtDirection.UseVisualStyleBackColor = true;
            //
            // lblAngle
            //
            lblAngle.AutoSize = true;
            lblAngle.Padding = new Padding(5, 3, 0, 0);
            lblAngle.Name = "lblAngle";
            lblAngle.TabIndex = 7;
            lblAngle.Text = "Угол";
            // 
            // txbAngle
            // 
            txbAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbAngle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbAngle.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            txbAngle.Name = "txbAngle";
            txbAngle.TabIndex = 6;
            // 
            // chbChangeDirection
            // 
            chbChangeDirection.AutoSize = true;
            chbChangeDirection.Name = "chbChangeDirection";
            chbChangeDirection.Padding = new Padding(5, 0, 0, 0);
            chbChangeDirection.TabIndex = 10;
            chbChangeDirection.Text = "Сменить направление";
            chbChangeDirection.UseVisualStyleBackColor = true;

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(generalPanel);
            Size = new System.Drawing.Size(400, 150);
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel generalPanel;

        private RadioButton rbtSet;
        private RadioButton rbtSurface;
        private RadioButton rbtDirection;

        private Label lblAngle;
        private TextBoxEx txbAngle;
        private CheckBox chbChangeDirection;
    }
}
