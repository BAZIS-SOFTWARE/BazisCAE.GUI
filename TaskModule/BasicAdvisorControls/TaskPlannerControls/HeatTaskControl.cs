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

        public override string CollectData()
        {
            var str = String.Format(CultureInfo.InvariantCulture,"{0};*;*;*;{1};{2};{3};{4};{5};{6};{7};{8}",
            txbDTtMax.Text, txbInitTemp.Text,  txbIters.Text, txbSaveRate.Text,
            cmbSolver.Text, txbSolverIterations.Text, txbPrecision.Text, txbRelaxation.Text, cmbPriority.Text);

            return str;
        }

        public override void InputData(string[] inputData)
        {
            txbDTtMax.Text = inputData[0];
            txbInitTemp.Text = inputData[4];
            txbIters.Text = inputData[5];
            txbSaveRate.Text = inputData[6];

            cmbSolver.Text = inputData[7];
            txbSolverIterations.Text = inputData[8];
            txbPrecision.Text = inputData[9];
            txbRelaxation.Text = inputData[10];
            cmbPriority.Text = inputData[11];
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
            if(sender is TextBox txb)
            {
                if (txb.Enabled == false)
                    txb.Text = "*";
            }
        }
    }
}
