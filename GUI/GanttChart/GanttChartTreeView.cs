using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaseModule.GanttChart
{
    public partial class GanttChartTreeView : UserControl
    {
        private GanttChartModel ganttChart;
        private Dictionary<TreeNode, int> mapTreeNodeToChartIndex;

        public GanttChartTreeView(IEnumerable<ICondData> conditions)
        {
            InitializeComponent();

            var start = conditions.Min(c => c.StartTime);
            var end = conditions.Max(c => c.StopTime);

            ganttChart = new GanttChartModel(start, end);
            mapTreeNodeToChartIndex = new Dictionary<TreeNode, int>();

            ganttChart.Chart.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(ganttChart.Chart);

            AddConditions(conditions);
        }

        private void AddConditions(IEnumerable<ICondData> tasks)
        {
            var chartLayer = 1;
            foreach(var task in tasks)
            {
                var dataKind = task.Kind.ToString();
                var description = task.ToString();

                if (!treeView.Nodes.ContainsKey(dataKind))
                {
                    var groupNode = treeView.Nodes.Add(dataKind, dataKind);
                    groupNode.Checked = true;
                }

                var parent = treeView.Nodes[dataKind];
                var node = parent.Nodes.Add(description);
                mapTreeNodeToChartIndex.Add(node, chartLayer);
                node.Checked = true;
                var start = task.StartTime;
                var end = task.StopTime;
                ganttChart.AddTask(start, end, chartLayer, dataKind, MapConditionToColor(task), description);
                chartLayer++;
            }
        }

        private Color MapConditionToColor(ICondData condition)
        {
            switch (condition.Kind)
            {
                case DataKind.Закрепление: return Color.FromArgb(194, 174, 95);
                case DataKind.Нагрев: return Color.FromArgb(194, 110, 96);
                case DataKind.Нагрузка: return Color.FromArgb(57, 157, 152);
                case DataKind.Материал: return Color.FromArgb(157, 57, 95);
                case DataKind.Среда: return Color.FromArgb(57, 157, 85);
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
