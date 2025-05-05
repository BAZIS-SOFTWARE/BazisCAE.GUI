using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

    public partial class GanttChartTreeView : UserControl
    {
        private GanttChartModel ganttChart;
        private Dictionary<TreeNode, int> mapTreeNodeToChartIndex;

        public GanttChartTreeView(IEnumerable<string> tasks, int timesteps)
        {
            InitializeComponent();

            var start = tasks.Select(t => t.Split(':')[1].Split(' ').GetLastByIndex(2)).Min(x => double.Parse(x));
            var end = tasks.Select(t => t.Split(' ')[1].Split(' ').GetLastByIndex(1)).Max(x => double.Parse(x));
            var interval = (end - start) / timesteps;

            ganttChart = new GanttChartModel(start, end, interval, tasks.Count());
            mapTreeNodeToChartIndex = new Dictionary<TreeNode, int>();

            ganttChart.Chart.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(ganttChart.Chart);

            AddTasks(tasks);
        }

        private void AddTasks(IEnumerable<string> tasks)
        {
            var chartLayer = 1;
            foreach(var task in tasks)
            {
                var dataKind = task.Split(':')[0];
                var description = task.Split(':')[1];

                if (!treeView.Nodes.ContainsKey(dataKind))
                {
                    var groupNode = treeView.Nodes.Add(dataKind, dataKind);
                    groupNode.Checked = true;
                }
                var parent = treeView.Nodes[dataKind];
                var node = parent.Nodes.Add(description);
                mapTreeNodeToChartIndex.Add(node, chartLayer);
                node.Checked = true;

                var start = double.Parse(description.Split(' ').GetLastByIndex(2));
                var end = double.Parse(description.Split(' ').GetLastByIndex(1));
                ganttChart.AddTask(start, end, chartLayer, dataKind, MapTaskToColor(dataKind), description);
                chartLayer++;
            }
        }

        private Color MapTaskToColor(string dataKind)
        {
            switch (dataKind)
            {
                case "Закрепление": return Color.FromArgb(194, 174, 95);
                case "Нагрев": return Color.FromArgb(194, 110, 96);
                case "Нагрузка": return Color.FromArgb(57, 157, 152);
                case "Материал": return Color.FromArgb(157, 57, 95);
                case "Среда": return Color.FromArgb(57, 157, 85);
                default: return Color.FromArgb(61, 81, 160);
            }
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!(sender is TreeView treeView))
                return;
            if (mapTreeNodeToChartIndex.TryGetValue(e.Node, out var layer))
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
