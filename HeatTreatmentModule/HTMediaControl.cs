
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace HeatTreatmentModule
{
    public partial class HTMediaControl : CheckedGridViewAdviserControl, IElmentsGroupsControl, IFunctionsRelatedControl
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

        enum Column : int { plane, node = 0, function, mediaTemp, bodyTemp, startTime, stopTime };

        public HTMediaControl()
        {
            InitializeComponent();
            DataName = "Среда";

        }

        public override string DataName { get; }


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

        private string AddRowInfo()
        {
            var dataList = new List<string>();

            dataList.Add(cmbEl.Text);
            dataList.Add(cmbExchFunc.Text);
            dataList.Add(cmbMedFunc.Text);
            dataList.Add("*");

            dataList.Add(txbStartTime.Text);
            dataList.Add(txbStopTime.Text);
            dataList.Add("*");

            return "\"" + string.Join(" ", dataList) + "\"";
        }

        public void Add_Functions(List<string> functions)
        {
            cmbExchFunc.Items.Clear();
            cmbMedFunc.Items.Clear();
            foreach (var function in functions)
            {
                cmbExchFunc.Items.Add(function);
                cmbMedFunc.Items.Add(function);
            }
        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
        }

        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);
        }


        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }

        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {
            base.StopChecking_Click(sender, e);
        }
    }
}
