using BazisGUI.Scene.Interfaces;
using System;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void viewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;

            if (e.ClickedItem.Tag.ToString() == "0")
            {
                camera.SetOnPlane(ViewPlane.XY, scaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                camera.SetOnPlane(ViewPlane.XZ, scaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                camera.SetOnPlane(ViewPlane.YZ, scaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                RotationAxis = ViewAxis.Y;
                RotationAngle = 90;
                camera.Rotate(RotationAxis, RotationAngle);
                RotationAxis = ViewAxis.XYZ;
                RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                RotationAxis = ViewAxis.X;
                RotationAngle = 90;
                camera.Rotate(RotationAxis, RotationAngle);
                RotationAxis = ViewAxis.XYZ;
                RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "8")
            {
                FitObjectsToScreen();
            }
            DisplayObjects();
        }

        private void btnSetRotAxis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            if (btn.Checked)
            {
                if (btn.Tag.ToString() == "3")
                {
                    RotationAxis = ViewAxis.X;
                    btnSetRotY.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else if (btn.Tag.ToString() == "4")
                {
                    RotationAxis = ViewAxis.Y;
                    btnSetRotX.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else
                {
                    RotationAxis = ViewAxis.Z;
                    btnSetRotX.Checked = false;
                    btnSetRotY.Checked = false;
                }

            }
            else
                RotationAxis = ViewAxis.XYZ;
        }
    }
}
