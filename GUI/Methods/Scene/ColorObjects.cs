using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using BazisGUI.Utilities;
using Model.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        internal void ColorObjects(string objTypeStr)
        {
            if (objTypeStr == "Объекты")
            {
                foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    SetVBObjectAttribute(project.CreateModelObjectsPresentor(type), "цвет");
            }
            else if (objTypeStr == "Элементы")
            {
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент1D), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент2D), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент3D), "цвет");
            }
            else if (objTypeStr == "Фигуры")
            {
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Поверхность), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Объем), "цвет");
            }
            else
            {
                var objType = Converters.ConvertToObjsType(objTypeStr);
                var presentor = project.CreateModelObjectsPresentor(objType);
                SetVBObjectAttribute(presentor, "цвет");
            }


            DisplayObjects();
        }
    }
}
