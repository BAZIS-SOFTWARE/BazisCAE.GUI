using BazisGUI.Properties;

namespace BazisGUI.Localization
{
    /// <summary>
    /// Локализованные подписи окна настроек.
    /// </summary>
    /// <remarks>
    /// Адаптер к общим ресурсам <see cref="Resources"/> для использования в разметке
    /// Avalonia через {x:Static}. Значения берутся по текущей языковой культуре.
    /// </remarks>
    public static class SettingsWindowLocalization
    {
        /// <summary>Заголовок окна.</summary>
        public static string Title => Resources.SettingsWindow_Title;

        /// <summary>Заголовок вкладки «Сцена».</summary>
        public static string TabScene => Resources.SettingsWindow_TabScene;

        /// <summary>Заголовок вкладки «Объекты».</summary>
        public static string TabObjects => Resources.SettingsWindow_TabObjects;

        /// <summary>Заголовок вкладки «Решатель».</summary>
        public static string TabSolver => Resources.SettingsWindow_TabSolver;

        /// <summary>Заголовок вкладки «Язык».</summary>
        public static string TabLanguage => Resources.SettingsWindow_TabLanguage;

        /// <summary>Подпись кнопки выбора цвета фона.</summary>
        public static string BackgroundColorButton => Resources.SettingsWindow_BackgroundColorButton;

        /// <summary>Подпись «Внутренние ребра элементов».</summary>
        public static string BackRibbersLabel => Resources.SettingsWindow_BackRibbersLabel;

        /// <summary>Подпись «Освещение».</summary>
        public static string LightingLabel => Resources.SettingsWindow_LightingLabel;

        /// <summary>Подпись «Интенсивность».</summary>
        public static string LightingIntensityLabel => Resources.SettingsWindow_LightingIntensityLabel;

        /// <summary>Подпись «Прозрачность».</summary>
        public static string TransparencyLabel => Resources.SettingsWindow_TransparencyLabel;

        /// <summary>Подпись «Значение прозрачности».</summary>
        public static string TransparencyValueLabel => Resources.SettingsWindow_TransparencyValueLabel;

        /// <summary>Подпись «Ортографическая проекция».</summary>
        public static string OrtoProjectionLabel => Resources.SettingsWindow_OrtoProjectionLabel;

        /// <summary>Подпись «Вкл/Выкл».</summary>
        public static string OnOff => Resources.SettingsWindow_OnOff;

        /// <summary>Подпись кнопки выбора цвета выделения объектов.</summary>
        public static string SelectObjectColorButton => Resources.SettingsWindow_SelectObjectColorButton;

        /// <summary>Подпись кнопки выбора цвета выделения групп.</summary>
        public static string SelectGroupColorButton => Resources.SettingsWindow_SelectGroupColorButton;

        /// <summary>Подпись кнопки выбора цвета 3D-элементов.</summary>
        public static string Select3DElemColorButton => Resources.SettingsWindow_Select3DElemColorButton;

        /// <summary>Подпись кнопки выбора цвета 2D-элементов.</summary>
        public static string Select2DElemColorButton => Resources.SettingsWindow_Select2DElemColorButton;

        /// <summary>Подпись кнопки выбора цвета узлов.</summary>
        public static string SelectNodeColorButton => Resources.SettingsWindow_SelectNodeColorButton;

        /// <summary>Подпись «Путь до решателя».</summary>
        public static string SolverPathLabel => Resources.SettingsWindow_SolverPathLabel;

        /// <summary>Подпись кнопки «Обзор…».</summary>
        public static string BrowseButton => Resources.SettingsWindow_BrowseButton;

        /// <summary>Подпись «Язык».</summary>
        public static string LanguageLabel => Resources.SettingsWindow_LanguageLabel;

        /// <summary>Заголовок окна выбора цвета.</summary>
        public static string ColorPickerTitle => Resources.SettingsWindow_ColorPickerTitle;

        /// <summary>Подпись кнопки «OK».</summary>
        public static string Ok => Resources.SettingsWindow_Ok;

        /// <summary>Подпись кнопки «Отмена».</summary>
        public static string Cancel => Resources.SettingsWindow_Cancel;
    }
}
