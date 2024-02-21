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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Название проекта :", 0, 0);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Путь :", 0, 0);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Сведения :", 0, 0);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Вид :");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Объекты", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Группы объектов", 1, 1);
            this.objects_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groups_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeNodesImageList_16x16 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.ndGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.object_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ребраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поверхностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ребраИПоверхностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.grbNavigator = new System.Windows.Forms.Panel();
            this.objects_MenuStrip.SuspendLayout();
            this.groups_MenuStrip.SuspendLayout();
            this.ndGroup_MenuStrip.SuspendLayout();
            this.object_MenuStrip.SuspendLayout();
            this.elGroup_MenuStrip.SuspendLayout();
            this.grbNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // objects_MenuStrip
            // 
            this.objects_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.objects_MenuStrip.Name = "lv0_MenuStrip";
            this.objects_MenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Удалить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.DelAllObjects_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "Скрыть";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.HideAllObjects_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem3.Text = "Показать";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ShowAllObjects_Click);
            // 
            // groups_MenuStrip
            // 
            this.groups_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.groups_MenuStrip.Name = "lv0_MenuStrip";
            this.groups_MenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::BaseModule.Properties.Resources.Delete;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem10.Text = "Удалить";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.DelAllGroups_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem11.Text = "Скрыть";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.HideAllGroups_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem12.Text = "Показать";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.ShowAllGroups_Click);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeNodesImageList_16x16;
            this.treeView.Indent = 19;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "названиеПроекта";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Tag = "0";
            treeNode1.Text = "Название проекта :";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "путь";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Tag = "1";
            treeNode2.Text = "Путь :";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "сведения";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Tag = "2";
            treeNode3.Text = "Сведения :";
            treeNode4.Name = "вид";
            treeNode4.Tag = "3";
            treeNode4.Text = "Вид :";
            treeNode5.ContextMenuStrip = this.objects_MenuStrip;
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "объекты";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Tag = "4";
            treeNode5.Text = "Объекты";
            treeNode6.ContextMenuStrip = this.groups_MenuStrip;
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "группыОбъектов";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Tag = "5";
            treeNode6.Text = "Группы объектов";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(223, 325);
            this.treeView.TabIndex = 2;
            this.treeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_BeforeLabelEdit);
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // treeNodesImageList_16x16
            // 
            this.treeNodesImageList_16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodesImageList_16x16.ImageStream")));
            this.treeNodesImageList_16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodesImageList_16x16.Images.SetKeyName(0, "Инфо.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(1, "CloseFolder.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(2, "OpenFolder.png");
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
            this.ndGroup_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.ndGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.ndGroup_MenuStrip.Size = new System.Drawing.Size(162, 136);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem5.Text = "Скрыть";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem6.Text = "Показать";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::BaseModule.Properties.Resources.Edit;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem7.Text = "Изменить";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::BaseModule.Properties.Resources.Rename;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem8.Text = "Переименовать";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::BaseModule.Properties.Resources.Info;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem9.Text = "Инфо";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // object_MenuStrip
            // 
            this.object_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьОбъектMenuItem,
            this.показатьОбъектMenuItem,
            this.скрытьMenuItem,
            this.отображениеToolStripMenuItem});
            this.object_MenuStrip.Name = "lv0_MenuStrip";
            this.object_MenuStrip.Size = new System.Drawing.Size(151, 92);
            // 
            // удалитьОбъектMenuItem
            // 
            this.удалитьОбъектMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьОбъектMenuItem.Image")));
            this.удалитьОбъектMenuItem.Name = "удалитьОбъектMenuItem";
            this.удалитьОбъектMenuItem.Size = new System.Drawing.Size(150, 22);
            this.удалитьОбъектMenuItem.Text = "Удалить";
            this.удалитьОбъектMenuItem.Click += new System.EventHandler(this.DelObjects_Click);
            // 
            // показатьОбъектMenuItem
            // 
            this.показатьОбъектMenuItem.Image = global::BaseModule.Properties.Resources.Show;
            this.показатьОбъектMenuItem.Name = "показатьОбъектMenuItem";
            this.показатьОбъектMenuItem.Size = new System.Drawing.Size(150, 22);
            this.показатьОбъектMenuItem.Text = "Показать";
            this.показатьОбъектMenuItem.Click += new System.EventHandler(this.ShowObjects_Click);
            // 
            // скрытьMenuItem
            // 
            this.скрытьMenuItem.Image = global::BaseModule.Properties.Resources.Hide;
            this.скрытьMenuItem.Name = "скрытьMenuItem";
            this.скрытьMenuItem.Size = new System.Drawing.Size(150, 22);
            this.скрытьMenuItem.Text = "Скрыть";
            this.скрытьMenuItem.Click += new System.EventHandler(this.HideObjects_Click);
            // 
            // отображениеToolStripMenuItem
            // 
            this.отображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ребраToolStripMenuItem,
            this.поверхностиToolStripMenuItem,
            this.ребраИПоверхностиToolStripMenuItem});
            this.отображениеToolStripMenuItem.Name = "отображениеToolStripMenuItem";
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.отображениеToolStripMenuItem.Text = "Отображение";
            // 
            // ребраToolStripMenuItem
            // 
            this.ребраToolStripMenuItem.Name = "ребраToolStripMenuItem";
            this.ребраToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ребраToolStripMenuItem.Text = "Ребра";
            this.ребраToolStripMenuItem.Click += new System.EventHandler(this.ребраToolStripMenuItem_Click);
            // 
            // поверхностиToolStripMenuItem
            // 
            this.поверхностиToolStripMenuItem.Name = "поверхностиToolStripMenuItem";
            this.поверхностиToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.поверхностиToolStripMenuItem.Text = "Поверхности";
            this.поверхностиToolStripMenuItem.Click += new System.EventHandler(this.поверхностиToolStripMenuItem_Click);
            // 
            // ребраИПоверхностиToolStripMenuItem
            // 
            this.ребраИПоверхностиToolStripMenuItem.Name = "ребраИПоверхностиToolStripMenuItem";
            this.ребраИПоверхностиToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ребраИПоверхностиToolStripMenuItem.Text = "Ребра и поверхности";
            this.ребраИПоверхностиToolStripMenuItem.Click += new System.EventHandler(this.ребраИПоверхностиToolStripMenuItem_Click);
            // 
            // elGroup_MenuStrip
            // 
            this.elGroup_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22});
            this.elGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.elGroup_MenuStrip.Size = new System.Drawing.Size(177, 158);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem16.Image")));
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem16.Text = "Удалить";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem17.Text = "Скрыть";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem18.Text = "Показать";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Image = global::BaseModule.Properties.Resources.Edit;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem19.Text = "Изменить";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Image = global::BaseModule.Properties.Resources.Rename;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem20.Text = "Переименовать";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Image = global::BaseModule.Properties.Resources.Info;
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem21.Text = "Инфо";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Image = global::BaseModule.Properties.Resources.NodeFromElemGroup;
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem22.Text = "Показать с узлами";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.ShowGroupWithNodes_Click);
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
            this.grbNavigator.Size = new System.Drawing.Size(225, 342);
            this.grbNavigator.TabIndex = 5;
            this.grbNavigator.Paint += new System.Windows.Forms.PaintEventHandler(this.grbNavigator_Paint);
            this.grbNavigator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbNavigator_MouseClick);
            this.grbNavigator.Resize += new System.EventHandler(this.grbNavigator_Resize);
            // 
            // NavigatorControl
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.grbNavigator);
            this.Name = "NavigatorControl";
            this.Size = new System.Drawing.Size(225, 342);
            this.objects_MenuStrip.ResumeLayout(false);
            this.groups_MenuStrip.ResumeLayout(false);
            this.ndGroup_MenuStrip.ResumeLayout(false);
            this.object_MenuStrip.ResumeLayout(false);
            this.elGroup_MenuStrip.ResumeLayout(false);
            this.grbNavigator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ImageList contextMenuImageList;
        private System.Windows.Forms.ContextMenuStrip ndGroup_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ContextMenuStrip groups_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ContextMenuStrip objects_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip object_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ребраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поверхностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ребраИПоверхностиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip elGroup_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ImageList treeNodesImageList_16x16;
        private System.Windows.Forms.Panel grbNavigator;
    }
}
