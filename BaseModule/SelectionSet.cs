using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule
{
    public partial class SelectionSet : UserControl
    {
        public event Action<object, SelectInDirectionEventArgs> SelectInDirection;
        public event Action<object, SelectInPlainEventArgs> SelectInPlain;

        public event Action<object, EventArgs> SelectNodes;
        public event Action<object, EventArgs> SelectElements;
        public SelectionSet()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (rbtInDirection.Checked)
                SelectInDirection(this, new SelectInDirectionEventArgs("Узлы", chbChangeDirection.Checked));
            else if (rbtInPlain.Checked)
                if (rbtNodes.Checked)
                    SelectInPlain(this, new SelectInPlainEventArgs("Узлы", float.Parse(txbAngle.Text)));
                else
                    SelectInPlain(this, new SelectInPlainEventArgs("Элементы", float.Parse(txbAngle.Text)));
        }

        private void rbtNodes_Click(object sender, EventArgs e)
        {
            SelectNodes(this, new EventArgs());
        }

        private void rbtElements_Click(object sender, EventArgs e)
        {
            SelectElements(this, new EventArgs());
        }

        private void rbtInDirection_Click(object sender, EventArgs e)
        {
            rbtElements.Enabled = false;
            rbtNodes.Checked = true;
            SelectNodes(this, new EventArgs());
        }

        private void rbtInPlain_Click(object sender, EventArgs e)
        {
            rbtElements.Enabled = true;
            rbtNodes.Checked = true;
            SelectNodes(this, new EventArgs());
        }
    }
}
