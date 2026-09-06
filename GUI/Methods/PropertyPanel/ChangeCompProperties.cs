using BazisGUI.Navigator;
using Newtonsoft.Json;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace BazisGUI
{
    public partial class BaseForm
    {
        enum CompPropertyKeys
        {
            Type,
            Execute,
            Algorithm,
            MatrixStorage,
            SolveIterations,
            SolveAccuracy,
            RelaxationCoef,
            MaxRelaxationCoef,
            Priority,
            IterationOnStep,
            SaveRate,
            StartTime,
            StopTime,
            InitialSolveStep,
            MinSolveStep,
            MaxSolveStep,
            InitialStateSource,
            InitialStateValue,
            InitialStateFile,
            InputEnabled,
            InputSource,
            InputValue,
            InputFile
        }

        /// <summary>Разделитель частей ключа строки: «InputSource:Thermal».</summary>
        private readonly char FieldKeySeparator = ':';

        private string ComposeFieldKey(CompPropertyKeys key, PhysicalFieldSet fieldSet) =>
            $"{key}{FieldKeySeparator}{fieldSet}";

        private string ComposeQuantityKey(CompPropertyKeys key, PhysicalFieldSet fieldSet, PhysicalQuantity quantity) =>
            $"{key}{FieldKeySeparator}{fieldSet}{FieldKeySeparator}{quantity}";
        enum PriorityKeys { Низкий, НижеСреднего, Средний, ВышеСреднего, Высокий, Наивысший }

        private void ChangeCompProperties(PropertiesPanel.PropertyChangedEventArgs obj, string nodeText)
        {
            var parameters = ReadTaskParametersFromFile(GetInstructionPath(nodeText));
            if (parameters is ChemicalParameters cmp) 
                ChangeChemicalTask(obj, cmp);
            else if (parameters is MechanicalParameters mhp) 
                ChangeMechanicalTask(obj, mhp);
            else if (parameters is TermalParameters tmp)
                ChangeTermalTask(obj, tmp);

            // Ключи строк несут набор полей и, при вводе значений, физическую величину.
            var rowKey = SplitFieldKey(obj.Key, out var fieldSet, out var quantity);

            if (Enum.TryParse(rowKey, out CompPropertyKeys key))
            {
                switch (key)
                {
                    case CompPropertyKeys.Execute:
                        // TODO: проверить корректность работы с данными при их смене
                        var isExe = bool.Parse(obj.NewValue);
                        var selectedInstruction = navigator.SelectedNode;
                        if (isExe)
                            selectedInstruction.Text = selectedInstruction.Text.Replace("пропустить", "выполнить");
                        else
                            selectedInstruction.Text = selectedInstruction.Text.Replace("выполнить", "пропустить");

                        nodeText = selectedInstruction.Text;
                        break;
                    // Solver и MatrixStorage доступны только на чтение — настройки пересоздаются.
                    case CompPropertyKeys.Algorithm:
                        ReplaceSolverSettings(parameters,
                            Enum.Parse<LinearSolverKind>(obj.NewValue),
                            EnsureSolverSettings(parameters).MatrixStorage);
                        break;
                    case CompPropertyKeys.MatrixStorage:
                        ReplaceSolverSettings(parameters,
                            EnsureSolverSettings(parameters).Solver,
                            Enum.Parse<MatrixStorageKind>(obj.NewValue));
                        break;
                    case CompPropertyKeys.SolveIterations:
                        EnsureSolverSettings(parameters).MaxIter = int.Parse(obj.NewValue);
                        break;
                    case CompPropertyKeys.SolveAccuracy:
                        EnsureSolverSettings(parameters).Precision = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.RelaxationCoef:
                        EnsureSolverSettings(parameters).Relaxation = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.MaxRelaxationCoef:
                        EnsureSolverSettings(parameters).MaxRelaxation = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.Priority:
                        EnsureSolverSettings(parameters).Priority = obj.NewValue;
                        break;
                    case CompPropertyKeys.IterationOnStep:
                        parameters.Iterations = int.Parse(obj.NewValue);
                        break;
                    case CompPropertyKeys.SaveRate:
                        parameters.SaveRate = int.Parse(obj.NewValue);
                        break;
                    case CompPropertyKeys.StartTime:
                        parameters.TimeSettings.StartTime = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.StopTime:
                        parameters.TimeSettings.StopTime = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.InitialSolveStep:
                        parameters.TimeSettings.InitTimeStep = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.MinSolveStep:
                        parameters.TimeSettings.MinTimeStep = ParseFloatValue(obj.NewValue);
                        break;
                    case CompPropertyKeys.MaxSolveStep:
                        parameters.TimeSettings.MaxTimeStep = ParseFloatValue(obj.NewValue);
                        break;

                    case CompPropertyKeys.InitialStateSource:
                        SetFieldSource(EnsureInitialField(parameters, fieldSet),
                            IsFileSource(obj.NewValue) ? PhysicalFieldSource.ResultFile : PhysicalFieldSource.Values);
                        break;
                    case CompPropertyKeys.InitialStateValue:
                        ApplyFieldValues(EnsureInitialField(parameters, fieldSet), quantity, obj.NewValue);
                        break;
                    case CompPropertyKeys.InitialStateFile:
                        // Core хранит имя файла результата или шаблон поиска, каталог не хранится.
                        EnsureInitialField(parameters, fieldSet).FileName = Path.GetFileName(obj.NewValue);
                        break;

                    case CompPropertyKeys.InputEnabled:
                        SetInputFieldEnabled(parameters, fieldSet, bool.Parse(obj.NewValue));
                        break;
                    case CompPropertyKeys.InputSource:
                        SetFieldSource(EnsureInputField(parameters, fieldSet),
                            IsFileSource(obj.NewValue) ? PhysicalFieldSource.ResultFile : PhysicalFieldSource.Values);
                        break;
                    case CompPropertyKeys.InputValue:
                        ApplyFieldValues(EnsureInputField(parameters, fieldSet), quantity, obj.NewValue);
                        break;
                    case CompPropertyKeys.InputFile:
                        EnsureInputField(parameters, fieldSet).FileName = Path.GetFileName(obj.NewValue);
                        break;
                }
            }

            SaveGeneralParametersToFile(parameters, nodeText);

            // перерисовывает панель свойств, если изменился параметр, от которого зависит
            // состав строк или показанное значение отличается от введённого.
            // Отложенно, потому что метод вызывается из обработчика изменения ячейки DataGridView.
            if (NeedsRedraw(rowKey))
                BeginInvoke(new Action(() => Navigator_SelectCompEvent(nodeText)));
        }

        /// <summary>
        /// Отделяет от ключа строки набор и физическую величину, если они в нём закодированы.
        /// </summary>
        private string SplitFieldKey(string key, out PhysicalFieldSet fieldSet, out PhysicalQuantity quantity)
        {
            fieldSet = default;
            quantity = default;

            var parts = key?.Split(FieldKeySeparator) ?? Array.Empty<string>();
            if (parts.Length < 2)
                return key;

            Enum.TryParse(parts[1], out fieldSet);
            if (parts.Length > 2)
                Enum.TryParse(parts[2], out quantity);

            return parts[0];
        }

        /// <summary>Выбран ли в списке источника данных файл, а не константа.</summary>
        private bool IsFileSource(string value) =>
            value == Properties.Resources.Header_comp_SourceFile;

        /// <summary>Нужно ли перестроить строки панели после изменения параметра.</summary>
        private bool NeedsRedraw(string key)
        {
            return key == CompPropertyKeys.InputEnabled.ToString()
                || key == CompPropertyKeys.InputSource.ToString()
                || key == CompPropertyKeys.InitialStateSource.ToString()
                || key == TermalTaskPropertyKeys.MaxTemperture.ToString()
                || key == MechanicalPropertyKeys.MaxMove.ToString()
                || key == MechanicalPropertyKeys.PlasticDeformation.ToString()
                || key == ChemicalTaskPropertyKeys.MaxConсentration.ToString();
        }

        private void ChangeCompProperties(PropertiesPanel.PropertyChangedEventArgs obj)
        {
            if (Enum.TryParse(obj.Key, out CompPropertyKeys key))
            {
                if (key == CompPropertyKeys.Type)
                    selectInstruction = obj.NewValue;
                else if (key == CompPropertyKeys.Execute)
                {
                    // obj.LocalizedHeader.Contains("Выполнять")
                    var name = obj.LocalizedHeader.Split(' ')[1];
                    navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);
                    var selectedInstruction = task[0].Nodes.Cast<TreeNode>().FirstOrDefault(inst => inst.Text.Contains(name));

                    var isExe = bool.Parse(obj.NewValue);
                    if (isExe)
                        selectedInstruction.Text = selectedInstruction.Text.Replace("пропустить", "выполнить");
                    else
                        selectedInstruction.Text = selectedInstruction.Text.Replace("выполнить", "пропустить");
                }
                Navigator_SelectCompsEvent();
            }
        }

        [Obsolete ("Отсутствует химические задачи, не протестировано")]
        private void ChangeChemicalTask(PropertiesPanel.PropertyChangedEventArgs obj, ChemicalParameters cmp)
        {
            if (Enum.TryParse(obj.Key, out ChemicalTaskPropertyKeys key))
            {
                switch (key)
                {
                    case ChemicalTaskPropertyKeys.MaxConсentration:
                        cmp.ChemicalConvergence.Is_Switched_Cm = bool.Parse(obj.NewValue);
                        break;
                    case ChemicalTaskPropertyKeys.MaxConсentrationValue:
                        cmp.ChemicalConvergence.Cm = ParseFloatValue(obj.NewValue);
                        break;
                        // Начальная концентрация задаётся через блок начального состояния.
                }
            }
        }

        private void ChangeTermalTask(PropertiesPanel.PropertyChangedEventArgs obj, TermalParameters tmp)
        {
            if (Enum.TryParse(obj.Key, out TermalTaskPropertyKeys key))
            {
                switch (key)
                {
                    case TermalTaskPropertyKeys.MaxTemperture:
                        tmp.TermalConvergence.Is_Switched_Tm = bool.Parse(obj.NewValue);
                        break;
                    case TermalTaskPropertyKeys.MaxTempertureValue:
                        tmp.TermalConvergence.Tm = ParseFloatValue(obj.NewValue);
                        break;
                }
            }
        }

        private void ChangeMechanicalTask(PropertiesPanel.PropertyChangedEventArgs obj, MechanicalParameters mhp)
        {
            if (Enum.TryParse(obj.Key, out MechanicalPropertyKeys key))
            {
                switch (key)
                {
                    case MechanicalPropertyKeys.MaxDiference:
                        mhp.MechanicalConvergence.DUm = ConvertToNumber<float>(obj.NewValue);
                        break;

                    case MechanicalPropertyKeys.MaxMove:
                        mhp.MechanicalConvergence.Is_Switched_Um = bool.Parse(obj.NewValue);
                        break;

                    case MechanicalPropertyKeys.MaxMoveValue:
                        mhp.MechanicalConvergence.Um = ConvertToNumber<float>(obj.NewValue);
                        break;

                    case MechanicalPropertyKeys.PlasticDeformation:
                        mhp.MechanicalConvergence.Is_Physically_NonLinear = bool.Parse(obj.NewValue);
                        break;

                    case MechanicalPropertyKeys.PlasticDeformationValue:
                        mhp.MechanicalConvergence.PlasticityCriterion = ConvertToNumber<float>(obj.NewValue);
                        break;
                }
            }
        }

        private void ApplySettingsToAllInstructions()
        {
            try
            {
                var selectedNode = navigator.SelectedNode;
                var compType = GetInstructionType(selectedNode.Text);
                var sample = ReadTaskParametersFromFile(GetInstructionPath(selectedNode.Text));

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add(item.Text);

                foreach (var taskName in tasks)
                    if (GetInstructionType(taskName) == compType)
                    {
                        var temp = ReadTaskParametersFromFile(GetInstructionPath(taskName));

                        if(temp is TermalParameters term)
                        {
                            var _sample = sample as TermalParameters;
                            term.TermalConvergence.Is_Switched_Tm = _sample.TermalConvergence.Is_Switched_Tm;
                            term.TermalConvergence.Tm = _sample.TermalConvergence.Tm;
                        }
                        else if (temp is MechanicalParameters mech)
                        {
                            var _sample = sample as MechanicalParameters;
                            mech.MechanicalConvergence.DUm = _sample.MechanicalConvergence.DUm;
                            mech.MechanicalConvergence.Is_Physically_NonLinear = _sample.MechanicalConvergence.Is_Physically_NonLinear;
                            mech.MechanicalConvergence.Is_Switched_Um = _sample.MechanicalConvergence.Is_Switched_Um;
                            mech.MechanicalConvergence.MaterialPlasticityCoeff = _sample.MechanicalConvergence.MaterialPlasticityCoeff;
                            mech.MechanicalConvergence.Um = _sample.MechanicalConvergence.Um;
                            mech.MechanicalConvergence.PlasticityCriterion = _sample.MechanicalConvergence.PlasticityCriterion;
                            mech.MechanicalConvergence.SiStm = _sample.MechanicalConvergence.SiStm;
                        }

                        if (temp is TermalParameters termTarget && sample is TermalParameters termSample)
                            termTarget.MetallurgicalProcesses = termSample.MetallurgicalProcesses;

                        // Начальное состояние не переносится: PreProc задаёт его отдельно
                        // для каждой инструкции цепочки (файл рестарта предыдущей задачи).
                        temp.Iterations = sample.Iterations;
                        temp.SaveRate = sample.SaveRate;
                        temp.SolverSettings = EnsureSolverSettings(sample);
                        temp.TimeSettings.InitTimeStep = sample.TimeSettings.InitTimeStep;
                        temp.TimeSettings.MinTimeStep = sample.TimeSettings.MinTimeStep;
                        temp.TimeSettings.MaxTimeStep = sample.TimeSettings.MaxTimeStep;
                        SaveGeneralParametersToFile(temp, taskName);
                    }
                        // TODO
                       
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SaveGeneralParametersToFile(GeneralParameters parameters, string nodeText)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);
            File.WriteAllText(GetInstructionPath(nodeText), parLine);
        }

        /// <summary>
        /// Путь к файлу инструкции из текста узла дерева «тип путь статус».
        /// Путь может содержать пробелы, поэтому его границей служит расширение файла,
        /// а не разбиение по пробелам.
        /// </summary>
        private string GetInstructionPath(string nodeText) => GetInstructionPath(nodeText, out _);

        /// <inheritdoc cref="GetInstructionPath(string)"/>
        /// <param name="status">Признак выполнения инструкции, идущий после пути.</param>
        private string GetInstructionPath(string nodeText, out string status)
        {
            const string extension = ".tsf";

            var start = nodeText.IndexOf(' ') + 1;
            var end = nodeText.LastIndexOf(extension, StringComparison.OrdinalIgnoreCase);
            if (start <= 0 || end < start)
                throw new ArgumentException($"Не удалось определить путь к файлу инструкции: «{nodeText}».");

            end += extension.Length;
            status = nodeText[end..].Trim();
            return nodeText[start..end].Trim();
        }

        /// <summary>Возвращает внешний набор полей, не изменяя модель.</summary>
        private PhysicalField FindInputField(GeneralParameters parameters, PhysicalFieldSet fieldSet) =>
            FindField(parameters.InputFields, fieldSet);

        /// <summary>Возвращает родной начальный набор полей, не изменяя модель.</summary>
        private PhysicalField FindInitialField(GeneralParameters parameters, PhysicalFieldSet fieldSet) =>
            FindField(parameters.InitialFields, fieldSet);

        /// <summary>Возвращает набор полей по его виду.</summary>
        private PhysicalField FindField(IEnumerable<PhysicalField> fields, PhysicalFieldSet fieldSet)
        {
            return fields?.FirstOrDefault(field => field.FieldSet == fieldSet);
        }

        /// <summary>Создаёт внешний набор полей, если он ещё не задан.</summary>
        private PhysicalField EnsureInputField(GeneralParameters parameters, PhysicalFieldSet fieldSet)
        {
            parameters.InputFields ??= new List<PhysicalField>();
            return EnsureField(parameters.InputFields, fieldSet);
        }

        /// <summary>Создаёт родной начальный набор полей, если он ещё не задан.</summary>
        private PhysicalField EnsureInitialField(GeneralParameters parameters, PhysicalFieldSet fieldSet)
        {
            parameters.InitialFields ??= new List<PhysicalField>();
            return EnsureField(parameters.InitialFields, fieldSet);
        }

        /// <summary>Возвращает единственный набор полей указанного вида.</summary>
        private PhysicalField EnsureField(List<PhysicalField> fields, PhysicalFieldSet fieldSet)
        {
            var field = FindField(fields, fieldSet);
            if (field == null)
            {
                field = new PhysicalField { FieldSet = fieldSet };
                fields.Add(field);
                return field;
            }

            fields.RemoveAll(existing => existing != field && existing.FieldSet == fieldSet);
            return field;
        }

        /// <summary>Включает или выключает внешний набор полей.</summary>
        private void SetInputFieldEnabled(GeneralParameters parameters, PhysicalFieldSet fieldSet, bool enabled)
        {
            if (enabled)
            {
                EnsureInputField(parameters, fieldSet);
                return;
            }

            parameters.InputFields?.RemoveAll(field => field.FieldSet == fieldSet);
        }

        /// <summary>Переключает источник набора, очищая неактуальные данные.</summary>
        private void SetFieldSource(PhysicalField field, PhysicalFieldSource source)
        {
            field.Source = source;

            if (source == PhysicalFieldSource.Values)
                field.FileName = "";
            else
                field.Values.Clear();
        }

        private SolverSettings EnsureSolverSettings(GeneralParameters parameters)
        {
            return parameters.SolverSettings ??=
                new SolverSettings(LinearSolverKind.ConjugateGradient, MatrixStorageKind.SymmetricCsr);
        }

        /// <summary>Пересоздаёт настройки решателя с переносом остальных значений.</summary>
        private void ReplaceSolverSettings(GeneralParameters parameters, LinearSolverKind solver, MatrixStorageKind matrixStorage)
        {
            var previous = EnsureSolverSettings(parameters);

            parameters.SolverSettings = new SolverSettings(solver, matrixStorage)
            {
                MaxIter = previous.MaxIter,
                MaxRelaxation = previous.MaxRelaxation,
                Relaxation = previous.Relaxation,
                Precision = previous.Precision,
                Priority = previous.Priority
            };
        }

        /// <summary>Возвращает родной набор полей текущей физической задачи.</summary>
        private PhysicalFieldSet GetNativeFieldSet(GeneralParameters parameters)
        {
            return parameters switch
            {
                TermalParameters => PhysicalFieldSet.Thermal,
                MechanicalParameters => PhysicalFieldSet.Mechanical,
                ChemicalParameters => PhysicalFieldSet.Chemical,
                _ => throw new ArgumentOutOfRangeException(nameof(parameters), "The task does not have a native field set.")
            };
        }

        /// <summary>Формирует строку значений одной физической величины по группам.</summary>
        private string FormatFieldValues(PhysicalField field, PhysicalQuantity quantity)
        {
            if (field?.Values == null)
                return string.Empty;

            var values = new List<string>();
            foreach (var pair in field.Values)
            {
                var fieldValue = pair.Value?.FirstOrDefault(value => value.Quantity == quantity);
                if (fieldValue != null)
                    values.Add($"{pair.Key} {FormatComponents(fieldValue.Components)}");
            }

            return string.Join(",", values);
        }

        /// <summary>Записывает значения одной физической величины по группам.</summary>
        private void ApplyFieldValues(PhysicalField field, PhysicalQuantity quantity, string newValue)
        {
            SetFieldSource(field, PhysicalFieldSource.Values);
            field.Values ??= new Dictionary<string, List<PhysicalFieldValue>>();

            var pairs = newValue
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(pair => pair.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                .ToList();

            // Запятая разделяет группы, поэтому десятичный разделитель здесь только точка.
            // Без проверки «Металл 21,5» молча создало бы группу «5».
            if (pairs.Any(pair => pair.Length != 2))
                throw new ArgumentException(
                    "Expected 'group value,group value'. The decimal separator must be a dot.");

            foreach (var values in field.Values.Values)
                values?.RemoveAll(value => value.Quantity == quantity);

            var emptyGroups = field.Values
                .Where(pair => pair.Value == null || pair.Value.Count == 0)
                .Select(pair => pair.Key)
                .ToList();
            foreach (var groupName in emptyGroups)
                field.Values.Remove(groupName);

            foreach (var pair in pairs)
            {
                if (!field.Values.TryGetValue(pair[0], out var values))
                {
                    values = new List<PhysicalFieldValue>();
                    field.Values.Add(pair[0], values);
                }

                values.Add(new PhysicalFieldValue
                {
                    Quantity = quantity,
                    Components = ParseComponents(pair[1])
                });
            }
        }

        /// <summary>
        /// Компоненты значения через «;» — запятая занята под десятичный разделитель
        /// (см. ParseFloatValue) и под разделитель групп начального состояния.
        /// </summary>
        private string FormatComponents(double[] values)
        {
            if (values == null || values.Length == 0)
                return string.Empty;

            return string.Join("; ", values.Select(x => x.ToString(CultureInfo.InvariantCulture)));
        }

        private double[] ParseComponents(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Array.Empty<double>();

            return value.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => double.Parse(x.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture)).ToArray();
        }

        [Obsolete("Стараться использовать дженерик метод ConvertToNumber")]
        private float ParseFloatValue(string value) => float.Parse(value.Trim().Replace(',', '.'));

        public T ConvertToNumber<T>(string input)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));// Получаем конвертер для нужного типа
            if (converter != null && converter.IsValid(input))
                return (T)converter.ConvertFromString(input);// Конвертируем строку и приводим к типу T
            throw new ArgumentException($"Невозможно преобразовать строку '{input}' в тип {typeof(T)}.");// Выбрасываем ошибку, если строка не подходит для конвертации
        }
    }
}
