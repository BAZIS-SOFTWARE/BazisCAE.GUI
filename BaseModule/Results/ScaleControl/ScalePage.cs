using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Results.ScaleControl
{
    public partial class ScalePage : UserControl
    {
        public event Action<object, bool> ShowScaleEvent;
        public event Action<object, ScaleEventArgs> SetScaleSettingEvent;
        public event Action<object, decimal> SetX_PositionEvent;
        public event Action<object, decimal> SetY_PositionEvent;
        public event Action<bool> SetUpMaxMinEvent;
        public event Action<object, string> SetScaleEvent;

        public ScalePage()
        {
            InitializeComponent();
        }

        public int Scale
        {
            get { return int.Parse(txbScale.Text); }
            set { txbScale.Text = value.ToString(); }
        }

        public bool IsMaxMinAuto
        {
            get { return chbMaxMinSetUp.Checked; }
            set { chbMaxMinSetUp.Checked = value; }
        }

        public float Max
        {
            get { return float.Parse(txbMax.Text); }
            set { txbMax.Text = value.ToString(); }
        }

        public float Min
        {
            get { return float.Parse(txbMin.Text); }
            set { txbMin.Text = value.ToString(); }
        }

        public decimal Intervals
        {
            get { return updIntervals.Value; }
            set { updIntervals.Value = value; }
        }

        public decimal Precision
        {
            get { return updPrecision.Value; }
            set { updPrecision.Value = value; }
        }

        public int X_Coord
        {
            get { return (int)upd_XCoord.Value; }
            set { upd_XCoord.Value = value; }
        }

        public int Y_Coord
        {
            get { return (int)upd_YCoord.Value; }
            set { upd_YCoord.Value = value; }
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
                SetScaleSettingEvent(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, (int)updIntervals.Value));
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
                SetScaleSettingEvent(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, (int)updIntervals.Value));
            }

        }     

        private void updPrecision_Leave(object sender, EventArgs e)
        {
            SetScaleSettingEvent(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, (int)updIntervals.Value));
        }

        private void updIntervals_Leave(object sender, EventArgs e)
        {
            SetScaleSettingEvent(this, new ScaleEventArgs(txbMax.Text, txbMin.Text, updPrecision.Text, (int)updIntervals.Value));
        }

        private void upd_XCoord_Leave(object sender, EventArgs e)
        {
            SetX_PositionEvent(this, upd_XCoord.Value);
        }

        private void upd_YCoord_Leave(object sender, EventArgs e)
        {
            SetY_PositionEvent(this, upd_YCoord.Value);
        }

        private void chbMaxMinSetUp_Click(object sender, EventArgs e)
        {
            if(chbMaxMinSetUp.Checked == true)
            {
                txbMax.Enabled = true;
                txbMin.Enabled = true;
                SetUpMaxMinEvent(chbMaxMinSetUp.Checked);
            }
            else
            {
                txbMax.Enabled = false;
                txbMin.Enabled = false;
                SetUpMaxMinEvent(chbMaxMinSetUp.Checked);
            }
        }

        private void txbScale_Leave(object sender, EventArgs e)
        {
            SetScaleEvent(this, txbScale.Text);
        }
    }
}
