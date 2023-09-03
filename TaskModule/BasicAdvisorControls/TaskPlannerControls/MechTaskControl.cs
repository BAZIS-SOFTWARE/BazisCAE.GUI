using Newtonsoft.Json;
using Project.TasksData;
using Project.TasksData.TaskParameters;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AdvisorControls.TaskPlannerControls
{
    public partial class MechTaskControl : TaskControl
    {

        public MechTaskControl()
        {
            InitializeComponent();
        }
        public override string TaskName { get; }

        public override void SetSolver(int solverIndex)
        {
            cmbSolver.SelectedIndex = 1;
        }

        public override GeneralParameters CollectData()
        {
            var mechParameters = new MechanicalParameters();

            if(chbDUiMax.Checked)
            {
                mechParameters.ConvergenceSettings.Is_Switched_DXmi = true;
                mechParameters.ConvergenceSettings.DXmi = Convert.ToSingle(txbMaxDUi.Text);
            }

            if (chbDUtMax.Checked)
            {
                mechParameters.ConvergenceSettings.Is_Switched_DXmt = true;
                mechParameters.ConvergenceSettings.DXmt = Convert.ToSingle(txbMaxDUt.Text);
            }
            if (chbDSiMax.Checked)
            {
                mechParameters.ConvergenceSettings.Is_Switched_DYmi = true;
                mechParameters.ConvergenceSettings.DYmi = Convert.ToSingle(txbMaxDSi.Text);
            }
            if (chbDStMax.Checked)
            {
                mechParameters.ConvergenceSettings.Is_Switched_DYmt = true;
                mechParameters.ConvergenceSettings.DYmt = Convert.ToSingle(txbMaxDSt.Text);
            }

            mechParameters.ConvergenceSettings.Iterations = Convert.ToInt32(txbIters.Text);

            mechParameters.BodyTemp = Convert.ToSingle(txbBodyTemp.Text);
            mechParameters.SaveRate = Convert.ToInt32(txbSaveRate.Text);

            mechParameters.SolverSettings.Solver = cmbSolver.Text;
            mechParameters.SolverSettings.MaxIter = Convert.ToInt32(txbSolverIterations.Text);
            mechParameters.SolverSettings.Precision = Convert.ToSingle(txbPrecision.Text);
            mechParameters.SolverSettings.Relaxation = Convert.ToSingle(txbRelaxation.Text);
            mechParameters.SolverSettings.Priority = cmbPriority.Text;

            return mechParameters;
        }

        public override void InputData(GeneralParameters parameters)
        {
            var mechParameters = (MechanicalParameters)parameters;
            txbMaxDSt.Text = mechParameters.ConvergenceSettings.DYmt.ToString();
            txbMaxDSi.Text = mechParameters.ConvergenceSettings.DYmi.ToString();
            txbMaxDUt.Text = mechParameters.ConvergenceSettings.DXmt.ToString();
            txbMaxDUi.Text = mechParameters.ConvergenceSettings.DXmi.ToString();
            txbIters.Text = mechParameters.ConvergenceSettings.Iterations.ToString();

            txbSaveRate.Text = mechParameters.SaveRate.ToString();
            txbBodyTemp.Text = mechParameters.BodyTemp.ToString();

            cmbSolver.Text = mechParameters.SolverSettings.Solver;
            txbSolverIterations.Text = mechParameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = mechParameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = mechParameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = mechParameters.SolverSettings.Priority.ToString();
        }

        public override void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            //var taskData = CollectData();
            if (sender is ComboBox cmb)
                if (cmb.SelectedItem.ToString() == "Gauss_direct")
                {
                    txbPrecision.Enabled = false;
                    txbRelaxation.Enabled = false;
                    txbSolverIterations.Enabled = false;
                }
                else
                {
                    if (cmb.Text == "SOR_iterative" | cmb.Text == "CG_iterative")
                    {
                        txbPrecision.Text = "0.0001";
                        txbRelaxation.Text = "1.25";
                        txbSolverIterations.Text = "100";
                    }
                    txbPrecision.Enabled = true;
                    txbRelaxation.Enabled = true;
                    txbSolverIterations.Enabled = true;
                }

            base.AllTextBox_TextChanged(sender, e);
        }

        public override void Txb_EnabledChanged(object sender, EventArgs e)
        {
            base.Txb_EnabledChanged(sender, e);
        }


        private void CheBox_CheckedChanged(object sender, EventArgs e)
        {
            var chb = sender as CheckBox;

            if (chb == chbDUtMax)
                if (chb.Checked)
                {
                    txbMaxDUt.Text = "10";
                    txbMaxDUt.Enabled = true;
                }
                else
                {
                    txbMaxDUt.Text = "0";
                    txbMaxDUt.Enabled = false;
                }
            if (chb == chbDStMax)
                if (chb.Checked)
                {
                    txbMaxDSt.Text = "50";
                    txbMaxDSt.Enabled = true;
                }
                else
                {
                    txbMaxDSt.Text = "0";
                    txbMaxDSt.Enabled = false;
                }
            if (chb == chbDSiMax)
                if (chb.Checked)
                {
                    txbMaxDSi.Text = "5";
                    txbMaxDSi.Enabled = true;
                }
                else
                {
                    txbMaxDSi.Text = "0";
                    txbMaxDSi.Enabled = false;
                }

        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            try
            {

                var dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;
                var settingsSerializer = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                var parameters = JsonConvert.DeserializeObject<MechanicalParameters>
    (File.ReadAllText(dialog.FileName), settingsSerializer);
                InputData(parameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
