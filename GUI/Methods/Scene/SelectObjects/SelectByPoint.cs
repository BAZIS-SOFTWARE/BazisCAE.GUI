using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
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

                        foreach (var point in coords)
                        {
                            var scnPoint = GetSceenCoord(point);
                            scnPoints.Add(scnPoint);

                            var scrPoint = GetScreenCoord(scnPoint);
                            scrPoints.Add(scrPoint);
                        }


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

            if (selFlag)
                CreateObjectProperties(tempSetInfo, tempNumb);

            return selFlag;
        }

        private void CreateObjectProperties(ISetInfo setName, int number)
        {

            var rows = new List<RowProperty>();
            if (setName.ObjType == ObjType.Точка)
                rows.AddRange(GetPointProperty(number));

            else if (setName.ObjType == ObjType.Узел)
            {
                var node = (Node)project.GetModelObject(ObjType.Узел, number);
                rows.AddRange(GetNodeProperty(node));
            }


            else if (setName.ObjType == ObjType.Элемент1D |
                setName.ObjType == ObjType.Элемент2D |
                setName.ObjType == ObjType.Элемент3D)
            {
                var element = project.GetModelElements().First(x => x.Number == number);
                rows.AddRange(GetElementProperty(element));
            }


            else if (setName.ObjType == ObjType.Кривая)
                rows.AddRange(GetCurveProperties(number));


            propertiesPanel.DrawTable(rows);
        }

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
            else
            {
                var rect = new RectangleBox(scrPoints);
                //if(rect.IsPointInside(selectionPoint))
                //{
                    if (scrPoints.Count == 2)
                    {
                        var seg = new Segment2D(scrPoints[0], scrPoints[1]);
 
                        return seg.IsPointBelongSegment(selectionPoint,5) ? true : false;
                    }
                    else
                    {
                        var creator = new Hull2DCreator();
                        if (creator.TryCreateHullGraham(scrPoints, out Polygon polygon))
                            return polygon.IsPointInsidePolygon(selectionPoint) ? true : false;
                    }
                //}
                return false;
            }
        }
    }
}
