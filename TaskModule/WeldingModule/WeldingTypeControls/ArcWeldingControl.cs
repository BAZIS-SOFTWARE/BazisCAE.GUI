using System;
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

        public override Func<ErrorProvider, bool>[] GetCtrlsValidatingMethods()
        {
            return new Func<ErrorProvider, bool>[] 
            {
                (EP) => currentTextBox.IsValueValid(EP),
                (EP) => voltageTextBox.IsValueValid(EP),
                (EP) => weldPoolTextBox.IsValueValid(EP)
            };
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
            CreatePictureBox(TaskModule.Properties.Resources.Arc_new, new Point(Width / 2, btnInfo.Location.Y));
        }
    }
}
