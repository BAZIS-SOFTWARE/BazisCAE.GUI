using BazisGUI.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.Tasks.TasksFromNavigator.Controls
{
    public partial class LoadControlCreator : UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;
        public string DataName { get; }
        public LoadControlCreator()
        {
            InitializeComponent();
            DataName = "Нагрузка";
        }
        public void Fill_nGroups(List<string> groups)
        {
            cmbGr.Items.Clear();
            foreach (var group in groups)
            {
                cmbGr.Items.Add(group);
            }
        }

        public void Add_Functions(List<string> functions)
        {
            cmbLoadFunction.Items.Clear();

            foreach (var function in functions)
            {
                cmbLoadFunction.Items.Add(function);
            }
        }

        public void AddButton_Click()
        {
            if (!IsValidated()) return;
            var rows = new List<string>();
            try
            {
                if (chbLRF.Checked) rows.Add(CreateRowInfo("LRF"));
                else
                {
                    if (chbX.Checked) rows.Add(CreateRowInfo("X"));
                    if (chbY.Checked) rows.Add(CreateRowInfo("Y"));
                    if (chbZ.Checked) rows.Add(CreateRowInfo("Z"));
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

        private string CreateRowInfo(string direction)
        {
            var loadFunc = cmbLoadFunction.Text == "" ? "*" : cmbLoadFunction.Text;
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} {6} *",
                 cmbGr.Text, cmbKind.Text, direction, txbValue.Text, loadFunc, txbStartTime.Text, txbStopTime.Text);
        }

        private bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                txbValue.IsValueValid(),
                cmbGr.IsValueValid(),
                cmbKind.IsValueValid(),
                cmbLoadFunction.IsValueValid(),
            };
            return checks.All(x => x);
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
    }
}
