using BazisGUI.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.Tasks.TasksFromNavigator.Controls
{
    public partial class MaterialControlCreator: UserControl
    {
        public event Action<AddDataEventArgs> AddDataEvent;

        public string DataName { get; }

        public MaterialControlCreator()
        {
            InitializeComponent();
            DataName = "Материал";
        }

        public void Add_Materials(List<string> materials)
        {
            cmbMat.Items.Clear();
            foreach (var material in materials)
            {
                cmbMat.Items.Add(material);
            }
        }

        public void Fill_eGroups(List<string> groupNames)
        {
            cmbEl.Items.Clear();

            foreach (var eGroup in groupNames)
                cmbEl.Items.Add(eGroup);
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid(),
                cmbEl.IsValueValid(),
                cmbMat.IsValueValid()
            };
            return checks.All(x => x);
        }

        public void AddButton_Click()
        {
            if (!IsValidated()) return;
            try
            {
                var row = CreateRowInfo();
                AddDataEvent?.Invoke(new AddDataEventArgs(DataName, row));   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateRowInfo() => string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} *", cmbEl.Text, cmbMat.Text, txbStartTime.Text, txbStopTime.Text);
    }
}
