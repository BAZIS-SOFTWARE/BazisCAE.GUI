using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using BaseModule.Extensions;

namespace BazisGUI
{
    public partial class BaseForm
    {
        
        public void CreateVBObjects(IModelData modelData, string objects)
        {
            if (objects == "Объекты")
            {
                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                {
                    if(modelData.ObjectData.GetObjects(item).Count() > 0)
                    {
                        var presentor = CreateModelObjectsPresentor(modelData, item);
                        var vbo = CreateVBObject(presentor);
                        VBOController.AddVbo(vbo);
                    }
                }
            }
            else if (objects == "Элементы")
            {
                var presentor1d = CreateModelObjectsPresentor(modelData, ObjType.Элемент1D);                 
                var vb1d = CreateVBObject(presentor1d);
                VBOController.AddVbo(vb1d);
                var presentor2d = CreateModelObjectsPresentor(modelData, ObjType.Элемент2D);
                var vb2d = CreateVBObject(presentor2d);
                VBOController.AddVbo(vb2d);
                var presentor3d = CreateModelObjectsPresentor(modelData, ObjType.Элемент3D);
                var vb3d = CreateVBObject(presentor3d);
                VBOController.AddVbo(vb3d);
            }
            else
            {
                var objType = objects.ToEnum<ObjType>();
                var pre = CreateModelObjectsPresentor(modelData, objType);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }
        }
    }
}
