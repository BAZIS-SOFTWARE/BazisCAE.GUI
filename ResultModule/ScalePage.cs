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

        public event Action<bool> ChangeMaxMinAutoEvent;

        public ScalePage()
        {
            InitializeComponent();
        }

        public bool IsMaxMinAuto
        {
            get { return chbMaxMinAuto.Checked; }
            set { chbMaxMinAuto.Checked = value; }
        }

        public float Max
        {
            set { txbMax.Text = value.ToString(); }
        }

        public float Min
        {
            set { txbMin.Text = value.ToString(); }
        }

        public decimal Intervals
        {
            set { updIntervals.Value = value; }
        }

        public decimal Precision
        {
            set { updPrecision.Value = value; }
        }

        public int X_Coord
        {
            set { upd_XCoord.Value = value; }
        }

        public int Y_Coord
        {
            set { upd_YCoord.Value = value; }
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
                SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));
                
                if (chbShowScale.Checked)
                    ShowScaleEvent(this, true);
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
                SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));

                if (chbShowScale.Checked)
                    ShowScaleEvent(this, true);
            }

        }     

        private void updPrecision_Leave(object sender, EventArgs e)
        {
            SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));

            if (chbShowScale.Checked)
                ShowScaleEvent(this, true);
        }

        private void updIntervals_Leave(object sender, EventArgs e)
        {
            SetScaleSetting(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, updIntervals.Value));

            if (chbShowScale.Checked)
                ShowScaleEvent(this, true);
        }

        private void upd_XCoord_Leave(object sender, EventArgs e)
        {
            SetX_PositionEvent(this, upd_XCoord.Value);

            if (chbShowScale.Checked)
                ShowScaleEvent(this, true);
        }

        private void upd_YCoord_Leave(object sender, EventArgs e)
        {
            SetY_PositionEvent(this, upd_YCoord.Value);

            if (chbShowScale.Checked)
                ShowScaleEvent(this, true);
        }

        private void chbMaxMinAuto_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMaxMinAutoEvent(chbMaxMinAuto.Checked);
        }
    }
}
