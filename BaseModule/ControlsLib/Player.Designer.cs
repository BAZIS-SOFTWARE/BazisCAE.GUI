using BaseModule.ControlsLib;
using System.Drawing;

namespace BaseModule.ControlsLib
{
    partial class Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStopCheck = new System.Windows.Forms.Button();
            this.colorSlider = new ColorSlider();
            this.btnCheckDinamic = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(84, 29);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 13);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Начните проверку";
            // 
            // btnStopCheck
            // 
            this.btnStopCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStopCheck.AutoSize = true;
            this.btnStopCheck.Image =  Properties.Resources.Stop.ToBitmap();
            this.btnStopCheck.Location = new System.Drawing.Point(26, 0);
            this.btnStopCheck.Margin = new System.Windows.Forms.Padding(0);
            this.btnStopCheck.Name = "btnStopCheck";
            this.btnStopCheck.Size = new System.Drawing.Size(26, 26);
            this.btnStopCheck.TabIndex = 24;
            this.btnStopCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStopCheck.UseVisualStyleBackColor = true;
            this.btnStopCheck.Click += new System.EventHandler(this.StopChecking_Click);
            // 
            // colorSlider
            // 
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(52, 0);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(0);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(163, 26);
            this.colorSlider.SmallChange = ((uint)(1u));
            this.colorSlider.TabIndex = 26;
            this.colorSlider.Text = "colorSlider";
            this.colorSlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // btnCheckDinamic
            // 
            this.btnCheckDinamic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckDinamic.AutoSize = true;
            this.btnCheckDinamic.Image = Properties.Resources.StartCheck;
            this.btnCheckDinamic.Location = new System.Drawing.Point(0, 0);
            this.btnCheckDinamic.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheckDinamic.Name = "btnCheckDinamic";
            this.btnCheckDinamic.Size = new System.Drawing.Size(26, 26);
            this.btnCheckDinamic.TabIndex = 25;
            this.btnCheckDinamic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckDinamic.UseVisualStyleBackColor = true;
            this.btnCheckDinamic.Click += new System.EventHandler(this.StartChecking_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnCheckDinamic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorSlider, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStopCheck, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 45);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(215, 45);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(215, 45);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStopCheck;
        private ColorSlider colorSlider;
        private System.Windows.Forms.Button btnCheckDinamic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
