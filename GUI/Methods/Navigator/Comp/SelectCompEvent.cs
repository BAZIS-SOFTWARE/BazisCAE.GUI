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
        /// Строки родного начального набора полей: источник данных и значения по группам.
        /// </summary>
        private List<RowProperty> GetPropertyInitialState(GeneralParameters parameters, List<string> availableResults)
        {
            var fieldSet = GetNativeFieldSet(parameters);
            var field = FindInitialField(parameters, fieldSet);
            var source = field?.Source ?? PhysicalFieldSource.Values;

            var rows = new List<RowProperty>
            {
                new RowProperty(ComposeFieldKey(CompPropertyKeys.InitialStateSource, fieldSet),
                    Properties.Resources.Header_comp_InitialStateSource,
                    new DropDownPropertyValue(SourceName(source == PhysicalFieldSource.ResultFile), SourceNames()))
            };

            if (source == PhysicalFieldSource.ResultFile)
            {
                rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InitialStateFile, fieldSet),
                    Indent(Properties.Resources.Header_comp_FileName),
                    ResultValue(field?.FileName, availableResults)));

                return rows;
            }

            var quantities = PhysicalQuantitiesToShow(fieldSet, field);
            foreach (var quantity in quantities)
                rows.Add(new RowProperty(
                    ComposeQuantityKey(CompPropertyKeys.InitialStateValue, fieldSet, quantity),
                    Indent(quantities.Count > 1
                        ? $"{Properties.Resources.Header_comp_Value} — {PhysicalQuantityHeader(quantity)}"
                        : Properties.Resources.Header_comp_Value),
                    FormatFieldValues(field, quantity)));

            return rows;
        }

        /// <summary>
        /// Строки внешних наборов полей: флажок, источник и значения по группам.
        /// </summary>
        private List<RowProperty> GetPropertyInputFields(GeneralParameters parameters, List<string> availableResults)
        {
            var rows = new List<RowProperty>();

            foreach (var fieldSet in InputFieldSetsToShow(parameters))
            {
                var field = FindInputField(parameters, fieldSet);

                rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputEnabled, fieldSet),
                    PhysicalFieldSetHeader(fieldSet), field != null));

                if (field == null)
                    continue;

                rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputSource, fieldSet),
                    Indent(Properties.Resources.Header_comp_InputSource),
                    new DropDownPropertyValue(SourceName(field.Source == PhysicalFieldSource.ResultFile), SourceNames())));

                if (field.Source == PhysicalFieldSource.Values)
                {
                    var quantities = PhysicalQuantitiesToShow(fieldSet, field);
                    foreach (var quantity in quantities)
                        rows.Add(new RowProperty(
                            ComposeQuantityKey(CompPropertyKeys.InputValue, fieldSet, quantity),
                            Indent(quantities.Count > 1
                                ? $"{Properties.Resources.Header_comp_Value} — {PhysicalQuantityHeader(quantity)}"
                                : Properties.Resources.Header_comp_Value),
                            FormatFieldValues(field, quantity)));
                }
                else
                    rows.Add(new RowProperty(ComposeFieldKey(CompPropertyKeys.InputFile, fieldSet),
                        Indent(Properties.Resources.Header_comp_FileName),
                        ResultValue(field.FileName, availableResults)));
            }

            return rows;
        }

        /// <summary>
        /// Наборы, которые задача способна получить от других физических задач.
        /// Уже сохранённые наборы также отображаются, чтобы настройки не терялись.
        /// </summary>
        private List<PhysicalFieldSet> InputFieldSetsToShow(GeneralParameters parameters)
        {
            var fieldSets = parameters switch
            {
                TermalParameters => new List<PhysicalFieldSet>
                {
                    PhysicalFieldSet.Chemical,
                    PhysicalFieldSet.Hydrodynamic
                },
                MechanicalParameters => new List<PhysicalFieldSet>
                {
                    PhysicalFieldSet.Thermal,
                    PhysicalFieldSet.Chemical,
                    PhysicalFieldSet.Hydrodynamic
                },
                ChemicalParameters => new List<PhysicalFieldSet>
                {
                    PhysicalFieldSet.Thermal
                },
                _ => new List<PhysicalFieldSet>()
            };

            foreach (var field in parameters.InputFields ?? Enumerable.Empty<PhysicalField>())
                if (!fieldSets.Contains(field.FieldSet))
                    fieldSets.Add(field.FieldSet);

            return fieldSets;
        }

        /// <summary>Возвращает заголовок набора физических полей.</summary>
        private string PhysicalFieldSetHeader(PhysicalFieldSet fieldSet)
        {
            return fieldSet switch
            {
                PhysicalFieldSet.Thermal => "Термический",
                PhysicalFieldSet.Mechanical => "Механический",
                PhysicalFieldSet.Chemical => "Химический",
                PhysicalFieldSet.Hydrodynamic => "Гидродинамический",
                _ => fieldSet.ToString()
            };
        }

        /// <summary>Возвращает заголовок физической величины.</summary>
        private string PhysicalQuantityHeader(PhysicalQuantity quantity)
        {
            return quantity switch
            {
                PhysicalQuantity.Temperature => Properties.Resources.Header_comp_FieldTemperature,
                PhysicalQuantity.Concentration => Properties.Resources.Header_comp_FieldConcentration,
                PhysicalQuantity.Velocity => Properties.Resources.Header_comp_FieldVelocity,
                PhysicalQuantity.PhaseComposition => "Фазовый состав",
                PhysicalQuantity.Displacement => "Перемещение",
                PhysicalQuantity.Pressure => "Давление",
                PhysicalQuantity.Stress => "Напряжение",
                PhysicalQuantity.Strain => "Деформация",
                _ => quantity.ToString()
            };
        }

        /// <summary>Возвращает величины, относящиеся к набору полей.</summary>
        private List<PhysicalQuantity> PhysicalQuantitiesToShow(PhysicalFieldSet fieldSet, PhysicalField field)
        {
            var quantities = fieldSet switch
            {
                PhysicalFieldSet.Thermal => new List<PhysicalQuantity>
                {
                    PhysicalQuantity.Temperature,
                    PhysicalQuantity.PhaseComposition
                },
                PhysicalFieldSet.Mechanical => new List<PhysicalQuantity>
                {
                    PhysicalQuantity.Temperature,
                    PhysicalQuantity.PhaseComposition,
                    PhysicalQuantity.Displacement,
                    PhysicalQuantity.Stress,
                    PhysicalQuantity.Strain
                },
                PhysicalFieldSet.Chemical => new List<PhysicalQuantity>
                {
                    PhysicalQuantity.Concentration,
                    PhysicalQuantity.Temperature
                },
                PhysicalFieldSet.Hydrodynamic => new List<PhysicalQuantity>
                {
                    PhysicalQuantity.Velocity,
                    PhysicalQuantity.Pressure,
                    PhysicalQuantity.Temperature
                },
                _ => new List<PhysicalQuantity>()
            };

            if (field?.Values == null)
                return quantities;

            foreach (var values in field.Values.Values)
                foreach (var value in values ?? Enumerable.Empty<PhysicalFieldValue>())
                    if (!quantities.Contains(value.Quantity))
                        quantities.Add(value.Quantity);

            return quantities;
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
