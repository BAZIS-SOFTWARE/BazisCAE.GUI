using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksParameters;

namespace BazisGUI.TasksControls
{
    internal interface ITaskControl
    {

        event Action<string> BtnSave_ClickEvent;

        bool GetValidationResult();
    }
}
