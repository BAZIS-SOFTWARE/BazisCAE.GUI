using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DrawingColor = System.Drawing.Color;

namespace BazisAvaloniaGUI.Navigator
{
    /// <summary>
    /// Avalonia-аналог System.Windows.Forms.TreeNode поверх TreeViewItem.
    /// Нужен, чтобы код обработчиков навигатора переносился из WinForms без изменений.
    /// </summary>
    internal sealed class TreeNode
    {
        private readonly TextBlock text;
        private readonly Image image;
        private int imageIndex = -1;
        private DrawingColor foreColor = DrawingColor.Empty;

        internal TreeViewItem Item { get; }
        internal NavigatorControl Owner { get; set; }
        internal TreeNodeCollection Collection { get; set; }

        public TreeNode(string text)
        {
            this.text = new TextBlock { Text = text, Foreground = Brushes.Black, VerticalAlignment = VerticalAlignment.Center };
            image = new Image { Width = 16, Height = 16, VerticalAlignment = VerticalAlignment.Center, IsVisible = false };
            var header = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 4 };
            header.Children.Add(image);
            header.Children.Add(this.text);
            Item = new TreeViewItem
            {
                Header = header,
                Tag = this,
                MinHeight = 18,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(0)
            };
            AutomationProperties.SetName(Item, text);
            Nodes = new TreeNodeCollection(Item.Items, this);
        }

        public string Name { get; set; } = string.Empty;

        public object Tag { get; set; }

        public string Text
        {
            get => text.Text;
            set
            {
                text.Text = value;
                AutomationProperties.SetName(Item, value);
            }
        }

        public DrawingColor ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                text.Foreground = value.IsEmpty ? Brushes.Black : Properties.PropertiesPanelControl.ColorBrush(value);
            }
        }

        public int ImageIndex
        {
            get => imageIndex;
            set
            {
                imageIndex = value;
                UpdateImage();
            }
        }

        public int SelectedImageIndex { get; set; } = -1;

        public TreeNodeCollection Nodes { get; }

        public TreeNode Parent => Collection?.OwnerNode;

        public int Level => Parent == null ? 0 : Parent.Level + 1;

        public int Index => Collection?.IndexOf(this) ?? -1;

        public bool IsExpanded => Item.IsExpanded;

        public void Expand() => Item.IsExpanded = true;

        public void Collapse() => Item.IsExpanded = false;

        public void Remove() => Collection?.Remove(this);

        internal void Attach(NavigatorControl owner)
        {
            Owner = owner;
            UpdateImage();
            foreach (TreeNode child in Nodes)
                child.Attach(owner);
        }

        private void UpdateImage()
        {
            var bitmap = imageIndex < 0 ? null : Owner?.GetImage(imageIndex);
            image.Source = bitmap;
            image.IsVisible = bitmap != null;
        }

        public override string ToString() => $"TreeNode: {Text}";
    }

    /// <summary>
    /// Avalonia-аналог System.Windows.Forms.TreeNodeCollection.
    /// </summary>
    internal sealed class TreeNodeCollection : IEnumerable
    {
        private readonly ItemCollection items;

        internal TreeNode OwnerNode { get; }
        internal NavigatorControl OwnerControl { get; set; }

        internal TreeNodeCollection(ItemCollection items, TreeNode ownerNode)
        {
            this.items = items;
            OwnerNode = ownerNode;
        }

        private NavigatorControl Control => OwnerNode?.Owner ?? OwnerControl;

        private IEnumerable<TreeNode> Nodes => items.OfType<TreeViewItem>().Select(item => (TreeNode)item.Tag);

        public int Count => items.Count;

        public TreeNode this[int index] => (TreeNode)((TreeViewItem)items[index]).Tag;

        public TreeNode this[string key] => Nodes.FirstOrDefault(node => node.Name == key);

        public int Add(TreeNode node)
        {
            node.Collection = this;
            node.Attach(Control);
            items.Add(node.Item);
            return items.Count - 1;
        }

        public void AddRange(TreeNode[] nodes)
        {
            foreach (var node in nodes)
                Add(node);
        }

        public void Clear()
        {
            foreach (var node in Nodes.ToList())
                node.Collection = null;
            items.Clear();
        }

        public bool ContainsKey(string key) => Nodes.Any(node => node.Name == key);

        public TreeNode[] Find(string key, bool searchAllChildren)
        {
            var result = new List<TreeNode>();
            foreach (var node in Nodes)
            {
                if (node.Name == key)
                    result.Add(node);
                if (searchAllChildren)
                    result.AddRange(node.Nodes.Find(key, true));
            }
            return result.ToArray();
        }

        internal int IndexOf(TreeNode node) => items.IndexOf(node.Item);

        internal void Remove(TreeNode node)
        {
            items.Remove(node.Item);
            node.Collection = null;
        }

        public IEnumerator GetEnumerator() => Nodes.ToList().GetEnumerator();
    }
}
