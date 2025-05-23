using System;
using System.Windows.Forms;
using UserControlsEx;

namespace BaseModule.Tasks.TasksFromNavigator
{
    public partial class GeneralСontrol : UserControl
    {
        public GeneralСontrol(string type)
        {
            InitializeComponent();
            Creator(type);
        }
        private void Creator(string type)
        {
            generalTableLayoutPanel.Controls.Clear();
            if (type == "Материал") generalTableLayoutPanel.Controls.Add(matControl, 0, 0);
            else if (type == "Закрепление") generalTableLayoutPanel.Controls.Add(clampControl, 0, 0);
            else if (type == "Нагрузка") generalTableLayoutPanel.Controls.Add(loadControl, 0, 0);
            else if (type == "Нагрев") generalTableLayoutPanel.Controls.Add(heatControl, 0, 0);
            else if (type == "Среда") generalTableLayoutPanel.Controls.Add(mediaControl, 0, 0);
            generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Clear(this);
        }
        private void Clear(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBoxEx textBox) textBox.Clear();
                else if (control is ComboBoxEx cmb) cmb.Text = String.Empty;
                else if (control is CheckBox check) check.Checked = false;
                else if (control.HasChildren) Clear(control);
            }
        }
    }
}
