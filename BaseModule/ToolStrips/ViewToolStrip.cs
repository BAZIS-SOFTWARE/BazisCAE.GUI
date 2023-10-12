using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ToolStrips
{
    public partial class ViewToolStrip : ToolStrip
    {
        public ViewToolStrip()
        {
            InitializeComponent();
        }


        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
