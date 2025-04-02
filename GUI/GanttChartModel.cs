using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace BazisGUI
{
    public class GanttChartModel
    {
        public Chart Chart { get; private set; }

        private Color defaultLabelForeColor;

        public GanttChartModel(double minValue, double maxValue, double intervalLength, int barMaxCount)
        {
            Chart = new Chart();
            Chart.ChartAreas.Add(new ChartArea());
            defaultLabelForeColor = Color.Black;
            ConfigureChart(minValue, maxValue, intervalLength, barMaxCount);
        }

        public void AddTask(double start, double end, int layer, string name, Color color, string description = "")
        {
            var index = Chart.Series[0].Points.AddXY(layer, start, end);
            Chart.Series[0].Points[index].Color = color;
            Chart.Series[0].Points[index].BackSecondaryColor = Color.Transparent;
            Chart.Series[0].Points[index].AxisLabel = name;
            Chart.Series[0].Points[index].Label = description;
            Chart.Series[0].Points[index].LabelForeColor = defaultLabelForeColor;
        }

        public void InverseBarColor(int layer)
        {
            var index = layer - 1;
            if (index >= 0 && index < Chart.Series[0].Points.Count)
            {
                var bar = Chart.Series[0].Points[index];
                (bar.Color, bar.BackSecondaryColor) = (bar.BackSecondaryColor, bar.Color);
                bar.LabelForeColor = (bar.LabelForeColor == Color.Transparent) ? defaultLabelForeColor : Color.Transparent;
            }
        }

        private void ConfigureChart(double minValue, double maxValue, double intervalLength, int barMaxCount)
        {
            var series = Chart.Series.Add("gantt diagram");
            series.ChartType = SeriesChartType.RangeBar;
            series.YValueType = ChartValueType.Double;
            series.SetCustomProperty("PixelPointWidth", "30");

            ConfigureAxisX(barMaxCount);
            ConfigureAxisY(minValue, maxValue, intervalLength);
        }

        private void ConfigureAxisX(int barMaxCount)
        {
            var ax = Chart.ChartAreas[0].AxisX;
            ax.Minimum = 0;
            ax.Maximum = barMaxCount + 1;
            ax.MajorGrid.Enabled = false;
            ax.IsLabelAutoFit = true;
            ax.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            ax.ScaleView.Size = 8;
            ax.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            ax.ScrollBar.BackColor = Color.FromKnownColor(KnownColor.Control);
            ax.ScrollBar.ButtonColor = Color.FromKnownColor(KnownColor.Control);
            ax.ScrollBar.LineColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void ConfigureAxisY(double minValue, double maxValue, double intervalLength)
        {
            var ay = Chart.ChartAreas[0].AxisY;
            ay.Minimum = minValue;
            ay.Maximum = maxValue + intervalLength;
            ay.MajorGrid.Interval = intervalLength;
            ay.LabelStyle.Interval = intervalLength;
            ay.IsLabelAutoFit = true;
            ay.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
            ay.ScaleView.Size = 0.9 * maxValue;
            ay.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            ay.ScrollBar.BackColor = Color.FromKnownColor(KnownColor.Control);
            ay.ScrollBar.ButtonColor = Color.FromKnownColor(KnownColor.Control);
            ay.ScrollBar.LineColor = Color.FromKnownColor(KnownColor.Control);
        }
    }
}
