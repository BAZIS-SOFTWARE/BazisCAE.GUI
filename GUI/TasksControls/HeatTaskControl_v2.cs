using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

//using System.IO;
using System.Linq;
using System.Windows.Forms;
using TasksParameters;

namespace BazisGUI.TasksControls
{
    public partial class HeatTaskControl_v2 : UserControl
    {

        public HeatTaskControl_v2()
        {
            InitializeComponent();
        }

        public string DTMax
        {
            get { return txbDTtMax.Text; }
            set { txbDTtMax.Text = value; }
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                txbDTtMax.IsValueValid()
            };
            return checks.All(x => x);
        }
    }
}
