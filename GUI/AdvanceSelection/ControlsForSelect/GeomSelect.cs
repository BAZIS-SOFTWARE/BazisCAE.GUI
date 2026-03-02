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
        public event Action<string> SelectInCurve;
        public event Action SelectInPlain;
        public event Action SelectInVolume;
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
                CloseForm?.Invoke();
        }
        public void UnchekAllRadioButton()
        {
            foreach (Control control in generalPanel.Controls)
                if (control is NullableRadioButton rbt)
                    rbt.Checked = false;
        }
        private void SetApply(bool volume, bool surface, bool curve)
        {
            rbtVolume.Enabled = volume;
            rbtSurface.Enabled = surface;
            rbtCurve.Enabled = curve;
        }

        private void UncheckOtherRbt_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is NullableRadioButton rbtSelect) || !rbtSelect.Checked)
                return;
            foreach (Control control in generalPanel.Controls)
                if (control is NullableRadioButton other && other != rbtSelect)
                    other.Checked = false;
        }

        private void rbtCurve_CheckedChanged(object sender, EventArgs e) => SelectInCurve?.Invoke(rbtCurve.Text);
        private void rbtSurface_CheckedChanged(object sender, EventArgs e) => SelectInPlain?.Invoke();
        private void rbtVolume_CheckedChanged(object sender, EventArgs e) => SelectInVolume?.Invoke();
    }
}
