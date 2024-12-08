using System.Windows.Forms;
using UserControlsEx;
using UserControlsEx.Graph;

namespace PropertiesDataBases.DataBases
{
    partial class DataBasePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBasePage));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.treePanel = new System.Windows.Forms.Panel();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new UserControlsEx.ToolStripEx();
            this.btnOpenDB = new System.Windows.Forms.ToolStripButton();
            this.btnAddDB = new System.Windows.Forms.ToolStripButton();
            this.btnSafeFile = new System.Windows.Forms.ToolStripButton();
            this.addBranchButton = new System.Windows.Forms.ToolStripButton();
            this.delBrachButton = new System.Windows.Forms.ToolStripButton();
            this.btnCreateCopy = new System.Windows.Forms.ToolStripButton();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.graphContainer = new GraphContainer();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dataGridView = new UserControlsEx.DataGridViewEx(this.components);
            this.dgrToolStrip = new UserControlsEx.ToolStripEx();
            this.btnAddNewRow = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblPath = new System.Windows.Forms.Label();
            this.menuLev0 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.treePanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.dgrToolStrip.SuspendLayout();
            this.menuLev0.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.treePanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.graphPanel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.dataPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblPath, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1142, 654);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // treePanel
            // 
            this.treePanel.BackColor = System.Drawing.Color.Silver;
            this.treePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treePanel.Controls.Add(this.toolStripContainer2);
            this.treePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePanel.Location = new System.Drawing.Point(5, 5);
            this.treePanel.Margin = new System.Windows.Forms.Padding(5);
            this.treePanel.Name = "treePanel";
            this.treePanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tableLayoutPanel.SetRowSpan(this.treePanel, 2);
            this.treePanel.Size = new System.Drawing.Size(210, 620);
            this.treePanel.TabIndex = 3;
            this.treePanel.Text = "Список";
            this.treePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.treePanel_Paint);
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.BackColor = System.Drawing.Color.Silver;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.treeView);
            this.toolStripContainer2.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(208, 569);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 15);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(208, 603);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.LabelEdit = true;
            this.treeView.LineColor = System.Drawing.Color.Orange;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(208, 569);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_BeforeLabelEdit);
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_AfterLabelEdit);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.FrameColor = System.Drawing.Color.Gray;
            this.toolStrip2.GeneralFrame = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.IconLocation = new System.Drawing.Point(1, 5);
            this.toolStrip2.ImageRectangleSize = new System.Drawing.Point(16, 16);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.ItemBackGroundColor = System.Drawing.Color.White;
            this.toolStrip2.ItemFrame = true;
            this.toolStrip2.ItemLocation = new System.Drawing.Point(3, 3);
            this.toolStrip2.ItemPressColor = System.Drawing.Color.Black;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenDB,
            this.btnAddDB,
            this.btnSafeFile,
            this.addBranchButton,
            this.delBrachButton,
            this.btnCreateCopy});
            this.toolStrip2.ItemSelectColor = System.Drawing.Color.Gray;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.toolStrip2.Size = new System.Drawing.Size(208, 34);
            this.toolStrip2.SplitButtonClickWidth = 16;
            this.toolStrip2.SplitButtonHeight = 34;
            this.toolStrip2.SplitButtonTriangleSize = 6;
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = " ";
            this.toolStrip2.TextBoxFrame = false;
            this.toolStrip2.TextBoxHeight = 0;
            // 
            // btnOpenDB
            // 
            this.btnOpenDB.AutoSize = false;
            this.btnOpenDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenDB.Image = global::PropertiesDataBases.Properties.Resources.OpenDB;
            this.btnOpenDB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDB.Name = "btnOpenDB";
            this.btnOpenDB.Size = new System.Drawing.Size(30, 30);
            this.btnOpenDB.Text = "Открыть файл";
            this.btnOpenDB.Click += new System.EventHandler(this.OpenFileDB_Click);
            // 
            // btnAddDB
            // 
            this.btnAddDB.AutoSize = false;
            this.btnAddDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDB.Image = global::PropertiesDataBases.Properties.Resources.AddDB;
            this.btnAddDB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(30, 30);
            this.btnAddDB.Text = "Добавить материалы";
            this.btnAddDB.Click += new System.EventHandler(this.AddDB_Click);
            // 
            // btnSafeFile
            // 
            this.btnSafeFile.AutoSize = false;
            this.btnSafeFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSafeFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSafeFile.Image")));
            this.btnSafeFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSafeFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSafeFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSafeFile.Name = "btnSafeFile";
            this.btnSafeFile.Size = new System.Drawing.Size(30, 30);
            this.btnSafeFile.Text = "Сохранить файл";
            this.btnSafeFile.Click += new System.EventHandler(this.SafeFileButton_Click);
            // 
            // addBranchButton
            // 
            this.addBranchButton.AutoSize = false;
            this.addBranchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBranchButton.Image = ((System.Drawing.Image)(resources.GetObject("addBranchButton.Image")));
            this.addBranchButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addBranchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addBranchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBranchButton.Name = "addBranchButton";
            this.addBranchButton.Size = new System.Drawing.Size(30, 30);
            this.addBranchButton.Text = "Добавить раздел";
            this.addBranchButton.Click += new System.EventHandler(this.AddBranchButton_Click);
            // 
            // delBrachButton
            // 
            this.delBrachButton.AutoSize = false;
            this.delBrachButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delBrachButton.Image = ((System.Drawing.Image)(resources.GetObject("delBrachButton.Image")));
            this.delBrachButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.delBrachButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.delBrachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delBrachButton.Name = "delBrachButton";
            this.delBrachButton.Size = new System.Drawing.Size(30, 30);
            this.delBrachButton.Text = "Удалить раздел";
            this.delBrachButton.Click += new System.EventHandler(this.DelBrachButton_Click);
            // 
            // btnCreateCopy
            // 
            this.btnCreateCopy.AutoSize = false;
            this.btnCreateCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateCopy.Image = global::PropertiesDataBases.Properties.Resources.Copy;
            this.btnCreateCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCreateCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateCopy.Name = "btnCreateCopy";
            this.btnCreateCopy.Size = new System.Drawing.Size(30, 30);
            this.btnCreateCopy.Text = "Создать копию";
            this.btnCreateCopy.Click += new System.EventHandler(this.CreateCopy_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.Silver;
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel.Controls.Add(this.graphContainer);
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(225, 320);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(5);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.graphPanel.Size = new System.Drawing.Size(912, 305);
            this.graphPanel.TabIndex = 4;
            this.graphPanel.Text = "График";
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            // 
            // graphContainer
            // 
            this.graphContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphContainer.Location = new System.Drawing.Point(0, 15);
            this.graphContainer.Margin = new System.Windows.Forms.Padding(0);
            this.graphContainer.Name = "graphContainer";
            this.graphContainer.Size = new System.Drawing.Size(910, 288);
            this.graphContainer.TabIndex = 0;
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.Silver;
            this.dataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataPanel.Controls.Add(this.toolStripContainer1);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(225, 5);
            this.dataPanel.Margin = new System.Windows.Forms.Padding(5);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.dataPanel.Size = new System.Drawing.Size(912, 305);
            this.dataPanel.TabIndex = 5;
            this.dataPanel.Text = "Данные";
            this.dataPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.dataPanel_Paint);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(910, 254);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 15);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(910, 288);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.dgrToolStrip);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.Size = new System.Drawing.Size(910, 254);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // dgrToolStrip
            // 
            this.dgrToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.dgrToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            this.dgrToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.dgrToolStrip.FrameColor = System.Drawing.Color.Gray;
            this.dgrToolStrip.GeneralFrame = false;
            this.dgrToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.dgrToolStrip.IconLocation = new System.Drawing.Point(1, 5);
            this.dgrToolStrip.ImageRectangleSize = new System.Drawing.Point(16, 16);
            this.dgrToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dgrToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            this.dgrToolStrip.ItemFrame = true;
            this.dgrToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            this.dgrToolStrip.ItemPressColor = System.Drawing.Color.Black;
            this.dgrToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewRow,
            this.btnDelRow,
            this.toolStripButton1});
            this.dgrToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            this.dgrToolStrip.Location = new System.Drawing.Point(0, 0);
            this.dgrToolStrip.Name = "dgrToolStrip";
            this.dgrToolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.dgrToolStrip.Size = new System.Drawing.Size(910, 34);
            this.dgrToolStrip.SplitButtonClickWidth = 16;
            this.dgrToolStrip.SplitButtonHeight = 34;
            this.dgrToolStrip.SplitButtonTriangleSize = 6;
            this.dgrToolStrip.Stretch = true;
            this.dgrToolStrip.TabIndex = 0;
            this.dgrToolStrip.TextBoxFrame = false;
            this.dgrToolStrip.TextBoxHeight = 16;
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = false;
            this.btnAddNewRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.Image")));
            this.btnAddNewRow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddNewRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddNewRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(30, 30);
            this.btnAddNewRow.Text = "Добавить ряд";
            this.btnAddNewRow.Click += new System.EventHandler(this.AddNewRowButton_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.AutoSize = false;
            this.btnDelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Image")));
            this.btnDelRow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelRow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(30, 30);
            this.btnDelRow.Text = "Удалить все ряды";
            this.btnDelRow.Click += new System.EventHandler(this.DelAllRowsButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PropertiesDataBases.Properties.Resources.ASC_sort;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton1.Text = "Сортировать";
            this.toolStripButton1.Click += new System.EventHandler(this.Resort_Click);
            // 
            // lblPath
            // 
            this.lblPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPath.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblPath, 2);
            this.lblPath.Location = new System.Drawing.Point(3, 635);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 13);
            this.lblPath.TabIndex = 6;
            // 
            // menuLev0
            // 
            this.menuLev0.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuLev0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmRename,
            this.itmDelete});
            this.menuLev0.Name = "menuLev0";
            this.menuLev0.Size = new System.Drawing.Size(162, 48);
            // 
            // itmRename
            // 
            this.itmRename.Name = "itmRename";
            this.itmRename.Size = new System.Drawing.Size(161, 22);
            this.itmRename.Text = "Переименовать";
            // 
            // itmDelete
            // 
            this.itmDelete.Name = "itmDelete";
            this.itmDelete.Size = new System.Drawing.Size(161, 22);
            this.itmDelete.Text = "Удалить";
            // 
            // DataBasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DataBasePage";
            this.Size = new System.Drawing.Size(1142, 654);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.treePanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.graphPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.dgrToolStrip.ResumeLayout(false);
            this.dgrToolStrip.PerformLayout();
            this.menuLev0.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TreeView treeView;
        private DataGridViewEx dataGridView;
        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private ToolStripEx toolStrip2;
        private System.Windows.Forms.ToolStripButton btnOpenDB;
        private System.Windows.Forms.ToolStripButton btnSafeFile;
        private System.Windows.Forms.ToolStripButton addBranchButton;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ToolStripEx dgrToolStrip;
        private System.Windows.Forms.ToolStripButton btnAddNewRow;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.ToolStripButton delBrachButton;

        private ContextMenuStrip menuLev0;
        private ToolStripMenuItem itmRename;
        private ToolStripMenuItem itmDelete;
        private ToolStripButton toolStripButton1;
        private ToolStripButton btnAddDB;
        private Label lblPath;
        private ToolStripButton btnCreateCopy;
        private GraphContainer graphContainer;
    }
}
