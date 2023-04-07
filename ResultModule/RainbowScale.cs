using Functions.Search;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ResultModule
{
    public class RainbowScale : IScale
    {
        Color[] сolorRange;

        List<float[]> valueRange;

        public IEnumerable<Color> ColorRange()
        {
            foreach (var color in сolorRange)
            {
                yield return color;
            }
        }

        public IEnumerable<float[]> ValueRange()
        {
            foreach (var range in valueRange)
            {
                yield return range;
            }
        }

        public float MaxValue
        {
            get
            {
                return valueRange.Last()[1];
            }
        }

        public float MinValue
        {
            get
            {
                return valueRange.First()[0];
            }
        }

        public int Coord_X { get; set; }
        public int Coord_Y { get; set; }

        public Color GetValueColor(float resValue)
        {
            var colorInd = LinearSearch.CloseLinear(valueRange, resValue);
            if (colorInd < 0) colorInd = 0;
            return сolorRange[colorInd];
        }


        public RainbowScale(decimal precision, float max, float min, decimal intervals)
        {
            valueRange = new List<float[]>();
            FillInputRange(max, min, intervals, precision);

            var tempColorRange = new Color[10];

            tempColorRange[0] = Color.FromArgb(0, 0, 255);
            tempColorRange[1] = Color.FromArgb(0, 128, 255);
            tempColorRange[2] = Color.FromArgb(0, 255, 255);
            tempColorRange[3] = Color.FromArgb(0, 255, 80);
            tempColorRange[4] = Color.FromArgb(0, 255, 0);
            tempColorRange[5] = Color.FromArgb(128, 255, 0);
            tempColorRange[6] = Color.FromArgb(255, 255, 0);
            tempColorRange[7] = Color.FromArgb(255, 128, 0);
            tempColorRange[8] = Color.FromArgb(255, 0, 0);
            tempColorRange[9] = Color.FromArgb(255, 0, 255);

            сolorRange = new Color[(int)intervals];

            for (int i = 0; i < сolorRange.Length; i++)
            {
                сolorRange[i] = tempColorRange[i];
            }

        }

        public void FillInputRange(float max, float min, decimal intervals, decimal precision)
        {
            List<float[]> range = GenerateValueRanges(max, min, intervals);
            RoundValueRanges(precision, range);

            valueRange = range;
        }

        private void RoundValueRanges(decimal precision, List<float[]> range)
        {
            foreach (var rangeItem in range)
            {
                var tempItem = rangeItem.Select(y => y = (float)Math.Round(y, (int)precision)).ToArray();
                rangeItem[0] = tempItem[0];
                rangeItem[1] = tempItem[1];
            }
        }

        private static List<float[]> GenerateValueRanges(float max, float min, decimal intervals)
        {
            var range = new List<float[]>();

            var step = (max - min) / (float)intervals;
            //var step = 1400;
            var value = min;

            for (int i = 0; i < intervals; i++)
            {
                var subrange = new float[2];
                for (int j = 0; j < subrange.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        subrange[j] = min;
                    }
                    else if (i == range.Count - 1 && j == range[i].Length - 1)
                    {
                        subrange[j] = max;
                    }
                    else
                    {
                        if (j == 0)
                        {
                            subrange[j] = range[i - 1][1];
                        }
                        else
                        {
                            value = value + step;
                            subrange[j] = value;
                        }
                    }
                }
                range.Add(subrange);
            }

            return range;
        }
    }
}
