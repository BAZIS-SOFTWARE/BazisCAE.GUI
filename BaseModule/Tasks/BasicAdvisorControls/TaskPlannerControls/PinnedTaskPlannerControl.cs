using BaseModule.PinnedControl;
using BaseModule.Results.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    public partial class PinnedTaskPlannerControl : PinnedPage
    {
        public event Action<object, Tasks, Priority> GenerateTSFEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;
        public event Action<object, string> EditTSFEvent;

        public PinnedTaskPlannerControl()
        {
            InitializeComponent();
        }

        public TaskPlannerControl_v2 TaskPlannerPage { get { return taskPlannerControl_v21; } }
    }
}
