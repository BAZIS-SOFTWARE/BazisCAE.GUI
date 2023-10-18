namespace BaseModule.SceneEx
{
    partial class SceneExControl
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
            this.grbScene = new System.Windows.Forms.Panel();
            this.sceneControl = new Scene.SceneControl();
            this.grbScene.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbScene
            // 
            this.grbScene.BackColor = System.Drawing.Color.Silver;
            this.grbScene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbScene.Controls.Add(this.sceneControl);
            this.grbScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbScene.Location = new System.Drawing.Point(0, 0);
            this.grbScene.Name = "grbScene";
            this.grbScene.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.grbScene.Size = new System.Drawing.Size(545, 394);
            this.grbScene.TabIndex = 1;
            this.grbScene.Paint += new System.Windows.Forms.PaintEventHandler(this.grbScene_Paint);
            this.grbScene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbScene_MouseClick);
            this.grbScene.Resize += new System.EventHandler(this.grbScene_Resize);
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sceneControl.BackGroundColor = System.Drawing.Color.White;
            this.sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sceneControl.IsBlending = true;
            this.sceneControl.IsLighting = true;
            this.sceneControl.LightAttenuation = 0F;
            this.sceneControl.LightTranslateX = 0F;
            this.sceneControl.LightTranslateY = 0F;
            this.sceneControl.LightTranslateZ = 0F;
            this.sceneControl.Location = new System.Drawing.Point(0, 15);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.RotationAngle = 2.5F;
            this.sceneControl.RotationAxis = SceneInterface.ViewAxis.XYZ;
            this.sceneControl.SelectionColor = System.Drawing.Color.LawnGreen;
            this.sceneControl.Size = new System.Drawing.Size(543, 377);
            this.sceneControl.TabIndex = 4;
            this.sceneControl.TitleColor = System.Drawing.Color.Black;
            this.sceneControl.TitleText = "";
            this.sceneControl.InfoObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_InfoObjectsEvent);
            this.sceneControl.SelectObjectsEvent += new System.Action<object, Scene.Events.SelectObjectsEventArgs>(this.sceneControl_SelectObjectsEvent);
            this.sceneControl.SetBackColorEvent += new System.Action<object, System.EventArgs>(this.sceneControl_SetBackColorEvent);
            this.sceneControl.ShowAllHiddenObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_ShowAllHiddenObjectsEvent);
            this.sceneControl.HideSelectedObjectsEvent += new System.Action<object, System.EventArgs>(this.sceneControl_HideSelectedObjectsEvent);
            this.sceneControl.CreateMeshGroupEvent += new System.Action<object, System.EventArgs>(this.sceneControl_CreateMeshGroupEvent);
            this.sceneControl.DeleteSelectionEvent += new System.Action<object, System.EventArgs>(this.sceneControl_DeleteSelectionEvent);
            this.sceneControl.MessageEvent += new System.Action<object, Scene.Events.MessageEventArgs>(this.sceneControl_MessageEvent);
            // 
            // SceneExControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbScene);
            this.Name = "SceneExControl";
            this.Size = new System.Drawing.Size(545, 394);
            this.grbScene.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grbScene;
        private Scene.SceneControl sceneControl;
    }
}
