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
        enum CompPropertyKeys { Type, Execute, Algorithm, MatrixStorage, SolveIterations, SolveAccuracy, RelaxationCoef, MaxRelaxationCoef, Priority, IterationOnStep, SaveRate, StartTime, StopTime, InitialSolveStep, MinSolveStep, MaxSolveStep, InitialStateSource, InitialStateValue, InitialStateFile, InputEnabled, InputSource, InputConstant, InputFile }

        /// <summary>Разделитель ключа строки и физического поля: «InputSource:Temperature».</summary>
        private const char FieldKeySeparator = ':';

        private static string ComposeFieldKey(CompPropertyKeys key, PhysicalField field) =>
            $"{key}{FieldKeySeparator}{field}";
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

            // Ключи строк входных полей и начальных значений несут физическое поле:
            // «InputSource:Temperature». Разбирается технический ключ, а не заголовок строки.
            var rowKey = SplitFieldKey(obj.Key, out var field);

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
                            selectedInstruction.Text = selectedInstruction.Text.Replace("пропустить", "выполнить");

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
                        SetInitialStateSource(EnsureInitialState(parameters),
                            IsFileSource(obj.NewValue) ? InitialStateSource.Result : InitialStateSource.Values);
                        break;
                    case CompPropertyKeys.InitialStateValue:
                        ApplyInitialValues(parameters, field, obj.NewValue);
                        break;
                    case CompPropertyKeys.InitialStateFile:
                        // Core хранит имя файла результата или шаблон поиска, каталог не хранится.
                        EnsureInitialResult(parameters).FileName = Path.GetFileName(obj.NewValue);
                        break;

                    case CompPropertyKeys.InputEnabled:
                        SetInputFieldEnabled(parameters, field, bool.Parse(obj.NewValue));
                        break;
                    case CompPropertyKeys.InputSource:
                        SetInputFieldSource(EnsureInputField(parameters, field),
                            IsFileSource(obj.NewValue) ? InputFieldSource.ResultFile : InputFieldSource.Constant);
                        break;
                    case CompPropertyKeys.InputConstant:
                        EnsureInputField(parameters, field).ConstantValues = ParseComponents(obj.NewValue);
                        break;
                    case CompPropertyKeys.InputFile:
                        EnsureInputField(parameters, field).FileName = Path.GetFileName(obj.NewValue);
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
        /// Отделяет от ключа строки физическое поле, если оно в нём закодировано.
        /// </summary>
        private static string SplitFieldKey(string key, out PhysicalField field)
        {
            field = default;

            var separator = key?.IndexOf(FieldKeySeparator) ?? -1;
            if (separator <= 0)
                return key;

            Enum.TryParse(key[(separator + 1)..], out field);
            return key[..separator];
        }

        /// <summary>Выбран ли в списке источника данных файл, а не константа.</summary>
        private static bool IsFileSource(string value) =>
            value == Properties.Resources.Header_comp_SourceFile;

        /// <summary>Нужно ли перестроить строки панели после изменения параметра.</summary>
        private static bool NeedsRedraw(string key)
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
                var compType = selectedNode.Text.Split(' ')[0];
                var sample = ReadTaskParametersFromFile(GetInstructionPath(selectedNode.Text));

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add(item.Text);

                foreach (var taskName in tasks)
                    if (taskName.Contains(compType))
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

        /// <summary>Возвращает описание источника поля, не изменяя модель.</summary>
        private InputField FindInputField(GeneralParameters parameters, PhysicalField field)
        {
            // GeneralParameters.GetInputField бросает исключение при дубликатах,
            // а панель должна показать даже частично заполненный файл.
            return parameters.InputFields?.FirstOrDefault(input => input.Field == field);
        }

        /// <summary>
        /// Возвращает описание источника поля, создавая его при отсутствии.
        /// Инвариант Core «один источник на одно физическое поле» поддерживается здесь.
        /// </summary>
        private InputField EnsureInputField(GeneralParameters parameters, PhysicalField field)
        {
            parameters.InputFields ??= new List<InputField>();

            var existing = parameters.InputFields.Where(input => input.Field == field).ToList();
            if (existing.Count == 0)
            {
                var created = new InputField { Field = field };
                parameters.InputFields.Add(created);
                return created;
            }

            for (var i = existing.Count - 1; i > 0; i--)
                parameters.InputFields.Remove(existing[i]);

            return existing[0];
        }

        /// <summary>
        /// Включает или выключает входное поле. Наличие поля в InputFields и означает,
        /// что задача его учитывает, — отдельного флага в модели нет.
        /// </summary>
        private void SetInputFieldEnabled(GeneralParameters parameters, PhysicalField field, bool enabled)
        {
            if (enabled)
            {
                EnsureInputField(parameters, field);
                return;
            }

            parameters.InputFields?.RemoveAll(input => input.Field == field);
        }

        /// <summary>Переключает источник поля, очищая значения, которые для него не действуют.</summary>
        private void SetInputFieldSource(InputField input, InputFieldSource source)
        {
            input.Source = source;

            if (source == InputFieldSource.Constant)
            {
                input.FileName = "";
                input.StartStep = 0;
                input.StepsCount = 0;
            }
            else
            {
                // Так же поступает PreProc.SetInputField при переходе на файл результатов.
                input.ConstantValues = Array.Empty<double>();
            }
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

        /// <summary>Возвращает начальное состояние, создавая его при отсутствии.</summary>
        private InitialState EnsureInitialState(GeneralParameters parameters) =>
            parameters.InitialState ??= new InitialState();

        /// <summary>Возвращает ссылку на результат начального состояния, создавая её при отсутствии.</summary>
        private ResultReference EnsureInitialResult(GeneralParameters parameters) =>
            EnsureInitialState(parameters).Result ??= new ResultReference();

        /// <summary>
        /// Переключает источник начального состояния, приводя модель к требованиям Core:
        /// при задании значениями ссылка на результат должна отсутствовать, а при
        /// инициализации результатом значения по группам должны быть пусты.
        /// </summary>
        private void SetInitialStateSource(InitialState state, InitialStateSource source)
        {
            state.Source = source;

            if (source == InitialStateSource.Values)
            {
                state.Result = null;
                state.Conditions ??= new List<InitialCondition>();
            }
            else
            {
                state.Conditions?.Clear();
                state.Result ??= new ResultReference();
            }
        }

        /// <summary>
        /// Начальные значения поля по группам в прежнем формате панели: «группа значение,группа значение».
        /// Заменяет удалённые GeneralParameters.InitTemp и ChemicalParameters.InitConcentration.
        /// </summary>
        private string FormatInitialValues(GeneralParameters parameters, PhysicalField field)
        {
            var values = parameters.InitialState?.Conditions?
                .FirstOrDefault(condition => condition.Field == field)?.Values;

            if (values == null)
                return string.Empty;

            return string.Join(",", values.Select(pair => $"{pair.Key} {FormatComponents(pair.Value)}"));
        }

        private void ApplyInitialValues(GeneralParameters parameters, PhysicalField field, string newValue)
        {
            var state = parameters.InitialState ??= new InitialState();

            // Инвариант Core: значения по группам и ссылка на результат взаимоисключающи.
            state.Source = InitialStateSource.Values;
            state.Result = null;
            state.Conditions ??= new List<InitialCondition>();

            var condition = state.Conditions.FirstOrDefault(x => x.Field == field);
            if (condition == null)
            {
                condition = new InitialCondition { Field = field };
                state.Conditions.Add(condition);
            }

            var pairs = newValue
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(pair => pair.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                .ToList();

            // Запятая разделяет группы, поэтому десятичный разделитель здесь только точка.
            // Без проверки «Металл 21,5» молча создало бы группу «5».
            if (pairs.Any(pair => pair.Length != 2))
                throw new ArgumentException(
                    "Ожидается «группа значение,группа значение». Десятичный разделитель — точка.");

            condition.Values = pairs.ToDictionary(pair => pair[0], pair => ParseComponents(pair[1]));
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