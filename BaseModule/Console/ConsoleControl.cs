using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using BaseModule.Console.Events;
using System.ComponentModel;
using UserControlsEx;
using BaseModule.Utilities;
using BaseModule.Interfaces;

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
        ChangeMeshCoordinates,
        ChangeObjCoordinates,
        FindCoincident,
        FindObject
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
    public partial class ConsoleControl : UserControl, IPinnedControl
    {
        [Category("General")]
        [Description("Set up color gradient")]
        public Color UpColor { get; set; } = Color.Silver;

        [Category("General")]
        [Description("Set down color gradient")]
        public Color DownColor { get; set; } = Color.WhiteSmoke;

        [Category("General")]
        [Description("Set header name")]
        public string HeaderName { get; set; } = "Консоль";

        [Category("General")]
        [Description("Set color text")]
        public Color TextColor { get; set; } = Color.Black;

        public bool CheckPrintElemsInfo { get; set; }
        public bool CheckPrintNodesInfo { get; set; }

        public bool ShowTaskInfo { get; private set; }

        public event Action ControlCollapseEvent;
        public event Action<object, EventArgs> InEvent;
        public event Action FindFreeNodesEvent;
        public event Action ControlUnpinnedEvent;
        public event Action<object, ModelRenumberEventArgs> RenumberMeshEvent;
        public event Action<object, ModelShiftCoordinateEventArgs> ModelShiftCoordinateEvent;
        public event Action<object, ModelRotateEventArgs> ModelRotateEvent;

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
            { "Изменить координаты сетки",GenCmd.ChangeMeshCoordinates},
            { "Изменить координаты объекта",GenCmd.ChangeObjCoordinates},
            { "Изменить вид",GenCmd.ChangeView},
            { "Найти свободные узлы",GenCmd.FindFreeNodes},
            { "Найти совпадающие",GenCmd.FindCoincident},
            { "Найти объект",GenCmd.FindObject},
            { "Выход",GenCmd.Exit }
        };

        //Dictionary<string, GeomCmd> geomCmds = new Dictionary<string, GeomCmd>()
        //{
        //    { "Переместить",GeomCmd.Move},
        //    { "Повернуть",GeomCmd.Rotate},
        //    { "Масштабировать",GeomCmd.Scale}
        //};

        //Dictionary<string, AtribCmd> atribCmds = new Dictionary<string, AtribCmd>()
        //{
        //    { "Вектор",AtribCmd.Vector},
        //    { "Угол",AtribCmd.Angle},
        //    { "Фактор",AtribCmd.Factor},
        //    { "Путь",AtribCmd.Path},
        //    { "Номер",AtribCmd.Path},
        //};

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
                SetValue(grbConsole, true, null);

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

                switch (genCmds[cmds[0]])
                {
                    case GenCmd.FindObject:
                        InEvent(this, new FindObjectEventArgs(cmds[1]));
                        break;
                    case GenCmd.LoadProject:
                        InEvent(this, new LoadProjectEventArgs(cmds[1]));
                        break;
                    case GenCmd.SaveProject:
                        InEvent(this, new SaveProjectEventArgs(cmds[1]));
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
                        RenumberMeshEvent?.Invoke(this, new ModelRenumberEventArgs(cmds[1]));
                        break;
                    case GenCmd.ChangeMeshCoordinates:
                        if(cmds[1] == "Переместить")
                            ModelShiftCoordinateEvent?.Invoke(this, new ModelShiftCoordinateEventArgs(cmds[2]));
                        else
                            ModelRotateEvent?.Invoke(this, new ModelRotateEventArgs(cmds[2]));
                        break;
                    case GenCmd.FindFreeNodes:
                        FindFreeNodesEvent?.Invoke();
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

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            spbDictionary.ShowDropDown();
        }

        private void btnBackGroundInfo_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            rtxbField.BackColor = colorDialog.Color;
        }

        private void grbConsole_Paint(object sender, PaintEventArgs e)
        {
            var loc_y = tlscOut.Location.Y;

            ComponentsPainter.PaintGradientRectangle(e.Graphics, new Point(0, 0),Width, loc_y, UpColor, DownColor);

            var locRect = new Point(Width - 15, loc_y / 2 - 4);
            ComponentsPainter.PaintCloseRectangle(e.Graphics, locRect);

            e.Graphics.DrawString(HeaderName, ComponentsPainter.Font, new SolidBrush(TextColor), 15, 0);
        }     

        private void grbConsole_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > grbConsole.Width - 16 & e.Location.X < grbConsole.Width - 8 && e.Location.Y <= 10)
                ControlCollapseEvent?.Invoke();
        }

        private void grbConsole_Resize(object sender, EventArgs e)
        {
            grbConsole.Invalidate();
        }

        private void rtxbField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var cmds = rtxbField.Lines[rtxbField.Lines.Count() - 1];

                if(cmds.Length != 0)
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
        }
    }
}
