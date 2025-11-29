using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.ComponentModel;
using TaskModule.BasicAdvisorControls.Interfaces;
using System.Linq;
using BazisGUI.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Tasks.BasicAdvisorControls.Interfaces;

namespace TaskModule.BasicAdvisorControls
{
    public partial class MaterialsControl : UserControl, IMaterialsRelatedControl, ICheckGridViewControl
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

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;
        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;

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

        public string DataName { get; }

        private void player_StartCheckingEvent(object obj)
        {
            //var gridViewList = new List<DataGridView>();
            //SearchControls(this, gridViewList);

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
            CheckDataEvent(this, new CheckDataEventArgs(DataName, arg2));
        }

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var row = CreateRowInfo();

                ChangeDataEvent(this, new ChangeDataEventArgs(DataName, dataGridView.CurentSelectedRowIndex, row));
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

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var row = CreateRowInfo();
                AddDataEvent(this, new AddDataEventArgs(DataName, row));
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateRowInfo() =>
            string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} *", cmbEl.Text, cmbMat.Text, txbStartTime.Text, txbStopTime.Text);

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent(this, new DeleteAllDataEventArgs(DataName));
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbEl.Text = dataGridView[(int)Column.elem, e.RowIndex].Value.ToString();
            cmbMat.Text = dataGridView[(int)Column.material, e.RowIndex].Value.ToString();
            txbStartTime.Text = dataGridView[(int)Column.startTime, e.RowIndex].Value.ToString();
            txbStopTime.Text = dataGridView[(int)Column.stopTime, e.RowIndex].Value.ToString();

            btnRefresh.Enabled = true;
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

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public bool IsValidated()
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

        public string Get_DataGridFillLine(int ind)
        {
            return dataGridView.Get_DataGridFillLine(ind);
        }

        public void Set_DataGridLines(IEnumerable<string> lines)
        {
            dataGridView.Set_DataGridLines(lines);
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
