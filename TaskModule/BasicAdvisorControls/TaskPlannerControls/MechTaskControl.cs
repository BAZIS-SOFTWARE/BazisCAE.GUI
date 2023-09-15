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

            if (chbUMax.Checked)
            {
                mechParameters.MechanicalConvergence.Is_Switched_Um = true;
                mechParameters.MechanicalConvergence.Um = Convert.ToSingle(txbMaxU.Text);
            }

            mechParameters.MechanicalConvergence.DUm = Convert.ToSingle(txbMaxDU.Text);
            mechParameters.MechanicalConvergence.SiStm = Convert.ToSingle(txbMaxSiSt.Text);

            mechParameters.Iterations = Convert.ToInt32(txbIters.Text);

            mechParameters.MechanicalConvergence.Is_Physically_NonLinear = true;
            mechParameters.MechanicalConvergence.MaterialPlasticityCoeff = 0.5f;

            mechParameters.MechanicalConvergence.PlasticityCriterion = Convert.ToSingle(txbMaxSiSt.Text);

            mechParameters.InitTemp = Convert.ToSingle(txbBodyTemp.Text);
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

            if (mechParameters.MechanicalConvergence.Is_Physically_NonLinear)
                chbPlastisity.Checked = true;

            if (mechParameters.MechanicalConvergence.Is_Switched_Um)
                chbUMax.Checked = true;

            txbMaxSiSt.Text = mechParameters.MechanicalConvergence.SiStm.ToString();

            txbMaxU.Text = mechParameters.MechanicalConvergence.Um.ToString();
            txbMaxDU.Text = mechParameters.MechanicalConvergence.DUm.ToString();
            txbIters.Text = mechParameters.Iterations.ToString();

            txbSaveRate.Text = mechParameters.SaveRate.ToString();
            txbBodyTemp.Text = mechParameters.InitTemp.ToString();

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

                var parameters = JsonConvert.DeserializeObject<MechanicalParameters>
    (File.ReadAllText(dialog.FileName), settingsSerializer);
                InputData(parameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbPlastisity_CheckedChanged(object sender, EventArgs e)
        {
            if(chbPlastisity.Checked)
            {
                chbUMax.Checked = true;
                chbUMax.Enabled = true;
                txbMaxDU.Enabled = true; 
                txbMaxSiSt.Enabled = true;
            }
            else
            {
                chbUMax.Checked = false;
                chbUMax.Enabled = false;
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
    }
}
