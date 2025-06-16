using BazisGUI.Utilities;
using Model.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;
using Scene.Events;
using BaseModule.Console;

namespace BazisGUI
{
    public partial class EmbendentPage : UserControl
    {
        public event Action<object, SelectObjectsEventArgs, ObjType> SelectObjectsEvent;
        public event Action<object,ObjType, string> DeleteObjectsEvent;
        public event Action<object,bool> ShowAllGroupsEvent;
        public event Action<object> DeleteAllGroupsEvent;
        public event Action<object, int> DeleteGroupEvent;
        public event Action<object> FindFreeNodesEvent;
        public event Action<object, int, bool> ShowGroupEvent;

        public BasePage BasePage
        {
            get
            {
                return basePage;
            }
        }

        public SplitContainerEx EmbeddedSplitContainer
        {
            get
            {
                return splitContainerEx;
            }
        }

        public ControlCollection EmbeddedControls
        {
            get
            {
                return splitContainerEx.Panel2.Controls;
            }
        }
        public EmbendentPage()
        {
            InitializeComponent();

            splitContainerEx.Panel2Collapsed = true;
        }

        private void pinnedControl_ControlCollapseEvent()
        {
            splitContainerEx.Panel2Collapsed = true;
        }

        private void basePage_DeleteObjectsEvent(object obj, ObjType objType,string setName)
        {
            DeleteObjectsEvent?.Invoke(obj, objType, setName);
        }

        private void basePage_HideAllGroupsEvent(object obj,bool state)
        {
            ShowAllGroupsEvent?.Invoke(obj,state);
        }

        private void basePage_DeleteAllGroupsEvent(object obj)
        {
            DeleteAllGroupsEvent?.Invoke(obj);
        }

        private void basePage_DeleteGroupEvent(object arg1, int arg2)
        {
            DeleteGroupEvent?.Invoke(arg1, arg2);
        }

        private void basePage_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2, ObjType arg3)
        {
            SelectObjectsEvent?.Invoke(arg1, arg2, arg3);
        }

        private void basePage_FindFreeNodesEvent(object obj)
        {
            FindFreeNodesEvent?.Invoke(this);
        }

        private void basePage_ShowGroupEvent(object arg1, int arg2, bool arg3)
        {
            ShowGroupEvent?.Invoke(this, arg2, arg3);
        }
    }
}
