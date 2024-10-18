using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    internal interface ITaskControl
    {
        bool GetValidationResult();

        void SetSolver(int solverIndex);

        void AllTextBox_TextChanged(object sender, EventArgs e);

        void Txb_EnabledChanged(object sender, EventArgs e);
    }
}
