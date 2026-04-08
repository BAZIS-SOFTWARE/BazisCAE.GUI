using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    public partial class MeshSelect : UserControl
    {
        private SelectInDirectionEventArgs directionConfig;
        private SelectInPlainEventArgs plainConfig;

        private readonly Dictionary<string, (bool set, bool surface, bool direction, bool other)> _modes = new()
        {
            { "Элемент1D", (true, false, false, false) },
            { "Элемент2D", (true, true, false, true) },
            { "Элемент3D", (true, false, false, false) },
            { "Узел",      (true, true, true, true) }
        };
        public event Action<SelectInDirectionEventArgs> SelectInDirection;
        public event Action CloseForm;
        private ObjType selectType;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public MeshSelect(string selectedObjects)
        {
            InitializeComponent();
            SetAvailableModes(selectedObjects);
        }

        public void SetDirectionConfig(SelectInDirectionEventArgs current)
        {
            directionConfig = current;
        }

        public void SetAvailableModes(string selectedObjects)
        {
            if (_modes.TryGetValue(selectedObjects, out var mode))
            {
                SetApply(mode.set, mode.surface, mode.direction, mode.other);
                selectType = ConvertToObjsType(selectedObjects);
                directionConfig = null;
                plainConfig = null;
    }
            else
                CloseForm?.Invoke();
        }

        public object GetSelectedAdditionalMode()
        {
            if (rbtDirection.Checked) 
            {
                if(directionConfig ==  null)
                    directionConfig = new SelectInDirectionEventArgs(ObjType.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text));
                return directionConfig;
            }
                
            else if (rbtSurface.Checked)
            {
                if(plainConfig == null)
                    plainConfig = new SelectInPlainEventArgs(selectType, float.Parse(txbAngle.Text));
                return plainConfig;
            }
            else
                return selectType;
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

        private void chbChangeDirection_CheckedChanged(object sender, EventArgs e) 
        {
            directionConfig.Reverse = chbChangeDirection.Checked;
            SelectInDirection(directionConfig);
        }
    }
}
