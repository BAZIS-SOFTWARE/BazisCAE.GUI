using BazisGUI.Navigator;
using BazisGUI.PropertiesPanel;
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
                var taskType = GetInstructionType(arg2);
                var availableResults = GetInstructionResultNames(path);
                var availableInitialResults = GetInstructionResultNames(path, taskType);
                rows.AddRange(GetPropertyInitialState(parameters, availableInitialResults));
                rows.AddRange(GetPropertyInputFields(parameters, availableResults));
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
        /// Строки начального состояния: источник данных и зависящая от него строка ввода.
        /// Заменяют прежние GeneralParameters.InitTemp и ChemicalParameters.InitConcentration.
        /// </summary>
        private List<RowProperty> GetPropertyInitialState(GeneralParameters parameters, List<string> availableResults)
        {
            var state = EnsureInitialState(parameters);

            var rows = new List<RowProperty>
            {
                new RowProperty(CompPropertyKeys.InitialStateSource.ToString(),
                    Properties.Resources.Header_comp_InitialStateSource,
                    new DropDownPropertyValue(SourceName(state.Source == InitialStateSource.Result), SourceNames()))
            };

            if (state.Source == InitialStateSource.Result)
            {
                rows.Add(new RowProperty(CompPropertyKeys.InitialStateFile.ToString(),
                    Indent(Properties.Resources.Header_comp_FileName),
                    ResultValue(state.Result?.FileName, availableResults)));

                return rows;
            }

            // Значения задаются по группам модели, а имена групп приходят из файла:
            // их формирует PreProc по условиям материала, поэтому строки строятся по факту.
            var conditions = GetInitialConditionsToShow(parameters);

            foreach (var condition in conditions)
                rows.Add(new RowProperty(
                    ComposeFieldKey(CompPropertyKeys.InitialStateValue, condition.Field),
                    Indent(conditions.Count > 1
                        ? $"{Properties.Resources.Header_comp_Value} — {InputFieldHeader(condition.Field)}"
                        : Properties.Resources.Header_comp_Value),
                    FormatInitialValues(parameters, condition.Field)));

            return rows;
        }

        private List<InitialCondition> GetInitialConditionsToShow(GeneralParameters parameters)
        {
            var conditions = parameters.InitialState?.Conditions?.ToList()
                ?? new List<InitialCondition>();

            if (conditions.Count != 0)
                return conditions;

            if (parameters is TermalParameters)
                conditions.Add(new InitialCondition { Field = PhysicalField.Temperature });
            else if (parameters is ChemicalParameters)
                conditions.Add(new InitialCondition { Field = PhysicalField.Concentration });

            return conditions;
        }

        /// <summary>
        /// Строки входных полей (InputFields): флажок на каждое физическое поле, а под
        /// включённым — источник данных и зависящая от него строка ввода.
        /// Заменяют прежние ThermalLoad / ThermalFile механической и химической задачи
        /// и ConvectionParameters тепловой.
        /// </summary>
        private List<RowProperty> GetPropertyInputFields(GeneralParameters parameters, List<string> availableResults)
        {
            var rows = new List<RowProperty>();

            foreach (var field in InputFieldsToShow(parameters))
            {
                var input = FindInputField(parameters, field);

                rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputEnabled, field),
                    InputFieldHeader(field), input != null));

                if (input == null)
                    continue;

                rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputSource, field),
                    Indent(Properties.Resources.Header_comp_InputSource),
                    new DropDownPropertyValue(SourceName(input.Source == InputFieldSource.ResultFile), SourceNames())));

                if (input.Source == InputFieldSource.Constant)
                    rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputConstant, field),
                        Indent(Properties.Resources.Header_comp_Value),
                        FormatComponents(input.ConstantValues)));
                else
                    rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputFile, field),
                        Indent(Properties.Resources.Header_comp_FileName),
                        ResultValue(input.FileName, availableResults)));
            }

            return rows;
        }

        /// <summary>
        /// Физические поля, для которых показываются флажки: температура, концентрация,
        /// скорость и всё, что уже есть в файле, чтобы ничего не пропало из виду.
        /// </summary>
        private List<PhysicalField> InputFieldsToShow(GeneralParameters parameters)
        {
            var fields = new List<PhysicalField>
            {
                PhysicalField.Temperature,
                PhysicalField.Concentration,
                PhysicalField.Velocity
            };

            foreach (var field in parameters.InputFields?.Select(input => input.Field) ?? Enumerable.Empty<PhysicalField>())
                if (!fields.Contains(field))
                    fields.Add(field);

            return fields;
        }

        private string InputFieldHeader(PhysicalField field)
        {
            switch (field)
            {
                case PhysicalField.Temperature: return Properties.Resources.Header_comp_FieldTemperature;
                case PhysicalField.Concentration: return Properties.Resources.Header_comp_FieldConcentration;
                case PhysicalField.Velocity: return Properties.Resources.Header_comp_FieldVelocity;
                default: return field.ToString();
            }
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

        /// <summary>
        /// Ячейка выбора результата. Сохранённая ссылка могла остаться от инструкции,
        /// которой больше нет, — тогда она добавляется в список, иначе он её потеряет.
        /// </summary>
        private DropDownPropertyValue ResultValue(string current, List<string> availableResults)
        {
            var values = new List<string>(availableResults);

            if (!string.IsNullOrEmpty(current) && !values.Contains(current))
                values.Add(current);

            return new DropDownPropertyValue(current ?? string.Empty, values);
        }

        /// <summary>
        /// Отступ строки настройки, подчинённой строке выше: источник данных и зависящая
        /// от него строка «Значение» либо «Имя файла».
        /// </summary>
        private string Indent(string header) => "   " + header;

        /// <summary>Локализованные значения выпадающего списка источника данных.</summary>
        private List<string> SourceNames() => new List<string>
        {
            Properties.Resources.Header_comp_SourceConstant,
            Properties.Resources.Header_comp_SourceFile
        };

        private string SourceName(bool isFile) => isFile
            ? Properties.Resources.Header_comp_SourceFile
            : Properties.Resources.Header_comp_SourceConstant;
    }
}
