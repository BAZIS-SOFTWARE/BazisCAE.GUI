using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void FitObjectsToScreen()
        {
            var matrix = ViewMatrix;
            matrix[0, 3] = 0; matrix[1, 3] = 0;
            var tempViewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(tempViewMatrixAr);

            for (int i = 0; i < 3; i++)
            {
                var factor = 1.0f;
                var maxRad = 0.0f;

                foreach (var glObj in VBOController.GetVBObjs())
                {
                    foreach (var item in glObj.BoundingBox.GetCornerPoints())
                    {
                        var scnCoord = GetSceenCoord(item);
                        var scrCoord = GetScreenCoord(scnCoord);

                        var pRad = (float)Math.Sqrt((scrCoord._x * scrCoord._x) + (scrCoord._y * scrCoord._y));

                        if (pRad > maxRad) maxRad = pRad;
                    }

                    if (maxRad == 0)
                        break;
                }
                if (Width > Height)
                    factor = 1 / (maxRad / (float)(Height / 3));
                else { factor = 1 / (maxRad / (float)(Width / 3)); }

                if (factor == 0) factor = 1;

                ScaleObjs(factor);

                if (Math.Abs(factor - 1) < 0.1) break;
            }
        }
    }
}
