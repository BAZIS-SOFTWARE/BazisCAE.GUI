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
    public partial class MeshToolStrip : ToolStrip
    {
        [Description("Set selectionHelper image")]
        [Category("General properties")]
        public Image BoundaryElementsImage
        {
            get { return btnBoundaryElements2D.Image; }
            set { btnBoundaryElements2D.Image = value; }
        }

        public event Action<object, MeshEventArgs> viewStatusChanged;
        public MeshToolStrip()
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
