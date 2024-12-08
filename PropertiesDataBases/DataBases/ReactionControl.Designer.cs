namespace PropertiesDataBases.DataBases
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
            this.cmbInitialPhase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFinalPhase = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.chbTimeDependent = new System.Windows.Forms.CheckBox();
            this.btnChangePhaseValue = new System.Windows.Forms.Button();
            this.btnDelPhaseValue = new System.Windows.Forms.Button();
            this.btnAddPhaseValue = new System.Windows.Forms.Button();
            this.txbPhaseValue = new System.Windows.Forms.TextBox();
            this.cmbPhaseName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbInitialPhase
            // 
            this.cmbInitialPhase.AccessibleName = "InitialPhase";
            this.cmbInitialPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInitialPhase.FormattingEnabled = true;
            this.cmbInitialPhase.Location = new System.Drawing.Point(119, 3);
            this.cmbInitialPhase.Name = "cmbInitialPhase";
            this.cmbInitialPhase.Size = new System.Drawing.Size(471, 21);
            this.cmbInitialPhase.TabIndex = 1;
            this.cmbInitialPhase.SelectionChangeCommitted += new System.EventHandler(this.cmbInitialPhase_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Начальная фаза";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Конечная фаза";
            // 
            // cmbFinalPhase
            // 
            this.cmbFinalPhase.AccessibleName = "FinalPhase";
            this.cmbFinalPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFinalPhase.FormattingEnabled = true;
            this.cmbFinalPhase.Location = new System.Drawing.Point(119, 30);
            this.cmbFinalPhase.Name = "cmbFinalPhase";
            this.cmbFinalPhase.Size = new System.Drawing.Size(471, 21);
            this.cmbFinalPhase.TabIndex = 1;
            this.cmbFinalPhase.SelectionChangeCommitted += new System.EventHandler(this.cmbFinalPhase_SelectionChangeCommitted);
            // 
            // dgv
            // 
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 137);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(587, 346);
            this.dgv.TabIndex = 4;
            this.dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseClick);
            // 
            // chbTimeDependent
            // 
            this.chbTimeDependent.AutoSize = true;
            this.chbTimeDependent.Location = new System.Drawing.Point(119, 84);
            this.chbTimeDependent.Name = "chbTimeDependent";
            this.chbTimeDependent.Size = new System.Drawing.Size(174, 17);
            this.chbTimeDependent.TabIndex = 5;
            this.chbTimeDependent.Text = "Реакция зависит от времени";
            this.chbTimeDependent.UseVisualStyleBackColor = true;
            this.chbTimeDependent.Click += new System.EventHandler(this.chbTimeDependent_Click);
            // 
            // btnChangePhaseValue
            // 
            this.btnChangePhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangePhaseValue.Enabled = false;
            this.btnChangePhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePhaseValue.Image = global::PropertiesDataBases.Properties.Resources.Refresh;
            this.btnChangePhaseValue.Location = new System.Drawing.Point(88, 106);
            this.btnChangePhaseValue.Name = "btnChangePhaseValue";
            this.btnChangePhaseValue.Size = new System.Drawing.Size(25, 25);
            this.btnChangePhaseValue.TabIndex = 2;
            this.btnChangePhaseValue.UseVisualStyleBackColor = true;
            this.btnChangePhaseValue.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelPhaseValue
            // 
            this.btnDelPhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelPhaseValue.Enabled = false;
            this.btnDelPhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelPhaseValue.Image = global::PropertiesDataBases.Properties.Resources.delete.ToBitmap();
            this.btnDelPhaseValue.Location = new System.Drawing.Point(57, 106);
            this.btnDelPhaseValue.Name = "btnDelPhaseValue";
            this.btnDelPhaseValue.Size = new System.Drawing.Size(25, 25);
            this.btnDelPhaseValue.TabIndex = 6;
            this.btnDelPhaseValue.UseVisualStyleBackColor = true;
            this.btnDelPhaseValue.Click += new System.EventHandler(this.btnDelTime_Click);
            // 
            // btnAddPhaseValue
            // 
            this.btnAddPhaseValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddPhaseValue.Enabled = false;
            this.btnAddPhaseValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhaseValue.Image = global::PropertiesDataBases.Properties.Resources.Add.ToBitmap();
            this.btnAddPhaseValue.Location = new System.Drawing.Point(26, 106);
            this.btnAddPhaseValue.Name = "btnAddPhaseValue";
            this.btnAddPhaseValue.Size = new System.Drawing.Size(25, 25);
            this.btnAddPhaseValue.TabIndex = 6;
            this.btnAddPhaseValue.UseVisualStyleBackColor = true;
            this.btnAddPhaseValue.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // txbPhaseValue
            // 
            this.txbPhaseValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPhaseValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPhaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbPhaseValue.Location = new System.Drawing.Point(119, 106);
            this.txbPhaseValue.Name = "txbPhaseValue";
            this.txbPhaseValue.Size = new System.Drawing.Size(471, 25);
            this.txbPhaseValue.TabIndex = 7;
            this.txbPhaseValue.Text = "1";
            // 
            // cmbPhaseName
            // 
            this.cmbPhaseName.AccessibleName = "PhaseName";
            this.cmbPhaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhaseName.FormattingEnabled = true;
            this.cmbPhaseName.Items.AddRange(new object[] {
            "Охлаждение",
            "Нагрев",
            "Выдержка"});
            this.cmbPhaseName.Location = new System.Drawing.Point(119, 57);
            this.cmbPhaseName.Name = "cmbPhaseName";
            this.cmbPhaseName.Size = new System.Drawing.Size(471, 21);
            this.cmbPhaseName.TabIndex = 1;
            this.cmbPhaseName.SelectionChangeCommitted += new System.EventHandler(this.cmbPhaseName_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название реакции";
            // 
            // ReactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbPhaseValue);
            this.Controls.Add(this.btnDelPhaseValue);
            this.Controls.Add(this.btnAddPhaseValue);
            this.Controls.Add(this.chbTimeDependent);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangePhaseValue);
            this.Controls.Add(this.cmbPhaseName);
            this.Controls.Add(this.cmbFinalPhase);
            this.Controls.Add(this.cmbInitialPhase);
            this.Name = "ReactionControl";
            this.Size = new System.Drawing.Size(593, 486);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
