using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;
using BaseModule.ControlsLib.Validation;

namespace TaskModule.BasicAdvisorControls
{
    public partial class ClampControl : CheckedGridViewAdviserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
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

        public event Func<bool> ValidateControls;
        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        enum Column : int { node,kind, direction, function,startTime, stopTime };
        //enum Kind : int { rigid, elastic = 1, contact, simmetry = 2 };

        //bool IsRowSelected { get; set; }

        //int selectedRowIndex;

        public ClampControl()
        {
            InitializeComponent();
            DataName = "Закрепление";

            //ValidateControls += () => txbStartTime.IsValueValid();
            //ValidateControls += () => txbStopTime.IsValueValid();
            //ValidateControls += () => cmbKind.IsValueValid();
            //ValidateControls += () => cmbNodeGr.IsValueValid();
            //ValidateControls += () => cmbStiffnessFunc.IsValueValid();
        }

        public override string DataName { get; }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbNodeGr.Items.Clear();
            for (int i = 0; i < nGroups.Count(); i++)
            {
                cmbNodeGr.Items.Add(nGroups[i]);
            }
        }

        private void kindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (cmbKind.Text == "Жесткое")
            {                
                chbLRF.Enabled = false;
            }
            else
                chbLRF.Enabled = true;

            if (comboBox.SelectedIndex == 0)
            {
                cmbStiffnessFunc.Enabled = false;
            }
            else if(comboBox.SelectedIndex == 1)
            {
                cmbStiffnessFunc.Enabled = true;
                chbX.Checked = true;
                chbY.Checked = true;
                chbZ.Checked = true;
            }
            else
            {
                cmbStiffnessFunc.Enabled = false;
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


        public void Add_Functions(List<string> functions)
        {
            cmbStiffnessFunc.Items.Clear();
            foreach (var function in functions)
            {
                cmbStiffnessFunc.Items.Add(function);
            }
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


        public override void AddButton_Click(object sender, EventArgs e)
        {
            //if (!IsValidated(this, new CancelEventArgs()))
            //    return;

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

            string stiffnessFunc;
            if (cmbStiffnessFunc.Text != "")
                stiffnessFunc = cmbStiffnessFunc.Text;
            else stiffnessFunc = "*";

            rowInfo = string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} *",
                    cmbNodeGr.Text, cmbKind.Text, direction, stiffnessFunc, txbStartTime.Text, txbStopTime.Text);

            return rowInfo;
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            //if (!IsValidated(this, new CancelEventArgs()))
            //    return;
            try
            {
                string direction = string.Empty;

                if (chbX.Checked)
                    direction+= "X";
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

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmbNodeGr.Text = dataGridView[(int)Column.node, e.RowIndex].Value.ToString();

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

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);   
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
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

        public void Fill_eGroups(List<string> groupNames)
        {
            //throw new Exception("Метод не реализован!");
        }

        private void chbLRF_EnabledChanged(object sender, EventArgs e)
        {
            if(!chbLRF.Enabled)
                chbLRF.Checked = false;
        }

        public bool IsValidated(object sender, CancelEventArgs args)
        {
            var check = ValidateControls();
            args.Cancel = check;
            return check;
        }

        //private void cmbNodeGr_Validating(object sender, CancelEventArgs e)
        //{
        //    var args = new Validation.ValidationEventArgs(errorProvider, cmbNodeGr);
        //    GroupValidator.Validating(sender, args);
        //}

        //private void cmbKind_Validating(object sender, CancelEventArgs e)
        //{
        //    var args = new Validation.ValidationEventArgs(errorProvider, cmbKind);
        //    CmbValidator.Validating(sender, args);
        //}

        //private void cmbStiffnessFunc_Validating(object sender, CancelEventArgs e)
        //{
        //    var args = new Validation.ValidationEventArgs(errorProvider, cmbStiffnessFunc);
        //    FunctionValidator.Validating(sender, args);
        //}

        //private void txbStartTime_Validating(object sender, CancelEventArgs e)
        //{
        //    var args = new Validation.ValidationEventArgs(errorProvider, txbStartTime);
        //    NumericValidator.Validating(sender, args);
        //}

        //private void txbStopTime_Validating(object sender, CancelEventArgs e)
        //{
        //    var args = new Validation.ValidationEventArgs(errorProvider, txbStopTime);
        //    NumericValidator.Validating(sender, args);
        //}
    }
}
