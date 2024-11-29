using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TaskModule.WeldingModule.WeldingTypeControls
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

        public override IEnumerable<bool> GetValidatorsResults()
        {
            return new bool[]
            {
                txbPower.IsValueValid(),
                txbBeamLenght.IsValueValid(),
                txbBeamBottomDiam.IsValueValid(),
                txbBeamUpperDiam.IsValueValid()
            };
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
            CreatePictureBox(BaseModule.Properties.Resources.LW, new Point(Width / 2, btnInfo.Location.Y));            
        }
    }
    
}
