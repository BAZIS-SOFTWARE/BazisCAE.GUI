using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BazisGUI.Interfaces.GeneralParams;
using System.Numerics;

namespace BazisGUI.Results.GraphCreation
{
    public enum GraphObjects : int { Узел, Элемент }
    public partial class GraphCreationPage : UserControl
    {
        public event Action<object, CreateTimeGraphArgs> CreateTimeGraphEvent;
        public event Action<object, CreatePathGraphEventArgs> CreatePathGraphEvent;
        public event Action<string> SelectResultsEvent;

        public GraphCreationPage()
        {
            InitializeComponent();
        }

        private int lineIndex;

        public void SetResultsItems(List<float> times)
        {
            richTextBox.Clear();

            for (int i = 0; i < times.Count; i++)
            {
                if (i == times.Count - 1)
                    richTextBox.AppendText($"{times[i]}");
                else
                    richTextBox.AppendText($"{times[i]}\n");
            }
        }

        private void btnCreatePlot_Click(object sender, EventArgs e)
        {
            if (rbtTime.Checked == false & rbtPath.Checked == false)
            {
                MessageBox.Show("Выберите тип графика!");
                return;
            }

            if (rbtNodes.Checked == false & rbtElements.Checked == false)
            {
                MessageBox.Show("Выберите тип объектов!");
                return;
            }

            if (rbtTime.Checked)
            {
                if (rbtNodes.Checked)
                    CreateTimeGraphEvent(this, new CreateTimeGraphArgs(GraphObjects.Узел));
                else CreateTimeGraphEvent(this, new CreateTimeGraphArgs(GraphObjects.Элемент));
            }
            else
            {
                if (richTextBox.Lines.Length > 0)
                {
                    var time = float.Parse(richTextBox.Lines[lineIndex]);
                    if (rbtNodes.Checked)
                        CreatePathGraphEvent(this, new CreatePathGraphEventArgs(GraphObjects.Узел, time));
                    else CreatePathGraphEvent(this, new CreatePathGraphEventArgs(GraphObjects.Элемент, time));
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
                richTextBox.Enabled = true;
            }

        }

        private void rbtTime_Click(object sender, EventArgs e)
        {
            if (rbtTime.Checked)
            {
                richTextBox.Enabled = false;
            }

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
