using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.BasicAdvisorControls.Interfaces;
using Newtonsoft.Json;
using System.Runtime;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    public enum Tasks : int { химическая, термическая, механическая,химическая_и_термическая, термическая_и_механическая };
    public partial class TaskPlannerControl_v2 : UserControl
    {
        //public ProcessType ProcessType { get; set; }

        public event Action<object, Tasks> AddDataUseTaskConditionsEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;
        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;
        public event Action<object, string> EditTSFEvent;

        enum Column : int { kind, settings, status };

        public TaskPlannerControl_v2()
        {
            InitializeComponent();
            DataName = "Расчет";

            // Create the ToolTip and associate with the Form container.
            var toolTip = new System.Windows.Forms.ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(btnLoadParameters, "Выберите директорию с *.tsf файлами");
        }

        public string DataName { get; }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopComputationEvent(this, new EventArgs());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var strs = dataGridView.Rows.Cast<DataGridViewRow>().Select(x => $"{x.Cells[0].Value} {x.Cells[1].Value} {x.Cells[2].Value}").ToList();
            GenerateTCFEvent(this, new GenerateTCFEventArgs(strs));
        }

        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var file = e.Row.Cells[1].Value.ToString();
            File.Delete(file);
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var taskKind = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();

                var fileSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

                EditTSFEvent?.Invoke(this, fileSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        private Tasks GetTasksSet()
        {
            if (rbtTermoMechTask.Checked)
            {
                return Tasks.термическая_и_механическая;
            }
            else if (rbtChemicalTask.Checked)
            {
                return Tasks.химическая;
            }
            else if (rbtTermoTask.Checked)
            {
                return Tasks.термическая;
            }
            else if (rbtMechTask.Checked)
            {
                return Tasks.механическая;
            }
            else
                return Tasks.химическая_и_термическая;
        }

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent?.Invoke(this, new DeleteAllDataEventArgs(DataName));
        }

        //start here
        public void Set_DataGridLines(IEnumerable<string> lines)
        {
            dataGridView.Rows.Clear();

            foreach (var line in lines)
                dataGridView.Rows.Add(line.Split(' '));
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog() ;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                //dataGridView.Rows.Clear();
                var files = Directory.GetFiles(fbd.SelectedPath).Where(x => Regex.IsMatch(x, @"(\w*)(\.tsf)"));

                var strs = new List<string>();
                foreach (var file in files)
                {
                    var str = String.Empty;
                    
                    if (file.Contains("термическая"))
                        str = "термическая";
                    else
                        str = "механическая";

                    str += $" {file} {true}";
                    strs.Add(str);
                }

                Set_DataGridLines(strs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    dataGridView.Rows[e.RowIndex].Selected = true;

                    if (dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "выполнить")
                        dataGridView[e.ColumnIndex, e.RowIndex].Value = "пропустить";
                    else
                        dataGridView[e.ColumnIndex, e.RowIndex].Value = "выполнить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == (int)Column.settings)
            {
                // Try to sort based on the cells in the current column.
                var fTask = Path.GetFileNameWithoutExtension(e.CellValue1.ToString());
                var sTask = Path.GetFileNameWithoutExtension(e.CellValue2.ToString());

                var fstrAr = fTask.Split('_');
                var sstrAr = sTask.Split('_');

                var numbComp = int.Parse(fstrAr[1]).CompareTo(int.Parse(sstrAr[1]));

                if (numbComp != 0)
                    e.SortResult = numbComp;

                else
                    e.SortResult = String.Compare(sTask, fTask);
            }
            else e.Handled = false;

            e.Handled = true;
        }      

        public string Get_DataGridFillLine(int ind)
        {
            throw new NotImplementedException();
        }

        private void btnGenTSF_Click(object sender, EventArgs e)
        {
            AddDataUseTaskConditionsEvent?.Invoke(this, GetTasksSet());
        }
    }
}
