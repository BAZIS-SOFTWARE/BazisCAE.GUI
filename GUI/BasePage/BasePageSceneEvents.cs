using Scene.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BasePage
    {
        private void scenePage_SceneInfoEvent(object arg1, string arg2, Color arg3)
        {
            consoleControl.PrintInfo(arg2, arg3);
        }

        private void scenePage_ShowAllObjectsEvent(object obj)
        {
            ChangeAllObjsViewStateEvent?.Invoke(this, true);
        }

        private void scenePage_SelectionDeletedEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke(this);
        }

        public virtual void scenePage_CreateMeshGroupEvent(object sender)
        {
            CreatedMeshGroupEvent?.Invoke(this);
        }
        private void scenePage_SetBackColorToAllObjectsEvent(object obj)
        {
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }

        private void scenePage_HideSelectedObjects(object obj)
        {
            HideSelectedObjectsEvent?.Invoke(this);
        }

        private void scenePage_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2);
        }

        private void scenePage_SceneExpandEvent()
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel2Collapsed = true;
        }

        private void scenePage_SceneFoldEvent()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer2.Panel2Collapsed = false;
        }
    }
}
