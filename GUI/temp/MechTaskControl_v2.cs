using AdvisorControls.TaskPlannerControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class MechTaskControl_v2 : UserControl, ITaskControl
    {
        MechanicalParameters parameters;
        private string tsFullFileName;

        public MechTaskControl_v2()
        {
            InitializeComponent();
        }

        public void SetSolver(int solverIndex)
        {
            cmbSolver.SelectedIndex = 1;
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                txbMaxDU.IsValueValid(),
                txbMaxU.IsValueValid(),
                txbMaxSiSt.IsValueValid(),
                txbPrecision.IsValueValid(),
                txbRelaxation.IsValueValid(),
                txbSaveRate.IsValueValid(),
                txbSolverIterations.IsValueValid(),
                txbBodyTemp.IsValueValid(),
                cmbPriority.IsValueValid(),
                cmbSolver.IsValueValid()
            };
            return checks.All(x => x);
        }

        public void InputData(MechanicalParameters _parameters, string _tsFullFileName)
        {
            parameters = _parameters;

            tsFullFileName = _tsFullFileName;

            if (parameters.MechanicalConvergence.Is_Physically_NonLinear)
                chbPlastisity.Checked = true;

            if (parameters.MechanicalConvergence.Is_Switched_Um)
                chbUMax.Checked = true;

            txbMaxSiSt.Text = parameters.MechanicalConvergence.SiStm.ToString();

            txbMaxU.Text = parameters.MechanicalConvergence.Um.ToString();
            txbMaxDU.Text = parameters.MechanicalConvergence.DUm.ToString();
            txbIters.Text = parameters.Iterations.ToString();

            txbSaveRate.Text = parameters.SaveRate.ToString();
            txbBodyTemp.Text = parameters.InitTemp.ToString();

            cmbSolver.Text = parameters.SolverSettings.Solver;
            txbSolverIterations.Text = parameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = parameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = parameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = parameters.SolverSettings.Priority.ToString();
        }

        public void AllTextBox_TextChanged(object sender, EventArgs e)
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
        }

        public void Txb_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txb)
            {
                if (txb.Enabled == false)
                    txb.Text = "0";
            }
        }

        private void chbPlastisity_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPlastisity.Checked)
            {
                chbUMax.Enabled = true;
                chbUMax.Checked = true;
                txbMaxDU.Enabled = true;
                txbMaxSiSt.Enabled = true;
            }
            else
            {
                chbUMax.Enabled = false;
                chbUMax.Checked = false;
                txbMaxDU.Enabled = false;
                txbMaxSiSt.Enabled = false;
            }
        }

        private void chbUMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUMax.Checked)
                txbMaxU.Enabled = true;
            else
                txbMaxU.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chbUMax.Checked)
            {
                parameters.MechanicalConvergence.Is_Switched_Um = true;
                parameters.MechanicalConvergence.Um = Convert.ToSingle(txbMaxU.Text);
            }

            parameters.MechanicalConvergence.DUm = Convert.ToSingle(txbMaxDU.Text);
            parameters.MechanicalConvergence.SiStm = Convert.ToSingle(txbMaxSiSt.Text);

            parameters.Iterations = Convert.ToInt32(txbIters.Text);

            parameters.MechanicalConvergence.Is_Physically_NonLinear = true;
            parameters.MechanicalConvergence.MaterialPlasticityCoeff = 0.5f;

            parameters.MechanicalConvergence.PlasticityCriterion = Convert.ToSingle(txbMaxSiSt.Text);

            parameters.InitTemp = Convert.ToSingle(txbBodyTemp.Text);
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
