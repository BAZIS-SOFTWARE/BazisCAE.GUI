using BaseModule.Extensions;
using BaseModule.Interfaces;
using BaseModule.PinnedControl;
using BaseModule.PropertiesPanel;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using UserControlsEx;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Navigator
{
    public enum ViewRegime : int { ribbers, surfaces, ribbersSurfaces };

    public enum NodeKind : int { real,virt}

    public enum NodeType : int 
    {
        объекты,
        Точки, 
        Кривые, 
        Поверхности, 
        Объемы,
        Точка,
        Кривая,
        Поверхность,
        Объем,
        Узлы, 
        Элементы1D, 
        Элементы2D, 
        Элементы3D,
        Узел,
        Элемент1D,
        Элемент2D,
        Элемент3D,

        условия,
        Материал,
        Среда,
        Нагрев,
        Закрепление,
        Нагрузка,

        //названиеПроекта,
        //путь,
        //сведения,
        вид,
        тип,
        базаФункций,
        базаМатериалов,

        задачи,
        Тепловая,
        Механическая,
        Химическая,

        результаты,
        Результат,
        Время
    };

    public enum Priority : int { Низкий, НижеСреднего, Средний, ВышеСреднего, Высокий };

    public partial class NavigatorControl : PinnedPage
    {
        private const string VIRTUALNODE = "VIRT";

        Dictionary<NodeType, int> ImgDict;

        [Category("treeView")]
        [Description("Set imageIndex for expand node")]
        public int ExpandIndex { get; set; } = 2;

        [Category("treeView")]
        [Description("Set imageIndex for collapse node")]
        public int CollapseIndex { get; set; } = 1;

        [Category("treeView")]
        [Description("Set imageIndex for project info nodes")]
        public int ProjectInfoIndex { get; set; } = 0;

        public TreeNode GetSelectedNode()
        {
             return treeView.SelectedNode;
        }
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

        public event Action<string, ViewRegime> ChangeSetViewEvent;
        public event Action<NodeType, string> ShowSetEvent;
        public event Action<NodeType, string> HideSetEvent;
        public event Action<NodeType, string> DelSetEvent;
        public event Action<NodeType, string> SelectSetEvent;

        public event Action<int> SelectGroupEvent;
        public event Action<int> DelGroupEvent;
        public event Action<int> HideGroupEvent;
        public event Action<int> ShowGroupEvent;
        public event Action<int> EditGroupEvent;
        public event Action<int> InfoGroupEvent;
        public event Action<int> ShowGroupWithNodesEvent;

        public event Action<NodeType, string> GetObjectsInfoEvent;
        public event Action<NodeType> DelObjectsEvent;
        public event Action<NodeType> ShowObjectsEvent;
        public event Action<NodeType> HideObjectsEvent;

        public event Action<NodeType, string, int> SelectObjectEvent;
        public event Action<NodeType, string, int> DelObjectEvent;
        public event Action<NodeType, string, int> GetObjectInfoEvent;
        public event Action<NodeType, string, int> ShowObjectEvent;
        public event Action<NodeType, string, int> HideObjectEvent;

        public event Action<NodeType, string> SelectCondEvent;
        public event Action<NodeType, string> SelectTaskEvent;
        public event Action<NodeType, string> SelectGeneralInfoEvent;
        public event Action<string, double> SelectTimeEvent;

        public event Action<NodeType> GetSetsInfoEvent;
        public event Action<string> GetResultInfoEvent;

        public event Action<object,NodeType> AddConditionEvent;
        public event Action GenerateTSFEvent;
        public event Action GenerateTCFEvent;

        public event Action StopComputationEvent;
        public event Action<object, Priority> SetCompPriority;

        public event Action<object, string, List<string>> CreateAnimationEvent;

        public NavigatorControl()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(treeView, true, null);

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            ImgDict = new Dictionary<NodeType, int>()
            {
                { NodeType.Узлы,3},
                { NodeType.Точки,3},
                { NodeType.Кривые,4},
                { NodeType.Поверхности,4},
                { NodeType.Объемы,4},
                { NodeType.Элементы3D,4},
                { NodeType.Элементы2D,4},
                { NodeType.Элементы1D,4},
                { NodeType.Материал,8},
                { NodeType.Среда,9},
                { NodeType.Нагрев,10},
                { NodeType.Закрепление,11},
                { NodeType.Нагрузка,12}
            };
        }

        public void SetObjectImageIndex(NodeType nodeType,int imgInd)
        {
            ImgDict[nodeType] = imgInd;
        }

        public int GetObjectImageIndex(NodeType nodeType)
        {
            return ImgDict[nodeType];
        }

        public TreeNode CreateRealNode(string name, string text)
        {
            return new TreeNode(text) { Name = name };
        }

        public TreeNode CreateRealNode(NodeType nodeType, string text)
        {
            return new TreeNode(text) { Name = nodeType.ToString() };
        }

        public TreeNode CreateVirtualNode(NodeType name)
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
            if (node.Parent.Name == NodeType.Точки.ToString() |
                node.Parent.Name == NodeType.Кривые.ToString() |
                node.Parent.Name == NodeType.Поверхности.ToString() |
                node.Parent.Name == NodeType.Объемы.ToString() |
                node.Parent.Name == NodeType.Узлы.ToString() |
                node.Parent.Name == NodeType.Элементы1D.ToString() |
                node.Parent.Name == NodeType.Элементы2D.ToString() |
                node.Parent.Name == NodeType.Элементы3D.ToString())
                node.ContextMenuStrip = set_MenuStrip;
            else if (node.Parent.Name == "группыОбъектов")
                if (node.Name == NodeType.Узел.ToString())
                    node.ContextMenuStrip = ndGroup_MenuStrip;
                else if (node.Name == NodeType.Элемент1D.ToString() |
                    node.Name == NodeType.Элемент2D.ToString() |
                    node.Name == NodeType.Элемент3D.ToString())
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

        public bool TrySearchNodes(NodeType nodeType, out List<TreeNode> nodes)
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
            //var groupIndex = treeView.SelectedNode.Index;

            DelGroupEvent?.Invoke(treeView.SelectedNode.Index);
            treeView.SelectedNode.Remove();
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

            NodeType nodeType;
            Enum.TryParse(node.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;

            ShowSetEvent?.Invoke(nodeType, node.Text.Split(' ')[0]);
        }

        public void HideSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeType nodeType;
            Enum.TryParse(node?.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            HideSetEvent?.Invoke(nodeType, node?.Text.Split(' ')[0]);
        }

        private void DelSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeType>();

            DelSetEvent?.Invoke(nodeType, node.Text.Split(' ')[0]);
        }

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeType>();

            if (nodeType == NodeType.объекты)
                ShowAllObjectsEvent?.Invoke();
            else
                ShowObjectsEvent?.Invoke(nodeType);
        }

        public void DelObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeType>();

            if (nodeType == NodeType.объекты)
                DelAllObjectsEvent?.Invoke();
            else
                DelObjectsEvent?.Invoke(nodeType);
        }

        public void HideObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeType = node.Name.ToEnum<NodeType>();

            if (nodeType == NodeType.объекты)
                HideAllObjectsEvent?.Invoke();
            else
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
            treeView.Nodes["группыОбъектов"].Nodes.Clear();
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

        public void ребраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSetViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.ribbers);
        }

        public void поверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSetViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.surfaces);
        }

        public void ребраИПоверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSetViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.ribbersSurfaces);
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
            {
                if (e.Node.Name == NodeType.базаФункций.ToString() |
                    e.Node.Name == NodeType.базаМатериалов.ToString() |
                    e.Node.Name == NodeType.тип.ToString() |
                    e.Node.Name == NodeType.вид.ToString()
)
                    SelectGeneralInfoEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), e.Node.Text);
            }

            else if (e.Node.Level == 1)
            {
                if (e.Node.Name == NodeType.Материал.ToString() |
e.Node.Name == NodeType.Среда.ToString() |
e.Node.Name == NodeType.Нагрев.ToString() |
e.Node.Name == NodeType.Нагрузка.ToString() |
e.Node.Name == NodeType.Закрепление.ToString()
)
                    SelectCondEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), e.Node.Text);
                else if (e.Node.Name == NodeType.Тепловая.ToString() |
e.Node.Name == NodeType.Механическая.ToString() |
e.Node.Name == NodeType.Химическая.ToString()
)
                {
                    SelectTaskEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), e.Node.Text);
                }
                else if (e.Node.Name == NodeType.Узел.ToString() |
e.Node.Name == NodeType.Элемент1D.ToString() |
e.Node.Name == NodeType.Элемент2D.ToString() |
e.Node.Name == NodeType.Элемент3D.ToString() |
e.Node.Name == NodeType.Точка.ToString() |
e.Node.Name == NodeType.Кривая.ToString() |
e.Node.Name == NodeType.Поверхность.ToString() |
e.Node.Name == NodeType.Объем.ToString()
)
                    SelectGroupEvent?.Invoke(e.Node.Index);
            }

            else if (e.Node.Level == 2)
            {
                if (e.Node.Parent.Name == NodeType.Узлы.ToString() |
e.Node.Parent.Name == NodeType.Элементы1D.ToString() |
e.Node.Parent.Name == NodeType.Элементы2D.ToString() |
e.Node.Parent.Name == NodeType.Элементы3D.ToString() |
e.Node.Parent.Name == NodeType.Точки.ToString() |
e.Node.Parent.Name == NodeType.Кривые.ToString() |
e.Node.Parent.Name == NodeType.Поверхности.ToString() |
e.Node.Parent.Name == NodeType.Объемы.ToString()
)
                    SelectSetEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), e.Node.Text);
                else if (e.Node.Name == NodeType.Время.ToString())
                    SelectTimeEvent?.Invoke(e.Node.Parent.Text, double.Parse(e.Node.Text));
            }

            else if (e.Node.Level == 3)
            {
                if (e.Node.Name == NodeType.Узел.ToString() |
e.Node.Name == NodeType.Элемент1D.ToString() |
e.Node.Name == NodeType.Элемент2D.ToString() |
e.Node.Name == NodeType.Элемент3D.ToString() |
e.Node.Name == NodeType.Точка.ToString() |
e.Node.Name == NodeType.Кривая.ToString() |
e.Node.Name == NodeType.Поверхность.ToString() |
e.Node.Name == NodeType.Объем.ToString()
)
                {
                    var set = node.Parent.Text.Split(' ')[0];
                    var number = int.Parse(node.Text.Split(' ')[0]);
                    SelectObjectEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), set, number);
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

                    //if(e.Node.Level == 1)
                    //{
                    //    if (e.Node.Name == NodeType.Результат.ToString())
                    //        GetResultInfoEvent?.Invoke(e.Node.Text);
                    //}

                    if(e.Node.Level == 1)
                    {
                        if (e.Node.Name == NodeType.Узлы.ToString() |
    e.Node.Name == NodeType.Элементы1D.ToString() |
    e.Node.Name == NodeType.Элементы2D.ToString() |
    e.Node.Name == NodeType.Элементы3D.ToString() |
    e.Node.Name == NodeType.Точки.ToString() |
    e.Node.Name == NodeType.Кривые.ToString() |
    e.Node.Name == NodeType.Поверхности.ToString() |
    e.Node.Name == NodeType.Объемы.ToString()
    )
                            GetSetsInfoEvent?.Invoke(e.Node.Name.ToEnum<NodeType>());
                        else if (e.Node.Name == NodeType.Результат.ToString())
                            GetResultInfoEvent?.Invoke(e.Node.Text);
                    } 
                    else if(e.Node.Level == 2)
                                                
                                GetObjectsInfoEvent?.Invoke(e.Node.Name.ToEnum<NodeType>(), e.Node.Text.Split(' ')[0]);

                }
                catch
                {
                    // Error occured, reset to a known state
                    e.Node.Nodes.Clear();
                    //AddVirtualNode(e.Node);
                }
            }
        }

        public void PresentCompDataOnTree(List<string> compData)
        {
            BeginUpdate();
            TrySearchNodes(NodeType.задачи.ToString(), out List<TreeNode> tasks);

            tasks[0].Nodes.Clear();

            foreach (var item in compData)
            {
                var r = CreateRealNode("расчет", item);

                tasks[0].Nodes.Add(r);
            }

            EndUpdate();
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
            AddConditionEvent?.Invoke(this, NodeType.Материал);
        }

        private void закреплениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeType.Закрепление);
        }

        private void нагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeType.Нагрузка);
        }

        private void нагревToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeType.Нагрев);
        }

        private void средаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionEvent?.Invoke(this, NodeType.Среда);
        }

        private void удалитьВсеУсловияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllConditionsEvent?.Invoke();
        }



        private void создатьАнимациюMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var list = new List<string>();

            foreach (TreeNode item in treeView.SelectedNode.Nodes)
                list.Add(item.Text);

            CreateAnimationEvent?.Invoke(this, node.Text, list);
        }

        private void удалитьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeType>();
            var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            DelObjectEvent?.Invoke(nodeType, set, number);
        }

        private void скрытьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeType>();
            var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            HideObjectEvent?.Invoke(nodeType, set, number);
        }

        private void показатьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Parent.Name.ToEnum<NodeType>();
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
    }
}
