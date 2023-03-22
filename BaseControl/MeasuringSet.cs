using System;
using System.Windows.Forms;

namespace BaseControl
{
    public partial class MeasuringSet : UserControl
    {

        public event Action<object, MeasureEventArgs> MakeMeasureEvent;
        public event Action<object, MeasureEventArgs> PreparingMeasureEvent;

        MeasureKind measureKind;
        public MeasuringSet()
        {
            InitializeComponent();            
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            if (rbtnDistance.Checked)
            {
                if (cmbMeasureObjects.SelectedIndex == 0)
                    measureKind = MeasureKind.DistanceNodeToNode;
                else measureKind = MeasureKind.DistanceNodeToNode;
            }
            else if(rbtVolume.Checked)
                measureKind = MeasureKind.Volume;
            else if(rbtSquare.Checked)
                measureKind = MeasureKind.Square;
            else measureKind = MeasureKind.Path;

            PreparingMeasureEvent(this, new MeasureEventArgs(measureKind));
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            MakeMeasureEvent(this, new MeasureEventArgs(measureKind));
        }
    }
}
