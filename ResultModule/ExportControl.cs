using Geometry;
using ModelInterfaces;
using PlayerControl;
using ProjectInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class ExportControl : UserControl
    {
        public event Action<string> SelectResultsEvent;
        public event Action<ExportResultEventArgs> ExportResultEvent;

        private readonly Dictionary<string, List<float>> resItems;
        private readonly List<string> nodesNames;
        private string selectedText;

        public ExportControl()
        {
            InitializeComponent();
            resItems = new Dictionary<string, List<float>>();
            nodesNames = new List<string>();
            cmbExtentionType.Items.AddRange(new[] {".bpf", ".STL(bin)", ".STL(text)"});
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFormBeforeButtonClick();
                var fbd = new FolderBrowserDialog();
                string selectedPath = "";
                if (fbd.ShowDialog() == DialogResult.OK)
                    selectedPath = fbd.SelectedPath;
                else
                    return;

                var time = float.Parse(selectedText);
                var taskKind = cmbTasksResults.SelectedItem.ToString();
                var resKind = cmbNodeGroupName.SelectedItem.ToString();
                var extension = cmbExtentionType.SelectedItem.ToString();
                ExportResultEvent(new ExportResultEventArgs(time, taskKind, resKind, selectedPath, extension));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckFormBeforeButtonClick()
        {
            if (cmbTasksResults.Text == "" || selectedText == "" || cmbNodeGroupName.Text == "" || cmbExtentionType.Text == "")
                throw new Exception("Перед экспортом результатов необходимо выбрать тип задачи и интервал времени для экспорта результата");
        }

        private void cmbTasksResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbTasksResults.SelectedItem;
            var rows = resItems[value.ToString()];
            foreach (var text in rows)
                richTextBox1.AppendText(text + "\n");

            SelectResultsEvent?.Invoke(value.ToString());
        }

        public void SetSelectorsValues(Dictionary<string, List<float>> resDic)
        {
            foreach(var key in resDic.Keys)
            {
                cmbTasksResults.Items.Add(key);
                resItems.Add(key, resDic[key]);
            }
        }

        public void SetNodesNames(List<string> nodesGroupName)
        {
            foreach (var name in nodesGroupName)
            {
                cmbNodeGroupName.Items.Add(name);
                nodesNames.Add(name);
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int charIndex = richTextBox1.GetCharIndexFromPosition(e.Location);
                //Получаем номер строки по знаку
                var lineIndex = richTextBox1.GetLineFromCharIndex(charIndex);
                PaintSelectedText(lineIndex);
                selectedText = richTextBox1.Lines[lineIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaintSelectedText(int lineIndex)
        {
            int startFromIndex = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
            //Получаем длину строки
            int lineLength = richTextBox1.Lines[lineIndex].Length;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = System.Drawing.Color.White;
            //Выделяем текст с первого символа строки до конца строки
            richTextBox1.Select(startFromIndex, lineLength);
            //Устанавливаем выделенному тексту оранжевый фон
            richTextBox1.SelectionBackColor = System.Drawing.Color.Orange;
            richTextBox1.Select(startFromIndex, 0);
        }
    }
}
