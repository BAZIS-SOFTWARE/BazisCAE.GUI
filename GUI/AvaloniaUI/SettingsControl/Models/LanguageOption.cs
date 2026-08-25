using System.Collections.Generic;

namespace BazisGUI.AvaloniaUI.SettingsControl.Models
{
    /// <summary>
    /// Языковой вариант интерфейса, выбираемый в окне настроек.
    /// </summary>
    /// <param name="DisplayName">Отображаемое имя (например, «Русский»).</param>
    /// <param name="Code">Код языка, сохраняемый в настройках (например, «ru»).</param>
    public sealed record LanguageOption(string DisplayName, string Code)
    {
        /// <summary>Русский язык.</summary>
        public static LanguageOption Russian { get; } = new("Русский", "ru");

        /// <summary>Английский язык.</summary>
        public static LanguageOption English { get; } = new("English", "en");

        /// <summary>Все доступные языки в порядке отображения.</summary>
        public static IReadOnlyList<LanguageOption> All { get; } = new[] { Russian, English };
    }
}
