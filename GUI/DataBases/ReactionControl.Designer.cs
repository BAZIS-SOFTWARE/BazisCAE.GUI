namespace BazisGUI.DataBases
{
    partial class ReactionControl
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ReactionControl));
            cmbInitialPhase = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cmbFinalPhase = new System.Windows.Forms.ComboBox();
            dgv = new System.Windows.Forms.DataGridView();
            chbTimeDependent = new System.Windows.Forms.CheckBox();
            btnChangePhaseValue = new System.Windows.Forms.Button();
            btnDelPhaseValue = new System.Windows.Forms.Button();
            btnAddPhaseValue = new System.Windows.Forms.Button();
            txbPhaseValue = new System.Windows.Forms.TextBox();
            cmbPhaseName = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // cmbInitialPhase
            // 
            cmbInitialPhase.AccessibleName = "InitialPhase";
            cmbInitialPhase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbInitialPhase.FormattingEnabled = true;
            cmbInitialPhase.Location = new System.Drawing.Point(139, 3);
            cmbInitialPhase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbInitialPhase.Name = "cmbInitialPhase";
            cmbInitialPhase.Size = new System.Drawing.Size(549, 23);
            cmbInitialPhase.TabIndex = 1;
            cmbInitialPhase.SelectionChangeCommitted += cmbInitialPhase_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 7);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = "Начальная фаза";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(34, 38);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 15);
            label2.TabIndex = 3;
            label2.Text = "Конечная фаза";
            // 
            // cmbFinalPhase
            // 
            cmbFinalPhase.AccessibleName = "FinalPhase";
            cmbFinalPhase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbFinalPhase.FormattingEnabled = true;
            cmbFinalPhase.Location = new System.Drawing.Point(139, 35);
            cmbFinalPhase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbFinalPhase.Name = "cmbFinalPhase";
            cmbFinalPhase.Size = new System.Drawing.Size(549, 23);
            cmbFinalPhase.TabIndex = 1;
            cmbFinalPhase.SelectionChangeCommitted += cmbFinalPhase_SelectionChangeCommitted;
            // 
            // dgv
            // 
            dgv.AllowUserToOrderColumns = true;
            dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new System.Drawing.Point(4, 158);
            dgv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgv.Name = "dgv";
            dgv.Size = new System.Drawing.Size(685, 399);
            dgv.TabIndex = 4;
            dgv.ColumnHeaderMouseClick += dgv_ColumnHeaderMouseClick;
            // 
            // chbTimeDependent
            // 
            chbTimeDependent.AutoSize = true;
            chbTimeDependent.Location = new System.Drawing.Point(139, 97);
            chbTimeDependent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chbTimeDependent.Name = "chbTimeDependent";
            chbTimeDependent.Size = new System.Drawing.Size(182, 19);
            chbTimeDependent.TabIndex = 5;
            chbTimeDependent.Text = "Реакция зависит от времени";
            chbTimeDependent.UseVisualStyleBackColor = true;
            chbTimeDependent.Click += chbTimeDependent_Click;
            // 
            // btnChangePhaseValue
            // 
            btnChangePhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnChangePhaseValue.Enabled = false;
            btnChangePhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangePhaseValue.Image = (System.Drawing.Image)resources.GetObject("btnChangePhaseValue.Image");
            btnChangePhaseValue.Location = new System.Drawing.Point(103, 122);
            btnChangePhaseValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnChangePhaseValue.Name = "btnChangePhaseValue";
            btnChangePhaseValue.Size = new System.Drawing.Size(29, 29);
            btnChangePhaseValue.TabIndex = 2;
            btnChangePhaseValue.UseVisualStyleBackColor = true;
            btnChangePhaseValue.Click += btnChange_Click;
            // 
            // btnDelPhaseValue
            // 
            btnDelPhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnDelPhaseValue.Enabled = false;
            btnDelPhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelPhaseValue.Image = (System.Drawing.Image)resources.GetObject("btnDelPhaseValue.Image");
            btnDelPhaseValue.Location = new System.Drawing.Point(66, 122);
            btnDelPhaseValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDelPhaseValue.Name = "btnDelPhaseValue";
            btnDelPhaseValue.Size = new System.Drawing.Size(29, 29);
            btnDelPhaseValue.TabIndex = 6;
            btnDelPhaseValue.UseVisualStyleBackColor = true;
            btnDelPhaseValue.Click += btnDelTime_Click;
            // 
            // btnAddPhaseValue
            // 
            btnAddPhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnAddPhaseValue.Enabled = false;
            btnAddPhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddPhaseValue.Image = (System.Drawing.Image)resources.GetObject("btnAddPhaseValue.Image");
            btnAddPhaseValue.Location = new System.Drawing.Point(30, 122);
            btnAddPhaseValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddPhaseValue.Name = "btnAddPhaseValue";
            btnAddPhaseValue.Size = new System.Drawing.Size(29, 29);
            btnAddPhaseValue.TabIndex = 6;
            btnAddPhaseValue.UseVisualStyleBackColor = true;
            btnAddPhaseValue.Click += btnAddTime_Click;
            // 
            // txbPhaseValue
            // 
            txbPhaseValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbPhaseValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbPhaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            txbPhaseValue.Location = new System.Drawing.Point(139, 122);
            txbPhaseValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbPhaseValue.Name = "txbPhaseValue";
            txbPhaseValue.Size = new System.Drawing.Size(549, 25);
            txbPhaseValue.TabIndex = 7;
            txbPhaseValue.Text = "1";
            // 
            // cmbPhaseName
            // 
            cmbPhaseName.AccessibleName = "PhaseName";
            cmbPhaseName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbPhaseName.FormattingEnabled = true;
            cmbPhaseName.Items.AddRange(new object[] { "Охлаждение", "Нагрев", "Выдержка" });
            cmbPhaseName.Location = new System.Drawing.Point(139, 66);
            cmbPhaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbPhaseName.Name = "cmbPhaseName";
            cmbPhaseName.Size = new System.Drawing.Size(549, 23);
            cmbPhaseName.TabIndex = 1;
            cmbPhaseName.SelectionChangeCommitted += cmbPhaseName_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 69);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(108, 15);
            label3.TabIndex = 3;
            label3.Text = "Название реакции";
            // 
            // ReactionControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txbPhaseValue);
            Controls.Add(btnDelPhaseValue);
            Controls.Add(btnAddPhaseValue);
            Controls.Add(chbTimeDependent);
            Controls.Add(dgv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnChangePhaseValue);
            Controls.Add(cmbPhaseName);
            Controls.Add(cmbFinalPhase);
            Controls.Add(cmbInitialPhase);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ReactionControl";
            Size = new System.Drawing.Size(692, 561);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox cmbInitialPhase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFinalPhase;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckBox chbTimeDependent;
        private System.Windows.Forms.Button btnAddPhaseValue;
        private System.Windows.Forms.Button btnChangePhaseValue;
        private System.Windows.Forms.Button btnDelPhaseValue;
        private System.Windows.Forms.TextBox txbPhaseValue;
        private System.Windows.Forms.ComboBox cmbPhaseName;
        private System.Windows.Forms.Label label3;
    }
}
