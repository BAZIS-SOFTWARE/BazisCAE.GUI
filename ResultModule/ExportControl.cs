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

        private readonly Dictionary<string, List<float>> resItems;
        private ObjType selectedObjType;
        public ExportControl()
        {
            InitializeComponent();
            resItems = new Dictionary<string, List<float>>();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog();
                string selectedPath;
                if (fbd.ShowDialog() == DialogResult.OK)
                    selectedPath = fbd.SelectedPath;

                var time = float.Parse(richTextBox1.SelectedText);
                var resKind = cmbTasksResults.SelectedText;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmbTasksResults_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbObjType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbObjType.SelectedItem.ToString() == "Элементы")
                selectedObjType = ObjType.Элемент;
            else
                selectedObjType = ObjType.Узел;
        }
    }
}
