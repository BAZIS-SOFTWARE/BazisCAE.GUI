using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.Export
{
    public partial class ExportControl : UserControl
    {
        public event Action<string> SelectResultsEvent;
        public event Action<ExportResultEventArgs> ExportResultEvent;
        public event Action<CopyResultDBEventArgs> CopyResultDBEvent;

        private readonly Dictionary<string, List<float>> resultDict;
        private readonly List<string> nodeNames;
        private readonly List<string> elementNames;
        private string selectedText;

        public ExportControl()
        {
            InitializeComponent();
            resultDict = new Dictionary<string, List<float>>();
            nodeNames = new List<string>();
            elementNames = new List<string>();
        }

        public void SetResultValues(Dictionary<string, List<float>> _resDic)
        {
            resultDict.Clear();
            foreach (var key in _resDic.Keys)
                resultDict.Add(key, _resDic[key]);
        }

        public void SetElementNames(IEnumerable<string> names)
        {
            elementNames.Clear();
            elementNames.AddRange(names);
        }

        public void SetNodeNames(IEnumerable<string> names)
        {
            nodeNames.Clear();
            nodeNames.AddRange(names);
        }

        public void SetResultKinds(IEnumerable<string> kinds)
        {
            cmbTasksResults.Items.Clear();
            cmbTasksResults.Items.AddRange(kinds.ToArray());
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
                    cmbGroupName.SelectedItem.ToString(),
                    selectedPath,
                    cmbExtentionType.SelectedItem.ToString(),
                    rbElements.Checked ? Objects.Элемент : Objects.Узел,
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
                || cmbGroupName.Text.Equals(string.Empty)
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
            var rows = resultDict[value.ToString()];
            foreach (var text in rows)
                richTextBox.AppendText(text + "\n");

            SelectResultsEvent?.Invoke(value.ToString());
        }

        private void SetGroupNames()
        {
            cmbGroupName.Items.Clear();

            if (rbNodes.Checked)
                cmbGroupName.Items.AddRange(nodeNames.ToArray());
            else
                cmbGroupName.Items.AddRange(elementNames.ToArray());
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int charIndex = richTextBox.GetCharIndexFromPosition(e.Location);
                //Получаем номер строки по знаку
                var lineIndex = richTextBox.GetLineFromCharIndex(charIndex);
                PaintSelectedText(lineIndex);
                selectedText = richTextBox.Lines[lineIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaintSelectedText(int lineIndex)
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

        private void rbGrid_Clicked(object sender, EventArgs e)
        {
            rbResults.Checked = false;
            rbGrid.Checked = true;

            rbElements.Checked = false;
            rbElements.Enabled = false;
            rbNodes.Checked = true;

            cmbExtentionType.Items.Clear();
            cmbExtentionType.Items.AddRange(new[] { "bpf", "stl-text", "stl-bin" });
        }

        private void rbResults_Clicked(object sender, EventArgs e)
        {
            rbElements.Enabled = true;
            rbGrid.Checked = false;
            rbResults.Checked = true;

            cmbExtentionType.Items.Clear();
            cmbExtentionType.Items.AddRange(new[] { "txt", "csv" });
        }

        private void rbNodes_Clicked(object sender, EventArgs e)
        {
            rbElements.Checked = false;
            rbNodes.Checked = true;

            SetGroupNames();
        }

        private void rbElements_Clicked(object sender, EventArgs e)
        {
            rbNodes.Checked = false;
            rbElements.Checked = true;

            SetGroupNames();
        }
    }
}
