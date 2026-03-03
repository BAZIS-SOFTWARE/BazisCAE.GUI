using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    public partial class MeshSelect : UserControl
    {
        private static readonly Dictionary<string, (bool set, bool surface, bool direction, bool other)> _modes = new()
        {
            { "Элемент1D", (true, false, false, false) },
            { "Элемент2D", (true, true, false, true) },
            { "Элемент3D", (true, false, false, false) },
            { "Узел",      (true, true, true, true) }
        };
        public event Action CloseForm;
        public event Action<object, SelectInDirectionEventArgs> SelectInDirection;
        public event Action<object, SelectInPlainEventArgs> SelectInPlain;
        public event Action<ObjType> SelectInSet;

        private ObjType selectType;
        public MeshSelect(string selectedObjects)
        {
            InitializeComponent();
            SetAvailableModes(selectedObjects);
        }

        public void SetAvailableModes(string selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
            {
                SetApply(mode.set, mode.surface, mode.direction, mode.other);
                selectType = ConvertToObjsType(selectedObjects);
            }
            else
                CloseForm?.Invoke();
        }

        public void UnchekAllRadioButton()
        {
            foreach (Control control in generalPanel.Controls)
                if (control is NullableRadioButton rbt)
                    rbt.Checked = false;
        }

        private void SetApply(bool set, bool surface, bool direction, bool other)
        {
            rbtSet.Enabled = set;
            rbtSurface.Enabled = surface;
            rbtDirection.Enabled = direction;
            lblAngle.Enabled = other;
            txbAngle.Enabled = other;
            chbChangeDirection.Enabled = other;
        }

        private void UncheckOtherRbt_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is NullableRadioButton rbtSelect) || !rbtSelect.Checked)
                return;
            foreach (Control control in generalPanel.Controls)
                if (control is NullableRadioButton other && other != rbtSelect)
                    other.Checked = false;
        }

        private ObjType ConvertToObjsType(string objects)
        {
            ObjType objType;
            return Enum.TryParse(objects, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {objects}");
        }

        private void rbtDirection_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDirection.Checked)
                SelectInDirection(this, new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text)));
        }
        private void rbtSurface_CheckedChanged(object sender, EventArgs e) 
        {
            if (rbtSurface.Checked)
                SelectInPlain(this, new SelectInPlainEventArgs(selectType, float.Parse(txbAngle.Text)));
        }
        private void rbtSet_CheckedChanged(object sender, EventArgs e) 
        { 
            if(rbtSet.Checked)
                SelectInSet(selectType);
        } 
    }
}
