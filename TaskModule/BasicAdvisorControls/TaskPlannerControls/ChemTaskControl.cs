using AdvisorControls.TaskPlannerControls;
using Project.TasksData.TaskParameters;
using Project.TasksData;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class ChemTaskControl : TaskControl
    {
        public ChemTaskControl()
        {
            InitializeComponent();
        }
        public override string TaskName { get; }

        public override void SetSolver(int solverIndex)
        {
            cmbSolver.SelectedIndex = 1;
        }

        public override void InputData(GeneralParameters parameters)
        {
            base.InputData(parameters);
            var chemicalParameters = (ChemicalParameters)parameters;
            txbDTtMax.Text = chemicalParameters.ConvergenceSettings.DYmt.ToString();
            txbIters.Text = chemicalParameters.ConvergenceSettings.Iterations.ToString();

            txbSaveRate.Text = chemicalParameters.SaveRate.ToString();
            txbInitConcentration.Text = chemicalParameters.InitConcentration.ToString();

            cmbSolver.Text = chemicalParameters.SolverSettings.Solver;
            txbSolverIterations.Text = chemicalParameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = chemicalParameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = chemicalParameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = chemicalParameters.SolverSettings.Priority.ToString();
        }

        public override GeneralParameters CollectData()
        {
            var chemicalParameters = new ChemicalParameters();

            if (chbDTtMax.Checked)
            {
                chemicalParameters.ConvergenceSettings.Is_Switched_DXmt = true;
                chemicalParameters.ConvergenceSettings.DXmt = Convert.ToSingle(txbDTtMax.Text);
            }

            chemicalParameters.ConvergenceSettings.Iterations = Convert.ToInt32(txbIters.Text);

            chemicalParameters.InitConcentration = Convert.ToSingle(txbInitConcentration.Text);
            chemicalParameters.SaveRate = Convert.ToInt32(txbSaveRate.Text);

            chemicalParameters.SolverSettings.Solver = cmbSolver.Text;
            chemicalParameters.SolverSettings.MaxIter = Convert.ToInt32(txbSolverIterations.Text);
            chemicalParameters.SolverSettings.Precision = Convert.ToSingle(txbPrecision.Text);
            chemicalParameters.SolverSettings.Relaxation = Convert.ToSingle(txbRelaxation.Text);
            chemicalParameters.SolverSettings.Priority = cmbPriority.Text;

            return chemicalParameters;
        }

        public override void AllTextBox_TextChanged(object sender, EventArgs e)
        {
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
                        txbPrecision.Text = "0.01";
                        txbRelaxation.Text = "1.05";
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

                var parameters = JsonConvert.DeserializeObject<ChemicalParameters>
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
