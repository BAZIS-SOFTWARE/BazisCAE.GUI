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
        public Image PlaneXYImage
        {
            get { return btnSetPlaneXY.Image; }
            set { btnSetPlaneXY.Image = value; }
        }

        public Image PlaneXZImage
        {
            get { return btnSetPlaneXZ.Image; }
            set { btnSetPlaneXZ.Image = value; }
        }

        public Image PlaneYZImage
        {
            get { return btnSetPlaneYZ.Image; }
            set { btnSetPlaneYZ.Image = value; }
        }

        public Image RotXImage
        {
            get { return btnRotX.Image; }
            set { btnRotX.Image = value; }
        }

        public Image RotYImage
        {
            get { return btnRotY.Image; }
            set { btnRotY.Image = value; }
        }

        public Image RotZImage
        {
            get { return btnRotZ.Image; }
            set { btnRotZ.Image = value; }
        }

        public Image Rot90HorImage
        {
            get { return btnRotHor90.Image; }
            set { btnRotHor90.Image = value; }
        }

        public Image Rot90VerImage
        {
            get { return btnRotVer90.Image; }
            set { btnRotVer90.Image = value; }
        }

        public Image FitImage
        {
            get { return btnFitMesh.Image; }
            set { btnFitMesh.Image = value; }
        }

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
