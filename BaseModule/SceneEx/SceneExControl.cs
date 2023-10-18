using Scene;
using Scene.Events;
using SceneInterface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.SceneEx
{
    public partial class SceneExControl : UserControl
    {
        public Action CreateMeshGroupEvent;
        public Action DeleteSelectionEvent;
        public Action HideSelectedObjectsEvent;
        public Action InfoObjectsEvent;
        public Action<object, MessageEventArgs> MessageEvent;
        public Action<object, SelectObjectsEventArgs> SelectObjectsEvent;
        public Action SetBackColorEvent;
        public Action ShowAllHiddenObjectsEvent;
        public Action ScenePanelExpandEvent;
        public Action ScenePanelUnwrapEvent;

        public SceneExControl()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(grbScene, true, null);
        }

        public SceneControl SceneControl
        {
            get
            {
                return sceneControl;
            }
        }

        public bool IsSceneExpand { get; private set; }

        private void grbScene_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Сцена", Font, new SolidBrush(System.Drawing.Color.Black), 16, 0);
            
            if(!IsSceneExpand)
            {
                var locRect = new Point(grbScene.Width - 16, 3);
                PaintRectangle(locRect, false,e);
            }

            else
            {
                var locRect1 = new Point(grbScene.Width - 16, 2);
                PaintRectangle(locRect1, false, e);
                var locRect0 = new Point(grbScene.Width - 19, 5);
                PaintRectangle(locRect0, false,e);

            }
        }

        private void PaintRectangle(Point location, bool isFilled, PaintEventArgs e)
        {
            var rect = new Rectangle(location, new Size(8, 8));
            var blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);

            e.Graphics.DrawRectangle(blackPen, rect);

            if (isFilled)
                e.Graphics.FillRectangle(Brushes.Silver,rect);


        }

        private void sceneControl_CreateMeshGroupEvent(object arg1, EventArgs arg2)
        {
            CreateMeshGroupEvent?.Invoke();
        }

        private void sceneControl_DeleteSelectionEvent(object arg1, EventArgs arg2)
        {
            DeleteSelectionEvent?.Invoke();
        }

        private void sceneControl_HideSelectedObjectsEvent(object arg1, EventArgs arg2)
        {
            HideSelectedObjectsEvent?.Invoke();
        }

        private void sceneControl_InfoObjectsEvent(object arg1, EventArgs arg2)
        {
            InfoObjectsEvent?.Invoke();
        }

        private void sceneControl_MessageEvent(object arg1, MessageEventArgs arg2)
        {
            MessageEvent?.Invoke(this, arg2);
        }

        private void sceneControl_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2);
        }

        private void sceneControl_SetBackColorEvent(object arg1, EventArgs arg2)
        {
            SetBackColorEvent?.Invoke();
        }

        private void sceneControl_ShowAllHiddenObjectsEvent(object arg1, EventArgs arg2)
        {
            ShowAllHiddenObjectsEvent?.Invoke();
        }

        private void grbScene_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > grbScene.Width - 16 & e.Location.X < grbScene.Width - 8 && e.Location.Y <= 10)
                if(!IsSceneExpand)
                {
                    ScenePanelExpandEvent?.Invoke();
                    IsSceneExpand = true;
                } 
            else
                {
                    ScenePanelUnwrapEvent?.Invoke();
                    IsSceneExpand = false;
                }

        }

        private void grbScene_Resize(object sender, EventArgs e)
        {
            grbScene.Invalidate();
        }
    }
}
