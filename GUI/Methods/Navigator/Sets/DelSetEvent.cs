using BaseModule.Navigator;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelSetEvent(NodeName nodeName, string nodeText)
        {
            try
            {
                

                var setName = nodeText.Split(' ')[0];
                if (nodeName == NodeName.Объемы | nodeName == NodeName.Поверхности)
                {
                    var ar = nodeText.Split(' ');
                    setName = string.Join(" ", ar, 0, ar.Length - 1);
                }

                // не применимо к одиночным наборам!!!
                if (nodeName == NodeName.Узлы |
                    nodeName == NodeName.Кривые |
                    nodeName == NodeName.Точки)
                    return;
 
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

                project.DeleteModelSet(objType, setName);

                PresentGroupDataOnTree();
                PresentCondDataOnTree();

                var set = project.GetModelSetInfo(objType, setName);
                VBOController.DeleteVBObjects(set.Name);

                if (set.ObjType == ObjType.Узел)
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
