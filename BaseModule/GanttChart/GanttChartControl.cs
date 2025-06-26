using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.GanttChart
{
    public partial class GanttChartControl : UserControl
    {
        private GanttChartModel ganttChart;
        private Dictionary<TreeNode, int> mapTreeNodeToChartIndex;

        public GanttChartControl(IEnumerable<string> tasks)
        {
            InitializeComponent();

            var start = tasks.Select(t => t.Split(':')[1].Split(' ').GetLastByIndex(2)).Min(x => double.Parse(x));
            var end = tasks.Select(t => t.Split(':')[1].Split(' ').GetLastByIndex(1)).Max(x => double.Parse(x));

            ganttChart = new GanttChartModel(start, end, tasks.Count());
            mapTreeNodeToChartIndex = new Dictionary<TreeNode, int>();

            splitContainer.Panel2.Controls.Add(ganttChart.FormsPlot);
            AddTasks(tasks);
            ganttChart.Refresh();
        }

        private void AddTasks(IEnumerable<string> tasks)
        {
            var chartLayer = 1;
            foreach (var task in tasks)
            {
                var taskType = task.Split(':')[0].Trim();
                var description = task.Split(':')[1];

                if (!treeView.Nodes.ContainsKey(taskType))
                {
                    var groupNode = treeView.Nodes.Add(taskType, taskType);
                    groupNode.Checked = true;
                }
                var parent = treeView.Nodes[taskType];
                var node = parent.Nodes.Add(description);
                node.Checked = true;
                mapTreeNodeToChartIndex.Add(node, chartLayer);

                var start = double.Parse(description.Split(' ').GetLastByIndex(2));
                var end = double.Parse(description.Split(' ').GetLastByIndex(1));
                ganttChart.AddTask(start, end, chartLayer, taskType, MapTaskToColor(taskType));

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
                if (e.Node.Checked)
                {
                    ganttChart.ShowTask(layer);
                }
                else
                {
                    ganttChart.HideTask(layer);
                }
                ganttChart.Refresh();
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
