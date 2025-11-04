using BazisGUI.Scene.Interfaces;
using System;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnXY_Click(object sender, EventArgs e)
        {
            SetOnPlane(ViewPlane.XY, ScaleFactor);
            DisplayObjects();
        }

        private void btnZX_Click(object sender, EventArgs e)
        {
            SetOnPlane(ViewPlane.XZ, ScaleFactor);
            DisplayObjects();
        }

        private void btnZY_Click(object sender, EventArgs e)
        {
            SetOnPlane(ViewPlane.YZ, ScaleFactor);
            DisplayObjects();
        }

        private void btnRotX_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (!bool.Parse(btn.Tag.ToString()))
            {
                btn.Tag = true;

                settingsConfig.RotationAxis = ViewAxis.X;

                btnRotY.Tag = false;
                btnRotZ.Tag = false;
            }
            else
            {
                btn.Tag = false;
                settingsConfig.RotationAxis = ViewAxis.XYZ;
            }
            DisplayObjects();
        }

        private void btnRotY_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (!bool.Parse(btn.Tag.ToString()))
            {
                btn.Tag = true;

                settingsConfig.RotationAxis = ViewAxis.Y;

                btnRotX.Tag = false;
                btnRotZ.Tag = false;
            }
            else
            {
                btn.Tag = false;
                settingsConfig.RotationAxis = ViewAxis.XYZ;
            }
            DisplayObjects();
        }

        private void btnRotZ_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (!bool.Parse(btn.Tag.ToString()))
            {
                btn.Tag = true;

                settingsConfig.RotationAxis = ViewAxis.Z;

                btnRotX.Tag = false;
                btnRotY.Tag = false;
            }
            else
            {
                btn.Tag = false;
                settingsConfig.RotationAxis = ViewAxis.XYZ;
            }
            DisplayObjects();
        }

        private void btnRotHor90_Click(object sender, EventArgs e)
        {
            Rotate(ViewAxis.Y, 90);
            DisplayObjects();
        }

        private void btnRotVert90_Click(object sender, EventArgs e)
        {
            Rotate(ViewAxis.X, 90);
            DisplayObjects();
        }  
    }
}
