using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolStrips
{
    public partial class ViewToolStrip : ToolStrip
    {
        public event Action<object, ViewEventArgs> viewStatusChanged;
        public ViewToolStrip()
        {
            InitializeComponent();
            //btnRotX.CheckedChanged += BtnView_CheckedChanged;
            //btnRotY.CheckedChanged += BtnView_CheckedChanged;
            //btnRotZ.CheckedChanged += BtnView_CheckedChanged;
            //btnRotXYZ.CheckedChanged += BtnView_CheckedChanged;

            //btnZoom.CheckedChanged += BtnView_CheckedChanged;

            //btnTranslation.CheckedChanged += BtnView_CheckedChanged;
        }

        //private void BtnView_CheckedChanged(object sender, EventArgs e)
        //{
        //    var btn = (ToolStripButton)sender;
        //    viewStatusChanged(this, new ViewEventArgs(btn.Text, btn.Checked));
        //}

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
