using System;

namespace UserControlsEx.Graph.Functions
{
    /// <summary>
    /// InterpolationSearch
    /// </summary>
    public static class InterpolationSearch
    {
        /// <summary>
        /// InterpolatedValueTwoPoints. Интерполяция между двумя точками. Внимание проверяйте, чтобы две точки не имели одинаковых x координат!
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="xn"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static float InterpolatedValueTwoPoints(float x1, float x2, float y1, float y2, float xn)
        {

            //if (Math.Abs(x1 - x2) < 1e-6)
            //{
            //    throw new Exception("Функция задана некорректно. Два одинаковых аргумента находятся рядом!");
            //}
            if (x1 < x2)
            {
                if (xn >= x1 & xn <= x2)
                {
                    return ((xn - x1) / (x2 - x1) * (y2 - y1)) + y1;

                }
                else if (xn < x1)
                {
                    return y1;
                }
                else
                {
                    return y2;
                }
            }
            else
            {
                if (xn <= x1 & xn >= x2)
                {
                    return ((xn - x1) / (x2 - x1) * (y2 - y1)) + y1;
                }
                else if (xn > x1)
                {
                    return y1;
                }
                else
                {
                    return y2;
                }
            }
        }
    }
}
