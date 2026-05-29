using BazisGUI.PinnedControl;
using BazisGUI.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.Console
{
    public partial class ConsoleControl : PinnedPage
    {
        public bool CheckPrintElemsInfo { get; set; }
        public bool CheckPrintNodesInfo { get; set; }
        public bool ShowTaskInfo { get; private set; }
        public int SessionNumber { get; set; }
        public string GetSessionLogPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                     "\\" + SessionNumber.ToString() + "bazis.session.txt";
            }
        }

        public event Action<string> ConsoleCommandEnteredEvent;
        public event Action<string> ScriptPathReceived;
        public event Action CommandsListRequestedEvent;
        public void NewItem_Click(object obj, EventArgs args)
        {
            var tstb = (ToolStripMenuItem)obj;

            var str = String.Empty;
            GetItemCmd(tstb, ref str);
            rtxbField.AppendText("\n" + str);
        }

        public ConsoleControl()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(tlscOut, true, null);

            var path = $" > {Resources.CurrentSession} ";

            rtxbField.AppendText(path);
            rtxbField.AppendText("\n");
            HighlightPhrase(path, System.Drawing.Color.Green);
        }

        public void PrintInfo(string str, Color color)
        {
            rtxbField.AppendText($" > {str}");

            if (color != Color.Black)
                HighlightPhrase(str, color);
            var path = GetSessionLogPath;
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                sw.Write(str);
            rtxbField.SelectionStart = rtxbField.Text.Length;

            rtxbField.AppendText("\n");

            rtxbField.Focus();
            rtxbField.ScrollToCaret();
        }

        public void PrintHistory(string str)
        {
            int lastLineIndex = rtxbField.Lines.Length - 1;
            int startIndex = rtxbField.GetFirstCharIndexFromLine(lastLineIndex);

            rtxbField.SelectionStart = startIndex;
            rtxbField.SelectionLength = rtxbField.TextLength - startIndex;

            rtxbField.SelectedText = str;

            rtxbField.SelectionStart = rtxbField.TextLength;
            rtxbField.SelectionLength = 0;
        }

        private void GetItemCmd(ToolStripMenuItem toolStripItem, ref string info)
        {
            var owner = toolStripItem.OwnerItem;
            if (owner is ToolStripMenuItem menuItem)
            {

                GetItemCmd(menuItem, ref info);
            }
            info = info + " " + "\"" + toolStripItem.Text + "\"";
        }


        private void ConsoleControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            var rnd = new Random();
            SessionNumber = rnd.Next(0, 10000);

            LinkLabel link = new LinkLabel();
            link.Text = GetSessionLogPath;
            link.AutoSize = true;
            link.Left = 100;
            link.LinkClicked += Link_LinkClicked;
            rtxbField.Controls.Add(link);
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("explorer", e.ToString());

        private void HighlightPhrase(string phrase, Color color)
        {
            int pos = rtxbField.SelectionStart;
            string s = rtxbField.Text;
            for (int ix = 0; ;)
            {
                int jx = s.IndexOf(phrase, ix, StringComparison.InvariantCulture);
                if (jx < 0) break;
                rtxbField.SelectionStart = jx;
                rtxbField.SelectionLength = phrase.Length;
                rtxbField.SelectionColor = color;
                ix = jx + 1;
            }
            rtxbField.SelectionStart = pos;
            rtxbField.SelectionLength = 0;
            rtxbField.SelectionColor = Color.Black;
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            var sessionPath = rtxbField.Lines[0];
            rtxbField.Clear();
            rtxbField.AppendText(sessionPath);
        }

        private void btnDictionary_Click(object sender, EventArgs e) => CommandsListRequestedEvent.Invoke();


        private void btnBackGroundInfo_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            rtxbField.BackColor = colorDialog.Color;
        }

        private void btnStartMacro_Click(object sender, EventArgs e)
        {
            OpenFileDialog newDialog = new OpenFileDialog()
            {
                Filter = "Bazis command file(*.tcf)|*.tcf|" + "All files(*.*)|*.*"
            };

            if (newDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ScriptPathReceived?.Invoke(newDialog.FileName);
        }

        private void KeyDownEventHadler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ConsoleCommandEnteredEvent(rtxbField.Lines[rtxbField.Lines.Count() - 1]);
            else if (e.KeyCode == Keys.Up)
                PrintHistory(ConsoleHistory.GetPreviousCommand());
            else if (e.KeyCode == Keys.Down)
                PrintHistory(ConsoleHistory.GetNextCommand());
        }
    }
}
