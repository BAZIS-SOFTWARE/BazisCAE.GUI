using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectObjectEvent(NodeName nodeName, string setName, int number)
        {
            try
            {
                // пока заглушим обработку объема
                if (nodeName != NodeName.Объем)
                {
                    var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);
                    var setIndo = project.GetModelSetInfo(objType, setName);
                    setIndo.SetBackColor();

                    var pres = project.CreateModelObjectsPresentor(setIndo);
                    SetVBObjectAttribute(pres, "цвет");

                    var obj = project.GetModelObject(objType, number);
                    obj.Color = settingsConfig.SelectGroupColor;

                    //pres = CreateObjectsPresentor(project.ModelData, group.ObjType);
                    SetVBObjectAttribute(pres, "цвет");

                    DisplayObjects();
                }

                CreateObjectProperties(nodeName, number);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void CreateObjectProperties(NodeName nodeName, int number)
        {

            var rows = new List<RowProperty>();
            if (nodeName == NodeName.Точка)
                rows.Add(GetPointProperty(number));

            else if (nodeName == NodeName.Узел)
            {
                var node = (Node)project.GetModelObject(ObjType.Узел, number);
                rows.AddRange(GetNodeProperty(node));
            }


            else if (nodeName == NodeName.Элемент1D |
                nodeName == NodeName.Элемент2D |
                nodeName == NodeName.Элемент3D)
            {
                var element = project.GetModelElements().First(x => x.Number == number);
                rows.AddRange(GetElementProperty(element));
            }


            else if (nodeName == NodeName.Кривая)
                rows.AddRange(GetCurveProperties(number));

            else if (nodeName == NodeName.Объем)
            {
                var vol = project.GetModelVolumes().First(x => x.Number == number);
                rows.AddRange(GetVolProperties(vol));
            }


            propertiesPanel.DrawTable(rows);
        }
    }
}
