using BaseModule.Extensions;
using BaseModule.PinnedControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaseModule.Navigator
{
    //public enum ViewRegime : int { ribbers, surfaces, ribbersSurfaces };

    public enum NodeKind : int { real,virt}

    public enum NodeName : int 
    {
        проект,
        геометрия,

        Точки,
        Точка,
        Кривые,
        Кривая,
        Поверхности,
        Поверхность,
        Объемы,
        Объем,

        сетка,

        Узлы,
        Элементы1D,
        Элементы2D,
        Элементы3D,
        Узел,
        Элемент1D,
        Элемент2D,
        Элемент3D,

        группы,
        задача,

        Материал,
        Среда,
        Нагрев,
        Закрепление,
        Нагрузка,

        расчет,
        термическая,
        механическая,
        химическая,

        результаты,
        Результат,
        Время
    };


    public enum Priority : int { Низкий, НижеСреднего, Средний, ВышеСреднего, Высокий };

    public partial class NavigatorControl : PinnedPage
    {
        public TreeNode SelectedNode
        {
            get 
            {
                return treeView.SelectedNode; 
            }
        }

        public void SelectNode(TreeNode treeNode)
        {
            treeView.SelectedNode = treeNode;
        }

        private const string VIRTUALNODE = "VIRT";

        Dictionary<NodeName, int> ImgDict;

        [Category("treeView")]
        [Description("Set imageIndex for expand node")]
        public int ExpandIndex { get; set; } = 2;

        [Category("treeView")]
        [Description("Set imageIndex for collapse node")]
        public int CollapseIndex { get; set; } = 1;

        [Category("treeView")]
        [Description("Set imageIndex for project info nodes")]
        public int ProjectInfoIndex { get; set; } = 0;

        public event Action HideResultsEvent;
        public event Action RemoveResultsEvent;
        public event Action ShowGantChartEvent;
        public event Action RemoveAllConditionsEvent;

        public event Action DelAllGroupsEvent;
        public event Action ShowAllGroupsEvent;
        public event Action HideAllGroupsEvent;

        public event Action ShowAllObjectsEvent;
        public event Action HideAllObjectsEvent;
        public event Action DelAllObjectsEvent;

        public event Action<NodeName, string> ShowSetEvent;
        public event Action<NodeName, string> HideSetEvent;
        public event Action<NodeName, string> DelSetEvent;
        public event Action<NodeName, string> SelectSetEvent;
        public event Action<TreeNode> GetSetsInfoEvent;
        public event Action<int> SetElementsOrderEvent;

        public event Action<int> SelectGroupEvent;
        public event Action<int> DelGroupEvent;
        public event Action<int> HideGroupEvent;
        public event Action<int> ShowGroupEvent;
        public event Action<int> EditGroupEvent;
        public event Action<int> InfoGroupEvent;
        public event Action<int> ShowGroupWithNodesEvent;

        public event Action<int> GenerateMesh2DEvent;
        public event Action GenerateMesh3DEvent;

        public event Action<TreeNode> GetObjectsInfoEvent;
        public event Action<NodeName> DelObjectsEvent;
        public event Action<NodeName> ShowObjectsEvent;
        public event Action<NodeName> HideObjectsEvent;

        public event Action<NodeName, string, int> SelectObjectEvent;
        public event Action<NodeName, string, int> DelObjectEvent;
        public event Action<NodeName, string, int> GetObjectInfoEvent;
        public event Action<NodeName, string, int> ShowObjectEvent;
        public event Action<NodeName, string, int> HideObjectEvent;

        public event Action<NodeName, string> SelectCondEvent;
        public event Action SelectTaskEvent;
        public event Action SelectGeoEvent;
        public event Action SelectResultsEvent;
        public event Action LoadResultsEvent;
 
        public event Action<NodeName, string> SelectInstrEvent;
        public event Action SelectGeneralInfoEvent;
        public event Action<string, double> SelectTimeEvent;
        public event Action<NodeName, string> SelectResultEvent;

        public event Action<TreeNode> GetResultInfoEvent;

        public event Action<object,NodeName> AddConditionEvent;
        public event Action GenerateTSFEvent;
        public event Action GenerateTCFEvent;

        public event Action StopComputationEvent;
        public event Action<object, Priority> SetCompPriority;

        public event Action<object, string, List<double>> CreateAnimationEvent;

        public NavigatorControl()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(treeView, true, null);

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            ImgDict = new Dictionary<NodeName, int>()
            {
                { NodeName.Узлы,3},
                { NodeName.Точки,3},
                { NodeName.Кривые,4},
                { NodeName.Поверхности,4},
                { NodeName.Объемы,4},
                { NodeName.Элементы3D,4},
                { NodeName.Элементы2D,4},
                { NodeName.Элементы1D,4},
                { NodeName.Материал,8},
                { NodeName.Среда,9},
                { NodeName.Нагрев,10},
                { NodeName.Закрепление,11},
                { NodeName.Нагрузка,12}
            };

            treeView.Nodes[0].Expand();
        }

        public void SetObjectImageIndex(NodeName nodeType,int imgInd)
        {
            ImgDict[nodeType] = imgInd;
        }

        public int GetObjectImageIndex(NodeName nodeType)
        {
            return ImgDict[nodeType];
        }

        public TreeNode CreateRealNode(string name, string text)
        {
            return new TreeNode(text) { Name = name };
        }

        public TreeNode CreateRealNode(NodeName nodeType, string text)
        {
            return new TreeNode(text) { Name = nodeType.ToString() };
        }

        public TreeNode CreateVirtualNode(NodeName name)
        {
            var tVirt = new TreeNode("Loading...") { Name = name.ToString() };
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = Color.Blue;
            tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            return tVirt;
        }

        public TreeNode CreateVirtualNode(string name)
        {
            var tVirt = new TreeNode("Loading...") { Name = name };
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = Color.Blue;
            tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            return tVirt;
        }

        public TreeNode[] CreateRealNodes(string name, IEnumerable<string> text)
        {

            var childs = new TreeNode[text.Count()];
            var counter = 0;
            foreach (var item in text)
            {
                childs[counter++] = new TreeNode(item) 
                { 
                    Name = name, 
                };
            }

            return childs;
        }

        public void TryCreateNode(string root, string name,string text, NodeKind kind)
        {
    
            if (TrySearchNodes(root,out List<TreeNode>nodes))
            {
                if (kind == NodeKind.virt)
                {
                    var v = CreateVirtualNode(name);
                    nodes.First().Nodes.Add(v);
                }

                else
                {
                    var r = CreateRealNode(name, text);
                    nodes.First().Nodes.Add(r);
                }
            }

        }

        public void SetContextMenu(TreeNode node)
        {
            if (node.Parent.Name == NodeName.Точки.ToString() |
                node.Parent.Name == NodeName.Кривые.ToString() |
                node.Parent.Name == NodeName.Поверхности.ToString() |
                node.Parent.Name == NodeName.Объемы.ToString() |
                node.Parent.Name == NodeName.Узлы.ToString() |
                node.Parent.Name == NodeName.Элементы1D.ToString() |
                node.Parent.Name == NodeName.Элементы2D.ToString() |
                node.Parent.Name == NodeName.Элементы3D.ToString())
                node.ContextMenuStrip = set_MenuStrip;
            else if (node.Parent.Name == NodeName.группы.ToString())
                if (node.Name == NodeName.Узел.ToString())
                    node.ContextMenuStrip = ndGroup_MenuStrip;
                else if (node.Name == NodeName.Элемент1D.ToString() |
                    node.Name == NodeName.Элемент2D.ToString() |
                    node.Name == NodeName.Элемент3D.ToString())
                    node.ContextMenuStrip = elGroup_MenuStrip;
        }

        public void SearchNodeRec(TreeNode startNode, string nodeName, List<TreeNode> nodes)
        {
            foreach (TreeNode item in startNode.Nodes)
            {
                // Check the node.  
                if (item.Name == nodeName)
                    nodes.Add(item);
                else
                    SearchNodeRec(item, nodeName, nodes);
            }

        }

        /// <summary>
        /// TrySearchNode.First - res,Second - node
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public bool TrySearchNodes(string nodeName, out List<TreeNode> nodes)
        {
            nodes = new List<TreeNode>();

            foreach (TreeNode n in treeView.Nodes)
            {
                if (n.Name == nodeName)
                {
                    nodes.Add(n);
                    break;
                }
  
                SearchNodeRec(n, nodeName, nodes);
                if (nodes.Count > 0)
                    break;
            }

            return nodes.Count != 0;
        }

        public bool TrySearchNodes(NodeName nodeType, out List<TreeNode> nodes)
        {
            nodes = new List<TreeNode>();

            foreach (TreeNode n in treeView.Nodes)
            {
                if (n.Name == nodeType.ToString())
                {
                    nodes.Add(n);
                    break;
                }

                SearchNodeRec(n, nodeType.ToString(), nodes);
                if (nodes.Count > 0)
                    break;
            }

            return nodes.Count != 0;
        }

        public void ShowGroupWithNodes_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            //treeView.Nodes["объекты"].Nodes["Узлы"].Nodes[0].ImageIndex = 5;
            //treeView.Nodes["объекты"].Nodes["Узлы"].Nodes[0].SelectedImageIndex = 5;

            //NodeType nodeType;
            //Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            ShowGroupWithNodesEvent?.Invoke(groupIndex);
        }

        public void ShowAllGroups_Click(object sender, EventArgs e)
        {
            //foreach (TreeNode item in treeView.Nodes[4].Nodes)
            //{
            //    foreach (TreeNode node in item.Nodes)
            //    {
            //        NodeType nodeType;
            //        Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            //        node.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            //        node.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            //    }
            //}

            ShowAllGroupsEvent?.Invoke();
        }

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = CollapseIndex;
            e.Node.SelectedImageIndex = CollapseIndex;
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = ExpandIndex;
            e.Node.SelectedImageIndex = ExpandIndex;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView.SelectedNode = e.Node;

            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ContextMenuStrip != null)
                    e.Node.ContextMenuStrip.Show(e.Location);
            }
 
        }

        public void DelGroup_Click(object sender, EventArgs e)
        {
            var temp = treeView.SelectedNode;
            //var groupIndex = treeView.SelectedNode.Index;
            treeView.SelectedNode.Remove();
            DelGroupEvent?.Invoke(temp.Index);
            
            //DeleteTaskDataNodes(treeView.SelectedNode);
            //treeView.Nodes["группыОбъектов"].Nodes.RemoveAt(groupIndex);
        }

        private void HideGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            HideGroupEvent?.Invoke(groupIndex);
        }

        private void ShowGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            //NodeType nodeType;
            //Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            ShowGroupEvent?.Invoke(groupIndex);
        }

        public void ShowSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeName nodeType;
            Enum.TryParse(node.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;

            ShowSetEvent?.Invoke(nodeType, node.Text);
        }

        public void HideSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeName nodeType;
            Enum.TryParse(node?.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            HideSetEvent?.Invoke(nodeType, node.Text);
        }

        private void DelSet_Click(object sender, EventArgs e)
        {
            var temp = treeView.SelectedNode;
            var nodeType = temp.Parent.Name.ToEnum<NodeName>();
            treeView.SelectedNode.Remove();

            DelSetEvent?.Invoke(nodeType, temp.Text);
        }

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeName>();
            ShowObjectsEvent?.Invoke(nodeType);
        }

        public void DelObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeName>();
            DelObjectsEvent?.Invoke(nodeType);
        }

        public void HideObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeName>();
            HideObjectsEvent?.Invoke(nodeType);
        }

        public void HideAllGroups_Click(object sender, EventArgs e)
        {
            HideAllGroupsEvent?.Invoke();
        }

        public void EditGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            EditGroupEvent?.Invoke(groupIndex);
        }

        public void DelAllGroups_Click(object sender, EventArgs e)
        {
            DelAllGroupsEvent?.Invoke();
        }

        public void DelAllObjects_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeView.Nodes["объекты"].Nodes)
                item.Nodes.Clear();

            DelAllObjectsEvent?.Invoke();
        }



        public void InfoGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            InfoGroupEvent?.Invoke(groupIndex);
        }
        
        private void treeView_Enter(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                treeView.SelectedNode.BackColor = Color.Empty;
                treeView.SelectedNode.ForeColor = Color.Empty;
            }
        }

        private void treeView_Leave(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                treeView.SelectedNode.BackColor = SystemColors.ControlDark;
                treeView.SelectedNode.ForeColor = Color.White;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;

            if (e.Node.Level == 0)
                SelectGeneralInfoEvent?.Invoke();
            
            else if(e.Node.Level == 1)
            {
                if (node.Name == NodeName.геометрия.ToString())
                    SelectGeoEvent?.Invoke();
                else if (node.Name == NodeName.задача.ToString())
                    SelectTaskEvent?.Invoke();
                else if (node.Name == NodeName.результаты.ToString())
                    SelectResultsEvent?.Invoke();
            }

            else if (e.Node.Level == 2)
            {
                if (e.Node.Name == NodeName.Материал.ToString() |
e.Node.Name == NodeName.Среда.ToString() |
e.Node.Name == NodeName.Нагрев.ToString() |
e.Node.Name == NodeName.Нагрузка.ToString() |
e.Node.Name == NodeName.Закрепление.ToString()
)
                    SelectCondEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                else if (e.Node.Name == NodeName.термическая.ToString() |
e.Node.Name == NodeName.механическая.ToString() |
e.Node.Name == NodeName.химическая.ToString()
)
                {
                    SelectInstrEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                }
                else if (e.Node.Name == NodeName.Узел.ToString() |
e.Node.Name == NodeName.Элемент1D.ToString() |
e.Node.Name == NodeName.Элемент2D.ToString() |
e.Node.Name == NodeName.Элемент3D.ToString() |
e.Node.Name == NodeName.Точка.ToString() |
e.Node.Name == NodeName.Кривая.ToString() |
e.Node.Name == NodeName.Поверхность.ToString() |
e.Node.Name == NodeName.Объем.ToString()
)
                    SelectGroupEvent?.Invoke(e.Node.Index);
                else if (e.Node.Name == NodeName.Результат.ToString())
                    SelectResultEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
            }

            else if (e.Node.Level == 3)
            {
                if (e.Node.Parent.Name == NodeName.Узлы.ToString() |
e.Node.Parent.Name == NodeName.Элементы1D.ToString() |
e.Node.Parent.Name == NodeName.Элементы2D.ToString() |
e.Node.Parent.Name == NodeName.Элементы3D.ToString() |
e.Node.Parent.Name == NodeName.Точки.ToString() |
e.Node.Parent.Name == NodeName.Кривые.ToString() |
e.Node.Parent.Name == NodeName.Поверхности.ToString() |
e.Node.Parent.Name == NodeName.Объемы.ToString()
)
                    SelectSetEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                else if (e.Node.Name == NodeName.Время.ToString())
                    SelectTimeEvent?.Invoke(e.Node.Parent.Text, double.Parse(e.Node.Text));
            }

            else if (e.Node.Level == 4)
            {
                if (e.Node.Name == NodeName.Узел.ToString() |
e.Node.Name == NodeName.Элемент1D.ToString() |
e.Node.Name == NodeName.Элемент2D.ToString() |
e.Node.Name == NodeName.Элемент3D.ToString() |
e.Node.Name == NodeName.Точка.ToString() |
e.Node.Name == NodeName.Кривая.ToString() |
e.Node.Name == NodeName.Поверхность.ToString() |
e.Node.Name == NodeName.Объем.ToString()
)
                {
                    var set = node.Parent.Text.Split(' ')[0];
                    var number = int.Parse(node.Text.Split(' ')[0]);
                    SelectObjectEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), set, number);
                }

            }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // If the node being expanded contains a virtual node then
            // we need to load this node's children on demand. If it doesn't
            // contain a virtual node then we already did it, so do nothing.

            if (e.Node.Nodes.ContainsKey(VIRTUALNODE))
            {
                try
                {
                    // Clear out all of the children
                    e.Node.Nodes.Clear();

                    if(e.Node.Level == 1)
                    {

                    } 
                    else if(e.Node.Level == 2)
                    {
                        if (e.Node.Name == NodeName.Узлы.ToString() |
      e.Node.Name == NodeName.Элементы1D.ToString() |
      e.Node.Name == NodeName.Элементы2D.ToString() |
      e.Node.Name == NodeName.Элементы3D.ToString() |
      e.Node.Name == NodeName.Точки.ToString() |
      e.Node.Name == NodeName.Кривые.ToString() |
      e.Node.Name == NodeName.Поверхности.ToString() |
      e.Node.Name == NodeName.Объемы.ToString()
      )
                            GetSetsInfoEvent?.Invoke(e.Node);
                        else if (e.Node.Name == NodeName.Результат.ToString())
                            GetResultInfoEvent?.Invoke(e.Node);
                    }

                    else if(e.Node.Level == 3)
                        GetObjectsInfoEvent?.Invoke(e.Node);

                }
                catch
                {
                    // Error occured, reset to a known state
                    e.Node.Nodes.Clear();
                    //AddVirtualNode(e.Node);
                }
            }
        }

        public void BeginUpdate()
        {
            treeView.BeginUpdate();
        }

        public void EndUpdate()
        {
            treeView.EndUpdate();
        }

        private void низкийПриорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCompPriority?.Invoke(this, Priority.Низкий);
        }

        private void среднийПриорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCompPriority?.Invoke(this, Priority.Средний);
        }

        private void высокийПриорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCompPriority?.Invoke(this, Priority.Высокий);
        }

        private void сформироватьИнструкцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTSFEvent?.Invoke();
        }

        private void запуститьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTCFEvent?.Invoke();
        }

        private void остановитьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopComputationEvent?.Invoke();
        }

        private void скрытьРезToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideResultsEvent?.Invoke();
        }

        private void удалитьРезToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveResultsEvent?.Invoke();
        }

        private void diagram_gantt_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGantChartEvent?.Invoke();
        }

        private void материалToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeName.Материал);
        }

        private void закреплениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeName.Закрепление);
        }

        private void нагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeName.Нагрузка);
        }

        private void нагревToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeName.Нагрев);
        }

        private void средаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeName.Среда);
        }

        private void удалитьВсеУсловияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllConditionsEvent?.Invoke();
        }



        private void создатьАнимациюMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var list = new List<double>();

            foreach (TreeNode item in treeView.SelectedNode.Nodes)
                list.Add(double.Parse(item.Text));

            CreateAnimationEvent?.Invoke(this, node.Text, list);
        }

        private void удалитьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeName>();
            var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            DelObjectEvent?.Invoke(nodeType, set, number);
        }

        private void скрытьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeName>();
            var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            HideObjectEvent?.Invoke(nodeType, set, number);
        }

        private void показатьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeName>();
            var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            ShowObjectEvent?.Invoke(nodeType, set, number);
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //if ((e.State & TreeNodeStates.Selected) != 0)
            //{
                // Draw the background of the selected node. The NodeBounds
                // method makes the highlight rectangle large enough to
                // include the text of a node tag, if one is present.
                e.Graphics.FillRectangle(Brushes.White, NodeBounds(e.Node));

                // Retrieve the node font. If the node font has not been set,
                // use the TreeView font.
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                // Draw the node text.
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
                    Rectangle.Inflate(e.Bounds, 2, 0));
            //}

            // Use the default background and node text.
            //else
            //{
            //    e.DrawDefault = true;
            //}
        }

        // Returns the bounds of the specified node, including the region 
        // occupied by the node label and any node tag displayed.
        private Rectangle NodeBounds(TreeNode node)
        {
            // Set the return value to the normal node bounds.
            Rectangle bounds = node.Bounds;
            if (node.Tag != null)
            {
                // Retrieve a Graphics object from the TreeView handle
                // and use it to calculate the display width of the tag.
                Graphics g = CreateGraphics();
                int tagWidth = (int)g.MeasureString
                    (node.Tag.ToString(), Font).Width + 6;

                // Adjust the node bounds using the calculated value.
                bounds.Offset(tagWidth / 2, 0);
                bounds = Rectangle.Inflate(bounds, tagWidth / 2, 0);
                g.Dispose();
            }

            return bounds;
        }

        private void загрузитьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadResultsEvent?.Invoke();
        }

        private void SetFirstOrder_Click(object sender, EventArgs e)
        {
            SetElementsOrderEvent?.Invoke(1);
        }

        private void SetSecondOrder_Click(object sender, EventArgs e)
        {
            SetElementsOrderEvent?.Invoke(2);
        }

        private void треугольная2DMenuItem_Click(object sender, EventArgs e)
        {
            GenerateMesh2DEvent?.Invoke(3);
        }

        private void создать3DMenuItem_Click(object sender, EventArgs e)
        {
            GenerateMesh3DEvent?.Invoke();
        }
    }
}
