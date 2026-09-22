using BazisGUI.Extensions;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;
using System;
using System.Linq;

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

                var numbers = elements.SelectMany(x => x.GetVertexes()).Select(x => x.Number);
                project.ModelView.SetVisible(ObjType.Узел, numbers, true);
            }                    
        }
    }
}
