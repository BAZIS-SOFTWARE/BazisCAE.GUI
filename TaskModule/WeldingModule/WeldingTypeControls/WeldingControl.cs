using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.BasicControls;
using TaskModule.BasicAdvisorControls.Events;
using TaskModule.BasicAdvisorControls.Interfaces;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public partial class WeldingControl : CheckedGridViewAdviserControl, ILoadControl, IFunctionsRelatedControl, ICheckGridViewControl
    {
        List<string> funcs = new List<string>();

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

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
                    var arcControl = (ArcWeldingControl)grbWeldRegime.Controls.Cast<Control>().
      Where(x => x.GetType() == typeof(ArcWeldingControl)).First();

                    return arcControl.CollectData();
                }
                else if (rbtFSW.Checked)
                {
                    var fswControl = (FSWeldingControl)grbWeldRegime.Controls.Cast<Control>().
Where(x => x.GetType() == typeof(FSWeldingControl)).First();

                    return fswControl.CollectData();
                }
                else if (rbtLW.Checked)
                {
                    var lwControl = (LWeldingControl)grbWeldRegime.Controls.Cast<Control>().
Where(x => x.GetType() == typeof(LWeldingControl)).First();

                    return lwControl.CollectData();
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

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbWeldZone.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbWeldZone.Items.Add(eGroup);
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

            var trajData = GetTrajectoryData();

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

            return string.Join(" ", taskStrAr);
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
        }


        private void arcwRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                grbWeldRegime.Controls.Clear();
                var cntrw = new ArcWeldingControl() { Dock = DockStyle.Fill };
                grbWeldRegime.Controls.Add(cntrw);
                GetChildControlExpandHeight(grbWeldRegime);
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
                GetChildControlExpandHeight(grbWeldRegime);
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
                GetChildControlExpandHeight(grbWeldRegime);
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

        private void grbWeldRegime_Paint(object sender, PaintEventArgs e)
        {
            var grb = (GroupBox)sender;
            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            var locRect = new Point(textSize + 5, 3);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var rect = new Rectangle(locRect, new Size(8, 8));

            e.Graphics.DrawRectangle(blackPen, rect);
            if (grb.Height == 17)
            {
                e.Graphics.DrawString("+", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 4, 0);
            }
            else
            {
                e.Graphics.DrawString("-", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 6, 0);
            }
        }

        private void grbWeldRegime_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = grbWeldRegime;

            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            if (e.Location.X > textSize + 5 & e.Location.X < textSize + 15 && e.Location.Y <= 10)
            {
                if (grb.Height == 17)
                {
                    GetChildControlExpandHeight(grb);
                }

                else grb.Height = 17;
            }
        }

        private void GetChildControlExpandHeight(GroupBox grb)
        {
            var heigth = 0;
            var gap = 20;
            foreach (Control control in grb.Controls)
            {
                if (control is UserControl uControl)
                    foreach (Control cntr in uControl.Controls)
                    {
                        if (cntr is TextBox txb | cntr is ComboBox cmb | cntr is Button)
                        {
                            heigth = heigth + cntr.Size.Height;
                            gap = gap + 6;
                        }
                    }
            }
            grb.Height = heigth + gap;
        }
    }
}
