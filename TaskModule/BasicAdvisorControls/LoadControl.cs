using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;
using System.Linq;
using TaskModule.BasicAdvisorControls.Events;
using System.Text;
using BaseModule.ControlsLib.Validation;

namespace TaskModule.BasicAdvisorControls
{
    public partial class LoadControl : CheckedGridViewAdviserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
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
        
        enum Column : int { node, kind, direction, function, startTime, stopTime };
        enum Kind : int { force, pressure, displacement };

        public LoadControl()
        {
            InitializeComponent();
            DataName = "Нагрузка";

            ValidateControls += () => txbStartTime.IsValueValid();
            ValidateControls += () => txbStopTime.IsValueValid();
            ValidateControls += () => txbValue.IsValueValid();
            ValidateControls += () => cmbGr.IsValueValid();
            ValidateControls += () => cmbKind.IsValueValid();
            ValidateControls += () => cmbLoadFunction.IsValueValid();
        }

        public override string DataName { get; }

        public event Func<bool> ValidateControls;
        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        public void Fill_nGroups(List<string> groups)
        {
            cmbGr.Items.Clear();
            foreach (var group in groups)
            {
                cmbGr.Items.Add(group);
            }
        }

        private void ChbDirection_Click(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;

            if (chb.Checked)
            {
                if (chb.Tag.ToString() == "0" || chb.Tag.ToString() == "1" || chb.Tag.ToString() == "2")
                {
                    chbLRF.Checked = false;
                }

                else
                {
                    chbX.Checked = false;
                    chbY.Checked = false;
                    chbZ.Checked = false;
                }
            }
        }

        public override void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated(this, new CancelEventArgs()))
                return;
            var rows = new List<string>();
            try
            {
                if (chbLRF.Checked)
                    rows.Add(CreateRowInfo("LRF"));

                else
                {
                    if (chbX.Checked)
                        rows.Add(CreateRowInfo("X"));
                    if (chbY.Checked)
                        rows.Add(CreateRowInfo("Y"));
                    if (chbZ.Checked)
                        rows.Add(CreateRowInfo("Z"));
                }

                foreach (var row in rows)
                {
                    CurentSelectedRowInfo = row;
                    base.AddButton_Click(sender, e);
                }
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string CreateRowInfo(string direction)
        {
            var rowInfo = string.Empty;

            string loadFunc;
            if (cmbLoadFunction.Text != "")
                loadFunc = cmbLoadFunction.Text;
            else loadFunc = "*";


            if (cmbGr.Text == "" || cmbKind.Text == "" || txbStartTime.Text == "" || txbStopTime.Text == "")
                throw new Exception("Одно из переданных значений полей было пустым");

            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} {6} *",
                 cmbGr.Text, cmbKind.Text, direction, txbValue.Text, loadFunc, txbStartTime.Text, txbStopTime.Text);
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

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmbGr.Text = dataGridView[(int)Column.node, e.RowIndex].Value.ToString();

                var directions = dataGridView[(int)Column.direction, e.RowIndex].Value.ToString();

                if (directions == "X")
                { chbX.Checked = true; chbY.Checked = false; chbZ.Checked = false; chbLRF.Checked = false; }
                else if (directions == "Y")
                { chbY.Checked = true; chbX.Checked = false; chbZ.Checked = false; chbLRF.Checked = false; }
                else
                { chbZ.Checked = true; chbX.Checked = false; chbY.Checked = false; chbLRF.Checked = false; }

                cmbKind.Text = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();
                txbStartTime.Text = dataGridView[(int)Column.startTime, e.RowIndex].Value.ToString();
                txbStopTime.Text = dataGridView[(int)Column.stopTime, e.RowIndex].Value.ToString();

                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void Add_Functions(List<string> functions)
        {
            cmbLoadFunction.Items.Clear();

            foreach (var function in functions)
            {
                cmbLoadFunction.Items.Add(function);
            }
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated(this, new CancelEventArgs()))
                return;
            try
            {
                string direction = string.Empty;

                if (chbX.Checked)
                    direction += "X";
                if (chbY.Checked)
                    direction += "Y";
                if (chbZ.Checked)
                    direction += "Z";

                if (direction.Length == 0 | direction.Length > 1)
                    throw new Exception("Для обновления данных должно быть только одно направление!");

                CurentSelectedRowInfo = CreateRowInfo(direction);
                base.RefreshButton_Click(sender, e);

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }

        private void player_CheckingEvent(object arg1, float arg2)
        {
            CheckDataEvent(this, new BasicAdvisorControls.Events.CheckDataEventArgs(DataName, arg2));
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

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            //throw new Exception("Метод не реализован!");
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public bool IsValidated(object sender, CancelEventArgs args)
        {
            var check = ValidateControls();
            args.Cancel = check;
            return check;
        }
    }
}
