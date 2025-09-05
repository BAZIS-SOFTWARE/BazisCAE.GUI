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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Точки", 14, 14);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Кривые", 14, 14);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Поверхности", 14, 14);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Объемы", 14, 14);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Геометрия", 14, 14, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Узлы", 14, 14);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Элементы1D", 14, 14);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Элементы2D", 14, 14);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Элементы3D", 14, 14);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Сетка", 14, 14, new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Группы", 14, 14);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Задача", 14, 14);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Расчет", 14, 14);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Результаты", 14, 14);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Проект", 14, 14, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            this.objects_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.meshMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.квадратная2DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.треугольная2DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уплотнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.по3DСеткеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.трехмернаяMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создать3DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалить3DMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создать1Dпо2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наПоверхности2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groups_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.taskMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagram_gantt_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закреплениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.низкийПриорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийПриорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.высокийПриорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьИнструкцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьРезToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьРезToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodesImageList_16x16 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.ndGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.set_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьНаборMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьПорядокЭлементовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetFirstOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.SetSecondOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.elGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.resultMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.экспортЗначенийMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьАнимациюMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultTimeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьДиаграммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьУсловиеMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.objects_MenuStrip.SuspendLayout();
            this.meshMenuStrip.SuspendLayout();
            this.groups_MenuStrip.SuspendLayout();
            this.taskMenuStrip.SuspendLayout();
            this.compMenuStrip.SuspendLayout();
            this.resultsMenuStrip.SuspendLayout();
            this.ndGroup_MenuStrip.SuspendLayout();
            this.set_MenuStrip.SuspendLayout();
            this.elGroup_MenuStrip.SuspendLayout();
            this.resultMenuStrip.SuspendLayout();
            this.resultTimeMenuStrip.SuspendLayout();
            this.objectMenuStrip.SuspendLayout();
            this.condMenuStrip.SuspendLayout();
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
            this.objects_MenuStrip.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Удалить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.DelObjects_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "Скрыть";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.HideObjects_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem3.Text = "Показать";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ShowObjects_Click);
            // 
            // meshMenuStrip
            // 
            this.meshMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.meshMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создать1Dпо2DToolStripMenuItem,
            this.toolStripMenuItem13,
            this.трехмернаяMenuItem});
            this.meshMenuStrip.Name = "taskMenuStrip";
            this.meshMenuStrip.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.квадратная2DMenuItem,
            this.треугольная2DMenuItem,
            this.уплотнитьToolStripMenuItem,
            this.по3DСеткеToolStripMenuItem,
            this.удалитьToolStripMenuItem1});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem13.Text = "2D";
            // 
            // квадратная2DMenuItem
            // 
            this.квадратная2DMenuItem.Name = "квадратная2DMenuItem";
            this.квадратная2DMenuItem.Size = new System.Drawing.Size(182, 22);
            this.квадратная2DMenuItem.Text = "Квадратная";
            // 
            // треугольная2DMenuItem
            // 
            this.треугольная2DMenuItem.Name = "треугольная2DMenuItem";
            this.треугольная2DMenuItem.Size = new System.Drawing.Size(182, 22);
            this.треугольная2DMenuItem.Text = "Треугольная";
            this.треугольная2DMenuItem.Click += new System.EventHandler(this.треугольная2DMenuItem_Click);
            // 
            // уплотнитьToolStripMenuItem
            // 
            this.уплотнитьToolStripMenuItem.Name = "уплотнитьToolStripMenuItem";
            this.уплотнитьToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.уплотнитьToolStripMenuItem.Text = "Уплотнить";
            // 
            // по3DСеткеToolStripMenuItem
            // 
            this.по3DСеткеToolStripMenuItem.Name = "по3DСеткеToolStripMenuItem";
            this.по3DСеткеToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.по3DСеткеToolStripMenuItem.Text = "На поверхности 3D ";
            this.по3DСеткеToolStripMenuItem.Click += new System.EventHandler(this.создать2Dпо3DToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            // 
            // трехмернаяMenuItem
            // 
            this.трехмернаяMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создать3DMenuItem,
            this.удалить3DMenuItem});
            this.трехмернаяMenuItem.Name = "трехмернаяMenuItem";
            this.трехмернаяMenuItem.Size = new System.Drawing.Size(180, 22);
            this.трехмернаяMenuItem.Text = "3D";
            // 
            // создать3DMenuItem
            // 
            this.создать3DMenuItem.Name = "создать3DMenuItem";
            this.создать3DMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создать3DMenuItem.Text = "Создать";
            this.создать3DMenuItem.Click += new System.EventHandler(this.создать3DMenuItem_Click);
            // 
            // удалить3DMenuItem
            // 
            this.удалить3DMenuItem.Name = "удалить3DMenuItem";
            this.удалить3DMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалить3DMenuItem.Text = "Удалить";
            // 
            // создать1Dпо2DToolStripMenuItem
            // 
            this.создать1Dпо2DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.наПоверхности2DToolStripMenuItem,
            this.удалитьToolStripMenuItem2});
            this.создать1Dпо2DToolStripMenuItem.Name = "создать1Dпо2DToolStripMenuItem";
            this.создать1Dпо2DToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создать1Dпо2DToolStripMenuItem.Text = "1D";
            // 
            // наПоверхности2DToolStripMenuItem
            // 
            this.наПоверхности2DToolStripMenuItem.Name = "наПоверхности2DToolStripMenuItem";
            this.наПоверхности2DToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.наПоверхности2DToolStripMenuItem.Text = "На поверхности 2D";
            this.наПоверхности2DToolStripMenuItem.Click += new System.EventHandler(this.создать1Dпо2DToolStripMenuItem_Click);
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
            // taskMenuStrip
            // 
            this.taskMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.diagram_gantt_toolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.taskMenuStrip.Name = "taskMenuStrip";
            this.taskMenuStrip.Size = new System.Drawing.Size(214, 70);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьВсеУсловияToolStripMenuItem_Click);
            // 
            // diagram_gantt_toolStripMenuItem
            // 
            this.diagram_gantt_toolStripMenuItem.Name = "diagram_gantt_toolStripMenuItem";
            this.diagram_gantt_toolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.diagram_gantt_toolStripMenuItem.Text = "Показать на диаграммме";
            this.diagram_gantt_toolStripMenuItem.Click += new System.EventHandler(this.diagram_gantt_toolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалToolStripMenuItem,
            this.закреплениеToolStripMenuItem,
            this.нагрузкаToolStripMenuItem,
            this.нагревToolStripMenuItem,
            this.средаToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.материалToolStripMenuItem.Text = "Материал";
            this.материалToolStripMenuItem.Click += new System.EventHandler(this.материалToolStripMenuItem_Click);
            // 
            // закреплениеToolStripMenuItem
            // 
            this.закреплениеToolStripMenuItem.Name = "закреплениеToolStripMenuItem";
            this.закреплениеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.закреплениеToolStripMenuItem.Text = "Закрепление";
            this.закреплениеToolStripMenuItem.Click += new System.EventHandler(this.закреплениеToolStripMenuItem_Click);
            // 
            // нагрузкаToolStripMenuItem
            // 
            this.нагрузкаToolStripMenuItem.Name = "нагрузкаToolStripMenuItem";
            this.нагрузкаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагрузкаToolStripMenuItem.Text = "Нагрузка";
            this.нагрузкаToolStripMenuItem.Click += new System.EventHandler(this.нагрузкаToolStripMenuItem_Click);
            // 
            // нагревToolStripMenuItem
            // 
            this.нагревToolStripMenuItem.Name = "нагревToolStripMenuItem";
            this.нагревToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагревToolStripMenuItem.Text = "Нагрев";
            this.нагревToolStripMenuItem.Click += new System.EventHandler(this.нагревToolStripMenuItem_Click);
            // 
            // средаToolStripMenuItem
            // 
            this.средаToolStripMenuItem.Name = "средаToolStripMenuItem";
            this.средаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.средаToolStripMenuItem.Text = "Среда";
            this.средаToolStripMenuItem.Click += new System.EventHandler(this.средаToolStripMenuItem_Click);
            // 
            // compMenuStrip
            // 
            this.compMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.compMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.сформироватьИнструкцииToolStripMenuItem,
            this.запуститьРасчетToolStripMenuItem,
            this.остановитьРасчетToolStripMenuItem});
            this.compMenuStrip.Name = "taskMenuStrip";
            this.compMenuStrip.Size = new System.Drawing.Size(227, 92);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.низкийПриорToolStripMenuItem,
            this.среднийПриорToolStripMenuItem,
            this.высокийПриорToolStripMenuItem});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItem8.Text = "Задать приоритет";
            // 
            // низкийПриорToolStripMenuItem
            // 
            this.низкийПриорToolStripMenuItem.Name = "низкийПриорToolStripMenuItem";
            this.низкийПриорToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.низкийПриорToolStripMenuItem.Text = "Низкий";
            this.низкийПриорToolStripMenuItem.Click += new System.EventHandler(this.низкийПриорToolStripMenuItem_Click);
            // 
            // среднийПриорToolStripMenuItem
            // 
            this.среднийПриорToolStripMenuItem.Name = "среднийПриорToolStripMenuItem";
            this.среднийПриорToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.среднийПриорToolStripMenuItem.Text = "Средний";
            this.среднийПриорToolStripMenuItem.Click += new System.EventHandler(this.среднийПриорToolStripMenuItem_Click);
            // 
            // высокийПриорToolStripMenuItem
            // 
            this.высокийПриорToolStripMenuItem.Name = "высокийПриорToolStripMenuItem";
            this.высокийПриорToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.высокийПриорToolStripMenuItem.Text = "Высокий";
            this.высокийПриорToolStripMenuItem.Click += new System.EventHandler(this.высокийПриорToolStripMenuItem_Click);
            // 
            // сформироватьИнструкцииToolStripMenuItem
            // 
            this.сформироватьИнструкцииToolStripMenuItem.Name = "сформироватьИнструкцииToolStripMenuItem";
            this.сформироватьИнструкцииToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.сформироватьИнструкцииToolStripMenuItem.Text = "Сформировать инструкции";
            this.сформироватьИнструкцииToolStripMenuItem.Click += new System.EventHandler(this.сформироватьИнструкцииToolStripMenuItem_Click);
            // 
            // запуститьРасчетToolStripMenuItem
            // 
            this.запуститьРасчетToolStripMenuItem.Name = "запуститьРасчетToolStripMenuItem";
            this.запуститьРасчетToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.запуститьРасчетToolStripMenuItem.Text = "Запустить расчет";
            this.запуститьРасчетToolStripMenuItem.Click += new System.EventHandler(this.запуститьРасчетToolStripMenuItem_Click);
            // 
            // остановитьРасчетToolStripMenuItem
            // 
            this.остановитьРасчетToolStripMenuItem.Name = "остановитьРасчетToolStripMenuItem";
            this.остановитьРасчетToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.остановитьРасчетToolStripMenuItem.Text = "Остановить расчет";
            this.остановитьРасчетToolStripMenuItem.Click += new System.EventHandler(this.остановитьРасчетToolStripMenuItem_Click);
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.скрытьРезToolStripMenuItem,
            this.удалитьРезToolStripMenuItem});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(129, 70);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьРезультатыToolStripMenuItem_Click);
            // 
            // скрытьРезToolStripMenuItem
            // 
            this.скрытьРезToolStripMenuItem.Name = "скрытьРезToolStripMenuItem";
            this.скрытьРезToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.скрытьРезToolStripMenuItem.Text = "Скрыть";
            this.скрытьРезToolStripMenuItem.Click += new System.EventHandler(this.скрытьРезToolStripMenuItem_Click);
            // 
            // удалитьРезToolStripMenuItem
            // 
            this.удалитьРезToolStripMenuItem.Name = "удалитьРезToolStripMenuItem";
            this.удалитьРезToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.изменитьПорядокЭлементовToolStripMenuItem});
            this.set_MenuStrip.Name = "lv0_MenuStrip";
            this.set_MenuStrip.Size = new System.Drawing.Size(177, 92);
            // 
            // удалитьНаборMenuItem
            // 
            this.удалитьНаборMenuItem.Name = "удалитьНаборMenuItem";
            this.удалитьНаборMenuItem.Size = new System.Drawing.Size(176, 22);
            this.удалитьНаборMenuItem.Text = "Удалить";
            this.удалитьНаборMenuItem.Click += new System.EventHandler(this.DelSet_Click);
            // 
            // скрытьНаборMenuItem
            // 
            this.скрытьНаборMenuItem.Name = "скрытьНаборMenuItem";
            this.скрытьНаборMenuItem.Size = new System.Drawing.Size(176, 22);
            this.скрытьНаборMenuItem.Text = "Скрыть";
            this.скрытьНаборMenuItem.Click += new System.EventHandler(this.HideSet_Click);
            // 
            // показатьНаборMenuItem
            // 
            this.показатьНаборMenuItem.Name = "показатьНаборMenuItem";
            this.показатьНаборMenuItem.Size = new System.Drawing.Size(176, 22);
            this.показатьНаборMenuItem.Text = "Показать";
            this.показатьНаборMenuItem.Click += new System.EventHandler(this.ShowSet_Click);
            // 
            // изменитьПорядокЭлементовToolStripMenuItem
            // 
            this.изменитьПорядокЭлементовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetFirstOrder,
            this.SetSecondOrder});
            this.изменитьПорядокЭлементовToolStripMenuItem.Name = "изменитьПорядокЭлементовToolStripMenuItem";
            this.изменитьПорядокЭлементовToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.изменитьПорядокЭлементовToolStripMenuItem.Text = "Порядок точности";
            // 
            // SetFirstOrder
            // 
            this.SetFirstOrder.Name = "SetFirstOrder";
            this.SetFirstOrder.Size = new System.Drawing.Size(80, 22);
            this.SetFirstOrder.Text = "1";
            this.SetFirstOrder.Click += new System.EventHandler(this.SetFirstOrder_Click);
            // 
            // SetSecondOrder
            // 
            this.SetSecondOrder.Name = "SetSecondOrder";
            this.SetSecondOrder.Size = new System.Drawing.Size(80, 22);
            this.SetSecondOrder.Text = "2";
            this.SetSecondOrder.Click += new System.EventHandler(this.SetSecondOrder_Click);
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
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.FullRowSelect = true;
            this.treeView.ImageIndex = 16;
            this.treeView.ImageList = this.treeNodesImageList_16x16;
            this.treeView.Indent = 19;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            treeNode1.ContextMenuStrip = this.objects_MenuStrip;
            treeNode1.ImageIndex = 14;
            treeNode1.Name = "Точки";
            treeNode1.SelectedImageIndex = 14;
            treeNode1.Tag = "5.1";
            treeNode1.Text = "Точки";
            treeNode2.ContextMenuStrip = this.objects_MenuStrip;
            treeNode2.ImageIndex = 14;
            treeNode2.Name = "Кривые";
            treeNode2.SelectedImageIndex = 14;
            treeNode2.Tag = "5.1";
            treeNode2.Text = "Кривые";
            treeNode3.ContextMenuStrip = this.objects_MenuStrip;
            treeNode3.ImageIndex = 14;
            treeNode3.Name = "Поверхности";
            treeNode3.SelectedImageIndex = 14;
            treeNode3.Tag = "5.1";
            treeNode3.Text = "Поверхности";
            treeNode4.ContextMenuStrip = this.objects_MenuStrip;
            treeNode4.ImageIndex = 14;
            treeNode4.Name = "Объемы";
            treeNode4.SelectedImageIndex = 14;
            treeNode4.Tag = "5.1";
            treeNode4.Text = "Объемы";
            treeNode5.ImageIndex = 14;
            treeNode5.Name = "геометрия";
            treeNode5.SelectedImageIndex = 14;
            treeNode5.Tag = "5";
            treeNode5.Text = "Геометрия";
            treeNode6.ContextMenuStrip = this.objects_MenuStrip;
            treeNode6.ImageIndex = 14;
            treeNode6.Name = "Узлы";
            treeNode6.SelectedImageIndex = 14;
            treeNode6.Tag = "5.1";
            treeNode6.Text = "Узлы";
            treeNode7.ContextMenuStrip = this.objects_MenuStrip;
            treeNode7.ImageIndex = 14;
            treeNode7.Name = "Элементы1D";
            treeNode7.SelectedImageIndex = 14;
            treeNode7.Tag = "5.1";
            treeNode7.Text = "Элементы1D";
            treeNode8.ContextMenuStrip = this.objects_MenuStrip;
            treeNode8.ImageIndex = 14;
            treeNode8.Name = "Элементы2D";
            treeNode8.SelectedImageIndex = 14;
            treeNode8.Tag = "5.1";
            treeNode8.Text = "Элементы2D";
            treeNode9.ContextMenuStrip = this.objects_MenuStrip;
            treeNode9.ImageIndex = 14;
            treeNode9.Name = "Элементы3D";
            treeNode9.SelectedImageIndex = 14;
            treeNode9.Tag = "5.1";
            treeNode9.Text = "Элементы3D";
            treeNode10.ContextMenuStrip = this.meshMenuStrip;
            treeNode10.ImageIndex = 14;
            treeNode10.Name = "сетка";
            treeNode10.SelectedImageIndex = 14;
            treeNode10.Text = "Сетка";
            treeNode11.ContextMenuStrip = this.groups_MenuStrip;
            treeNode11.ImageIndex = 14;
            treeNode11.Name = "группы";
            treeNode11.SelectedImageIndex = 14;
            treeNode11.Tag = "6";
            treeNode11.Text = "Группы";
            treeNode12.ContextMenuStrip = this.taskMenuStrip;
            treeNode12.ImageIndex = 14;
            treeNode12.Name = "задача";
            treeNode12.SelectedImageIndex = 14;
            treeNode12.Tag = "7";
            treeNode12.Text = "Задача";
            treeNode13.ContextMenuStrip = this.compMenuStrip;
            treeNode13.ImageIndex = 14;
            treeNode13.Name = "расчет";
            treeNode13.SelectedImageIndex = 14;
            treeNode13.Tag = "8";
            treeNode13.Text = "Расчет";
            treeNode14.ContextMenuStrip = this.resultsMenuStrip;
            treeNode14.ImageIndex = 14;
            treeNode14.Name = "результаты";
            treeNode14.SelectedImageIndex = 14;
            treeNode14.Tag = "9";
            treeNode14.Text = "Результаты";
            treeNode15.ImageIndex = 14;
            treeNode15.Name = "проект";
            treeNode15.SelectedImageIndex = 14;
            treeNode15.Text = "Проект";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView.SelectedImageIndex = 16;
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(256, 539);
            this.treeView.TabIndex = 5;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.Enter += new System.EventHandler(this.treeView_Enter);
            this.treeView.Leave += new System.EventHandler(this.treeView_Leave);
            // 
            // resultMenuStrip
            // 
            this.resultMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортЗначенийMenuItem,
            this.создатьАнимациюMenuItem,
            this.построитьГрафикToolStripMenuItem});
            this.resultMenuStrip.Name = "resultsMenuStrip";
            this.resultMenuStrip.Size = new System.Drawing.Size(180, 70);
            // 
            // экспортЗначенийMenuItem
            // 
            this.экспортЗначенийMenuItem.Name = "экспортЗначенийMenuItem";
            this.экспортЗначенийMenuItem.Size = new System.Drawing.Size(179, 22);
            this.экспортЗначенийMenuItem.Text = "Экспорт значений";
            // 
            // создатьАнимациюMenuItem
            // 
            this.создатьАнимациюMenuItem.Name = "создатьАнимациюMenuItem";
            this.создатьАнимациюMenuItem.Size = new System.Drawing.Size(179, 22);
            this.создатьАнимациюMenuItem.Text = "Создать анимацию";
            this.создатьАнимациюMenuItem.Click += new System.EventHandler(this.создатьАнимациюMenuItem_Click);
            // 
            // построитьГрафикToolStripMenuItem
            // 
            this.построитьГрафикToolStripMenuItem.Name = "построитьГрафикToolStripMenuItem";
            this.построитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.построитьГрафикToolStripMenuItem.Text = "Построить график";
            // 
            // resultTimeMenuStrip
            // 
            this.resultTimeMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultTimeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem20,
            this.построитьДиаграммуToolStripMenuItem});
            this.resultTimeMenuStrip.Name = "resultsMenuStrip";
            this.resultTimeMenuStrip.Size = new System.Drawing.Size(198, 70);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem15.Text = "Экспорт значений";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem20.Text = "Экспорт сетки";
            // 
            // построитьДиаграммуToolStripMenuItem
            // 
            this.построитьДиаграммуToolStripMenuItem.Name = "построитьДиаграммуToolStripMenuItem";
            this.построитьДиаграммуToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.построитьДиаграммуToolStripMenuItem.Text = "Построить диаграмму";
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
            // удалитьToolStripMenuItem2
            // 
            this.удалитьToolStripMenuItem2.Name = "удалитьToolStripMenuItem2";
            this.удалитьToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem2.Text = "Удалить";
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
            this.objects_MenuStrip.ResumeLayout(false);
            this.meshMenuStrip.ResumeLayout(false);
            this.groups_MenuStrip.ResumeLayout(false);
            this.taskMenuStrip.ResumeLayout(false);
            this.compMenuStrip.ResumeLayout(false);
            this.resultsMenuStrip.ResumeLayout(false);
            this.ndGroup_MenuStrip.ResumeLayout(false);
            this.set_MenuStrip.ResumeLayout(false);
            this.elGroup_MenuStrip.ResumeLayout(false);
            this.resultMenuStrip.ResumeLayout(false);
            this.resultTimeMenuStrip.ResumeLayout(false);
            this.objectMenuStrip.ResumeLayout(false);
            this.condMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
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
        private System.Windows.Forms.ContextMenuStrip objects_MenuStrip;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip compMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem низкийПриорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийПриорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem высокийПриорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьИнструкцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьРасчетToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьРезToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьРезToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip taskMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagram_gantt_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закреплениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нагрузкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нагревToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem средаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem экспортЗначенийMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьАнимациюMenuItem;
        private System.Windows.Forms.ContextMenuStrip resultTimeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem построитьГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьДиаграммуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip objectMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьПорядокЭлементовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetFirstOrder;
        private System.Windows.Forms.ToolStripMenuItem SetSecondOrder;
        private System.Windows.Forms.ContextMenuStrip meshMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem квадратная2DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem треугольная2DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem трехмернаяMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уплотнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem создать3DMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалить3DMenuItem;
        private System.Windows.Forms.ContextMenuStrip condMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьУсловиеMenuItem;
        private System.Windows.Forms.ToolStripMenuItem по3DСеткеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создать1Dпо2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наПоверхности2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem2;
    }
}
