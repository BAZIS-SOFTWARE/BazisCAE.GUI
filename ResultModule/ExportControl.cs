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
        public event Action<string> SelectResultsEvent;

        private readonly Dictionary<string, List<float>> resItems;
        public ExportControl()
        {
            InitializeComponent();
            resItems = new Dictionary<string, List<float>>();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void cbmTasksResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rows = resItems[cmbTasksResults.SelectedItem.ToString()];
            foreach(var text in rows)
                richTextBox1.AppendText(text + "\n");

            SelectResultsEvent?.Invoke(cmbTasksResults.SelectedItem.ToString());
        }

        public void SetSelectorsValues(Dictionary<string, List<float>> resDic)
        {
            foreach(var key in resDic.Keys)
            {
                cmbTasksResults.Items.Add(key);
                resItems.Add(key, resDic[key]);
            }
        }
    }
}
