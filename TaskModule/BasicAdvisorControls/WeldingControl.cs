using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using AdvisorControls.WeldingTypeControls;
using BasicAdvisorControls;
using System.Globalization;
using BasicAdvisorControls.Interfaces;

namespace AdvisorControls
{
    public partial class WeldingControl : CheckedGridViewAdviserControl, INodesGroupControl,IElmentsGroupsControl,IFunctionsRelatedControl
    {

        List<string> funcs = new List<string>();
        enum Column : int { weldingType = 0, weldingArea, startTime, stopTime, movingReferenceFrame };

        public override string Traj
        {
            get { return cmbTraj.Text; }
        }

        public override string Ref
        {
            get { return cmbRef.Text; }
        }

        public override string Velosity
        {
            get { return txbVelosity.Text; }
        }

        public override string StartPoints
        {
            get { return cmbStartPoint.Text; }
        }

        public override string StopPoints
        {
            get { return cmbStopPoint.Text; }
        }

        public override string Shifting_X
        {
            get { return txbShiftX.Text; }
        }
        public override string Shifting_Y
        {
            get { return txbShiftY.Text; }
        }
        public override string Shifting_Z
        {
            get { return txbShiftZ.Text; }
        }

        public override string Rotation
        {
            get { return txbAngle.Text; }
        }

        string HeatSourceData
        {
            get
            {
                if (rbtARC.Checked)
                {
                    var controls = new List<ArcWeldingControl>();
                    Functions.Search.RecursiveSearch.AllTypedControls(grbWeldRegime, controls);
                    return controls[0].CollectData();
                }
                else if (rbtFSW.Checked)
                {
                    var controls = new List<FSWeldingControl>();
                    Functions.Search.RecursiveSearch.AllTypedControls(grbWeldRegime, controls);
                    return controls[0].CollectData();
                }
                else if (rbtLW.Checked)
                {
                    var controls = new List<LWeldingControl>();
                    Functions.Search.RecursiveSearch.AllTypedControls(grbWeldRegime, controls);
                    return controls[0].CollectData();
                }
                else return null;
            }
            set
            {
                var hsDataAr = value.Split(';');

                WeldContainerControl wcc;
                if (hsDataAr[0] == "ARC")
                {
                    rbtARC.Checked = true;
                    wcc = new ArcWeldingControl() { Dock = DockStyle.Fill };
                }

                else if (hsDataAr[0] == "FSW")
                {
                    rbtFSW.Checked = true;
                    wcc = new FSWeldingControl() { Dock = DockStyle.Fill };
                }

                else
                {
                    rbtLW.Checked = true;
                    wcc = new LWeldingControl() { Dock = DockStyle.Fill };
                }

                grbWeldRegime.Controls.Clear();
                grbWeldRegime.Controls.Add(wcc);

                wcc.InputData(value.Split(';'));                
            }
        }


        public void Add_Functions(List<string> functions)
        {
            funcs.Clear();
            cmbEnergyCalibration.Items.Clear();
            foreach (var function in functions)
            {
                cmbEnergyCalibration.Items.Add(function);
                funcs.Add(function);
            }
        }

        public void Fill_eGroups(string taskType, string elemType, List<string> groupNames)
        {
            if (taskType == "Plain" | taskType == "AxiPlain")
            {
                if (elemType == "Элементы2D")
                {
                    cmbWeldZone.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbWeldZone.Items.Add(eGroup);
                }
            }
            else
            {
                if (elemType == "Элементы3D")
                {
                    cmbWeldZone.Items.Clear();

                    foreach (var eGroup in groupNames)
                        cmbWeldZone.Items.Add(eGroup);
                }
            }
        }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbStartPoint.Items.Clear();
            cmbStopPoint.Items.Clear();
            cmbTraj.Items.Clear();
            cmbRef.Items.Clear();
            for (int i = 0; i < nGroups.Count(); i++)
            {
                cmbStartPoint.Items.Add(nGroups[i]);
                cmbStopPoint.Items.Add(nGroups[i]);
                cmbTraj.Items.Add(nGroups[i]);
                cmbRef.Items.Add(nGroups[i]);
            }
        }

        public WeldingControl()
        {
            InitializeComponent();
            DataName = "Нагрев";
        }

        public override string DataName { get; }
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

            var trajData= GetTrajectoryData();

            if (chbShifting.Checked)
            {
                CheckShiftingInput();
                trajData = trajData + ";" + 
                    string.Format($"{txbShiftX.Text}|{txbShiftY.Text}|{txbShiftZ.Text}|{txbAngle.Text}");
            }

