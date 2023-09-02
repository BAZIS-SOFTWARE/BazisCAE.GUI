using Project.TasksData;
using Project.TasksData.TaskParameters;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace AdvisorControls.TaskPlannerControls
{
    public partial class HeatTaskControl : TaskControl
    {
        public HeatTaskControl()
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
            var termalParameters = (TermalParameters)parameters;
            txbDTtMax.Text = termalParameters.ConvergenceSettings.DYmt.ToString();          
            txbIters.Text = termalParameters.ConvergenceSettings.Iterations.ToString();

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
                termalParameters.ConvergenceSettings.Is_Swithed_DXmt = true;
                termalParameters.ConvergenceSettings.DXmt = Convert.ToSingle(txbDTtMax.Text);
            }
           
            termalParameters.ConvergenceSettings.Iterations = Convert.ToInt32(txbIters.Text);
            
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


            base.AllTextBox_TextChanged(sender, e);
        }

        public override void Txb_EnabledChanged(object sender, EventArgs e)
        {
            base.Txb_EnabledChanged(sender, e);
        }
    }
}
