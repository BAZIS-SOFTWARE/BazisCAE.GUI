
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsEx.Graph
{
    public class GraphData
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// IsTitleShown
        /// </summary>
        public bool IsTitleShown { get; set; } = true;
        /// <summary>
        /// IsShown
        /// </summary>
        public bool IsShown { get; set; } = true;
        /// <summary>
        /// Color
        /// </summary>
        public Color Color { get; }

        GraphPoint [] x_y_points;

        public string X_Unit { get; }
        public string Y_Unit { get; }

        public GraphData(string title, Color color, string x_unit, string y_unit, GraphPoint [] x_y_points)
        {
            Title = title;
            Color = color;

            X_Unit = x_unit;
            Y_Unit = y_unit;
          
            this.x_y_points = x_y_points;

            X_Max = x_y_points.Max(x => x.X);
            X_Min = x_y_points.Min(x => x.X);
            Y_Max = x_y_points.Max(x => x.Y);
            Y_Min = x_y_points.Min(x => x.Y);

        }

        public GraphPoint this[int ind]
        {
            get { return x_y_points[ind]; }
        }

        public int Get_XByY(float yValue)
        {
            var left = 0;
            var right = x_y_points.Length - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;

                if (yValue.CompareTo(x_y_points[middle].Y) < 0)
                    right = middle;
                else if (yValue.CompareTo(x_y_points[middle].Y) == 0)
                    return middle;
                else left = middle + 1;
            }

            return right;
        }
        /// <summary>
        /// GetPoints
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GraphPoint> GetPoints()
        {
            foreach (var x_y_value in x_y_points)
            {
                yield return x_y_value;
            }
        }
        /// <summary>
        /// Y_Max
        /// </summary>
        public float Y_Max { get; }
        /// <summary>
        /// Y_Min
        /// </summary>
        public float Y_Min { get; }
        /// <summary>
        /// X_Max
        /// </summary>
        public float X_Max { get; }
        /// <summary>
        /// X_Min
        /// </summary>
        public float X_Min { get; }
        /// <summary>
        /// ValueFlag
        /// </summary>
        public bool ValueFlag { get; set; } = false;
        /// <summary>
        /// Thickness
        /// </summary>
        public float Thickness { get; set; } = 1.0f;
    }
}
