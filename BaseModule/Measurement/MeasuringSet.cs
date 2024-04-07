using System;
using System.Windows.Forms;

namespace BaseModule
{
    public partial class MeasuringSet : UserControl
    {

        public event Action<object, MeasureEventArgs> MakeMeasureEvent;
        public event Action PreparingMeasureEvent;

        MeasureKind measureKind;
        public MeasuringSet()
        {
            InitializeComponent();
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            if (rbtVolume.Checked)
            {
                measureKind = MeasureKind.Volume;
                cmbMeasureObjects.Enabled = false;
                PreparingMeasureEvent?.Invoke();
            }

            else if (rbtSquare.Checked)
            {
                measureKind = MeasureKind.Square;
                cmbMeasureObjects.Enabled = false;
                PreparingMeasureEvent?.Invoke();
            }

            else if (rbtnPath.Checked)
            {
                measureKind = MeasureKind.Path;
                cmbMeasureObjects.Enabled = false;
                PreparingMeasureEvent?.Invoke();
            }

            else
            {
                cmbMeasureObjects.Enabled = true;
                measureKind = MeasureKind.DistanceNodeToNode;
                cmbMeasureObjects.SelectedIndex = 0;
            }

        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            MakeMeasureEvent(this, new MeasureEventArgs(measureKind));
        }

        private void cmbMeasureObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMeasureObjects.SelectedIndex == 0)
                measureKind = MeasureKind.DistanceNodeToNode;
            else if (cmbMeasureObjects.SelectedIndex == 1)
                measureKind = MeasureKind.DistanceNodeToPlane;

            PreparingMeasureEvent?.Invoke();
        }
    }
}