            if (rbtFSW.Checked)
            {
                var hsDataAr = HeatSourceData.Split(';');

                var pinDataStr = string.Join(";", new string[] { "FSWPin", hsDataAr[1], hsDataAr[4], hsDataAr[5], hsDataAr[6], hsDataAr[7], hsDataAr[8] });
                var taskStr = string.Join(" ", new string[] { pinDataStr, cmbWeldZone.Text, txbStartTime.Text, "*", trajData });

                taskStrAr.Add("\"" + taskStr + "\"");

                var shoulderDataStr = string.Join(";", new string[] { "FSWShoulder", hsDataAr[1], hsDataAr[2], hsDataAr[3], hsDataAr[3], "30", hsDataAr[7], hsDataAr[8] });
                taskStr = string.Join(" ", new string[] { shoulderDataStr, cmbWeldZone.Text, txbStartTime.Text, "*", trajData });

                taskStrAr.Add("\"" + taskStr + "\"");
            }

            else
            {
                var taskStr = string.Join(" ", new string[] { HeatSourceData, cmbWeldZone.Text, txbStartTime.Text, "*", trajData });
                taskStrAr.Add("\"" + taskStr + "\"");
            }

            return  string.Join(" ", taskStrAr);
        }       

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmbWeldZone.Text = dataGridView[(int)Column.weldingArea, e.RowIndex].Value.ToString();

                HeatSourceData = dataGridView[(int)Column.weldingType, e.RowIndex].Value.ToString();

                txbStartTime.Text = dataGridView[(int)Column.startTime, e.RowIndex].Value.ToString();

                var str = dataGridView[(int)Column.movingReferenceFrame, e.RowIndex].Value.ToString();
                var strAr = str.Split(';');
                var linesAr = strAr[0].Split('|');

                cmbTraj.Text = linesAr[0];
                cmbRef.Text = linesAr[1];

                txbVelosity.Text = strAr[1];

                cmbStartPoint.Text = strAr[2];
                cmbStopPoint.Text = strAr[3];

                var hsShiftingAr = strAr[4].Split('|');

                txbShiftX.Text = hsShiftingAr[0];
                txbShiftY.Text = hsShiftingAr[1];
                txbShiftZ.Text = hsShiftingAr[2];
                txbAngle.Text = hsShiftingAr[3];

                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        public override void ShowDataButton_Click(object sender, EventArgs e)
        {
            base.ShowDataButton_Click(sender, e);
        }


        public override void StartChecking_Click(object sender, EventArgs e)
        {
            base.StartChecking_Click(sender, e);
        }

        public override void StopChecking_Click(object sender, EventArgs e)
        {
            base.StopChecking_Click(sender, e);
        }

        public override void HideAllDataButton_Click(object sender, EventArgs e)
        {
            base.HideAllDataButton_Click(sender, e);
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }

        public override void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            base.CheckVelocitySlider_Scroll(sender, e);
        }


        private void arcwRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                grbWeldRegime.Controls.Clear();
                var cntrw = new ArcWeldingControl() { Dock = DockStyle.Fill };
                grbWeldRegime.Controls.Add(cntrw);
            }
        }

        private void fswRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                grbWeldRegime.Controls.Clear();
                var cntrw = new FSWeldingControl() { Dock = DockStyle.Fill };
                cntrw.Add_Functions(funcs);
                grbWeldRegime.Controls.Add(cntrw);
            }
        }

        private void rbtLW_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                grbWeldRegime.Controls.Clear();
                var cntrw = new LWeldingControl() { Dock = DockStyle.Fill };
                grbWeldRegime.Controls.Add(cntrw);
            }
        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            CurentSelectedRowInfo = AddRowInfo();
            base.RefreshButton_Click(sender, e);

            btnRefresh.Enabled = false;
   
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[(int)Column.stopTime].Value = "0";
        }

        private void ChbEnergyCalib_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnergyCalibration.Checked)
            {
                    cmbEnergyCalibration.Enabled = true;                
            }
            else
            {
                cmbEnergyCalibration.Text = "";
                cmbEnergyCalibration.Enabled = false;
            }
        }

        private void ChbShifting_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShifting.Checked)
            {
                txbShiftX.Enabled = true;
                txbShiftY.Enabled = true;
                txbShiftZ.Enabled = true;
                txbAngle.Enabled = true;
            }
            else
            {
                txbShiftX.Enabled = false;
                txbShiftY.Enabled = false;
                txbShiftZ.Enabled = false;
                txbAngle.Enabled = false;
            }
        }


    }
    
}
