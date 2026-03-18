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
        public event Action ChangeRbt;

        private ObjType selectType;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SendSelectType();
        }

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

        public void SendSelectType()
        {
            if (rbtDirection.Checked)
                SelectInDirection(this, new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text)));
            else if (rbtSurface.Checked)
                SelectInPlain(this, new SelectInPlainEventArgs(selectType, float.Parse(txbAngle.Text)));
            else if (rbtSet.Checked)
                SelectInSet(selectType);
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

        private ObjType ConvertToObjsType(string objects)
        {
            ObjType objType;
            return Enum.TryParse(objects, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {objects}");
        }

        private void rbtChange(object sender, EventArgs e) => ChangeRbt?.Invoke();

        private void chbChangeDirection_CheckedChanged(object sender, EventArgs e) =>
            SelectInDirection(this, new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text)));
    }
}
