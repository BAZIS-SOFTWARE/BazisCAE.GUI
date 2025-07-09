using BazisGUI.Scene.VBO;
using System;
using System.Linq;
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
                        var presentor = project.CreateModelObjectsPresentor(item, settingsConfig.IsInsideObjectsShown);
                        var vbo = CreateVBObject(presentor);
                        VBOController.AddVbo(vbo);
                    }
                }
            }
            else if (objects == "Элементы")
            {
                var presentor1d = project.CreateModelObjectsPresentor(ObjType.Элемент1D, settingsConfig.IsInsideObjectsShown);                 
                var vb1d = CreateVBObject(presentor1d);
                VBOController.AddVbo(vb1d);
                var presentor2d = project.CreateModelObjectsPresentor(ObjType.Элемент2D, settingsConfig.IsInsideObjectsShown);
                var vb2d = CreateVBObject(presentor2d);
                VBOController.AddVbo(vb2d);
                var presentor3d = project.CreateModelObjectsPresentor(ObjType.Элемент3D, settingsConfig.IsInsideObjectsShown);
                var vb3d = CreateVBObject(presentor3d);
                VBOController.AddVbo(vb3d);
            }
            else
            {
                var objType = objects.ToEnum<ObjType>();
                var pre = project.CreateModelObjectsPresentor(objType, settingsConfig.IsInsideObjectsShown);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }
        }
    }
}
