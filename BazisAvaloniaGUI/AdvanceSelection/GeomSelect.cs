using Avalonia;
using Avalonia.Controls;
using BazisAvaloniaGUI.Shell;
using System;
using System.Collections.Generic;
using System.Resources;

namespace BazisAvaloniaGUI.AdvanceSelection
{
    /// <summary>
    /// Avalonia-аналог GeomSelect: дополнительный выбор геометрии по объемлющим объектам
    /// (объёмам, поверхностям или кривым).
    /// </summary>
    internal sealed class GeomSelect : UserControl
    {
        private readonly Dictionary<SelectionType, (bool volume, bool surface, bool curve)> _modes = new()
        {
            { SelectionType.Points, (true, true, true) },
            { SelectionType.Curves, (true, true, false) },
            { SelectionType.Surfaces, (true, false, false) }
        };
        public event Action CloseForm;

        private readonly RadioButton rbtVolume;
        private readonly RadioButton rbtSurface;
        private readonly RadioButton rbtCurve;

        public GeomSelect(SelectionType selectedObjects)
        {
            var resources = new ResourceManager(typeof(GeomSelect));
            rbtVolume = new RadioButton { Name = "rbtVolume", Content = resources.GetString("rbtVolume.Text"), GroupName = "geomSelect", IsChecked = true };
            rbtSurface = new RadioButton { Name = "rbtSurface", Content = resources.GetString("rbtSurface.Text"), GroupName = "geomSelect" };
            rbtCurve = new RadioButton { Name = "rbtCurve", Content = resources.GetString("rbtCurve.Text"), GroupName = "geomSelect" };

            Content = new StackPanel
            {
                Name = "generalPanel",
                Spacing = 6,
                Margin = new Thickness(10),
                Children = { rbtVolume, rbtSurface, rbtCurve }
            };

            SetAvailableModes(selectedObjects);
        }

        public void SetAvailableModes(SelectionType selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
                SetApply(mode.volume, mode.surface, mode.curve);
            else
                CloseForm?.Invoke();
        }

        /// <summary>Размерность объемлющих объектов, по которым расширяется выбор; -1 — режим не выбран.</summary>
        public int GetSelectDimension()
        {
            if (rbtVolume.IsChecked == true)
                return 3;
            if (rbtSurface.IsChecked == true)
                return 2;
            if (rbtCurve.IsChecked == true)
                return 1;
            return -1;
        }

        private void SetApply(bool volume, bool surface, bool curve)
        {
            rbtVolume.IsEnabled = volume;
            rbtSurface.IsEnabled = surface;
            rbtCurve.IsEnabled = curve;
        }
    }
}
