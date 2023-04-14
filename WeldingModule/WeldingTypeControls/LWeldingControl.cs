using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WeldingModule.WeldingTypeControls
{
    public partial class LWeldingControl : WeldContainerControl
    {

        public LWeldingControl()
        {
            InitializeComponent();
        }

        public override string CollectData()
        {
            var strs = new string[]
            {
                "LW",
                txbPower.Text,
                txbBeamLenght.Text,
                txbBeamUpperDiam.Text,
                txbBeamBottomDiam.Text

            };

            return string.Join(";", strs);
        }

        public override void InputData(string[] inputData)
        {
            txbPower.Text = inputData[1];
            txbBeamLenght.Text = inputData[2];
            txbBeamUpperDiam.Text = inputData[3];
            txbBeamBottomDiam.Text = inputData[4];
        }

        public override void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            base.AllTextBox_TextChanged(sender, e);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            CreatePictureBox("AdvisorControls.Resources.LW.png", new Point(Width / 2, btnInfo.Location.Y));            
        }
    }
    
}
