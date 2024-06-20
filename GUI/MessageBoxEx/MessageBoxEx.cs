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

        }
    }
}
