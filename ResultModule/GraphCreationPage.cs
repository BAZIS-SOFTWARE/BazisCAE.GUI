using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelInterfaces;

namespace ResultModule
{
    public partial class GraphCreationPage : UserControl
    {
        public event Action<object, CreateTimeGraphArgs> CreateTimeGraphEvent;
        public event Action<object, CreatePathGraphEventArgs> CreatePathGraphEvent;

        public event Action<ObjType> SelectObjectsEvent;
        public event Action<string> SelectResultsEvent;

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
                SelectObjectsEvent(ObjType.Узел);
            else SelectObjectsEvent(ObjType.Элемент);
        }

        private void btnCreatePlot_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)
                MessageBox.Show("Выберите тип задачи!");
            var resKind = comboBox.SelectedItem.ToString();

            if (rbtTime.Checked)
            {
                if (rbtNodes.Checked)
                    CreateTimeGraphEvent(this, new CreateTimeGraphArgs(ObjType.Узел, resKind));
                else CreateTimeGraphEvent(this, new CreateTimeGraphArgs(ObjType.Элемент, resKind));
            }
            else
            {
                if (richTextBox.Lines.Length > 0)
                {
                    var time = float.Parse(richTextBox.Lines[lineIndex]);
                    if (rbtNodes.Checked)
                        CreatePathGraphEvent(this, new CreatePathGraphEventArgs(ObjType.Узел, resKind, time));
                    else CreatePathGraphEvent(this, new CreatePathGraphEventArgs(ObjType.Элемент, resKind, time));
                }
            }
        }

        private void MarkTimeStep(int lineIndex)
        {
            int startFromIndex = richTextBox.GetFirstCharIndexFromLine(lineIndex);
            //Получаем длину строки
            int lineLength = richTextBox.Lines[lineIndex].Length;

            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = System.Drawing.Color.White;
            //Выделяем текст с первого символа строки до конца строки
            richTextBox.Select(startFromIndex, lineLength);
            //Устанавливаем выделенному тексту оранжевый фон
            richTextBox.SelectionBackColor = System.Drawing.Color.Orange;
            richTextBox.Select(startFromIndex, 0);
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

            SelectResultsEvent?.Invoke(comboBox.SelectedItem.ToString());        
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            int charIndex = richTextBox.GetCharIndexFromPosition(e.Location);
            //Получаем номер строки по знаку
            lineIndex = richTextBox.GetLineFromCharIndex(charIndex);
            MarkTimeStep(lineIndex);
        }
    }
}
