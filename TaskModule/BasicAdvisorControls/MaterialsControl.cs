using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.ComponentModel;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.BasicAdvisorControls
{
    public partial class MaterialsControl : CheckedGridViewAdviserControl, IElmentsGroupsControl, IMaterialsRelatedControl
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

        enum Column: int { elem, material, startTime, stopTime };

        public override int CountRows
        {
            get { return dataGridView.Rows.Count; }
        }

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

        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {
            base.StopChecking_Click(sender, e);
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
        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
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
            return string.Format(CultureInfo.InvariantCulture, "\"{0} {1} {2} {3} *\"", cmbEl.Text, cmbMat.Text, txbStartTime.Text, txbStopTime.Text);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
        }

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

        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);    
        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
        }

        public void Fill_eGroups(string taskType, string elemType, List<string> groupNames)
        {
            if (taskType == "Plain" | taskType == "AxiPlain")
            {
                if(elemType == "Элементы2D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }
            else
            {
                if (elemType == "Элементы3D")
                {
                    cmbEl.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbEl.Items.Add(eGroup);
                }
            }

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
