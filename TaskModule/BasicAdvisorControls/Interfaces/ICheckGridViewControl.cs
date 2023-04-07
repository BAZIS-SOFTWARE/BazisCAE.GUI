using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicAdvisorControls.Interfaces
{
    public interface ICheckGridViewControl : IGridViewControl
    {
        event Action<object, ShowDataEventArgs> ShowDataEvent;
        event Action<object, HideDataEventArgs> HideDataEvent;
        event Action<object, CheckDataEventArgs> CheckDataEvent;

        void ShowDataButton_Click(object sender, EventArgs e);
        void HideAllDataButton_Click(object sender, EventArgs e);

        void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e);
    }
}
