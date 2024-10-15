using Geometry;
using ModelInterfaces;
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
        public event Action<CopyResultDBEventArgs> CopyResultDBEvent;

        private readonly Dictionary<string, List<float>> resItems;
        private readonly List<string> nodesNames;
        private string selectedText;

        public ExportControl()
        {
            InitializeComponent();
            resItems = new Dictionary<string, List<float>>();
            nodesNames = new List<string>();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFormBeforeExport();
                string selectedPath = "";
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                    selectedPath = fbd.SelectedPath;
                else
                    return;

                ExportResultEvent(new ExportResultEventArgs(float.Parse(selectedText),
                    cmbTasksResults.SelectedItem.ToString(),
                    cmbNodeGroupName.SelectedItem.ToString(),
                    selectedPath,
                    cmbExtentionType.SelectedItem.ToString(),
                    rbElements.Checked ? ObjType.Элемент : ObjType.Узел,
                    rbGrid.Checked ? ExportType.Grid : ExportType.Results));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveBD_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFormBeforeDBSave();
                string selectedPath = "";
                var fbd = new FolderBrowserDialog();
                
                if (fbd.ShowDialog() == DialogResult.OK)
                    selectedPath = fbd.SelectedPath;
                else
                    return;

                CopyResultDBEvent(new CopyResultDBEventArgs(cmbTasksResults.Text, float.Parse(selectedText), selectedPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckFormBeforeExport()
        {
            if (selectedText.Equals(string.Empty)
                || cmbTasksResults.Text.Equals(string.Empty)
                || cmbNodeGroupName.Text.Equals(string.Empty)
                || cmbExtentionType.Text.Equals(string.Empty)
                || (!rbGrid.Checked && !rbResults.Checked))
                throw new Exception("Перед экспортом результатов необходимо выбрать тип задачи и интервал времени для экспорта результата");
        }

        private void CheckFormBeforeDBSave()
        {
            if (selectedText.Equals(string.Empty) || cmbTasksResults.Text.Equals(string.Empty))
                throw new Exception("Перед сохранением результата необходимо выбрать временной интервал и задачу");
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
            richTextBox1.SelectionBackColor = System.Drawing.Color.LightBlue;
            richTextBox1.Select(startFromIndex, 0);
        }

        private void rbGrid_Clicked(object sender, EventArgs e)
        {
            rbResults.Checked = false;
            rbGrid.Checked = true;

            rbElements.Checked = false;
            rbElements.Enabled = false;
            rbNodes.Checked = true;

            cmbExtentionType.Items.Clear();
            cmbExtentionType.Items.AddRange(new[] { "*.bpf", "*.STL (Text)", "*.STL (bin)" });
        }

        private void rbResults_Clicked(object sender, EventArgs e)
        {
            rbElements.Enabled = true;
            rbGrid.Checked = false;
            rbResults.Checked = true;

            cmbExtentionType.Items.Clear();
            cmbExtentionType.Items.AddRange(new[] { "*.TXT", "*.CSV" });
        }

        private void rbNodes_Clicked(object sender, EventArgs e)
        {
            rbElements.Checked = false;
            rbNodes.Checked = true;
        }

        private void rbElements_Clicked(object sender, EventArgs e)
        {
            rbNodes.Checked = false;
            rbElements.Checked = true;
        }
    }
}
