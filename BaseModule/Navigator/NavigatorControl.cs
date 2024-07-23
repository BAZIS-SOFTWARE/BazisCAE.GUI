using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.Navigator
{
    public enum ViewRegime : int { ribbers, surfaces, ribbersSurfaces };
    public partial class NavigatorControl : UserControl
    {
        Dictionary<string, int> imgDict;

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

        public event Action<string> ShowObjectsEvent;
        public event Action<string, ViewRegime> ChangeObjectsViewEvent;
        public event Action<string> HideObjectsEvent;
        public event Action<string> DelObjectsEvent;
        public event Action NavigatorPanelCollapseEvent;
        public NavigatorControl()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(grbNavigator, true, null);     

        imgDict = new Dictionary<string, int>()
            {
                { "Узел",3},
                { "Точка",3},
                { "Линия",4},
                { "Фигура2D",4},
                { "Фигура3D",4},
                { "Элемент3D",4},
                { "Элемент2D",4},
                { "Элемент1D",4},
                { "Материал",8},
                { "Среда",9},
                { "Нагрев",10},
                { "Закрепление",11},
                { "Нагрузка",12},
                { "Расчет",13}

            };
        }

        public TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }


        public bool CreateChildNode(string root, string name, string text, string tag)
        {
            var node = new TreeNode()
            {
                Name = name,
                Text = text,

                ImageIndex = imgDict.ContainsKey(name) ? imgDict[name] : 0,
                SelectedImageIndex = imgDict.ContainsKey(name) ? imgDict[name] : 0,

                Tag = tag
            };

            if(root == "объекты")
                node.ContextMenuStrip = object_MenuStrip;
            else if (root == "группыОбъектов")
                if (imgDict[name] == 3)
                    node.ContextMenuStrip = ndGroup_MenuStrip;
                else if (imgDict[name] == 4)
                    node.ContextMenuStrip = elGroup_MenuStrip;

            var rootNode = CallNonRecursiveSearch(root);

            if (rootNode == null)
                return false;
            else
                rootNode.Nodes.Add(node);

            return true;
        }

        public TreeNode SearchNonRecursive(TreeNode startNode, string nodeName)
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
        private TreeNode CallNonRecursiveSearch(string nodeName)
        {
            // Print each node.
            foreach (TreeNode n in treeView.Nodes)
            {
                var res = SearchNonRecursive(n, nodeName);
                if (res != null)
                    return res;
            }
            return null;
        }

        public void ShowObjectsNode(string objsType)
        {
            treeView.Nodes["объекты"].Nodes[objsType].ImageIndex = imgDict[objsType] == 3 ? 5 : 6;
            treeView.Nodes["объекты"].Nodes[objsType].SelectedImageIndex = imgDict[objsType] == 3 ? 5 : 6;
        }

        public void HideObjectsNode(string objsType)
        {
            treeView.Nodes["объекты"].Nodes[objsType].ImageIndex = imgDict[objsType];
            treeView.Nodes["объекты"].Nodes[objsType].SelectedImageIndex = imgDict[objsType];
        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            treeView.LabelEdit = true;
            treeView.SelectedNode.BeginEdit();
        }

        public void ShowGroupWithNodes_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            treeView.Nodes["объекты"].Nodes[ObjType.Узел.ToString()].ImageIndex = 5;
            treeView.Nodes["объекты"].Nodes[ObjType.Узел.ToString()].SelectedImageIndex = 5;

            treeView.SelectedNode.ImageIndex = imgDict[treeView.SelectedNode.Name];
            treeView.SelectedNode.SelectedImageIndex = imgDict[treeView.SelectedNode.Name];

            ShowGroupWithNodesEvent?.Invoke(groupIndex);
        }

        public void ShowAllGroups_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeView.Nodes[4].Nodes)
            {
                item.ImageIndex = imgDict[item.Name] == 3 ? 5 : 6;
                item.SelectedImageIndex = imgDict[item.Name] == 3 ? 5 : 6;
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
                    if(nodes.Count() > 0)
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
                if (e.Node.Tag.ToString() == "5.1")
                    SelectGroupEvent?.Invoke(e.Node.Text);
            }
            treeView.SelectedNode = e.Node;
        }

        public void DelGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            DelGroupEvent?.Invoke(groupIndex);

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

            treeView.SelectedNode.ImageIndex = imgDict[treeView.SelectedNode.Name];
            treeView.SelectedNode.SelectedImageIndex = imgDict[treeView.SelectedNode.Name];

            ShowGroupEvent?.Invoke(groupIndex);
        }

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            var objsName = treeView.SelectedNode.Name;

            treeView.SelectedNode.ImageIndex = imgDict[objsName] == 3 ? 5 : 6;
            treeView.SelectedNode.SelectedImageIndex = imgDict[objsName] == 3 ? 5 : 6;

            ShowObjectsEvent?.Invoke(objsName);
        }

        public void ShowAllObjects_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeView.Nodes[4].Nodes)
            {
                item.ImageIndex = imgDict[item.Name] == 3 ? 5 : 6;
                item.SelectedImageIndex = imgDict[item.Name] == 3 ? 5 : 6;
            }

            ShowAllObjectsEvent?.Invoke();
        }

        public void HideAllObjects_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in treeView.Nodes[4].Nodes)
            {
                item.ImageIndex = imgDict[item.Name];
                item.SelectedImageIndex = imgDict[item.Name];
            }

            HideAllObjectsEvent?.Invoke();
        }

        public void HideAllGroups_Click(object sender, EventArgs e)
        {
            HideAllGroupsEvent?.Invoke();
        }

        public void HideObjects_Click(object sender, EventArgs e)
        {
            var objsName = treeView.SelectedNode.Name;

            treeView.Nodes["объекты"].Nodes[objsName].ImageIndex = imgDict[objsName];
            treeView.Nodes["объекты"].Nodes[objsName].SelectedImageIndex = imgDict[objsName];

            HideObjectsEvent?.Invoke(objsName);
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
            DelObjectsEvent?.Invoke("Объект");
        }

        public void DelObjects_Click(object sender, EventArgs e)
        {
            DelObjectsEvent?.Invoke(treeView.SelectedNode.Name);
            //DelObjects(treeView.SelectedNode);
            //treeView.Nodes["объекты"].Nodes.Remove(treeView.SelectedNode);
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

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0),Width, loc_y,UpColor,DownColor);
            
            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString(HeaderName, ComponentsPainter.Font, new SolidBrush(System.Drawing.Color.Black), 15, 0);
        }

        private void grbNavigator_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > grbNavigator.Width - 16 & e.Location.X < grbNavigator.Width - 8 && e.Location.Y <= 10)
                NavigatorPanelCollapseEvent?.Invoke();
        }

        private void grbNavigator_Resize(object sender, EventArgs e)
        {
            grbNavigator.Invalidate();
        }
    }
}
