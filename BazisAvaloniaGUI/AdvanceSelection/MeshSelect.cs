using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using BazisAvaloniaGUI.Shell;
using BazisAvaloniaGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace BazisAvaloniaGUI.AdvanceSelection
{
    /// <summary>
    /// Avalonia-аналог MeshSelect: режимы дополнительного выбора сеточных объектов —
    /// по наборам, в плоскости и по направлению.
    /// </summary>
    internal sealed class MeshSelect : UserControl
    {
        private SelectInDirectionEventArgs directionConfig;
        private SelectInPlainEventArgs plainConfig;

        private readonly Dictionary<SelectionType, (bool set, bool surface, bool direction, bool other)> _modes = new()
        {
            { SelectionType.Elements1D, (true, false, false, false) },
            { SelectionType.Elements2D, (true, true, false, true) },
            { SelectionType.Elements3D, (true, false, false, false) },
            { SelectionType.Nodes,      (true, true, true, true) }
        };
        public event Action CloseForm;
        private ObjType selectType;

        private readonly RadioButton rbtSet;
        private readonly RadioButton rbtSurface;
        private readonly RadioButton rbtDirection;
        private readonly TextBlock lblAngle;
        private readonly TextBox txbAngle;
        private readonly CheckBox chbChangeDirection;

        public MeshSelect(SelectionType selectedObjects)
        {
            var resources = new ResourceManager(typeof(MeshSelect));
            rbtSet = new RadioButton { Name = "rbtSet", Content = resources.GetString("rbtSet.Text"), GroupName = "meshSelect", IsChecked = true };
            rbtSurface = new RadioButton { Name = "rbtSurface", Content = resources.GetString("rbtSurface.Text"), GroupName = "meshSelect" };
            rbtDirection = new RadioButton { Name = "rbtDirection", Content = resources.GetString("rbtDirection.Text"), GroupName = "meshSelect" };
            foreach (var radio in new[] { rbtSet, rbtSurface, rbtDirection })
                radio.IsCheckedChanged += Rbt_CheckedChanged;

            lblAngle = new TextBlock { Name = "lblAngle", Text = resources.GetString("lblAngle.Text"), VerticalAlignment = VerticalAlignment.Center };
            txbAngle = new TextBox { Name = "txbAngle", Text = resources.GetString("txbAngle.Text") ?? "5", Width = 60, Margin = new Thickness(6, 0, 0, 0) };
            chbChangeDirection = new CheckBox { Name = "chbChangeDirection", Content = resources.GetString("chbChangeDirection.Text") };
            chbChangeDirection.IsCheckedChanged += chbChangeDirection_CheckedChanged;

            var angle = new StackPanel { Orientation = Orientation.Horizontal, Children = { lblAngle, txbAngle } };
            Content = new StackPanel
            {
                Name = "generalPanel",
                Spacing = 6,
                Margin = new Thickness(10),
                Children = { rbtSet, rbtSurface, rbtDirection, angle, chbChangeDirection }
            };

            SetAvailableModes(selectedObjects);
        }

        public void SetAvailableModes(SelectionType selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
            {
                SetApply(mode.set, mode.surface, mode.direction, mode.other);
                selectType = Converters.ConvertSelectionTypeToObjType(selectedObjects);
                directionConfig = null;
                plainConfig = null;
            }
            else
                CloseForm?.Invoke();
        }

        public object GetSelectedAdditionalMode()
        {
            if (rbtDirection.IsChecked == true)
            {
                if (directionConfig == null)
                    directionConfig = new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.IsChecked == true, ParseAngle());
                return directionConfig;
            }

            else if (rbtSurface.IsChecked == true)
            {
                if (plainConfig == null)
                    plainConfig = new SelectInPlainEventArgs(selectType, ParseAngle());
                return plainConfig;
            }
            else
                return selectType;
        }

        private float ParseAngle() =>
            float.Parse(txbAngle.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);

        private void SetApply(bool set, bool surface, bool direction, bool other)
        {
            rbtSet.IsEnabled = set;
            rbtSurface.IsEnabled = surface;
            rbtDirection.IsEnabled = direction;
            lblAngle.IsEnabled = other;
            txbAngle.IsEnabled = other;
            chbChangeDirection.IsEnabled = other;
        }

        private void chbChangeDirection_CheckedChanged(object sender, EventArgs e)
        {
            if (directionConfig != null)
                directionConfig.Reverse = chbChangeDirection.IsChecked == true;
        }

        private void Rbt_CheckedChanged(object sender, EventArgs e)
        {
            directionConfig = null;
            plainConfig = null;
        }
    }
}
