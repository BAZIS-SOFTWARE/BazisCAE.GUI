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
    public partial class DiffusionСontrol : CheckedGridViewAdviserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
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

        enum Column : int { elem, difCoef, thermoCircle, startTime, stopTime };

        Dictionary<string, Dictionary<string, string>> diffDict = new Dictionary<string, Dictionary<string, string>>()
        {
            {"тип материала альфа Fe", new Dictionary<string, string>()
                {
                   {"Цементация","4"},
                   {"Азотирование","3"},
                   {"Нитроцементация","3,4"}
                }
            },
            {"тип материала гамма Fe", new Dictionary<string, string>()
                {
                   {"Цементация","67"},
                }
            },
        };

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        public override int CountRows
        {
            get { return dataGridView.Rows.Count; }
        }

        public DiffusionСontrol()
        {
            InitializeComponent();
            DataName = "Диффузия";
        }

        public override string DataName { get; }

        public void Fill_eGroup(List<string> eGroups)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in eGroups)
            {
                cmbEl.Items.Add(eGroup);
            }
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbEl.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            txbConcentrCarbon.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            txbDiffCoefCarbon.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            cmbTempreture.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            txbStart.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            txbStop.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();

            base.DataGridView_RowHeaderMouseClick(sender, e);

        }

        public override void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
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

        private void player_StartCheckingEvent(object obj)
        {
            var gridViewList = new List<DataGridView>();
            SearchControls(this, gridViewList);

            var checkStopTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
       .Max(r => Convert.ToSingle(r.Cells[(int)Column.stopTime].Value, CultureInfo.InvariantCulture));

            var checkStartTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
                        .Min(r => Convert.ToSingle(r.Cells[(int)Column.startTime].Value, CultureInfo.InvariantCulture));

            player.StartValue = (int)checkStartTime;
            player.StopValue = (int)checkStopTime;
        }

        private void player_CheckingEvent(object arg1, float arg2)
        {
            CheckDataEvent(this, new BasicAdvisorControls.Events.CheckDataEventArgs(DataName, arg2));
        }

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
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

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
            int rowIndex = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows.RemoveAt(rowIndex);
        }

        private void rbtNitritization_Click(object sender, EventArgs e)
        {
            rbtAlphaFe.Checked = true;
            rbtAlphaFe.Enabled = false;
            rbtGammaFe.Enabled = false;
            txbDiffCoefNitro.Enabled = true;
            txbConcentrNitro.Enabled = true;
            txbDiffCoefNitro.Text = "3";
            txbDiffCoefCarbon.Text = null;
            if (rbtNitritization.Checked)
            {
                txbDiffCoefCarbon.Enabled = false;
                txbConcentrCarbon.Enabled = false;
            }
        }

        private void rbtCarburization_Click(object sender, EventArgs e)
        {
            rbtAlphaFe.Enabled = true;
            rbtGammaFe.Enabled = true;
            txbDiffCoefCarbon.Enabled = true;
            txbConcentrCarbon.Enabled = true;
            txbDiffCoefNitro.Text = null;
            txbDiffCoefCarbon.Text = null;

            if (rbtCarburization.Checked)
            {
                txbDiffCoefNitro.Enabled = false;
                txbConcentrNitro.Enabled = false;
                txbDiffCoefCarbon.Text = "4";
            }
        }

        private void rbtAlphaFe_Click(object sender, EventArgs e)
        {
            txbDiffCoefCarbon.Clear();
            txbDiffCoefNitro.Clear();
            txbConcentrCarbon.Clear();
            txbConcentrNitro.Clear();

            if (rbtAlphaFe.Checked && rbtCarburization.Checked)
            {
                txbDiffCoefCarbon.Text = "4";
            }
            else if (rbtAlphaFe.Checked && rbtNitritization.Checked)
            {
                txbDiffCoefNitro.Text = "3";
            }
        }

        private void rbtGammaFe_Click(object sender, EventArgs e)
        {
            txbDiffCoefCarbon.Clear();
            txbDiffCoefNitro.Clear();
            txbConcentrCarbon.Clear();
            txbConcentrNitro.Clear();

            if (rbtGammaFe.Checked && rbtCarburization.Checked)
            {
                txbDiffCoefCarbon.Text = "67";
            }
        }

        private void rbtNitrocarburizing_Click(object sender, EventArgs e)
        {
            txbDiffCoefCarbon.Enabled = true;
            txbDiffCoefNitro.Enabled = true;
            txbConcentrNitro.Enabled = true;
            txbConcentrCarbon.Enabled = true;
            txbDiffCoefCarbon.Clear();
            txbDiffCoefNitro.Clear();
            txbConcentrCarbon.Clear();
            txbConcentrNitro.Clear();
            rbtAlphaFe.Checked = true;
            rbtAlphaFe.Enabled = false;
            rbtGammaFe.Enabled = false;
            if (rbtNitrocarburizing.Checked)
            {
                txbDiffCoefCarbon.Text = "4";
                txbDiffCoefNitro.Text = "3";
            }
        }

        private string CreateRowInfo()
        {
            var taskStrAr = new List<string>();
            if (rbtNitrocarburizing.Checked)
            {
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} *", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} *", cmbEl.Text, txbDiffCoefNitro.Text, txbConcentrNitro.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
            }

            else if (rbtCarburization.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} *", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));

            else if (rbtNitritization.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} *", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));

            return string.Join(" ", taskStrAr);
        }

        private void rbtParam_Click(object sender, EventArgs e)
        {
            if (rbtParam.Checked)
            {
                cmbTempreture.Enabled = false;
                cmbTempreture.Text = "***";
            }
        }

        private void rbtFunction_Click(object sender, EventArgs e)
        {
            cmbTempreture.Enabled = true;
            cmbTempreture.Text = "";
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public void Add_Functions(List<string> functions)
        {
            cmbTempreture.Items.Clear();
            foreach (var function in functions)
            {
                cmbTempreture.Items.Add(function);
            }
        }

        public void Fill_nGroups(List<string> groupNames)
        {
            throw new Exception("Метод не реализован!");
        }
        public override bool IsValidated()
        {
            var cancel = new CancelEventArgs();
            var checks = new List<bool>()
            {
                cmbEl.IsValueValid(),
                cmbTempreture.IsValueValid(),
                txbConcentrCarbon.IsValueValid(),
                txbDiffCoefCarbon.IsValueValid(),
                txbConcentrNitro.IsValueValid(),
                txbDiffCoefNitro.IsValueValid(),
                txbStart.IsValueValid(),
                txbStop.IsValueValid()
        };
            var res = checks.All(x => x);
            cancel.Cancel = !res;
            return res;
        }
    }
}
