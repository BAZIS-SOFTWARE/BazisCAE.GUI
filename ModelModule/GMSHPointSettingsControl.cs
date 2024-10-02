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
                var headControl = ParentForm.Controls[0] as GMSHGeneralMeshControl;
                var values =  new double[] { double.Parse(textBoxEx1.Text) };
                headControl.CreatePointSizesRequest(PointSizesRequest.Set, values);
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            textBoxEx1.Text = string.Empty;
            var headControl = ParentForm.Controls[0] as GMSHGeneralMeshControl;
            headControl.CreatePointSizesRequest(PointSizesRequest.Reset);
        }
    }
}
