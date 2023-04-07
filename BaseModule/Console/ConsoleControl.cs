using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using BaseModule.Console.Events;
using Functions.Parser;

namespace BaseModule.Console
{
    public enum GenCmd
    {
        LoadProject,
        SaveProject,
        NewProject,
        ShowResults,
        HideResults,
        CreateGraph,
        SolveProject,
        Exit,
        RenumberMesh,
        ChangeView,
        FindFreeNodes,
        ChangeModelCoordinates,
        ChangeObjCoordinates,
        FindCoincident
    }

    public enum GeomCmd
    {
        Move,
        Rotate,
        Scale
    }

    public enum AtribCmd
    {
        Vector,
        Angle,
        Factor,
        Path
    }
    public partial class ConsoleControl : UserControl
    {
        public bool CheckPrintElemsInfo { get; set; }
        public bool CheckPrintNodesInfo { get; set; }

        public bool ShowTaskInfo { get; private set; }

        int SessionNumber
        {
            get;
            set;
        }

        Dictionary<string, GenCmd> genCmds = new Dictionary<string, GenCmd>()
        {
            { "Загрузить проект",GenCmd.LoadProject},
            { "Сохранить проект",GenCmd.SaveProject},
            { "Новый проект",GenCmd.NewProject},
            { "Рассчитать проект",GenCmd.SolveProject},
            { "Перенумерация сетки",GenCmd.RenumberMesh},
            { "Изменить координаты модели",GenCmd.ChangeModelCoordinates},
            { "Изменить координаты объекта",GenCmd.ChangeObjCoordinates},
            { "Изменить вид",GenCmd.ChangeView},
            { "Найти свободные узлы",GenCmd.FindFreeNodes},
            { "Найти совпадающие",GenCmd.FindCoincident},
            { "Найти объект",GenCmd.FindFreeNodes},
            { "Выход",GenCmd.Exit }
        };

        Dictionary<string, GeomCmd> geomCmds = new Dictionary<string, GeomCmd>()
        {
            { "Переместить",GeomCmd.Move},
            { "Повернуть",GeomCmd.Rotate},
            { "Масштабировать",GeomCmd.Scale}
        };

        Dictionary<string, AtribCmd> atribCmds = new Dictionary<string, AtribCmd>()
        {
            { "Вектор",AtribCmd.Vector},
            { "Угол",AtribCmd.Angle},
            { "Фактор",AtribCmd.Factor},
            { "Путь",AtribCmd.Path},
            { "Номер",AtribCmd.Path},
        };

        private Thread trd;

        public void RunMacro(bool value)
        {
            Invoke(new Action(() =>
            {
                if (value)
                {
                    trd.Resume();
                }
                else
                {
                    trd.Suspend();
                }
            }));
        }

        public event Action<object, EventArgs> InEvent;

        int LineIndex { get; set; }

        //public Action<object,BaseFormCntrEventArgs> ConsoleEvent;

        public ConsoleControl()
        {
            InitializeComponent();
            tlsOut.Renderer = new BtnToolStrRender();
            tlsIn.Renderer = new BtnToolStrRender();

            var path = " > Текущая сессия ";

            rtxbOut.AppendText(path);
            HighlightPhrase(path, System.Drawing.Color.Green);
        }

        //private ToolStripMenuItem CreateItem(string cmd)
        //{
        //    var newItem = new ToolStripMenuItem(cmd)
        //    {
        //        Text = cmd,
        //        AutoSize = true
        //    };
        //    newItem.Click += NewItem_Click;
        //    return newItem;
        //}

        private void GetChildControlExpandHeight(GroupBox grb)
        {
            var heigth = 0;
            var gap = 20;
            foreach (Control control in grb.Controls)
            {
                if (control is UserControl uControl)
                    foreach (Control cntr in uControl.Controls)
                    {
                        if (cntr is TextBox txb | cntr is ComboBox cmb)
                        {
                            heigth = heigth + cntr.Size.Height;
                            gap = gap + 6;
                        }
                    }
            }
            grb.Height = heigth + gap;
        }

        private void NewItem_Click(object obj, EventArgs args)
        {
            var tstb = (ToolStripMenuItem)obj;
            if (inputRichTextBox.Text == "введите команду...")
                inputRichTextBox.Text = "";

            var str = String.Empty;
            GetItemCmd(tstb, ref str);
            inputRichTextBox.AppendText("\n" + str);
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
            rtxbOut.Controls.Add(link);
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", e.ToString());
        }

