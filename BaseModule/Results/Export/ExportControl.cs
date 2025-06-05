using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule.Results.Export
{
    public enum ExportType
    {
        Grid,
        Results
    }
    public partial class ExportControl : UserControl
    {
        public event Action<ExportResultEventArgs> ExportResultEvent;
        public event Action<CopyResultDBEventArgs> CopyResultDBEvent;

        private readonly List<float> times;
        private readonly List<string> nodeNames;
        private readonly List<string> elementNames;
        private string selectedText;

        public ExportControl()
        {
            InitializeComponent();
            times = new List<float>();
            nodeNames = new List<string>();
            elementNames = new List<string>();
        }

        public void SetTimes(IEnumerable<float> _times)
        {
            times.Clear();
            times.AddRange(_times);
            richTextBox.Text = string.Join("\n", times);
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

            cmbGroupName.Items.Clear();
            cmbGroupName.Items.AddRange(nodeNames.ToArray());
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
                else return;

                ExportResultEvent(new ExportResultEventArgs(float.Parse(selectedText),
                    cmbGroupName.SelectedItem.ToString(),
                    selectedPath,
                    cmbExtentionType.SelectedItem.ToString(),
                    rbElements.Checked ? Objects.Элемент3D : Objects.Узел,
                    rbGrid.Checked ? ExportType.Grid : ExportType.Results));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
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
                else return;

                CopyResultDBEvent(new CopyResultDBEventArgs(float.Parse(selectedText),
                    selectedPath,
                    rbElements.Checked ? Objects.Элемент : Objects.Узел));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CheckFormBeforeExport()
        {
            if (selectedText == null || selectedText.Equals(string.Empty)
                || cmbGroupName.Text == null || cmbGroupName.Text.Equals(string.Empty)
                || cmbExtentionType.Text == null || cmbExtentionType.Text.Equals(string.Empty)
                || (!rbGrid.Checked && !rbResults.Checked))
                throw new Exception("Перед экспортом результатов необходимо выбрать тип задачи и интервал времени для экспорта результата");
        }

        private void CheckFormBeforeDBSave()
        {
            if (selectedText == null || selectedText.Equals(string.Empty))
                throw new Exception("Перед сохранением результата необходимо выбрать временной интервал и задачу");
        }

        private void SetGroupNames()
        {
            cmbGroupName.Items.Clear();

            if (rbNodes.Checked) 
                cmbGroupName.Items.AddRange(nodeNames.ToArray());

            else cmbGroupName.Items.AddRange(elementNames.ToArray());
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PaintSelectedText(int lineIndex)
        {
            int startIndex = richTextBox.GetFirstCharIndexFromLine(lineIndex);
            int lineLength = richTextBox.Lines[lineIndex].Length; //Получаем длину строки

            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = System.Drawing.Color.White;
            richTextBox.Select(startIndex, lineLength); //Выделяем текст с первого символа строки до конца строки
            richTextBox.SelectionBackColor = System.Drawing.Color.Orange; //Устанавливаем выделенному тексту оранжевый фон
            richTextBox.Select(startIndex, 0);
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
