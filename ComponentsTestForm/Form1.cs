using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentsTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBoxEx1_CheckBoxClick(object obj)
        {
            if (groupBoxEx1.CheckState)
                txbTest.Text = "Проверка";
            else
                txbTest.Text = "Нет проверки";
        }
    }
}
