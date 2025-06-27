using BaseModule;
using BaseModule.Console;
using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.SceenControls;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using Scene.Events;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public partial class ToolStripPage : UserControl
    {
        public event Action<object,string,string> ChangedGroupNameEvent;
        public event Action<object,string> CreatedMeshGroupEvent;
        public event Action<object> DeleteAllGroupsEvent;
        public event Action<object,int> DeleteGroupEvent;
        public event Action<object, ObjType, string> DeleteObjectsEvent;
        public event Action<object, SelectObjectsEventArgs, string> SelectObjectsEvent;
        public event Action<object,bool> ChangeAllGroupsViewEvent;
        public event Action<object, bool> ChangeAllObjsViewEvent;
        public event Action<object> ShowInsideObjectsEvent;
        public event Action<object> HideInsideObjectsEvent;
        public event Action<object, ViewMode> ChangeViewModeObjectsEvent;
        public event Action<object, CreatePlaneFromTextArgs> CreateSectionSurfacesFromCoordsEvent;
        public event Action<object> CreateSectionSurfacesFromNodesEvent;
        public event Action<object, string> DistancePointToPointEvent;
        public event Action<object, string> DistancePointToPlaneEvent;
        public event Action<object> CreatePathAsyncEvent;
        public event Action<object, string> CalcSquareEvent;
        public event Action<object, string> CalcVolumeEvent;
        public event Action<object> SelectNodeInPlaneEvent;
        public event Action<object> MakeScreenShotEvent;
        public event Action<object> ShowMeshCountorsEvent;
        public event Action<object> ShowMeshNormalsEvent;
        public event Action<object, float> SelectE2DInPlaneEvent;
        public event Action<object, ObjType, float,bool> SelectInDirectionEvent;
        
        public event Action<object, int, bool> ChangeGroupViewEvent;
        public event Action<object, ObjType, string, bool> ChangeSetViewStateEvent;
        public event Action<object, int> EditGroupEvent;
        public event Action<object,string> DeleteSelectedObjectsEvent;
        public event Action<object, string> SelectGroupEvent;
        public event Action<object> SetBackColorToAllObjectsEvent;
        public event Action<object,string> HideSelectedObjectsEvent;
        public event Action<object, int> InfoGroupEvent;
        public event Action<object, int> ShowGroupWithNodesEvent;
        public event Action<object> DelAllObjectsEvent;
        public event Action<object, ObjType, string> SelectSetEvent;
        public event Action<object> UpdateNavigatorEvent;
        public event Action<object, NodeType, string> GetObjectsInfoEvent;
        public event Action<object, NodeType> GetSetsInfoEvent;
        public event Action<object, string> GetResultsInfoEvent;
        //public event Action<object, TreeNode> SelectPhysicalDataEvent;

        [Category("General")]
        [Description("Ширина разделителей")]
        public int SplitterWidthEx { get; set; } = 5;

        [Category("General")]
        [Description("Кнопка на клавиатуре")]
        public Keys PressedKey { get; set; }

        [Category("General")]
        [Description("NavigatorControl")]
        public NavigatorControl NavigatorControl
        {
            get
            {
                return navigator;
            }
        }
        [Category("General")]
        [Description("ScenePage")]
        public ScenePage ScenePage
        {
            get
            {
                return scenePage;
            }
        }
        [Category("General")]
        [Description("ConsoleControl")]
        public ConsoleControl ConsoleControl
        {
            get
            {
                return consoleControl;
            }
        }

        SplittersController SplittersController;

        public string SelectedObjects
        {
            get { return spbSelectObject.ToolTipText; }
            set { spbSelectObject.ToolTipText = value; }
        }

        public SplitContainerEx EmbeddedSplitContainer
        {
            get
            {
                return embeddedSplitContainer;
            }
        }

        public ControlCollection EmbeddedControls
        {
            get
            {
                return embeddedSplitContainer.Panel2.Controls;
            }
        }

        PropertyPanelProvider panelProvider;

        public PropertyPanelProvider PanelProvider { get { return panelProvider; } }
        public IModelController ModelController { get; set; } = new ModelController.ModelController();


        public ToolStripPage()
        {
            InitializeComponent();
            //selectToolStrip.Location = new Point(3, 0);
            SplitterWidthEx = 8;

            navigator.TrySearchNodes(NodeType.условия, out List<TreeNode> conds);
            conds[0].ContextMenuStrip = condsMenuStrip;

            navigator.TrySearchNodes(NodeType.задачи, out List<TreeNode> tasks);
            tasks[0].ContextMenuStrip = tasksMenuStrip;

            //SelectPhysicalDataEvent += basePage_SelectPhysicalData;

            navigator.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
            nodes[0].ContextMenuStrip = resultsMenuStrip;   

            selectToolStrip.Location = new Point(3, 0);
            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);

            //scale = scenePage.SceneControl.CreateScaleObject(0, 1, 2, "", "");

            panelProvider.Out += propertiesPanelControl.DrawTable;
            propertiesPanelControl.ValidateValue += panelProvider.ValidationData;
            //propertiesPanelControl1.OnPropertyUpdate += PropertiesPanelControl1_OnPropertyUpdate; 
            SplittersController = new SplittersController();

            //panelProvider.OnUpdateNavigator += PanelProvider_OnUpdateNavigator; ;
        }
        private void basePage_SelectPhysicalData(string arg1)
        {
            //SelectConditionEvent?.Invoke(this, arg1);
        }

  

    //    private void basePage_ChangedGroupNameEvent(object sender,string ar1,string ar2)
    //    {
    //        ChangedGroupNameEvent?.Invoke(this,ar1,ar2);
    //    }

    //    private void basePage_CreatedMeshGroupEvent(object sender)
    //    {
    //        if (spbSelectObject.ToolTipText == "Объекты" |
    //spbSelectObject.ToolTipText == "Фигуры" |
    //spbSelectObject.ToolTipText == "Элементы")
    //        {

    //            consoleControl.PrintInfo($"Нельзя создать группу {spbSelectObject.ToolTipText}", Color.Orange);
    //        }
    //        else
    //        {
    //            CreatedMeshGroupEvent?.Invoke(this, spbSelectObject.ToolTipText);
    //        }

    //    }
        

        private void basePage_DeleteObjectsEvent(object arg1, ObjType arg2, string arg3)
        {
            DeleteObjectsEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_ChangeAllGroupsViewEvent(object arg1,bool arg2)
        {
            ChangeAllGroupsViewEvent?.Invoke(this, arg2);
        }

        private void basePage_DeleteAllGroupsEvent(object obj)
        {
            DeleteAllGroupsEvent?.Invoke(this);
        }

        private void basePage_DeleteGroupEvent(object arg1, int arg2)
        {
            DeleteGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2, spbSelectObject.ToolTipText);
        }

        private void basePage_FindFreeNodesEvent(object obj)
        {
            //FindFreeNodesEvent?.Invoke(this);
        }

        private void basePage_ChangeGroupViewEvent(object arg1, int arg2, bool arg3)
        {
            ChangeGroupViewEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_ChangeSetViewStateEvent(object arg1, ObjType arg2, string arg3, bool arg4)
        {
            ChangeSetViewStateEvent?.Invoke(this, arg2, arg3, arg4);
        }

        private void basePage_EditGroupEvent(object arg1, int arg2)
        {
            EditGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SelectGroupEvent(object arg1, string arg2)
        {
            SelectGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SetBackColorToAllObjectsEvent(object obj)
        {
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }

        private void basePage_HideSelectedObjectsEvent(object obj)
        {
            HideSelectedObjectsEvent?.Invoke(this, spbSelectObject.ToolTipText);
        }

        private void basePage_DeleteSelectedObjectsEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke(this, spbSelectObject.ToolTipText);
        }

        private void basePage_InfoGroupEvent(object arg1, int arg2)
        {
            InfoGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_ChangeAllObjsViewStateEvent(object arg1, bool arg2)
        {
            ChangeAllObjsViewEvent?.Invoke(this, arg2);
        }

        private void basePage_ShowGroupWithNodesEvent(object arg1, int arg2)
        {
            ShowGroupWithNodesEvent?.Invoke(this, arg2);
        }

        private void basePage_DelAllObjectsEvent(object obj)
        {
            DelAllObjectsEvent?.Invoke(this);
        }

        private void basePage_SelectSetEvent(object arg1, ObjType arg2, string arg3)
        {
            SelectSetEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_UpdateNavigatorEvent(object obj)
        {
            UpdateNavigatorEvent?.Invoke(this);
        }

        private void basePage_GetObjectsInfoEvent(object arg1, NodeType arg2,string arg3)
        {
            GetObjectsInfoEvent?.Invoke(this, arg2,arg3);
        }

        private void basePage_GetSetsInfoEvent(object arg1, NodeType arg2)
        {
            GetSetsInfoEvent?.Invoke(this, arg2);
        }      





        private void propertiesPanelControl_ControlCollapseEvent()
        {

        }
    }  
}
