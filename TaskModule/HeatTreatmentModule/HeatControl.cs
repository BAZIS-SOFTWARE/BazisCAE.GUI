using PlayerControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatControl : CheckedGridViewAdviserControl, IElmentsGroupsControl, IFunctionsRelatedControl, ICheckGridViewControl
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

        enum Column : int { kind,plane, function, mediaTemp, startTime, stopTime };

        public HeatControl()
        {
            InitializeComponent();
            DataName = "Среда";

        }

        public override string DataName { get; }

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        private string AddRowInfo()
        {
            var dataList = new List<string>();

            if (rbtHeatColling.Checked)
                dataList.Add(rbtHeatColling.Text);
            else
                dataList.Add(rbtTempering.Text);

            dataList.Add(cmbEl.Text);
            dataList.Add(cmbExchFunc.Text);
            dataList.Add(cmbTempFunc.Text);
            dataList.Add("*");

            dataList.Add(txbStartTime.Text);
            dataList.Add(txbStopTime.Text);
            dataList.Add("*");

            return "\"" + string.Join(" ", dataList) + "\"";
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

        public override void AddButton_Click(object sender, EventArgs e)
        {
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

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
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

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var medTempFunc = dataGridView[(int)Column.mediaTemp, CurentSelectedRowIndex].Value.ToString();
            cmbTempFunc.Text = medTempFunc;

            cmbEl.Text = dataGridView[(int)Column.plane, CurentSelectedRowIndex].Value.ToString();
            cmbExchFunc.Text = dataGridView[(int)Column.function, CurentSelectedRowIndex].Value.ToString();


            var procType = dataGridView[(int)Column.kind, CurentSelectedRowIndex].Value.ToString();

            if (procType == "Охлаждение/Нагрев")
                rbtHeatColling.Checked = true;
            else
                rbtTempering.Checked = true;

            txbStartTime.Text = dataGridView[(int)Column.startTime, CurentSelectedRowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, CurentSelectedRowIndex].Value.ToString();

            btnRefresh.Enabled = true;
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
            int rowIndex = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows.RemoveAt(rowIndex);
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


        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        private void player_StartCheckingEvent(object obj)
        {
            var gridViewList = new List<DataGridView>();
            SearchControls(this, gridViewList);

            if(gridViewList[0].Rows.Count > 0)
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
    }
}
