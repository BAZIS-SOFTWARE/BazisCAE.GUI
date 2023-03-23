using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolStrips;

namespace TestControls
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            //selectToolStrip1.Renderer = new BtnToolStrRender();
            compoToolStrip1.Renderer = new BtnToolStrRender();
            viewToolStrip1.Renderer = new BtnToolStrRender();
            //standartToolStrip1.Renderer = new BtnToolStrRender();
            instrumentToolStrip1.Renderer = new BtnToolStrRender();
            displayToolStrip1.Renderer = new BtnToolStrRender();
        }
    }
}
