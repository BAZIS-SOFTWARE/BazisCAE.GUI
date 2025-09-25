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
        public bool SelectByPoint(IEnumerable<ISetInfo> sets, Point2D selectionPoint, bool isSelected)
        {
            var selFlag = false;
            var tempNumb = 0;
            ISetInfo tempSetInfo = null;
            var cur_z_depth = 0.0f;

            foreach (var set in sets)
            {
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
                        // Магия выбора
                        // Если объект точка 
                        // TO DO сделать выбор для остальных объектов через
                        // барицентрические координаты


                        if (IsObjectSelected(selectionPoint, scrPoints))
                        {
                            selFlag = true;
                            if (isSelected)
                                set.SetColor(settingsConfig.SelectObjectColor, numb);
                            else
                                set.SetBackColor(numb);

                            bool isObjectCloser;

                            var temp_z_depth = 0.0f;

                            if (scnPoints.Count == 1)
                                temp_z_depth = scnPoints[0]._z;
                            else
                                temp_z_depth = scnPoints.Sum(x => x._z) / scnPoints.Count;

                            if (cur_z_depth == 0)
                                isObjectCloser = true;
                            else
                                isObjectCloser = temp_z_depth > cur_z_depth ? true : false;

                            if (isObjectCloser)
                            {
                                tempSetInfo?.SetBackColor(tempNumb);
                                tempSetInfo = set;
                                tempNumb = numb;
                                cur_z_depth = temp_z_depth;
                            }
                            else
                                set.SetBackColor(numb);
                        }
                    }
                }

            }

            return selFlag;
        }

        private void SwapInfo(ref int tempNumb, ref ISetInfo tempSetInfo, ISetInfo set, int numb)
        {
            tempSetInfo = set;
            tempNumb = numb;
        }

        //private Tuple<Point2D[], Point3D[]> ConvertObjectCoords(IEnumerable<Point3D> coords)
        //{
        //    var scrPoints = new Point2D[coords.Count()];
        //    var scnPoints = new Point3D[coords.Count()];

        //    var pointCounter = 0;
        //    foreach (var point in coords)
        //    {
        //        var scnPoint = GetSceenCoord(point);
        //        scnPoints[pointCounter] = scnPoint;

        //        var scrPoint = GetScreenCoord(scnPoint);
        //        scrPoints[pointCounter] = scrPoint;

        //        pointCounter++;
        //    }

        //    return new Tuple<Point2D[], Point3D[]>(scrPoints, scnPoints);
        //}

        private bool IsObjectCloser(ref ISetInfo tempSetInfo, ref Point3D tempScnPoint, List<Point3D> scnPoints)
        {
            if (scnPoints.Count == 1)
                return scnPoints[0]._z > tempScnPoint._z ? true : false;
            else
            {
                var _z = scnPoints.Sum(x => x._z) / scnPoints.Count;
                return _z > tempScnPoint._z ? true : false;
            }
        }

        private bool IsObjectSelected(Point2D selectionPoint, List<Point2D> scrPoints)
        {
            if (scrPoints.Count == 1)
            {
                if (scrPoints[0]._x > selectionPoint._x - 10
                                & scrPoints[0]._x < selectionPoint._x + 5
                                &&
                                scrPoints[0]._y > selectionPoint._y - 5
                                & scrPoints[0]._y < selectionPoint._y + 5)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (scrPoints.Count == 2)
            {
                var curve = new Curve2D(scrPoints);
                return curve.IsPointBelongCurve(selectionPoint) ? true : false;
            }
            else
            {
                var creator = new Hull2DCreator();
                if(creator.TryCreateHullGraham(scrPoints, out Polygon polygon))
                    return polygon.IsPointInsidePolygon(selectionPoint) ? true : false;

                return false;
            }

        }
    }
}
