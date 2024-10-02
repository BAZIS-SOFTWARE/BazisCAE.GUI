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
        public event Action<object, PointSizesRequest, double[]> pressOkEvent;
        public event Action<object, PointSizesRequest, double[]> pressDelEvent;
        public GMSHPointSettingsControl()
        {
            InitializeComponent();
        }

        public void WritePointSettingsToControls(double[] sizes)
        {
            textBoxEx1.Text = sizes[0] == 0 ? string.Empty : sizes[0].ToString();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (textBoxEx1.IsValueValid())
            {
                var values = new double[] { double.Parse(textBoxEx1.Text) };
                pressOkEvent?.Invoke(this, PointSizesRequest.Set, values);
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            pressDelEvent?.Invoke(this, PointSizesRequest.Reset, null);
            textBoxEx1.Text = string.Empty;
        }
    }
}
