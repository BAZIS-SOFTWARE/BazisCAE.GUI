using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GanttChart
{
    public partial class GanttChartTreeView : UserControl
    {
        private GanttChartModel ganttChart;
        private Dictionary<TreeNode, int> mapTreeViewIndexToChartIndex;

        public GanttChartTreeView(List<IValuableData> tasks, int timestamps)
        {
            InitializeComponent();

            var start = tasks.Select(t => t.StartTime).Min();
            var end = tasks.Select(t => t.StopTime).Max();
            var interval = (end - start) / timestamps;

            ganttChart = new GanttChartModel(start, end, interval, tasks.Count);
            mapTreeViewIndexToChartIndex = new Dictionary<TreeNode, int>();

            ganttChart.Chart.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(ganttChart.Chart);

            ProcessTasks(tasks);
        }

        private void ProcessTasks(List<IValuableData> tasks)
        {
            var chartLayer = 1;
            for (var i = 0; i < tasks.Count(); i++)
            {
                var groupName = tasks[i].Name.Split('-')[0];
                var fullName = tasks[i].Name;

                if (!treeView.Nodes.ContainsKey(groupName))
                {
                    var groupNode = treeView.Nodes.Add(groupName, groupName);
                    groupNode.Checked = true;
                }

                var parent = treeView.Nodes[groupName];
                var node = parent.Nodes.Add(fullName);
                mapTreeViewIndexToChartIndex.Add(node, chartLayer);
                node.Checked = true;

                ganttChart.AddTask(tasks[i].StartTime, tasks[i].StopTime, chartLayer, fullName, MapTaskToColor(tasks[i]));
                chartLayer++;
            }
        }

        private Color MapTaskToColor(IValuableData task)
        {
            switch (task)
            {
                case ClampData _: return Color.FromArgb(56, 94, 157);
                case HeatData _: return Color.FromArgb(194, 110, 96);
                case LoadData _: return Color.FromArgb(57, 157, 152);
                case MatData _: return Color.FromArgb(157, 57, 95);
                case MediaData _: return Color.FromArgb(57, 157, 85);
                default: return Color.FromArgb(152, 57, 157);
            }
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!(sender is TreeView treeView))
                return;
            if (mapTreeViewIndexToChartIndex.TryGetValue(e.Node, out var layer))
            {
                ganttChart.InverseBarColor(layer);
            }
            else
            {
                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    if (childNode.Checked != e.Node.Checked)
                        childNode.Checked = e.Node.Checked;
                }
            }
        }
    }
}
