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

                project.DeleteModelSet(objType, setName);

                PresentGroupDataOnTree();
                PresentCondDataOnTree();
                PresentMeshData();

                if (navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> nodes))
                {
                    nodes.First().Collapse();
                    nodes.First().Expand();
                }              

                //var set = project.GetModelSetInfo(objType, setName);
                VBOController.DeleteVBObjects(setName);

                if (objType == ObjType.Узел)
                    DeleteVBObjects("Элементы");

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message,Color.Red);
            }

        }
    }
}
