using BazisGUI.Properties;
using System.Windows.Forms;
using UserControlsEx;
using UserControlsEx.Graph;

namespace BazisGUI.DataBases
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBasePage));
            tableLayoutPanel = new TableLayoutPanel();
            treePanel = new Panel();
            toolStripContainer2 = new ToolStripContainer();
            treeView = new TreeView();
            toolStrip2 = new ToolStripEx();
            btnOpenDB = new ToolStripButton();
            btnAddDB = new ToolStripButton();
            btnSafeFile = new ToolStripButton();
            addBranchButton = new ToolStripButton();
            delBrachButton = new ToolStripButton();
            btnCreateCopy = new ToolStripButton();
            graphPanel = new Panel();
            graphContainer = new GraphContainer();
            dataPanel = new Panel();
            toolStripContainer1 = new ToolStripContainer();
            dataGridView = new DataGridViewEx(components);
            dgrToolStrip = new ToolStripEx();
            btnAddNewRow = new ToolStripButton();
            btnDelRow = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            menuLev0 = new ContextMenuStrip(components);
            itmRename = new ToolStripMenuItem();
            itmDelete = new ToolStripMenuItem();
            tableLayoutPanel.SuspendLayout();
            treePanel.SuspendLayout();
            toolStripContainer2.ContentPanel.SuspendLayout();
            toolStripContainer2.TopToolStripPanel.SuspendLayout();
            toolStripContainer2.SuspendLayout();
            toolStrip2.SuspendLayout();
            graphPanel.SuspendLayout();
            dataPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            dgrToolStrip.SuspendLayout();
            menuLev0.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.12913F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.87087F));
            tableLayoutPanel.Controls.Add(treePanel, 0, 0);
            tableLayoutPanel.Controls.Add(graphPanel, 1, 1);
            tableLayoutPanel.Controls.Add(dataPanel, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 47.5496674F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4503326F));
            tableLayoutPanel.Size = new System.Drawing.Size(1332, 755);
            tableLayoutPanel.TabIndex = 2;
            // 
            // treePanel
            // 
            treePanel.BackColor = System.Drawing.Color.Silver;
            treePanel.BorderStyle = BorderStyle.FixedSingle;
            treePanel.Controls.Add(toolStripContainer2);
            treePanel.Dock = DockStyle.Fill;
            treePanel.Location = new System.Drawing.Point(0, 0);
            treePanel.Margin = new Padding(0, 0, 3, 0);
            treePanel.Name = "treePanel";
            treePanel.Padding = new Padding(0, 17, 0, 0);
            tableLayoutPanel.SetRowSpan(treePanel, 2);
            treePanel.Size = new System.Drawing.Size(385, 755);
            treePanel.TabIndex = 3;
            treePanel.Text = "Список";
            treePanel.Paint += treePanel_Paint;
            // 
            // toolStripContainer2
            // 
            toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            toolStripContainer2.ContentPanel.BackColor = System.Drawing.Color.Silver;
            toolStripContainer2.ContentPanel.Controls.Add(treeView);
            toolStripContainer2.ContentPanel.Margin = new Padding(0);
            toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(383, 702);
            toolStripContainer2.Dock = DockStyle.Fill;
            toolStripContainer2.LeftToolStripPanelVisible = false;
            toolStripContainer2.Location = new System.Drawing.Point(0, 17);
            toolStripContainer2.Margin = new Padding(4, 3, 4, 3);
            toolStripContainer2.Name = "toolStripContainer2";
            toolStripContainer2.RightToolStripPanelVisible = false;
            toolStripContainer2.Size = new System.Drawing.Size(383, 736);
            toolStripContainer2.TabIndex = 1;
            toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            toolStripContainer2.TopToolStripPanel.BackColor = System.Drawing.Color.Gainsboro;
            toolStripContainer2.TopToolStripPanel.Controls.Add(toolStrip2);
            // 
            // treeView
            // 
            treeView.BorderStyle = BorderStyle.None;
            treeView.Dock = DockStyle.Fill;
            treeView.LabelEdit = true;
            treeView.LineColor = System.Drawing.Color.Orange;
            treeView.Location = new System.Drawing.Point(0, 0);
            treeView.Margin = new Padding(0);
            treeView.Name = "treeView";
            treeView.Size = new System.Drawing.Size(383, 702);
            treeView.TabIndex = 0;
            treeView.BeforeLabelEdit += TreeView_BeforeLabelEdit;
            treeView.AfterLabelEdit += TreeView_AfterLabelEdit;
            treeView.AfterSelect += TreeView_AfterSelect;
            treeView.MouseDown += treeView_MouseDown;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.BackGroundColor = System.Drawing.Color.Gainsboro;
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.FrameColor = System.Drawing.Color.Gray;
            toolStrip2.GeneralFrame = false;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.IconLocation = new System.Drawing.Point(1, 5);
            toolStrip2.ImageRectangleSize = new System.Drawing.Point(16, 16);
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.ItemBackGroundColor = System.Drawing.Color.White;
            toolStrip2.ItemFrame = true;
            toolStrip2.ItemLocation = new System.Drawing.Point(3, 3);
            toolStrip2.ItemPressColor = System.Drawing.Color.Black;
            toolStrip2.Items.AddRange(new ToolStripItem[] { btnOpenDB, btnAddDB, btnSafeFile, addBranchButton, delBrachButton, btnCreateCopy });
            toolStrip2.ItemSelectColor = System.Drawing.Color.Gray;
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new Padding(1, 0, 0, 1);
            toolStrip2.Size = new System.Drawing.Size(383, 34);
            toolStrip2.SplitButtonClickWidth = 16;
            toolStrip2.SplitButtonHeight = 34;
            toolStrip2.SplitButtonTriangleSize = 6;
            toolStrip2.Stretch = true;
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = " ";
            toolStrip2.TextBoxFrame = false;
            toolStrip2.TextBoxHeight = 0;
            // 
            // btnOpenDB
            // 
            btnOpenDB.AutoSize = false;
            btnOpenDB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenDB.Image = Resources.OpenDB;
            btnOpenDB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnOpenDB.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnOpenDB.Name = "btnOpenDB";
            btnOpenDB.Size = new System.Drawing.Size(30, 30);
            btnOpenDB.Text = "Открыть файл";
            btnOpenDB.Click += OpenFileDB_Click;
            // 
            // btnAddDB
            // 
            btnAddDB.AutoSize = false;
            btnAddDB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddDB.Image = Resources.AddDB;
            btnAddDB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAddDB.ImageScaling = ToolStripItemImageScaling.None;
            btnAddDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddDB.Name = "btnAddDB";
            btnAddDB.Size = new System.Drawing.Size(30, 30);
            btnAddDB.Text = "Добавить материалы";
            btnAddDB.Click += AddDB_Click;
            // 
            // btnSafeFile
            // 
            btnSafeFile.AutoSize = false;
            btnSafeFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSafeFile.Image = (System.Drawing.Image)resources.GetObject("btnSafeFile.Image");
            btnSafeFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSafeFile.ImageScaling = ToolStripItemImageScaling.None;
            btnSafeFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSafeFile.Name = "btnSafeFile";
            btnSafeFile.Size = new System.Drawing.Size(30, 30);
            btnSafeFile.Text = "Сохранить файл";
            btnSafeFile.Click += SafeFileButton_Click;
            // 
            // addBranchButton
            // 
            addBranchButton.AutoSize = false;
            addBranchButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            addBranchButton.Image = (System.Drawing.Image)resources.GetObject("addBranchButton.Image");
            addBranchButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            addBranchButton.ImageScaling = ToolStripItemImageScaling.None;
            addBranchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            addBranchButton.Name = "addBranchButton";
            addBranchButton.Size = new System.Drawing.Size(30, 30);
            addBranchButton.Text = "Добавить раздел";
            addBranchButton.Click += AddBranchButton_Click;
            // 
            // delBrachButton
            // 
            delBrachButton.AutoSize = false;
            delBrachButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            delBrachButton.Image = (System.Drawing.Image)resources.GetObject("delBrachButton.Image");
            delBrachButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            delBrachButton.ImageScaling = ToolStripItemImageScaling.None;
            delBrachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            delBrachButton.Name = "delBrachButton";
            delBrachButton.Size = new System.Drawing.Size(30, 30);
            delBrachButton.Text = "Удалить раздел";
            delBrachButton.Click += DelBrachButton_Click;
            // 
            // btnCreateCopy
            // 
            btnCreateCopy.AutoSize = false;
            btnCreateCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCreateCopy.Image = Properties.Resources.Copy;
            btnCreateCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnCreateCopy.ImageScaling = ToolStripItemImageScaling.None;
            btnCreateCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnCreateCopy.Name = "btnCreateCopy";
            btnCreateCopy.Size = new System.Drawing.Size(30, 30);
            btnCreateCopy.Text = "Создать копию";
            btnCreateCopy.Click += CreateCopy_Click;
            // 
            // graphPanel
            // 
            graphPanel.BackColor = System.Drawing.Color.Silver;
            graphPanel.BorderStyle = BorderStyle.FixedSingle;
            graphPanel.Controls.Add(graphContainer);
            graphPanel.Dock = DockStyle.Fill;
            graphPanel.Location = new System.Drawing.Point(391, 362);
            graphPanel.Margin = new Padding(3, 3, 0, 0);
            graphPanel.Name = "graphPanel";
            graphPanel.Padding = new Padding(0, 17, 0, 0);
            graphPanel.Size = new System.Drawing.Size(941, 393);
            graphPanel.TabIndex = 4;
            graphPanel.Text = "График";
            graphPanel.Paint += graphPanel_Paint;
            // 
            // graphContainer
            // 
            graphContainer.Dock = DockStyle.Fill;
            graphContainer.Location = new System.Drawing.Point(0, 17);
            graphContainer.Margin = new Padding(0);
            graphContainer.Name = "graphContainer";
            graphContainer.Size = new System.Drawing.Size(939, 374);
            graphContainer.TabIndex = 0;
            // 
            // dataPanel
            // 
            dataPanel.BackColor = System.Drawing.Color.Silver;
            dataPanel.BorderStyle = BorderStyle.FixedSingle;
            dataPanel.Controls.Add(toolStripContainer1);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Location = new System.Drawing.Point(391, 0);
            dataPanel.Margin = new Padding(3, 0, 0, 3);
            dataPanel.Name = "dataPanel";
            dataPanel.Padding = new Padding(0, 17, 0, 0);
            dataPanel.Size = new System.Drawing.Size(941, 356);
            dataPanel.TabIndex = 5;
            dataPanel.Text = "Данные";
            dataPanel.Paint += dataPanel_Paint;
            // 
            // toolStripContainer1
            // 
            toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(dataGridView);
            toolStripContainer1.ContentPanel.Margin = new Padding(4, 3, 4, 3);
            toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(939, 303);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.LeftToolStripPanelVisible = false;
            toolStripContainer1.Location = new System.Drawing.Point(0, 17);
            toolStripContainer1.Margin = new Padding(4, 3, 4, 3);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new System.Drawing.Size(939, 337);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Gainsboro;
            toolStripContainer1.TopToolStripPanel.Controls.Add(dgrToolStrip);
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new System.Drawing.Point(0, 0);
            dataGridView.Margin = new Padding(0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 30;
            dataGridView.Size = new System.Drawing.Size(939, 303);
            dataGridView.TabIndex = 1;
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.CellEndEdit += DataGridView_CellEndEdit;
            dataGridView.UserDeletingRow += DataGridView_UserDeletingRow;
            // 
            // dgrToolStrip
            // 
            dgrToolStrip.BackColor = System.Drawing.Color.Transparent;
            dgrToolStrip.BackGroundColor = System.Drawing.Color.Gainsboro;
            dgrToolStrip.Dock = DockStyle.None;
            dgrToolStrip.FrameColor = System.Drawing.Color.Gray;
            dgrToolStrip.GeneralFrame = false;
            dgrToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            dgrToolStrip.IconLocation = new System.Drawing.Point(1, 5);
            dgrToolStrip.ImageRectangleSize = new System.Drawing.Point(16, 16);
            dgrToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            dgrToolStrip.ItemBackGroundColor = System.Drawing.Color.White;
            dgrToolStrip.ItemFrame = true;
            dgrToolStrip.ItemLocation = new System.Drawing.Point(3, 3);
            dgrToolStrip.ItemPressColor = System.Drawing.Color.Black;
            dgrToolStrip.Items.AddRange(new ToolStripItem[] { btnAddNewRow, btnDelRow, toolStripButton1 });
            dgrToolStrip.ItemSelectColor = System.Drawing.Color.Gray;
            dgrToolStrip.Location = new System.Drawing.Point(0, 0);
            dgrToolStrip.Name = "dgrToolStrip";
            dgrToolStrip.Padding = new Padding(1, 0, 0, 1);
            dgrToolStrip.Size = new System.Drawing.Size(939, 34);
            dgrToolStrip.SplitButtonClickWidth = 16;
            dgrToolStrip.SplitButtonHeight = 34;
            dgrToolStrip.SplitButtonTriangleSize = 6;
            dgrToolStrip.Stretch = true;
            dgrToolStrip.TabIndex = 0;
            dgrToolStrip.TextBoxFrame = false;
            dgrToolStrip.TextBoxHeight = 16;
            // 
            // btnAddNewRow
            // 
            btnAddNewRow.AutoSize = false;
            btnAddNewRow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddNewRow.Image = (System.Drawing.Image)resources.GetObject("btnAddNewRow.Image");
            btnAddNewRow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAddNewRow.ImageScaling = ToolStripItemImageScaling.None;
            btnAddNewRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddNewRow.Name = "btnAddNewRow";
            btnAddNewRow.Size = new System.Drawing.Size(30, 30);
            btnAddNewRow.Text = "Добавить ряд";
            btnAddNewRow.Click += AddNewRowButton_Click;
            // 
            // btnDelRow
            // 
            btnDelRow.AutoSize = false;
            btnDelRow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelRow.Image = (System.Drawing.Image)resources.GetObject("btnDelRow.Image");
            btnDelRow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnDelRow.ImageScaling = ToolStripItemImageScaling.None;
            btnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelRow.Name = "btnDelRow";
            btnDelRow.Size = new System.Drawing.Size(30, 30);
            btnDelRow.Text = "Удалить все ряды";
            btnDelRow.Click += DelAllRowsButton_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.AutoSize = false;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.ASC_sort;
            toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(30, 30);
            toolStripButton1.Text = "Сортировать";
            toolStripButton1.Click += Resort_Click;
            // 
            // menuLev0
            // 
            menuLev0.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuLev0.Items.AddRange(new ToolStripItem[] { itmRename, itmDelete });
            menuLev0.Name = "menuLev0";
            menuLev0.Size = new System.Drawing.Size(162, 48);
            // 
            // itmRename
            // 
            itmRename.Name = "itmRename";
            itmRename.Size = new System.Drawing.Size(161, 22);
            itmRename.Text = "Переименовать";
            // 
            // itmDelete
            // 
            itmDelete.Name = "itmDelete";
            itmDelete.Size = new System.Drawing.Size(161, 22);
            itmDelete.Text = "Удалить";
            // 
            // DataBasePage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "DataBasePage";
            Size = new System.Drawing.Size(1332, 755);
            tableLayoutPanel.ResumeLayout(false);
            treePanel.ResumeLayout(false);
            toolStripContainer2.ContentPanel.ResumeLayout(false);
            toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer2.TopToolStripPanel.PerformLayout();
            toolStripContainer2.ResumeLayout(false);
            toolStripContainer2.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            graphPanel.ResumeLayout(false);
            dataPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            dgrToolStrip.ResumeLayout(false);
            dgrToolStrip.PerformLayout();
            menuLev0.ResumeLayout(false);
            ResumeLayout(false);
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
        private ToolStripButton btnCreateCopy;
        private GraphContainer graphContainer;
    }
}
