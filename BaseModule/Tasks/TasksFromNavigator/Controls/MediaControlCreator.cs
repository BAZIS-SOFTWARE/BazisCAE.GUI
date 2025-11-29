using BazisGUI.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.Tasks.TasksFromNavigator.Controls
{
    public partial class MediaControlCreator: UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;
        public string DataName { get; }
        public MediaControlCreator()
        {
            InitializeComponent();
            mediaRadioButton_CheckedChanged(this, EventArgs.Empty);
            DataName = "Среда";
        }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbNode.Items.Clear();
            foreach (var nGroup in nGroups)
            {
                cmbNode.Items.Add(nGroup);
            }
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public void Add_Functions(List<string> functions)
        {
            cmbFunc.Items.Clear();
            cmbTermoCycle.Items.Clear();
            foreach (var function in functions)
            {
                cmbFunc.Items.Add(function);
                cmbTermoCycle.Items.Add(function);
            }
        }

        public void AddButton_Click()
        {
            if (!IsValidated()) return;
            try
            {
                var rowInfo = AddRowInfo();
                AddDataEvent(new AddDataEventArgs(DataName, rowInfo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                txbMediaTemp.IsValueValid(),
                cmbEl.IsValueValid(),
                cmbFunc.IsValueValid(),
                cmbNode.IsValueValid(),
                cmbTermoCycle.IsValueValid()

            };
            return checks.All(x => x);
        }
        private string AddRowInfo()
        {
            //TO DO
            var dataList = new List<string>();

            if (rbtHeatFlow.Checked)
            {
                dataList.Add(cmbEl.Text);
                dataList.Add(cmbFunc.Text);
                dataList.Add(txbMediaTemp.Text);
            }
            else
            {
                dataList.Add(cmbNode.Text);
                dataList.Add("*");
                dataList.Add(cmbTermoCycle.Text);
            }

            dataList.Add(txbStartTime.Text);
            dataList.Add(txbStopTime.Text);
            dataList.Add("*");

            return string.Join(" ", dataList);
        }

        private void mediaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = true;
            cmbEl.Enabled = true;
            cmbFunc.Enabled = true;

            cmbTermoCycle.Enabled = false;
            cmbNode.Enabled = false;
        }

        private void termocycleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            txbMediaTemp.Enabled = false;
            cmbEl.Enabled = false;
            cmbFunc.Enabled = false;

            cmbTermoCycle.Enabled = true;
            cmbNode.Enabled = true;
        }
    }
}
