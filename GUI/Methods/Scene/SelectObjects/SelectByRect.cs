using BazisGUI.Properties;
using BazisGUI.SettingsControls;
using Geometry;
using Geometry.Exteisions;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void SelectByRect(IEnumerable<ISetInfo> sets, RectangleBox selectionBox, bool isSelected)
        {
            var creator = new Hull2DCreator();
            var counter = 0;
            var numbersSelevtedElement = new List<int>();
            foreach (var set in sets)
            {
                var changeFlag = false;
                foreach (var numb in set.GetNumbers())
                {
                    if (set.GetViewState(numb))
                    {
                        var coords = set.GetCoords(numb);
                        var scrPoints = new HashSet<Point2D>();
  
                        foreach (var point in coords)
                        {
                            var scnPoint = GetSceenCoord(point);
                            var scrPoint = GetScreenCoord(scnPoint);

                            scrPoints.Add(scrPoint);
                        }

                        var selectionFlag = ChechSelection(selectionBox, creator, scrPoints);

                        if (selectionFlag)
                        {
                            counter++;
                            changeFlag = true;
                            if (isSelected)
                            {
                                set.SetColor(settingsConfig.SelectObjectColor, numb);
                                numbersSelevtedElement.Add(numb);
                            }
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
            var objStr = Declination(counter);
            if (isSelected)
            {
                // пока отключим и посмотрим, как будет работать
                // только при одиночном клике

                //if (bool.Parse(btnAdvSelection.Tag.ToString()) && counter != 0)
                //    DispatchSelection(sets.First().ObjType, numbersSelevtedElement, isSelected);
                //else
                    console.PrintInfo($"{Resources.SelectByRect_Selected_Message} {counter} {objStr}", Color.Black);
            }
            else
                console.PrintInfo($"{Resources.SelectByRect_Hidden_Message} {counter} {objStr}", Color.Black);
            DisplayObjects();

        }

        private string Declination(int input)
        {
            string s = Resources.SelectByRect_Declination_Type1;
            if (input % 10 == 1) s = Resources.SelectByRect_Declination_Type2;
            if (input % 10 >= 2 && input % 10 <= 4) s = Resources.SelectByRect_Declination_Type3;
            //if (n % 100 >= 11 & n % 100 <= 20) s = "объектов";

            return s;
        }

        private bool ChechSelection(RectangleBox selectionBox, Hull2DCreator creator, HashSet<Point2D> scrPoints)
        {
            //bool selectionFlag;
            if (scrPoints.Count == 1)
                return selectionBox.IsPointInside(scrPoints.First());
            else if (scrPoints.Count == 2)
            {
                //select by line
                return scrPoints.Any(x => selectionBox.IsPointInside(x));
            }
            else
            {
                // TO DO Пробовать разные варианты оптимизации
                // Тут проверка пересечений прямоугольников
                var polygonBox = new RectangleBox(scrPoints);

                //if (polygonBox.IsIntersectWithOther(selectionBox))
                //    selectionFlag = true;
                if (polygonBox.IsInnerOther(selectionBox))
                    return true;
                // Тут проверка пересечений точек прямоугольника и многоугольника
                else if (polygonBox.IsIntersectWithOther(selectionBox))
                {
                    //дополнительные проверки пересечений по горизонтали
                    if (selectionBox.Left <= polygonBox.Left &&
                        selectionBox.Right >= polygonBox.Right)
                        return true;
                    //дополнительные проверки пересечений по вертикали
                    else if (selectionBox.Bottom <= polygonBox.Bottom &&
                        selectionBox.Top >= polygonBox.Top)
                        return true;

                    else if (creator.TryCreateHullGraham(scrPoints, out Polygon polygon))
                    {
                        var rectanglePoints = selectionBox.GetPoints();

                        if (rectanglePoints.Any(p => polygon.IsPointInsidePolygon(p)))
                            return true;
                        else if (polygon.GetPoints().Any(p => selectionBox.IsPointInside(p)))
                            return true;
                    }
                }
            }

            return false;
        }  
    }
}
