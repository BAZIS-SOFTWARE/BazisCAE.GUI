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

        public override string CollectData()
        {
            var str = String.Format(CultureInfo.InvariantCulture,"{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",
                txbMaxDUt.Text, txbMaxDUi.Text, txbMaxDSt.Text, 
                txbMaxDSi.Text, txbInitTemp.Text,  txbIters.Text, txbSaveRate.Text,
                cmbSolver.Text, txbSolverIterations.Text, txbPrecision.Text, txbRelaxation.Text,cmbPriority.Text);

            return str;
        }

        public override void InputData(string[] inputData)
        {
            txbMaxDUt.Text = inputData[0];
            txbMaxDUi.Text = inputData[1];
            txbMaxDSt.Text = inputData[2];
            txbMaxDSi.Text = inputData[3];
            txbInitTemp.Text = inputData[4];
            txbIters.Text = inputData[5];
            txbSaveRate.Text = inputData[6];

            cmbPriority.Text = inputData[11];
            cmbSolver.Text = inputData[7];
            txbSolverIterations.Text = inputData[8];
            txbPrecision.Text = inputData[9];
            txbRelaxation.Text = inputData[10];
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
