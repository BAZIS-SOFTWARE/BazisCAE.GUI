using BaseModule.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.Tasks.TasksFromNavigator
{
    public partial class GeneralСontrol : UserControl
    {
        public event Action<AddDataEventArgs> CreatePhysicalDataEvent;

        private List<string> materialNames;
        private List<string> group;
        public GeneralСontrol(string type, List<string> mat, List<string> elementGroup)
        {
            group = elementGroup;
            materialNames = mat;
            InitializeComponent();
            Creator(type);
        }

        public void Control_AddDataEvent( AddDataEventArgs arg2)
        {
            CreatePhysicalDataEvent?.Invoke(arg2);
        }

        private void Creator(string type)
        {
            generalTableLayoutPanel.Controls.Clear();
            if (type == "Материал") 
            {
                generalTableLayoutPanel.Controls.Add(matControl, 0, 0);
                matControl.Add_Materials(materialNames);
                matControl.Fill_eGroups(group);
            } 
            else if (type == "Закрепление") generalTableLayoutPanel.Controls.Add(clampControl, 0, 0);
            else if (type == "Нагрузка") generalTableLayoutPanel.Controls.Add(loadControl, 0, 0);
            else if (type == "Нагрев") generalTableLayoutPanel.Controls.Add(heatControl, 0, 0);
            else if (type == "Среда") generalTableLayoutPanel.Controls.Add(mediaControl, 0, 0);
            generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
        }

        public void btnCreatePhysicalData_Click(object sender, EventArgs e)
        {
            matControl.AddButton_Click();
            
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
                else if (control is ComboBoxEx cmb) cmb.Text = String.Empty;
                else if (control is CheckBox check) check.Checked = false;
                else if (control.HasChildren) Clear(control);
            }
        }
    }
}
