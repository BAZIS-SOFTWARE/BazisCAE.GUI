using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
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
        enum ObjectPropertyKey { Type }
        private void navigator_SelectObjectEvent(string objInfo, int number)
        {
            try
            {
                ObjType objType;
                // пока заглушим обработку объема
                if (objInfo.TryToEnum(out objType))
                {
                    var setIndo = project.GetModelSetInfo(objType, number);
                    setIndo.SetBackColor();

                    var pres = project.CreateModelObjectsPresentor(setIndo);
                    SetVBObjectAttribute(pres, "цвет");

                    var obj = project.GetModelObject(objType, number);
                    obj.Color = settingsConfig.SelectObjectColor;

                    //pres = CreateObjectsPresentor(project.ModelData, group.ObjType);
                    SetVBObjectAttribute(pres, "цвет");
                    DisplayObjects();

                    CreateObjectProperties(objType, number);
                }
                else
                {
                    var set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                    set.SetBackColor();
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                    
                    var vol = project.GetModelVolumes().First(x => x.Number == number);

                    foreach (var item in vol.GetSurfaceFigures())
                        item.Color = settingsConfig.SelectObjectColor;

                    SetVBObjectAttribute(pres, "цвет");
                    DisplayObjects();

                    CreateVolProperties(number);
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void CreateVolProperties(int number)
        {
            try
            {
                var rows = new List<RowProperty>();

                rows.Add(new RowProperty(ObjectPropertyKey.Type.ToString(), "Объект", "Объем", true));

                rows.AddRange(GetVolProperties(number));

                //rows.Add(new RowProperty("Поверхности", new ButtonPropertyValue("Показать",
                //    new Action(() =>
                //    {
                //        ShowAdg(3, number, 1);
                //        var set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                //        PresentSet(set);
                //        DisplayObjects();

                //    })), true));

                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
 
        }

        private void CreateObjectProperties(ObjType objType, int number)
        {
            var rows = new List<RowProperty> { new RowProperty(ObjectPropertyKey.Type.ToString(), "Объект", objType, true) };

            switch (objType)
            {
                case ObjType.Точка:
                    rows.AddRange(GetPointProperty(number));
                    break;

                case ObjType.Узел:
                    var node = (Node)project.GetModelObject(ObjType.Узел, number);
                    rows.AddRange(GetNodeProperty(node));
                    break;

                case ObjType.Кривая:
                    rows.AddRange(GetCurveProperties(number));
                    break;

                case ObjType.Элемент1D | ObjType.Элемент2D | ObjType.Элемент3D:
                    var element = project.GetAllModelElements().First(x => x.Number == number);
                    rows.AddRange(GetElementProperty(element));
                    break;

                case ObjType.Поверхность:
                    rows.AddRange(GetSurfaceProperties(number));
                    break;
            }

            propertiesPanel.DrawTable(rows);
        }
    }
}
