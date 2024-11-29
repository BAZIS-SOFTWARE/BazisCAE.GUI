using System.Collections.Generic;
using System.Drawing;

namespace BaseModule.Results.ScaleControl
{
    public interface IScale
    {

        IEnumerable<Color> ColorRange();

        IEnumerable<float[]> ValueRange();
 

        float MaxValue { get; }

        float MinValue { get; }

        int Coord_X { get; set; }
        int Coord_Y { get; set; }

        Color GetValueColor(float resValue);

        void FillInputRange(float max, float min, decimal intervals, decimal precision);
    }
}