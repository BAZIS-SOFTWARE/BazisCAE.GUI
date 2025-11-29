using BazisGUI.Tasks.BasicAdvisorControls.Events;
using System;

namespace BazisGUI.Tasks.BasicAdvisorControls.Interfaces
{
    public interface ICheckGridViewControl : IGridViewControl
    {
        event Action<object, ShowDataEventArgs> ShowDataEvent;
        event Action<object, HideDataEventArgs> HideDataEvent;
        event Action<object, CheckDataEventArgs> CheckDataEvent;

        void ShowDataButton_Click(object sender, EventArgs e);
        void HideAllDataButton_Click(object sender, EventArgs e);

        //void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e);
    }
}
