using ModelInterfaces;
using ProjectInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class ExportControl : UserControl
    {
        public event Action<string> SelectResultsEvent;
        public event Action<ExportResultEventArgs> ExportResultEvent;

        private readonly Dictionary<string, List<float>> resItems;

        public ExportControl()
        {
            InitializeComponent();
            resItems = new Dictionary<string, List<float>>();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFormBeforeButtonClick();
                var fbd = new FolderBrowserDialog();
                string selectedPath = "";
                if (fbd.ShowDialog() == DialogResult.OK)
                    selectedPath = fbd.SelectedPath;
                else
                    return;

                var time = float.Parse(richTextBox1.SelectedText);
                var resKind = cmbTasksResults.SelectedItem.ToString();
                ExportResultEvent(new ExportResultEventArgs(time, resKind, selectedPath));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckFormBeforeButtonClick()
        {
            if (cmbTasksResults.Text == "" || richTextBox1.SelectedText == "")
                throw new Exception("Перед экспортом результатов необходимо выбрать тип задачи и интервал времени для экспорта результата");
        }

        private void cmbTasksResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbTasksResults.SelectedItem;
            var rows = resItems[value.ToString()];
            foreach (var text in rows)
                richTextBox1.AppendText(text + "\n");

            SelectResultsEvent?.Invoke(value.ToString());
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
