using BaseModule.PinnedControl;
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

        public PinnedTaskPlannerControl()
        {
            InitializeComponent();
        }

        public TaskPlannerControl_v2 TaskPlannerPage { get { return taskPlannerControl_v21; } }      
    }
}
