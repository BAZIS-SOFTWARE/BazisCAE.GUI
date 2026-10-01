using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Extensions;
using BazisAvaloniaGUI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using DrawingColor = System.Drawing.Color;

namespace BazisAvaloniaGUI.Navigator
{
    public enum NodeKind : int { real, virt }
    public enum NodeName : int
    {
        Project,
        Geometry,
        Mesh,

        Sets,
        Objects,

        Groups,
        NodesGroup,
        ElementsGroup,

        Task,
        Material,
        Media,
        Heat,
        Clamp,
        Load,

        Calculations,
        Calculation,

        Results,
        Result,
        Time
    }

    internal sealed class NavigatorControl : UserControl
    {
        // Avalonia: перекрывает StyledElement.Resources, чтобы Resources.X ссылался на строковые ресурсы.
        private new class Resources : Localization.Resources { }

        public TreeNode SelectedNode
        {
            get
            {
                return (treeView.SelectedItem as TreeViewItem)?.Tag as TreeNode;
            }
        }

        public void SelectNode(TreeNode treeNode)
        {
            treeView.SelectedItem = treeNode?.Item;
        }

        private const string VIRTUALNODE = "VIRT";

        Dictionary<NodeName, int> genImgDict;
        Dictionary<NodeName, int[]> helpImgDict;

        public int ExpandIndex { get; set; } = 8;

        public int CollapseIndex { get; set; } = 7;

        public int ProjectInfoIndex { get; set; } = 0;
        public bool DrawNodeFrozen { get; set; }

        public event Action HideResultsEvent;
        public event Action RemoveResultsEvent;

        public event Action RemoveAllConditionsEvent;

        public event Action DelAllGroupsEvent;
        public event Action ShowAllGroupsEvent;
        public event Action HideAllGroupsEvent;

        public event Action<bool> ChangeAllGeoViewStateEvent;
        public event Action DelAllGeoEvent;

        public event Action DelAllMeshEvent;
        public event Action<bool> ChangeAllMeshViewStateEvent;

        public event Action ShowSetEvent;
        public event Action HideSetEvent;
        public event Action DelSetEvent;
        public event Action<string> SelectSetEvent;
        public event Action<TreeNode> GetSetsInfoEvent;

        public event Action<int> SelectGroupEvent;
        public event Action DelGroupEvent;
        public event Action HideGroupEvent;
        public event Action ShowGroupEvent;
        public event Action EditGroupEvent;
        public event Action InfoGroupEvent;

        public event Action<TreeNode> GetObjectsInfoEvent;

        public event Action<string, int> SelectObjectEvent;
        public event Action DelObjectEvent;
        public event Action<NodeName, string, int> GetObjectInfoEvent;
        public event Action ShowObjectEvent;
        public event Action HideObjectEvent;

        public event Action<int> SelectCondEvent;
        public event Action SelectTaskEvent;
        public event Action SelectGeoEvent;
        public event Action SelectMeshEvent;
        public event Action SelectResultsEvent;

        public event Action<string> SelectCompEvent;
        public event Action SelectCompsEvent;
        public event Action SelectGeneralInfoEvent;
        public event Action<string, double> SelectTimeEvent;
        public event Action<string> SelectResultEvent;

        public event Action<TreeNode> GetResultInfoEvent;
        public event Action DelCondEvent;

        // Avalonia: TreeView вместо System.Windows.Forms.TreeView; дополнительные иконки
        // действий рисуются отдельным слоем поверх выбранного узла (аналог DrawImages).
        private readonly TreeView treeView = new()
        {
            Background = Brush.Parse("#F0F0F0"),
            FontFamily = new FontFamily("Microsoft Sans Serif"),
            FontSize = 10.6667 // WinForms treeView: 8 pt at 96 DPI
        };
        private readonly Grid viewport = new();
        private readonly Canvas actionLayer = new();
        private readonly StackPanel visibleActions = new() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
        private readonly Border actionOverlay = new();
        private readonly Dictionary<int, Bitmap> imageList = new();
        private readonly Dictionary<int, Bitmap> helpImageList_loc = new();
        private ScrollViewer scrollViewer;

        public TreeNodeCollection Nodes { get; }

