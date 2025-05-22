using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Tasks.TasksFromNavigator
{
    public partial class GeneralСontrol: UserControl
    {
        public GeneralСontrol(string type)
        {
            InitializeComponent();
            Creator(type);
        }
        private void Creator(string type)
        {
            generalTableLayoutPanel.Controls.Clear();
            if(type == "Материал")
            {
                generalTableLayoutPanel.Controls.Add(matControl, 0, 0);
                generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
            }
            else if (type == "Закрепление") 
            {
                generalTableLayoutPanel.Controls.Add(clampControl, 0, 0);
                generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
            }
            else if (type == "Нагрузка")
            {
                generalTableLayoutPanel.Controls.Add(loadControl, 0, 0);
                generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
            }
            else if (type == "Нагрев")
            {
                generalTableLayoutPanel.Controls.Add(heatControl, 0, 0);
                generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
            }
            else if (type == "Среда")
            {
                generalTableLayoutPanel.Controls.Add(mediaControl, 0, 0);
                generalTableLayoutPanel.Controls.Add(movementParametersGroupBox, 0, 1);
            }
        }
    }
}
