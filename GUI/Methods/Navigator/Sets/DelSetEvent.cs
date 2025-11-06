using BaseModule.Navigator;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelSetEvent(NodeName nodeName, string nodeText)
        {
            try
            {
                

                var setName = nodeText.Split(' ')[1];

                // Пока запретим удалять геометрические сущности
                if (nodeName == NodeName.Объемы |
                    nodeName == NodeName.Поверхности |
                    nodeName == NodeName.Кривые |
                    nodeName == NodeName.Точки)
                    return;

                // Пока закоментируем..позже сделаем с синхронизацие gmsh
                //if (nodeName == NodeName.Объемы | nodeName == NodeName.Поверхности)
                //{
                //    var ar = nodeText.Split(' ');
                //    setName = string.Join(" ", ar, 1, ar.Length - 2);
                //}
 
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

                if (objType == ObjType.Узел)
                {
                    DeleteVBObjects("Элементы");
                    project.ClearModelCollection(objType);
                }

                else
                {
                    project.DeleteModelSet(objType, setName);
                }

                VBOController.DeleteVBObjects(setName);

                

                PresentGroupDataOnTree();
                PresentCondDataOnTree();
                PresentMeshData();
                PresentModelObjectsForSelection();
                if (navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> nodes))
                {
                    nodes.First().Collapse();
                    nodes.First().Expand();
                }              
                    

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message,Color.Red);
            }

        }
    }
}
