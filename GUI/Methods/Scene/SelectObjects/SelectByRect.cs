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
                        var selectionFlag = ChechSelection(selectionBox, creator, scrPoints);

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

        public IEnumerable<Point2D> GetHullGraham(HashSet<Point2D> points)
        {
            var startPoint = points
                .OrderBy(p => p._y)
                .ThenBy(p => p._x)
                .First();
            var sortedPoints = points
                .Distinct()
                .Where(point => point != startPoint)
                .GroupBy(point => GetPolarAngle(startPoint, point))
                .Select(group =>
                    group.OrderByDescending(point => Vector.GetVectorLength(point.Sub(startPoint)))
                         .First())
                .OrderBy(point => GetPolarAngle(startPoint, point))
                .ToArray();
            var stack = new Stack<Point2D>();
            stack.Push(startPoint);
            stack.Push(sortedPoints[0]);
            stack.Push(sortedPoints[1]);
            for (var i = 2; i < sortedPoints.Length; i++)
            {
                while (new Segment2D(NextToTop(stack), stack.Peek()).GetOrientationSign(sortedPoints[i]) <= 0)
                {
                    stack.Pop();
                }
                stack.Push(sortedPoints[i]);
            }
            return stack.Reverse();
        }

        private Point2D NextToTop(Stack<Point2D> stack)
        {
            var top = stack.Pop();
            var nextToTop = stack.Peek();
            stack.Push(top);
            return nextToTop;
        }

        //Angle between vector i = (1, 0) and vector (localCenter - p)
        private float GetPolarAngle(Point2D localCenter, Point2D p)
        {
            var dotProduct = p._x - localCenter._x;
            var length = Vector.GetVectorLength(p.Sub(localCenter));
            return (float)Math.Acos(dotProduct / length);
        }
    }

    public class Poly
    {
        private readonly List<Point2D> points;

        public Poly(List<Point2D> points)
        {
            //var hullCreator = new Hull2DCreator(points);
            this.points = points;
        }

        //Gauss's area formula (фор-ла шнурования или землемера)
        //Seems legit because the hull creator traverse on points in a defined direction
        public double GetPolygonArea()
        {
            var sum = 0.0;
            var n = points.Count;
            for (var i = 0; i < n - 1; i++)
            {
                sum += (points[i]._x * points[i + 1]._y - points[i + 1]._x * points[i]._y);
            }
            sum += (points[n - 1]._x * points[0]._y - points[0]._x * points[n - 1]._y);
            return 0.5 * Math.Abs(sum);
        }

        public bool IsPointInsidePolygon(Point2D point, float epsilon = 0.01f)
        {
            var sourceArea = GetPolygonArea();
            var integratedArea = 0d;
            foreach (var segment in points.Bigrams(true))
            {
                var a = segment.Item2.Sub(segment.Item1);
                var b = point.Sub(segment.Item1);
                var triangleArea = 0.5 * Math.Abs(a._x * b._y - a._y * b._x);
                integratedArea += triangleArea;
            }
            return Math.Abs(integratedArea - sourceArea) < epsilon;
        }

        public bool IsSelectedByRectangle(RectangleBox rectangle)
        {
            var maxX = (int)points.Select(p => p._x).Max();
            var maxY = (int)points.Select(p => p._y).Max();
            var minX = (int)points.Select(p => p._x).Min();
            var minY = (int)points.Select(p => p._y).Min();
            var figureBox = new RectangleBox(minX, maxX, minY, maxY);
            if (!figureBox.IsIntersectWithOther(rectangle))
                return false;
            if (figureBox.IsInnerOther(rectangle))
                return true;
            var rectanglePoints = rectangle.GetPoints();
            if (rectanglePoints.Any(p => IsPointInsidePolygon(p)))
                return true;
            // Вопрос, насколько нужен этот цикл проверки?
            foreach (var rectangleSegment in rectanglePoints.Bigrams(true).Select(p => new Segment2D(p.Item1, p.Item2)))
            {
                foreach (var contourSegment in points.Bigrams(true).Select(p => new Segment2D(p.Item1, p.Item2)))
                {
                    if (contourSegment.HasIntersectedPoint(rectangleSegment))
                        return true;
                }
            }
            return false;
        }
    }
}
