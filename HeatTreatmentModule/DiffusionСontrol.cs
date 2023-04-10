using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace HeatTreatmentModule
{
    public partial class DiffusionСontrol : CheckedGridViewAdviserControl, IElmentsGroupsControl, IFunctionsRelatedControl
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
            get { return CheckVelocitySlider.BarInnerColor; }
            set { CheckVelocitySlider.BarInnerColor = value; }
        }
        [Category("Colors")]
        [Description("Set color for bar outer slider")]
        public Color SliderBarOuterColor
        {
            get { return CheckVelocitySlider.BarOuterColor; }
            set { CheckVelocitySlider.BarOuterColor = value; }
        }

        [Category("Colors")]
        [Description("Set color for elapsed inner slider")]
        public Color SliderElapsedInnerColor
        {
            get { return CheckVelocitySlider.ElapsedInnerColor; }
            set { CheckVelocitySlider.ElapsedInnerColor = value; }
        }

        [Category("Colors")]
        [Description("Set color for elapsed outer slider")]
        public Color SliderElapsedOuterColor
        {
            get { return CheckVelocitySlider.ElapsedOuterColor; }
            set { CheckVelocitySlider.ElapsedOuterColor = value; }
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

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {

            base.StopChecking_Click(sender, e);
        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
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

        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
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

        private string AddRowInfo()
        {
            var taskStrAr = new List<string>();

            if (rbtNitrocarburizing.Checked)
            {
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\" {0} {1} {2} {3} {4} {5} *\"", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\" {0} {1} {2} {3} {4} {5} *\"", cmbEl.Text, txbDiffCoefNitro.Text, txbConcentrNitro.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
            }

            else if (rbtCarburization.Checked)
            {
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\" {0} {1} {2} {3} {4} {5} *\"", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
            }

            else if (rbtNitritization.Checked)
            {
                taskStrAr.Add(string.Format(CultureInfo.InvariantCulture, "\" {0} {1} {2} {3} {4} {5} *\"", cmbEl.Text, txbDiffCoefCarbon.Text, txbConcentrCarbon.Text, cmbTempreture.Text, txbStart.Text, txbStop.Text));
            }

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

        public void Fill_eGroups(string taskType, string elemType, List<string> groupNames)
        {
            if (taskType == "Plain" | taskType == "AxiPlain")
            {
                if (elemType == "Элементы1D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }
            else
            {
                if (elemType == "Элементы2D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }
        }

        public void Add_Functions(List<string> functions)
        {
            cmbTempreture.Items.Clear();
            foreach (var function in functions)
            {
                cmbTempreture.Items.Add(function);
            }
        }
    }
}
