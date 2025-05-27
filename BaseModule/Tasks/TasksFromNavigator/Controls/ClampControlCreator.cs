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
using System.Globalization;

namespace BaseModule.Tasks.TasksFromNavigator.Controls
{
    public partial class ClampControlCreator: UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;
        public string DataName { get; }
        public ClampControlCreator()
        {
            InitializeComponent();
            DataName = "Закрепление";
        }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbNodeGr.Items.Clear();
            for (int i = 0; i < nGroups.Count(); i++)
            {
                cmbNodeGr.Items.Add(nGroups[i]);
            }
        }
        public void Add_Functions(List<string> functions)
        {
            cmbStiffnessFunc.Items.Clear();
            foreach (var function in functions)
            {
                cmbStiffnessFunc.Items.Add(function);
            }
        }

        public void AddButton_Click()
        {
            if (!IsValidated()) return;

            var rows = new List<string>();
            try
            {
                if (chbLRF.Checked)
                    rows.Add(CreateRowInfo("LRF"));

                else
                {
                    if (chbX.Checked)
                        rows.Add(CreateRowInfo("X"));
                    if (chbY.Checked)
                        rows.Add(CreateRowInfo("Y"));
                    if (chbZ.Checked)
                        rows.Add(CreateRowInfo("Z"));
                }

                foreach (var row in rows)
                {

                    AddDataEvent(new AddDataEventArgs(DataName, row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                cmbKind.IsValueValid(),
                cmbNodeGr.IsValueValid(),
                cmbStiffnessFunc.IsValueValid()
        };
            return checks.All(x => x);
        }

        private string CreateRowInfo(string direction)
        {
            var stiffnessFunc = cmbStiffnessFunc.Text == "" ? "0" : cmbStiffnessFunc.Text;
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} * {4} {5} *",
                    cmbNodeGr.Text, cmbKind.Text, direction, stiffnessFunc, txbStartTime.Text, txbStopTime.Text);
        }

        private void kindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (cmbKind.Text == "Жесткое")
            {
                chbLRF.Enabled = false;
            }
            else
                chbLRF.Enabled = true;

            if (comboBox.SelectedIndex == 0)
            {
                cmbStiffnessFunc.Enabled = false;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                cmbStiffnessFunc.Enabled = true;
                chbX.Checked = true;
                chbY.Checked = true;
                chbZ.Checked = true;
            }
            else
            {
                cmbStiffnessFunc.Enabled = false;
            }
        }
        private void ChbDirection_Click(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;

            if (chb.Checked)
            {
                if (chb.Tag.ToString() == "0" || chb.Tag.ToString() == "1" || chb.Tag.ToString() == "2")
                {
                    chbLRF.Checked = false;
                }

                else
                {
                    chbX.Checked = false;
                    chbY.Checked = false;
                    chbZ.Checked = false;
                }
            }
        }

        private void chbLRF_EnabledChanged(object sender, EventArgs e)
        {
            if (!chbLRF.Enabled)
                chbLRF.Checked = false;
        }
    }
}