        public void PrintMatrix(float[][] matrix)
        {
            FontStyle style = (FontStyle.Bold); //жирный

            var w1 = rtxbOut.Width;
            var w2 = matrix.GetLength(0);

            for (int i = 0; i < w1; i++)
            {
                rtxbOut.AppendText("_");
            }
            rtxbOut.AppendText("\n");
            var w = (float)w1 / (w2 * 16);

            //StringBuilder st = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var str = "";
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != 0)
                        str = str + "1";
                    else { str = str + "_"; }
                }
                str = str + "\n";
                rtxbOut.SelectionFont = new Font(rtxbOut.Font.FontFamily, w, style);
                rtxbOut.AppendText(str);
            }
        }
        private void PrintVector(float[] vector)
        {
            FontStyle style = (FontStyle.Bold); //жирный

            var w1 = rtxbOut.Width;
            var w2 = vector.Length;

            for (int i = 0; i < w1; i++)
            {
                rtxbOut.AppendText("_");
            }
            rtxbOut.AppendText("\n");
            var w = (float)w1 / (w2 * 16);

            var str = "";
            for (int j = 0; j < vector.Length; j++)
            {
                if (vector[j] != 0)
                    str = str + " " + vector[j].ToString();
                else { str = str + " " + "0"; }
            }
            str = str + "\n";
            rtxbOut.SelectionFont = new Font(rtxbOut.Font.FontFamily, w, style);
            rtxbOut.AppendText(str);
        }

        public string GetSessionLogPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                     "\\" + SessionNumber.ToString() + "bazis.session.txt";
            }
        }

        public void PrintFile(string str, string path)
        {

        }

        public void PrintInfo(string str, Color color)
        {
            if (ShowTaskInfo)
            {
                if (str.Contains(" s "))
                    rtxbOut.AppendText("\n > " + str);
            }
            else
                rtxbOut.AppendText("\n > " + str);
            if (color.Name != "Black")
                HighlightPhrase(str, color);
            var path = GetSessionLogPath;
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                sw.Write(str);
            rtxbOut.SelectionStart = rtxbOut.Text.Length;


            rtxbOut.Focus();
            rtxbOut.ScrollToCaret();

        }

        void HighlightPhrase(string phrase, Color color)
        {
            int pos = rtxbOut.SelectionStart;
            string s = rtxbOut.Text;
            for (int ix = 0; ;)
            {
                int jx = s.IndexOf(phrase, ix, StringComparison.InvariantCulture);
                if (jx < 0) break;
                rtxbOut.SelectionStart = jx;
                rtxbOut.SelectionLength = phrase.Length;
                rtxbOut.SelectionColor = color;
                ix = jx + 1;
            }
            rtxbOut.SelectionStart = pos;
            rtxbOut.SelectionLength = 0;
            rtxbOut.SelectionColor = Color.Black;
        }

        private void ChooseAll_Click(object sender, EventArgs e)
        {
            rtxbOut.SelectAll();
        }

        private void inputRichTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                //Копируем все строки как список
                List<string> list = inputRichTextBox.Lines.ToList();
                //Удаляем последний элемент (именно для этого нужно было массив в список превращать)
                list.RemoveAt(inputRichTextBox.Lines.Length - 1);
                //Возвращаем список строк в контролл
                inputRichTextBox.Lines = list.ToArray();
                var cmds = list.Last();

                trd = new Thread(delegate ()
                {
                    try
                    {

                        ExecuteCommand(cmds);
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            inputRichTextBox.AppendText("\n < " + ex.Message);
                            inputRichTextBox.AppendText("\n");
                        }
                            ));

                    }
                });
                trd.Start();

                Invoke(new Action(() =>
                {
                    inputRichTextBox.AppendText("\n < " + cmds);
                    inputRichTextBox.AppendText("\n");
                }));
            }
        }

        public void ExecuteCmdFile(string cmdFileName)
        {
            if (System.IO.File.Exists(cmdFileName))
            {
                var cmdLines = File.ReadAllLines(cmdFileName);

                foreach (var line in cmdLines)
                {
                    ExecuteCommand(line);
                }

                var assembly = Assembly.GetExecutingAssembly();
                var stream = assembly.GetManifestResourceStream("PrConsole.Resources.StartCheck.ico");
                btnStartMacro.Image = new Bitmap(stream);
                trd.Abort();

            }
            else throw new Exception("\n > Указанный коммандный файл не найден!");
        }

        private void ExecuteCommand(string line)
        {
            var cmds = FieldsParserTask.ParseLine(line);
            if (cmds.Count == 0) throw new Exception("Введите команду!");

            if (!this.genCmds.ContainsKey(cmds[0])) throw new Exception("Не является командой");

            switch (genCmds[cmds[0]])
            {
                case GenCmd.LoadProject:
                    {
                        InEvent(this, new LoadProjectEventArgs(cmds[1]));
                    }
                    break;
                case GenCmd.SaveProject:
                    {
                        InEvent(this, new SaveProjectEventArgs(cmds[1]));
                    }
                    break;
                case GenCmd.NewProject:
                    break;
                case GenCmd.ShowResults:
                    break;
                case GenCmd.HideResults:
                    break;
                case GenCmd.CreateGraph:
                    break;
                case GenCmd.RenumberMesh:
                    InEvent(this, new ModelRenumberEventArgs(cmds[1]));
                    break;
                case GenCmd.ChangeModelCoordinates:
                    InEvent(this, new ModelShiftCoordinateEventArgs(cmds[2]));
                    break;
                case GenCmd.FindFreeNodes:
                    InEvent(this, new ModelFindFreeNodesEventArgs());
                    break;
                case GenCmd.FindCoincident:
                    if (cmds[1] == "Узлы")
                        InEvent(this, new ModelFindCoincidentsNodesEventArgs());
                    break;
                case GenCmd.SolveProject:
                    InEvent(this, new SolveProjectEventArgs());
                    break;
                case GenCmd.Exit:
                    InEvent(this, new ExitAppEventArgs());
                    break;
            }
        }

        private void inputRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (inputRichTextBox.Text == "введите команду...")
                inputRichTextBox.Text = "";
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            var sessionPath = rtxbOut.Lines[0];
            rtxbOut.Clear();
            rtxbOut.AppendText(sessionPath);
        }

        public void SetFocus()
        {
            rtxbOut.Focus();
        }

        private void btnStartMacro_Click(object sender, EventArgs e)
        {
            try
            {
                if (trd == null)
                {
                    OpenFileDialog newDialog = new OpenFileDialog()
                    {
                        Filter = "Bazis command file(*.bcf)|*.bcf|" +
            "All files(*.*)|*.*"
                    };
                    if (newDialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    trd = new Thread(delegate () { ExecuteCmdFile(newDialog.FileName); });
                    trd.Start();

                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream("PrConsole.Resources.Stop.ico");
                    btnStartMacro.Image = new Bitmap(stream);
                }
                else
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream("PrConsole.Resources.StartCheck.ico");
                    btnStartMacro.Image = new Bitmap(stream);

                    trd.Abort();

                }
            }
            catch (Exception)
            {
                trd = null;
            }
        }

        private void btnProjInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnMeshInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnResInfo_Click(object sender, EventArgs e)
        {

        }

        private void rtxbOut_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void btnCompInfo_CheckedChanged(object sender, EventArgs e)
        {
            //var btn = (ToolStripButton)sender;

            //if (btn.Checked)
            //    ShowTaskInfo = true;
            //else

            //{
            //    ShowTaskInfo = false;

            //    rtxbOut.Clear();
            //    var sessionPath = GetSessionLogPath;
            //    Encoding win1251 = Encoding.GetEncoding("windows-1251");
            //    var lines = File.ReadAllLines(sessionPath, win1251);
            //    rtxbOut.Lines = lines;
            //}
        }

        private void inputRichTextBox_Leave(object sender, EventArgs e)
        {
            if (inputRichTextBox.Text == "")
                inputRichTextBox.Text = "введите команду...";
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            btnDictionary.ShowDropDown();
        }

        private void btnCompInfo_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            if (btn.Checked)
            {
                ShowTaskInfo = true;

                rtxbOut.Clear();
                var sessionPath = GetSessionLogPath;
                Encoding win1251 = Encoding.GetEncoding("windows-1251");
                var lines = File.ReadAllLines(sessionPath, win1251);

                var res = lines.Where(x => x.Contains(" > s ")).ToArray();
                rtxbOut.Lines = res;
            }
            else
            {
                ShowTaskInfo = false;

                rtxbOut.Clear();
                var sessionPath = GetSessionLogPath;
                Encoding win1251 = Encoding.GetEncoding("windows-1251");
                var lines = File.ReadAllLines(sessionPath, win1251);
                var res = lines.Where(x => x.Length > 0).ToArray();
                rtxbOut.Lines = res;
            }
        }
    }
}
