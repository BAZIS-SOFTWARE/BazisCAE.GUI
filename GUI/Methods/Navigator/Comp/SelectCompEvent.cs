using BazisGUI.Navigator;
using BazisGUI.PropertiesPanel;
using BazisGUI.PropertiesPanel.PhysicalSets;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum SelectCompKeys { ApplyForAll }
        private void Navigator_SelectCompEvent(string arg2)
        {
            try
            {
                var path = GetInstructionPath(arg2, out var status);
                var parameters = ReadTaskParametersFromFile(path);
                var isExe = status == "выполнить";
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
                rows.AddRange(GetPropertyPhysicalSets(parameters, arg2, path));
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
            var solver = EnsureSolverSettings(parameters);

            return new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.Algorithm.ToString(), Properties.Resources.Header_comp_Algorithm,
                new DropDownPropertyValue(solver.Solver,
                Enum.GetNames<LinearSolverKind>().ToList())),

                new RowProperty(CompPropertyKeys.MatrixStorage.ToString(), Properties.Resources.Header_comp_MatrixStorage,
                new DropDownPropertyValue(solver.MatrixStorage,
                Enum.GetNames<MatrixStorageKind>().ToList())),

                new RowProperty(CompPropertyKeys.SolveIterations.ToString(), Properties.Resources.Header_comp_SolveIterations, solver.MaxIter),
                new RowProperty(CompPropertyKeys.SolveAccuracy.ToString(), Properties.Resources.Header_comp_SolveAccuracy, solver.Precision),
                new RowProperty(CompPropertyKeys.RelaxationCoef.ToString(), Properties.Resources.Header_comp_RelaxationCoef, solver.Relaxation),
                new RowProperty(CompPropertyKeys.MaxRelaxationCoef.ToString(), Properties.Resources.Header_comp_MaxRelaxationCoef, solver.MaxRelaxation),

                new RowProperty(CompPropertyKeys.Priority.ToString(), Properties.Resources.Header_comp_Priority,
                new DropDownPropertyValue(solver.Priority,
                Enum.GetValues<PriorityKeys>().Select(x => x.ToString()).ToList()))
            };
        }

        private List<RowProperty> GetPropertyBasic(GeneralParameters parameters)
        {
            return new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.IterationOnStep.ToString(), Properties.Resources.Header_comp_IterationsOnStep, parameters.Iterations),
                new RowProperty(CompPropertyKeys.SaveRate.ToString(), Properties.Resources.Header_comp_SaveRate, parameters.SaveRate)
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

        /// <summary>
        /// Строки физических наборов: родной набор задаёт начальное состояние, внешние
        /// приходят от других физических задач. Устройство наборов одинаково, поэтому
        /// строки для них строит один и тот же PhysicalSetRowBuilder, а состав наборов
        /// и величин знает PhysicalSetCatalog.
        /// </summary>
        private List<RowProperty> GetPropertyPhysicalSets(GeneralParameters parameters, string nodeText, string path)
        {
            var rows = new List<RowProperty>();
            var catalog = new PhysicalSetCatalog();
            var groups = catalog.GetGroups(parameters);

            // Начальное состояние продолжает расчёт той же физики, поэтому список
            // результатов для него ограничен задачами того же типа.
            var native = catalog.GetNativeSet(parameters);
            if (native != null)
            {
                var initialSet = parameters.InitialSet?.Name == native.Value ? parameters.InitialSet : null;
                var initialResults = GetInstructionResultNames(path, GetInstructionType(nodeText));

                rows.AddRange(new PhysicalSetRowBuilder(catalog, groups, initialResults)
                    .BuildInitial(native.Value, initialSet));
            }

            var inputBuilder = new PhysicalSetRowBuilder(catalog, groups, GetInstructionResultNames(path));
            var inputSets = catalog.GetInputSets(parameters);

            if (inputSets.Count > 0)
                rows.Add(inputBuilder.BuildForeignLabel());

            foreach (var name in inputSets)
                rows.AddRange(inputBuilder.BuildInput(name,
                    parameters.InputSets?.FirstOrDefault(set => set.Name == name)));

            return rows;
        }

        /// <summary>
        /// Имена файлов результатов, на которые можно сослаться.
        /// Файла ещё нет — он появится после решения задачи, — поэтому выбирается инструкция,
        /// а имя её результата выводится из имени файла инструкции: так же его формирует PreProc
        /// (см. PreProc.CreateFilesForSingleProcess, где .tsf и .db имеют общую основу имени).
        /// </summary>
        /// <param name="currentPath">Файл текущей инструкции. В список попадают только предыдущие инструкции.</param>
        /// <param name="taskType">Если указан, в список попадают только задачи того же типа.</param>
        private List<string> GetInstructionResultNames(string currentPath, string taskType = null)
        {
            var names = new List<string> { string.Empty };

            if (!navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> calculations))
                return names;

            foreach (TreeNode instruction in calculations[0].Nodes)
            {
                if (!instruction.Text.Contains(".tsf", StringComparison.OrdinalIgnoreCase))
                    continue;

                var path = GetInstructionPath(instruction.Text);
                if (string.Equals(path, currentPath, StringComparison.OrdinalIgnoreCase))
                    break;

                if (taskType != null && !string.Equals(
                    GetInstructionType(instruction.Text), taskType, StringComparison.OrdinalIgnoreCase))
                    continue;

                names.Add(Path.ChangeExtension(Path.GetFileName(path), ".db"));
            }

            return names;
        }

        private string GetInstructionType(string nodeText)
        {
            var separator = nodeText.IndexOf(' ');
            return separator < 0 ? nodeText : nodeText[..separator];
        }

    }
}
