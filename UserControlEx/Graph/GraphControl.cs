using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx.Graph.Functions;

namespace UserControlsEx.Graph
{
    public partial class GraphControl : UserControl
    {
        //List<List<float>> xRanges = new List<List<float>>() { new List<float>() { 0, 10 } };
        //List<List<float>> yRanges = new List<List<float>>() { new List<float>() { 0, 10 } };
        List<GraphData> graphData = new List<GraphData>();
        private Point iniPos;

        public string Title { get; set; }

        public float Y_max { get; set; } = 10;
        public float Y_min { get; set; } = 0;

        public float X_length { get { return X_max - X_min; } }

        public float Y_length { get { return Y_max - Y_min; } }

        float Deviation { get; set; }

        public float X_max { get; set; } = 10;
        public float X_min { get; set; } = 0;

        public AxisFormat XAxisFormat { get; set; } = new AxisFormat();

        public AxisFormat YAxisFormat { get; set; } = new AxisFormat();

        public int CountRanges()
        {
            return graphData.Count;
        }

        public GraphData this[int index]
        {
            get { return graphData[index]; }
        }

        public IEnumerable<GraphData> GetData()
        {
            foreach (var data in graphData)
            {
                yield return data;
            }
        }

        public void AddData(List<GraphData> data)
        {
            graphData.AddRange(data);

            Set_Max_Min_X_Y();
        }

        public void ClearData()
        {
            graphData.Clear();
        }

        public void Set_Max_Min_X_Y()
        {
            X_min = graphData.Min(d => d.X_Min);
            X_max = graphData.Max(d => d.X_Max);

            if (X_min.Equals(X_max))
                if (X_max > 0)
                    X_min = 0;
                else if (X_max < 0)
                    X_max = 0;
                else X_max = 1;

            Y_min = graphData.Min(d => d.Y_Min);
            Y_max = graphData.Max(d => d.Y_Max);

            if (Y_min.Equals(Y_max))
                if (Y_max > 0)
                    Y_min = 0;
                else if (Y_max < 0)
                    Y_max = 0;
                else Y_max = 1;
        }

        public bool ValueFlag { get; set; } = false;
        public bool DashPaintFlag { get; set; } = false;
        public bool LinePaintFlag { get; set; } = true;
        public float PathThickness 
        { 
            set
            {
                foreach (var data in graphData)
                {
                    data.Thickness = value;
                }
            }
        }

        //public Dictionary<string, string> Y_dimension { get; set; }
        //public Dictionary<string, string> X_dimension { get; set; }

        public GraphControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
            Dock = DockStyle.Fill;
        }

