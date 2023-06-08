
using System;
using System.Windows.Forms;

namespace ConnectionModule
{
    public partial class AboutControl : UserControl
    {
        public AboutControl()
        {
            InitializeComponent();
        }

        public string OwnerInfo { set { lblCompanyName.Text = value; } }

        public string AdressInfo { set { lblServerAdress.Text = value; } }

        public string KeysInfo 
        { 
            get { return lblKeyInfo.Text; } 
            set { lblKeyInfo.Text = value; } 
        }
    }
}
