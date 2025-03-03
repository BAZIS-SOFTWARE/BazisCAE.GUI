using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace GanttChart
{
    public class GanttChart
    {
        public Chart Chart { get; private set; }

        public GanttChart(double minValue, double maxValue, double intervalLength, int barMaxCount)
        {
            Chart = new Chart();
            Chart.ChartAreas.Add(new ChartArea());
            ConfigureChart(minValue, maxValue, intervalLength, barMaxCount);
        }

        public void AddTask(double start, double end, int layer, string label, Color color)
        {
            var index = Chart.Series[0].Points.AddXY(layer, start, end);
            Chart.Series[0].Points[index].Color = color;
            Chart.Series[0].Points[index].BackSecondaryColor = Color.Transparent;
            Chart.Series[0].Points[index].AxisLabel = label;
        }

        public void HideTask(int index)
        {
            if (index >= 0 && index < Chart.Series[0].Points.Count)
            {
                var temp = Chart.Series[0].Points[index].Color;
                Chart.Series[0].Points[index].Color = Chart.Series[0].Points[index].BackSecondaryColor;
                Chart.Series[0].Points[index].BackSecondaryColor = temp;
            }
        }

        private void ConfigureChart(double minValue, double maxValue, double intervalLength, int barMaxCount)
        {
            var series = Chart.Series.Add("gantt diagram");
            series.ChartType = SeriesChartType.RangeBar;
            series.YValueType = ChartValueType.Double;

            var ax = Chart.ChartAreas[0].AxisX;
            ax.Minimum = 0;
            ax.Maximum = barMaxCount + 1;
            ax.MajorGrid.Enabled = false;
            ax.IsLabelAutoFit = true;
            ax.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;

            var ay = Chart.ChartAreas[0].AxisY;
            ay.Minimum = minValue;
            ay.Maximum = maxValue + intervalLength;
            ay.MajorGrid.Interval = intervalLength;
            ay.LabelStyle.Interval = intervalLength;
            ay.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
        }
    }
}
