using BazisGUI.Properties;

namespace BazisGUI.Localization
{
    /// <summary>
    /// Локализованные подписи окна «Скрыть плоскостью».
    /// </summary>
    /// <remarks>
    /// Класс является адаптером к общим ресурсам приложения <see cref="Resources"/>:
    /// собственного механизма локализации не содержит, значения берутся из
    /// Resources.resx / Resources.ru.resx / Resources.en.resx по текущей языковой культуре.
    /// Используется в разметке Avalonia через {x:Static}, так как класс ресурсов
    /// имеет модификатор internal и недоступен из XAML напрямую.
    /// </remarks>
    public static class ClipWindowLocalization
    {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public static string Title => Resources.ClipWindow_Title;

        /// <summary>
        /// Подпись чекбокса «Включить».
        /// </summary>
        public static string EnableCheckBox => Resources.ClipWindow_EnableCheckBox;

        /// <summary>
        /// Подпись «Дельта D:».
        /// </summary>
        public static string DeltaDLabel => Resources.ClipWindow_DeltaDLabel;

        /// <summary>
        /// Подпись «D:».
        /// </summary>
        public static string OffsetDLabel => Resources.ClipWindow_OffsetDLabel;

        /// <summary>
        /// Подпись «Толщина слоя:».
        /// </summary>
        public static string LayerThicknessLabel => Resources.ClipWindow_LayerThicknessLabel;

        /// <summary>
        /// Подпись кнопки «Сброс».
        /// </summary>
        public static string ResetButton => Resources.ClipWindow_ResetButton;

        /// <summary>
        /// Подпись кнопки «Захват».
        /// </summary>
        public static string CaptureButton => Resources.ClipWindow_CaptureButton;

        /// <summary>
        /// Подпись режима «Обычное».
        /// </summary>
        public static string ModeDefault => Resources.ClipWindow_ModeDefault;

        /// <summary>
        /// Подпись режима «Сохранять 3D».
        /// </summary>
        public static string ModeKeepElement => Resources.ClipWindow_ModeKeepElement;

        /// <summary>
        /// Подпись режима «Слой 3D».
        /// </summary>
        public static string ModeLayered => Resources.ClipWindow_ModeLayered;
    }
}
