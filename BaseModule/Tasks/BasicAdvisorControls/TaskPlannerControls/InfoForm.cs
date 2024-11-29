using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvisorControls.TaskPlannerControls
{
    public partial class InfoForm : Form
    {
        public InfoForm(string path)
        {
            InitializeComponent();
            this.Text = path;
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            try
            {
                var lines = File.ReadAllLines(this.Text, win1251);
                richTextBox.Lines = lines;
                richTextBox.SelectionStart = richTextBox.Text.Length;
                richTextBox.ScrollToCaret();
            }
            catch (Exception) { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            try
            {
                var lines = File.ReadAllLines(this.Text, win1251);
                richTextBox.Lines = lines;
                richTextBox.SelectionStart = richTextBox.Text.Length;
                richTextBox.ScrollToCaret();
            }
            catch (Exception) { }
        }
    }
}
