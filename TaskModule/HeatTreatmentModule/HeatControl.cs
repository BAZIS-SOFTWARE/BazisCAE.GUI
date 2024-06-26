using BaseModule.ControlsLib.Validation;
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

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatControl : CheckedGridViewAdviserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
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

            ValidateControls += () => txbStartTime.IsValueValid();
            ValidateControls += () => txbStopTime.IsValueValid();
            ValidateControls += () => cmbEl.IsValueValid();
            ValidateControls += () => cmbExchFunc.IsValueValid();
            ValidateControls += () => cmbTempFunc.IsValueValid();
            ValidateControls += () => blackRank.IsValueValid();
            ValidateControls += () => convExcFunc.IsValueValid();
            ValidateControls += () => StefanBolzmanConst.IsValueValid();
        }

        public override string DataName { get; }

        public event Func<bool> ValidateControls;
        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        private string CreateRowInfo()
        {
            // Order matters
            var dataList = new List<string>
            {
                cmbEl.Text
            };

            if (radAndConvCoef.Checked)
            {
                float StefanBolzman, BlacknessCoef, convCoef;

                if (!float.TryParse(StefanBolzmanConst.Text, out StefanBolzman))
                    throw new Exception("Константа должна быть числом с плавающей точкой");

                if(!float.TryParse(blackRank.Text, out BlacknessCoef))
                    throw new Exception("Коэффициент черноты должен быть числом с плавающей точкой");

                if (!float.TryParse(convExcFunc.Text, out convCoef))
                    throw new Exception("Коэффициент конвекционных потерь должен быть рассчитан и записан в виде числа с плавающей точкой");

                var res = convCoef + StefanBolzman * BlacknessCoef;
                dataList.Add(res.ToString());
            }
            else
                dataList.Add(cmbExchFunc.Text);

            dataList.AddRange(new[]{
                cmbTempFunc.Text,
                txbStartTime.Text,
                txbStopTime.Text,
                "*"
            });

            if (dataList.Any(x => x == ""))
                throw new Exception("Одно из переданных значений полей было пустым");

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

        public override void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated(this, new CancelEventArgs()))
                return;
            try
            {
                CurentSelectedRowInfo = CreateRowInfo();
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
            if (!IsValidated(this, new CancelEventArgs()))
                return;
            try
            {
                CurentSelectedRowInfo = CreateRowInfo();
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

            cmbEl.Text = dataGridView[(int)Column.element, CurentSelectedRowIndex].Value.ToString();
            cmbExchFunc.Text = dataGridView[(int)Column.heatExchange, CurentSelectedRowIndex].Value.ToString();
            cmbTempFunc.Text = dataGridView[(int)Column.mediaTemp, CurentSelectedRowIndex].Value.ToString();

            //var procType = dataGridView[(int)Column.kind, CurentSelectedRowIndex].Value.ToString();

            txbStartTime.Text = dataGridView[(int)Column.startTime, CurentSelectedRowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, CurentSelectedRowIndex].Value.ToString();

            btnRefresh.Enabled = true;
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
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

        public bool IsValidated(object sender, CancelEventArgs args)
        {
            var check = ValidateControls();
            args.Cancel = check;
            return check;
        }
    }
}
