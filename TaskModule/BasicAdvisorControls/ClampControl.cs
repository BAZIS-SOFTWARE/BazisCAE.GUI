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

        private void ChbDirection_CheckedChanged(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;
            if (CountSelectedRow > 0)
            {
                if (chb.Checked)
                    if (chb.Tag.ToString() == "0")
                    {
                        chbY.Checked = false;
                        chbZ.Checked = false;
                        chbLRF.Checked = false;
                    }
                    else if (chb.Tag.ToString() == "1")
                    {
                        chbX.Checked = false;
                        chbZ.Checked = false;
                        chbLRF.Checked = false;
                    }
                    else if (chb.Tag.ToString() == "2")
                    {
                        chbX.Checked = false;
                        chbY.Checked = false;
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
            try
            {
                var rows = AddRowInfo().Split('~');
                foreach (var row in rows)
                {
                    CurentSelectedRowInfo = row;
                    base.AddButton_Click(sender, e);
                    btnRefresh.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string AddRowInfo()
        {
            var taskStrAr = new List<string>();

            string stiffnessFunc;
            if (cmbStiffnessFunc.Text != "")
                stiffnessFunc = cmbStiffnessFunc.Text;
            else stiffnessFunc = "*";

            var direction = new List<string>();
            if (chbLRF.Checked)
                direction.Add("LRF");

            else
            {
                if (chbX.Enabled && chbX.Checked)
                    direction.Add("X");
                if (chbY.Enabled && chbY.Checked)
                    direction.Add("Y");
                if (chbZ.Enabled && chbZ.Checked)
                    direction.Add("Z");
            }

            if (direction.Count == 0)
                throw new Exception("Не выбрано направление");

            foreach(var d in direction)
            taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\"{0} {1} {2} {3} {4} {5} *\"",
                    cmbNodeGr.Text, cmbKind.Text, d, stiffnessFunc, txbStartTime.Text, txbStopTime.Text));

            return string.Join("~", taskStrAr);
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
            try
            {
                cmbNodeGr.Text = dataGridView[(int)Column.node, e.RowIndex].Value.ToString();

                var directions = dataGridView[(int)Column.direction, e.RowIndex].Value.ToString();

                if (directions == "X")
                { chbX.Checked = true; }
                else if (directions == "Y")
                { chbY.Checked = true; }
                else if (directions == "Z")
                { chbZ.Checked = true;  }
                else
                { chbLRF.Checked = true; }

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
    }
}
