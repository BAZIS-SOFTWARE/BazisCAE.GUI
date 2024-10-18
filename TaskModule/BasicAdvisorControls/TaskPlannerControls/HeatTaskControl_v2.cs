using AdvisorControls.TaskPlannerControls;
using Newtonsoft.Json;
using ProjectInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class HeatTaskControl_v2 : UserControl, ITaskControl
    {
        TermalParameters parameters;
        private string tsFullFileName;

        public HeatTaskControl_v2()
        {
            InitializeComponent();
        }

        public event Action<object, EventArgs> ChangeDataEvent;

        public void SetSolver(int solverIndex)
        {
            cmbSolver.SelectedIndex = 1;
        }

        public void InputData(TermalParameters _parameters, string _tsFullFileName)
        {
            parameters = _parameters;
 
            tsFullFileName = _tsFullFileName;

            if (parameters.TermalConvergence.Is_Switched_Tm)
                chbDTtMax.Checked = true;

            txbDTtMax.Text = parameters.TermalConvergence.Tm.ToString();
            txbIters.Text = parameters.Iterations.ToString();

            txbSaveRate.Text = parameters.SaveRate.ToString();
            txbInitTemp.Text = parameters.InitTemp.ToString();

            cmbSolver.Text = parameters.SolverSettings.Solver;
            txbSolverIterations.Text = parameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = parameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = parameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = parameters.SolverSettings.Priority.ToString();
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

        private void chbDTtMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDTtMax.Checked)
                txbDTtMax.Enabled = true;
            else
                txbDTtMax.Enabled = false;
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                cmbSolver.IsValueValid(),
                cmbPriority.IsValueValid(),
                txbDTtMax.IsValueValid(),
                txbInitTemp.IsValueValid(),
                txbIters.IsValueValid(),
                txbPrecision.IsValueValid(),
                txbRelaxation.IsValueValid(),
                txbSaveRate.IsValueValid(),
                txbSolverIterations.IsValueValid()
            };
            return checks.All(x => x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chbDTtMax.Checked)
            {
                parameters.TermalConvergence.Is_Switched_Tm = true;
                parameters.TermalConvergence.Tm = Convert.ToSingle(txbDTtMax.Text);
            }

            parameters.Iterations = Convert.ToInt32(txbIters.Text);

            parameters.InitTemp = Convert.ToSingle(txbInitTemp.Text);
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
