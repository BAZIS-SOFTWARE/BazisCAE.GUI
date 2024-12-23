using PreProc;
using PreProc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.TasksControls
{
    public partial class TimeSettingsControl : UserControl
    {
        public TimeSettingsControl()
        {
            InitializeComponent();
        }

        public void SetTimeSettings(ITimeSettings timeSettings)
        {
            txbStartStep.Text = timeSettings.InitTimeStep.ToString();
            txbMaxStep.Text = timeSettings.MaxTimeStep.ToString();
            txbMinStep.Text = timeSettings.MinTimeStep.ToString();
            txbStartTime.Text = timeSettings.StartTime.ToString();
            txbStopTime.Text = timeSettings.StopTime.ToString();
        }

        public TimeSettings GetTimeSettings()
        {
            return new TimeSettings()
            {
                InitTimeStep = Convert.ToSingle(txbStartStep.Text),
                MaxTimeStep = Convert.ToSingle(txbMaxStep.Text),
                MinTimeStep = Convert.ToSingle(txbMinStep.Text),
                StartTime = Convert.ToSingle(txbStartTime.Text),
                StopTime = Convert.ToSingle(txbStopTime.Text)
            };
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                txbMaxStep.IsValueValid(),
                txbMinStep.IsValueValid(),
                txbStartStep.IsValueValid(),
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid()
            };         

            return checks.All(x => x);
        }
    }
}
