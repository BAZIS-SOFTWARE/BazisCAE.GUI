using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class ArcWeldingControl: WeldContainerControl
    {
        public ArcWeldingControl()
        {
            InitializeComponent();
        }

        public override string CollectData()
        {
            var strs = new string[]
            {
                "ARC",
                weldPoolTextBox.Text,
                currentTextBox.Text,
                voltageTextBox.Text
            };

            return string.Join(";", strs);
        }

        public override IEnumerable<bool> GetValidatorsResults()
        {
            return new bool[]
            {
                currentTextBox.IsValueValid(),
                voltageTextBox.IsValueValid(),
                weldPoolTextBox.IsValueValid()
            };
        }

        public override void InputData(string[] inputData)
        {
            weldPoolTextBox.Text = inputData[1];
            currentTextBox.Text = inputData[2];
            voltageTextBox.Text = inputData[3];
        }

        public override void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            base.AllTextBox_TextChanged(sender, e);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            CreatePictureBox(BazisGUI.Properties.Resources.Arc_new, new Point(Width / 2, btnInfo.Location.Y));
        }
    }
}
