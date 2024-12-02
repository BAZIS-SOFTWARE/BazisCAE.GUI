using BaseModule.PinnedControl;
using BaseModule.Tasks.WeldingModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskModule.HeatTreatmentModule;

namespace BaseModule.Tasks.HeatTreatmentModule
{
    public partial class PinnedHTAdvControl : PinnedPage
    {
        public HeatTreatmentAdvisor HTAdvisor { get { return heatTreatmentAdvisor; } }
        public PinnedHTAdvControl()
        {
            InitializeComponent();
        }
    }
}
