using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.ToolStrips
{
    public partial class HeatTreatmentTasksToolStrip : ToolStrip
    {
        public event Action<object, AdvisorEventArgs> advisorStatusChanged;
        public HeatTreatmentTasksToolStrip()
        {
            InitializeComponent();
        }

        private void TasksToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var checkBtn = (ToolStripButton)e.ClickedItem;
            
            //checkBtn.Checked = true;
            advisorStatusChanged(this, new AdvisorEventArgs(checkBtn.Text, checkBtn.Checked));
        }
    }
}
