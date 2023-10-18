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
        public event Action CreateMeshGroupEvent;
        public event Action DeleteSelectionEvent;
        public event Action HideSelectedObjectsEvent;
        public event Action InfoObjectsEvent;
        public event Action<object, MessageEventArgs> MessageEvent;
        public event Action<object, SelectObjectsEventArgs> SelectObjectsEvent;
        public event Action SetBackColorEvent;
        public event Action ShowAllHiddenObjectsEvent;
        public event Action ScenePanelExpandEvent;
        public event Action ScenePanelUnwrapEvent;

        public SceneExControl()
        {
            InitializeComponent();
        }

        public SceneControl SceneControl
        {
            get
            {
                return sceneControl;
            }
        }

        public bool IsSceneExpand { get; private set; }

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
    }
}
