using BaseModule.Interfaces;
using BaseModule.PinnedControl;
using BasicControls.ProgressBarEx.Functions.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace TaskModule.BasicTaskAdvisor
{
    public partial class PinnedWAdvControl : PinnedPage
    {
        public TaskAdvisor TaskAdvisor { get { return weldingAdvisor; } }

        public PinnedWAdvControl()
        {
            InitializeComponent();
        } 
    }
}
