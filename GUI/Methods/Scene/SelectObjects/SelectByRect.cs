using BazisGUI.SettingsControls;
using Geometry;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void SelectByRect(IEnumerable<ISetInfo> sets, RectangleBox selectionBox, bool isSelected)
        {
            
            foreach (var set in sets)
            {
                var changeFlag = false;
                // TO DO добавить проверку состояния viewState набора
                foreach (var numb in set.GetNumbers())
                {
                    if (set.GetViewState(numb))
                    {
                        var coords = set.GetCoords(numb);
                        var scrPoints = new List<Point2D>();//[coords.Count()];
                        var scnPoints = new List<Point3D>();//[coords.Count()];

                        //var pointCounter = 0;
                        foreach (var point in coords)
                        {
                            var scnPoint = GetSceenCoord(point);
                            scnPoints.Add(scnPoint);

                            var scrPoint = GetScreenCoord(scnPoint);
                            scrPoints.Add(scrPoint);

                            //pointCounter++;
                        }

                        // тест выделения рамкой
                        bool selectionFlag;
                        if (scrPoints.Count == 1)
                            selectionFlag = selectionBox.IsPointInside(scrPoints[0]);
                        else if (scrPoints.Count == 2)
                        {
                            //select by line
                            selectionFlag = scrPoints.Any(x => selectionBox.IsPointInside(x));
                        }
                        else
                        {
                            var poligon = new Geometry.Polygon(scrPoints);
                            selectionFlag = poligon.IsSelectedByRectangle(selectionBox);
                        }

                        if (selectionFlag)
                        {
                            changeFlag = true;
                            if (isSelected)
                                set.SetColor(settingsConfig.SelectObjectColor, numb);//  page.ScenePage.settingsConfig.SelectObjectColor;
                            else
                                set.SetBackColor(numb);
                        }
                    }
                }

                if(changeFlag)
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    SetVBObjectAttribute(pres, "цвет");
                }
            }
            DisplayObjects();
            //if (isSorted & selections.Count > 0)
            //{
            //    var near = selections.OrderByDescending(x => GetSceenCoord(x.CalcCentr())._z).FirstOrDefault();
            //    selections = new List<IModelObject>() { near };
            //}

            //return changeFlag;
        }
    }
}
