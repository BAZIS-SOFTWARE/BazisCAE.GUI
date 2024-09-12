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
    public partial class GMSHCurveSettingsControl : UserControl
    {
        public GMSHCurveSettingsControl()
        {
            InitializeComponent();
        }

        public void WriteCurveSettingsToControls(string[] attributes)
        {
            if (attributes.Length == 0)
            {
                rbtnProgressive.Checked = true;
                txbAlgoCoef.Text = "1.0";
                txbAlgoNPoints.Text = string.Empty;
            }
            else
            {
                var law = attributes[1];
                if (rbtnBump.Text.Contains(law))
                    rbtnBump.Checked = true;
                else if (rbtnBeta.Text.Contains(law))
                    rbtnBeta.Checked = true;
                else
                    rbtnProgressive.Checked = true;

                txbAlgoNPoints.Text = attributes[0];
                txbAlgoCoef.Text = attributes[2].Length == 0 ? "1.0" : attributes[2];
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var attributes = new string[3] { txbAlgoNPoints.Text, rbtnProgressive.Text, txbAlgoCoef.Text };
            if (rbtnBeta.Checked)
                attributes[1] = rbtnBeta.Text;
            else if (rbtnBump.Checked)
                attributes[1] = rbtnBump.Text;

            if (txbAlgoCoef.IsValueValid() && txbAlgoNPoints.IsValueValid())
            {
                var headControl = ParentForm.Controls[0] as GMSHGeneralMeshControl;
                headControl.ApplyCurveTranfinition(attributes);
            }
        }
    }
}
