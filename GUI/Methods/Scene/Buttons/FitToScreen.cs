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

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnFitToScreen_Click(object sender, EventArgs e)
        {
            try
            {
                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
