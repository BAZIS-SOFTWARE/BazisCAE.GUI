using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib
{
    public partial class InstrumentToolStrip : ToolStrip
    {
        public Image MeasureImage
        {
            get { return btnMeasure.Image; }
            set { btnMeasure.Image = value; }
        }

        public Image MakePhotoImage
        {
            get { return btnMakePhoto.Image; }
            set { btnMakePhoto.Image = value; }
        }

        public Image CrossSectionImage
        {
            get { return btnCrossSection.Image; }
            set { btnCrossSection.Image = value; }
        }
        public InstrumentToolStrip()
        {
            InitializeComponent();
        }
    }
}
