using BazisGUI.Console.Events;
using BazisGUI.PinnedControl;
using BazisGUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BazisGUI.Console
{
    public enum GenCmd
    {
        LoadProject,
        SaveProject,
        NewProject,
        CreateGraph,
        SolveProject,
        Exit,
        RenumberMesh,
        FindFreeNodes,
        MoveMesh,
        ChangeObjCoordinates,
        FindCoincident,
        FindObject,
        FindVolElems,
        BeamConnection,
        SetLevel,
        RotateMesh,
        MoveNodes,
        MergeElementSets,
        CreateMesh2DPoligon,
        CreatePoint,
        CreateCurve,
        CreateSurface
    }

    public partial class ConsoleControl : PinnedPage
    {
        public bool CheckPrintElemsInfo { get; set; }
        public bool CheckPrintNodesInfo { get; set; }

        public bool ShowTaskInfo { get; private set; }


        public event Action<object, EventArgs> InEvent;
        public event Action FindFreeNodesEvent;
        public event Action<object, ModelRenumberEventArgs> RenumberMeshEvent;
        public event Action<object, ModelShiftCoordinateEventArgs> ModelShiftCoordinateEvent;
        public event Action<object, ModelRotateEventArgs> ModelRotateEvent;
        public event Action<object, MergeElementSetsEventArgs> MergeElementSetsEvent;
        public event Action<object, CreateMesh2DPoligonEventArgs> CreateMesh2DPoligonEvent;
        public event Action<CreateGeometryEventArgs> CreateGeometryEvent;
        int SessionNumber
        {
            get;
            set;
        }

        Dictionary<string, GenCmd> genCmds = new Dictionary<string, GenCmd>()
        {
            { "Загрузить проект",GenCmd.LoadProject},
            { "Сохранить проект",GenCmd.SaveProject},
            { "Рассчитать проект",GenCmd.SolveProject},
            { "Перенумерация сетки",GenCmd.RenumberMesh},
            { "Переместить узел",GenCmd.MoveNodes},
            { "Переместить сетку",GenCmd.MoveMesh},
            { "Повернуть сетку",GenCmd.RotateMesh},
            { "Найти свободные узлы",GenCmd.FindFreeNodes},
            { "Найти совпадающие",GenCmd.FindCoincident},
            { "Найти объемные элементы",GenCmd.FindVolElems},
            { "Найти объект",GenCmd.FindObject},
            { "Соединить стержнями",GenCmd.BeamConnection},
            { "Задать порядок точности",GenCmd.SetLevel },
            { "Слить наборы элементов",GenCmd.MergeElementSets },
            { "Построить 2D сетку",GenCmd.CreateMesh2DPoligon },
            { "Выход",GenCmd.Exit },
            { "Добавить точку", GenCmd.CreatePoint },
            { "Добавить линию", GenCmd.CreateCurve },
            { "Добавить поверхность", GenCmd.CreateSurface}
        };

        Dictionary<GenCmd, string[]> subCmds = new Dictionary<GenCmd, string[]>()
        {
            { GenCmd.LoadProject,new string[]{"путь"} },
            { GenCmd.SaveProject,new string[]{"путь"}},
            { GenCmd.SolveProject,new string[]{}},
            { GenCmd.RenumberMesh,new string[]{"тип:начальный номер"}},
            { GenCmd.MoveMesh,new string[]{ "переместить","x,y,z" }},
            { GenCmd.MoveNodes,new string[]{ "переместить" }},
            { GenCmd.RotateMesh,new string[]{ "повернуть","x,y,z:угол" }},
            { GenCmd.FindFreeNodes,new string[]{}},
            { GenCmd.FindCoincident,new string[]{ "узлы","расстояние" }},
            { GenCmd.FindVolElems,new string[]{ "величина" }},
            { GenCmd.FindObject,new string[]{ "тип,номер" }},
            { GenCmd.BeamConnection,new string[]{ "радиус поиска","макс. кол-во","группа#1","группа#2" }},
            { GenCmd.SetLevel,new string[]{ "тип","порядок точности" }},
            { GenCmd.MergeElementSets,new string[]{ "тип","набор#1","набор#2" }},
            { GenCmd.CreateMesh2DPoligon,new string[]{ "x1,y1", "x2,y2", "x3,y3","x4,y4","кол-во элементов" }},
            { GenCmd.Exit,Array.Empty<string>()},
            { GenCmd.CreatePoint, new string[]{ "x,y,z" } },
            { GenCmd.CreateCurve, new string[]{ "точка#1", "точка#2" }},
            { GenCmd.CreateSurface, new string[]{ "кривые формирующие контур", "кривая#1,кривая#2,..." } }
        };


        private Thread trd;

        public void NewItem_Click(object obj, EventArgs args)
        {
            var tstb = (ToolStripMenuItem)obj;

            var str = String.Empty;
            GetItemCmd(tstb, ref str);
            rtxbField.AppendText("\n" + str);
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

        int LineIndex { get; set; }

        public ConsoleControl()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(tlscOut, true, null);

            var path = " > Текущая сессия ";

            rtxbField.AppendText(path);
            rtxbField.AppendText("\n");
            HighlightPhrase(path, System.Drawing.Color.Green);
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

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", e.ToString());
        }    

        public string GetSessionLogPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                     "\\" + SessionNumber.ToString() + "bazis.session.txt";
            }
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

        void HighlightPhrase(string phrase, Color color)
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
            //TO DO
            var cmds = FieldsParser.ParseLine(line);
            if (cmds.Count != 0)
            {
                if (!this.genCmds.ContainsKey(cmds[0])) 
                    throw new Exception("Не является командой");
                if (subCmds[genCmds[cmds[0]]].Length !=  cmds.Count -1)
                    throw new Exception("Неверное колличество аргументов");

                ConsoleHistory.AddComand(line);
                
                switch (genCmds[cmds[0]])
                {
                    case GenCmd.CreateMesh2DPoligon:
                        CreateMesh2DPoligonEvent?.Invoke(this, new CreateMesh2DPoligonEventArgs(cmds[1], cmds[2], cmds[3], cmds[4], cmds[5]));
                        break;
                    case GenCmd.MergeElementSets:
                        MergeElementSetsEvent?.Invoke(this, new MergeElementSetsEventArgs(cmds[1], cmds[2], cmds[3]));
                        break;
                    case GenCmd.FindObject:
                        InEvent(this, new FindObjectEventArgs(cmds[1]));
                        break;
                    case GenCmd.LoadProject:
                        InEvent(this, new LoadProjectEventArgs(cmds[1]));
                        break;
                    case GenCmd.SaveProject:
                        InEvent(this, new SaveProjectEventArgs(cmds[1]));
                        break;
                    case GenCmd.CreateGraph:
                        break;
                    case GenCmd.RenumberMesh:
                        RenumberMeshEvent?.Invoke(this, new ModelRenumberEventArgs(cmds[1]));
                        break;
                    case GenCmd.MoveMesh:
                        ModelShiftCoordinateEvent?.Invoke(this, new ModelShiftCoordinateEventArgs(cmds[2]));
                        break;
                    case GenCmd.RotateMesh:
                        ModelRotateEvent?.Invoke(this, new ModelRotateEventArgs(cmds[2]));
                        break;
                    case GenCmd.MoveNodes:
                        if (cmds[1] == "переместить")
                            InEvent?.Invoke(this, new NodesShiftCoordinateEventArgs());
                        else
                            InEvent?.Invoke(this, new NodesRotateCoordinateEventArgs());
                        break;
                    case GenCmd.FindFreeNodes:
                        FindFreeNodesEvent?.Invoke();
                        break;
                    case GenCmd.FindVolElems:
                        InEvent(this, new FindVolElemsEventArgs(cmds[1]));
                        break;
                    case GenCmd.FindCoincident:
                        if (cmds[1] == "узлы")
                            InEvent(this, new ModelFindCoincidentsNodesEventArgs(cmds[2]));
                        break;
                    case GenCmd.BeamConnection:
                        InEvent(this, new BeamConnectionEventArgs(cmds[1], cmds[2],cmds[3], cmds[4]));
                        break;
                    case GenCmd.SolveProject:
                        InEvent(this, new SolveProjectEventArgs());
                        break;
                    case GenCmd.SetLevel:
                        InEvent(this, new SetElementLevelEventArgs(cmds[1], cmds[2]));
                        break;
                    case GenCmd.Exit:
                        InEvent(this, new ExitAppEventArgs());
                        break;
                    case GenCmd.CreatePoint:
                        CreateGeometryEvent(new CreateGeometryEventArgs(0, [cmds[1]]));
                        break;   
                    case GenCmd.CreateCurve:
                        CreateGeometryEvent(new CreateGeometryEventArgs(1, [cmds[1], cmds[2]]));
                        break;
                    case GenCmd.CreateSurface:
                        CreateGeometryEvent(new CreateGeometryEventArgs(2, [cmds[2]]));
                        break;
                }
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            var sessionPath = rtxbField.Lines[0];
            rtxbField.Clear();
            rtxbField.AppendText(sessionPath);
        }

        private void btnStartMacro_Click(object sender, EventArgs e)
        {
            try
            {
                if (trd == null)
                {
                    OpenFileDialog newDialog = new OpenFileDialog()
                    {
                        Filter = "Bazis command file(*.tcf)|*.tcf|" +
            "All files(*.*)|*.*"
                    };
                    if (newDialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    trd = new Thread(delegate () { ExecuteCmdFile(newDialog.FileName); });
                    trd.Start();

                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream("PrConsole.Resources.Stop.ico");
                    btnStartMacro.Image = new Bitmap(stream);
                    btnStartMacro.Text = "Остановить";
                }
                else
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream("PrConsole.Resources.StartCheck.ico");
                    btnStartMacro.Image = new Bitmap(stream);
                    btnStartMacro.Text = "Запустить";
                    trd.Abort();

                }
            }
            catch (Exception)
            {
                trd = null;
            }
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            PrintInfo("Доступные команды:", Color.Black);

            foreach (var item in genCmds)
            {
                var args = string.Join(" ", subCmds[item.Value].Select(s => $"\"{s}\""));
                PrintInfo($"- \"{item.Key}\" {args}", Color.Black);
            }
        }

        private void btnBackGroundInfo_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            rtxbField.BackColor = colorDialog.Color;
        }


        private void rtxbField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var cmds = rtxbField.Lines[rtxbField.Lines.Count() - 1];

                if (cmds.Length != 0)
                {
                    trd = new Thread(delegate ()
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                ExecuteCommand(cmds);
                            }));
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                PrintInfo(ex.Message, Color.Red);
                            }
                                ));

                        }
                    });
                    trd.Start();

                    rtxbField.AppendText($"\n < {cmds}");
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                PrintHistory(ConsoleHistory.GetPreviousCommand());
            }
            else if (e.KeyCode == Keys.Down)
            {
                PrintHistory(ConsoleHistory.GetNextCommand());
            }
        }
    }
}
