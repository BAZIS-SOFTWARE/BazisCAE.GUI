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
using Tasks.TaskParameters;
using ProjectInterfaces.Tasks;
using System.Text.RegularExpressions;

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
        public string Path { get; set; }

        public event Action<object,EventArgs> AddDataUseTaskConditionsEvent;
        public event Action<object, EventArgs> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;

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
                if (grb.Height == 17) GetChildControlExpandHeight(grb);
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
                            gap = gap + 6;
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
            File.Delete(Path + e.Row.Cells[1]);
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var taskKind = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();

                var taskSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

                Set_TaskSettings(taskKind, taskSettings, e.RowIndex);

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
            var filePath = $@"{Path}\{fileSettings}";

            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            grbTaskSettings.Controls.Clear();

            GeneralParameters parameters;
            if (taskKind == "термическая")
            {
                chbTermoTask.Checked = true;
                parameters = JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(filePath), settingsSerializer);
                cntrHeatTask.InputData(parameters);
                cntrHeatTask.BringToFront();
                grbTaskSettings.Controls.Add(cntrHeatTask);
            }
            else if (taskKind == "механическая")
            {
                chbMechTask.Checked = true;
                parameters = JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
                cntrMechTask.InputData(parameters);
                cntrMechTask.BringToFront();
                grbTaskSettings.Controls.Add(cntrMechTask);
                chbLinkedCalc.Checked = !(parameters as MechanicalParameters).TermalProcesses.Equals(string.Empty);
            }
            else
            {
                chbChemicalTask.Checked = true;
                parameters = JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
                cntrChemTask.InputData(parameters);
                cntrChemTask.BringToFront();
                grbTaskSettings.Controls.Add(cntrChemTask);
            }


            txbStartTime.Text = parameters.TimeSettings.StartTime.ToString();
            txbStopTime.Text = parameters.TimeSettings.StopTime.ToString();
            txbStartStep.Text = parameters.TimeSettings.InitTimeStep.ToString();
            txbMinStep.Text = parameters.TimeSettings.MinTimeStep.ToString();
            txbMaxStep.Text = parameters.TimeSettings.MaxTimeStep.ToString();
            chbFurtherComp.Checked = !parameters.RestartFile.Equals(string.Empty);
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

                GenerateTsfFile(taskKind, CurentSelectedRowIndex);
                CurentSelectedRowInfo = AddRowInfo(taskKind, taskStatus, CurentSelectedRowIndex);
                base.RefreshButton_Click(sender, e);

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GenerateTsfFile(TaskKind taskKind, int taskIndex)
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

                File.WriteAllText($@"{Path}\{tsfFileName}", tsfStr);

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
                    AddDataUseTaskConditionsEvent?.Invoke(this, new EventArgs());
                else
                {
                    var isTsfFileCreated = false;
                    if (chbChemicalTask.Checked)
                    {
                        CurentSelectedRowInfo = AddRowInfo(TaskKind.химическая, TaskStatus.выполнить, CountRows);
                        isTsfFileCreated = GenerateTsfFile(TaskKind.химическая, CountRows);
                        base.AddButton_Click(this, new EventArgs());
                    }
                    Thread.Sleep(100);
                    if (chbTermoTask.Checked)
                    {
                        CurentSelectedRowInfo = AddRowInfo(TaskKind.термическая, TaskStatus.выполнить, CountRows);
                        isTsfFileCreated = GenerateTsfFile(TaskKind.термическая, CountRows);
                        base.AddButton_Click(this, new EventArgs());
                    }
                    Thread.Sleep(100);
                    if (chbMechTask.Checked)
                    {
                        CurentSelectedRowInfo = AddRowInfo(TaskKind.механическая, TaskStatus.выполнить, CountRows);
                        isTsfFileCreated = GenerateTsfFile(TaskKind.механическая, CountRows);
                        base.AddButton_Click(this, new EventArgs());
                    }
                    if(isTsfFileCreated)
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

        private string AddRowInfo(TaskKind taskKind, TaskStatus status, int taskInd)
        {
            if (txbStartTime.Text == "")
                throw new Exception("Время старта не указано");

            if (txbStopTime.Text == "")
                throw new Exception("Время окончания не указано");

            var tsfFileName = $"{taskKind}_{taskInd}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";
            return $"\"{taskKind} {tsfFileName} {status}\"";
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllTsfFilesFromDisc(Path);
            base.ClearAllDataButton_Click(sender, e);
        }

        private void DeleteAllTsfFilesFromDisc(string path)
        {
            try
            {
                foreach (var file in Directory.GetFiles(path))
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

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureComputationDirectoryCreated();
                var fbd = new FolderBrowserDialog();
                string path =Path;
                if (fbd.ShowDialog() == DialogResult.OK) 
                    path = fbd.SelectedPath;

                DeleteAllTsfFilesFromDisc(path);
                foreach (var file in Directory.GetFiles(path))
                {
                    if (Regex.IsMatch(file, @"(\w*)(\.tsf)"))
                        AddToComputationFolder(file);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnsureComputationDirectoryCreated()
        {
            if (!Directory.Exists($"{Path}Computation"))
                Directory.CreateDirectory($"{Path}Computation");
        }

        private void AddToComputationFolder(string path)
        {
            var compFolder = $"{Path}Computation";
            var file = File.ReadAllText(path);
            File.WriteAllText($"{compFolder}{path.Substring(path.LastIndexOf('\\'))}", file);
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

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            //TO DO
        }
    }
}
