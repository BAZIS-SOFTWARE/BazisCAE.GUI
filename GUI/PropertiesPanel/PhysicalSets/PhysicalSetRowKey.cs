using Project.TaskParameters;
using System;

namespace BazisGUI.PropertiesPanel.PhysicalSets
{
    /// <summary>Роль набора в параметрах задачи.</summary>
    internal enum PhysicalSetRole
    {
        /// <summary>Родной набор, задающий начальное состояние.</summary>
        Initial,

        /// <summary>Внешний набор, приходящий от другой задачи.</summary>
        Input
    }

    /// <summary>Что именно настраивает строка панели.</summary>
    internal enum PhysicalSetRowKind
    {
        /// <summary>Флажок наличия внешнего набора.</summary>
        Enabled,

        /// <summary>Источник значений набора.</summary>
        Source,

        /// <summary>Имя файла результатов.</summary>
        File,

        /// <summary>Значения величины для одной элементной группы.</summary>
        Value
    }

    /// <summary>
    /// Технический ключ строки набора. Формат объявлен здесь и только здесь, поэтому
    /// построение строк и обратная запись не могут разойтись в его понимании.
    /// От локализованного заголовка ключ не зависит.
    /// </summary>
    internal readonly struct PhysicalSetRowKey
    {
        private const char Separator = '|';
        private const string Prefix = "Set";

        public PhysicalSetRole Role { get; }
        public PhysicalSetRowKind Kind { get; }
        public PhysicalSetName Set { get; }
        public PhysicalFieldName Quantity { get; }

        /// <summary>Имя элементной группы для <see cref="PhysicalSetRowKind.Value"/>.</summary>
        public string Group { get; }

        public PhysicalSetRowKey(
            PhysicalSetRole role,
            PhysicalSetRowKind kind,
            PhysicalSetName set,
            PhysicalFieldName quantity = default,
            string group = null)
        {
            Role = role;
            Kind = kind;
            Set = set;
            Quantity = quantity;
            Group = group;
        }

        /// <summary>
        /// Величина и группа значимы только для строки значения, у остальных строк
        /// их места пусты. Имя группы идёт последним и берётся остатком строки,
        /// поэтому разделитель внутри имени группы разбор не ломает.
        /// </summary>
        public override string ToString()
        {
            var quantity = Kind == PhysicalSetRowKind.Value ? Quantity.ToString() : string.Empty;
            return string.Join(Separator.ToString(), Prefix, Role, Kind, Set, quantity, Group ?? string.Empty);
        }

        public static bool TryParse(string key, out PhysicalSetRowKey result)
        {
            result = default;

            if (key == null || !key.StartsWith(Prefix + Separator, StringComparison.Ordinal))
                return false;

            var parts = key.Split(Separator, 6);
            if (parts.Length < 6
                || !Enum.TryParse(parts[1], out PhysicalSetRole role)
                || !Enum.TryParse(parts[2], out PhysicalSetRowKind kind)
                || !Enum.TryParse(parts[3], out PhysicalSetName set))
                return false;

            var quantity = default(PhysicalFieldName);
            if (kind == PhysicalSetRowKind.Value && !Enum.TryParse(parts[4], out quantity))
                return false;

            result = new PhysicalSetRowKey(role, kind, set, quantity,
                parts[5].Length == 0 ? null : parts[5]);
            return true;
        }
    }
}
