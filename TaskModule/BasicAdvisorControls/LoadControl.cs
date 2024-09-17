using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using TaskModule.BasicAdvisorControls.Interfaces;
using System.Linq;
using TaskModule.BasicAdvisorControls.Events;
using static Tao.Platform.Windows.Winmm;
using TaskModule.BasicAdvisorControls.BasicControls;

namespace TaskModule.BasicAdvisorControls
{
    public partial class LoadControl : UserControl, IBoundaryControl, IFunctionsRelatedControl, ICheckGridViewControl
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
        }

        public string DataName { get; }
        
        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;
        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;

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

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
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
                    AddDataEvent(this, new AddDataEventArgs(DataName, row));
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
            var loadFunc = cmbLoadFunction.Text == "" ? "*" : cmbLoadFunction.Text;
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} {6} *",
                 cmbGr.Text, cmbKind.Text, direction, txbValue.Text, loadFunc, txbStartTime.Text, txbStopTime.Text);
        }

        public void ShowDataButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                ShowDataEvent(this, new ShowDataEventArgs(DataName,dataGridView.GetSelectedRowIndexes().ToList()));
            }
        }
        public void HideAllDataButton_Click(object sender, EventArgs e)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        public void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
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

                var rowInfo = CreateRowInfo(direction);
                var count = dataGridView.Rows.Count;
                ChangeDataEvent(this, new ChangeDataEventArgs(DataName, dataGridView.CurentSelectedRowIndex, rowInfo));

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent(this, new DeleteAllDataEventArgs(DataName));
        }

        private void player_CheckingEvent(object arg1, float arg2)
        {
            CheckDataEvent(this, new BasicAdvisorControls.Events.CheckDataEventArgs(DataName, arg2));
        }

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

        private void player_StopCheckingEvent(object obj)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            //throw new Exception("Метод не реализован!");
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                txbValue.IsValueValid(),
                cmbGr.IsValueValid(),
                cmbKind.IsValueValid(),
                cmbLoadFunction.IsValueValid(),
            };
            return checks.All(x => x);
        }

        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteDataEvent(this, new DeleteDataEventArgs(DataName, e.Row.Index));
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
