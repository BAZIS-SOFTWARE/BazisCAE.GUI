using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule.Results.GraphCreation;
using ResultDB.IO;
using System.Windows.Forms;
using BazisGUI.Utilities;
using Model.Interfaces;
using System.Collections.Generic;
using UserControlsEx.Graph;
using System.Threading.Tasks;
using System.Linq;
using BaseModule.Navigator;
using Model;
using ResultDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_CreateAnimationEvent(object arg1, string arg2, List<double> list)
        {
            //вызов контрола анимации результатов
            // при создании анимации в нем обработать событие методом
            // CreateGIFAnimation()
        }
    }
}
