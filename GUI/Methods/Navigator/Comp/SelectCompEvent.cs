using BazisGUI.PropertiesPanel;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static IronPython.Modules._ast;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum SelectCompKeys { ApplyForAll }
        private void Navigator_SelectCompEvent(string arg2)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(arg2.Split(' ')[1]);
                bool isExe;
                 if (arg2.Split(' ')[2] == "выполнить")
                    isExe = true;
                else
                    isExe = false;
                List<RowProperty> rows = new List<RowProperty>();
                rows.Add(new RowProperty(CompPropertyKeys.Execute.ToString(), Properties.Resources.Header_comp_Execute, isExe));
                
                if (parameters is ChemicalParameters cmp)
                    rows.AddRange(GetPropertyChemicalTask(cmp));
                else if (parameters is MechanicalParameters mhp)
                    rows.AddRange(GetPropertyMechanicalTask(mhp));
                else if (parameters is TermalParameters tmp)
                    rows.AddRange(GetPropertyTermalTask(tmp));

                rows.AddRange(GetPropertySolverSettings(parameters));
                rows.AddRange(GetPropertyBasic(parameters));
                rows.AddRange(GetPropertyTimeSettings(parameters));
                rows.Add(new RowProperty(SelectCompKeys.ApplyForAll.ToString(), Properties.Resources.Header_comp_ApplyForAll, new ButtonPropertyValue(Properties.Resources.OK, () => ApplySettingsToAllInstructions())));
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private string selectInstruction = string.Empty;
        

        private List<RowProperty> GetPropertySolverSettings(GeneralParameters parameters) 
        {
            return new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.Algorithm.ToString(), Properties.Resources.Header_comp_Algorithm, 
                new DropDownPropertyValue(parameters.SolverSettings.Solver, 
                new List<string>() { "Gauss_direct", "SOR_iterative", "CG_iterative" })),

                new RowProperty(CompPropertyKeys.SolveIterations.ToString(), Properties.Resources.Header_comp_SolveIterations, parameters.SolverSettings.MaxIter),
                new RowProperty(CompPropertyKeys.SolveAccuracy.ToString(), Properties.Resources.Header_comp_SolveAccuracy, parameters.SolverSettings.Precision),
                new RowProperty(CompPropertyKeys.RelaxationCoef.ToString(), Properties.Resources.Header_comp_RelaxationCoef, parameters.SolverSettings.Relaxation),
                new RowProperty(CompPropertyKeys.MaxRelaxationCoef.ToString(), Properties.Resources.Header_comp_MaxRelaxationCoef, parameters.SolverSettings.MaxRelaxation),

                new RowProperty(CompPropertyKeys.Priority.ToString(), Properties.Resources.Header_comp_Priority, 
                new DropDownPropertyValue(parameters.SolverSettings.Priority,
                Enum.GetValues<PriorityKeys>().Select(x => x.ToString()).ToList()))            
            };
        }

        private List<RowProperty> GetPropertyBasic(GeneralParameters parameters)
        {
            return new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.IterationOnStep.ToString(), Properties.Resources.Header_comp_IterationsOnStep, parameters.Iterations),
                new RowProperty(CompPropertyKeys.SaveRate.ToString(), Properties.Resources.Header_comp_SaveRate, parameters.SaveRate),
                new RowProperty(
                    CompPropertyKeys.InitTemp.ToString(), 
                Properties.Resources.Header_comp_InitTemp,
                string.Join(",", parameters.InitTemp.Select(pair => $"{pair.Key} {pair.Value}")))
            };
        }

        private List<RowProperty> GetPropertyTimeSettings(GeneralParameters parameters)
        {
            return new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.StartTime.ToString(), Properties.Resources.Header_comp_StartTime, parameters.TimeSettings.StartTime),
                new RowProperty(CompPropertyKeys.StopTime.ToString(), Properties.Resources.Header_comp_StopTime, parameters.TimeSettings.StopTime),
                new RowProperty(CompPropertyKeys.InitialSolveStep.ToString(), Properties.Resources.Header_comp_InitialSolveStep, parameters.TimeSettings.InitTimeStep),
                new RowProperty(CompPropertyKeys.MinSolveStep.ToString(), Properties.Resources.Header_comp_MinSolveStep, parameters.TimeSettings.MinTimeStep),
                new RowProperty(CompPropertyKeys.MaxSolveStep.ToString(), Properties.Resources.Header_comp_MaxSolveStep, parameters.TimeSettings.MaxTimeStep)
            };
        }
    }
}
