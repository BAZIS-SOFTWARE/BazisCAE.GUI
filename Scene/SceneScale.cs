
using Geometry;
using Scene.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tao.OpenGl;

namespace Scene
{
    /// <summary>
    /// SceneScale
    /// </summary>
    public class SceneScale : ISceneScale
    {
        private ScaleItem [] items;
        private int intervals = 10;
        /// <inheritdoc/>
        public int FontBase { get; set; }//идентификатор нужен для корректного отображения шрифтов

        /// <inheritdoc/>

        public string Title { get; set; }
        /// <inheritdoc/>
        public string Info { get; set; }
        /// <inheritdoc/>

        public decimal Precision { get; set; } = 4;
/// <inheritdoc/>

        public float MaxValue
        {
            get
            {
                return items.Last().Max;
            }
        }
/// <inheritdoc/>

        public float MinValue
        {
            get
            {
                return items.First().Min;
            }
        }
/// <inheritdoc/>

        public int Coord_X { get; set; } = 70;
        /// <inheritdoc/>
        public int Coord_Y { get; set; } = 140;
        /// <inheritdoc/>
        public int Intervals 
        {
            get { return intervals; }
            set
            {
                if (value > 10)
                    throw new Exception("Допускается не больше 10 интервалов");
                intervals = value;
            }
        }

        /// <inheritdoc/>

        public Color GetValueColor(float resValue)
        {
            var color = items.First().Color;

            if (items.Last().Max <= resValue)
                color = items.Last().Color;
            else if (items.First().Min >= resValue)
                color = items.First().Color;
            else
            {
                foreach (var item in items)
                {
                    if (item.Min <= resValue & item.Max >= resValue)
                    {
                        color = item.Color;
                        break;
                    }

                }
            }
            return color;
        }

        public SceneScale(float min, float max, decimal ranges, string genInfo, string subInfo)
        {
            if (ranges < 2)
                throw new Exception("Должно быть минимум два диапазона!");
            Title = genInfo;
            Info = subInfo;
            FillRange(min, max, ranges);
        }
/// <inheritdoc/>

        public void FillRange(float min, float max, decimal intervals)
        {
            items = new ScaleItem[(int)intervals];

            var values = GenerateValueRanges(min, max, intervals);
            RoundValueRanges(values);
            var colors = CreateColorRange(intervals);

            for (int i = 0; i < colors.Length; i++)
            {
                items[i] = new ScaleItem() { Color = colors[i], Min = values[i][0], Max = values[i][1] };
            }
        }

        private Color[] CreateColorRange(decimal intervals)
        {
            switch (intervals)
            {
                case 2:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 3:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff3c"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 4:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00fff7"),
                        System.Drawing.ColorTranslator.FromHtml("#84ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 5:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00aaff"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff3c"),
                        System.Drawing.ColorTranslator.FromHtml("#e1ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 6:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#006fff"),
                        System.Drawing.ColorTranslator.FromHtml("#00ffaa"),
                        System.Drawing.ColorTranslator.FromHtml("#37ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ffe100"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 7:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#0048ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00fff7"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff3c"),
                        System.Drawing.ColorTranslator.FromHtml("#84ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ffbf00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 8:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#002fff"),
                        System.Drawing.ColorTranslator.FromHtml("#00d0ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff8c"),
                        System.Drawing.ColorTranslator.FromHtml("#1aff00"),
                        System.Drawing.ColorTranslator.FromHtml("#bbff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ffa200"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                case 9:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#001aff"),
                        System.Drawing.ColorTranslator.FromHtml("#00aaff"),
                        System.Drawing.ColorTranslator.FromHtml("#00ffc8"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff3c"),
                        System.Drawing.ColorTranslator.FromHtml("#55ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#e1ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff8c00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
                default:
                    return new Color[]
                    {
                        System.Drawing.ColorTranslator.FromHtml("#7300ff"),
                        System.Drawing.ColorTranslator.FromHtml("#000dff"),
                        System.Drawing.ColorTranslator.FromHtml("#0088ff"),
                        System.Drawing.ColorTranslator.FromHtml("#00fff7"),
                        System.Drawing.ColorTranslator.FromHtml("#00ff77"),
                        System.Drawing.ColorTranslator.FromHtml("#04ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#84ff00"),
                        System.Drawing.ColorTranslator.FromHtml("#fffb00"),
                        System.Drawing.ColorTranslator.FromHtml("#ff8000"),
                        System.Drawing.ColorTranslator.FromHtml("#ff0000")
                    };
            }
        }

        private void RoundValueRanges(List<float[]> range)
        {
            foreach (var rangeItem in range)
            {
                var tempItem = rangeItem.Select(y => y = (float)Math.Round(y, (int)Precision)).ToArray();
                rangeItem[0] = tempItem[0];
                rangeItem[1] = tempItem[1];
            }
        }

        private static List<float[]> GenerateValueRanges(float min, float max, decimal intervals)
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

        private void DisplayText(string str, Color color, Point3D coord)
        {
            Gl.glPushMatrix();
            Gl.glColor3b(color.R, color.G, color.B);
            Gl.glRasterPos3f(coord._x, coord._y, coord._z);
            Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
            Gl.glListBase(FontBase);//Устанавливаем базу на FontBase!
            Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
            Gl.glPopAttrib();//Возвращаем старую базу
            Gl.glPopMatrix();
        }
        /// <inheritdoc/>
        public void Display(int width, int height, Graphics g, Font font)
        {
            Initialize_GUI_Plane(width, height);

            var lenght = height - Coord_Y - 50;
            var gap_Y = 2;
            var cellSize_Y = (lenght - ((items.Length - 1) * gap_Y)) / items.Length;

            var step_Y = cellSize_Y + gap_Y;

            DisplayScale(Coord_X, Coord_Y, gap_Y, cellSize_Y, step_Y);

            //var dec = (int)resultData.Precision;
            var pos_y = Coord_Y;
            for (int i = 0; i < items.Length; i++)
            {
                var incrY = pos_y + (step_Y / 2) - (step_Y / 2);

                DisplayText(items[i].Min.ToString(), Color.FromArgb(0, 0, 0), new Point3D(Coord_X + 20, incrY, -5));
                incrY = incrY + step_Y;
                DisplayText(items[i].Max.ToString(), Color.FromArgb(0, 0, 0), new Point3D(Coord_X + 20, incrY, -5));

                pos_y += step_Y;
            }

            SizeF messageSize = g.MeasureString(Title, font);
            DisplayText(Title, Color.FromArgb(0, 0, 0), new Point3D(Coord_X - messageSize.Width / 2, pos_y + 30, -5));

            messageSize = g.MeasureString(Info, font);
            DisplayText(Info, Color.FromArgb(0, 0, 0), new Point3D(Coord_X - messageSize.Width / 2, pos_y + 15, -5));
            Finish_GUI_Plane();
        }

        private void DisplayScale(int x, int y, int gap_Y, int cellSize_Y, int step_Y)
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(x, y, -5);

            var y0 = 0;
            var y1 = cellSize_Y;

            for (int i = 0; i < items.Length; i++)
            {
                var color = items[i].Color;
                Gl.glColor3f(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
                Gl.glRectd(0, y0, 10, y1);

                y0 = y1 + gap_Y;
                y1 = y1 + step_Y;
            }
            Gl.glPopMatrix();
        }

        private void Initialize_GUI_Plane(int width, int height)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
        }

        private void Finish_GUI_Plane()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();
        }
/// <inheritdoc/>

        public IEnumerator<IScaleItem> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
