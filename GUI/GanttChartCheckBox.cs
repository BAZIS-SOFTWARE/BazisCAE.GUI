using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GanttChart
{
    public partial class GanttChartCheckBox : UserControl
    {
        private GanttChartModel ganttChart;

        public GanttChartCheckBox(List<IValuableData> tasks, int timestamps)
        {
            InitializeComponent();
            var start = tasks.Select(t => t.StartTime).Min();
            var end = tasks.Select(t => t.StopTime).Max();
            var interval = (end - start) / timestamps;
            ganttChart = new GanttChartModel(start, end, interval, tasks.Count);
            ganttChart.Chart.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(ganttChart.Chart);

            ProcessTasks(tasks);
        }

        private void ProcessTasks(List<IValuableData> tasks)
        {
            for (var i = 0; i < tasks.Count(); i++)
            {
                ganttChart.AddTask(tasks[i].StartTime, tasks[i].StopTime, i + 1, tasks[i].Name, MapTaskToColor(tasks[i]));
                checkedListBox.Items.Add(tasks[i].Name, true);
            }
        }

        private Color MapTaskToColor(IValuableData task)
        {
            switch(task)
            {
                case ClampData _: return Color.FromArgb(56, 94, 157);
                case HeatData _: return Color.FromArgb(194, 110, 96);
                case LoadData _: return Color.FromArgb(57, 157, 152);
                case MatData _: return Color.FromArgb(157, 57, 95);
                case MediaData _: return Color.FromArgb(57, 157, 85);
                default: return Color.FromArgb(152, 57, 157);
            }
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckedListBox box))
                return;
            var index = box.SelectedIndex;
            ganttChart.InverseBarColor(index + 1);
        }

        private void checkedListBox_DoubleClick(object sender, EventArgs e)
        {
            checkedListBox_SelectedIndexChanged(sender, e);
        }
    }
}
