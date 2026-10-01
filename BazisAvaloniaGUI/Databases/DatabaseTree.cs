using Avalonia.Controls;
using Avalonia.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace BazisAvaloniaGUI.Databases;

// Keeps the source database hierarchy and node paths while using Avalonia selection and menus.
internal sealed class DatabaseTree : TreeView
{
    public DatabaseNodes Nodes { get; } = new();
    public TreeNode SelectedNode { get => SelectedItem as TreeNode; set => SelectedItem = value; }
    public DatabaseTree() { ItemsSource = Nodes; }
}

internal sealed class DatabaseNodes : ObservableCollection<TreeNode>
{
    private readonly TreeNode parent;
    public DatabaseNodes(TreeNode parent = null) { this.parent = parent; }
    public TreeNode this[string name] => this.FirstOrDefault(n => n.Name == name);
    protected override void InsertItem(int index, TreeNode item) { item.ParentNode = parent; base.InsertItem(index, item); }
    public void RemoveByKey(string name) { var node = this[name]; if (node != null) Remove(node); }
    public TreeNode[] Find(string name, bool recursive) => this.SelectMany(n =>
        (n.Name == name ? new[] { n } : []).Concat(recursive ? n.Nodes.Find(name, true) : [])).ToArray();
}

internal sealed class TreeNode : TreeViewItem
{
    public TreeNode ParentNode { get; set; }
    public new TreeNode Parent => ParentNode;
    public new int Level => ParentNode == null ? 0 : ParentNode.Level + 1;
    public string FullPath => ParentNode == null ? Text : ParentNode.FullPath + "\\" + Text;
    public DatabaseNodes Nodes { get; }
    private string text;
    public string Text { get => text; set { text = value; Header = value; } }
    public TreeNode(string text) { Text = text; Nodes = new DatabaseNodes(this); ItemsSource = Nodes; }
    public object Clone()
    {
        var copy = new TreeNode(Text) { Name = Name, ContextMenu = ContextMenu };
        foreach (var child in Nodes) copy.Nodes.Add((TreeNode)child.Clone());
        return copy;
    }
}

internal sealed class TreeViewEventArgs(TreeNode node) : System.EventArgs { public TreeNode Node { get; } = node; }
internal sealed class NodeLabelEditEventArgs(TreeNode node, string label) : System.EventArgs
{
    public TreeNode Node { get; } = node;
    public string Label { get; } = label;
    public bool CancelEdit { get; set; }
}
