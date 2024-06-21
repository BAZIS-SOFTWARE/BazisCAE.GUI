using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;
using TaskModule.Validation;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class WeldingMediaControl : CheckedGridViewAdviserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
    {
        enum Column : int { objects, heatExchange, mediaTemp, startTime, stopTime };

        public WeldingMediaControl()
        {
            InitializeComponent();
            DataName = "Среда";

        }

        public override string DataName { get; }

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

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

        public override void AddButton_Click(object sender, EventArgs e)
        {
            if (sender is BtnValidate cvb)
            {
                if (!cvb.ValidateControl_OnClick_IsValuesValid(cvb, new CancelEventArgs()))
                    return;
            }
            try
            {
                CurentSelectedRowInfo = AddRowInfo();
                base.AddButton_Click(sender, e);

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

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var function = dataGridView[(int)Column.heatExchange, e.RowIndex].Value.ToString();

            if (function == "*")
            {
                cmbNode.Text = dataGridView[(int)Column.objects, CurentSelectedRowIndex].Value.ToString();
                cmbTermoCycle.Text = dataGridView[(int)Column.mediaTemp, CurentSelectedRowIndex].Value.ToString();
                rbtTermoCycle.Checked = true;
            }
            else
            {
                cmbEl.Text = dataGridView[(int)Column.objects, CurentSelectedRowIndex].Value.ToString();
                cmbFunc.Text = dataGridView[(int)Column.heatExchange, CurentSelectedRowIndex].Value.ToString();
                txbMediaTemp.Text = dataGridView[(int)Column.mediaTemp, CurentSelectedRowIndex].Value.ToString();
                rbtHeatFlow.Checked = true;
            }

            txbStartTime.Text = dataGridView[(int)Column.startTime, CurentSelectedRowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, CurentSelectedRowIndex].Value.ToString();

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

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            if (sender is BtnValidate cvb)
            {
                if (!cvb.ValidateControl_OnClick_IsValuesValid(cvb, new CancelEventArgs()))
                    return;
            }
            try
            {
                CurentSelectedRowInfo = AddRowInfo();
                base.RefreshButton_Click(sender, e);
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
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
            var gridViewList = new List<DataGridView>();
            SearchControls(this, gridViewList);

            if (gridViewList[0].Rows.Count > 0)
            {
                var checkStopTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
.Max(r => Convert.ToSingle(r.Cells[(int)Column.stopTime].Value, CultureInfo.InvariantCulture));

                var checkStartTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
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
            if (CountSelectedRow > 0)
            {
                ShowDataEvent(this, new ShowDataEventArgs(DataName, GetSelectedRowIndexes().ToList()));
            }
        }

        public void HideAllDataButton_Click(object sender, EventArgs e)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }
    }
}
