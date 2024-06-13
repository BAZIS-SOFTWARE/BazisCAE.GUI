using AdvisorControls.TaskPlannerControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    public partial class HeatTaskControl_v2 : TaskControl
    {
        public HeatTaskControl_v2()
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
            var termalParameters = (TermalParameters)parameters;

            if (termalParameters.TermalConvergence.Is_Switched_Tm)
                chbDTtMax.Checked = true;

            txbDTtMax.Text = termalParameters.TermalConvergence.Tm.ToString();
            txbIters.Text = termalParameters.Iterations.ToString();

            txbSaveRate.Text = termalParameters.SaveRate.ToString();
            txbInitTemp.Text = termalParameters.InitTemp.ToString();

            cmbSolver.Text = termalParameters.SolverSettings.Solver;
            txbSolverIterations.Text = termalParameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = termalParameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = termalParameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = termalParameters.SolverSettings.Priority.ToString();
        }

        public override GeneralParameters CollectData()
        {
            var termalParameters = new TermalParameters();

            if (chbDTtMax.Checked)
            {
                termalParameters.TermalConvergence.Is_Switched_Tm = true;
                termalParameters.TermalConvergence.Tm = Convert.ToSingle(txbDTtMax.Text);
            }

            termalParameters.Iterations = Convert.ToInt32(txbIters.Text);

            termalParameters.InitTemp = Convert.ToSingle(txbInitTemp.Text);
            termalParameters.SaveRate = Convert.ToInt32(txbSaveRate.Text);

            termalParameters.SolverSettings.Solver = cmbSolver.Text;
            termalParameters.SolverSettings.MaxIter = Convert.ToInt32(txbSolverIterations.Text);
            termalParameters.SolverSettings.Precision = Convert.ToSingle(txbPrecision.Text);
            termalParameters.SolverSettings.Relaxation = Convert.ToSingle(txbRelaxation.Text);
            termalParameters.SolverSettings.Priority = cmbPriority.Text;

            return termalParameters;
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
        }

        public override void Txb_EnabledChanged(object sender, EventArgs e)
        {
            base.Txb_EnabledChanged(sender, e);
        }

        private void chbDTtMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDTtMax.Checked)
                txbDTtMax.Enabled = true;
            else
                txbDTtMax.Enabled = false;
        }
    }
}
