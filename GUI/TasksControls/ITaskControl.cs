using System;

namespace BazisGUI.TasksControls
{
    internal interface ITaskControl
    {

        event Action<string> BtnSave_ClickEvent;

        bool GetValidationResult();
    }
}
