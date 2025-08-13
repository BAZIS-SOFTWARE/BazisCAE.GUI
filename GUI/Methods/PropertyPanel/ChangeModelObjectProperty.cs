using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeModelObjectProperty(PropertyChangedEventArgs obj, NodeName nodeName)
        {
            var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);
            if (nodeName == NodeName.Элемент3D |
                nodeName == NodeName.Элемент2D |
                nodeName == NodeName.Элемент1D |
                nodeName == NodeName.Узел)
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

                // получаем объект
                var mObj = project.GetModelObject(objType, number);

                if (mObj.ObjType == Model.Interfaces.ObjType.Узел)
                {
                    var c = mObj.GetCoordinates().First();

                    if (obj.Header == "Координата X")
                        c._x = float.Parse(obj.NewValue);
                    else if (obj.Header == "Координата Y")
                        c._y = float.Parse(obj.NewValue);
                    else
                        c._z = float.Parse(obj.NewValue);
                    List<ObjType> objTypes = new List<ObjType> { ObjType.Узел, ObjType.Элемент1D, ObjType.Элемент2D, ObjType.Элемент3D };
                    foreach(var type in objTypes)
                    {
                        var presentor = project.CreateModelObjectsPresentor(type);
                        SetVBObjectAttribute(presentor, "координаты");
                    }
                }
                navigator.SelectedNode.Text = mObj.ToString();
                DisplayObjects();
            }
        }
    }
}
