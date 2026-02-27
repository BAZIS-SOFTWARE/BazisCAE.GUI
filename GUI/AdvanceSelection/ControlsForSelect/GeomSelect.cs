using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    public partial class GeomSelect : UserControl
    {
        private static readonly Dictionary<string, (bool volume, bool surface, bool curve)> _modes = new()
        {
            { "Точка", (true, true, true) },
            { "Кривая", (true, true, false) },
            { "Поверхность", (true, false, false) }
        };
        public event Action CloseForm;
        public GeomSelect(string selectedObjects)
        {
            InitializeComponent();
            SetAvailableModes(selectedObjects);
        }

        public void SetAvailableModes(string selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
                SetApply(mode.volume, mode.surface, mode.curve);
            else
                //SetApply(false, false, false);
                CloseForm?.Invoke();
        }

        private void SetApply(bool volume, bool surface, bool curve)
        {
            rbtVolume.Enabled = volume;
            rbtSurface.Enabled = surface;
            rbtCurve.Enabled = curve;
        }
    }
}
