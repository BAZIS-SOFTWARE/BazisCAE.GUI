using BaseModule.Extensions;
using BaseModule.PinnedControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using UserControlsEx;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        набор,
        объект,

        Узлы,
        Элементы1D,
        Элементы2D,
        Элементы3D,
        Узел,
        Элемент1D,
        Элемент2D,
        Элемент3D,

        группы,
        группа,

        задача,
        условие,

        Материал,
        Среда,
        Нагрев,
        Закрепление,
        Нагрузка,

        расчеты,
        расчет,

        результаты,
        результат,
        время
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
        
        public event Action RemoveAllConditionsEvent;

        public event Action DelAllGroupsEvent;
        public event Action ShowAllGroupsEvent;
        public event Action HideAllGroupsEvent;
        //public event Action SortGroupEvent;

        public event Action<bool> ChangeAllGeoViewStateEvent;
        public event Action DelAllGeoEvent;

        public event Action<int,bool> ShowMeshEvent;
        //public event Action<int> HideElementsEvent;
        public event Action<int> DelMeshEvent;
        public event Action DelAllMeshEvent;
        public event Action<bool> ChangeAllMeshViewStateEvent;
        //public event Action LoadMaterialsEvent;
        //public event Action LoadFunctionsEvent;

        public event Action ShowSetEvent;
        public event Action HideSetEvent;
        public event Action DelSetEvent;
        public event Action<NodeName, string> SelectSetEvent;
        public event Action<TreeNode> GetSetsInfoEvent;

        public event Action<int> SelectGroupEvent;
        public event Action DelGroupEvent;
        public event Action HideGroupEvent;
        public event Action ShowGroupEvent;
        public event Action<int> EditGroupEvent;
        public event Action<int> InfoGroupEvent;
        public event Action<int> ShowGroupWithNodesEvent;

        public event Action<TreeNode> GetObjectsInfoEvent;

        public event Action<NodeName, int> SelectObjectEvent;
        //public event Action ShowAdjacenciesEvent;
        //public event Action ShowAdjacenciesSetEvent;
        public event Action DelObjectEvent;
        public event Action<NodeName, string, int> GetObjectInfoEvent;
        public event Action ShowObjectEvent;
        public event Action HideObjectEvent;

        public event Action<NodeName, string> SelectCondEvent;
        public event Action SelectTaskEvent;
        public event Action SelectGeoEvent;
        public event Action SelectMeshEvent;
        public event Action SelectResultsEvent;
 
        public event Action<NodeName, string> SelectCompEvent;
        public event Action SelectCompsEvent;
        public event Action SelectGeneralInfoEvent;
        public event Action<string, double> SelectTimeEvent;
        public event Action<NodeName, string> SelectResultEvent;

        public event Action<TreeNode> GetResultInfoEvent;
        public event Action DelCondEvent;

        public event Action<object, string, List<double>> CreateAnimationEvent;

        public NavigatorControl()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(treeView, true, null);

            showMeshMenuItem.DropDown.Closing += SplitButton_Closing;
            hideMeshMenuItem.DropDown.Closing += SplitButton_Closing;
            delMeshMenuItem.DropDown.Closing += SplitButton_Closing;

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            ImgDict = new Dictionary<NodeName, int>()
            {
                { NodeName.Узлы,3},
                { NodeName.Точки,3},
                { NodeName.Кривые,7},
                { NodeName.Поверхности,7},
                { NodeName.Объемы,7},
                { NodeName.Элементы3D,4},
                { NodeName.Элементы2D,4},
                { NodeName.Элементы1D,4},
                { NodeName.Материал,8},
                { NodeName.Среда,9},
                { NodeName.Нагрев,10},
                { NodeName.Закрепление,11},
                { NodeName.Нагрузка,12},
                { NodeName.сетка,14},
                { NodeName.геометрия,14}
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
            //tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            return tVirt;
        }

        public TreeNode CreateVirtualNode(string name)
        {
            var tVirt = new TreeNode("Loading...") { Name = name };
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = Color.Blue;
            //tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            return tVirt;
        }

        public TreeNode CreateVirtualNode()
        {
            var tVirt = new TreeNode("Loading...");
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = Color.Blue;
            //tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
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

        public void ActionMenu(TreeNode node, int actIndex)
        {
            if (node.Name == NodeName.результаты.ToString())
            {
                if (actIndex == 0)
                    RemoveResultsEvent?.Invoke();
                else if (actIndex == 1)
                    HideResultsEvent?.Invoke();
            }

            //node.ContextMenuStrip = resultsMenuStrip;
            else if (node.Name == NodeName.задача.ToString())
            {
                if (actIndex == 0)
                    RemoveAllConditionsEvent?.Invoke();
            }
            else if (node.Name == NodeName.условие.ToString())
            {
                if (actIndex == 0)
                    DelCondEvent?.Invoke();
            }
            //node.ContextMenuStrip = taskMenuStrip;
            else if (node.Name == NodeName.геометрия.ToString())
            {
                if (actIndex == 0)
                    DelAllGeoEvent?.Invoke();
                else if (actIndex == 1)
                    ChangeAllGeoViewStateEvent?.Invoke(false);
                else if (actIndex == 2)
                    ChangeAllGeoViewStateEvent?.Invoke(true);
            }
                //node.ContextMenuStrip = geoMenuStrip;
            else if (node.Name == NodeName.сетка.ToString())
            {
                if (actIndex == 0)
                    DelAllMeshEvent?.Invoke();
                else if (actIndex == 1)
                    ChangeAllMeshViewStateEvent?.Invoke(false);
                else if (actIndex == 2)
                    ChangeAllMeshViewStateEvent?.Invoke(true);
            }

            else if (node.Name == NodeName.набор.ToString())
            {
                if (actIndex == 0)
                    DelSetEvent?.Invoke();
                else if (actIndex == 1)
                    ShowSetEvent?.Invoke();
                else if (actIndex == 2)
                    HideSetEvent?.Invoke();
            }
            else if (node.Name == NodeName.объект.ToString())
            {
                if (actIndex == 0)
                    DelObjectEvent?.Invoke();
                else if (actIndex == 1)
                    ShowObjectEvent?.Invoke();
                else if (actIndex == 2)
                    HideObjectEvent?.Invoke();
            }
            //node.ContextMenuStrip = meshMenuStrip;
            else if (node.Name == NodeName.группы.ToString())
            {
                if (actIndex == 0)
                    DelAllGroupsEvent?.Invoke();
                else if (actIndex == 1)
                    ShowAllGroupsEvent?.Invoke();
                else if (actIndex == 2)
                    HideAllGroupsEvent?.Invoke();
            }

            else if (node.Name == NodeName.группа.ToString())
            {
                if (actIndex == 0)
                    DelGroupEvent?.Invoke();
                else if (actIndex == 1)
                    ShowGroupEvent?.Invoke();
                else if (actIndex == 2)
                    HideGroupEvent?.Invoke();
            }
        }

        public void SetContextMenu(TreeNode node)
        {
    //        if (node.Name == NodeName.результаты.ToString())
    //            node.ContextMenuStrip = resultsMenuStrip;
    //        else if (node.Name == NodeName.задача.ToString())
    //            node.ContextMenuStrip = taskMenuStrip;
    //        else if (node.Name == NodeName.геометрия.ToString())
    //            node.ContextMenuStrip = geoMenuStrip;
    //        else if (node.Name == NodeName.сетка.ToString())
    //            node.ContextMenuStrip = meshMenuStrip;
    //        else if (node.Name == NodeName.группы.ToString())
    //            node.ContextMenuStrip = groups_MenuStrip;
    //        //else if (node.Name == NodeName.расчеты.ToString())
    //        //    node.ContextMenuStrip = compMenuStrip;


    //        else if (node.Name == NodeName.Точки.ToString() |
    //            node.Name == NodeName.Кривые.ToString() |
    //            node.Name == NodeName.Поверхности.ToString() |
    //            node.Name == NodeName.Объемы.ToString() |
    //            node.Name == NodeName.Узлы.ToString() |
    //            node.Name == NodeName.Элементы1D.ToString() |
    //            node.Name == NodeName.Элементы2D.ToString() |
    //            node.Name == NodeName.Элементы3D.ToString())
    //        {
    //            if (node.Parent.Name == NodeName.сетка.ToString())
    //                node.ContextMenuStrip = set_MenuStrip;
    //            else if (node.Parent.Name == NodeName.геометрия.ToString())
    //                node.ContextMenuStrip = set_MenuStrip;
    //            else if (node.Parent.Name == NodeName.группы.ToString())
    //            {
    //                if (node.Name == NodeName.Узлы.ToString())
    //                    node.ContextMenuStrip = ndGroup_MenuStrip;
    //                else if (node.Name == NodeName.Элементы1D.ToString() |
    //                    node.Name == NodeName.Элементы2D.ToString() |
    //                    node.Name == NodeName.Элементы3D.ToString())
    //                    node.ContextMenuStrip = elGroup_MenuStrip;
    //            }

    //        }

    //        else if (node.Name == NodeName.Точка.ToString() |
    //node.Name == NodeName.Кривая.ToString() |
    //node.Name == NodeName.Поверхность.ToString() |
    //node.Name == NodeName.Объем.ToString() |
    //node.Name == NodeName.Узел.ToString() |
    //node.Name == NodeName.Элемент1D.ToString() |
    //node.Name == NodeName.Элемент2D.ToString() |
    //node.Name == NodeName.Элемент3D.ToString())
    //        {
    //            node.ContextMenuStrip = objectMenuStrip;
    //        }


    //        else if (node.Parent.Name == NodeName.задача.ToString())
    //            node.ContextMenuStrip = condMenuStrip;
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

            var show = treeNodesImageList_16x16.Images[18];
            var hide = treeNodesImageList_16x16.Images[17];
            var del = treeNodesImageList_16x16.Images[19];



            var shift = del.Width + 20;
            if(e.X > treeView.Width - shift & e.X < treeView.Width)
            {
                // удалить
            }
            shift += hide.Width + 4;
            if (e.X > treeView.Width - shift & e.X < treeView.Width)
            {
                // скрыть
            }
            shift += show.Width + 4;
            if (e.X > treeView.Width - shift & e.X < treeView.Width)
            {
                // показать
            }

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
            //DelGroupEvent?.Invoke(temp.Index);
            
            //DeleteTaskDataNodes(treeView.SelectedNode);
            //treeView.Nodes["группыОбъектов"].Nodes.RemoveAt(groupIndex);
        }

        private void HideGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            //HideGroupEvent?.Invoke(groupIndex);
        }

        private void ShowGroup_Click(object sender, EventArgs e)
        {
            var groupIndex = treeView.SelectedNode.Index;

            //NodeType nodeType;
            //Enum.TryParse(treeView.SelectedNode.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            //ShowGroupEvent?.Invoke(groupIndex);
        }

        public void ShowSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeName = treeView.SelectedNode.Name.ToEnum<NodeName>();

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType] == 3 ? 5 : 6;

            //ShowSetEvent?.Invoke(nodeName, node.Text);
        }

        public void HideSet_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;

            var nodeName = treeView.SelectedNode.Name.ToEnum<NodeName>();
            //Enum.TryParse(node?.Parent.Name, out nodeType);

            //treeView.SelectedNode.ImageIndex = ImgDict[nodeType];
            //treeView.SelectedNode.SelectedImageIndex = ImgDict[nodeType];

            //HideSetEvent?.Invoke(nodeName, node.Text);
        }

        private void DelSet_Click(object sender, EventArgs e)
        {
            var temp = treeView.SelectedNode;
            var nodeName = treeView.SelectedNode.Name.ToEnum<NodeName>();
            //treeView.SelectedNode.Remove();

            //DelSetEvent?.Invoke(nodeName, temp.Text);
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
                treeView.SelectedNode.ForeColor = Color.Black;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            //node..BackColor = System.Drawing.Color.LightBlue;

            if (e.Node.Level == 0)
            {
                if (node.Name == NodeName.проект.ToString())
                    SelectGeneralInfoEvent?.Invoke();
                else if (node.Name == NodeName.результаты.ToString())
                    SelectResultsEvent?.Invoke();
            }           
            
            else if(e.Node.Level == 1)
            {
                if (node.Name == NodeName.геометрия.ToString())
                    SelectGeoEvent?.Invoke();
                else if (node.Name == NodeName.сетка.ToString())
                    SelectMeshEvent?.Invoke();
                else if (node.Name == NodeName.задача.ToString())
                    SelectTaskEvent?.Invoke();
                else if (node.Name == NodeName.результаты.ToString())
                    SelectResultsEvent?.Invoke();
                else if (node.Name == NodeName.расчеты.ToString()) 
                    SelectCompsEvent?.Invoke();
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
                else if (e.Node.Name == NodeName.расчет.ToString())
                {
                    SelectCompEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                }
                else if (e.Node.Name == NodeName.Узлы.ToString() |
e.Node.Name == NodeName.Элементы1D.ToString() |
e.Node.Name == NodeName.Элементы2D.ToString() |
e.Node.Name == NodeName.Элементы3D.ToString() |
e.Node.Name == NodeName.Точки.ToString() |
e.Node.Name == NodeName.Кривые.ToString() |
e.Node.Name == NodeName.Поверхности.ToString() |
e.Node.Name == NodeName.Объемы.ToString()
)
                {
                    if(e.Node.Parent.Name == NodeName.группы.ToString())
                        SelectGroupEvent?.Invoke(e.Node.Index);
                    else
                        SelectSetEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                }    
 
                else if (e.Node.Name == NodeName.результат.ToString())
                    SelectResultEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
            }

            //else if (e.Node.Level == 3)
            //{
//                if (e.Node.Parent.Name == NodeName.Узлы.ToString() |
//e.Node.Parent.Name == NodeName.Элементы1D.ToString() |
//e.Node.Parent.Name == NodeName.Элементы2D.ToString() |
//e.Node.Parent.Name == NodeName.Элементы3D.ToString() |
//e.Node.Parent.Name == NodeName.Точки.ToString() |
//e.Node.Parent.Name == NodeName.Кривые.ToString() |
//e.Node.Parent.Name == NodeName.Поверхности.ToString() |
//e.Node.Parent.Name == NodeName.Объемы.ToString()
//)
//                    SelectSetEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), e.Node.Text);
                //else if (e.Node.Name == NodeName.Время.ToString())
                    //SelectTimeEvent?.Invoke(e.Node.Parent.Text, double.Parse(e.Node.Text));
            //}

            else if (e.Node.Level == 3)
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
                    var number = int.Parse(node.Text.Split(' ')[0]);
                    SelectObjectEvent?.Invoke(e.Node.Name.ToEnum<NodeName>(), number);
                }
                else if (e.Node.Name == NodeName.время.ToString())
                    SelectTimeEvent?.Invoke(e.Node.Parent.Text, double.Parse(e.Node.Text));
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
                        if(e.Node.Name == NodeName.сетка.ToString() |
                            e.Node.Name == NodeName.геометрия.ToString())
                            GetSetsInfoEvent?.Invoke(e.Node);
                    } 
                    //else if(e.Node.Level == 2)
                    //{
                        // !!!!Пока посмотрим как будет работать если все наборы будут в одной куче
      //
      //                  if (e.Node.Name == NodeName.Узлы.ToString() |
      //e.Node.Name == NodeName.Элементы1D.ToString() |
      //e.Node.Name == NodeName.Элементы2D.ToString() |
      //e.Node.Name == NodeName.Элементы3D.ToString() |
      //e.Node.Name == NodeName.Точки.ToString() |
      //e.Node.Name == NodeName.Кривые.ToString() |
      //e.Node.Name == NodeName.Поверхности.ToString() |
      //e.Node.Name == NodeName.Объемы.ToString()
      //)
      //                      GetSetsInfoEvent?.Invoke(e.Node);

                    //}

                    else if(e.Node.Level == 2)
                        if (e.Node.Name == NodeName.результат.ToString())
                            GetResultInfoEvent?.Invoke(e.Node);
                        else
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

        private void скрытьРезToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideResultsEvent?.Invoke();
        }

        private void удалитьРезToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveResultsEvent?.Invoke();
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
            var nodeType = node.Name.ToEnum<NodeName>();
            //var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            //DelObjectEvent?.Invoke(nodeType, number);
        }

        private void скрытьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Name.ToEnum<NodeName>();
            //var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            //HideObjectEvent?.Invoke(nodeType, number);
        }

        private void показатьОбъектMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView.SelectedNode;
            var nodeType = node.Name.ToEnum<NodeName>();
            //var set = node.Parent.Nodes[0].Text.Split(' ')[0];
            var number = int.Parse(node.Text.Split(' ')[0]);
            //ShowObjectEvent?.Invoke(nodeType, number);
        }

        // Draws a node.
        private void treeView_DrawNode(
            object sender, DrawTreeNodeEventArgs e)
        {
            var nodeFont = e.Node.NodeFont;
            if (nodeFont == null)
                nodeFont = treeView.Font;

            var textS = 3;

            // Draw the background and node text for a selected node.
            if ((e.State & TreeNodeStates.Focused | e.State & TreeNodeStates.Selected) != 0)
            {
                // Draw the node text.
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
                    e.Node.Bounds.X, e.Node.Bounds.Y + textS);
            }

            // Use the default background and node text.
            else
            {
                // выделяем узел который хранит выделение прозрачным прямоугольником
                if (treeView.SelectedNode != null & e.Node == treeView.SelectedNode)
                {
                    var brush = new SolidBrush(Color.FromArgb(100, 0, 1, 1));
                    e.Graphics.FillRectangle(brush, 0, e.Node.Bounds.Y,
                    treeView.Width, e.Node.Bounds.Height);
                }

                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
e.Node.Bounds.X, e.Node.Bounds.Y + textS);

            }

            // рисуем дополнительные иконки
            DrawImages(e);

        }

        private void DrawImages(DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level > 0) // Assuming you store the image in the node's Tag property
            {

                var show = treeNodesImageList_16x16.Images[18];
                var hide = treeNodesImageList_16x16.Images[17];
                var del = treeNodesImageList_16x16.Images[19];

                // Calculate the position for the image after the text
                // You might need to adjust the X and Y coordinates based on your desired layout
                float imageX = e.Bounds.Right + 5; // 5 pixels right of the node's bounds
                float imageY = e.Bounds.Y + (e.Bounds.Height - show.Height) / 2; // Vertically center the image

                // Draw the images
                var shift = del.Width + 20;
                e.Graphics.DrawImage(del, treeView.Width - shift, imageY, del.Width, del.Height);
                shift += hide.Width + 4;
                e.Graphics.DrawImage(hide, treeView.Width - shift, imageY, hide.Width, hide.Height);
                shift += show.Width + 4;
                e.Graphics.DrawImage(show, treeView.Width - shift, imageY, show.Width, show.Height);
            }
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

        private void удалитьУсловиеMenuItem_Click(object sender, EventArgs e)
        {
            DelCondEvent?.Invoke();
        }

        private void скрытьГеометриюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAllGeoViewStateEvent?.Invoke(false);
        }


        private void удалитьГеометриюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelAllGeoEvent?.Invoke();
        }

        private void показатьГеометриюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAllGeoViewStateEvent?.Invoke(true);
        }

        private void показатьСмежныеНаборыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowAdjacenciesSetEvent?.Invoke();
        }

        private void show1DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(1,true);
        }

        private void show2DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(2, true);
        }

        private void show3DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(3, true);
        }

        private void hide1DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(1, false);
        }

        private void hide2DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(2, false);
        }

        private void hide3DMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(3, false);
        }

        private void del1DMenuItem_Click(object sender, EventArgs e)
        {
            DelMeshEvent?.Invoke(1);
        }

        private void del2DMenuItem_Click(object sender, EventArgs e)
        {
            DelMeshEvent?.Invoke(2);
        }

        private void del3DMenuItem_Click(object sender, EventArgs e)
        {
            DelMeshEvent?.Invoke(3);
        }

        private void nodeHideMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(0, false);
        }

        private void nodeShowMenuItem_Click(object sender, EventArgs e)
        {
            ShowMeshEvent?.Invoke(0, true);
        }

        private void SplitButton_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }
    }
}
