using BazisGUI.Console.Events;
using BazisGUI.PinnedControl;
using BazisGUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
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
        CreateSurface,
        ExtrudeCurve,
        ExtrudeRotate
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
        public event Action<CreateExtruderEventArgs> ExtrudeEvent;
        int SessionNumber
        {
            get;
            set;
        }

        Dictionary<string, GenCmd> genCmds;
        Dictionary<GenCmd, string[]> subCmds;

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

        public ConsoleControl()
        {
            InitializeComponent();
            InitGenCubCommandsDictionaries();

            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).
                SetValue(tlscOut, true, null);

            var path = $" > {Localization.Localization.GetStringResourceByName<ConsoleControl>("CurrentSession")} ";

            rtxbField.AppendText(path);
            rtxbField.AppendText("\n");
            HighlightPhrase(path, System.Drawing.Color.Green);
        }

        private void InitGenCubCommandsDictionaries()
        {
            var tempUICultureName = Thread.CurrentThread.CurrentUICulture.Name;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            var resources = new ComponentResourceManager(typeof(ConsoleControl));
            genCmds = new Dictionary<string, GenCmd>()
            {
                { resources.GetString("GenLoadProject"),GenCmd.LoadProject},
                { resources.GetString("GenSaveProject"),GenCmd.SaveProject},
                { resources.GetString("GenSolveProject"),GenCmd.SolveProject},
                { resources.GetString("GenRenumberMesh"),GenCmd.RenumberMesh},
                { resources.GetString("GenMoveNodes"),GenCmd.MoveNodes},
                { resources.GetString("GenMoveMesh"),GenCmd.MoveMesh},
                { resources.GetString("GenRotateMesh"),GenCmd.RotateMesh},
                { resources.GetString("GenFindFreeNodes"),GenCmd.FindFreeNodes},
                { resources.GetString("GenFindCoincident"),GenCmd.FindCoincident},
                { resources.GetString("GenFindVolElems"),GenCmd.FindVolElems},
                { resources.GetString("GenFindObject"),GenCmd.FindObject},
                { resources.GetString("GenBeamConnection"),GenCmd.BeamConnection},
                { resources.GetString("GenSetLevel"),GenCmd.SetLevel },
                { resources.GetString("GenMergeElementSets"),GenCmd.MergeElementSets },
                { resources.GetString("GenCreateMesh2DPoligon"),GenCmd.CreateMesh2DPoligon },
                { resources.GetString("GenCreatePoint"),GenCmd.CreatePoint },
                { resources.GetString("GenCreateCurve"),GenCmd.CreateCurve },
                { resources.GetString("GenCreateSurface"),GenCmd.CreateSurface },
                { resources.GetString("GenExtrudeCurve"),GenCmd.ExtrudeCurve },
                { resources.GetString("GenExtrudeByRotation"),GenCmd.ExtrudeRotate },
                { resources.GetString("GenExit"),GenCmd.Exit }
            };
            subCmds = new Dictionary<GenCmd, string[]>()
            {
                { GenCmd.LoadProject,resources.GetString("SubLoadProject").Split("<|>") },
                { GenCmd.SaveProject,resources.GetString("SubSaveProject").Split("<|>")},
                { GenCmd.SolveProject,new string[] { } },
                { GenCmd.RenumberMesh,resources.GetString("SubRenumberMesh").Split("<|>")},
                { GenCmd.MoveMesh,resources.GetString("SubMoveMesh").Split("<|>")},
                { GenCmd.MoveNodes,resources.GetString("SubMoveNodes").Split("<|>")},
                { GenCmd.RotateMesh,resources.GetString("SubRotateMesh").Split("<|>")},
                { GenCmd.FindFreeNodes,new string[] { } },
                { GenCmd.FindCoincident,resources.GetString("SubFindCoincident").Split("<|>")},
                { GenCmd.FindVolElems,resources.GetString("SubFindVolElems").Split("<|>")},
                { GenCmd.FindObject,resources.GetString("SubFindObject").Split("<|>")},
                { GenCmd.BeamConnection,resources.GetString("SubBeamConnection").Split("<|>")},
                { GenCmd.SetLevel,resources.GetString("SubSetLevel").Split("<|>")},
                { GenCmd.MergeElementSets,resources.GetString("SubMergeElementSets").Split("<|>")},
                { GenCmd.CreateMesh2DPoligon,resources.GetString("SubCreateMesh2DPoligon").Split("<|>")},
                { GenCmd.CreatePoint,resources.GetString("SubCreatePoint").Split("<|>") },
                { GenCmd.CreateCurve,resources.GetString("SubCreateCurve").Split("<|>") },
                { GenCmd.CreateSurface,resources.GetString("SubCreateSurface").Split("<|>") },
                { GenCmd.ExtrudeCurve,resources.GetString("SubExtrudeCurve").Split("<|>") },
                { GenCmd.ExtrudeRotate,resources.GetString("SubExtrudeRotation").Split("<|>") },
                { GenCmd.Exit,new string[] { } }
            };

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(tempUICultureName);
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
            else throw new Exception($"\n > {Localization.Localization.GetStringResourceByName<ConsoleControl>("ExecuteCMDFileMissing)")}");
        }

        private void ExecuteCommand(string line)
        {
            //TO DO
            var cmds = FieldsParser.ParseLine(line);
            if (cmds.Count != 0)
            {
                if (!this.genCmds.ContainsKey(cmds[0])) 
                    throw new Exception(Localization.Localization.GetStringResourceByName<ConsoleControl>("NotACommandException"));
                if (subCmds[genCmds[cmds[0]]].Length !=  cmds.Count -1)
                    throw new Exception(Localization.Localization.GetStringResourceByName<ConsoleControl>("InvalidArgumentsNumberException"));

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
                        if (cmds[1] == Localization.Localization.GetStringResourceByName<ConsoleControl>("MoveRotNodesOption"))
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
                        if (cmds[1] == Localization.Localization.GetStringResourceByName<ConsoleControl>("FindCoincidentOption"))
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
                        CreateGeometryEvent(new CreateGeometryEventArgs(GeometryType.Point, [cmds[1]]));
                        break;   
                    case GenCmd.CreateCurve:
                        CreateGeometryEvent(new CreateGeometryEventArgs(GeometryType.Curve, [cmds[1], cmds[2]]));
                        break;
                    case GenCmd.CreateSurface:
                        CreateGeometryEvent(new CreateGeometryEventArgs(GeometryType.Surface, [cmds[2]]));
                        break;
                    case GenCmd.ExtrudeCurve:
                        ExtrudeEvent(new CreateExtruderEventArgs(ExtruderType.Curve, new List<string> { cmds[1], cmds[2], cmds[3], cmds[4], cmds[5] }));
                        break;
                    //case GenCmd.ExtrudeRotate:
                    //    ExtrudeEvent(new CreateExtruderEventArgs(ExtruderType.Rotate, new List<string> { cmds[1], cmds[2], cmds[3], cmds[4], cmds[5] }));
                    //    break;
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
                    btnStartMacro.Text = Localization.Localization.GetStopCaption();
                }
                else
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream("PrConsole.Resources.StartCheck.ico");
                    btnStartMacro.Image = new Bitmap(stream);
                    btnStartMacro.Text = Localization.Localization.GetStartCaption();
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
            PrintInfo($"{Localization.Localization.GetStringResourceByName<ConsoleControl>("AvailableCommands")}:", Color.Black);

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
                            Invoke(new Action(() => ExecuteCommand(cmds)));
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() => PrintInfo(ex.Message, Color.Red)));
                        }
                    });
                    trd.Start();

                    rtxbField.AppendText($"\n < {cmds}");
                }
            }
            else if (e.KeyCode == Keys.Up)
                PrintHistory(ConsoleHistory.GetPreviousCommand());
            else if (e.KeyCode == Keys.Down)
                PrintHistory(ConsoleHistory.GetNextCommand());
        }
    }
}
