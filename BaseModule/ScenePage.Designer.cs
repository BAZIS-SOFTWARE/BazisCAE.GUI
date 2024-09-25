namespace BaseModule
{
    partial class ScenePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenePage));
            this.sceneControl = new Scene.SceneControl();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьГруппуItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьВыбранноеItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьСкрытыеItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_InfoSelectedObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SetRotPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_DeleteSelectedObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.SystemColors.ControlDark;
            this.sceneControl.DisplayBasis = true;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsBlending = true;
            this.sceneControl.IsClipPlane = false;
            this.sceneControl.IsLighting = true;
            this.sceneControl.IsSmoothShadow = false;
            this.sceneControl.LightAttenuation = 0F;
            this.sceneControl.LightTranslateX = 0F;
            this.sceneControl.LightTranslateY = 0F;
            this.sceneControl.LightTranslateZ = 0F;
            this.sceneControl.Location = new System.Drawing.Point(0, 0);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.Projection = Scene.Interfaces.ViewProjection.Perspective;
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = Scene.Interfaces.ViewAxis.XYZ;
            this.sceneControl.ScaleFactor = 1F;
            this.sceneControl.SelectionColor = System.Drawing.Color.Green;
            this.sceneControl.ShadowAngle = 0F;
            this.sceneControl.ShowSurfaceBackEdges = false;
            this.sceneControl.Size = new System.Drawing.Size(609, 472);
            this.sceneControl.TabIndex = 0;
            this.sceneControl.SelectObjectsEvent += new System.Action<object, Scene.Events.SelectObjectsEventArgs>(this.sceneControl_SelectObjectsEvent);
            this.sceneControl.SceneMouseClickEvent += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.sceneControl_SceneMouseClickEvent);
            this.sceneControl.SceneKeyDownEvent += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.sceneControl_SceneKeyDownEvent);
            this.sceneControl.MessageEvent += new System.Action<object, Scene.Events.MessageEventArgs>(this.sceneControl_MessageEvent);
            this.sceneControl.SceneControlExpandEvent += new System.Action(this.sceneControl_SceneControlExpandEvent);
            this.sceneControl.SceneControlFoldEvent += new System.Action(this.sceneControl_SceneControlFoldEvent);
            this.sceneControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sceneControl_SceneMouseClickEvent);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьГруппуItem,
            this.скрытьВыбранноеItem,
            this.показатьСкрытыеItem,
            this.menuItem_InfoSelectedObjects,
            this.menuItem_SetRotPoint,
            this.menuItem_DeleteSelectedObjects});
            this.contextMenu.Name = "sceneContextMenu";
            this.contextMenu.Size = new System.Drawing.Size(204, 136);
            // 
            // создатьГруппуItem
            // 
            this.создатьГруппуItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьГруппуItem.Image")));
            this.создатьГруппуItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.создатьГруппуItem.Name = "создатьГруппуItem";
            this.создатьГруппуItem.Size = new System.Drawing.Size(203, 22);
            this.создатьГруппуItem.Text = "Создать новую группу";
            this.создатьГруппуItem.Click += new System.EventHandler(this.создатьГруппуItem_Click);
            // 
            // скрытьВыбранноеItem
            // 
            this.скрытьВыбранноеItem.Image = ((System.Drawing.Image)(resources.GetObject("скрытьВыбранноеItem.Image")));
            this.скрытьВыбранноеItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.скрытьВыбранноеItem.Name = "скрытьВыбранноеItem";
            this.скрытьВыбранноеItem.Size = new System.Drawing.Size(203, 22);
            this.скрытьВыбранноеItem.Text = "Скрыть выбранное";
            this.скрытьВыбранноеItem.Click += new System.EventHandler(this.скрытьВыбранноеItem_Click);
            // 
            // показатьСкрытыеItem
            // 
            this.показатьСкрытыеItem.Image = ((System.Drawing.Image)(resources.GetObject("показатьСкрытыеItem.Image")));
            this.показатьСкрытыеItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.показатьСкрытыеItem.Name = "показатьСкрытыеItem";
            this.показатьСкрытыеItem.Size = new System.Drawing.Size(203, 22);
            this.показатьСкрытыеItem.Text = "Показать все скрытые";
            this.показатьСкрытыеItem.Click += new System.EventHandler(this.показатьСкрытыеItem_Click);
            // 
            // menuItem_InfoSelectedObjects
            // 
            this.menuItem_InfoSelectedObjects.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_InfoSelectedObjects.Image")));
            this.menuItem_InfoSelectedObjects.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_InfoSelectedObjects.Name = "menuItem_InfoSelectedObjects";
            this.menuItem_InfoSelectedObjects.Size = new System.Drawing.Size(203, 22);
            this.menuItem_InfoSelectedObjects.Text = "Инфо";
            this.menuItem_InfoSelectedObjects.Click += new System.EventHandler(this.menuItem_InfoSelectedObjects_Click);
            // 
            // menuItem_SetRotPoint
            // 
            this.menuItem_SetRotPoint.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_SetRotPoint.Image")));
            this.menuItem_SetRotPoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_SetRotPoint.Name = "menuItem_SetRotPoint";
            this.menuItem_SetRotPoint.Size = new System.Drawing.Size(203, 22);
            this.menuItem_SetRotPoint.Text = "Задать точку вращения";
            this.menuItem_SetRotPoint.Click += new System.EventHandler(this.menuItem_SetRotPoint_Click);
            // 
            // menuItem_DeleteSelectedObjects
            // 
            this.menuItem_DeleteSelectedObjects.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_DeleteSelectedObjects.Image")));
            this.menuItem_DeleteSelectedObjects.Name = "menuItem_DeleteSelectedObjects";
            this.menuItem_DeleteSelectedObjects.Size = new System.Drawing.Size(203, 22);
            this.menuItem_DeleteSelectedObjects.Text = "Удалить выбранное";
            this.menuItem_DeleteSelectedObjects.Click += new System.EventHandler(this.menuItem_DeleteSelectedObjects_Click);
            // 
            // ScenePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sceneControl);
            this.Name = "ScenePage";
            this.Size = new System.Drawing.Size(609, 472);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem создатьГруппуItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьВыбранноеItem;
        private System.Windows.Forms.ToolStripMenuItem показатьСкрытыеItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_InfoSelectedObjects;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetRotPoint;
        private System.Windows.Forms.ToolStripMenuItem menuItem_DeleteSelectedObjects;
        private Scene.SceneControl sceneControl;
    }
}
