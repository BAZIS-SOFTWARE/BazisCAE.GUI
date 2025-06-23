using BaseModule.Navigator;
using BazisGUI.Utilities;
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
        private void navigator_HideAllGroupsEvent()
        {
            ChangeAllGroupsViewEvent?.Invoke(this, false);
        }

        private void navigator_HideAllObjectsEvent()
        {
            ChangeAllObjsViewStateEvent?.Invoke(this, false);
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            ChangeGroupViewEvent?.Invoke(this, obj, true);
        }

        private void navigator_HideGroupEvent(int obj)
        {
            ChangeGroupViewEvent?.Invoke(this, obj, false);
        }

        private void navigator_HideSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewStateEvent?.Invoke(this, objType, setName, false);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            ChangeAllObjsViewStateEvent?.Invoke(this, true);
        }

        private void navigator_ShowSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewStateEvent?.Invoke(this, objType, setName, true);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            InfoGroupEvent?.Invoke(this, obj);
        }

        private void navigator_ShowAllGroupsEvent()
        {
            ChangeAllGroupsViewEvent?.Invoke(this, true);
        }

        private void navigator_ChangeSetViewEventHandler(string objs, ViewRegime viewRegime)
        {

        }
        private void navigator_DelGroupEvent(int grIndex)
        {
            DeleteGroupEvent?.Invoke(this, grIndex);
        }

        private void navigator_DelAllGroupsEvent()
        {
            DeleteAllGroupsEvent?.Invoke(this);
        }

        private void navigator_DelSetEvent(NodeType nodeType, string setName)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
            DeleteSetEvent?.Invoke(this, objType, setName);
        }

        private void navigator_EditGroupEvent(int obj)
        {
            EditGroupEvent?.Invoke(this, obj);
        }
        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            ShowGroupWithNodesEvent?.Invoke(this, obj);
        }
        private void navigator_NavigatorPanelCollapseEvent()
        {
            splitContainer1.Panel1Collapsed = true;
        }
        private void navigator_DelAllObjectsEvent()
        {
            DelAllObjectsEvent?.Invoke(this);
        }
        private void navigator_GetObjectsInfoEvent(NodeType obj, string set)
        {
            GetObjectsInfoEvent?.Invoke(this, obj, set);
        }

        private void navigator_GetSetsInfoEvent(NodeType obj)
        {
            GetSetsInfoEvent?.Invoke(this, obj);
        }

        private void navigator_GetResultInfoEvent(string obj)
        {
            GetResultsInfoEvent?.Invoke(this, obj);
        }

        private void navigator_SelectCondEvent(NodeType arg1, string arg2)
        {
            SelectPhysicalDataEvent?.Invoke(arg2);
        }

        private void navigator_SelectGeneralInfoEvent(NodeType arg1, string arg2)
        {
            // TO DO
        }

        private void navigator_SelectGroupEvent(NodeType arg1, string arg2)
        {
            var grName = arg2.Split(' ')[0];
            SelectGroupEvent?.Invoke(this, grName);
        }

        private void navigator_SelectObjectEvent(NodeType arg1, string arg2)
        {
            // TO DO
        }

        private void navigator_SelectSetEvent(NodeType arg1, string arg2)
        {
            var setName = arg2.Split(' ')[0]; // Деление по пробелу перед :

            var type = Converters.ConvertNavigatorNodeTypeToObjType(arg1);
            SelectSetEvent?.Invoke(this, type, setName);
        }

        private void navigator_SelectTaskEvent(NodeType arg1, string arg2)
        {
            // TO DO
        }

        private void navigator_SelectTimeEvent(string arg1, double arg2)
        {
            // TO DO
        }
    }
}
