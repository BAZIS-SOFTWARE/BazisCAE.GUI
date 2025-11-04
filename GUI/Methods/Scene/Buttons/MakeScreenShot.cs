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
        private void btnMakeScreenShot_Click(object sender, EventArgs e)
        {
            CreateScreenShot(WorkingDir + "\\screenShot.bmp");
            console.PrintInfo($"Сделан снимок экрана {WorkingDir}\\screenShot.bmp", Color.Black);
        }
    }
}
