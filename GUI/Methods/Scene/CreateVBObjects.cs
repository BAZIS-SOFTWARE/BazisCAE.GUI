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
                VBOController.DeleteAllVBObjects();

                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                {
                    var presentor = CreateObjectsPresentor(modelData, item);
                    var vbo = CreateVBObject(presentor);
                    VBOController.AddVbo(vbo);
                }
            }
            else if (objects == "Элементы")
            {
                VBOController.DeleteVBObjects(ObjType.Элемент1D.ToString());
                var presentor1d = CreateObjectsPresentor(modelData, ObjType.Элемент1D);
                var vb1d = CreateVBObject(presentor1d);
                VBOController.AddVbo(vb1d);
                VBOController.DeleteVBObjects(ObjType.Элемент2D.ToString());
                var presentor2d = CreateObjectsPresentor(modelData, ObjType.Элемент2D);
                var vb2d = CreateVBObject(presentor2d);
                VBOController.AddVbo(vb2d);
                VBOController.DeleteVBObjects(ObjType.Элемент3D.ToString());
                var presentor3d = CreateObjectsPresentor(modelData, ObjType.Элемент3D);
                var vb3d = CreateVBObject(presentor3d);
                VBOController.AddVbo(vb3d);
            }
            else if (objects == "Фигуры")
            {
                VBOController.DeleteVBObjects(ObjType.Поверхность.ToString());
                var surf = CreateObjectsPresentor(modelData, ObjType.Поверхность);
                var vbs = CreateVBObject(surf);
                VBOController.AddVbo(vbs);
                VBOController.DeleteVBObjects(ObjType.Объем.ToString());
                var vol = CreateObjectsPresentor(modelData, ObjType.Объем);
                var vbv = CreateVBObject(vol);
                VBOController.AddVbo(vbv);
            }
            else
            {
                VBOController.DeleteVBObjects(objects);
                var objType = objects.ToEnum<ObjType>();
                var pre = CreateObjectsPresentor(modelData, objType);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }

            DisplayObjects();
        }
    }
}
