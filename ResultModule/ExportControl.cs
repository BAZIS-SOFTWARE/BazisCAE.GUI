using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class ExportControl : UserControl
    {
        public ExportControl()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void cbmTasksResults_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void SetSelectorsValues(Dictionary<string, List<float>> resDic)
        {

        }
    }
}
