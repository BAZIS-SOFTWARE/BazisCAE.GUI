using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class WeldingMediaControl : UserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
    {
        enum Column : int { objects, heatExchange, mediaTemp, startTime, stopTime };

        public WeldingMediaControl()
        {
            InitializeComponent();
            DataName = "Среда";
        }

        public string DataName { get; }

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;
        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbNode.Items.Clear();
            foreach (var nGroup in nGroups)
            {
                cmbNode.Items.Add(nGroup);
            }
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = AddRowInfo();
                AddDataEvent(this, new AddDataEventArgs(DataName, rowInfo));

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string AddRowInfo()
        {
            //TO DO
            var dataList = new List<string>();

            if (rbtHeatFlow.Checked)
            {
                dataList.Add(cmbEl.Text);
                dataList.Add(cmbFunc.Text);
                dataList.Add(txbMediaTemp.Text);
            }
            else
            {
                dataList.Add(cmbNode.Text);
                dataList.Add("*");
                dataList.Add(cmbTermoCycle.Text);
            }

            dataList.Add(txbStartTime.Text);
            dataList.Add(txbStopTime.Text);
            dataList.Add("*");

            return string.Join(" ", dataList);
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var function = dataGridView[(int)Column.heatExchange, e.RowIndex].Value.ToString();

            if (function == "*")
            {
                cmbNode.Text = dataGridView[(int)Column.objects, e.RowIndex].Value.ToString();
                cmbTermoCycle.Text = dataGridView[(int)Column.mediaTemp, e.RowIndex].Value.ToString();
                rbtTermoCycle.Checked = true;
            }
            else
            {
                cmbEl.Text = dataGridView[(int)Column.objects, e.RowIndex].Value.ToString();
                cmbFunc.Text = dataGridView[(int)Column.heatExchange, e.RowIndex].Value.ToString();
                txbMediaTemp.Text = dataGridView[(int)Column.mediaTemp, e.RowIndex].Value.ToString();
                rbtHeatFlow.Checked = true;
            }

            txbStartTime.Text = dataGridView[(int)Column.startTime, e.RowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, e.RowIndex].Value.ToString();

            btnRefresh.Enabled = true;
        }

        public void Add_Functions(List<string> functions)
        {
            cmbFunc.Items.Clear();
            cmbTermoCycle.Items.Clear();
            foreach (var function in functions)
            {
                cmbFunc.Items.Add(function);
                cmbTermoCycle.Items.Add(function);
            }
        }

        private void mediaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = true;
            cmbEl.Enabled = true;
            cmbFunc.Enabled = true;

            cmbTermoCycle.Enabled = false;
            cmbNode.Enabled = false;

            btnRefresh.Enabled = false;
        }

        private void termocycleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = false;
            cmbEl.Enabled = false;
            cmbFunc.Enabled = false;

            cmbTermoCycle.Enabled = true;
            cmbNode.Enabled = true;

            btnRefresh.Enabled = false;
        }

        public void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = AddRowInfo();
                ChangeDataEvent(this, new ChangeDataEventArgs(DataName, dataGridView.CurentSelectedRowIndex, rowInfo));
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteDataEvent(this, new DeleteDataEventArgs(DataName, e.Row.Index));
        }

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent(this, new DeleteAllDataEventArgs(DataName));
        }

        private void dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            if (e.Column.Index == (int)Column.startTime | e.Column.Index == (int)Column.stopTime)
            {
                if (float.Parse(e.CellValue1.ToString()) > float.Parse(e.CellValue2.ToString()))
                    e.SortResult = 1;
                else if (float.Parse(e.CellValue1.ToString()) < float.Parse(e.CellValue2.ToString()))
                    e.SortResult = -1;
                else e.SortResult = 0;
            }
            // If the cells are equal, sort based on the ID column.
            //if (e.SortResult == 0 && e.Column.Name != "ID")
            //{
            //    e.SortResult = System.String.Compare(
            //        dataGridView.Rows[e.RowIndex1].Cells["ID"].Value.ToString(),
            //        dataGridView.Rows[e.RowIndex2].Cells["ID"].Value.ToString());
            //}
            e.Handled = true;
        }

        private void player_StartCheckingEvent(object obj)
        {
            if (dataGridView.Rows.Count > 0)
            {
                var checkStopTime = dataGridView.Rows.Cast<DataGridViewRow>()
.Max(r => Convert.ToSingle(r.Cells[(int)Column.stopTime].Value, CultureInfo.InvariantCulture));

                var checkStartTime = dataGridView.Rows.Cast<DataGridViewRow>()
                            .Min(r => Convert.ToSingle(r.Cells[(int)Column.startTime].Value, CultureInfo.InvariantCulture));

                player.StartValue = (int)checkStartTime;
                player.StopValue = (int)checkStopTime;
            }    

        }

        private void player_CheckingEvent(object arg1, float arg2)
        {
            CheckDataEvent(this, new BasicAdvisorControls.Events.CheckDataEventArgs(DataName, arg2));
        }

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void ShowDataButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                ShowDataEvent(this, new ShowDataEventArgs(DataName, dataGridView.GetSelectedRowIndexes().ToList()));
            }
        }

        public void HideAllDataButton_Click(object sender, EventArgs e)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                txbMediaTemp.IsValueValid(),
                cmbEl.IsValueValid(),
                cmbFunc.IsValueValid(),
                cmbNode.IsValueValid(),
                cmbTermoCycle.IsValueValid()

            }; 
            return checks.All(x => x);
        }

        public string Get_DataGridFillLine(int ind)
        {
            return dataGridView.Get_DataGridFillLine(ind);
        }

        public void Set_DataGridLines(IEnumerable<string> lines)
        {
            dataGridView.Set_DataGridLines(lines);
        }
    }
}
