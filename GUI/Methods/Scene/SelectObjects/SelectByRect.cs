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
        public bool SelectByRect(IEnumerable<ISetInfo> sets, RectangleBox selectionBox, bool isSelected)
        {
            var selFlag = false;
            foreach (var set in sets)
            {
                foreach (var numb in set.GetNumbers())
                {
                    if (set.GetViewState(numb))
                    {
                        var coords = set.GetCoords(numb);
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

                        if (selectionBox.IsPointsInside(scrPoints))
                        {
                            selFlag = true;
                            if (isSelected)
                                set.SetColor(settingsConfig.SelectObjectColor, numb);//  page.ScenePage.settingsConfig.SelectObjectColor;
                            else
                                set.SetBackColor(numb);
                        }
                    }
                }

            }

            //if (isSorted & selections.Count > 0)
            //{
            //    var near = selections.OrderByDescending(x => GetSceenCoord(x.CalcCentr())._z).FirstOrDefault();
            //    selections = new List<IModelObject>() { near };
            //}

            return selFlag;
        }
    }
}
