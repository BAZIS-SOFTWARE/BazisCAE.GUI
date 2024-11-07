using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using ProjectInterfaces.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using TasksParameters;
using TaskModule.BasicAdvisorControls.Interfaces;
using TaskModule.BasicAdvisorControls.Events;
using ProjectInterfaces;
using System.Runtime;
using BaseModule;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class TaskPlannerControl_v2 : UserControl,IGridViewControl
    {
        public ProcessType ProcessType { get; set; }

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

        public event Action<object, EventArgs> AddDataUseTaskConditionsEvent;
        public event Action<object, EventArgs> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;
        public event Action<object, AddDataEventArgs> AddDataEvent;
        public event Action<object, DeleteDataEventArgs> DeleteDataEvent;
        public event Action<object, ChangeDataEventArgs> ChangeDataEvent;
        public event Action<object, DeleteAllDataEventArgs> DeleteAllDataEvent;

        enum Column : int { kind, settings, status };
        enum TaskKind : int { химическая,термическая, механическая,твердость };

        //HeatTaskControl_v2 cntrHeatTask;
        //MechTaskControl_v2 cntrMechTask;
        //ChemTaskControl cntrChemTask;

        public TaskPlannerControl_v2()
        {
            InitializeComponent();
            DataName = "Расчет";

            //cntrHeatTask = new HeatTaskControl_v2() { Dock = DockStyle.Fill };
            //cntrMechTask = new MechTaskControl_v2() { Dock = DockStyle.Fill };
            //cntrChemTask = new ChemTaskControl() { Dock = DockStyle.Fill };

            //cntrHeatTask.ChangeDataEvent += Cntrw_InEvent;
            //cntrMechTask.ChangeDataEvent += Cntrw_InEvent;
            //cntrChemTask.ChangeDataEvent += Cntrw_InEvent;

            //cntrHeatTask.SetSolver(1);
            //cntrMechTask.SetSolver(1);
            //cntrChemTask.SetSolver(1);

            // Create the ToolTip and associate with the Form container.
            var toolTip = new System.Windows.Forms.ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(btnLoadParameters, "Выберите директорию с *.tsf файлами");
        }

        public bool IsValidated()
        {
            var checks = new List<bool>()
            {
                txbMaxStep.IsValueValid(),
                txbMinStep.IsValueValid(),
                txbStartStep.IsValueValid(),
                txbStartTime.IsValueValid(),
                txbStopTime.IsValueValid()
            };
            return checks.All(x => x);
        }

        public string DataName { get; }

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

        private void Cntrw_InEvent(object arg1, EventArgs arg2)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                btnRefresh.Enabled = true;
            }
        }

        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var file = e.Row.Cells[1].Value.ToString();
            File.Delete(file);
            if (e.Row.Cells.Count == 0)
                PrevResultLoadBtn.Enabled = false;
            //base.DataGridView_UserDeletingRow(sender, e);
        }

        public void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var taskKindStr = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();

                var fileSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

                TaskKind taskKind;
                Enum.TryParse(taskKindStr, out taskKind);

                var parameters = GetParametersFromFile(taskKind, fileSettings);

                txbStartTime.Text = parameters.TimeSettings.StartTime.ToString();
                txbStopTime.Text = parameters.TimeSettings.StopTime.ToString();
                txbStartStep.Text = parameters.TimeSettings.InitTimeStep.ToString();
                txbMinStep.Text = parameters.TimeSettings.MinTimeStep.ToString();
                txbMaxStep.Text = parameters.TimeSettings.MaxTimeStep.ToString();

                if (parameters.RestartFile != "")
                    chbFurtherComp.Checked = true;
                else
                    chbFurtherComp.Checked = false;

                if (taskKind == TaskKind.механическая)
                    rbtMechTask.Checked = true;
                else if (taskKind == TaskKind.термическая)
                    rbtTermoTask.Checked = true;
                else if (taskKind == TaskKind.химическая)
                    rbtChemicalTask.Checked = true;
                else
                    rbtHardnessTask.Checked = true;

                grbTaskKind.Enabled = false;
                btnRefresh.Enabled = true;
                PrevResultLoadBtn.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private GeneralParameters GetParametersFromFile(TaskKind taskKind, string fileSettings)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            if(taskKind == TaskKind.термическая)
                return JsonConvert.DeserializeObject<TermalParameters>
    (File.ReadAllText(fileSettings), settingsSerializer);
            else if (taskKind == TaskKind.механическая)
                return JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
            else
                return JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
        }

        private void SetParametersToFile(GeneralParameters parameters, string tsfFileName, string path)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllText($@"{path}\{tsfFileName}", parLine);
        }

        public void RefreshButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                var status = dataGridView[(int)Column.status, dataGridView.CurentSelectedRowIndex].Value.ToString();

                TaskStatus taskStatus;
                Enum.TryParse(status, out taskStatus);

                var kind = dataGridView[(int)Column.kind, dataGridView.CurentSelectedRowIndex].Value.ToString();

                TaskKind taskKind;
                Enum.TryParse(kind, out taskKind);

                var fileSettings = dataGridView[(int)Column.settings, dataGridView.CurentSelectedRowIndex].Value.ToString();

                var parameters = GetParametersFromFile(taskKind,fileSettings);

                if (parameters != null)
                {
                    parameters.TimeSettings.StartTime = Convert.ToSingle(txbStartTime.Text);
                    parameters.TimeSettings.StopTime = Convert.ToSingle(txbStopTime.Text);
                    parameters.TimeSettings.InitTimeStep = Convert.ToSingle(txbStartStep.Text);
                    parameters.TimeSettings.MinTimeStep = Convert.ToSingle(txbMinStep.Text);
                    parameters.TimeSettings.MaxTimeStep = Convert.ToSingle(txbMaxStep.Text);

                    var path = Path.GetDirectoryName(fileSettings);

                    var tsfFileName = Path.GetFileName(fileSettings);
                    //$"{taskKind}_{dataGridView.CurentSelectedRowIndex + 1}_{parameters.TimeSettings.StartTime}_{parameters.TimeSettings.StopTime}.tsf";

                    SetParametersToFile(parameters, tsfFileName, path);

                    dataGridView[(int)Column.kind, dataGridView.CurentSelectedRowIndex].Value = taskKind;
                    dataGridView[(int)Column.settings, dataGridView.CurentSelectedRowIndex].Value = $@"{path}\{tsfFileName}";
                    dataGridView[(int)Column.status, dataGridView.CurentSelectedRowIndex].Value = status;
                }
                grbTaskKind.Enabled = true;
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private GeneralParameters GenerateParameters(TaskKind taskKind)
        {
            GeneralParameters parameters;
            if (taskKind == TaskKind.химическая)
                parameters = new ChemicalParameters();
            else if (taskKind == TaskKind.термическая)
                parameters = new TermalParameters();
            else if (taskKind == TaskKind.механическая)
                parameters = new MechanicalParameters();
            else
                parameters = new TermalParameters();

            parameters.TimeSettings.StartTime = Convert.ToSingle(txbStartTime.Text);
                parameters.TimeSettings.StopTime = Convert.ToSingle(txbStopTime.Text);
                parameters.TimeSettings.InitTimeStep = Convert.ToSingle(txbStartStep.Text);
                parameters.TimeSettings.MinTimeStep = Convert.ToSingle(txbMinStep.Text);
                parameters.TimeSettings.MaxTimeStep = Convert.ToSingle(txbMaxStep.Text);

                if (chbFurtherComp.Checked)
                    parameters.RestartFile = $@"{taskKind}_*_*_{parameters.TimeSettings.StartTime}.db";

                return parameters;
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidated()) return;
            try
            {
                if (chbAddByTaskConditions.Checked)
                {
                    AddDataUseTaskConditionsEvent?.Invoke(this, new EventArgs());
                }
                else
                {
                    if(rbtTermoMechTask.Checked)
                    {
                        var parameters = GenerateParameters(TaskKind.термическая);
                        var tsfFileName = $"{TaskKind.термическая}_{dataGridView.RowCount}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                        var args = new GenerateTSFEventArgs(parameters, DataName, tsfFileName);
                        AddDataEvent?.Invoke(this, args);

                        Thread.Sleep(100);

                        parameters = GenerateParameters(TaskKind.механическая);

                        var mechParameters = (MechanicalParameters)parameters;

                        var termFile = $@"термическая_*_{parameters.TimeSettings.StartTime}_{parameters.TimeSettings.StopTime}.db";
                        mechParameters.ThermalFile = termFile;

                        tsfFileName = $"{TaskKind.механическая}_{dataGridView.RowCount}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                        args = new GenerateTSFEventArgs(parameters, DataName, tsfFileName);
                        AddDataEvent?.Invoke(this, args);
                    }
                    else if(rbtChemicalTask.Checked)
                    {
                        var parameters = GenerateParameters(TaskKind.химическая);
                        var tsfFileName = $"{TaskKind.химическая}_{dataGridView.RowCount}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                        var args = new GenerateTSFEventArgs(parameters, DataName, tsfFileName);
                        AddDataEvent?.Invoke(this, args);
                    }
                    else if (rbtTermoTask.Checked)
                    {
                        var parameters = GenerateParameters(TaskKind.термическая);
                        var tsfFileName = $"{TaskKind.термическая}_{dataGridView.RowCount}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                        var args = new GenerateTSFEventArgs(parameters, DataName, tsfFileName);
                        AddDataEvent?.Invoke(this, args);
                    }
                    else if (rbtMechTask.Checked)
                    {
                        var parameters = GenerateParameters(TaskKind.механическая);
                        var tsfFileName = $"{TaskKind.механическая}_{dataGridView.RowCount}_{txbStartTime.Text}_{txbStopTime.Text}.tsf";

                        var args = new GenerateTSFEventArgs(parameters, DataName, tsfFileName);
                        AddDataEvent?.Invoke(this, args);
                    }

                    var temp = txbStopTime.Text;
                    txbStartTime.Text = temp;
                }
                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            DeleteAllDataEvent?.Invoke(this, new DeleteAllDataEventArgs(DataName));
        }

        //start here
        public void Set_DataGridLines(IEnumerable<string> lines)
        {
            dataGridView.Rows.Clear();

            foreach (var line in lines)
                dataGridView.Rows.Add(line.Split(' '));
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog() ;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                //dataGridView.Rows.Clear();
                var files = Directory.GetFiles(fbd.SelectedPath).Where(x => Regex.IsMatch(x, @"(\w*)(\.tsf)"));

                var strs = new List<string>();
                foreach (var file in files)
                {
                    var str = String.Empty;
                    
                    if (file.Contains("термическая"))
                        str = "термическая";
                    else
                        str = "механическая";

                    str += $" {file} {true}";
                    strs.Add(str);
                }

                Set_DataGridLines(strs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    if (dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == TaskStatus.выполнить.ToString())
                        dataGridView[e.ColumnIndex, e.RowIndex].Value = TaskStatus.пропустить.ToString();
                    else
                        dataGridView[e.ColumnIndex, e.RowIndex].Value = TaskStatus.выполнить.ToString();
                }
                else if(e.ColumnIndex == 1)
                {
                    var taskKind = dataGridView[(int)Column.kind, e.RowIndex].Value.ToString();
                    var fileSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

                    var taskControl = CreateTaskControl(taskKind, fileSettings);

                    var form = new Form()
                    {
                        TopMost = true,
                        ShowIcon = false,
                        ClientSize = taskControl.Size,
                        MaximizeBox = false,
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        Owner = Application.OpenForms[0],
                        Text = $"Настройки задачи: {fileSettings}"
                    };

                    form.Controls.Add(taskControl);
                    var location = this.PointToScreen(Point.Empty);
                    form.Show();
                    form.Location = location;
                }
                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static UserControl CreateTaskControl(string taskKind, string fileSettings)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            TaskKind taskKindEnum;
            Enum.TryParse(taskKind, out taskKindEnum);

            UserControl taskControl;
            if (taskKindEnum == TaskKind.термическая)
            {
                var parameters = JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
                var heatControl = new HeatTaskControl_v2();
                heatControl.InputData(parameters, fileSettings);
                taskControl = heatControl;
            }
            else if (taskKindEnum == TaskKind.механическая)
            {
                var parameters = JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
                var mechControl = new MechTaskControl_v2();
                mechControl.InputData(parameters, fileSettings);
                taskControl = mechControl;
            }
            else
            {
                var parameters = JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(fileSettings), settingsSerializer);
                var chemControl = new ChemTaskControl();
                chemControl.InputData(parameters, fileSettings);
                taskControl = new ChemTaskControl();
            }

            return taskControl;
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

        private void PrevResultLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new OpenFileDialog();
                if (fbd.ShowDialog() == DialogResult.OK && Regex.IsMatch(fbd.FileName, @"(\w*)(\.db)"))
                {
                    var settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    };

                    var prevResults = fbd.FileName;
                    var fileWithPath = dataGridView[1, dataGridView.CurentSelectedRowIndex].Value.ToString();

                    var selectedFile = JsonConvert.DeserializeObject<GeneralParameters>(File.ReadAllText(fileWithPath), settings);

                    selectedFile.RestartFile = prevResults;
                    var result = JsonConvert.SerializeObject(selectedFile, settings);
                    File.WriteAllText(fileWithPath, result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Get_DataGridFillLine(int ind)
        {
            throw new NotImplementedException();
        }
    }
}
