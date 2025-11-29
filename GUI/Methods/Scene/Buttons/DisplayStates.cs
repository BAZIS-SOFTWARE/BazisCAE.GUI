using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BazisGUI;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;
using BazisGUI.Properties;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnDisplayStates_Click(object sender, EventArgs e)
        {
            //var btnSelect = sender as Button;
            var flag = bool.Parse(btnDisplayStates.Tag.ToString());
            if (!flag)
            {
                flag = true;
                btnDisplayStates.Image = Resources.arrow_d;
            }

            else
            {
                flag = false;
                btnDisplayStates.Image = Resources.arrow_l;
            }


            btnDisplayStates.Tag = flag;


            //TODO
            btnShowSides.Visible = flag;
            btnShowRibs.Visible = flag;
            btnShowSidesRibs.Visible = flag;
            btnBazis.Visible = flag;
            btnBorder.Visible = flag;
        }
    }
}
