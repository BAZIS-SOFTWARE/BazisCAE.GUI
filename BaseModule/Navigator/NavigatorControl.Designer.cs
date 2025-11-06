namespace BaseModule.Navigator
{
    partial class NavigatorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Проект", 14, 14);
            this.groups_MenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.geoMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.показатьОбъектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьОбъектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьОбъектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.скрытьРезToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьРезToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodesImageList_16x16 = new System.Windows.Forms.ImageList();
            this.contextMenuImageList = new System.Windows.Forms.ImageList();
            this.ndGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.set_MenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.удалитьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьСмежныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.elGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.objectMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.удалитьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.удалитьУсловиеMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.showMeshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.show1DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.show2DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.show3DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideMeshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hide1DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hide2DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hide3DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеHideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delMeshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del1DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del2DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del3DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groups_MenuStrip.SuspendLayout();
            this.geoMenuStrip.SuspendLayout();
            this.taskMenuStrip.SuspendLayout();
            this.resultsMenuStrip.SuspendLayout();
            this.ndGroup_MenuStrip.SuspendLayout();
            this.set_MenuStrip.SuspendLayout();
            this.elGroup_MenuStrip.SuspendLayout();
            this.objectMenuStrip.SuspendLayout();
            this.condMenuStrip.SuspendLayout();
            this.meshMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groups_MenuStrip
            // 
            this.groups_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.groups_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.groups_MenuStrip.Name = "lv0_MenuStrip";
            this.groups_MenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem10.Text = "Удалить";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.DelAllGroups_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem11.Text = "Скрыть";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.HideAllGroups_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem12.Text = "Показать";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.ShowAllGroups_Click);
            // 
            // geoMenuStrip
            // 
            this.geoMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.geoMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьОбъектыToolStripMenuItem,
            this.скрытьОбъектыToolStripMenuItem,
            this.удалитьОбъектыToolStripMenuItem});
            this.geoMenuStrip.Name = "taskMenuStrip";
            this.geoMenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // показатьОбъектыToolStripMenuItem
            // 
            this.показатьОбъектыToolStripMenuItem.Name = "показатьОбъектыToolStripMenuItem";
            this.показатьОбъектыToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.показатьОбъектыToolStripMenuItem.Text = "Показать";
            this.показатьОбъектыToolStripMenuItem.Click += new System.EventHandler(this.показатьГеометриюToolStripMenuItem_Click);
            // 
            // скрытьОбъектыToolStripMenuItem
            // 
            this.скрытьОбъектыToolStripMenuItem.Name = "скрытьОбъектыToolStripMenuItem";
            this.скрытьОбъектыToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.скрытьОбъектыToolStripMenuItem.Text = "Скрыть";
            this.скрытьОбъектыToolStripMenuItem.Click += new System.EventHandler(this.скрытьГеометриюToolStripMenuItem_Click);
            // 
            // удалитьОбъектыToolStripMenuItem
            // 
            this.удалитьОбъектыToolStripMenuItem.Name = "удалитьОбъектыToolStripMenuItem";
            this.удалитьОбъектыToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.удалитьОбъектыToolStripMenuItem.Text = "Удалить";
            this.удалитьОбъектыToolStripMenuItem.Click += new System.EventHandler(this.удалитьГеометриюToolStripMenuItem_Click);
            // 
            // taskMenuStrip
            // 
            this.taskMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.taskMenuStrip.Name = "taskMenuStrip";
            this.taskMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьВсеУсловияToolStripMenuItem_Click);
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьРезToolStripMenuItem,
            this.удалитьРезToolStripMenuItem});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(119, 48);
            // 
            // скрытьРезToolStripMenuItem
            // 
            this.скрытьРезToolStripMenuItem.Name = "скрытьРезToolStripMenuItem";
            this.скрытьРезToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.скрытьРезToolStripMenuItem.Text = "Скрыть";
            this.скрытьРезToolStripMenuItem.Click += new System.EventHandler(this.скрытьРезToolStripMenuItem_Click);
            // 
            // удалитьРезToolStripMenuItem
            // 
            this.удалитьРезToolStripMenuItem.Name = "удалитьРезToolStripMenuItem";
            this.удалитьРезToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьРезToolStripMenuItem.Text = "Удалить";
            this.удалитьРезToolStripMenuItem.Click += new System.EventHandler(this.удалитьРезToolStripMenuItem_Click);
            // 
            // treeNodesImageList_16x16
            // 
            this.treeNodesImageList_16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodesImageList_16x16.ImageStream")));
            this.treeNodesImageList_16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodesImageList_16x16.Images.SetKeyName(0, "Инфо.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(1, "CloseFolder.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(2, "OpenFolder.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(3, "NodeObjs.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(4, "MeshObjs.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(5, "switchOn_nodes_16x16.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(6, "switchOn_elems_16x16.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(7, "GeomObjs.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(8, "Материалы.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(9, "Среда.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(10, "Нагрев.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(11, "Закрепление.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(12, "Нагрузки.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(13, "CompInfo.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(14, "н 2.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(15, "н 3.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(16, "н1.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(17, "hide_w.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(18, "show_w.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(19, "delete.ico");
            // 
            // contextMenuImageList
            // 
            this.contextMenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("contextMenuImageList.ImageStream")));
            this.contextMenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.contextMenuImageList.Images.SetKeyName(0, "Del.ico");
            this.contextMenuImageList.Images.SetKeyName(1, "Hide.bmp");
            this.contextMenuImageList.Images.SetKeyName(2, "Show.bmp");
            this.contextMenuImageList.Images.SetKeyName(3, "Edit.png");
            this.contextMenuImageList.Images.SetKeyName(4, "Rename.png");
            this.contextMenuImageList.Images.SetKeyName(5, "Info.bmp");
            // 
            // ndGroup_MenuStrip
            // 
            this.ndGroup_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ndGroup_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem9});
            this.ndGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.ndGroup_MenuStrip.Size = new System.Drawing.Size(129, 114);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem5.Text = "Скрыть";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem6.Text = "Показать";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem7.Text = "Изменить";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem9.Text = "Инфо";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // set_MenuStrip
            // 
            this.set_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.set_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьНаборMenuItem,
            this.скрытьНаборMenuItem,
            this.показатьНаборMenuItem,
            this.показатьСмежныеToolStripMenuItem1});
            this.set_MenuStrip.Name = "lv0_MenuStrip";
            this.set_MenuStrip.Size = new System.Drawing.Size(180, 92);
            // 
            // удалитьНаборMenuItem
            // 
            this.удалитьНаборMenuItem.Name = "удалитьНаборMenuItem";
            this.удалитьНаборMenuItem.Size = new System.Drawing.Size(179, 22);
            this.удалитьНаборMenuItem.Text = "Удалить";
            this.удалитьНаборMenuItem.Click += new System.EventHandler(this.DelSet_Click);
            // 
            // скрытьНаборMenuItem
            // 
            this.скрытьНаборMenuItem.Name = "скрытьНаборMenuItem";
            this.скрытьНаборMenuItem.Size = new System.Drawing.Size(179, 22);
            this.скрытьНаборMenuItem.Text = "Скрыть";
            this.скрытьНаборMenuItem.Click += new System.EventHandler(this.HideSet_Click);
            // 
            // показатьНаборMenuItem
            // 
            this.показатьНаборMenuItem.Name = "показатьНаборMenuItem";
            this.показатьНаборMenuItem.Size = new System.Drawing.Size(179, 22);
            this.показатьНаборMenuItem.Text = "Показать";
            this.показатьНаборMenuItem.Click += new System.EventHandler(this.ShowSet_Click);
            // 
            // показатьСмежныеToolStripMenuItem1
            // 
            this.показатьСмежныеToolStripMenuItem1.Name = "показатьСмежныеToolStripMenuItem1";
            this.показатьСмежныеToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.показатьСмежныеToolStripMenuItem1.Text = "Показать смежные";
            this.показатьСмежныеToolStripMenuItem1.Click += new System.EventHandler(this.показатьСмежныеНаборыToolStripMenuItem_Click);
            // 
            // elGroup_MenuStrip
            // 
            this.elGroup_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.elGroup_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22});
            this.elGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.elGroup_MenuStrip.Size = new System.Drawing.Size(177, 136);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem16.Text = "Удалить";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem17.Text = "Скрыть";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem18.Text = "Показать";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem19.Text = "Изменить";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem21.Text = "Инфо";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem22.Text = "Показать с узлами";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.ShowGroupWithNodes_Click);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.FullRowSelect = true;
            this.treeView.ImageIndex = 16;
            this.treeView.ImageList = this.treeNodesImageList_16x16;
            this.treeView.Indent = 19;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 14;
            treeNode1.Name = "проект";
            treeNode1.SelectedImageIndex = 14;
            treeNode1.Text = "Проект";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.SelectedImageIndex = 16;
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(256, 539);
            this.treeView.TabIndex = 5;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.Enter += new System.EventHandler(this.treeView_Enter);
            this.treeView.Leave += new System.EventHandler(this.treeView_Leave);
            // 
            // objectMenuStrip
            // 
            this.objectMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.objectMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьОбъектMenuItem,
            this.скрытьОбъектMenuItem,
            this.показатьОбъектMenuItem});
            this.objectMenuStrip.Name = "lv0_MenuStrip";
            this.objectMenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // удалитьОбъектMenuItem
            // 
            this.удалитьОбъектMenuItem.Name = "удалитьОбъектMenuItem";
            this.удалитьОбъектMenuItem.Size = new System.Drawing.Size(124, 22);
            this.удалитьОбъектMenuItem.Text = "Удалить";
            this.удалитьОбъектMenuItem.Click += new System.EventHandler(this.удалитьОбъектMenuItem_Click);
            // 
            // скрытьОбъектMenuItem
            // 
            this.скрытьОбъектMenuItem.Name = "скрытьОбъектMenuItem";
            this.скрытьОбъектMenuItem.Size = new System.Drawing.Size(124, 22);
            this.скрытьОбъектMenuItem.Text = "Скрыть";
            this.скрытьОбъектMenuItem.Click += new System.EventHandler(this.скрытьОбъектMenuItem_Click);
            // 
            // показатьОбъектMenuItem
            // 
            this.показатьОбъектMenuItem.Name = "показатьОбъектMenuItem";
            this.показатьОбъектMenuItem.Size = new System.Drawing.Size(124, 22);
            this.показатьОбъектMenuItem.Text = "Показать";
            this.показатьОбъектMenuItem.Click += new System.EventHandler(this.показатьОбъектMenuItem_Click);
            // 
            // condMenuStrip
            // 
            this.condMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.condMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьУсловиеMenuItem});
            this.condMenuStrip.Name = "lv0_MenuStrip";
            this.condMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // удалитьУсловиеMenuItem
            // 
            this.удалитьУсловиеMenuItem.Name = "удалитьУсловиеMenuItem";
            this.удалитьУсловиеMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьУсловиеMenuItem.Text = "Удалить";
            this.удалитьУсловиеMenuItem.Click += new System.EventHandler(this.удалитьУсловиеMenuItem_Click);
            // 
            // meshMenuStrip
            // 
            this.meshMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.meshMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMeshMenuItem,
            this.hideMeshMenuItem,
            this.delMeshMenuItem});
            this.meshMenuStrip.Name = "taskMenuStrip";
            this.meshMenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // showMeshMenuItem
            // 
            this.showMeshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show1DMenuItem,
            this.show2DMenuItem,
            this.show3DMenuItem,
            this.всеShowMenuItem});
            this.showMeshMenuItem.Name = "showMeshMenuItem";
            this.showMeshMenuItem.Size = new System.Drawing.Size(124, 22);
            this.showMeshMenuItem.Text = "Показать";
            // 
            // show1DMenuItem
            // 
            this.show1DMenuItem.Name = "show1DMenuItem";
            this.show1DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.show1DMenuItem.Text = "1D";
            this.show1DMenuItem.Click += new System.EventHandler(this.show1DMenuItem_Click);
            // 
            // show2DMenuItem
            // 
            this.show2DMenuItem.Name = "show2DMenuItem";
            this.show2DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.show2DMenuItem.Text = "2D";
            this.show2DMenuItem.Click += new System.EventHandler(this.show2DMenuItem_Click);
            // 
            // show3DMenuItem
            // 
            this.show3DMenuItem.Name = "show3DMenuItem";
            this.show3DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.show3DMenuItem.Text = "3D";
            this.show3DMenuItem.Click += new System.EventHandler(this.show3DMenuItem_Click);
            // 
            // всеShowMenuItem
            // 
            this.всеShowMenuItem.Name = "всеShowMenuItem";
            this.всеShowMenuItem.Size = new System.Drawing.Size(102, 22);
            this.всеShowMenuItem.Text = "Узлы";
            this.всеShowMenuItem.Click += new System.EventHandler(this.nodeShowMenuItem_Click);
            // 
            // hideMeshMenuItem
            // 
            this.hideMeshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hide1DMenuItem,
            this.hide2DMenuItem,
            this.hide3DMenuItem,
            this.всеHideMenuItem});
            this.hideMeshMenuItem.Name = "hideMeshMenuItem";
            this.hideMeshMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hideMeshMenuItem.Text = "Скрыть";
            // 
            // hide1DMenuItem
            // 
            this.hide1DMenuItem.Name = "hide1DMenuItem";
            this.hide1DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.hide1DMenuItem.Text = "1D";
            this.hide1DMenuItem.Click += new System.EventHandler(this.hide1DMenuItem_Click);
            // 
            // hide2DMenuItem
            // 
            this.hide2DMenuItem.Name = "hide2DMenuItem";
            this.hide2DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.hide2DMenuItem.Text = "2D";
            this.hide2DMenuItem.Click += new System.EventHandler(this.hide2DMenuItem_Click);
            // 
            // hide3DMenuItem
            // 
            this.hide3DMenuItem.Name = "hide3DMenuItem";
            this.hide3DMenuItem.Size = new System.Drawing.Size(102, 22);
            this.hide3DMenuItem.Text = "3D";
            this.hide3DMenuItem.Click += new System.EventHandler(this.hide3DMenuItem_Click);
            // 
            // всеHideMenuItem
            // 
            this.всеHideMenuItem.Name = "всеHideMenuItem";
            this.всеHideMenuItem.Size = new System.Drawing.Size(102, 22);
            this.всеHideMenuItem.Text = "Узлы";
            this.всеHideMenuItem.Click += new System.EventHandler(this.nodeHideMenuItem_Click);
            // 
            // delMeshMenuItem
            // 
            this.delMeshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.del1DMenuItem,
            this.del2DMenuItem,
            this.del3DMenuItem});
            this.delMeshMenuItem.Name = "delMeshMenuItem";
            this.delMeshMenuItem.Size = new System.Drawing.Size(124, 22);
            this.delMeshMenuItem.Text = "Удалить";
            // 
            // del1DMenuItem
            // 
            this.del1DMenuItem.Name = "del1DMenuItem";
            this.del1DMenuItem.Size = new System.Drawing.Size(88, 22);
            this.del1DMenuItem.Text = "1D";
            this.del1DMenuItem.Click += new System.EventHandler(this.del1DMenuItem_Click);
            // 
            // del2DMenuItem
            // 
            this.del2DMenuItem.Name = "del2DMenuItem";
            this.del2DMenuItem.Size = new System.Drawing.Size(88, 22);
            this.del2DMenuItem.Text = "2D";
            this.del2DMenuItem.Click += new System.EventHandler(this.del2DMenuItem_Click);
            // 
            // del3DMenuItem
            // 
            this.del3DMenuItem.Name = "del3DMenuItem";
            this.del3DMenuItem.Size = new System.Drawing.Size(88, 22);
            this.del3DMenuItem.Text = "3D";
            this.del3DMenuItem.Click += new System.EventHandler(this.del3DMenuItem_Click);
            // 
            // NavigatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.treeView);
            this.HeaderName = "Навигатор";
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Name = "NavigatorControl";
            this.Size = new System.Drawing.Size(256, 554);
            this.groups_MenuStrip.ResumeLayout(false);
            this.geoMenuStrip.ResumeLayout(false);
            this.taskMenuStrip.ResumeLayout(false);
            this.resultsMenuStrip.ResumeLayout(false);
            this.ndGroup_MenuStrip.ResumeLayout(false);
            this.set_MenuStrip.ResumeLayout(false);
            this.elGroup_MenuStrip.ResumeLayout(false);
            this.objectMenuStrip.ResumeLayout(false);
            this.condMenuStrip.ResumeLayout(false);
            this.meshMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList contextMenuImageList;
        private System.Windows.Forms.ContextMenuStrip ndGroup_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ContextMenuStrip groups_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ContextMenuStrip set_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьНаборMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьНаборMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьНаборMenuItem;
        private System.Windows.Forms.ContextMenuStrip elGroup_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ImageList treeNodesImageList_16x16;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьРезToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьРезToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip taskMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip objectMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОбъектMenuItem;
        private System.Windows.Forms.ContextMenuStrip geoMenuStrip;
        private System.Windows.Forms.ContextMenuStrip condMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьУсловиеMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОбъектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьОбъектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьСмежныеToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip meshMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showMeshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem show1DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem show2DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem show3DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMeshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hide1DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hide2DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hide3DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delMeshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem del1DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem del2DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem del3DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеHideMenuItem;
    }
}