        private void Graph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.SystemColors.Control);

            Find_yMax_Length(e.Graphics);

            Rectangle border = BorderPaint(e.Graphics);

            try
            {
                int x0, xl, y0, yl;

                x0 = border.X; // положение области графика на контроле по х
                xl = border.Width; // длина области графика
                y0 = ClientSize.Height - border.Y; // положение области графика на контроле по у
                yl = border.Height; // ширина области графика

                var font = new Font(Font.FontFamily, (float)14, FontStyle.Regular, GraphicsUnit.Pixel);

                TitlePaint(e.Graphics, Title, new Point(ClientSize.Width / 2, 10));
                AxisPaint(e.Graphics, border, x0, xl, y0, yl);
                foreach (var data in graphData)
                {
                    if (data.IsShown)
                    {
                        PathPaint(e.Graphics, border, x0, xl, y0, yl, data);

                        if (ValueFlag)
                            PointsPaint(e.Graphics, border, x0, xl, y0, yl, data);
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public virtual void Draw()
        //{
            
        //}

        private void PointsPaint(Graphics e, Rectangle border, int x0, int xl, int y0, int yl, GraphData data)
        {
            if (data.ValueFlag)
            {
                GraphicsPath graphPath = new GraphicsPath();

                foreach (var point in data.GetPoints())
                {
                    PointPaint(e, point, data.Color, x0, xl, y0, yl);
                    ValuePaint(e, point, data.Color, x0, xl, y0, yl);
                }
            }
        }

        public virtual void ValuePaint(Graphics e, GraphPoint point, Color color, int x0, int xl, int y0, int yl)
        {

            var kx = (point.X - X_min) / X_length;

            if (float.IsInfinity(kx) | float.IsNaN(kx))
                throw new Exception("Ошибка рисования значений по оси  X, число INF или NAN");

            var ky = (point.Y - Y_min) / Y_length;

            if (float.IsInfinity(kx) | float.IsNaN(kx))
                throw new Exception("Ошибка рисования значений по оси  Y, число INF или NAN");

            var x_c = (kx * xl) + x0;
            var y_c = y0 - (ky * yl);

            var info = point.ToString();

            var font = new Font(Font.FontFamily, (float)12, FontStyle.Regular, GraphicsUnit.Pixel);

            TextPaint(e, String.Format("[{0}]", info), new Point((int)x_c, (int)y_c - 10),font);

        }

        public void PathPaint(Graphics e, Rectangle drawRect, int x0, int xl, int y0, int yl, GraphData data)
        {
            var font = new Font(Font.FontFamily, (float)14, FontStyle.Regular, GraphicsUnit.Pixel);

            GraphicsPath graphPath = new GraphicsPath();
            var points = data.GetPoints().ToArray();

            var kx = (points[points.Length / 2].X - X_min) / X_length;
            var ky = (points[points.Length / 2].Y - Y_min) / Y_length;

            var x_c = (kx * xl) + x0;
            var y_c = y0 - (ky * yl);

            if(data.IsTitleShown)
                TextPaint(e, data.Title, new Point((int)x_c, (int)y_c - 25), font);

            for (int j = 0; j < points.Length - 1; j++)
            {
                kx = (points[j].X - X_min) / X_length;
                ky = (points[j].Y - Y_min) / Y_length;

                if (float.IsInfinity(kx) | float.IsNaN(kx))
                    throw new Exception($"Ошибка рисования графика {data.Title} ось X, число INF или NAN");

                if (float.IsInfinity(ky) | float.IsNaN(ky))
                    throw new Exception($"Ошибка рисования графика {data.Title} ось Y, число INF или NAN");

                var x1_c = (kx * xl) + x0;
                var y1_c = y0 - (ky * yl);


                kx = (points[j + 1].X - X_min) / (X_length);

                ky = (points[j + 1].Y - Y_min) / Y_length;
                var x2_c = (kx * xl) + x0;
                var y2_c = y0 - (ky * yl);

                if (x1_c < x0 && x2_c > x0)
                {
                    y1_c = InterpolationSearch.InterpolatedValueTwoPoints(x1_c, x2_c, y1_c, y2_c,x0);
                    x1_c = x0;
                }
                if (x1_c < x0 + xl && x2_c > x0 + xl)
                {
                    y2_c = InterpolationSearch.InterpolatedValueTwoPoints(x1_c, x2_c, y1_c, y2_c,x0 + xl);
                    x2_c = x0 + xl;
                }
                if (y1_c < y0 - yl && y2_c > y0 - yl) // убывание значения фун-ции
                {
                    x1_c = InterpolationSearch.InterpolatedValueTwoPoints(y1_c, y2_c, x1_c, x2_c, y0 - yl);
                    y1_c = y0 - yl;
                }
                if (y1_c > y0 && y2_c < y0)
                {
                    x1_c = InterpolationSearch.InterpolatedValueTwoPoints(y2_c, y1_c,x1_c, x2_c, y0);
                    y1_c = y0;
                }
                if (y1_c > y0 - yl && y2_c < y0 - yl) // рост значения фун-ции
                {
                    x2_c = InterpolationSearch.InterpolatedValueTwoPoints(y2_c, y1_c,x1_c, x2_c, y0 - yl);
                    y2_c = y0 - yl;
                }
                if (y1_c < y0 && y2_c > y0)
                {
                    x2_c = InterpolationSearch.InterpolatedValueTwoPoints(y1_c, y2_c,x1_c, x2_c, y0);
                    y2_c = y0;
                }

                if ((x1_c < x0 && x2_c < x0) || (x1_c > x0 + xl && x2_c > x0 + xl)) continue;

                if ((y1_c < y0 - yl && y2_c < y0 - yl) || (y1_c > y0 && y2_c > y0)) continue;

                else graphPath.AddLine(x1_c, y1_c, x2_c, y2_c);

                if (DashPaintFlag)
                {
                    DashPaint(e, drawRect, x1_c, y1_c);
                    DashPaint(e, drawRect, x2_c, y2_c);
                }

            }

            TextPaint(e, "X," + data.X_Unit, new Point(ClientSize.Width + 10 - (int)Deviation, ClientSize.Height - 30), font);
            TextPaint(e, "Y," + data.Y_Unit, new Point(5 + (int)Deviation, 15), font);


            e.DrawPath(new Pen(data.Color, data.Thickness), graphPath);
        }

        public void PointPaint(Graphics e, GraphPoint point, Color color, int x0, int xl, int y0, int yl)
        {
            var kx = (point.X - X_min) / (X_length);
            
            if (float.IsInfinity(kx) | float.IsNaN(kx))
                throw new Exception("Ошибка рисования точек по оси X, число INF или NAN");
            var ky = (point.Y - Y_min) / Y_length;

            if (float.IsInfinity(kx) | float.IsNaN(kx))
                throw new Exception("Ошибка рисования точек по оси Y, число INF или NAN");
            var x_c = (kx * xl) + x0;
            var y_c = y0 - (ky * yl);

            e.FillRectangle(new SolidBrush(color), new Rectangle((int)x_c - 2, (int)y_c - 2, 5, 5));
            e.DrawRectangle(new Pen(Brushes.Gray, 0.5f), new Rectangle((int)x_c - 2, (int)y_c - 2, 5, 5));
        }

        public void AxisPaint(Graphics e, Rectangle borderRect, int x0, int xl, int y0, int yl)
        {
            var count = 5;
            var y = Y_min;
            var x = X_min;

            var stepY = Y_length / count;
            var stepX = X_length / count;

            var kx = 0.0f; var ky = 0.0f;

            var font = new Font(Font.FontFamily, (float)12, FontStyle.Regular, GraphicsUnit.Pixel);
            for (int i = 0; i <= count; i++)
            {
                if (graphData.Count != 0) kx = (x - X_min) / X_length;
                if (graphData.Count != 0) ky = (y - Y_min) / Y_length;

                if (float.IsInfinity(kx) | float.IsNaN(kx))
                    throw new Exception("Ошибка рисования оси X, число INF или NAN");

                if (float.IsInfinity(ky) | float.IsNaN(ky))
                    throw new Exception("Ошибка рисования оси Y, число INF или NAN");

                var x_c = (kx * xl) + x0;
                var y_c = y0 - (ky * yl);

                float yVal;
                if (YAxisFormat.StepFormat == StepFormat.logarithmic)
                    yVal = (float)Math.Pow(10, y);
                else yVal = y;

                var yStr = GetValueFormatStr(yVal, YAxisFormat);

                TextPaint(e, yStr, new Point((borderRect.X / 2), (int)y_c), font);


                float xVal;
                if (XAxisFormat.StepFormat == StepFormat.logarithmic)
                    xVal = (float)Math.Pow(10, x);
                else xVal = x;

                var xStr = GetValueFormatStr(xVal,XAxisFormat);

                TextPaint(e, xStr, new Point((int)x_c, ClientSize.Height - 15), font);
                y = y + stepY;
                x = x + stepX;
                if (LinePaintFlag) LinePaint(e, borderRect, x_c, y_c);
            }
        }

        private string GetValueFormatStr(float x, AxisFormat axisFormat)
        {
            var preStr = axisFormat.NumberOfSingsStr;
 
            if (axisFormat.TextFormat == TextFormat.exponential)
                return x.ToString($"0.{preStr}E+00");
            else return x.ToString($"#.{preStr}");
        }

        public void Find_yMax_Length(Graphics g)
        {
            if (graphData.Count == 0) 
                Deviation = 0;

            var l = 0.0f;
            foreach (var data in graphData)
            {
                foreach (var point in data.GetPoints())
                {
                    var s = point.Y.ToString();
                    SizeF messageSize = g.MeasureString(s, Font);
                    if (l < messageSize.Width) l = messageSize.Width;
                }
            }

            Deviation = l;
        }

        public void DashPaint(Graphics g, Rectangle drawRect, float x_c, float y_c)
        {
            Pen pen = new Pen(Brushes.Black, 1f)
            {
                DashStyle = DashStyle.Dash,
                DashPattern = new float[] { 10.0F, 10.0F }
            };
            g.DrawLine(pen, new Point(drawRect.X, (int)y_c), new Point((int)x_c, (int)y_c));
            g.DrawLine(pen, new Point((int)x_c, drawRect.Height + drawRect.Y), new Point((int)x_c, (int)y_c));
        }

        public void LinePaint(Graphics g, Rectangle drawRect, float x_c, float y_c)
        {
            Pen pen = new Pen(Brushes.LightGray, 0.25f);
            g.DrawLine(pen, new Point(drawRect.X, (int)y_c), new Point(ClientSize.Width - drawRect.X, (int)y_c));
            g.DrawLine(pen, new Point((int)x_c, drawRect.Height + drawRect.Y), new Point((int)x_c, drawRect.Y));
        }

        public Rectangle BorderPaint(Graphics g)
        {
            var x0p = 15 + (int)Deviation;
            var y0p = 30;

            var rectWidth = ClientSize.Width - (2 * x0p);
            var rectHeight = ClientSize.Height - (2 * y0p);

            Rectangle drawRect = new Rectangle(x0p, y0p, rectWidth, rectHeight);
            g.DrawRectangle(SystemPens.ActiveBorder, drawRect);
            return drawRect;
        }

        public void TextPaint(Graphics g, string text, Point position, Font font)
        {
            SizeF messageSize = g.MeasureString(text, font);
            PointF p = new PointF(position.X - messageSize.Width / 2, position.Y - messageSize.Height / 2);

            g.DrawString(text, font, SystemBrushes.WindowText, p);
        }
        public void TitlePaint(Graphics g, string text, Point position)
        {
            SizeF messageSize = g.MeasureString(text, Font);
            PointF p = new PointF(position.X - messageSize.Width / 2, position.Y - messageSize.Height / 2);
            Font _TabFont = new Font(Font.FontFamily, (float)14, FontStyle.Regular, GraphicsUnit.Pixel);

            g.DrawString(text.Split(new char[] { ',' })[0], _TabFont, SystemBrushes.WindowText, p);
        }       
    }
}
