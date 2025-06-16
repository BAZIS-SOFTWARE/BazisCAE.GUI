using BaseModule.Interfaces;
using BaseModule.PropertiesPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using UserControlsEx;
using static BaseModule.Interfaces.GeneralParams;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.Navigator
{
    public enum ViewRegime : int { ribbers, surfaces, ribbersSurfaces };

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
        Нагрузка
    };

    public partial class NavigatorControl : UserControl, IPinnedControl
    {
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

        public event Action<NodeType, string> ShowObjectsEvent;
        public event Action<string, ViewRegime> ChangeObjectsViewEvent;
        public event Action<NodeType, string> HideObjectsEvent;
        public event Action<TreeNode> DelObjectsEvent;
        public event Action DelAllObjectsEvent;
        public event Action ControlCollapseEvent;
        public event Action ControlUnpinnedEvent;

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

        public void PresentModelInfo(ModelInfo modelInfo)
        {
            treeView.BeginUpdate();
            FillObjectsNodes(modelInfo);

            FillGroupsNodes(modelInfo);
            treeView.EndUpdate();
        }

        public void PresentGeneralInfo(GeneralInfo generalInfo)
        {
            SetProjectTitleInfo("названиеПроекта", "Название : " + generalInfo.Name);
            SetProjectTitleInfo("путь", "Путь : " + generalInfo.Path);
            SetProjectTitleInfo("сведения", "Сведения : " + generalInfo.Comments);
            SetProjectTitleInfo("вид", "Вид: " + generalInfo.TaskType);
        }

        private void FillGroupsNodes(ModelInfo modelInfo)
        {
            treeView.Nodes["группыОбъектов"].Nodes.Clear();
            treeView.Nodes["группыОбъектов"].Expand();

            foreach (var group in modelInfo.groups)
            {
                var text = $"{group.Name}";
                var imgIndex = ImgDict[group.NodeType];

                var child = new TreeNode(text, imgIndex, imgIndex)
                {
                    Tag = "5.1",
                    Name = group.NodeType.ToString()
                };
                SetContextMenu("группыОбъектов", child);
                treeView.Nodes["группыОбъектов"].Nodes.Add(child);
            }
        }

        private void FillObjectsNodes(ModelInfo modelInfo)
        {

            foreach (TreeNode item in treeView.Nodes["объекты"].Nodes)
                item.Nodes.Clear();

            treeView.Nodes["объекты"].Expand();


            foreach (var setInfo in modelInfo.sets)
            {
                var text = $"{setInfo.Name} : {setInfo.NumberOfObjects}";
                var imgIndex = ImgDict[setInfo.NodeType];
                imgIndex = imgIndex == 3 ? 5 : 6;
                var child = new TreeNode(text, imgIndex, imgIndex)
                {
                    Tag = "4.1.1",
                    Name = setInfo.NodeType.ToString()
                };
                SetContextMenu("объекты", child);

                var rootName = setInfo.NodeType.ToString();
                TreeNode rootNode;
                if (TrySearchNode(rootName, out rootNode))
                    rootNode.Nodes.Add(child);
            }
        }



        public void SetContextMenu(string root, TreeNode node)
        {
            if (root == "объекты")
                node.ContextMenuStrip = object_MenuStrip;
            else if (root == "группыОбъектов")
                if (node.ImageIndex == 3)
                    node.ContextMenuStrip = ndGroup_MenuStrip;
                else if (node.ImageIndex == 4)
                    node.ContextMenuStrip = elGroup_MenuStrip;
        }

        public TreeNode SearchChildNode(TreeNode startNode, string nodeName)
        {
            if (startNode != null)
            {
                //Using a queue to store and process each node in the TreeView
                Queue<TreeNode> staging = new Queue<TreeNode>();
                staging.Enqueue(startNode);

                while (staging.Count > 0)
                {
                    var treeNode = staging.Dequeue();

                    // Check the node.  
                    if (treeNode.Name == nodeName)
                        return treeNode;

                    foreach (TreeNode node in treeNode.Nodes)
                    {
                        staging.Enqueue(node);
                    }
                }
            }
            return null;
        }

        // Call the procedure using the TreeView.  
        public bool TrySearchNode(string nodeName, out TreeNode treeNode)
        {

            foreach (TreeNode n in treeView.Nodes)
            {
                var res = SearchChildNode(n, nodeName);
                if (res != null)
                {
                    treeNode = res;
                    return true;
                }

            }
            treeNode = null;
            return false;
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

        public void SetProjectTitleInfo(string titleKind, string text)
        {
            treeView.Nodes[titleKind].Text = text;
            treeView.Nodes[titleKind].ImageIndex = ProjectInfoIndex;
            treeView.Nodes[titleKind].SelectedImageIndex = ProjectInfoIndex;
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

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeType nodeType;
            Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            treeView.SelectedNode.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;

            ShowObjectsEvent?.Invoke(nodeType, node.Text);
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

        public void HideObjects_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            NodeType nodeType;
            Enum.TryParse(node.Name, out nodeType);

            treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            HideObjectsEvent?.Invoke(nodeType, node.Text);
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
            DelObjectsEvent?.Invoke(treeView.SelectedNode);
        }

        public void InfoGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            InfoGroupEvent?.Invoke(groupIndex);
        }

        public void ребраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeObjectsViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.ribbers);
        }

        public void поверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeObjectsViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.surfaces);
        }

        public void ребраИПоверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeObjectsViewEvent?.Invoke(treeView.SelectedNode.Name, ViewRegime.ribbersSurfaces);
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
    }
}
