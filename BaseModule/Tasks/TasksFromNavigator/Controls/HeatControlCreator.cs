using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    public partial class HeatControlCreator: UserControl
    {
        public HeatControlCreator()
        {
            InitializeComponent();
            SelectingHeatingSource();
        }
        private void SelectingHeatingSource()
        {
            groupBox3.Controls.Clear();

            if (rbtARC.Checked) generalTableLayoutPanel.Controls.Add(tableLayoutPanel3);
            else if (rbtLW.Checked) generalTableLayoutPanel.Controls.Add(tableLayoutPanel2);
            else if (rbtFS.Checked) generalTableLayoutPanel.Controls.Add(tableLayoutPanel4);
        }
    }
}
