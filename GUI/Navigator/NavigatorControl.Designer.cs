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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorControl));
            var treeNode2 = new System.Windows.Forms.TreeNode("Проект", 7, 7);
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
            helpImageList.Images.SetKeyName(0, "Инфо.png");
            helpImageList.Images.SetKeyName(1, "Карандаш.png");
            helpImageList.Images.SetKeyName(2, "Открыто.png");
            helpImageList.Images.SetKeyName(3, "Закрыто.png");
            helpImageList.Images.SetKeyName(4, "Удалить раздел.png");
            // 
            // treeView
            // 
            treeView.BackColor = System.Drawing.SystemColors.Control;
            treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            treeView.FullRowSelect = true;
            treeView.ImageIndex = 9;
            treeView.ImageList = genImageList;
            treeView.Indent = 19;
            treeView.ItemHeight = 18;
            treeView.Location = new System.Drawing.Point(0, 20);
            treeView.Margin = new System.Windows.Forms.Padding(0);
            treeView.Name = "treeView";
            treeNode2.ImageIndex = 7;
            treeNode2.Name = "проект";
            treeNode2.SelectedImageIndex = 7;
            treeNode2.Text = "Проект";
            treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode2 });
            treeView.SelectedImageIndex = 9;
            treeView.ShowLines = false;
            treeView.Size = new System.Drawing.Size(299, 619);
            treeView.TabIndex = 5;
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
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gainsboro;
            Controls.Add(treeView);
            HeaderName = "Навигатор";
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            Name = "NavigatorControl";
            Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            Size = new System.Drawing.Size(299, 639);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList helpImageList;
        private System.Windows.Forms.ImageList genImageList;
        private System.Windows.Forms.TreeView treeView;
    }
}
