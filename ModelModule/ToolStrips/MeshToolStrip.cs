using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelModule.ToolStrips
{
    public partial class MeshToolStrip : ToolStrip
    {
        [Description("Set selectionHelper image")]
        [Category("General properties")]
        public Image BoundaryElementsImage
        {
            get { return btnBoundaryElements2D.Image; }
            set { btnBoundaryElements2D.Image = value; }
        }

        public MeshToolStrip()
        {
            InitializeComponent();
        }

        private void MeshToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var checkBtn = (ToolStripButton)e.ClickedItem;

            foreach (var item in this.Items)
            {
                var btn = (ToolStripButton)item;

                if (!checkBtn.Equals(btn))
                    btn.Checked = false;
            }
        }
    }
}
