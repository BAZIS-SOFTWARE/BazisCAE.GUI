using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseModule.Tasks.BasicAdvisorControls.Events;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    public partial class HeatControlCreator: UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;
        public HeatControlCreator()
        {
            InitializeComponent();
        }
        public void SelectingHeatingSource(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();

            if (rbtARC.Checked) groupBox3.Controls.Add(tableLayoutPanel3);
            else if (rbtLW.Checked) groupBox3.Controls.Add(tableLayoutPanel2);
            else if (rbtFS.Checked) groupBox3.Controls.Add(tableLayoutPanel4);
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        //private string CreateRowInfo(string stopTime)
        //{

        //    var trajData = string.Format($"{txbShiftX.Text}|{txbShiftY.Text}|{txbShiftZ.Text}|{txbAngle.Text}");

        //    var taskStr = string.Join(" ", new string[] { "1", "*", HeatSourceData, cmbWeldZone.Text, txbStartTime.Text, stopTime, trajData });

        //    return taskStr;
        //}
    }
}
