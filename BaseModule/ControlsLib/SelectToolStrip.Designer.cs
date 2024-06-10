namespace BaseModule.ControlsLib
{
    partial class SelectToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectToolStrip));
            this.btnNodes = new System.Windows.Forms.ToolStripButton();
            this.btnElems = new System.Windows.Forms.ToolStripButton();
            this.btnObjs = new System.Windows.Forms.ToolStripButton();
            this.btnSplitSelector = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSelectorHelper = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnNodes
            // 
            this.btnNodes.AutoSize = false;
            this.btnNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNodes.Image = ((System.Drawing.Image)(resources.GetObject("btnNodes.Image")));
            this.btnNodes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNodes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNodes.Name = "btnNodes";
            this.btnNodes.Size = new System.Drawing.Size(36, 50);
            this.btnNodes.Tag = "1";
            this.btnNodes.Text = "Выбрать узлы";
            // 
            // btnElems
            // 
            this.btnElems.AutoSize = false;
            this.btnElems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElems.Image = ((System.Drawing.Image)(resources.GetObject("btnElems.Image")));
            this.btnElems.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnElems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElems.Name = "btnElems";
            this.btnElems.Size = new System.Drawing.Size(36, 50);
            this.btnElems.Tag = "2";
            this.btnElems.Text = "Выбрать элементы";
            // 
            // btnObjs
            // 
            this.btnObjs.AutoSize = false;
            this.btnObjs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnObjs.Image = ((System.Drawing.Image)(resources.GetObject("btnObjs.Image")));
            this.btnObjs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnObjs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnObjs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnObjs.Name = "btnObjs";
            this.btnObjs.Size = new System.Drawing.Size(36, 50);
            this.btnObjs.Tag = "3";
            this.btnObjs.Text = "Выбрать геометрию";
            this.btnObjs.ToolTipText = "Выбрать объекты";
            // 
            // btnSplitSelector
            // 
            this.btnSplitSelector.AutoSize = false;
            this.btnSplitSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSplitSelector.DropDownButtonWidth = 16;
            this.btnSplitSelector.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSplitSelector.Image = ((System.Drawing.Image)(resources.GetObject("btnSplitSelector.Image")));
            this.btnSplitSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitSelector.Name = "btnSplitSelector";
            this.btnSplitSelector.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSplitSelector.Size = new System.Drawing.Size(155, 50);
            this.btnSplitSelector.Tag = "0";
            this.btnSplitSelector.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSplitSelector.ToolTipText = "Выберите объект";
            // 
            // btnSelectorHelper
            // 
            this.btnSelectorHelper.AutoSize = false;
            this.btnSelectorHelper.CheckOnClick = true;
            this.btnSelectorHelper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectorHelper.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectorHelper.Image")));
            this.btnSelectorHelper.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectorHelper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectorHelper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectorHelper.Name = "btnSelectorHelper";
            this.btnSelectorHelper.Size = new System.Drawing.Size(36, 50);
            this.btnSelectorHelper.Tag = "4";
            this.btnSelectorHelper.Text = "Дополнительный выбор";
            // 
            // SelectToolStrip
            // 
            this.AllowDrop = true;
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSplitSelector,
            this.btnNodes,
            this.btnElems,
            this.btnObjs,
            this.btnSelectorHelper});
            this.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Size = new System.Drawing.Size(800, 55);
            this.Text = "Выбор";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnNodes;
        private System.Windows.Forms.ToolStripButton btnElems;
        private System.Windows.Forms.ToolStripButton btnObjs;
        private System.Windows.Forms.ToolStripSplitButton btnSplitSelector;
        private System.Windows.Forms.ToolStripButton btnSelectorHelper;
    }
}
