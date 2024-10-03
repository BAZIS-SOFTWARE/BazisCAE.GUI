using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelModule
{
    public partial class GMSHPointSettingsControl : UserControl
    {
        public event Action<object,double[]> pressOkEvent;
        public event Action<object> pressDelEvent;

        public void SetPointSize(double meshSize)
        {
            textBoxEx1.Text = meshSize == 0 ? string.Empty : meshSize.ToString();
        }

        public GMSHPointSettingsControl()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (textBoxEx1.IsValueValid())
            {
                var values = new double[] { double.Parse(textBoxEx1.Text) };
                pressOkEvent?.Invoke(this, values);
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            pressDelEvent?.Invoke(this);
            textBoxEx1.Text = string.Empty;
        }
    }
}
