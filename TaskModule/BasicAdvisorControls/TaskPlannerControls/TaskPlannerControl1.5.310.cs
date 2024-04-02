using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AdvisorControls.TaskPlannerControls;
using System.Globalization;
using System.ComponentModel;
using TaskModule.BasicAdvisorControls.BasicControls;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using ProjectInterfaces.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class TaskPlannerControl : GridViewAdviserControl
    {
        [Category("Images")]
        [Description("Set image for add button")]
        public Image AddButtonImage
        {
            get { return btnAddNewTask.Image; }
            set { btnAddNewTask.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for clear button")]
        public Image ClearButtonImage
        {
            get { return btnClearAllTask.Image; }
            set { btnClearAllTask.Image = value; }
        }

        [Category("Images")]
        [Description("Set image for refresh button")]
        public Image RefreshButtonImage
        {
            get { return btnRefresh.Image; }
            set { btnRefresh.Image = value; }
        }
        [Category("General")]
        [Description("Set path for computation")]

        public string ProjPath { get; set; }
        string InputDataPath 
        { 
            get 
            {
                var inputDataPath = $@"{Path.GetFullPath(ProjPath)}\InputData";
                return inputDataPath;
            }
        }

        public event Action<object, EventArgs> AddDataUseTaskConditionsEvent;
        public event Action<object, EventArgs> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;

        enum Column : int { kind, settings, status };
        enum TaskKind : int { химическая, термическая, механическая, твердость };

        HeatTaskControl cntrHeatTask;
        MechTaskControl cntrMechTask;
        ChemTaskControl cntrChemTask;

        public TaskPlannerControl()
        {
            InitializeComponent();
            DataName = "Расчет";

            cntrHeatTask = new HeatTaskControl() { Dock = DockStyle.Fill };
            cntrMechTask = new MechTaskControl() { Dock = DockStyle.Fill };
            cntrChemTask = new ChemTaskControl() { Dock = DockStyle.Fill };

            cntrHeatTask.ChangeDataEvent += Cntrw_InEvent;
            cntrMechTask.ChangeDataEvent += Cntrw_InEvent;
            cntrChemTask.ChangeDataEvent += Cntrw_InEvent;

            cntrHeatTask.SetSolver(1);
            cntrMechTask.SetSolver(1);
            cntrChemTask.SetSolver(1);
        }

        public override string DataName { get; }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopComputationEvent(this, new EventArgs());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartComputationEvent(this, new EventArgs());
        }

        private void btnGenTCF_Click(object sender, EventArgs e)
        {
            var strs = dataGridView.Rows.Cast<DataGridViewRow>().Select(x => $"{x.Cells[0].Value} {x.Cells[1].Value} {x.Cells[2].Value}").ToList();
            GenerateTCFEvent(this, new GenerateTCFEventArgs(strs));
        }

        private void grbTask_Paint(object sender, PaintEventArgs e)
        {
            var grb = (GroupBox)sender;
            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            var locRect = new Point(textSize + 5, 3);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var rect = new Rectangle(locRect, new Size(8, 8));

            e.Graphics.DrawRectangle(blackPen, rect);
            if (grb.Height == 17)
            {
                e.Graphics.DrawString("+", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 4, 0);
            }
            else
            {
                e.Graphics.DrawString("-", Font, new SolidBrush(System.Drawing.Color.Blue), textSize + 6, 0);
            }
        }
        private void grbTask_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = grbTaskSettings;

            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            if (e.Location.X > textSize + 5 & e.Location.X < textSize + 15 && e.Location.Y <= 10)
            {
                if (grb.Height == 17)
                {
                    GetChildControlExpandHeight(grb);
                }

                else grb.Height = 17;
            }
        }

        private void GetChildControlExpandHeight(GroupBox grb)
        {
            var heigth = 0;
            var gap = 20;
            foreach (Control control in grb.Controls)
            {
                if (control is UserControl uControl)
                    foreach (Control cntr in uControl.Controls)
                    {
                        if (cntr is TextBox txb | cntr is ComboBox cmb | cntr is Button)
                        {
                            heigth = heigth + cntr.Size.Height;
                            gap = gap + 5;
                        }
                    }
            }
            grbTaskSettings.Height = heigth + gap;
        }

        private void Cntrw_InEvent(object arg1, EventArgs arg2)
        {
            if (CountSelectedRow > 0)
            {
                btnRefresh.Enabled = true;
            }
        }

        public override void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var file = e.Row.Cells[1].Value.ToString();
            File.Delete(file);
            //base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var taskKind = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();

                var taskSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

                Set_TaskSettings(taskKind, taskSettings, e.RowIndex);

                GetChildControlExpandHeight(grbTaskSettings);

                btnRefresh.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Set_TaskSettings(string taskKind, string fileSettings, int rowInd)
        {
            //var taskParams = new TaskParameters(path); //read from file.txt
            //var filePath = $@"{ProjPath}\{fileSettings}";

            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            grbTaskSettings.Controls.Clear();

            GeneralParameters parameters;
            if (taskKind == "термическая")
            {
                parameters = CreateTermalTaskSettings(fileSettings, settingsSerializer);
            }
            else if (taskKind == "механическая")
            {
                parameters = CreateMechTaskSettings(fileSettings, settingsSerializer);
            }
            else
            {
                parameters = CreateChemicalTaskSettings(fileSettings, settingsSerializer);
            }


            txbStartTime.Text = parameters.TimeSettings.StartTime.ToString();
            txbStopTime.Text = parameters.TimeSettings.StopTime.ToString();
            txbStartStep.Text = parameters.TimeSettings.InitTimeStep.ToString();
            txbMinStep.Text = parameters.TimeSettings.MinTimeStep.ToString();
            txbMaxStep.Text = parameters.TimeSettings.MaxTimeStep.ToString();
            chbFurtherComp.Checked = !parameters.RestartFile.Equals(string.Empty);
        }

        private GeneralParameters CreateChemicalTaskSettings(string fileSettings, JsonSerializerSettings settingsSerializer)
        {
            GeneralParameters parameters;
            chbChemicalTask.Checked = true;
            parameters = JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
            cntrChemTask.InputData(parameters);
            cntrChemTask.BringToFront();
            grbTaskSettings.Controls.Add(cntrChemTask);
            return parameters;
        }

        private GeneralParameters CreateMechTaskSettings(string fileSettings, JsonSerializerSettings settingsSerializer)
        {
            GeneralParameters parameters;

            parameters = JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
            cntrMechTask.InputData(parameters);
            cntrMechTask.BringToFront();
            grbTaskSettings.Controls.Add(cntrMechTask);

            var mechPar = parameters as MechanicalParameters;

            if (!mechPar.ThermalFile.Equals(string.Empty))
            {
                chbLinkedCalc.Checked = true;
                chbTermoTask.Checked = true;
                if (!mechPar.ChemicalFile.Equals(string.Empty))
                    chbChemicalTask.Checked = true;
            }
            else
            {
                chbLinkedCalc.Checked = false;
                chbTermoTask.Checked = false;
                chbChemicalTask.Checked = false;
            }

            chbMechTask.Checked = true;

            return parameters;
        }

        private GeneralParameters CreateTermalTaskSettings(string fileSettings, JsonSerializerSettings settingsSerializer)
        {
            GeneralParameters parameters;

            parameters = JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
            cntrHeatTask.InputData(parameters);
            cntrHeatTask.BringToFront();
            grbTaskSettings.Controls.Add(cntrHeatTask);

            var termPar = parameters as TermalParameters;

            if (!termPar.ChemicalFile.Equals(string.Empty))
            {
                chbLinkedCalc.Checked = true;
                chbChemicalTask.Checked = true;
            }
            else
            {
                chbLinkedCalc.Checked = false;
                chbChemicalTask.Checked = false;
            }
            chbTermoTask.Checked = true;
            chbMechTask.Checked = false;
            return parameters;
        }

        private GeneralParameters Get_TaskSettings(TaskKind kind)
        {
            if (kind == TaskKind.термическая) return cntrHeatTask.CollectData();
            else if (kind == TaskKind.механическая) return cntrMechTask.CollectData();
            else return cntrMechTask.CollectData();
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                var status = dataGridView[(int)Column.status, CurentSelectedRowIndex].Value.ToString();

                TaskStatus taskStatus;
                Enum.TryParse(status, out taskStatus);

                var kind = dataGridView[(int)Column.kind, CurentSelectedRowIndex].Value.ToString();

                TaskKind taskKind;
                Enum.TryParse(kind, out taskKind);

                var setting = dataGridView[(int)Column.settings, CurentSelectedRowIndex].Value.ToString();
                var taskInd = int.Parse(Path.GetFileName(setting).Split('_')[1]);

                GenerateTsfFile(taskKind, taskInd, InputDataPath);
                //CurentSelectedRowInfo = AddRowInfo(taskKind, taskStatus, CurentSelectedRowIndex);
                //base.RefreshButton_Click(sender, e);

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GenerateTsfFile(TaskKind taskKind, int taskIndex, string path)
        {
            try
            {
                var parameters = Get_TaskSettings(taskKind);

                parameters.TermalProcesses = new List<string>() { "Охлаждение", "Нагрев" };

                parameters.TimeSettings.StartTime = Convert.ToSingle(txbStartTime.Text);
                parameters.TimeSettings.StopTime = Convert.ToSingle(txbStopTime.Text);
                parameters.TimeSettings.InitTimeStep = Convert.ToSingle(txbStartStep.Text);
                parameters.TimeSettings.MinTimeStep = Convert.ToSingle(txbMinStep.Text);
                parameters.TimeSettings.MaxTimeStep = Convert.ToSingle(txbMaxStep.Text);

                var settingsSerializer = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                if (chbFurtherComp.Checked)
                    parameters.RestartFile = $@"{taskKind}_*_*_{parameters.TimeSettings.StartTime}.db";

                var tsfStr = String.Empty;
                if (taskKind == TaskKind.термическая)
                    tsfStr = JsonConvert.SerializeObject((TermalParameters)parameters, settingsSerializer);

                else if (taskKind == TaskKind.механическая)
                {
                    var mechParameters = (MechanicalParameters)parameters;

                    if (chbLinkedCalc.Checked)
                        if (chbTermoTask.Checked)
                        {
                            var termFile = $@"термическая_*_{parameters.TimeSettings.StartTime}_{parameters.TimeSettings.StopTime}.db";
                            mechParameters.ThermalFile = termFile;
                        }

                    tsfStr = JsonConvert.SerializeObject(mechParameters, settingsSerializer);
                }

                else
                    tsfStr = JsonConvert.SerializeObject(parameters, settingsSerializer);

                var tsfFileName = $"{taskKind}_{taskIndex}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                File.WriteAllText($@"{path}\{tsfFileName}", tsfStr);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbAddByTaskConditions.Checked)
                {
                    DeleteAllTsfFilesFromInputDataDir();
                    AddDataUseTaskConditionsEvent?.Invoke(this, new EventArgs());
                }
                else
                {
                    var isTsfFileCreated = false;
                    if (chbChemicalTask.Checked)
                    {
                        isTsfFileCreated = GenerateTsfFile(TaskKind.химическая, CountRows, InputDataPath);
                        if (isTsfFileCreated)
                            AddRowInfo(TaskKind.химическая, TaskStatus.выполнить, CountRows);
                    }
                    Thread.Sleep(100);
                    if (chbTermoTask.Checked)
                    {
                        isTsfFileCreated = GenerateTsfFile(TaskKind.термическая, CountRows, InputDataPath);
                        if (isTsfFileCreated)
                            AddRowInfo(TaskKind.термическая, TaskStatus.выполнить, CountRows);
                    }
                    
                    Thread.Sleep(100);
                    if (chbMechTask.Checked)
                    {
                        isTsfFileCreated = GenerateTsfFile(TaskKind.механическая, CountRows, InputDataPath);
                        if (isTsfFileCreated)
                            AddRowInfo(TaskKind.механическая, TaskStatus.выполнить, CountRows);
                    }
                    if (isTsfFileCreated)
                    {
                        var temp = txbStopTime.Text;
                        txbStartTime.Text = temp;
                    }

                }
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddRowInfo(TaskKind taskKind, TaskStatus status, int taskInd)
        {
            if (txbStartTime.Text == "")
                throw new Exception("Время старта не указано");

            if (txbStopTime.Text == "")
                throw new Exception("Время окончания не указано");

            var tsfFileName = $"{taskKind}_{taskInd}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";
            
            dataGridView.Rows.Add(new string[] { taskKind.ToString(), $@"{InputDataPath}\{tsfFileName}", status.ToString() });
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllTsfFilesFromInputDataDir();

            dataGridView.Rows.Clear();
            //base.ClearAllDataButton_Click(sender, e);
        }

        private void DeleteAllTsfFilesFromInputDataDir()
        {
            try
            {
                foreach (var file in Directory.GetFiles(InputDataPath))
                {
                    if (Regex.IsMatch(file, @"(\w*)(\.tsf)"))
                        File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File can't be deleted: {ex.Message}");
            }
        }

        public override void Set_DataGridLines(IEnumerable<string> lines)
        {
            dataGridView.Rows.Clear();

            foreach (var line in lines)
            {
                var taskType = Path.GetFileName(line).Split('_')[0];
                dataGridView.Rows.Add(new string[] { taskType, line, TaskStatus.выполнить.ToString() });
            }
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog() { SelectedPath = ProjPath };
                if (fbd.ShowDialog() == DialogResult.OK)
                    ProjPath = fbd.SelectedPath;
                else
                    return;

                dataGridView.Rows.Clear();

                foreach (var file in Directory.GetFiles(ProjPath))
                {
                    if (Regex.IsMatch(file, @"(\w*)(\.tsf)"))
                    {
                        var taskType = Path.GetFileName(file).Split('_')[0];
                        dataGridView.Rows.Add(new string[] { taskType, file, TaskStatus.выполнить.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimeSettingsTextBox_Leave(object sender, EventArgs e)
        {
            var txb = (TextBox)sender;
            bool isInt = float.TryParse(txb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float res);

            if (!isInt)
            {
                txb.Text = "0";
            }
        }

        private void chbTaskKind_CheckedChange(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;

            if (!chbLinkedCalc.Checked)
            {
                if (chb.Tag.ToString() == "0")
                {
                    if (chb.Checked)
                    {
                        chbTermoTask.Checked = false;
                        chbMechTask.Checked = false;
                    }
                }
                else if (chb.Tag.ToString() == "1")
                {
                    if (chb.Checked)
                    {
                        chbChemicalTask.Checked = false;
                        chbMechTask.Checked = false;
                    }
                }
                else
                {
                    if (chb.Checked)
                    {
                        chbChemicalTask.Checked = false;
                        chbTermoTask.Checked = false;
                    }
                }
            }
        }



        private void chbLinkedCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbLinkedCalc.Checked)
            {
                chbChemicalTask.Checked = false;
                chbTermoTask.Checked = false;
                chbMechTask.Checked = false;
            }
        }

        private void LblTermoTask_Click(object sender, EventArgs e)
        {
            lblTermoTask.BackColor = Color.Gray;
            lblTermoTask.ForeColor = Color.White;

            lblChemicalTask.BackColor = Color.Transparent;
            lblChemicalTask.ForeColor = Color.Black;

            lblMechTask.BackColor = Color.Transparent;
            lblMechTask.ForeColor = Color.Black;

            grbTaskSettings.Controls.Clear();

            cntrHeatTask.BringToFront();
            grbTaskSettings.Controls.Add(cntrHeatTask);

            GetChildControlExpandHeight(grbTaskSettings);

        }

        private void LblMechTask_Click(object sender, EventArgs e)
        {
            lblMechTask.BackColor = Color.Gray;
            lblMechTask.ForeColor = Color.White;

            lblTermoTask.BackColor = Color.Transparent;
            lblTermoTask.ForeColor = Color.Black;

            lblChemicalTask.BackColor = Color.Transparent;
            lblChemicalTask.ForeColor = Color.Black;

            grbTaskSettings.Controls.Clear();

            cntrMechTask.BringToFront();
            grbTaskSettings.Controls.Add(cntrMechTask);

            GetChildControlExpandHeight(grbTaskSettings);

        }

        private void LblChemicalTask_Click(object sender, EventArgs e)
        {
            lblChemicalTask.BackColor = Color.Gray;
            lblChemicalTask.ForeColor = Color.White;

            lblTermoTask.BackColor = Color.Transparent;
            lblTermoTask.ForeColor = Color.Black;

            lblMechTask.BackColor = Color.Transparent;
            lblMechTask.ForeColor = Color.Black;
        }



        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    dataGridView.Rows[e.RowIndex].Selected = true;

                    if (dataGridView[e.ColumnIndex, CurentSelectedRowIndex].Value.ToString() == TaskStatus.выполнить.ToString())
                        dataGridView[e.ColumnIndex, CurentSelectedRowIndex].Value = TaskStatus.пропустить.ToString();
                    else
                        dataGridView[e.ColumnIndex, CurentSelectedRowIndex].Value = TaskStatus.выполнить.ToString();
                }
                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == (int)Column.settings)
            {
                // Try to sort based on the cells in the current column.
                var fTask = Path.GetFileNameWithoutExtension(e.CellValue1.ToString());
                var sTask = Path.GetFileNameWithoutExtension(e.CellValue2.ToString());

                var fstrAr = fTask.Split('_');
                var sstrAr = sTask.Split('_');

                var numbComp = int.Parse(fstrAr[1]).CompareTo(int.Parse(sstrAr[1]));

                if (numbComp != 0)
                    e.SortResult = numbComp;

                else
                    e.SortResult = String.Compare(sTask, fTask);
            }
            else e.Handled = false;

            e.Handled = true;
        }
    }
}
