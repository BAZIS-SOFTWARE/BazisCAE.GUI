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
        private void btnMakeScreenShot_Click(object sender, EventArgs e)
        {
            try
            {
                var image = CreateScreenShot();
                image.Save(WorkingDir + "\\screenShot.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                console.PrintInfo($"Сделан снимок экрана {WorkingDir}\\screenShot.bmp", Color.Black);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
