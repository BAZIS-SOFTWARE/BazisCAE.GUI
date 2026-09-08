using Project.TaskParameters;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BazisGUI.PropertiesPanel.PhysicalSets
{
    /// <summary>
    /// Превращает физический набор в строки панели свойств.
    /// Родной и внешний наборы имеют одинаковое устройство, поэтому их настройки
    /// строит один и тот же код: отличается только заголовок и наличие флажка.
    /// </summary>
    internal sealed class PhysicalSetRowBuilder
    {
        /// <summary>Ключ подписи: такие строки ничего не настраивают и никем не разбираются.</summary>
        private const string LabelKey = "PhysicalSetLabel";

        private readonly PhysicalSetCatalog catalog;
        private readonly List<string> groups;
        private readonly List<string> availableResults;

        public PhysicalSetRowBuilder(PhysicalSetCatalog catalog, List<string> groups, List<string> availableResults)
        {
            this.catalog = catalog;
            this.groups = groups ?? new List<string>();
            this.availableResults = availableResults ?? new List<string>();
        }

        /// <summary>
        /// Строки родного набора: его имя, источник данных и зависящие от источника строки.
        /// Флажка нет — родной набор у задачи всегда есть, он и задаёт начальное состояние.
        /// </summary>
        public List<RowProperty> BuildInitial(PhysicalSetName name, PhysicalSet set)
        {
            var rows = new List<RowProperty>
            {
                Label(Properties.Resources.Header_comp_NativeSet, catalog.GetSetHeader(name)),
                SourceRow(PhysicalSetRole.Initial, name, set,
                    Indent(1) + Properties.Resources.Header_comp_InitialStateSource)
            };

            // Источник и зависящие от него строки — соседи под именем набора.
            rows.AddRange(SettingRows(PhysicalSetRole.Initial, name, set, 1));
            return rows;
        }

        /// <summary>Подпись, отделяющая внешние наборы от родного.</summary>
        public RowProperty BuildForeignLabel() =>
            Label(Properties.Resources.Header_comp_ForeignSets, string.Empty);

        /// <summary>
        /// Строки внешнего набора: флажок наличия и, если набор включён,
        /// источник данных с зависящими от него строками.
        /// </summary>
        public List<RowProperty> BuildInput(PhysicalSetName name, PhysicalSet set)
        {
            var rows = new List<RowProperty>
            {
                new RowProperty(
                    new PhysicalSetRowKey(PhysicalSetRole.Input, PhysicalSetRowKind.Enabled, name).ToString(),
                    Indent(1) + catalog.GetSetHeader(name),
                    set != null)
            };

            if (set == null)
                return rows;

            rows.Add(SourceRow(PhysicalSetRole.Input, name, set,
                Indent(2) + Properties.Resources.Header_comp_InputSource));
            rows.AddRange(SettingRows(PhysicalSetRole.Input, name, set, 2));
            return rows;
        }

        /// <summary>Информационная строка: ничего не настраивает, только поясняет структуру.</summary>
        private static RowProperty Label(string header, string value) =>
            new RowProperty(LabelKey, header, value, isReadOnly: true);

        /// <summary>Отступ строки, подчинённой строке выше.</summary>
        private static string Indent(int level) => new string(' ', 3 * level);

        private RowProperty SourceRow(PhysicalSetRole role, PhysicalSetName name, PhysicalSet set, string header)
        {
            var isFile = (set?.Source ?? PhysicalSetSource.Values) == PhysicalSetSource.ResultFile;

            return new RowProperty(
                new PhysicalSetRowKey(role, PhysicalSetRowKind.Source, name).ToString(),
                header,
                new DropDownPropertyValue(SourceName(isFile), SourceNames()));
        }

        /// <summary>
        /// Строки, состав которых зависит от источника: имя файла результатов либо
        /// значения величин по элементным группам.
        /// </summary>
        private IEnumerable<RowProperty> SettingRows(
            PhysicalSetRole role, PhysicalSetName name, PhysicalSet set, int level)
        {
            if ((set?.Source ?? PhysicalSetSource.Values) == PhysicalSetSource.ResultFile)
            {
                yield return new RowProperty(
                    new PhysicalSetRowKey(role, PhysicalSetRowKind.File, name).ToString(),
                    Indent(level) + Properties.Resources.Header_comp_FileName,
                    ResultValue(set?.File));

                yield break;
            }

            var quantities = catalog.GetQuantities(name, set);

            foreach (var group in GroupsToShow(set))
                foreach (var quantity in quantities)
                    yield return new RowProperty(
                        new PhysicalSetRowKey(role, PhysicalSetRowKind.Value, name, quantity, group).ToString(),
                        Indent(level) + ValueHeader(group, quantity, quantities.Count),
                        FormatComponents(set, group, quantity));
        }

        /// <summary>
        /// Группы инструкции плюс те, что уже есть в значениях набора: группа могла
        /// остаться от условия, которое из инструкции убрали.
        /// </summary>
        private List<string> GroupsToShow(PhysicalSet set)
        {
            var result = new List<string>(groups);

            foreach (var group in set?.Values?.Keys ?? Enumerable.Empty<string>())
                if (!result.Contains(group))
                    result.Add(group);

            return result;
        }

        private string ValueHeader(string group, PhysicalFieldName quantity, int quantityCount) =>
            quantityCount > 1 ? $"{group} — {catalog.GetQuantityHeader(quantity)}" : group;

        /// <summary>Компоненты величины группы через запятую.</summary>
        private string FormatComponents(PhysicalSet set, string group, PhysicalFieldName quantity)
        {
            if (set?.Values == null || !set.Values.TryGetValue(group, out var fields))
                return string.Empty;

            var components = fields?.FirstOrDefault(field => field.Name == quantity)?.Components;
            if (components == null || components.Length == 0)
                return string.Empty;

            return string.Join(", ", components.Select(x => x.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Ячейка выбора результата. Сохранённая ссылка могла остаться от инструкции,
        /// которой больше нет, — тогда она добавляется в список, иначе он её потеряет.
        /// </summary>
        private DropDownPropertyValue ResultValue(string current)
        {
            var values = new List<string>(availableResults);

            if (!string.IsNullOrEmpty(current) && !values.Contains(current))
                values.Add(current);

            return new DropDownPropertyValue(current ?? string.Empty, values);
        }

        private static List<string> SourceNames() => new List<string>
        {
            Properties.Resources.Header_comp_SourceConstant,
            Properties.Resources.Header_comp_SourceFile
        };

        private static string SourceName(bool isFile) => isFile
            ? Properties.Resources.Header_comp_SourceFile
            : Properties.Resources.Header_comp_SourceConstant;
    }
}