        public NavigatorControl()
        {
            InitializeComponent();
            Nodes = new TreeNodeCollection(treeView.Items, null) { OwnerControl = this };

            genImgDict = new Dictionary<NodeName, int>()
            {
                { NodeName.Project, 7 },
                { NodeName.Mesh,7},
                { NodeName.Geometry,7},
                { NodeName.Material,2},
                { NodeName.Media,3},
                { NodeName.Heat,4},
                { NodeName.Clamp,5},
                { NodeName.Load,6},
                { NodeName.Results,7},
                { NodeName.Calculations,7},
                { NodeName.Calculation,9},
                { NodeName.Result,7},
                { NodeName.Time,9},
                { NodeName.Task,7},
                { NodeName.Groups,7},
                { NodeName.NodesGroup,0},
                { NodeName.ElementsGroup,1},
                { NodeName.Sets,7},
                { NodeName.Objects,9}
            };

            helpImgDict = new Dictionary<NodeName, int[]>()
            {
                { NodeName.Mesh,new []{ 2,3,4} },
                { NodeName.Geometry,new []{ 2, 3, 4 } },
                { NodeName.Material,new []{ 4} },
                { NodeName.Media,new []{ 4}},
                { NodeName.Heat,new []{ 4}},
                { NodeName.Clamp,new []{ 4}},
                { NodeName.Load,new []{ 4}},
                { NodeName.Results,new []{ 3,4}},
                { NodeName.Result,new int[0]},
                { NodeName.Time,new int[0]},
                { NodeName.Calculations,new int [0]},
                { NodeName.Calculation,new int [0]},
                { NodeName.Task,new []{4} },
                { NodeName.Groups,new []{ 2,3,4}},
                { NodeName.NodesGroup,new []{ 0,1,2,3,4}},
                { NodeName.ElementsGroup,new []{ 0,1,2,3,4}},
                { NodeName.Objects,new []{ 2,3,4}},
                { NodeName.Sets,new []{ 2,3,4}},
            };

            var node = CreateRealNode(NodeName.Project, Resources.Navigator_TreeView_Node_Text_Project);
            Nodes.Clear();
            Nodes.Add(node);
            Nodes[0].Expand();
        }

        public int GetObjectImageIndex(NodeName nodeType)
        {
            return genImgDict[nodeType];
        }

        public TreeNode CreateRealNode(NodeName nodeName)
        {
            return new TreeNode(Localization.Localization.GetNavigatorNodeNameLocalization(nodeName)) { Name = nodeName.ToString(), ImageIndex = GetObjectImageIndex(nodeName) };
        }

        public TreeNode CreateRealNode(NodeName nodeName, string text)
        {
            var imgIndex = GetObjectImageIndex(nodeName);
            return new TreeNode(text)
            {
                Name = nodeName.ToString(),
                ImageIndex = imgIndex,
                SelectedImageIndex = imgIndex
            };
        }

        public TreeNode CreateVirtualNode(NodeName name)
        {
            var tVirt = new TreeNode("Loading...") { Name = name.ToString() };
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = DrawingColor.Blue;
            return tVirt;
        }

        public TreeNode CreateVirtualNode()
        {
            var tVirt = new TreeNode("Loading...");
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = DrawingColor.Blue;
            return tVirt;
        }

        public TreeNode[] CreateRealNodes(NodeName nodeName, IEnumerable<string> text)
        {

            var childs = new TreeNode[text.Count()];
            var counter = 0;
            foreach (var item in text)
            {
                var imgIndex = GetObjectImageIndex(nodeName);
                childs[counter++] = new TreeNode(item)
                {
                    Name = nodeName.ToString(),
                    ImageIndex = imgIndex,
                    SelectedImageIndex = imgIndex
                };
            }

            return childs;
        }

