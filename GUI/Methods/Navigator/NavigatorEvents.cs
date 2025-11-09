using BaseModule.Extensions;
using BazisGUI.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Scene.VBO;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Utilities;
using PreProc;
using PreProc.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        
        private void navigator_RemoveAllConditionsEvent()
        {
            try
            {
                project.TaskData?.Clear();
                navigator.SelectedNode.Nodes.Clear();
                PresentCondDataOnTree();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        public void navigator_RemoveConditionEvent(int index)
        {
            project.TaskData.RemoveAt(index);
        }

        private void navigator_RemoveResultsEvent()
        {
            try
            {
                navigator.TrySearchNodes(NodeName.результаты, out List<TreeNode> nodes);
                //nodes[0].Nodes["ПоУзлам"].Nodes.Clear();
                //nodes[0].Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();
                nodes[0].Remove();

                ClearAllDataOnScene();

                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                    CreateVBObject(project.CreateModelObjectsPresentor(item));

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
        private void navigator_HideResultsEvent()
        {
            try
            {
                ClearAllDataOnScene();

                CreateVBObjects("Объекты");

                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }    



        private List<string> GetLoadGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }

        private List<string> GetBoundaryGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент1D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
        }

        private List<string> GetMaterialGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }      

        public void navigator_HideConditionsEvent(object arg1, IModelData modelData, HideDataEventArgs arg2)
        {
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                modelData.ObjectData.SetBackColor(type);
                var pres = project.CreateModelObjectsPresentor(type);
                SetVBObjectAttribute(pres, "цвет");
            }
            DisplayObjects();
        }     

        private void navigator_ControlCollapseEvent()
        {

        }

        private void navigator_ControlUnpinnedEvent()
        {

        }

        private void navigator_NavigatorPanelCollapseEvent()
        {
            splitContainer1.Panel1Collapsed = true;
        }

          
        private void navigator_GetObjectsInfoEvent(TreeNode node)
        {
            //TODO тут преобразование текста узла в тип объекта

            ObjType objType;

            var objInfo = node.Text.Split(' ')[0];
            // пока заглушим обработку объема
            if (!objInfo.TryToEnum(out objType))
            {
                foreach (var item in project.GetModelVolumes())
                {
                    //var text = $"{item.Number} {item.Name} {item.NumberOfSides}";
                    var r_node = navigator.CreateRealNode(NodeName.объект, item.ToString());

                    //navigator.SetContextMenu(r_node);

                    node.Nodes.Add(r_node);
                }
            }
            else
            {
                var setName = node.Text.Split(' ')[1];
                if (objType == ObjType.Поверхность)
                {
                    var ar = node.Text.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }

                var setInfo = project.GetModelSetInfo(objType, setName);
                var childs = navigator.CreateRealNodes(NodeName.объект, setInfo.GetObjectsInfo());

                // Кажется что это костыль, но без него происходит
                // вывод текста узлов в верхний левый угол вякий раз, когда добавляются
                // ноыве узлы. Поэтому DrawNodeFrozen пока использовать обязательно
                navigator.DrawNodeFrozen = true;
                navigator.BeginUpdate();

                node.Nodes.AddRange(childs);
                
                navigator.EndUpdate();
                navigator.DrawNodeFrozen = false;
            }

 
        }

        private void navigator_GetSetsInfoEvent(TreeNode node)
        {
            var nodeType = node.Name.ToEnum<NodeName>();
            //var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeType);

            //var sets = project.GetModelSetsInfo(objType);

            List<ObjType> objTypes;
            if (nodeType == NodeName.сетка)
                objTypes = new List<ObjType>()
                {
                    ObjType.Узел,
                    ObjType.Элемент1D,
                    ObjType.Элемент2D,
                    ObjType.Элемент3D
                };
            else
            {
                objTypes = new List<ObjType>()
                {
                    ObjType.Точка,
                    ObjType.Кривая,
                    ObjType.Поверхность
                };
            }
            foreach (var item in objTypes)
                foreach (var set in project.GetModelSetsInfo(item))
                {
                    //var nodeName = Converters.ConvertToNavigatorNodeType(set.ObjType);
                    var text = $"{set.ObjType} {set.Name} {set.NumberOfObjects}";
                    var r_node = navigator.CreateRealNode(NodeName.набор, text);
                    var v_node = navigator.CreateVirtualNode();
                    r_node.Nodes.Add(v_node);
                    node.Nodes.Add(r_node);
                    //navigator.SetContextMenu(r_node);
                }
            // загрузка объемов
            if (nodeType == NodeName.геометрия)
            {
                var text = $"Объемы Объем {project.GetModelVolumes().Count()}";
                var r_node = navigator.CreateRealNode(NodeName.набор, text);

                var v_node = navigator.CreateVirtualNode();
                r_node.Nodes.Add(v_node);
                node.Nodes.Add(r_node);
                //navigator.SetContextMenu(r_node);
            }
                //foreach (var item in project.GetModelVolumes())
                //{
                //    var r_node = navigator.CreateRealNode(NodeName.Объем, $"{NodeName.Объем} {item.Name} {item.NumberOfSides}");
                //    r_node.ImageIndex = 14;
                //    r_node.SelectedImageIndex = 14;
                //    node.Nodes.Add(r_node);
                //}
        }

        private void navigator_GetResultInfoEvent(TreeNode node)
        {
            var times = resultTimes.Select(x => x.ToString());

            var childs = navigator.CreateRealNodes(NodeName.время, times);
            node.Nodes.AddRange(childs);
        }
    }
}
