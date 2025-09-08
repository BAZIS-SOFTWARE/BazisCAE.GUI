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
                        var scrPoints = new HashSet<Point2D>();//[coords.Count()];
                        //var scnPoints = new List<Point3D>();//[coords.Count()];

                        //scnPoints.Add(scnPoint);
                        //scrPoints.Add(scrPoint);

                        foreach (var point in coords)
                        {
                            var scnPoint = GetSceenCoord(point);
                            var scrPoint = GetScreenCoord(scnPoint);

            
                            //scnPoints.Add(scnPoint);
                            scrPoints.Add(scrPoint);             
                        }

                        // тест выделения рамкой
                        bool selectionFlag;
                        if (scrPoints.Count == 1)
                            selectionFlag = selectionBox.IsPointInside(scrPoints.First());
                        else if (scrPoints.Count == 2)
                        {
                            //select by line
                            selectionFlag = scrPoints.Any(x => selectionBox.IsPointInside(x));
                        }
                        else
                        {
                            // TO DO Пробовать разные варианты использования выпуклой оболочки
                            // пока результаты неудовлетворительные

                            var creator = new Hull2DCreator(scrPoints);
                            var hull = creator.GetHullGraham();
                            var poligon = new Geometry.Polygon(hull.ToList());

                            selectionFlag = poligon.IsSelectedByRectangle(selectionBox);

                            //if (!checker.CheckAllPointsOnLine(list))
                            //{
                            //    var poligon = new Geometry.Polygon(list);
                            //    selectionFlag = poligon.IsSelectedByRectangle(selectionBox);
                            //}
                            //else selectionFlag = false;
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
