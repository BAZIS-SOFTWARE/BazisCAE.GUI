using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.ComponentModel;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;
using System.Linq;
using TaskModule.BasicAdvisorControls.Events;
using BaseModule.ControlsLib.Validation;
using System.Reflection.Emit;

namespace TaskModule.BasicAdvisorControls
{
    public partial class MaterialsControl : CheckedGridViewAdviserControl, IMaterialsRelatedControl, ICheckGridViewControl
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

        enum Column: int { elem, material, startTime, stopTime };

        public override int CountRows
        {
            get { return dataGridView.Rows.Count; }
        }

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        public void Add_Materials(List<string> materials)
        {
            cmbMat.Items.Clear();
            foreach (var material in materials)
            {
                cmbMat.Items.Add(material);
            }
        }

        public MaterialsControl()
        {
            InitializeComponent();

            DataName = "Материал";
        }

        public override string DataName { get; }

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
        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
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

        private string CreateRowInfo() =>
            string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} *", cmbEl.Text, cmbMat.Text, txbStartTime.Text, txbStopTime.Text);

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);   
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbEl.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            cmbMat.Text = dataGridView[(int)Column.material, e.RowIndex].Value.ToString();
            txbStartTime.Text = dataGridView[(int)Column.startTime, e.RowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, e.RowIndex].Value.ToString();

            btnRefresh.Enabled = true;
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

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public override bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                cmbEl.IsValueValid(),
                cmbMat.IsValueValid()
        };
            return checks.All(x => x);
        }

        //private void dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        //{
        //    // Try to sort based on the cells in the current column.
        //    if(e.Column.Index == (int)Column.startTime | e.Column.Index == (int)Column.stopTime)
        //    {
        //        if (float.Parse(e.CellValue1.ToString()) > float.Parse(e.CellValue2.ToString()))
        //            e.SortResult = 1;
        //        else if (float.Parse(e.CellValue1.ToString()) < float.Parse(e.CellValue2.ToString()))
        //            e.SortResult = -1;
        //        else e.SortResult = 0;
        //    }

        //    e.Handled = true;
        //}
    }


}
