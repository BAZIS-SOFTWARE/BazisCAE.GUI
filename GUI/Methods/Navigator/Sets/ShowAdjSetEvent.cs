using BaseModule.Extensions;
using BaseModule.Navigator;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowAdjacenciesSetEvent()
        {
            var setName = navigator.SelectedNode.Text.Split()[1];
            var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
            //var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

            if (nodeName == NodeName.Элементы1D |
                nodeName == NodeName.Элементы2D |
                nodeName == NodeName.Элементы3D)
            {
                var dim = 1;
                if (nodeName == NodeName.Элементы2D)
                    dim = 2;
                else if (nodeName == NodeName.Элементы3D)
                    dim = 3;
                var elements = project.GetModelElements(dim, setName);

                foreach (var element in elements)
                {
                    foreach (var node in element.GetVertexes())
                        node.ViewState = true;
                }

                VBOController.DeleteVBObjects(NodeName.Узел.ToString());
                var set = project.GetModelSetInfo(ObjType.Узел, setName);
                var pre = project.CreateModelObjectsPresentor(set);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
                DisplayObjects();
            }
        }
    }
}
