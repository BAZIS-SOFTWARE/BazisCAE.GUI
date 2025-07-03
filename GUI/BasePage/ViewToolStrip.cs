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
                scene.SceneControl.PlaneObjs(ViewPlane.XY);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                scene.SceneControl.PlaneObjs(ViewPlane.XZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                scene.SceneControl.PlaneObjs(ViewPlane.YZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                scene.SceneControl.RotationAxis = ViewAxis.Y;
                scene.SceneControl.RotationAngle = 90;
                scene.SceneControl.RotateObjs();
                scene.SceneControl.RotationAxis = ViewAxis.XYZ;
                scene.SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                scene.SceneControl.RotationAxis = ViewAxis.X;
                scene.SceneControl.RotationAngle = 90;
                scene.SceneControl.RotateObjs();
                scene.SceneControl.RotationAxis = ViewAxis.XYZ;
                scene.SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "8")
            {
                scene.SceneControl.FitObjectsToScreen();
            }
            scene.SceneControl.DisplayObjects();
        }

        private void btnSetRotAxis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            if (btn.Checked)
            {
                if (btn.Tag.ToString() == "3")
                {
                    scene.SceneControl.RotationAxis = ViewAxis.X;
                    btnSetRotY.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else if (btn.Tag.ToString() == "4")
                {
                    scene.SceneControl.RotationAxis = ViewAxis.Y;
                    btnSetRotX.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else
                {
                    scene.SceneControl.RotationAxis = ViewAxis.Z;
                    btnSetRotX.Checked = false;
                    btnSetRotY.Checked = false;
                }

            }
            else
                scene.SceneControl.RotationAxis = ViewAxis.XYZ;
        }
    }
}
