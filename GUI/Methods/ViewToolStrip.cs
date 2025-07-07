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
                SetOnPlane(ViewPlane.XY, ScaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                SetOnPlane(ViewPlane.XZ, ScaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                SetOnPlane(ViewPlane.YZ, ScaleFactor);
            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                Rotate(ViewAxis.Y, 90);
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                Rotate(ViewAxis.X, 90);
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
                    settingsConfig.RotationAxis = ViewAxis.X;
                    btnSetRotY.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else if (btn.Tag.ToString() == "4")
                {
                    settingsConfig.RotationAxis = ViewAxis.Y;
                    btnSetRotX.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else
                {
                    settingsConfig.RotationAxis = ViewAxis.Z;
                    btnSetRotX.Checked = false;
                    btnSetRotY.Checked = false;
                }

            }
            else
                settingsConfig.RotationAxis = ViewAxis.XYZ;
        }
    }
}
