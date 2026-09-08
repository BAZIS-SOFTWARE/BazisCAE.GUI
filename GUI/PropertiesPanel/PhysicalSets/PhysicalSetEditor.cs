using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BazisGUI.PropertiesPanel.PhysicalSets
{
    /// <summary>
    /// Применяет к параметрам задачи изменения, введённые в строках физических наборов.
    /// Здесь же поддерживаются требования Core: один набор на вид, взаимоисключающие
    /// источник-файл и значения по группам.
    /// </summary>
    internal sealed class PhysicalSetEditor
    {
        private readonly PhysicalSetCatalog catalog;

        public PhysicalSetEditor(PhysicalSetCatalog catalog)
        {
            this.catalog = catalog;
        }

        /// <summary>
        /// Применяет значение, если ключ строки принадлежит физическим наборам.
        /// </summary>
        /// <returns><c>false</c>, если ключ относится к другим параметрам задачи.</returns>
        public bool TryApply(GeneralParameters parameters, string rowKey, string newValue)
        {
            if (!PhysicalSetRowKey.TryParse(rowKey, out var key))
                return false;

            switch (key.Kind)
            {
                case PhysicalSetRowKind.Enabled:
                    SetInputEnabled(parameters, key.Set, ParseBool(newValue));
                    break;

                case PhysicalSetRowKind.Source:
                    SetSource(EnsureSet(parameters, key), IsFileSource(newValue)
                        ? PhysicalSetSource.ResultFile
                        : PhysicalSetSource.Values);
                    break;

                case PhysicalSetRowKind.File:
                    // Core хранит имя файла результатов или шаблон поиска, каталог не хранится.
                    EnsureSet(parameters, key).File = Path.GetFileName(newValue) ?? string.Empty;
                    break;

                case PhysicalSetRowKind.Value:
                    SetComponents(EnsureSet(parameters, key), key.Group, key.Quantity, ParseComponents(newValue));
                    break;
            }

            return true;
        }

        /// <summary>
        /// Меняет ли строка состав отображаемых строк: наличие внешнего набора
        /// и выбранный источник определяют, какие строки показывать ниже.
        /// </summary>
        public bool ChangesRowSet(string rowKey)
        {
            return PhysicalSetRowKey.TryParse(rowKey, out var key)
                && (key.Kind == PhysicalSetRowKind.Enabled || key.Kind == PhysicalSetRowKind.Source);
        }

        // ------------------------------------------------------------------ изменение модели

        /// <summary>
        /// Включает или выключает внешний набор: наличие набора в InputSets и означает,
        /// что задача его учитывает, — отдельного признака в модели нет.
        /// </summary>
        private void SetInputEnabled(GeneralParameters parameters, PhysicalSetName name, bool enabled)
        {
            if (!enabled)
            {
                parameters.InputSets?.RemoveAll(set => set.Name == name);
                return;
            }

            parameters.InputSets ??= new List<PhysicalSet>();
            EnsureInput(parameters, name);
        }

        /// <summary>
        /// Переключает источник, очищая значения, которые для нового источника не действуют:
        /// Core не должен получить набор, у которого заданы и файл, и значения.
        /// </summary>
        private void SetSource(PhysicalSet set, PhysicalSetSource source)
        {
            set.Source = source;

            if (source == PhysicalSetSource.Values)
                set.File = string.Empty;
            else
                set.Values?.Clear();
        }

        private void SetComponents(PhysicalSet set, string group, PhysicalFieldName quantity, double[] components)
        {
            if (string.IsNullOrEmpty(group))
                throw new ArgumentException("The row key does not contain an element group name.");

            SetSource(set, PhysicalSetSource.Values);
            set.Values ??= new Dictionary<string, List<PhysicalField>>();

            if (!set.Values.TryGetValue(group, out var fields) || fields == null)
            {
                fields = new List<PhysicalField>();
                set.Values[group] = fields;
            }

            var field = fields.FirstOrDefault(value => value.Name == quantity);

            // Пустое значение означает, что величина для группы не задана.
            if (components.Length == 0)
            {
                if (field != null)
                    fields.Remove(field);

                if (fields.Count == 0)
                    set.Values.Remove(group);

                return;
            }

            if (field == null)
            {
                field = new PhysicalField { Name = quantity };
                fields.Add(field);
            }

            field.Components = components;
        }

        /// <summary>Возвращает набор строки, создавая его при отсутствии.</summary>
        private PhysicalSet EnsureSet(GeneralParameters parameters, PhysicalSetRowKey key) =>
            key.Role == PhysicalSetRole.Initial
                ? EnsureInitial(parameters, key.Set)
                : EnsureInput(parameters, key.Set);

        private PhysicalSet EnsureInitial(GeneralParameters parameters, PhysicalSetName name)
        {
            if (parameters.InitialSet == null || parameters.InitialSet.Name != name)
                parameters.InitialSet = new PhysicalSet { Name = name };

            return parameters.InitialSet;
        }

        /// <summary>
        /// Возвращает внешний набор, создавая его при отсутствии. Требование Core
        /// «один источник на набор» поддерживается здесь: дубликаты сворачиваются.
        /// </summary>
        private PhysicalSet EnsureInput(GeneralParameters parameters, PhysicalSetName name)
        {
            parameters.InputSets ??= new List<PhysicalSet>();

            var existing = parameters.InputSets.Where(set => set.Name == name).ToList();
            if (existing.Count == 0)
            {
                var created = new PhysicalSet { Name = name };
                parameters.InputSets.Add(created);
                return created;
            }

            for (var i = existing.Count - 1; i > 0; i--)
                parameters.InputSets.Remove(existing[i]);

            return existing[0];
        }

        // ------------------------------------------------------------------ разбор значений

        private static bool IsFileSource(string value) =>
            value == Properties.Resources.Header_comp_SourceFile;

        private static bool ParseBool(string value)
        {
            if (!bool.TryParse((value ?? string.Empty).Trim(), out var result))
                throw new ArgumentException($"Не удалось преобразовать «{value}» в логическое значение.");

            return result;
        }

        /// <summary>
        /// Компоненты величины через запятую. Разделителем компонент выбрана запятая
        /// по схеме данных, поэтому десятичный разделитель здесь только точка.
        /// </summary>
        private static double[] ParseComponents(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Array.Empty<double>();

            return value
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(ParseComponent)
                .ToArray();
        }

        private static double ParseComponent(string value)
        {
            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                throw new ArgumentException(
                    $"Не удалось преобразовать «{value}» в число. Компоненты разделяются запятой, дробная часть — точкой.");

            return result;
        }
    }
}
