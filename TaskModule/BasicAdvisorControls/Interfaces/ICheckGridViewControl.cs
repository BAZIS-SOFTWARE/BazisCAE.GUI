using System;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;

namespace TaskModule.BasicAdvisorControls.Interfaces
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
