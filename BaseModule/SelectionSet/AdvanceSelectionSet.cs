using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BazisGUI.Interfaces.GeneralParams;

namespace BazisGUI
{
    public partial class AdvanceSelectionSet : UserControl
    {
        public event Action<object, SelectInDirectionEventArgs> SelectInDirection;
        public event Action<object, SelectInPlainEventArgs> SelectInPlain;

        public event Action<object, EventArgs> SelectNodes;
        public event Action<object, EventArgs> SelectElements;
        public AdvanceSelectionSet()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtInDirection.Checked)
                    if (rbtNodes.Checked)
                        SelectInDirection(this, new SelectInDirectionEventArgs(Objects.Узел, chbChangeDirection.Checked, float.Parse(txbAngle.Text)));
                    else
                        MessageBox.Show("Измените объект выбора на \"Узлы\"");
                else if (rbtInPlain.Checked)
                    if (rbtNodes.Checked)
                        SelectInPlain(this, new SelectInPlainEventArgs(Objects.Узел, float.Parse(txbAngle.Text)));
                    else
                        SelectInPlain(this, new SelectInPlainEventArgs(Objects.Элемент2D, float.Parse(txbAngle.Text)));
            }
            catch (Exception ex)
            {
                //console
                //throw;
            }
  
        }

        private void rbtNodes_Click(object sender, EventArgs e)
        {
            if (rbtNodes.Checked)
                SelectNodes?.Invoke(this, new EventArgs());
        }

        private void rbtElements_Click(object sender, EventArgs e)
        {
            if (rbtElements.Checked)
                SelectElements?.Invoke(this, new EventArgs());
        }
    }
}
