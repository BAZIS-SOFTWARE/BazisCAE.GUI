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
using BaseModule.Extensions;
using Model.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void DeleteVBObjects(string objects)
        {
            if (objects == "Объекты")
            {
                VBOController.DeleteAllVBObjects();
            }
            else if (objects == "Элементы")
            {
                VBOController.DeleteVBObjects(ObjType.Элемент1D.ToString());
                VBOController.DeleteVBObjects(ObjType.Элемент2D.ToString());
                VBOController.DeleteVBObjects(ObjType.Элемент3D.ToString());
            }
            else if (objects == "Фигуры")
            {
                VBOController.DeleteVBObjects(ObjType.Кривая.ToString());
            }
            else
                VBOController.DeleteVBObjects(objects);
        }
        public void DeleteVBObjects(ObjType objType)
        {
            if (objType == ObjType.Узел)
            {
                VBOController.DeleteVBObjects(ObjType.Узел.ToString());
                VBOController.DeleteVBObjects(ObjType.Элемент1D.ToString());
                VBOController.DeleteVBObjects(ObjType.Элемент2D.ToString());
                VBOController.DeleteVBObjects(ObjType.Элемент3D.ToString());
            }
            else if (objType == ObjType.Точка)
            {
                VBOController.DeleteVBObjects(ObjType.Точка.ToString());
                VBOController.DeleteVBObjects(ObjType.Кривая.ToString());
            }

            else
                VBOController.DeleteVBObjects(objType.ToString());
        }
    }
}
