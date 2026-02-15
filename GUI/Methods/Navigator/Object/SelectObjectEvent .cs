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
        private void navigator_SelectObjectEvent(string objInfo, int number)
        {
            try
            {
                ObjType objType;
                if (objInfo.TryToEnum(out objType))
                {
                    var setIndo = project.GetModelSetInfo(objType, number);

                    var setsInfo = project.GetModelSetsInfo(objType);
                    foreach (var set in setsInfo)
                        set.SetBackColor();

                    var pres = project.CreateModelObjectsPresentor(setIndo);
                    SetVBObjectAttribute(pres, "цвет");

                    var obj = project.GetModelObject(objType, number);
                    obj.Color = settingsConfig.SelectObjectColor;

                    ApplyDim(objType);
                    
                    foreach (var set in setsInfo)
                    {
                        var setPres = project.CreateModelObjectsPresentor(set);
                        SetVBObjectAttribute(setPres, "цвет");
                    }
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

                    ApplyDim(ObjType.Поверхность);

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

        private void ApplyDim(ObjType objType)
        {
            var modelObjs = project.GetModelObjects(objType).Where(obj => obj.Color != settingsConfig.SelectObjectColor);

            foreach (var item in modelObjs)
                item.Color = ApplyBrightness(item.Color, 0.6f, 0.85f);
        }

        private Color ApplyBrightness(Color color, float dimFactor, float desaturateFactor)
        {
            // затемнение
            float r = color.R * dimFactor;
            float g = color.G * dimFactor;
            float b = color.B * dimFactor;

            // лёгкая десатурация (смешивание с серым)
            float gray = (r + g + b) * 0.33333334f;

            r += (gray - r) * desaturateFactor;
            g += (gray - g) * desaturateFactor;
            b += (gray - b) * desaturateFactor;

            int Clamp(float v) => Math.Max(0, Math.Min(255, (int)v));

            return Color.FromArgb(
                color.A,
                Clamp(r),
                Clamp(g),
                Clamp(b));
        }

        private void CreateVolProperties(int number)
        {
            try
            {
                var rows = new List<RowProperty>();

                rows.Add(new RowProperty("Объект", "Объем", true));

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
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty("Объект", objType, true));

            if (objType == ObjType.Точка) 
            {
                rows.AddRange(GetPointProperty(number));
            }
            else if (objType == ObjType.Узел)
            {
                var node = (Node)project.GetModelObject(ObjType.Узел, number);
                rows.AddRange(GetNodeProperty(node));
            }
            else if (objType == ObjType.Элемент1D | objType == ObjType.Элемент2D | objType == ObjType.Элемент3D)
            {
                var element = project.GetAllModelElements().First(x => x.Number == number);
                rows.AddRange(GetElementProperty(element));
            }
            else if (objType == ObjType.Кривая) 
            {
                rows.AddRange(GetCurveProperties(number));
            }
            else if (objType == ObjType.Поверхность)
            {
                rows.AddRange(GetSurfaceProperties(number));
            }

            //rows.Add(new RowProperty("Связанные объекты", new ButtonPropertyValue("Показать", 
            //    new Action(() => { ShowAdjacencies(objType, number);}))));
            propertiesPanel.DrawTable(rows);
        }
    }
}
