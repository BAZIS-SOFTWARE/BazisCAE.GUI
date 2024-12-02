using UserControlsEx;

namespace UserControlsEx.Graph
{
    partial class GraphContainer
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
            UserControlsEx.Graph.AxisFormat axisFormat1 = new UserControlsEx.Graph.AxisFormat();
            UserControlsEx.Graph.AxisFormat axisFormat2 = new UserControlsEx.Graph.AxisFormat();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphContainer));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.graphControl = new UserControlsEx.Graph.GraphControl();
            this.generalToolStrip = new UserControlsEx.ToolStripEx();
            this.dashButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.btnValue = new System.Windows.Forms.ToolStripButton();
            this.btnTitle = new System.Windows.Forms.ToolStripButton();
            this.btnPathThick = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnValueToTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txb_X_Max = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txb_X_Min = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txb_Y_Max = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txb_Y_Min = new System.Windows.Forms.ToolStripTextBox();
            this.showDataSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.btnFitGraph = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.generalToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.graphControl);
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(667, 394);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(667, 427);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.generalToolStrip);
            // 
            // graphControl
            // 
            this.graphControl.BackColor = System.Drawing.Color.White;
            this.graphControl.DashPaintFlag = false;
            this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphControl.LinePaintFlag = true;
            this.graphControl.Location = new System.Drawing.Point(0, 0);
            this.graphControl.Margin = new System.Windows.Forms.Padding(0);
            this.graphControl.Name = "graphControl";
            this.graphControl.Size = new System.Drawing.Size(667, 394);
            this.graphControl.TabIndex = 0;
            this.graphControl.Title = "test";
            this.graphControl.ValueFlag = false;
            this.graphControl.X_max = 10F;
            this.graphControl.X_min = 0F;
            axisFormat1.NumberOfSings = 2;
            axisFormat1.StepFormat = UserControlsEx.Graph.StepFormat.redular;
            axisFormat1.TextFormat = UserControlsEx.Graph.TextFormat.normal;
            this.graphControl.XAxisFormat = axisFormat1;
            this.graphControl.Y_max = 10F;
            this.graphControl.Y_min = 0F;
            axisFormat2.NumberOfSings = 2;
            axisFormat2.StepFormat = UserControlsEx.Graph.StepFormat.redular;
            axisFormat2.TextFormat = UserControlsEx.Graph.TextFormat.normal;
            this.graphControl.YAxisFormat = axisFormat2;
            this.graphControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseMove);
            // 
            // generalToolStrip
            // 
            this.generalToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.generalToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.generalToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.generalToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.generalToolStrip.GeneralFrame = false;
            this.generalToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.generalToolStrip.IconLocation = new System.Drawing.Point(1, 5);
            this.generalToolStrip.ImageRectangleSize = new System.Drawing.Point(16, 16);
            this.generalToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.generalToolStrip.ItemFrame = true;
            this.generalToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.generalToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.generalToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashButton,
            this.lineButton,
            this.btnValue,
            this.btnTitle,
            this.btnPathThick,
            this.btnValueToTable,
            this.toolStripLabel1,
            this.txb_X_Max,
            this.toolStripLabel2,
            this.txb_X_Min,
            this.toolStripLabel3,
            this.txb_Y_Max,
            this.toolStripLabel4,
            this.txb_Y_Min,
            this.showDataSplitButton,
            this.btnFitGraph});
            this.generalToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.generalToolStrip.Location = new System.Drawing.Point(0, 0);
            this.generalToolStrip.Name = "generalToolStrip";
            this.generalToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.generalToolStrip.Size = new System.Drawing.Size(667, 33);
            this.generalToolStrip.SplitButtonClickWidth = 12;
            this.generalToolStrip.SplitButtonHeight = 30;
            this.generalToolStrip.SplitButtonTriangleSize = 6;
            this.generalToolStrip.Stretch = true;
            this.generalToolStrip.TabIndex = 0;
            this.generalToolStrip.Text = " ";
            this.generalToolStrip.TextBoxFrame = true;
            this.generalToolStrip.TextBoxHeight = 0;
            // 
            // dashButton
            // 
            this.dashButton.AutoSize = false;
            this.dashButton.CheckOnClick = true;
            this.dashButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dashButton.Image = ((System.Drawing.Image)(resources.GetObject("dashButton.Image")));
            this.dashButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dashButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dashButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dashButton.Margin = new System.Windows.Forms.Padding(0);
            this.dashButton.Name = "dashButton";
            this.dashButton.Size = new System.Drawing.Size(30, 30);
            this.dashButton.Text = "toolStripButton1";
            this.dashButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dashButton.ToolTipText = "Трассировка";
            this.dashButton.CheckedChanged += new System.EventHandler(this.DashPaintButton_CheckedChanged);
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = false;
            this.lineButton.Checked = true;
            this.lineButton.CheckOnClick = true;
            this.lineButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lineButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Margin = new System.Windows.Forms.Padding(0);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(30, 30);
            this.lineButton.Text = "toolStripButton2";
            this.lineButton.ToolTipText = "Разметка";
            this.lineButton.CheckedChanged += new System.EventHandler(this.LinePaintButton_CheckedChanged);
            // 
            // btnValue
            // 
            this.btnValue.AutoSize = false;
            this.btnValue.CheckOnClick = true;
            this.btnValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValue.Image = global::UserControlsEx.Properties.Resources.Show_value;
            this.btnValue.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValue.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnValue.Name = "btnValue";
            this.btnValue.Size = new System.Drawing.Size(30, 30);
            this.btnValue.Text = "Показать значения";
            this.btnValue.CheckedChanged += new System.EventHandler(this.ValueButton_CheckedChanged);
            // 
            // btnTitle
            // 
            this.btnTitle.AutoSize = false;
            this.btnTitle.Checked = true;
            this.btnTitle.CheckOnClick = true;
            this.btnTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTitle.Image = global::UserControlsEx.Properties.Resources.Title;
            this.btnTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTitle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(30, 30);
            this.btnTitle.Text = "T";
            this.btnTitle.Click += new System.EventHandler(this.btnTitle_Click);
            // 
            // btnPathThick
            // 
            this.btnPathThick.AutoSize = false;
            this.btnPathThick.BackColor = System.Drawing.SystemColors.Control;
            this.btnPathThick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPathThick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.btnPathThick.Image = ((System.Drawing.Image)(resources.GetObject("btnPathThick.Image")));
            this.btnPathThick.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPathThick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPathThick.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnPathThick.Name = "btnPathThick";
            this.btnPathThick.Size = new System.Drawing.Size(45, 30);
            this.btnPathThick.DropDownOpened += new System.EventHandler(this.PathThickButton_DropDownOpened);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 22);
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AutoSize = false;
            this.toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(40, 22);
            this.toolStripMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AutoSize = false;
            this.toolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(40, 22);
            this.toolStripMenuItem3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // btnValueToTable
            // 
            this.btnValueToTable.AutoSize = false;
            this.btnValueToTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValueToTable.Image = global::UserControlsEx.Properties.Resources.ExportToBuffer;
            this.btnValueToTable.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValueToTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValueToTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValueToTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnValueToTable.Name = "btnValueToTable";
            this.btnValueToTable.Size = new System.Drawing.Size(30, 30);
            this.btnValueToTable.Text = "Свести данные в таблицу";
            this.btnValueToTable.Click += new System.EventHandler(this.btnValueToTable_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 27);
            this.toolStripLabel1.Text = "Xmax";
            // 
            // txb_X_Max
            // 
            this.txb_X_Max.AutoSize = false;
            this.txb_X_Max.BackColor = System.Drawing.Color.White;
            this.txb_X_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_X_Max.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txb_X_Max.Name = "txb_X_Max";
            this.txb_X_Max.Size = new System.Drawing.Size(35, 25);
            this.txb_X_Max.Text = "566";
            this.txb_X_Max.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_X_Max.Leave += new System.EventHandler(this.XMaxTextBox_Leave);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 27);
            this.toolStripLabel2.Text = "Xmin";
            // 
            // txb_X_Min
            // 
            this.txb_X_Min.BackColor = System.Drawing.Color.White;
            this.txb_X_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_X_Min.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txb_X_Min.Name = "txb_X_Min";
            this.txb_X_Min.Size = new System.Drawing.Size(35, 33);
            this.txb_X_Min.Text = "0";
            this.txb_X_Min.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_X_Min.Leave += new System.EventHandler(this.XMinTextBox_Leave);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(36, 27);
            this.toolStripLabel3.Text = "Ymax";
            // 
            // txb_Y_Max
            // 
            this.txb_Y_Max.AutoSize = false;
            this.txb_Y_Max.BackColor = System.Drawing.Color.White;
            this.txb_Y_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Y_Max.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txb_Y_Max.Margin = new System.Windows.Forms.Padding(0);
            this.txb_Y_Max.Name = "txb_Y_Max";
            this.txb_Y_Max.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txb_Y_Max.Size = new System.Drawing.Size(35, 25);
            this.txb_Y_Max.Text = "0";
            this.txb_Y_Max.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_Y_Max.Leave += new System.EventHandler(this.YMaxTextBox_Leave);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(34, 32);
            this.toolStripLabel4.Text = "Ymin";
            // 
            // txb_Y_Min
            // 
            this.txb_Y_Min.AutoSize = false;
            this.txb_Y_Min.BackColor = System.Drawing.Color.White;
            this.txb_Y_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Y_Min.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txb_Y_Min.Name = "txb_Y_Min";
            this.txb_Y_Min.Size = new System.Drawing.Size(35, 25);
            this.txb_Y_Min.Text = "0";
            this.txb_Y_Min.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txb_Y_Min.Leave += new System.EventHandler(this.YMinTextBox_Leave);
            // 
            // showDataSplitButton
            // 
            this.showDataSplitButton.AutoSize = false;
            this.showDataSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showDataSplitButton.Image = global::UserControlsEx.Properties.Resources.SwitchOn;
            this.showDataSplitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showDataSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDataSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showDataSplitButton.Name = "showDataSplitButton";
            this.showDataSplitButton.Size = new System.Drawing.Size(45, 30);
            this.showDataSplitButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnFitGraph
            // 
            this.btnFitGraph.AutoSize = false;
            this.btnFitGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFitGraph.Image = global::UserControlsEx.Properties.Resources.Fit;
            this.btnFitGraph.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFitGraph.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFitGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFitGraph.Name = "btnFitGraph";
            this.btnFitGraph.Size = new System.Drawing.Size(30, 30);
            this.btnFitGraph.Click += new System.EventHandler(this.btnFitGraph_Click);
            // 
            // GraphContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GraphContainer";
            this.Size = new System.Drawing.Size(667, 427);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.generalToolStrip.ResumeLayout(false);
            this.generalToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private ToolStripEx generalToolStrip;
        private System.Windows.Forms.ToolStripButton dashButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripSplitButton btnPathThick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton btnValue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txb_X_Max;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txb_X_Min;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txb_Y_Max;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txb_Y_Min;
        private System.Windows.Forms.ToolStripButton btnValueToTable;
        private System.Windows.Forms.ToolStripSplitButton showDataSplitButton;
        private System.Windows.Forms.ToolStripButton btnFitGraph;
        private System.Windows.Forms.ToolStripButton btnTitle;
        private GraphControl graphControl;
    }
}
