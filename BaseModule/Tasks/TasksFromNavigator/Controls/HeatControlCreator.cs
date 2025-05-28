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
        }
        public void SelectingHeatingSource(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();

            if (rbtARC.Checked) groupBox3.Controls.Add(tableLayoutPanel3);
            else if (rbtLW.Checked) groupBox3.Controls.Add(tableLayoutPanel2);
            else if (rbtFS.Checked) groupBox3.Controls.Add(tableLayoutPanel4);
        }
    }
}
