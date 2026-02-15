using BazisGUI.PropertiesPanel;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private bool IsReduceBrightness = true;
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

                        if (IsObjectSelected(selectionPoint, set.ObjType, scrPoints))
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
                                // вычисление центральной z координаты объекта
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
            {
                if (IsReduceBrightness)
                {
                    ApplyDim(tempSetInfo.ObjType);
                    IsReduceBrightness = false;
                }
                console.PrintInfo($"Выбран объект : {tempSetInfo.ObjType} {tempNumb}", Color.Black);
                CreateObjectProperties(tempSetInfo, tempNumb);
            }
            return selFlag;
        }

        private bool IsObjectSelected(Point2D selectionPoint, ObjType objType, List<Point2D> scrPoints)
        {
            var temp = false;
            if (objType == ObjType.Кривая)
                temp = IsCurveSelected(selectionPoint, scrPoints);
            else if (objType == ObjType.Поверхность)
                temp = IsSurfaceSelected(selectionPoint, scrPoints);
            else
                temp = IsObjectSelected(selectionPoint, scrPoints);
            return temp;
        }

        private bool IsSurfaceSelected(Point2D selectionPoint, List<Point2D> scrPoints)
        {
            var rect = new RectangleBox(scrPoints);
            if (rect.IsPointInside(selectionPoint))
            // пока добавим дополнительную проверку, без нее работает гораздо хуже на изогнутых поверхностях
            {
                var creator = new Hull2DCreator();
                var count = scrPoints.Count/3;
                for (int i = 0; i < count; i++)
                {
                    var temp = new Point2D[]
                    {
                        scrPoints[3 * i + 0],
                        scrPoints[3 * i + 1],
                        scrPoints[3 * i + 2]
                    };
                    if (creator.TryCreateHullGraham(temp, out Polygon polygon))
                        if (polygon.IsPointInsidePolygon(selectionPoint))
                            return true;
                        //return polygon.IsPointInsidePolygon(selectionPoint) ? true :;
                }
                return false;
            }
            else 
                return false;
        }

        private void CreateObjectProperties(ISetInfo setName, int number)
        {

            var rows = new List<RowProperty>();
            rows.Add(new RowProperty("Объект", setName.ObjType, true));

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
                var element = project.GetAllModelElements().First(x => x.Number == number);
                rows.AddRange(GetElementProperty(element));
            }
            else if (setName.ObjType == ObjType.Кривая)
                rows.AddRange(GetCurveProperties(number));
            else if (setName.ObjType == ObjType.Поверхность)
                rows.AddRange(GetSurfaceProperties(number));

            var objInfo = $"{number} {setName.ObjType}";
            propertiesPanel.DrawTable(rows, objInfo, 1);
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

        private bool IsCurveSelected(Point2D selectionPoint, List<Point2D> scrPoints)
        {
            var rect = new RectangleBox(scrPoints);
            if (rect.IsPointInside(selectionPoint))
            // пока добавим дополнительную проверку, без нее работает гораздо хуже на изогнутых поверхностях
            {
                if (scrPoints.Count == 2)
                {
                    var seg = new Segment2D(scrPoints[0], scrPoints[1]);

                    return seg.IsPointBelongSegment(selectionPoint, 5) ? true : false;
                }
                else
                {
                    var count = scrPoints.Count/2;
                    for (int i = 0; i < count; i++)
                    {          
                        var seg = new Segment2D(scrPoints[2 * i + 0], scrPoints[2 * i + 1]);
                        if (seg.IsPointBelongSegment(selectionPoint, 5))
                            return true;
                    }            
                }
            }
            return false;
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
                if (rect.IsPointInside(selectionPoint))
                // пока добавим дополнительную проверку, без нее работает гораздо хуже на изогнутых поверхностях
                {
                    var creator = new Hull2DCreator();
                    if (creator.TryCreateHullGraham(scrPoints, out Polygon polygon))
                        return polygon.IsPointInsidePolygon(selectionPoint) ? true : false;
                }
                return false;
            }
        }
    }
}
