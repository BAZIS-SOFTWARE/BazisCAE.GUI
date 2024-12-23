using PreProc;
using PreProc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.TasksControls
{
    public partial class SolverSettingsControl : UserControl
    {
        public SolverSettingsControl()
        {
            InitializeComponent();
        }

        public bool GetValidationResult()
        {
            var checks = new List<bool>()
            {
                cmbPriority.IsValueValid(),
                cmbSolver.IsValueValid(),
                txbPrecision.IsValueValid(),
                txbRelaxation.IsValueValid(),
                txbSolverIterations.IsValueValid()
            };
            return checks.All(x => x);
        }

        internal SolverSettings GetSolverSettings()
        {
            return new SolverSettings()
            {
                Solver = cmbSolver.Text,
                MaxIter = Convert.ToInt32(txbSolverIterations.Text),
                Precision = Convert.ToSingle(txbPrecision.Text),
                Relaxation = Convert.ToSingle(txbRelaxation.Text),
                Priority = cmbPriority.Text
            };
      
        }

        internal void SetSolverSettings(ISolverSettings solverSettings)
        {
            txbPrecision.Text = solverSettings.Precision.ToString();
            txbRelaxation.Text = solverSettings.Relaxation.ToString();
            txbSolverIterations.Text = solverSettings.MaxIter.ToString();
            cmbPriority.Text = solverSettings.Priority;
            cmbSolver.Text = solverSettings.Solver;
        }
    }
}
