using BazisGUI.Scene.VBO;
using System;
using System.Linq;
using Model.Interfaces;
using BaseModule.Extensions;

namespace BazisGUI
{
    public partial class BaseForm
    {
        
        public void CreateVBObjects(string objects)
        {
            if (objects == "Объекты")
            {
                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                    CreateVBObjsByObjsType(item);
            }
            else if (objects == "Элементы")
            {
                CreateVBObjsByObjsType(ObjType.Элемент1D);
                CreateVBObjsByObjsType(ObjType.Элемент2D);
                CreateVBObjsByObjsType(ObjType.Элемент3D);
            }
            else if (objects == "Геометрия")
            {
                CreateVBObjsByObjsType(ObjType.Кривая);
                CreateVBObjsByObjsType(ObjType.Поверхность);
            }
            else
            {
                var objType = objects.ToEnum<ObjType>();
                CreateVBObjsByObjsType(objType);
            }
        }

        public void CreateVBObjsByObjsType(ObjType objType)
        {
            foreach (var setInfo in project.GetModelSetsInfo(objType))
            {
                if (setInfo.NumberOfObjects > 0 && setInfo.ViewState)
                {
                    var pre = project.CreateModelObjectsPresentor(setInfo);
                    var vbo = CreateVBObject(pre);
                    VBOController.AddVbo(vbo);
                }
            }
        }
    }
}
