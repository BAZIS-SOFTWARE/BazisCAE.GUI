using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    public partial class GeomSelect : UserControl
    {
        private readonly Dictionary<string, (bool volume, bool surface, bool curve)> _modes = new()
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public void SetAvailableModes(string selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
                SetApply(mode.volume, mode.surface, mode.curve);
            else
                CloseForm?.Invoke();
        }

        public int GetSelectDimension()
        {
            foreach (var rb in generalPanel.Controls.OfType<RadioButton>())
                if (rb.Checked)
                    return GetDimm(rb.Text);
            return -1;
        }

        private void SetApply(bool volume, bool surface, bool curve)
        {
            rbtVolume.Enabled = volume;
            rbtSurface.Enabled = surface;
            rbtCurve.Enabled = curve;
        }

        private int GetDimm(string rbtText) 
        {
            return rbtText switch
            {
                "Объемы" => 3,
                "Поверхности" => 2,
                "Кривые" => 1,
            };
        }
    }
}
