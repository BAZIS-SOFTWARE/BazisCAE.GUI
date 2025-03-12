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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Название проекта :", 16, 16);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Путь :", 16, 16);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Сведения :", 16, 16);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Вид :");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Узлы", 14, 14);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Точки", 14, 14);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Кривые", 14, 14);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Поверхности", 14, 14);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Объемы", 14, 14);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Элементы1D", 14, 14);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Элементы2D", 14, 14);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Элементы3D", 14, 14);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Объекты", 14, 14, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Группы объектов", 14, 14);
            this.objects_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groups_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.treeView = new System.Windows.Forms.TreeView();
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
            this.objects_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.objects_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.objects_MenuStrip.Name = "lv0_MenuStrip";
            this.objects_MenuStrip.Size = new System.Drawing.Size(147, 82);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem1.Text = "Удалить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.DelAllObjects_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem2.Text = "Скрыть";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.HideAllObjects_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem3.Text = "Показать";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ShowAllObjects_Click);
            // 
            // groups_MenuStrip
            // 
            this.groups_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.groups_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.groups_MenuStrip.Name = "lv0_MenuStrip";
            this.groups_MenuStrip.Size = new System.Drawing.Size(147, 82);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::BaseModule.Properties.Resources.Delete;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem10.Text = "Удалить";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.DelAllGroups_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem11.Text = "Скрыть";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.HideAllGroups_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem12.Text = "Показать";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.ShowAllGroups_Click);
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
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.ndGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.ndGroup_MenuStrip.Size = new System.Drawing.Size(195, 160);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem5.Text = "Скрыть";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem6.Text = "Показать";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::BaseModule.Properties.Resources.Edit;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem7.Text = "Изменить";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::BaseModule.Properties.Resources.Rename;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem8.Text = "Переименовать";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::BaseModule.Properties.Resources.Info;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuItem9.Text = "Инфо";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // object_MenuStrip
            // 
            this.object_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.object_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьОбъектMenuItem,
            this.показатьОбъектMenuItem,
            this.скрытьMenuItem,
            this.отображениеToolStripMenuItem});
            this.object_MenuStrip.Name = "lv0_MenuStrip";
            this.object_MenuStrip.Size = new System.Drawing.Size(180, 108);
            // 
            // удалитьОбъектMenuItem
            // 
            this.удалитьОбъектMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьОбъектMenuItem.Image")));
            this.удалитьОбъектMenuItem.Name = "удалитьОбъектMenuItem";
            this.удалитьОбъектMenuItem.Size = new System.Drawing.Size(179, 26);
            this.удалитьОбъектMenuItem.Text = "Удалить";
            this.удалитьОбъектMenuItem.Click += new System.EventHandler(this.DelObjects_Click);
            // 
            // показатьОбъектMenuItem
            // 
            this.показатьОбъектMenuItem.Image = global::BaseModule.Properties.Resources.Show;
            this.показатьОбъектMenuItem.Name = "показатьОбъектMenuItem";
            this.показатьОбъектMenuItem.Size = new System.Drawing.Size(179, 26);
            this.показатьОбъектMenuItem.Text = "Показать";
            this.показатьОбъектMenuItem.Click += new System.EventHandler(this.ShowObjects_Click);
            // 
            // скрытьMenuItem
            // 
            this.скрытьMenuItem.Image = global::BaseModule.Properties.Resources.Hide;
            this.скрытьMenuItem.Name = "скрытьMenuItem";
            this.скрытьMenuItem.Size = new System.Drawing.Size(179, 26);
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
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.отображениеToolStripMenuItem.Text = "Отображение";
            // 
            // ребраToolStripMenuItem
            // 
            this.ребраToolStripMenuItem.Name = "ребраToolStripMenuItem";
            this.ребраToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.ребраToolStripMenuItem.Text = "Ребра";
            this.ребраToolStripMenuItem.Click += new System.EventHandler(this.ребраToolStripMenuItem_Click);
            // 
            // поверхностиToolStripMenuItem
            // 
            this.поверхностиToolStripMenuItem.Name = "поверхностиToolStripMenuItem";
            this.поверхностиToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.поверхностиToolStripMenuItem.Text = "Поверхности";
            this.поверхностиToolStripMenuItem.Click += new System.EventHandler(this.поверхностиToolStripMenuItem_Click);
            // 
            // ребраИПоверхностиToolStripMenuItem
            // 
            this.ребраИПоверхностиToolStripMenuItem.Name = "ребраИПоверхностиToolStripMenuItem";
            this.ребраИПоверхностиToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.ребраИПоверхностиToolStripMenuItem.Text = "Ребра и поверхности";
            this.ребраИПоверхностиToolStripMenuItem.Click += new System.EventHandler(this.ребраИПоверхностиToolStripMenuItem_Click);
            // 
            // elGroup_MenuStrip
            // 
            this.elGroup_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.elGroup_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22});
            this.elGroup_MenuStrip.Name = "lv11_MenuStrip";
            this.elGroup_MenuStrip.Size = new System.Drawing.Size(212, 186);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem16.Image")));
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem16.Text = "Удалить";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Image = global::BaseModule.Properties.Resources.Hide;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem17.Text = "Скрыть";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Image = global::BaseModule.Properties.Resources.Show;
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem18.Text = "Показать";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Image = global::BaseModule.Properties.Resources.Edit;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem19.Text = "Изменить";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Image = global::BaseModule.Properties.Resources.Rename;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem20.Text = "Переименовать";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Image = global::BaseModule.Properties.Resources.Info;
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem21.Text = "Инфо";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Image = global::BaseModule.Properties.Resources.NodeFromElemGroup;
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(211, 26);
            this.toolStripMenuItem22.Text = "Показать с узлами";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.ShowGroupWithNodes_Click);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.FullRowSelect = true;
            this.treeView.ImageIndex = 16;
            this.treeView.ImageList = this.treeNodesImageList_16x16;
            this.treeView.Indent = 19;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 16;
            treeNode1.Name = "названиеПроекта";
            treeNode1.SelectedImageIndex = 16;
            treeNode1.Tag = "0";
            treeNode1.Text = "Название проекта :";
            treeNode2.ImageIndex = 16;
            treeNode2.Name = "путь";
            treeNode2.SelectedImageIndex = 16;
            treeNode2.Tag = "1";
            treeNode2.Text = "Путь :";
            treeNode3.ImageIndex = 16;
            treeNode3.Name = "сведения";
            treeNode3.SelectedImageIndex = 16;
            treeNode3.Tag = "2";
            treeNode3.Text = "Сведения :";
            treeNode4.Name = "вид";
            treeNode4.Tag = "3";
            treeNode4.Text = "Вид :";
            treeNode5.ImageIndex = 14;
            treeNode5.Name = "узлы";
            treeNode5.SelectedImageIndex = 14;
            treeNode5.Tag = "4.1";
            treeNode5.Text = "Узлы";
            treeNode6.ImageIndex = 14;
            treeNode6.Name = "точки";
            treeNode6.SelectedImageIndex = 14;
            treeNode6.Tag = "4.1";
            treeNode6.Text = "Точки";
            treeNode7.ImageIndex = 14;
            treeNode7.Name = "кривые";
            treeNode7.SelectedImageIndex = 14;
            treeNode7.Tag = "4.1";
            treeNode7.Text = "Кривые";
            treeNode8.ImageIndex = 14;
            treeNode8.Name = "поверхности";
            treeNode8.SelectedImageIndex = 14;
            treeNode8.Tag = "4.1";
            treeNode8.Text = "Поверхности";
            treeNode9.ImageIndex = 14;
            treeNode9.Name = "объемы";
            treeNode9.SelectedImageIndex = 14;
            treeNode9.Tag = "4.1";
            treeNode9.Text = "Объемы";
            treeNode10.ImageIndex = 14;
            treeNode10.Name = "элементы1D";
            treeNode10.SelectedImageIndex = 14;
            treeNode10.Tag = "4.1";
            treeNode10.Text = "Элементы1D";
            treeNode11.ImageIndex = 14;
            treeNode11.Name = "элементы2D";
            treeNode11.SelectedImageIndex = 14;
            treeNode11.Tag = "4.1";
            treeNode11.Text = "Элементы2D";
            treeNode12.ImageIndex = 14;
            treeNode12.Name = "элементы3D";
            treeNode12.SelectedImageIndex = 14;
            treeNode12.Tag = "4.1";
            treeNode12.Text = "Элементы3D";
            treeNode13.ContextMenuStrip = this.objects_MenuStrip;
            treeNode13.ImageIndex = 14;
            treeNode13.Name = "объекты";
            treeNode13.SelectedImageIndex = 14;
            treeNode13.Tag = "4";
            treeNode13.Text = "Объекты";
            treeNode14.ContextMenuStrip = this.groups_MenuStrip;
            treeNode14.ImageIndex = 14;
            treeNode14.Name = "группыОбъектов";
            treeNode14.SelectedImageIndex = 14;
            treeNode14.Tag = "5";
            treeNode14.Text = "Группы объектов";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode13,
            treeNode14});
            this.treeView.SelectedImageIndex = 16;
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(225, 327);
            this.treeView.TabIndex = 2;
            this.treeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_BeforeLabelEdit);
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.Enter += new System.EventHandler(this.treeView_Enter);
            this.treeView.Leave += new System.EventHandler(this.treeView_Leave);
            // 
            // grbNavigator
            // 
            this.grbNavigator.BackColor = System.Drawing.Color.Silver;
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
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel grbNavigator;
    }
}
