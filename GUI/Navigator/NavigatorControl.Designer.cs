namespace BazisGUI.Navigator
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Проект", 7, 7);
            this.genImageList = new System.Windows.Forms.ImageList(this.components);
            this.helpImageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // genImageList
            // 
            this.genImageList.ImageStream = Properties.Resources.genImageList_ImageStream;
            this.genImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.genImageList.Images.SetKeyName(0, "NodeObjs.png");
            this.genImageList.Images.SetKeyName(1, "MeshObjs.png");
            this.genImageList.Images.SetKeyName(2, "Материалы.bmp");
            this.genImageList.Images.SetKeyName(3, "Среда.bmp");
            this.genImageList.Images.SetKeyName(4, "Нагрев.bmp");
            this.genImageList.Images.SetKeyName(5, "Закрепление.bmp");
            this.genImageList.Images.SetKeyName(6, "Нагрузки.bmp");
            this.genImageList.Images.SetKeyName(7, "н 2.png");
            this.genImageList.Images.SetKeyName(8, "н 3.png");
            this.genImageList.Images.SetKeyName(9, "н1.png");
            // 
            // helpImageList
            // 
            this.helpImageList.ImageStream = Properties.Resources.helpImageList_ImageStream;
            this.helpImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.helpImageList.Images.SetKeyName(0, "info_w.png");
            this.helpImageList.Images.SetKeyName(1, "Edit.png");
            this.helpImageList.Images.SetKeyName(2, "show_w.png");
            this.helpImageList.Images.SetKeyName(3, "hide_w.png");
            this.helpImageList.Images.SetKeyName(4, "Del.ico");
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.FullRowSelect = true;
            this.treeView.ImageIndex = 9;
            //this.treeView.ImageList = this.genImageList;
            this.treeView.Indent = 19;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 15);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 7;
            treeNode1.Name = "проект";
            treeNode1.SelectedImageIndex = 7;
            treeNode1.Text = "Проект";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.SelectedImageIndex = 9;
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList helpImageList;
        private System.Windows.Forms.ImageList genImageList;
        private System.Windows.Forms.TreeView treeView;
    }
}
