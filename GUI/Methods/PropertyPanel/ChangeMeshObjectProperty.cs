using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeNodeProperty(PropertyChangedEventArgs obj, int number)
        {

            // получаем объект
            var mObj = project.GetModelObject(ObjType.Узел, number);

            var c = mObj.GetCoordinates().First();

            if (obj.Header == "Координата X")
                c._x = float.Parse(obj.NewValue);
            else if (obj.Header == "Координата Y")
                c._y = float.Parse(obj.NewValue);
            else
                c._z = float.Parse(obj.NewValue);
            List<ObjType> objTypes = new List<ObjType> { ObjType.Узел, ObjType.Элемент1D, ObjType.Элемент2D, ObjType.Элемент3D };
            foreach (var type in objTypes)
            {
                var presentor = project.CreateModelObjectsPresentor(type);
                SetVBObjectAttribute(presentor, "координаты");
            }

            navigator.SelectedNode.Text = mObj.ToString();
            DisplayObjects();

        }

        private void ChangeElementProperty(PropertyChangedEventArgs obj, ObjType objType, int number)
        {
            // получаем объект
            var mObj = project.GetModelObject(objType, number);

            var element = mObj as Element;
            element.Level = int.Parse(obj.NewValue);

            navigator.SelectedNode.Text = mObj.ToString();
            DisplayObjects();

        }
    }
}
