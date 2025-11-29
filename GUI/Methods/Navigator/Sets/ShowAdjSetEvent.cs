using BazisGUI.Extensions;
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
        private void ShowAdjacenciesSet(ObjType objType, string setName)
        {

            if (objType == ObjType.Элемент1D |
            objType == ObjType.Элемент2D |
            objType == ObjType.Элемент3D)
            {
                var dim = 1;
                if (objType == ObjType.Элемент2D)
                    dim = 2;
                else if (objType == ObjType.Элемент3D)
                    dim = 3;
                var elements = project.GetModelElements(dim, setName);

                foreach (var element in elements)
                {
                    foreach (var node in element.GetVertexes())
                        node.ViewState = true;
                }

                VBOController.DeleteVBObjects(ObjType.Узел.ToString());
                var set = project.GetModelSetInfo(ObjType.Узел, setName);
                var pre = project.CreateModelObjectsPresentor(set);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
                DisplayObjects();
            }                    
        }
    }
}
