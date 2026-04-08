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
            txbAngle = new TextBoxEx(components);
            chbChangeDirection = new CheckBox();
            generalPanel.SuspendLayout();
            SuspendLayout();
            // 
            // generalPanel
            // 
            generalPanel.AutoSize = true;
            generalPanel.ColumnCount = 2;
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            generalPanel.Controls.Add(rbtSet, 0, 0);
            generalPanel.Controls.Add(rbtSurface, 0, 1);
            generalPanel.Controls.Add(rbtDirection, 0, 2);
            generalPanel.Controls.Add(lblAngle, 0, 3);
            generalPanel.Controls.Add(txbAngle, 1, 3);
            generalPanel.Controls.Add(chbChangeDirection, 0, 4);
            generalPanel.Dock = DockStyle.Fill;
            generalPanel.Location = new Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.RowCount = 5;
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            generalPanel.Size = new Size(225, 150);
            generalPanel.TabIndex = 0;
            // 
            // rbtSet
            // 
            rbtSet.Anchor = AnchorStyles.Left;
            rbtSet.AutoSize = true;
            rbtSet.Checked = true;
            generalPanel.SetColumnSpan(rbtSet, 2);
            rbtSet.Location = new Point(8, 5);
            rbtSet.Margin = new Padding(8, 0, 0, 0);
            rbtSet.Name = "rbtSet";
            rbtSet.Size = new Size(70, 19);
            rbtSet.TabIndex = 8;
            rbtSet.TabStop = true;
            rbtSet.Text = "Наборы";
            // 
            // rbtSurface
            // 
            rbtSurface.Anchor = AnchorStyles.Left;
            rbtSurface.AutoSize = true;
            generalPanel.SetColumnSpan(rbtSurface, 2);
            rbtSurface.Location = new Point(8, 35);
            rbtSurface.Margin = new Padding(8, 0, 0, 0);
            rbtSurface.Name = "rbtSurface";
            rbtSurface.Size = new Size(93, 19);
            rbtSurface.TabIndex = 8;
            rbtSurface.TabStop = true;
            rbtSurface.Text = "В плоскости";
            // 
            // rbtDirection
            // 
            rbtDirection.Anchor = AnchorStyles.Left;
            rbtDirection.AutoSize = true;
            generalPanel.SetColumnSpan(rbtDirection, 2);
            rbtDirection.Location = new Point(8, 65);
            rbtDirection.Margin = new Padding(8, 0, 0, 0);
            rbtDirection.Name = "rbtDirection";
            rbtDirection.Size = new Size(120, 19);
            rbtDirection.TabIndex = 8;
            rbtDirection.TabStop = true;
            rbtDirection.Text = "По направлению";
            // 
            // lblAngle
            // 
            lblAngle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblAngle.AutoSize = true;
            lblAngle.Location = new Point(3, 90);
            lblAngle.Name = "lblAngle";
            lblAngle.Padding = new Padding(5, 3, 0, 5);
            lblAngle.Size = new Size(38, 30);
            lblAngle.TabIndex = 9;
            lblAngle.Text = "Угол";
            lblAngle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbAngle
            // 
            txbAngle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbAngle.BorderStyle = BorderStyle.FixedSingle;
            txbAngle.InputType = TXTBoxInputType.Text;
            txbAngle.IsValidating = true;
            txbAngle.Location = new Point(67, 93);
            txbAngle.Margin = new Padding(0, 0, 20, 0);
            txbAngle.Name = "txbAngle";
            txbAngle.Size = new Size(138, 23);
            txbAngle.TabIndex = 6;
            txbAngle.Text = "5";
            txbAngle.UserRegExCheck = null;
            txbAngle.UserRegExCheckErrorMessage = null;
            // 
            // chbChangeDirection
            // 
            chbChangeDirection.AutoSize = true;
            generalPanel.SetColumnSpan(chbChangeDirection, 2);
            chbChangeDirection.Location = new Point(3, 123);
            chbChangeDirection.Name = "chbChangeDirection";
            chbChangeDirection.Padding = new Padding(5, 0, 0, 0);
            chbChangeDirection.Size = new Size(154, 19);
            chbChangeDirection.TabIndex = 10;
            chbChangeDirection.Text = "Сменить направление";
            chbChangeDirection.UseVisualStyleBackColor = true;
            chbChangeDirection.CheckedChanged += chbChangeDirection_CheckedChanged;
            // 
            // MeshSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(generalPanel);
            Name = "MeshSelect";
            Size = new Size(225, 150);
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
