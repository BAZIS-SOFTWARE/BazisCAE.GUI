using System;
using System.Windows.Forms;
using TaskModule.BasicAdvisorControls.Events;

namespace TaskModule.BasicAdvisorControls.BasicControls
{
    public enum CheckState : int { start, pause, continuation };
    public partial class CheckedGridViewAdviserControl : GridViewAdviserControl
    {
        public CheckedGridViewAdviserControl()
        {
            InitializeComponent();
        }

        public virtual string Traj { get; internal set; }
        public virtual string Ref { get; internal set; }
        public virtual string Velosity { get; internal set; }
        public virtual string StartPoints { get; internal set; }
        public virtual string StopPoints { get; internal set; }
        public virtual string Shifting_X { get; internal set; }
        public virtual string Shifting_Y { get; internal set; }
        public virtual string Shifting_Z { get; internal set; }
        public virtual string Rotation { get; internal set; }

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
            if (Shifting_X == "")
                throw new Exception("Смещение по X не задано!");
            if (Shifting_Y == "")
                throw new Exception("Смещение по Y не задано!");
            if (Shifting_Z == "")
                throw new Exception("Смещение по Z не задано!");
            if (Rotation == "")
                throw new Exception("Угол незадан!");
        }
    }
}
