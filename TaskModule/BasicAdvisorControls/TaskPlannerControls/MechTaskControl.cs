using Project.TasksData;
using Project.TasksData.TaskParameters;
using System;
using System.Globalization;
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
            var mechParameters = new TermalParameters();

            mechParameters.ConvergenceSettings.DYmt = Convert.ToSingle(txbMaxDSt.Text);
            mechParameters.ConvergenceSettings.DYmi = Convert.ToSingle(txbMaxDSi.Text);

            mechParameters.ConvergenceSettings.DXmt = Convert.ToSingle(txbMaxDUt.Text);
            mechParameters.ConvergenceSettings.DXmi = Convert.ToSingle(txbMaxDUi.Text);

            mechParameters.ConvergenceSettings.Iterations = Convert.ToInt32(txbIters.Text);

            mechParameters.InitTemp = Convert.ToSingle(txbInitTemp.Text);
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
            base.InputData(parameters);
            var termalParameters = (TermalParameters)parameters;
            txbMaxDSt.Text = termalParameters.ConvergenceSettings.DYmt.ToString();
            txbMaxDSi.Text = termalParameters.ConvergenceSettings.DYmi.ToString();
            txbMaxDUt.Text = termalParameters.ConvergenceSettings.DXmt.ToString();
            txbMaxDUi.Text = termalParameters.ConvergenceSettings.DXmi.ToString();
            txbIters.Text = termalParameters.ConvergenceSettings.Iterations.ToString();

            txbSaveRate.Text = termalParameters.SaveRate.ToString();
            txbInitTemp.Text = termalParameters.InitTemp.ToString();

            cmbSolver.Text = termalParameters.SolverSettings.Solver;
            txbSolverIterations.Text = termalParameters.SolverSettings.MaxIter.ToString();
            txbPrecision.Text = termalParameters.SolverSettings.Precision.ToString();
            txbRelaxation.Text = termalParameters.SolverSettings.Relaxation.ToString();
            cmbPriority.Text = termalParameters.SolverSettings.Priority.ToString();
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

            if (chb == maxDUtCheBox)
                if (chb.Checked)
                {
                    txbMaxDUt.Text = "10";
                    txbMaxDUt.Enabled = true;
                }
                else
                {
                    txbMaxDUt.Text = "*";
                    txbMaxDUt.Enabled = false;
                }
            if (chb == maxDStCheBox)
                if (chb.Checked)
                {
                    txbMaxDSt.Text = "50";
                    txbMaxDSt.Enabled = true;
                }
                else
                {
                    txbMaxDSt.Text = "*";
                    txbMaxDSt.Enabled = false;
                }
            if (chb == maxDSiCheBox)
                if (chb.Checked)
                {
                    txbMaxDSi.Text = "5";
                    txbMaxDSi.Enabled = true;
                }
                else
                {
                    txbMaxDSi.Text = "*";
                    txbMaxDSi.Enabled = false;
                }

        }
    }
}
