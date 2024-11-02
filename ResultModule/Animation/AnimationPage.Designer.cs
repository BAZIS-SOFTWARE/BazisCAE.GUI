using BaseModule.Player;
using UserControlsEx;

namespace ResultModule.Animation
{
    partial class AnimationPage
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.chbDelTempScrs = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDelayTime = new UserControlsEx.TextBoxEx(this.components);
            this.btnCreateAnimation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.player = new BaseModule.Player.PlayerControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txbScale = new UserControlsEx.TextBoxEx(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbResultNames = new System.Windows.Forms.ComboBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.playerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(408, 503);
            this.tableLayoutPanel2.TabIndex = 42;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.61539F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chbDelTempScrs, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbDelayTime, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCreateAnimation, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 421);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(408, 82);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Задержка между слайдами";
            // 
            // chbDelTempScrs
            // 
            this.chbDelTempScrs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbDelTempScrs.AutoSize = true;
            this.chbDelTempScrs.Checked = true;
            this.chbDelTempScrs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDelTempScrs.Location = new System.Drawing.Point(210, 52);
            this.chbDelTempScrs.Margin = new System.Windows.Forms.Padding(4);
            this.chbDelTempScrs.Name = "chbDelTempScrs";
            this.chbDelTempScrs.Size = new System.Drawing.Size(15, 14);
            this.chbDelTempScrs.TabIndex = 6;
            this.chbDelTempScrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbDelTempScrs.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Удалить промежуточные результаты";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbDelayTime
            // 
            this.txbDelayTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbDelayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDelayTime.InputType = UserControlsEx.TXTBoxInputType.Integer;
            this.txbDelayTime.IsValidating = true;
            this.txbDelayTime.Location = new System.Drawing.Point(200, 8);
            this.txbDelayTime.Margin = new System.Windows.Forms.Padding(0);
            this.txbDelayTime.Name = "txbDelayTime";
            this.txbDelayTime.Size = new System.Drawing.Size(36, 20);
            this.txbDelayTime.TabIndex = 5;
            this.txbDelayTime.Text = "100";
            this.txbDelayTime.UserRegExCheck = null;
            this.txbDelayTime.UserRegExCheckErrorMessage = null;
            this.txbDelayTime.Leave += new System.EventHandler(this.txbDelayTime_Leave);
            // 
            // btnCreateAnimation
            // 
            this.btnCreateAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAnimation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAnimation.Location = new System.Drawing.Point(243, 45);
            this.btnCreateAnimation.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnCreateAnimation.Name = "btnCreateAnimation";
            this.btnCreateAnimation.Size = new System.Drawing.Size(158, 27);
            this.btnCreateAnimation.TabIndex = 3;
            this.btnCreateAnimation.Text = "Создать";
            this.btnCreateAnimation.UseVisualStyleBackColor = true;
            this.btnCreateAnimation.Click += new System.EventHandler(this.btnCreateAnimation_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.14712F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.85288F));
            this.tableLayoutPanel1.Controls.Add(this.playerPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbScale, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.53846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 100);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // playerPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.playerPanel, 3);
            this.playerPanel.Controls.Add(this.player);
            this.playerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerPanel.Enabled = false;
            this.playerPanel.Location = new System.Drawing.Point(4, 4);
            this.playerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(400, 53);
            this.playerPanel.TabIndex = 0;
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.CheckState = BaseModule.Player.CheckState.start;
            this.player.CurrentValue = 0;
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player.Location = new System.Drawing.Point(0, 0);
            this.player.Margin = new System.Windows.Forms.Padding(0);
            this.player.MinimumSize = new System.Drawing.Size(287, 55);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(400, 55);
            this.player.SliderBarInnerColor = System.Drawing.Color.Gold;
            this.player.SliderBarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.player.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.player.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.player.SpeedValue = 500;
            this.player.StartValue = 0;
            this.player.StopValue = 100;
            this.player.TabIndex = 0;
            this.player.CheckingEvent += new System.Action<object, float>(this.playerControl_CheckingEvent);
            this.player.StopCheckingEvent += new System.Action<object>(this.playerControl_StopCheckingEvent);
            this.player.StartCheckingEvent += new System.Action<object>(this.playerControl_StartCheckingEvent);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Масшт.";
            // 
            // txbScale
            // 
            this.txbScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbScale.InputType = UserControlsEx.TXTBoxInputType.Positive;
            this.txbScale.IsValidating = true;
            this.txbScale.Location = new System.Drawing.Point(272, 70);
            this.txbScale.Margin = new System.Windows.Forms.Padding(4, 4, 7, 4);
            this.txbScale.Name = "txbScale";
            this.txbScale.Size = new System.Drawing.Size(57, 20);
            this.txbScale.TabIndex = 20;
            this.txbScale.Text = "1";
            this.txbScale.UserRegExCheck = null;
            this.txbScale.UserRegExCheckErrorMessage = null;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 321);
            this.panel1.TabIndex = 50;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cmbResultNames, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.richTextBox, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(406, 319);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cmbResultNames
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cmbResultNames, 2);
            this.cmbResultNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbResultNames.FormattingEnabled = true;
            this.cmbResultNames.Location = new System.Drawing.Point(0, 0);
            this.cmbResultNames.Margin = new System.Windows.Forms.Padding(0);
            this.cmbResultNames.Name = "cmbResultNames";
            this.cmbResultNames.Size = new System.Drawing.Size(406, 21);
            this.cmbResultNames.TabIndex = 0;
            this.cmbResultNames.Text = "выберите результаты...";
            this.cmbResultNames.SelectedIndexChanged += new System.EventHandler(this.cmbResultNames_SelectedIndexChanged);
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel3.SetColumnSpan(this.richTextBox, 2);
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 24);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(406, 295);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            // 
            // AnimationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AnimationPage";
            this.Size = new System.Drawing.Size(408, 503);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.playerPanel.ResumeLayout(false);
            this.playerPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnCreateAnimation;
        private TextBoxEx txbDelayTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbDelTempScrs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel playerPanel;
        private PlayerControl player;
        private TextBoxEx txbScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbResultNames;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}
