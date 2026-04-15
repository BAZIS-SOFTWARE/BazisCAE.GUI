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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorControl));
            genImageList = new System.Windows.Forms.ImageList(components);
            helpImageList = new System.Windows.Forms.ImageList(components);
            treeView = new System.Windows.Forms.TreeView();
            SuspendLayout();
            // 
            // genImageList
            // 
            genImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            genImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("genImageList.ImageStream");
            genImageList.TransparentColor = System.Drawing.Color.Transparent;
            genImageList.Images.SetKeyName(0, "NodeObjs.png");
            genImageList.Images.SetKeyName(1, "MeshObjs.png");
            genImageList.Images.SetKeyName(2, "Материалы.bmp");
            genImageList.Images.SetKeyName(3, "Среда.bmp");
            genImageList.Images.SetKeyName(4, "Нагрев.bmp");
            genImageList.Images.SetKeyName(5, "Закрепление.bmp");
            genImageList.Images.SetKeyName(6, "Нагрузки.bmp");
            genImageList.Images.SetKeyName(7, "н 2.png");
            genImageList.Images.SetKeyName(8, "н 3.png");
            genImageList.Images.SetKeyName(9, "н1.png");
            // 
            // helpImageList
            // 
            helpImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            helpImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("helpImageList.ImageStream");
            helpImageList.TransparentColor = System.Drawing.Color.Transparent;
            helpImageList.Images.SetKeyName(0, "info_w.png");
            helpImageList.Images.SetKeyName(1, "Edit.png");
            helpImageList.Images.SetKeyName(2, "show_w.png");
            helpImageList.Images.SetKeyName(3, "hide_w.png");
            helpImageList.Images.SetKeyName(4, "Del.ico");
            // 
            // treeView
            // 
            resources.ApplyResources(treeView, "treeView");
            treeView.BackColor = System.Drawing.SystemColors.Control;
            treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            treeView.FullRowSelect = true;
            treeView.ImageList = genImageList;
            treeView.ItemHeight = 18;
            treeView.Name = "treeView";
            treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { (System.Windows.Forms.TreeNode)resources.GetObject("treeView.Nodes") });
            treeView.ShowLines = false;
            treeView.AfterCollapse += treeView_AfterCollapse;
            treeView.BeforeExpand += treeView_BeforeExpand;
            treeView.AfterExpand += treeView_AfterExpand;
            treeView.DrawNode += treeView_DrawNode;
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            treeView.Enter += treeView_Enter;
            // 
            // NavigatorControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gainsboro;
            Controls.Add(treeView);
            HeaderName = resources.GetString("HeaderName");
            Name = "NavigatorControl";
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList helpImageList;
        private System.Windows.Forms.ImageList genImageList;
        private System.Windows.Forms.TreeView treeView;
    }
}
