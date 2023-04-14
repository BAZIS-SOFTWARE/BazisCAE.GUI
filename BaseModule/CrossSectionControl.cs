using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using ModelController;
using Geometry;
using Scene;
using BaseControl;

namespace CrossSectionFront
{
    public partial class CrossSectionControl : UserControl
    {
        public event Action<object, CreatePlaneFromTextArgs> CreatePlaneFromTextArgs;
        public event Action<object, CreatePlaneFromNodesArgs> CreatePlaneFromNodesArgs;
        public CrossSectionControl()
        {
            InitializeComponent();
            MinimumSize = new Size(MinimumSize.Width, MinimumSize.Height);
        }

        public void chbSelectPoints_CheckedChanged(object sender, EventArgs e)
        {
            txbPoint1.Enabled = true;
            txbPoint2.Enabled = true;
            txbPoint3.Enabled = true;
            rbtXY.Enabled = true;
            rbtXZ.Enabled = true;
            rbtYZ.Enabled = true;

            if (chbSelectPoints.Checked)
            {
                txbPoint1.Enabled = false;
                txbPoint2.Enabled = false;
                txbPoint3.Enabled = false;
                rbtXY.Enabled = false;
                rbtXZ.Enabled = false;
                rbtYZ.Enabled = false;
            }
            
        }

        public void rbtXY_CheckedChanged(object sender, EventArgs e)
        {
            txbPoint1.Text = "0;0;0";
            txbPoint2.Text = "1;0;0";
            txbPoint3.Text = "0;1;0";
        }

        public void rbtXZ_CheckedChanged(object sender, EventArgs e)
        {
            txbPoint1.Text = "0;0;0";
            txbPoint2.Text = "1;0;0";
            txbPoint3.Text = "0;0;1";
        }

        public void rbtYZ_CheckedChanged(object sender, EventArgs e)
        {
            txbPoint1.Text = "0;0;0";
            txbPoint2.Text = "0;1;0";
            txbPoint3.Text = "0;0;1";
        }

        public void btnCreateCrossSection_Click_1(object sender, EventArgs e)
        {
            if (txbPoint1 == null || txbPoint2 == null || txbPoint3 == null || txbPoint1.Text == txbPoint2.Text || txbPoint2.Text == txbPoint3.Text || txbPoint1.Text == txbPoint3.Text)
                throw new Exception("Неверно заданы координаты плоскости");
        }

        public void btnCreatePlane_Click_1(object sender, EventArgs e)
        {
            if (chbSelectPoints.Checked == false)
            {
                string[] p1 = txbPoint1.Text.Split(';');
                string[] p2 = txbPoint2.Text.Split(';');
                string[] p3 = txbPoint3.Text.Split(';');

                Point3D point1 = new Point3D(float.Parse(p1[0]), float.Parse(p1[1]), float.Parse(p1[2]));
                Point3D point2 = new Point3D(float.Parse(p2[0]), float.Parse(p2[1]), float.Parse(p2[2]));
                Point3D point3 = new Point3D(float.Parse(p3[0]), float.Parse(p3[1]), float.Parse(p3[2]));

                CreatePlaneFromTextArgs(this, new CreatePlaneFromTextArgs(point1, point2, point3));
            }
            else if (chbSelectPoints.Checked == true)
            {
                CreatePlaneFromNodesArgs(this, new CreatePlaneFromNodesArgs());
            }
        }

        public void chbShowModel_CheckedChanged(object sender, EventArgs e)
        { 
                
        }
    }
}
