using AdvisorControls.TaskPlannerControls;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using TasksParameters;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.TasksControls
{
    public partial class ChemTaskControl : UserControl, ITaskControl
    {
        private ChemicalParameters parameters;
        private string tsFullFileName;

        public ChemTaskControl()
        {
            InitializeComponent();
        }

        public void SetSolver(int solverIndex)
        {
            cmbSolver.SelectedIndex = 1;
        }

        public void InputData(ChemicalParameters _parameters, string _tsFullFileName)
        {
            parameters = _parameters;

            tsFullFileName = _tsFullFileName;

            txbDTtMax.Text = parameters.ChemicalConvergence.Cm.ToString();
            txbIters.Text = parameters.Iterations.ToString();

            txbSaveRate.Text = parameters.SaveRate.ToString();
            txbInitConcentration.Text = parameters.InitConcentration.ToString();

            cmbSolver.Text = parameters.SolverSettings.Solver;
            txbSolverIterations.Text = parameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = parameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = parameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = parameters.SolverSettings.Priority.ToString();
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                cmbPriority.IsValueValid(),
                cmbSolver.IsValueValid(),
                txbDTtMax.IsValueValid(),
                txbInitConcentration.IsValueValid(),
                txbIters.IsValueValid(),
                txbPrecision.IsValueValid(),
                txbRelaxation.IsValueValid(),
                txbSaveRate.IsValueValid(),
                txbSolverIterations.IsValueValid()
            };
            return checks.All(x => x);
        }

        public void AllTextBox_TextChanged(object sender, EventArgs e)
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
        }

        public void Txb_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txb)
            {
                if (txb.Enabled == false)
                    txb.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parameters = new ChemicalParameters();

            if (chbDTtMax.Checked)
            {
                parameters.ChemicalConvergence.Is_Switched_Cm = true;
                parameters.ChemicalConvergence.Cm = Convert.ToSingle(txbDTtMax.Text);
            }

            parameters.Iterations = Convert.ToInt32(txbIters.Text);

            parameters.InitConcentration = Convert.ToSingle(txbInitConcentration.Text);
            parameters.SaveRate = Convert.ToInt32(txbSaveRate.Text);

            parameters.SolverSettings.Solver = cmbSolver.Text;
            parameters.SolverSettings.MaxIter = Convert.ToInt32(txbSolverIterations.Text);
            parameters.SolverSettings.Precision = Convert.ToSingle(txbPrecision.Text);
            parameters.SolverSettings.Relaxation = Convert.ToSingle(txbRelaxation.Text);
            parameters.SolverSettings.Priority = cmbPriority.Text;

            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);

            File.WriteAllText(tsFullFileName, parLine);
        }
    }
}
