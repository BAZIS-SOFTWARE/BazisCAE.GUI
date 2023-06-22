using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class GraphCreationPage : UserControl
    {
        public event Action<object, CreateTimeGraphArgs> CreateTimeGraphEvent;
        public event Action<object, CreatePathGraphEventArgs> CreatePathGraphEvent;

        public event Action<string> SelectObjectsEvent;

        public GraphCreationPage()
        {
            InitializeComponent();
        }

        Dictionary<string, List<float>> resItems;
        private int lineIndex;

        public void SetResultsItems(Dictionary<string, List<float>> resItems)
        {
            foreach (var item in resItems.Keys)
            {
                comboBox.Items.Add(item);
            }

            this.resItems = resItems;
        }

        private void btnSelectObjs_Click(object sender, EventArgs e)
        {
            if (rbtNodes.Checked)
                SelectObjectsEvent("Узлы");
            else SelectObjectsEvent("Элементы");
        }

        private void btnCreatePlot_Click(object sender, EventArgs e)
        {
            
            if (rbtTime.Checked)
            {
                if (rbtNodes.Checked)
                    CreateTimeGraphEvent(this, new CreateTimeGraphArgs("Узлы"));
                else CreateTimeGraphEvent(this, new CreateTimeGraphArgs("Элементы"));
            }
            else
            {
                var resName = comboBox.SelectedItem.ToString();
                if (richTextBox.Lines.Length > 0)
                {
                    var time = float.Parse(richTextBox.Lines[lineIndex]);
                    if (rbtNodes.Checked)
                        CreatePathGraphEvent(this, new CreatePathGraphEventArgs("Узлы", resName, time));
                    else CreatePathGraphEvent(this, new CreatePathGraphEventArgs("Элементы", resName, time));
                }
            }
        }

        private void rbtPath_Click(object sender, EventArgs e)
        {
            if (rbtPath.Checked)
            {
                comboBox.Enabled = true;
                richTextBox.Enabled = true;
            }

        }

        private void rbtTime_Click(object sender, EventArgs e)
        {
            if (rbtTime.Checked)
            {
                comboBox.Enabled = false;
                richTextBox.Enabled = false;
            }

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var times = resItems[comboBox.SelectedItem.ToString()];

            richTextBox.Clear();
            foreach (var time in times)
                richTextBox.AppendText($"{time}\n");
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            int charIndex = richTextBox.GetCharIndexFromPosition(e.Location);
            //Получаем номер строки по знаку
            lineIndex = richTextBox.GetLineFromCharIndex(charIndex);
        }
    }
}