        public void ActionMenu(TreeNode node, int actIndex)
        {
            var nodeName = node.Name.ToEnum<NodeName>();
            if (nodeName == NodeName.Results)
            {
                if (actIndex == 0)
                    HideResultsEvent?.Invoke();
                else if (actIndex == 1)
                    RemoveResultsEvent?.Invoke();

            }

            else if (nodeName == NodeName.Task)
            {
                if (actIndex == 0)
                    RemoveAllConditionsEvent?.Invoke();
            }
            else if (nodeName == NodeName.Material |
                    nodeName == NodeName.Media |
                    nodeName == NodeName.Heat |
                    nodeName == NodeName.Clamp |
                    nodeName == NodeName.Load)
            {
                if (actIndex == 0)
                    DelCondEvent?.Invoke();
            }
            else if (nodeName == NodeName.Geometry)
            {
                if (actIndex == 0)
                    ChangeAllGeoViewStateEvent?.Invoke(true);
                else if (actIndex == 1)
                    ChangeAllGeoViewStateEvent?.Invoke(false);
                else if (actIndex == 2)
                    DelAllGeoEvent?.Invoke();

            }
            else if (nodeName == NodeName.Mesh)
            {
                // TODO подключить
                if (actIndex == 0)
                    ChangeAllMeshViewStateEvent?.Invoke(true);
                else if (actIndex == 1)
                    ChangeAllMeshViewStateEvent?.Invoke(false);
                else if (actIndex == 2)
                    DelAllMeshEvent?.Invoke();

            }

            else if (nodeName == NodeName.Sets)
            {
                if (actIndex == 0)
                    ShowSetEvent?.Invoke();
                else if (actIndex == 1)
                    HideSetEvent?.Invoke();
                else if (actIndex == 2)
                    DelSetEvent?.Invoke();
            }
            else if (nodeName == NodeName.Objects)
            {
                if (actIndex == 0)
                    ShowObjectEvent?.Invoke();
                else if (actIndex == 1)
                    HideObjectEvent?.Invoke();
                else if (actIndex == 2)
                    DelObjectEvent?.Invoke();
            }
            else if (nodeName == NodeName.Groups)
            {
                if (actIndex == 0)
                    ShowAllGroupsEvent?.Invoke();
                else if (actIndex == 1)
                    HideAllGroupsEvent?.Invoke();
                else if (actIndex == 2)
                    DelAllGroupsEvent?.Invoke();

            }

            else if (nodeName == NodeName.NodesGroup |
                    nodeName == NodeName.ElementsGroup)
            {
                if (actIndex == 0)
                    InfoGroupEvent?.Invoke();
                else if (actIndex == 1)
                    EditGroupEvent?.Invoke();
                else if (actIndex == 2)
                    ShowGroupEvent?.Invoke();
                else if (actIndex == 3)
                    HideGroupEvent?.Invoke();
                else if (actIndex == 4)
                    DelGroupEvent?.Invoke();

            }
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
        public bool TrySearchNodes(string nodeName, out List<TreeNode> nodes)
        {
            nodes = new List<TreeNode>();

            foreach (TreeNode n in Nodes)
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

            foreach (TreeNode n in Nodes)
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


        private void treeView_AfterCollapse(TreeNode node)
        {
            node.ImageIndex = CollapseIndex;
            node.SelectedImageIndex = CollapseIndex;
        }

        private void treeView_AfterExpand(TreeNode node)
        {
            node.ImageIndex = ExpandIndex;
            node.SelectedImageIndex = ExpandIndex;
        }

        /// <summary>
        /// Аналог treeView_NodeMouseClick: в Avalonia иконки действий — отдельные элементы,
        /// поэтому вместо проверки координат щелчка сразу известна позиция иконки.
        /// </summary>
        private void treeView_NodeMouseClick(TreeNode node, int position)
        {
            SelectNode(node);
            if (node.Name == "VIRT")
                return;
            if (node.Level > 0)
            {
                var indexes = helpImgDict[node.Name.ToEnum<NodeName>()];

                if (indexes.Length > 0)
                    ActionMenu(node, position);
            }
        }

        private void treeView_AfterSelect(TreeNode node)
        {
            try
            {
                if (node.Name == "VIRT")
                    return;

                if (node.Level == 0)
                {
                    if (node.Name == NodeName.Project.ToString())
                        SelectGeneralInfoEvent?.Invoke();
                    else if (node.Name == NodeName.Results.ToString())
                        SelectResultsEvent?.Invoke();
                }

                else if (node.Level == 1)
                {
                    if (node.Name == NodeName.Geometry.ToString())
                        SelectGeoEvent?.Invoke();
                    else if (node.Name == NodeName.Mesh.ToString())
                        SelectMeshEvent?.Invoke();
                    else if (node.Name == NodeName.Task.ToString())
                        SelectTaskEvent?.Invoke();
                    else if (node.Name == NodeName.Results.ToString())
                        SelectResultsEvent?.Invoke();
                    else if (node.Name == NodeName.Calculations.ToString())
                        SelectCompsEvent?.Invoke();
                }

                else if (node.Level == 2)
                {
                    if (node.Name == NodeName.Material.ToString() |
                        node.Name == NodeName.Media.ToString() |
                        node.Name == NodeName.Heat.ToString() |
                        node.Name == NodeName.Clamp.ToString() |
                        node.Name == NodeName.Load.ToString())
                        SelectCondEvent?.Invoke(node.Index);
                    else if (node.Name == NodeName.Calculation.ToString())
                    {
                        SelectCompEvent?.Invoke(node.Text);
                    }

                    else if (node.Name == NodeName.NodesGroup.ToString() |
                        node.Name == NodeName.ElementsGroup.ToString())
                        SelectGroupEvent?.Invoke(node.Index);

                    else if (node.Name == NodeName.Result.ToString())
                        SelectResultEvent?.Invoke(node.Text);
                    else
                        SelectSetEvent?.Invoke(node.Text);
                }

                else if (node.Level == 3)
                {
                    if (node.Name == NodeName.Objects.ToString())
                    {
                        var number = int.Parse(node.Text.Split(' ')[0]);
                        var objType = node.Text.Split(' ')[1];
                        SelectObjectEvent?.Invoke(objType, number);
                    }
                    else if (node.Name == NodeName.Time.ToString())
                        SelectTimeEvent?.Invoke(node.Parent.Text, double.Parse(node.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void treeView_BeforeExpand(TreeNode node)
        {
            // If the node being expanded contains a virtual node then
            // we need to load this node's children on demand. If it doesn't
            // contain a virtual node then we already did it, so do nothing.

            if (node.Nodes.ContainsKey(VIRTUALNODE))
            {
                try
                {
                    // Clear out all of the children
                    node.Nodes.Clear();

                    if (node.Level == 1)
                    {
                        if (node.Name == NodeName.Mesh.ToString() |
                            node.Name == NodeName.Geometry.ToString())
                            GetSetsInfoEvent?.Invoke(node);
                    }

                    else if (node.Level == 2)
                        if (node.Name == NodeName.Result.ToString())
                            GetResultInfoEvent?.Invoke(node);
                        else
                            GetObjectsInfoEvent?.Invoke(node);

                }
                catch
                {
                    // Error occured, reset to a known state
                    node.Nodes.Clear();
                }
            }
        }

        // В Avalonia нет TreeView.BeginUpdate/EndUpdate: обновление визуального дерева группирует диспетчер.
        public void BeginUpdate()
        {
        }

        public void EndUpdate()
        {
        }

        // ---- Avalonia: построение визуального дерева и иконок действий (DrawImages) ----

        private void InitializeComponent()
        {
            Background = Brush.Parse("#F0F0F0");
            treeView.Classes.Add("navigator-tree");
            SetTreeColors();
            treeView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            actionOverlay.Height = 18;
            actionOverlay.Background = Brush.Parse("#C4C4C4");
            actionOverlay.Padding = new Thickness(4, 0, 0, 0);
            actionOverlay.Child = visibleActions;
            actionOverlay.IsVisible = false;
            Canvas.SetRight(actionOverlay, 16);
            actionLayer.Children.Add(actionOverlay);
            viewport.Children.Add(treeView);
            viewport.Children.Add(actionLayer);
            Content = viewport;

            treeView.LayoutUpdated += (_, _) =>
            {
                if (scrollViewer == null) AttachScrollViewer();
                UpdateActionPosition();
            };
            AttachedToVisualTree += (_, _) => AttachScrollViewer();
            DetachedFromVisualTree += (_, _) => DetachScrollViewer();
            treeView.SelectionChanged += (_, _) =>
            {
                var node = SelectedNode;
                DrawImages(node);
                if (node != null)
                    treeView_AfterSelect(node);
            };
            treeView.AddHandler(TreeViewItem.ExpandedEvent, (_, e) =>
            {
                if ((e.Source as TreeViewItem)?.Tag is not TreeNode node) return;
                treeView_BeforeExpand(node);
                treeView_AfterExpand(node);
            });
            treeView.AddHandler(TreeViewItem.CollapsedEvent, (_, e) =>
            {
                if ((e.Source as TreeViewItem)?.Tag is TreeNode node)
                    treeView_AfterCollapse(node);
            });
        }

        internal Bitmap GetImage(int index)
        {
            if (imageList.TryGetValue(index, out var icon)) return icon;
            using var stream = AssetLoader.Open(new Uri($"avares://BazisAvaloniaGUI/Navigator/Assets/{index}.png"));
            icon = new Bitmap(stream);
            imageList[index] = icon;
            return icon;
        }

        private Bitmap GetHelpImage(int index)
        {
            if (helpImageList_loc.TryGetValue(index, out var icon)) return icon;
            using var stream = AssetLoader.Open(new Uri($"avares://BazisAvaloniaGUI/Navigator/Assets/action-{index}.png"));
            icon = new Bitmap(stream);
            helpImageList_loc[index] = icon;
            return icon;
        }

        private void DrawImages(TreeNode node)
        {
            visibleActions.Children.Clear();
            actionOverlay.IsVisible = false;
            if (node == null || !(node.Level > 0 & node.Name != VIRTUALNODE))
                return;

            var indexes = helpImgDict[node.Name.ToEnum<NodeName>()];
            for (var position = 0; position < indexes.Length; position++)
            {
                var actionPosition = position;
                var icon = new Image
                {
                    Source = GetHelpImage(indexes[position]),
                    Width = 16,
                    Height = 16,
                    Margin = new Thickness(4, 0, 0, 0),
                    Cursor = new Cursor(StandardCursorType.Hand)
                };
                AutomationProperties.SetName(icon, $"{node.Name}.{actionPosition}");
                icon.PointerPressed += (_, e) =>
                {
                    e.Handled = true;
                    treeView_NodeMouseClick(node, actionPosition);
                };
                visibleActions.Children.Add(icon);
            }
            UpdateActionPosition();
        }

        private void AttachScrollViewer()
        {
            DetachScrollViewer();
            scrollViewer = treeView.GetVisualDescendants().OfType<ScrollViewer>().FirstOrDefault();
            if (scrollViewer != null) scrollViewer.ScrollChanged += OnTreeScrolled;
            UpdateActionPosition();
        }

        private void DetachScrollViewer()
        {
            if (scrollViewer != null) scrollViewer.ScrollChanged -= OnTreeScrolled;
            scrollViewer = null;
        }

        private void OnTreeScrolled(object sender, ScrollChangedEventArgs e) => UpdateActionPosition();

        private void UpdateActionPosition()
        {
            if (visibleActions.Children.Count == 0 || treeView.SelectedItem is not TreeViewItem selected)
            {
                actionOverlay.IsVisible = false;
                return;
            }
            var header = selected.GetVisualDescendants().OfType<StackPanel>().FirstOrDefault();
            var position = (header as Visual ?? selected).TranslatePoint(new Point(0, 0), viewport);
            if (position is not { } point || point.Y < 0 || point.Y + 18 > treeView.Bounds.Height)
            {
                actionOverlay.IsVisible = false;
                return;
            }
            Canvas.SetTop(actionOverlay, point.Y);
            actionOverlay.IsVisible = true;
        }

        private void SetTreeColors()
        {
            var selected = Brush.Parse("#C4C4C4");
            var normal = Brush.Parse("#F0F0F0");
            treeView.Resources["TreeViewItemBackground"] = normal;
            treeView.Resources["TreeViewItemBackgroundPointerOver"] = normal;
            treeView.Resources["TreeViewItemBackgroundPressed"] = selected;
            treeView.Resources["TreeViewItemBackgroundSelected"] = selected;
            treeView.Resources["TreeViewItemBackgroundSelectedPointerOver"] = selected;
            treeView.Resources["TreeViewItemBackgroundSelectedPressed"] = selected;
            treeView.Resources["TreeViewItemForeground"] = Brushes.Black;
            treeView.Resources["TreeViewItemForegroundPointerOver"] = Brushes.Black;
            treeView.Resources["TreeViewItemForegroundPressed"] = Brushes.Black;
            treeView.Resources["TreeViewItemForegroundSelected"] = Brushes.Black;
            treeView.Resources["TreeViewItemForegroundSelectedPointerOver"] = Brushes.Black;
            treeView.Resources["TreeViewItemForegroundSelectedPressed"] = Brushes.Black;
            treeView.Resources["TreeViewItemBorderBrushSelected"] = Brushes.Transparent;
            treeView.Resources["TreeViewItemBorderBrushSelectedPointerOver"] = Brushes.Transparent;
            treeView.Resources["TreeViewItemBorderBrushSelectedPressed"] = Brushes.Transparent;
        }
    }
}
