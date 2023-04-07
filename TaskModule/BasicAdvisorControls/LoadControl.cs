using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using BasicAdvisorControls;
using System.Globalization;
using BasicAdvisorControls.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace AdvisorControls
{
    public partial class LoadControl : CheckedGridViewAdviserControl, INodesGroupControl, IFunctionsRelatedControl
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

        [Category("Images")]
        [Description("Set image for check in dinamic button")]
        public Image CheckDinamicButtonImage
        {
            get { return btnCheckDinamic.Image; }
            set { btnCheckDinamic.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for stop check button")]
        public Image StopCheckingButtonImage
        {
            get { return btnStopCheck.Image; }
            set { btnStopCheck.Image = value; }
        }

        [Category("Colors")]
        [Description("Set color for bar inner slider")]
        public Color SliderBarInnerColor
        {
            get { return checkVelocitySlider.BarInnerColor; }
            set { checkVelocitySlider.BarInnerColor = value; }
        }
        [Category("Colors")]
        [Description("Set color for bar outer slider")]
        public Color SliderBarOuterColor
        {
            get { return checkVelocitySlider.BarOuterColor; }
            set { checkVelocitySlider.BarOuterColor = value; }
        }

        [Category("Colors")]
        [Description("Set color for elapsed inner slider")]
        public Color SliderElapsedInnerColor
        {
            get { return checkVelocitySlider.ElapsedInnerColor; }
            set { checkVelocitySlider.ElapsedInnerColor = value; }
        }

        [Category("Colors")]
        [Description("Set color for elapsed outer slider")]
        public Color SliderElapsedOuterColor
        {
            get { return checkVelocitySlider.ElapsedOuterColor; }
            set { checkVelocitySlider.ElapsedOuterColor = value; }
        }
        enum Column : int { node, direction,kind, function, startTime, stopTime };
        enum Kind : int { force, pressure, displacement };

        public LoadControl()
        {
            InitializeComponent();
            DataName = "Нагрузка";
        }

        public override string DataName { get; }

        public void Fill_nGroups(List<string> groups)
        {
            cmbGr.Items.Clear();
            foreach (var group in groups)
            {
                cmbGr.Items.Add(group);
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

                btnRefresh.Enabled = true;
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

        private string AddRowInfo()
        {
            var taskStrAr = new List<string>();

            var stiffnessFunc = string.Empty;
            if (cmbLoadFunction.Enabled)
                stiffnessFunc = cmbLoadFunction.SelectedItem.ToString();
            else stiffnessFunc = "*";

            var direction = string.Empty;
            if (chbX.Enabled & chbX.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\"{0} {1} X {2} {3} {4} *\"",
                    cmbGr.Text, cmbKind.Text, stiffnessFunc, txbStartTime.Text, txbStopTime.Text));

            if (chbY.Enabled & chbY.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\"{0} {1} Y {2} {3} {4} *\"",
                    cmbGr.Text, cmbKind.Text, stiffnessFunc, txbStartTime.Text, txbStopTime.Text));

            if (chbZ.Enabled & chbZ.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\"{0} {1} Z {2} {3} {4} *\"",
                    cmbGr.Text, cmbKind.Text, stiffnessFunc, txbStartTime.Text, txbStopTime.Text));

            if (chbLRF.Checked)
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\"{0} {1} LRF {2} {3} {4} *\"",
                    cmbGr.Text, cmbKind.Text, stiffnessFunc, txbStartTime.Text, txbStopTime.Text));

            return string.Join(" ", taskStrAr);
        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
        }
        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
        }

        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {
            base.StopChecking_Click(sender, e);
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

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }
    }
}
