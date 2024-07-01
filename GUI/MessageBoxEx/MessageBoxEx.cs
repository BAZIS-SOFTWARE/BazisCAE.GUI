using BaseModule.ControlsComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.MessageBoxEx
{
    public partial class MessageBoxEx : UserControl
    {
        [Category("General")]
        [Description("Set up color gradient")]
        public Color UpColor { get; set; } = Color.Silver;

        [Category("General")]
        [Description("Set down color gradient")]
        public Color DownColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set down color gradient")]
        public string Message 
        { 
            get { return message.Text; }
            set { message.Text = value; }
        }
        public MessageBoxEx()
        {
            InitializeComponent();
        }

        private void MessageBoxEx_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = messagePanel.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0), Width, loc_y, UpColor, DownColor);
        }
    }
}
