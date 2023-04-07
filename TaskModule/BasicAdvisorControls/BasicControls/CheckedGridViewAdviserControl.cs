using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using BasicAdvisorControls.Interfaces;
using System.IO;
using System.Globalization;
using MB.Controls;

namespace BasicAdvisorControls
{
    public enum CheckState : int { start, pause, continuation };
    public partial class CheckedGridViewAdviserControl : GridViewAdviserControl, ICheckGridViewControl
    {
        public CheckedGridViewAdviserControl()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new System.EventHandler(Timer_Tick);
        }

        public CheckState CheckState { get; set; }

        public float CheckCurrentTime { get; set; }

        public int CheckStepTime { get; set; }

        public float CheckStartTime { get; set; }

        public float CheckStopTime { get; set; }
        public virtual string Traj { get; internal set; }
        public virtual string Ref { get; internal set; }
        public virtual string Velosity { get; internal set; }
        public virtual string StartPoints { get; internal set; }
        public virtual string StopPoints { get; internal set; }
        public virtual string Shifting_X { get; internal set; }
        public virtual string Shifting_Y { get; internal set; }
        public virtual string Shifting_Z { get; internal set; }
        public virtual string Rotation { get; internal set; }

        System.Windows.Forms.Timer timer;

        public event Action<object, ShowDataEventArgs> ShowDataEvent;
        public event Action<object, HideDataEventArgs> HideDataEvent;
        public event Action<object, CheckDataEventArgs> CheckDataEvent;

        //public event Action<object, EventArgs> StartCheckingEvent;
        //public event Action<object, EventArgs> PauseCheckingEvent;
        //public event Action<object, EventArgs> StopCheckingEvent;

        public virtual void StartChecking_Click(object sender, EventArgs e)
        {
            if (CountRows == 0) MessageBox.Show("Добавьте данные для проверки!");
            else
            {
                if (CheckState == CheckState.pause)
                {
                    CheckState = CheckState.continuation;
                    timer.Stop();

                    SetCheckButtonState();
                }
                else if (CheckState == CheckState.start)
                {
                    CheckState = CheckState.pause;

                    timer.Enabled = true;
                    timer.Interval = 500;
                    timer.Start();

                    SetTimeAttributes();
                    SetCheckButtonState();
                }
                else
                {
                    CheckState = CheckState.pause;
                    timer.Start();

                    SetCheckButtonState();
                }
            }
        }

        private void SetCheckButtonState()
        {
            var buttonList = new List<Button>();
            SearchControls(this, buttonList);

            var checkButton = buttonList.Find(x => x.Name == "btnCheckDinamic");

            var assembly = Assembly.GetExecutingAssembly();
            var res = assembly.GetManifestResourceNames();
            Stream stream;
            if (CheckState == CheckState.start)
            {
                stream = assembly.GetManifestResourceStream("BasicAdvisorControls.Resources.StartCheck.ico");
            }
            else if(CheckState == CheckState.pause)
            {
                stream = assembly.GetManifestResourceStream("BasicAdvisorControls.Resources.Pause.ico");
            }
            else
            {
                stream = assembly.GetManifestResourceStream("BasicAdvisorControls.Resources.StartCheck.ico");
            }
            checkButton.Image = Image.FromStream(stream);
        }

        private void SetTimeAttributes()
        {
            var gridViewList = new List<DataGridView>();
            SearchControls(this, gridViewList);

            var checkStopTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
       .Max(r => Convert.ToSingle(r.Cells["stopColumn"].Value, CultureInfo.InvariantCulture));

            var checkStartTime = gridViewList[0].Rows.Cast<DataGridViewRow>()
                        .Min(r => Convert.ToSingle(r.Cells["startColumn"].Value, CultureInfo.InvariantCulture));

            CheckStartTime = checkStartTime;
            CheckStopTime = checkStopTime;
            CheckCurrentTime = checkStartTime;

            var sliderList = new List<ColorSlider>();
            SearchControls(this, sliderList);

            CheckStepTime = sliderList[0].Value;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CheckCurrentTime >= CheckStopTime)
            {
                timer.Stop();
                timer.Enabled = false;
                CheckState = CheckState.start;
                SetCheckButtonState();
            }
            else
            {
                CheckDataEvent(this, new CheckDataEventArgs(DataName, CheckCurrentTime));
                Thread.Sleep(100);
                CheckCurrentTime += CheckStepTime;
            }

        }

        public virtual void StopChecking_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;

            CheckState = CheckState.start;
            SetCheckButtonState();

            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public virtual void ShowDataButton_Click(object sender, EventArgs e)
        {
            if (CountSelectedRow > 0)
            {
                ShowDataEvent(this, new ShowDataEventArgs(DataName, GetSelectedRowIndexes().ToList()));
            }
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.DataGridView_RowHeaderMouseClick(sender, e);
        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            base.RefreshButton_Click(sender, e);
        }

        public virtual void HideAllDataButton_Click(object sender, EventArgs e)
        {
            HideDataEvent(this, new HideDataEventArgs(DataName));
        }

        public virtual void CheckVelocitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            CheckStepTime = e.NewValue;
        }
        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
        }

        public string GetTrajectoryData()
        {

            if (Traj.Equals(Ref))
                throw new Exception("Траектория и опорная линия должны различаться!");

            if (Traj == "")
                throw new Exception("Выберите линию движения!");
            if (Ref == "")
                throw new Exception("Выберите опорную линию!");
            if (Velosity == "")
                throw new Exception("Задайте скорость движения!");

            if (StartPoints == "")
                throw new Exception("Задайте точки начала движения!");

            if (StopPoints == "")
                throw new Exception("Задайте точки остановки движения!");

            return string.Format("{0}|{1};{2};{3};{4}",
                Traj, Ref, Velosity, StartPoints, StopPoints);
        }

        public void CheckShiftingInput()
        {
            if (!float.TryParse(Shifting_X, NumberStyles.Float, CultureInfo.InvariantCulture, out float x))
                throw new Exception("Первое число задано неверно!");
            if (!float.TryParse(Shifting_Y, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
                throw new Exception("Второе число задано неверно!");
            if (!float.TryParse(Shifting_Z, NumberStyles.Float, CultureInfo.InvariantCulture, out float z))
                throw new Exception("Третье число задано неверно!");
            if (!float.TryParse(Rotation, NumberStyles.Float, CultureInfo.InvariantCulture, out float angle))
                throw new Exception("Угол задан неверно!");
        }
    }
}
