namespace BaseControl
{
    partial class BasePage
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Название проекта :", 0, 0);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Путь :", 0, 0);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Сведения :", 0, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePage));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInputCmd = new System.Windows.Forms.ToolStripStatusLabel();
            this.webPageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbNavigator = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grbScene = new System.Windows.Forms.Panel();
            this.pctScreenSaver = new System.Windows.Forms.PictureBox();
            this.sceneControl = new Scene.SceneControl();
            this.grbConsole = new System.Windows.Forms.Panel();
            this.consoleControl = new Console.ConsoleControl();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grbScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctScreenSaver)).BeginInit();
            this.grbConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(937, 601);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(937, 648);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInputCmd,
            this.lblVersion,
            this.webPageLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(937, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblInputCmd
            // 
            this.lblInputCmd.BackColor = System.Drawing.SystemColors.Control;
            this.lblInputCmd.Name = "lblInputCmd";
            this.lblInputCmd.Size = new System.Drawing.Size(376, 17);
            this.lblInputCmd.Text = "Начните работу с загрузки проекта или импорта сеточной модели";
            // 
            // webPageLabel
            // 
            this.webPageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.webPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.webPageLabel.IsLink = true;
            this.webPageLabel.LinkColor = System.Drawing.Color.OrangeRed;
            this.webPageLabel.Name = "webPageLabel";
            this.webPageLabel.Size = new System.Drawing.Size(101, 17);
            this.webPageLabel.Text = "www.bazisnet.ru";
            this.webPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.webPageLabel.Click += new System.EventHandler(this.webPageLabel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbNavigator);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(927, 591);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // grbNavigator
            // 
            this.grbNavigator.BackColor = System.Drawing.Color.Silver;
            this.grbNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbNavigator.Controls.Add(this.treeView);
            this.grbNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNavigator.Location = new System.Drawing.Point(0, 0);
            this.grbNavigator.Name = "grbNavigator";
            this.grbNavigator.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbNavigator.Size = new System.Drawing.Size(319, 591);
            this.grbNavigator.TabIndex = 0;
            this.grbNavigator.Paint += new System.Windows.Forms.PaintEventHandler(this.grbNavigator_Paint);
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "названиеПроекта";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Название проекта :";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "путь";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "Путь :";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "сведения";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "Сведения :";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView.Size = new System.Drawing.Size(317, 574);
            this.treeView.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grbScene);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbConsole);
            this.splitContainer2.Size = new System.Drawing.Size(603, 591);
            this.splitContainer2.SplitterDistance = 452;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // grbScene
            // 
            this.grbScene.BackColor = System.Drawing.Color.Silver;
            this.grbScene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbScene.Controls.Add(this.pctScreenSaver);
            this.grbScene.Controls.Add(this.sceneControl);
            this.grbScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbScene.Location = new System.Drawing.Point(0, 0);
            this.grbScene.Name = "grbScene";
            this.grbScene.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbScene.Size = new System.Drawing.Size(603, 452);
            this.grbScene.TabIndex = 0;
            this.grbScene.Paint += new System.Windows.Forms.PaintEventHandler(this.grbScene_Paint);
            // 
            // pctScreenSaver
            // 
            this.pctScreenSaver.BackColor = System.Drawing.Color.White;
            this.pctScreenSaver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctScreenSaver.Image = ((System.Drawing.Image)(resources.GetObject("pctScreenSaver.Image")));
            this.pctScreenSaver.Location = new System.Drawing.Point(0, 15);
            this.pctScreenSaver.Name = "pctScreenSaver";
            this.pctScreenSaver.Size = new System.Drawing.Size(601, 435);
            this.pctScreenSaver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctScreenSaver.TabIndex = 3;
            this.pctScreenSaver.TabStop = false;
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.Color.White;
            this.sceneControl.DisplayRadioButtons = false;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsLighting = true;
            this.sceneControl.Location = new System.Drawing.Point(0, 15);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = Scene.ViewAxis.XYZ;
            this.sceneControl.SelectionColor = System.Drawing.Color.GreenYellow;
            this.sceneControl.SelectionType = "Узлы";
            this.sceneControl.Size = new System.Drawing.Size(601, 435);
            this.sceneControl.TabIndex = 2;
            this.sceneControl.TitleColor = System.Drawing.Color.Black;
            this.sceneControl.TitleText = "";
            this.sceneControl.InfoObjectsEvent += new System.Action<object, Scene.InfoObjectsEventArgs>(this.sceneControl_InfoObjectsEvent);
            this.sceneControl.CreateMeshGroupEvent += new System.Action<object, Scene.Events.CreateGroupEventArgs>(this.sceneControl_CreateMeshGroupEvent);
            this.sceneControl.DeleteSelectionEvent += new System.Action<object, System.EventArgs>(this.sceneControl_DeleteSelectionEvent);
            this.sceneControl.CreateVBObjectsEvent += new System.Action<object, Scene.Events.VBOPresenterEventArgs>(this.sceneControl_CreateVBObjectsEvent);
            this.sceneControl.MessageEvent += new System.Action<object, Scene.Events.MessageEventArgs>(this.sceneControl_MessageEvent);
            // 
            // grbConsole
            // 
            this.grbConsole.BackColor = System.Drawing.Color.Silver;
            this.grbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbConsole.Controls.Add(this.consoleControl);
            this.grbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConsole.Location = new System.Drawing.Point(0, 0);
            this.grbConsole.Name = "grbConsole";
            this.grbConsole.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbConsole.Size = new System.Drawing.Size(603, 134);
            this.grbConsole.TabIndex = 0;
            this.grbConsole.Paint += new System.Windows.Forms.PaintEventHandler(this.grbConsole_Paint);
            // 
            // consoleControl
            // 
            this.consoleControl.BackColor = System.Drawing.SystemColors.Control;
            this.consoleControl.CheckPrintElemsInfo = false;
            this.consoleControl.CheckPrintNodesInfo = false;
            this.consoleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl.Location = new System.Drawing.Point(0, 15);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(601, 117);
            this.consoleControl.TabIndex = 4;
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(414, 17);
            this.lblVersion.Spring = true;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "BasePage";
            this.Size = new System.Drawing.Size(937, 648);
            this.Load += new System.EventHandler(this.BasePage_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbNavigator.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grbScene.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctScreenSaver)).EndInit();
            this.grbConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInputCmd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripStatusLabel webPageLabel;
        private System.Windows.Forms.Panel grbConsole;
        private Console.ConsoleControl consoleControl;
        private System.Windows.Forms.Panel grbNavigator;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel grbScene;
        private System.Windows.Forms.PictureBox pctScreenSaver;
        private Scene.SceneControl sceneControl;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
    }
}
