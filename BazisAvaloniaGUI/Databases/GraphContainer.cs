using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using Color = System.Drawing.Color;

namespace BazisAvaloniaGUI.Databases;

internal class GraphPoint(float x, float y)
{
    public float X { get; } = x;
    public float Y { get; } = y;
}
internal sealed class GraphData(string name, Color color, string xUnit, string yUnit, GraphPoint[] points)
{
    public string Name { get; } = name;
    public Color Color { get; } = color;
    public string XUnit { get; } = xUnit;
    public string YUnit { get; } = yUnit;
    public GraphPoint[] Points { get; } = points;
    public bool ValueFlag { get; set; }
    public float Thickness { get; set; } = 1;
}
internal enum StepFormat { normal, logarithmic }
internal sealed class AxisFormat
{
    public StepFormat StepFormat { get; set; }
    public int NumberOfSings { get; set; } = 2;
}

// The original graph assembly targets WinForms; draw its database series directly in Avalonia.
internal sealed class GraphContainer : Control
{
    public IReadOnlyList<GraphData> CurrentData { get; private set; } = [];
    public string Header { get; private set; }
    private AxisFormat xAxis = new(), yAxis = new();
    public void CreateGraphData(string header, List<GraphData> data, AxisFormat xFormat, AxisFormat yFormat)
    {
        Header = header; CurrentData = data; xAxis = xFormat; yAxis = yFormat; InvalidateVisual();
    }
    public override void Render(DrawingContext context)
    {
        base.Render(context);
        context.DrawRectangle(Brushes.White, null, new Rect(Bounds.Size));
        var points = CurrentData.SelectMany(d => d.Points).Where(p => float.IsFinite(p.X) && float.IsFinite(p.Y)).ToArray();
        if (points.Length == 0 || Bounds.Width < 120 || Bounds.Height < 100) return;
        var xmin = points.Min(p => p.X); var xmax = points.Max(p => p.X);
        var ymin = points.Min(p => p.Y); var ymax = points.Max(p => p.Y);
        var plot = new Rect(55, 30, Bounds.Width - 75, Bounds.Height - 80);
        Point Map(GraphPoint p) => new(plot.Left + (p.X - xmin) / Math.Max(xmax - xmin, 1e-8f) * plot.Width,
            plot.Bottom - (p.Y - ymin) / Math.Max(ymax - ymin, 1e-8f) * plot.Height);
        var axisPen = new Pen(Brushes.Black, 1);
        context.DrawLine(axisPen, plot.BottomLeft, plot.TopLeft);
        context.DrawLine(axisPen, plot.BottomLeft, plot.BottomRight);
        void Label(string value, Point origin) => context.DrawText(new FormattedText(value, System.Globalization.CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight, new Typeface("Microsoft Sans Serif"), 11, Brushes.Black), origin);
        Label(Header, new Point(55, 5));
        for (var i = 0; i <= 4; i++)
        {
            var x = xmin + (xmax - xmin) * i / 4; var y = ymin + (ymax - ymin) * i / 4;
            Label((xAxis.StepFormat == StepFormat.logarithmic ? Math.Pow(10, x) : x).ToString($"F{xAxis.NumberOfSings}"), new Point(plot.Left + plot.Width * i / 4, plot.Bottom + 4));
            Label(y.ToString($"F{yAxis.NumberOfSings}"), new Point(0, plot.Bottom - plot.Height * i / 4));
        }
        Label(CurrentData[0].XUnit, new Point(plot.Left, plot.Bottom + 25));
        Label(CurrentData[0].YUnit, new Point(0, 10));
        var legendY = 30.0;
        foreach (var series in CurrentData)
        {
            var brush = new SolidColorBrush(Avalonia.Media.Color.FromArgb(series.Color.A, series.Color.R, series.Color.G, series.Color.B));
            var pen = new Pen(brush, series.Thickness);
            var finite = series.Points.Where(p => float.IsFinite(p.X) && float.IsFinite(p.Y)).ToArray();
            for (var i = 1; i < finite.Length; i++) context.DrawLine(pen, Map(finite[i - 1]), Map(finite[i]));
            foreach (var point in finite) if (series.ValueFlag) context.DrawEllipse(brush, null, Map(point), 2, 2);
            context.DrawLine(pen, new Point(plot.Right - 140, legendY + 7), new Point(plot.Right - 125, legendY + 7));
            Label(series.Name, new Point(plot.Right - 120, legendY)); legendY += 16;
        }
    }
}
