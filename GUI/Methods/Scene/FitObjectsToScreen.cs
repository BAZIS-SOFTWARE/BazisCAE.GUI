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
            var matrix = camera.GetViewMatrix();
            matrix[0, 3] = 0; matrix[1, 3] = 0;
            var tempViewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(tempViewMatrixAr);

            for (int i = 0; i < 3; i++)
            {
                var factor = 1.0f;
                var maxRad = 0.0f;

                foreach (var glObj in VBOController.GetVBObjs())
                {
                    var coords = glObj.PointsCoords;

                    if (coords.Length == 0)
                        continue;

                    var length = coords.Length / 3;
                    for (int j = 0; j < length; j++)
                    {
                        var x = coords[3 * j + 0];
                        var y = coords[3 * j + 1];
                        var z = coords[3 * j + 2];
                        var scnCoord = camera.GetSceenCoord(x, y, z);
                        var scrCoord = camera.GetScreenCoord(scnCoord);

                        var pRad = (float)Math.Sqrt((scrCoord._x * scrCoord._x) + (scrCoord._y * scrCoord._y));

                        if (pRad > maxRad) maxRad = pRad;
                    }

                    if (Width > Height)
                        factor = 1 / (maxRad / (float)(Height / 2));
                    else { factor = 1 / (maxRad / (float)(Width / 2)); }

                    if (factor == 0) factor = 1;

                    ScaleObjs(factor);
                }
                if (Math.Abs(factor - 1) < 0.1) break;
            }
        }
    }
}
