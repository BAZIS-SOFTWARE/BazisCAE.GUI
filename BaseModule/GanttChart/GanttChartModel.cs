using ScottPlot;
using ScottPlot.TickGenerators;
using ScottPlot.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaseModule.GanttChart
{
    public static class ListExtension
    {
        public static T GetLastByIndex<T>(this IList<T> source, int index)
        {
            return source[source.Count - 1 - index];
        }
    }

    public class GanttChartModel
    {
        public FormsPlot FormsPlot { get; }

        private Plot plot;
        private Bar[] bars;
        private Tick[] ticks;
        private System.Drawing.Color[] colors;
        private double maxValue;

        public GanttChartModel(double minValue, double maxValue, int barMaxCount)
        {
            FormsPlot = new FormsPlot() { Dock = DockStyle.Fill };
            FormsPlot.UserInputProcessor.RemoveAll<ScottPlot.Interactivity.UserActionResponses.MouseDragZoomRectangle>();
            FormsPlot.UserInputProcessor.RemoveAll<ScottPlot.Interactivity.UserActionResponses.MouseDragPan>();
            FormsPlot.UserInputProcessor.RemoveAll<ScottPlot.Interactivity.UserActionResponses.MouseDragZoom>();
            FormsPlot.UserInputProcessor.RemoveAll<ScottPlot.Interactivity.UserActionResponses.MouseWheelZoom>();
            plot = FormsPlot.Plot;
            bars = new Bar[barMaxCount + 1];
            ticks = new Tick[barMaxCount + 1];
            colors = new System.Drawing.Color[barMaxCount + 1];
            this.maxValue = maxValue;
        }

        public void AddTask(double start, double end, int layer, string taskType, System.Drawing.Color color)
        {
            var bar = new Bar() 
            { 
                Orientation = ScottPlot.Orientation.Horizontal, 
                Value = end, 
                ValueBase = start, 
                FillColor = ScottPlot.Color.FromColor(color),
                Position = layer,
                Size = 0.5,
                LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Transparent)
            };
            ticks[layer] = new Tick(layer, taskType);
            bars[layer] = bar;
            colors[layer] = color;
            plot.Add.Bar(bar);
        }

        public void Refresh()
        {
            plot.Axes.Left.TickGenerator = new NumericManual(ticks);
            FormsPlot.Refresh();
        }

        public Bitmap GetImage(int width, int height)
        {
            plot.Axes.Left.TickGenerator = new NumericManual(ticks);
            return plot.GetImage(width, height).GetBitmap();
        }

        public void HideTask(int layer)
        {
            bars[layer].FillColor = ScottPlot.Color.FromColor(System.Drawing.Color.Transparent);
        }

        public void ShowTask(int layer)
        {
            bars[layer].FillColor = ScottPlot.Color.FromColor(colors[layer]);
        }
    }
}
