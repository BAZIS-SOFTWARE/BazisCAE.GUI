using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace BaseModule.Tasks.HeatTreatmentModule
{
    public partial class HeatControl : UserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
    {
        [Category("Images")]
        [Description("Set image for add button")]
        public Image AddButtonImage
        {
            get { return btnAddNewRow.Image; }
            set { btnAddNewRow.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for clear button")]
        public Image ClearButtonImage
        {
            get { return btnClearAll.Image; }
            set { btnClearAll.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for refresh button")]
        public Image RefreshButtonImage
        {
            get { return btnRefresh.Image; }
            set { btnRefresh.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for showAll button")]
        public Image ShowAllButtonImage
        {
            get { return btnShowAll.Image; }
            set { btnShowAll.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for hideAll button")]
        public Image HideAllButtonImage
        {
            get { return btnHideAll.Image; }
            set { btnHideAll.Image = value; }
        }      

        enum Column : int { element, heatExchange, mediaTemp, startTime, stopTime };

        public HeatControl()
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

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        private string CreateRowInfo()
        {
            // Order matters
            var dataList = new List<string> { cmbEl.Text };

            if (radAndConvCoef.Checked)
            {
                var StefanBolzman = float.Parse(StefanBolzmanConst.Text);
                var BlacknessCoef = float.Parse(blackRank.Text);
                var convCoef = float.Parse(convExcFunc.Text);

                var res = convCoef + StefanBolzman * BlacknessCoef;
                dataList.Add(res.ToString());
            }
            else
                dataList.Add(cmbExchFunc.Text);

            dataList.AddRange(new[]{
                cmbTempFunc.Text,
                txbStartTime.Text,
                txbStopTime.Text,
                "*" });

            return string.Join(" ", dataList);
        }

        public void Add_Functions(List<string> functions)
        {
            cmbExchFunc.Items.Clear();
            cmbTempFunc.Items.Clear();
            foreach (var function in functions)
            {
                cmbExchFunc.Items.Add(function);
                cmbTempFunc.Items.Add(function);
            }
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = CreateRowInfo();
                AddDataEvent(this, new AddDataEventArgs(DataName, rowInfo));

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = CreateRowInfo();
                var count = dataGridView.Rows.Count;
                ChangeDataEvent(this, new ChangeDataEventArgs(DataName, dataGridView.CurentSelectedRowIndex, rowInfo));
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var medTempFunc = dataGridView[(int)Column.mediaTemp, dataGridView.CurentSelectedRowIndex].Value.ToString();
            cmbTempFunc.Text = medTempFunc;

            cmbEl.Text = dataGridView[(int)Column.element, dataGridView.CurentSelectedRowIndex].Value.ToString();
            cmbExchFunc.Text = dataGridView[(int)Column.heatExchange, dataGridView.CurentSelectedRowIndex].Value.ToString();
            cmbTempFunc.Text = dataGridView[(int)Column.mediaTemp, dataGridView.CurentSelectedRowIndex].Value.ToString();

            //var procType = dataGridView[(int)Column.kind, CurentSelectedRowIndex].Value.ToString();

            txbStartTime.Text = dataGridView[(int)Column.startTime, dataGridView.CurentSelectedRowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, dataGridView.CurentSelectedRowIndex].Value.ToString();

            btnRefresh.Enabled = true;
        }

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent(this, new DeleteAllDataEventArgs(DataName));
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


        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteDataEvent(this, new DeleteDataEventArgs(DataName, e.Row.Index));
        }

        private void player_StartCheckingEvent(object obj)
        {

            if(dataGridView.Rows.Count > 0)
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
            CheckDataEvent(this, new CheckDataEventArgs(DataName, arg2));
        }

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void Fill_nGroups(List<string> groupNames)
        {
            //для термообработки нет возможности задавать граничные условия на узлах
        }

        private void fullCoef_CheckedChanged(object sender, EventArgs e)
        {
            if (radAndConvCoef.Checked)
            {
                cmbExchFunc.Enabled = false;

                convExcFunc.Enabled = true;
                StefanBolzmanConst.Enabled = true;
                blackRank.Enabled = true;
            }
        }

        private void radAndConvCoef_CheckedChanged(object sender, EventArgs e)
        {
            if (fullCoef.Checked)
            {
                cmbExchFunc.Enabled = true;

                convExcFunc.Enabled = false;
                StefanBolzmanConst.Enabled = false;
                blackRank.Enabled = false;
            }
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                cmbEl.IsValueValid(),
                cmbExchFunc.IsValueValid(),
                cmbTempFunc.IsValueValid(),
                blackRank.IsValueValid(),
                convExcFunc.IsValueValid(),
                StefanBolzmanConst.IsValueValid()
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
