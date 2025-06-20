using BaseModule.Interfaces;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.Navigator
{
    public enum ViewRegime : int { ribbers, surfaces, ribbersSurfaces };

    public enum NodeKind : int { real,virt}

    public enum NodeType : int 
    { 
        Точки, 
        Кривые, 
        Поверхности, 
        Объемы, 
        Узлы, 
        Элементы1D, 
        Элементы2D, 
        Элементы3D,
        Материал,
        Среда,
        Нагрев,
        Закрепление,
        Нагрузка,
        названиеПроекта,
        путь,
        сведения,
        вид
    };

    public partial class NavigatorControl : UserControl, IPinnedControl
    {
        private const string VIRTUALNODE = "VIRT";

        Dictionary<NodeType, int> ImgDict;

        [Category("General")]
        [Description("Set up color gradient")]
        public Color UpColor { get; set; } = Color.Silver;

        [Category("General")]
        [Description("Set down color gradient")]
        public Color DownColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set header name")]
        public string HeaderName { get; set; } = "Навигатор";

        [Category("treeView")]
        [Description("Set imageIndex for expand node")]
        public int ExpandIndex { get; set; } = 2;

        [Category("treeView")]
        [Description("Set imageIndex for collapse node")]
        public int CollapseIndex { get; set; } = 1;

        [Category("treeView")]
        [Description("Set imageIndex for project info nodes")]
        public int ProjectInfoIndex { get; set; } = 0;

        public event Action<string, string> RenameGroupEvent;

        public event Action<string> SelectGroupEvent;

        public event Action<TreeNode, SelectionType> AfterSelectEvent;

        public event Action<int> DelGroupEvent;
        public event Action DelAllGroupsEvent;
        public event Action<int> HideGroupEvent;
        public event Action<int> ShowGroupEvent;
        public event Action<int> EditGroupEvent;
        public event Action<int> InfoGroupEvent;
        public event Action<int> ShowGroupWithNodesEvent;
        public event Action ShowAllGroupsEvent;
        public event Action HideAllGroupsEvent;

        public event Action ShowAllObjectsEvent;
        public event Action HideAllObjectsEvent;

        public event Action<NodeType, string> ShowSetEvent;
        public event Action<string, ViewRegime> ChangeSetViewEvent;
        public event Action<NodeType, string> HideSetEvent;
        public event Action<NodeType, string> DelSetEvent;
        public event Action DelAllObjectsEvent;
        public event Action ControlCollapseEvent;
        public event Action ControlUnpinnedEvent;
        public event Action<string,string> GetObjectsInfoEvent;
        public event Action<string> GetSetsInfoEvent;

        public NavigatorControl()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(grbNavigator, true, null);

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

        public System.Windows.Forms.TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }

        public TreeNode CreateRealNode(string name, string text)
        {

            return new TreeNode(text) { Name = name };
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
            var nodes = new List<TreeNode>();
            if (TrySearchNode(root, nodes))
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
                if (node.ImageIndex == 3)
                    node.ContextMenuStrip = ndGroup_MenuStrip;
                else if (node.ImageIndex == 4)
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

        // Call the procedure using the TreeView.  
        public bool TrySearchNode(string nodeName, List<TreeNode> nodes)
        {
            foreach (TreeNode n in treeView.Nodes)
            {
                SearchNodeRec(n, nodeName, nodes);
                if (nodes.Count > 0)
                    break;
            }

            return nodes.Count != 0;
        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            treeView.LabelEdit = true;
            treeView.SelectedNode.BeginEdit();
        }

        public void ShowGroupWithNodes_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            treeView.Nodes["объекты"].Nodes["Узлы"].Nodes[0].ImageIndex = 5;
            treeView.Nodes["объекты"].Nodes["Узлы"].Nodes[0].SelectedImageIndex = 5;

            NodeType nodeType;
            Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            ShowGroupWithNodesEvent?.Invoke(groupIndex);
        }

        public void ShowAllGroups_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeView.Nodes[4].Nodes)
            {
                foreach (TreeNode node in item.Nodes)
                {
                    NodeType nodeType;
                    Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

                    node.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
                    node.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
                }
            }

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

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null || e.Label.Contains(" ") == true || e.Label == "")
                e.CancelEdit = true;
            else
            {
                var parentNode = treeView.SelectedNode.Parent;

                var newName = e.Label;
                var oldName = e.Node.Text;

                if (parentNode.Name == "группыОбъектов")
                {
                    var nodes = treeView.Nodes["группыОбъектов"].Nodes.Cast<TreeNode>().Where(x => x.Text == newName);
                    if (nodes.Count() > 0)
                        e.CancelEdit = true;
                    else
                    {
                        RenameGroupEvent?.Invoke(newName, oldName);

                        var dataNodes = treeView.Nodes.Find("Данные", true);

                        if (dataNodes.Count() != 0)
                            foreach (TreeNode node in dataNodes[0].Nodes)
                            {
                                if (node.Text.Contains(oldName))
                                    node.Text = node.Text.Replace(oldName, newName);
                            }
                    }
                }
            }

            treeView.LabelEdit = false;
        }

        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!treeView.LabelEdit)
                e.CancelEdit = true;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ContextMenuStrip != null)
                    e.Node.ContextMenuStrip.Show(e.Location);
            }
            else
            {
                if (e.Node.Tag?.ToString() == "5.1")
                    SelectGroupEvent?.Invoke(e.Node.Text);
            }
            treeView.SelectedNode = e.Node;
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

            NodeType nodeType;
            Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

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

        public void ShowAllObjects_Click(object sender, EventArgs e)
        {
            foreach (TreeNode objsNode in treeView.Nodes[4].Nodes)
            {
                foreach (TreeNode item in objsNode.Nodes)
                {
                    NodeType nodeType;
                    Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

                    item.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
                    item.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
                }
            }

            ShowAllObjectsEvent?.Invoke();
        }

        public void HideAllObjects_Click(object sender, EventArgs e)
        {
            foreach (TreeNode objsNode in treeView.Nodes[4].Nodes)
            {
                foreach (TreeNode item in objsNode.Nodes)
                {
                    NodeType nodeType;
                    Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

                    item.ImageIndex = ImgDict[nodeType];
                    item.SelectedImageIndex = ImgDict[nodeType];
                }
            }

            HideAllObjectsEvent?.Invoke();
        }

        public void HideAllGroups_Click(object sender, EventArgs e)
        {
            HideAllGroupsEvent?.Invoke();
        }

        public void HideSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeType nodeType;
            Enum.TryParse(node.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            HideSetEvent?.Invoke(nodeType, node.Text.Split(' ')[0]);
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

        public void DelObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            NodeType nodeType;
            Enum.TryParse(node.Parent.Name, out nodeType);

            DelSetEvent?.Invoke(nodeType, node.Text.Split(' ')[0]);
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

        private void grbNavigator_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = treeView.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, UpColor, DownColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString(HeaderName, ComponentsPainter.Font, new SolidBrush(System.Drawing.Color.Black), 15, 0);
        }

        private void grbNavigator_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > grbNavigator.Width - 16 & e.Location.X < grbNavigator.Width - 8 && e.Location.Y <= 10)
                ControlCollapseEvent?.Invoke();
        }

        private void grbNavigator_Resize(object sender, EventArgs e)
        {
            grbNavigator.Invalidate();
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

            if (node.Parent?.Parent == treeView.Nodes["объекты"])
            {
                SelectionType type = SelectionType.Object;
                AfterSelectEvent(node, type);
            }
            else if (node.Parent == treeView.Nodes["группыОбъектов"])
            {
                SelectionType type = SelectionType.Group;
                AfterSelectEvent(node, type);
            }
            else if (node.Parent == treeView.Nodes["Данные"])
            {
                SelectionType type = SelectionType.PhysicalData;
                AfterSelectEvent(node, type);
            }
        }

        private void treeVirt1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // If the node being expanded contains a virtual node then
            // we need to load this node's children on demand. If it doesn't
            // contain a virtual node then we already did it, so do nothing.

            if (e.Node.Nodes.ContainsKey(VIRTUALNODE))
            {
                try
                {
                    // Do some work to load data.
                    // Note this may take a while and could
                    // be annoying to your user.
                    // See asynchronous version below.
                    //Random r = new Random();
                    //Thread.Sleep(r.Next(200, 1200));

                    // Clear out all of the children
                    e.Node.Nodes.Clear();

                    if(e.Node.Name == NodeType.Узлы.ToString() |
                        e.Node.Name == NodeType.Элементы1D.ToString() |
                        e.Node.Name == NodeType.Элементы2D.ToString() |
                        e.Node.Name == NodeType.Элементы3D.ToString() |
                        e.Node.Name == NodeType.Точки.ToString() |
                        e.Node.Name == NodeType.Кривые.ToString() |
                        e.Node.Name == NodeType.Поверхности.ToString() |
                        e.Node.Name == NodeType.Объемы.ToString()
                        )
                        GetSetsInfoEvent?.Invoke(e.Node.Name);
                    else
                        GetObjectsInfoEvent?.Invoke(e.Node.Name, e.Node.Text.Split(' ')[0]);

                    // Load the new children into the treeview.
                    //string[] arrChildren = new string[] { "Grapes", "Apples", "Tomatoes", "Kiwi" };
                    //foreach (string sChild in arrChildren)
                    //{
                        // Be sure to add virtual nodes to new items that "may"
                        // have children.  If you know for sure that your item is
                        // a leaf node, then there's no need to add the virtual node.
                        //TreeNode tNode = e.Node.Nodes.Add(sChild);
                        //AddVirtualNode(tNode);
                    //}
                }
                catch
                {
                    // Error occured, reset to a known state
                    e.Node.Nodes.Clear();
                    //AddVirtualNode(e.Node);
                }
            }
        }
    }
}
