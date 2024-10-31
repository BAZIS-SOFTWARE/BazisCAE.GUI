namespace ModelModule.SettingsControls
{
    partial class GMSHVolSettingsControl
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txbLayerThickness = new UserControlsEx.TextBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txbSurfaceMeshSize = new UserControlsEx.TextBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txbCoreMeshSize = new UserControlsEx.TextBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetGradientSettings = new System.Windows.Forms.Button();
            this.txbMeshGradientPower = new UserControlsEx.TextBoxEx(this.components);
            this.btnDelGradient = new System.Windows.Forms.Button();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txbLayerThickness, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txbSurfaceMeshSize, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbCoreMeshSize, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSetGradientSettings, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.txbMeshGradientPower, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnDelGradient, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31086F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31086F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31086F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.06741F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(565, 321);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Степень градиента";
            // 
            // txbLayerThickness
            // 
            this.txbLayerThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbLayerThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbLayerThickness.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbLayerThickness.IsValidating = true;
            this.txbLayerThickness.Location = new System.Drawing.Point(246, 27);
            this.txbLayerThickness.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbLayerThickness.Name = "txbLayerThickness";
            this.txbLayerThickness.Size = new System.Drawing.Size(299, 20);
            this.txbLayerThickness.TabIndex = 11;
            this.txbLayerThickness.UserRegExCheck = null;
            this.txbLayerThickness.UserRegExCheckErrorMessage = null;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер элементов в центре";
            // 
            // txbSurfaceMeshSize
            // 
            this.txbSurfaceMeshSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSurfaceMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSurfaceMeshSize.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbSurfaceMeshSize.IsValidating = true;
            this.txbSurfaceMeshSize.Location = new System.Drawing.Point(246, 101);
            this.txbSurfaceMeshSize.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbSurfaceMeshSize.Name = "txbSurfaceMeshSize";
            this.txbSurfaceMeshSize.Size = new System.Drawing.Size(299, 20);
            this.txbSurfaceMeshSize.TabIndex = 12;
            this.txbSurfaceMeshSize.UserRegExCheck = null;
            this.txbSurfaceMeshSize.UserRegExCheckErrorMessage = null;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Размер элементов на поверхности";
            // 
            // txbCoreMeshSize
            // 
            this.txbCoreMeshSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCoreMeshSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCoreMeshSize.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbCoreMeshSize.IsValidating = true;
            this.txbCoreMeshSize.Location = new System.Drawing.Point(246, 175);
            this.txbCoreMeshSize.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbCoreMeshSize.Name = "txbCoreMeshSize";
            this.txbCoreMeshSize.Size = new System.Drawing.Size(299, 20);
            this.txbCoreMeshSize.TabIndex = 13;
            this.txbCoreMeshSize.UserRegExCheck = null;
            this.txbCoreMeshSize.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Толщина слоя";
            // 
            // btnSetGradientSettings
            // 
            this.btnSetGradientSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetGradientSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetGradientSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetGradientSettings.Location = new System.Drawing.Point(246, 287);
            this.btnSetGradientSettings.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnSetGradientSettings.Name = "btnSetGradientSettings";
            this.btnSetGradientSettings.Size = new System.Drawing.Size(299, 27);
            this.btnSetGradientSettings.TabIndex = 14;
            this.btnSetGradientSettings.Text = "Задать настройки";
            this.btnSetGradientSettings.UseVisualStyleBackColor = true;
            this.btnSetGradientSettings.Click += new System.EventHandler(this.btnSetGradientSettings_Click);
            // 
            // txbMeshGradientPower
            // 
            this.txbMeshGradientPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMeshGradientPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMeshGradientPower.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbMeshGradientPower.IsValidating = true;
            this.txbMeshGradientPower.Location = new System.Drawing.Point(246, 241);
            this.txbMeshGradientPower.Margin = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.txbMeshGradientPower.Name = "txbMeshGradientPower";
            this.txbMeshGradientPower.Size = new System.Drawing.Size(299, 20);
            this.txbMeshGradientPower.TabIndex = 15;
            this.txbMeshGradientPower.UserRegExCheck = null;
            this.txbMeshGradientPower.UserRegExCheckErrorMessage = null;
            // 
            // btnDelGradient
            // 
            this.btnDelGradient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelGradient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelGradient.Location = new System.Drawing.Point(20, 287);
            this.btnDelGradient.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDelGradient.Name = "btnDelGradient";
            this.btnDelGradient.Size = new System.Drawing.Size(186, 27);
            this.btnDelGradient.TabIndex = 17;
            this.btnDelGradient.Text = "Удалить настройки";
            this.btnDelGradient.UseVisualStyleBackColor = true;
            this.btnDelGradient.Click += new System.EventHandler(this.btnDelGradient_Click);
            // 
            // GMSHVolSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "GMSHVolSettingsControl";
            this.Size = new System.Drawing.Size(565, 321);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private UserControlsEx.TextBoxEx txbLayerThickness;
        private System.Windows.Forms.Label label5;
        private UserControlsEx.TextBoxEx txbSurfaceMeshSize;
        private System.Windows.Forms.Label label4;
        private UserControlsEx.TextBoxEx txbCoreMeshSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetGradientSettings;
        private UserControlsEx.TextBoxEx txbMeshGradientPower;
        private System.Windows.Forms.Button btnDelGradient;
    }
}
