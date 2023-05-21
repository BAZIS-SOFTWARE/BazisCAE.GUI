using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class ScalePage : UserControl
    {
        public event Action<object, bool> ShowScaleEvent;

        public event Action<object, ScaleEventArgs> SetScaleSetting;

        public event Action<object, decimal> SetX_PositionEvent;
        public event Action<object, decimal> SetY_PositionEvent;

        public ScalePage()
        {
            InitializeComponent();
        }

        private void chbShowScale_Click(object sender, EventArgs e)
        {
            if(chbShowScale.Checked)
                ShowScaleEvent(this, true);
            else ShowScaleEvent(this, false);

        }

        private void txbMax_Leave(object sender, EventArgs e)
        {
            var res = 0.0f;
            if (!float.TryParse(txbMax.Text, out res))
            {
                MessageBox.Show("Некорректный ввод!");
                txbMax.Text = "0";
            }
            else
            {
                if(chbShowScale.Checked)
                    SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));
            }

        }

        private void txbMin_Leave(object sender, EventArgs e)
        {
            var res = 0.0f;
            if (!float.TryParse(txbMin.Text, out res))
            {
                MessageBox.Show("Некорректный ввод!");
                txbMin.Text = "0";
            }
            else
            {
                if (chbShowScale.Checked)
                    SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));
            }

        }

        private void upd_YCoord_Leave(object sender, EventArgs e)
        {
            var res = 0;
            if (!int.TryParse(upd_YCoord.Text, out res))
            {
                MessageBox.Show("Некорректный ввод!");
                upd_YCoord.Text = "0";
            }
            else
            {
                if (chbShowScale.Checked)
                    SetY_PositionEvent(this, res);
            }
        }

        private void updPrecision_ValueChanged(object sender, EventArgs e)
        {
            if (chbShowScale.Checked)
                SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));
        }

        private void updIntervals_ValueChanged(object sender, EventArgs e)
        {
            if (chbShowScale.Checked)
                SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));
        }

        private void upd_XCoord_ValueChanged(object sender, EventArgs e)
        {
            if (chbShowScale.Checked)
                SetX_PositionEvent(this, upd_XCoord.Value);
        }

        private void upd_YCoord_ValueChanged(object sender, EventArgs e)
        {
            if (chbShowScale.Checked)
                SetY_PositionEvent(this, upd_YCoord.Value);
        }
    }
}
