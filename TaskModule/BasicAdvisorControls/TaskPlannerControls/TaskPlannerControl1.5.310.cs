using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using AdvisorControls.TaskPlannerControls;
using System.Globalization;
using System.ComponentModel;
using TaskModule.BasicAdvisorControls.BasicControls;

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

        public event Action<object,EventArgs> AddDataUseTaskConditionsEvent;
        public event Action<object, EventArgs> StartComputationEvent;
        public event Action<object, EventArgs> StopComputationEvent;

        enum Column : int { kind, settings, time };
        enum TaskKind : int { химическая, термическая, механическая, твердость };

        HeatTaskControl cntrHeatTask;
        MechTaskControl cntrMechTask;

        public TaskPlannerControl()
        {
            InitializeComponent();
            DataName = "Расчет";
  
            cntrHeatTask = new HeatTaskControl() { Dock = DockStyle.Fill };
            cntrMechTask = new MechTaskControl() { Dock = DockStyle.Fill };

            cntrHeatTask.ChangeDataEvent += Cntrw_InEvent;
            cntrMechTask.ChangeDataEvent += Cntrw_InEvent;

            cntrHeatTask.SetSolver(1);
            cntrMechTask.SetSolver(1);
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
                        if (cntr is TextBox txb | cntr is ComboBox cmb)
                        {
                            heigth = heigth + cntr.Size.Height;
                            gap = gap + 6;
                        }
                    }
            }
            grbTaskSettings.Height = heigth + gap;
        }

   

        private string GetCurentTimeInfo()
        {
            return String.Format(CultureInfo.InvariantCulture,"{0};{1};{2};{3};{4}",
                txbStartTime.Text,
                txbStopTime.Text,
                txbStartStep.Text,
                txbMinStep.Text,
                txbMaxStep.Text);
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
            base.DataGridView_UserDeletingRow(sender, e);
        }

        public override void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var taskTime = dataGridView[(int)Column.time, e.RowIndex].Value.ToString();

            var strTime = taskTime.Split(';');
            txbStartTime.Text = strTime[0];
            txbStopTime.Text = strTime[1];
            txbStartStep.Text = strTime[2];
            txbMinStep.Text = strTime[3];
            txbMaxStep.Text = strTime[4];

            var taskSettings = dataGridView[(int)Column.settings, e.RowIndex].Value.ToString();

            Set_TaskCntrData(taskSettings, e.RowIndex);

            GetChildControlExpandHeight(grbTaskSettings);


            btnRefresh.Enabled = true; ;
        }      

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader myStream = new StreamReader(openFileDialog.OpenFile());
                        var settingsFileName = openFileDialog.FileName;

                        var taskSettings = FileSettingsIO.ReadFromFile(settingsFileName);

                        Set_TaskCntrData(taskSettings,e.RowIndex);

                        GetChildControlExpandHeight(grbTaskSettings);
                        

                        myStream.Dispose();
                        btnRefresh.Enabled = true;
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Set_TaskCntrData(string taskSettings, int rowInd)
        {         
            var taskKind = dataGridView[(int)Column.kind, rowInd].Value.ToString();
            //var taskParams = new TaskParameters(path); //read from file.txt
            //var data = taskParams.GetData().Split(',');
            grbTaskSettings.Controls.Clear();
            if (taskKind == "термическая")
            {
                chbTermoTask.Checked = true;
                cntrHeatTask.InputData(taskSettings.Split(';'));
                cntrHeatTask.BringToFront();
                grbTaskSettings.Controls.Add(cntrHeatTask);
            }
            else if (taskKind == "механическая")
            {
                chbMechTask.Checked = true;
                cntrMechTask.InputData(taskSettings.Split(';'));
                cntrMechTask.BringToFront();
                grbTaskSettings.Controls.Add(cntrMechTask);
            }
            else
            {
                chbChemicalTask.Checked = true;
            }
        }

        private string Get_TaskSettings(TaskKind kind)
        {
            if (kind == TaskKind.термическая) return cntrHeatTask.CollectData();
            else if (kind == TaskKind.механическая) return cntrMechTask.CollectData();
            else return cntrMechTask.CollectData();
        }

        public override void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                CurentSelectedRowInfo = AddRowInfo();

                base.RefreshButton_Click(sender, e);

                btnRefresh.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void AddButton_Click(object sender, EventArgs e)
        {
            if (chbAddByTaskConditions.Checked)
                AddDataUseTaskConditionsEvent(this, new EventArgs());
            else
            {
                CurentSelectedRowInfo = AddRowInfo();

                base.AddButton_Click(this, new EventArgs());

                var temp = txbStopTime.Text;
                txbStartTime.Text = temp;
            }
            btnRefresh.Enabled = false;

        }

        private string AddRowInfo()
        {
            var taskStrAr = new List<string>();
            string timeStr = GetCurentTimeInfo();
            if (chbChemicalTask.Checked)
                taskStrAr.Add(string.Format("\"{0} {1} {2}\"",TaskKind.химическая.ToString(),Get_TaskSettings(TaskKind.химическая), timeStr));
            if (chbTermoTask.Checked)
                taskStrAr.Add(string.Format("\"{0} {1} {2}\"", TaskKind.термическая.ToString(),Get_TaskSettings(TaskKind.термическая), timeStr));
            if (chbMechTask.Checked)
                taskStrAr.Add(string.Format("\"{0} {1} {2}\"", TaskKind.механическая.ToString(),Get_TaskSettings(TaskKind.механическая), timeStr));
            if (cmbHardnessTask.Checked)
                taskStrAr.Add(string.Format("\"{0} \"*\" {1}\"", TaskKind.твердость.ToString(),timeStr));

            return string.Join(" ", taskStrAr);
        }

        public override void ClearAllDataButton_Click(object sender, EventArgs e)
        {
            base.ClearAllDataButton_Click(sender, e);
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

        

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            if (e.RowIndex >= 0 & e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var assembly = Assembly.GetExecutingAssembly();

                var stream = assembly.GetManifestResourceStream("TaskModule.BasicAdvisorControls.Resources.open.ico");
                var im = new Bitmap(stream);


                var w = im.Width;
                var h = im.Height;
                var x = e.CellBounds.Left + im.Width / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                var loc = new Point(e.CellBounds.Location.X + 1, e.CellBounds.Location.Y + 1);
                var size = new Size(e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                var rec = new Rectangle(loc, size);
                var brush = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(brush, rec);
                e.Graphics.DrawImage(im, new Rectangle(x, y, w, h));

                e.Graphics.DrawString(e.Value.ToString(), this.Font, new SolidBrush(Color.Black),
                    new Point(x + w, y));
                e.Handled = true;
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
    }
}
