using System;
using System.Collections.Generic;
using System.Drawing;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class FSWeldingControl : WeldContainerControl
    {

        public FSWeldingControl()
        {
            InitializeComponent();
        }

        public override string CollectData()
        {
            var hsStr = string.Empty;
            if (radioButton1.Checked)
                hsStr = "FSWPin";
            else if (radioButton2.Checked)
                hsStr = "FSWShoulder";

            var strs = new string[]
            {
                hsStr,
                rotSpeedTextBox.Text,
                axisForceTextBox.Text,
                shoulderDiamTextBox.Text,
                pinBottomDiamTextBox.Text,
                pinUpperDiamTextBox.Text,
                pinLenghtTextBox.Text,
                cmbFriction.Text,
                cmbYield.Text
            };

            return string.Join(";", strs);
        }

        public override void InputData(string[] inputData)
        {
            if (inputData[0] == "FSWPin")
                radioButton1.Checked = true;
            else if(inputData[0] == "FSWShoulder")
                radioButton2.Checked = true;
            
            rotSpeedTextBox.Text = inputData[1];
            axisForceTextBox.Text = inputData[2];
            shoulderDiamTextBox.Text = inputData[3];
            pinBottomDiamTextBox.Text = inputData[4];
            pinUpperDiamTextBox.Text = inputData[5];
            pinLenghtTextBox.Text = inputData[6];
        }

        public void Add_Functions(List<string> functions)
        {
            cmbFriction.Items.Clear();
            cmbYield.Items.Clear();
            foreach (var function in functions)
            {
                cmbFriction.Items.Add(function);
                cmbYield.Items.Add(function);
            }
        }

        public override void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            base.AllTextBox_TextChanged(sender, e);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            CreatePictureBox(TaskModule.Properties.Resources.FSW_new, new Point(Width / 2, btnInfo.Location.Y));           
        }
    }
}
