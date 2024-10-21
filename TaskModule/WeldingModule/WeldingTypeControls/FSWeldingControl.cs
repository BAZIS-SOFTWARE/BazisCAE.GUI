using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            var strsArr = new List<string>();
            if (rbtPin.Checked)
            {
                strsArr.Add("FSWPin");
                strsArr.Add(txbRotSpeed.Text);
                strsArr.Add(txbPinLenght.Text);
                strsArr.Add(txbPinBottomDiam.Text);
                strsArr.Add(txbPinUpperDiam.Text);
                strsArr.Add(cmbYield.Text);
            }
 

            else if (rbtShoulder.Checked)
            {
                strsArr.Add("FSWShoulder");
                strsArr.Add(txbAxisForce.Text);
                strsArr.Add("30");
                strsArr.Add(txbShoulderDiam.Text);
                strsArr.Add(txbShoulderDiam.Text);
                strsArr.Add(cmbFrictionModule.Text);
            }

            return string.Join(";", strsArr);
        }

        public override IEnumerable<bool> GetValidatorsResults()
        {
            return new bool[]
            {
                txbRotSpeed.IsValueValid(),
                txbAxisForce.IsValueValid(),
                txbShoulderDiam.IsValueValid(),
                txbPinLenght.IsValueValid(),
                txbPinBottomDiam.IsValueValid(),
                txbPinUpperDiam.IsValueValid(),
                cmbFrictionModule.IsValueValid(),
                cmbYield.IsValueValid()
            };
        }

        public override void InputData(string[] inputData)
        {
            if (inputData[0] == "FSWPin")
            {                
                rbtPin.Checked = true;
                txbRotSpeed.Text = inputData[1];
                txbPinLenght.Text = inputData[2];
                txbPinBottomDiam.Text = inputData[3];
                txbPinUpperDiam.Text = inputData[4];
                cmbYield.Text = inputData[5];
            }
  
            else if(inputData[0] == "FSWShoulder")
            {
                rbtShoulder.Checked = true;
                txbAxisForce.Text = inputData[1];
                //считаем что диаметры одинаковые, а длина всегда 30 мм
                txbShoulderDiam.Text = inputData[4];
                cmbFrictionModule.Text = inputData[5];
            }
            SetIntefaceState();
        }

        public void Add_Functions(List<string> functions)
        {
            cmbFrictionModule.Items.Clear();
            cmbYield.Items.Clear();
            foreach (var function in functions)
            {
                cmbFrictionModule.Items.Add(function);
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

        private void rbt_Click(object sender, EventArgs e)
        {
            SetIntefaceState();
        }

        private void SetIntefaceState()
        {
            if (rbtPin.Checked)
            {
                txbRotSpeed.Enabled = true;
                txbAxisForce.Enabled = false;
                txbShoulderDiam.Enabled = false;
                txbPinLenght.Enabled = true;
                txbPinUpperDiam.Enabled = true;
                txbPinBottomDiam.Enabled = true;
                cmbFrictionModule.Enabled = false;
                cmbYield.Enabled = true;
            }
            if (rbtShoulder.Checked)
            {
                txbRotSpeed.Enabled = false;
                txbAxisForce.Enabled = true;
                txbShoulderDiam.Enabled = true;
                txbPinLenght.Enabled = false;
                txbPinUpperDiam.Enabled = false;
                txbPinBottomDiam.Enabled = false;
                cmbFrictionModule.Enabled = true;
                cmbYield.Enabled = false;
            }
        }
    }
}
