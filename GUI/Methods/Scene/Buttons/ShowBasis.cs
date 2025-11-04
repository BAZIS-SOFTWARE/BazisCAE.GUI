using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void btnBazis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            if (btn.Checked)
                settingsConfig.DisplayBasis = true;
            else settingsConfig.DisplayBasis = false;

            DisplayObjects();
        }
    }
}
