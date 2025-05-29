using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.TasksFromNavigator.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.Tasks.TasksFromNavigator
{
    public partial class GeneralСontrol : UserControl
    {
        public event Action<AddDataEventArgs> CreatePhysicalDataEvent;

        private List<string> materialNames;
        private List<string> funcNames;
        private List<string> nGroup;
        private List<string> eGroup;
        public GeneralСontrol(string type, List<string> mat, List<string> func, List<string> eGrpsNames, List<string> nGrpsNames)
        {
            eGroup = eGrpsNames;
            nGroup = nGrpsNames;
            funcNames = func;
            materialNames = mat;
            InitializeComponent();
            Creator(type);
        }

        public void Control_AddDataEvent(AddDataEventArgs arg2)
        {
            var dataEventArgs = arg2;
            if (generalTableLayoutPanel.Controls.OfType<HeatControlCreator>().Any())
            {
                var data = dataEventArgs.DataInfo.Split(' ');
                data[4] = txbStartTime.Text;
                data[5] = txbStartTime.Text;
                var newData = string.Join(" ", data);
                var frameFunction = data[2].Split(';');
                dataEventArgs = new AddDataEventArgs(dataEventArgs.DataName, newData);
            }
            CreatePhysicalDataEvent?.Invoke(dataEventArgs);
        }

        public void Fill_nGroups(List<string> nGroups)
        {
            cmbTraj.Items.Clear();
            cmbRef.Items.Clear();
            for (int i = 0; i < nGroups.Count(); i++)
            {
                cmbTraj.Items.Add(nGroups[i]);
                cmbRef.Items.Add(nGroups[i]);
            }
        }
        private void Creator(string type)
        {
            Fill_nGroups(nGroup);
            generalTableLayoutPanel.Controls.Clear();
            if (type == "Материал")
            {
                generalTableLayoutPanel.Controls.Add(matControl, 0, 0);
                matControl.Add_Materials(materialNames);
                matControl.Fill_eGroups(eGroup);
            }
            else if (type == "Закрепление")
            {
                generalTableLayoutPanel.Controls.Add(clampControl, 0, 0);
                clampControl.Add_Functions(funcNames);
                clampControl.Fill_nGroups(nGroup);
            }
            else if (type == "Нагрузка")
            {
                generalTableLayoutPanel.Controls.Add(loadControl, 0, 0);
                loadControl.Fill_nGroups(nGroup);
                loadControl.Add_Functions(funcNames);
            }
            else if (type == "Нагрев")
            {
                generalTableLayoutPanel.Controls.Add(heatControl, 0, 0);
                heatControl.Fill_eGroups(eGroup);
            }
            else if (type == "Среда") 
            {
                generalTableLayoutPanel.Controls.Add(mediaControl, 0, 0);
                mediaControl.Fill_eGroups(eGroup);
                mediaControl.Fill_nGroups(nGroup);
                mediaControl.Add_Functions(funcNames);
            }
            generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
        }

        private bool IsValidated()
        {
            var checks = new List<bool>()
            {
                cmbTraj.IsValueValid(),
                cmbRef.IsValueValid(),
                txbVelosity.IsValueValid(),
                txbStartTime.IsValueValid(),
                txbX.IsValueValid(),
                txbY.IsValueValid(),
                txbZ.IsValueValid(),
                txbAngleX.IsValueValid(),
                txbAngleY.IsValueValid(),
                txbAngleZ.IsValueValid(),
            };
            return checks.All(x => x);
        }
        private void btnCreatePhysicalData_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            matControl.AddButton_Click();
            clampControl.AddButton_Click();
            heatControl.AddButton_Click();
            loadControl.AddButton_Click();
            mediaControl.AddButton_Click();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Clear(this);
        }

        private void Clear(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control control in parent.Controls)
            {
                if (control is TextBoxEx textBox) textBox.Clear();
                else if (control is ComboBoxEx cmb) cmb.SelectedIndex = -1;
                else if (control is CheckBox check) check.Checked = false;
                else if (control.HasChildren) Clear(control);
            }
        }
    }
}
