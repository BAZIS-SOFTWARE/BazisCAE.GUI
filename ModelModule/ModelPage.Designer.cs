namespace ModelModule
{
    partial class ModelPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelPage));
            this.удалитьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отобразитьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.object_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.показатьОбъектMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.objects_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.groups_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.ndGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.treeNodesImageList_16x16 = new System.Windows.Forms.ImageList(this.components);
            this.elGroup_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.object_MenuStrip.SuspendLayout();
            this.objects_MenuStrip.SuspendLayout();
            this.groups_MenuStrip.SuspendLayout();
            this.ndGroup_MenuStrip.SuspendLayout();
            this.elGroup_MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // удалитьОбъектMenuItem
            // 
            this.удалитьОбъектMenuItem.Image = global::ModelModule.Properties.Resources.Del;
            this.удалитьОбъектMenuItem.Name = "удалитьОбъектMenuItem";
            this.удалитьОбъектMenuItem.Size = new System.Drawing.Size(138, 22);
            this.удалитьОбъектMenuItem.Text = "Удалить";
            this.удалитьОбъектMenuItem.Click += new System.EventHandler(this.DelObjects_Click);
            // 
            // скрытьОбъектMenuItem
            // 
            this.скрытьОбъектMenuItem.Image = global::ModelModule.Properties.Resources.SwitchOff;
            this.скрытьОбъектMenuItem.Name = "скрытьОбъектMenuItem";
            this.скрытьОбъектMenuItem.Size = new System.Drawing.Size(138, 22);
            this.скрытьОбъектMenuItem.Text = "Погасить";
            this.скрытьОбъектMenuItem.Click += new System.EventHandler(this.SwitchOffObjects_Click);
            // 
            // отобразитьОбъектMenuItem
            // 
            this.отобразитьОбъектMenuItem.Image = global::ModelModule.Properties.Resources.SwitchOn;
            this.отобразитьОбъектMenuItem.Name = "отобразитьОбъектMenuItem";
            this.отобразитьОбъектMenuItem.Size = new System.Drawing.Size(138, 22);
            this.отобразитьОбъектMenuItem.Text = "Отобразить";
            this.отобразитьОбъектMenuItem.Click += new System.EventHandler(this.SwitchOnObjects_Click);
            // 
            // object_MenuStrip
            // 
            this.object_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьОбъектMenuItem,
            this.скрытьОбъектMenuItem,
            this.отобразитьОбъектMenuItem,
            this.показатьОбъектMenuItem,
            this.скрытьMenuItem});
            this.object_MenuStrip.Name = "lv0_MenuStrip";
            this.object_MenuStrip.Size = new System.Drawing.Size(139, 114);
            // 
            // показатьОбъектMenuItem
            // 
            this.показатьОбъектMenuItem.Image = global::ModelModule.Properties.Resources.Show;
            this.показатьОбъектMenuItem.Name = "показатьОбъектMenuItem";
            this.показатьОбъектMenuItem.Size = new System.Drawing.Size(138, 22);
            this.показатьОбъектMenuItem.Text = "Показать";
            this.показатьОбъектMenuItem.Click += new System.EventHandler(this.ShowObjects_Click);
            // 
            // скрытьMenuItem
            // 
            this.скрытьMenuItem.Image = global::ModelModule.Properties.Resources.Hide;
            this.скрытьMenuItem.Name = "скрытьMenuItem";
            this.скрытьMenuItem.Size = new System.Drawing.Size(138, 22);
            this.скрытьMenuItem.Text = "Скрыть";
            this.скрытьMenuItem.Click += new System.EventHandler(this.HideObjects_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::ModelModule.Properties.Resources.Del;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem1.Text = "Удалить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.DelAllObjects_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::ModelModule.Properties.Resources.SwitchOff;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem2.Text = "Погасить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.SwitchOffAllObjects_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::ModelModule.Properties.Resources.SwitchOn;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem3.Text = "Отобразить";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.SwitchAllObjects_Click);
            // 
            // objects_MenuStrip
            // 
            this.objects_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.objects_MenuStrip.Name = "lv0_MenuStrip";
            this.objects_MenuStrip.Size = new System.Drawing.Size(139, 70);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::ModelModule.Properties.Resources.Del;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem10.Text = "Удалить";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.DelAllGroups_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::ModelModule.Properties.Resources.Hide;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem11.Text = "Скрыть";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.HideAllGroups_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = global::ModelModule.Properties.Resources.Show;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem12.Text = "Показать";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.ShowAllGroups_Click);
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
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::ModelModule.Properties.Resources.Del;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::ModelModule.Properties.Resources.Hide;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem5.Text = "Скрыть";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::ModelModule.Properties.Resources.Show;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem6.Text = "Показать";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::ModelModule.Properties.Resources.Edit;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem7.Text = "Изменить";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::ModelModule.Properties.Resources.Rename;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem8.Text = "Переименовать";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::ModelModule.Properties.Resources.Info;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem9.Text = "Инфо";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.InfoGroup_Click);
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
            // treeNodesImageList_16x16
            // 
            this.treeNodesImageList_16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodesImageList_16x16.ImageStream")));
            this.treeNodesImageList_16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodesImageList_16x16.Images.SetKeyName(0, "CloseFolder.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(1, "OpenFolder.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(2, "Инфо.bmp");
            this.treeNodesImageList_16x16.Images.SetKeyName(3, "NodeObjs.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(4, "MeshObjs.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(5, "switchOn_nodes_16x16.png");
            this.treeNodesImageList_16x16.Images.SetKeyName(6, "switchOn_elems_16x16.png");
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
            this.toolStripMenuItem16.Image = global::ModelModule.Properties.Resources.Del;
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem16.Text = "Удалить";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.DelGroup_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Image = global::ModelModule.Properties.Resources.Hide;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem17.Text = "Скрыть";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.HideGroup_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Image = global::ModelModule.Properties.Resources.Show;
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem18.Text = "Показать";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.ShowGroup_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Image = global::ModelModule.Properties.Resources.Edit;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem19.Text = "Изменить";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Image = global::ModelModule.Properties.Resources.Rename;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem20.Text = "Переименовать";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.RenameGroup_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Image = global::ModelModule.Properties.Resources.Info;
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem21.Text = "Инфо";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.InfoGroup_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Image = global::ModelModule.Properties.Resources.NodeFromElemGroup;
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem22.Text = "Показать с узлами";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.ShowGroupWithNodes_Click);
            // 
            // ModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ModelPage";
            this.Size = new System.Drawing.Size(1005, 642);
            this.Load += new System.EventHandler(this.ModelPage_Load);
            this.object_MenuStrip.ResumeLayout(false);
            this.objects_MenuStrip.ResumeLayout(false);
            this.groups_MenuStrip.ResumeLayout(false);
            this.ndGroup_MenuStrip.ResumeLayout(false);
            this.elGroup_MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отобразитьОбъектMenuItem;
        private System.Windows.Forms.ContextMenuStrip object_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip objects_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ContextMenuStrip groups_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ContextMenuStrip ndGroup_MenuStrip;
        private System.Windows.Forms.ImageList contextMenuImageList;
        private System.Windows.Forms.ImageList treeNodesImageList_16x16;
        private System.Windows.Forms.ContextMenuStrip elGroup_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem показатьОбъектMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьMenuItem;
    }
}
