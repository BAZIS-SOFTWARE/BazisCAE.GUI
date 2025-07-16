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
            Point3D tempSceenPoint = null;

            foreach (var set in sets)
            {
                foreach (var numb in set.GetNumbers())
                {
                    if (set.GetViewState(numb))
                    {
                        var coords = set.GetCoords(numb);

                        var resu = ConvertObjectCoords(coords);

                        var scnPoints = resu.Item2;
                        var scrPoints = resu.Item1;
                        // Магия выбора
                        // Если объект точка 
                        if (coords.Count() == 1)
                        {
                            if (IsPointObjectSelected(selectionPoint, scrPoints))
                            {
                                selFlag = true;
                                if (isSelected)
                                    set.SetColor(settingsConfig.SelectObjectColor, numb);
                                else
                                    set.SetBackColor(numb);

                                if (IsObjectCloser(ref tempSetInfo, ref tempSceenPoint, scnPoints))
                                {
                                    tempSetInfo?.SetBackColor(tempNumb);
                                    SwapInfo(ref tempNumb, ref tempSetInfo, set, numb);
                                    tempSceenPoint = scnPoints[0];
                                }
                                else
                                    set.SetBackColor(numb);
                            }
 
                        }
                        else if (coords.Count() == 2)
                        {

                        }
                        else
                        {

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

        private Tuple<Point2D[], Point3D[]> ConvertObjectCoords(IEnumerable<Point3D> coords)
        {
            var scrPoints = new Point2D[coords.Count()];
            var scnPoints = new Point3D[coords.Count()];

            var pointCounter = 0;
            foreach (var point in coords)
            {
                var scnPoint = GetSceenCoord(point);
                scnPoints[pointCounter] = scnPoint;

                var scrPoint = GetScreenCoord(scnPoint);
                scrPoints[pointCounter] = scrPoint;

                pointCounter++;
            }

            return new Tuple<Point2D[], Point3D[]>(scrPoints, scnPoints);
        }

        private bool IsObjectCloser(ref ISetInfo tempSetInfo, ref Point3D tempScnPoint, Point3D[] scnPoints)
        {
            if (tempSetInfo == null ||
                    tempSetInfo != null &
                    scnPoints[0]._z > tempScnPoint._z)
            {
                return true;
            }
            else
                return false;

        }

        private bool IsPointObjectSelected(Point2D selectionPoint, Point2D[] scrPoints)
        {
            if (scrPoints[0]._x > selectionPoint._x - 10
                                            & scrPoints[0]._x < selectionPoint._x + 10
                                            &&
                                            scrPoints[0]._y > selectionPoint._y - 10
                                            & scrPoints[0]._y < selectionPoint._y + 10)
            {
                return true;
            }
            else
                return false;
        }
    }
}
