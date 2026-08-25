using BazisGUI.Properties;

namespace BazisGUI.Localization
{
    /// <summary>
    /// Локализованные подписи окна измерений.
    /// </summary>
    /// <remarks>
    /// Класс является адаптером к общим ресурсам приложения <see cref="Resources"/>:
    /// собственного механизма локализации не содержит, значения берутся из
    /// Resources.resx / Resources.ru.resx / Resources.en.resx по текущей языковой культуре.
    /// Используется в разметке Avalonia через {x:Static}, так как класс ресурсов
    /// имеет модификатор internal и недоступен из XAML напрямую.
    /// Подписи читаются при создании окна, поэтому окно открывается на языке,
    /// выбранном в настройках приложения.
    /// </remarks>
    public static class MeasurementWindowLocalization
    {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public static string Title => Resources.MeasurementWindow_Title;

        /// <summary>
        /// Подпись переключателя «Расстояние».
        /// </summary>
        public static string Distance => Resources.MeasurementWindow_Distance;

        /// <summary>
        /// Подпись переключателя «Путь».
        /// </summary>
        public static string Path => Resources.MeasurementWindow_Path;

        /// <summary>
        /// Подпись переключателя «Площадь».
        /// </summary>
        public static string Area => Resources.MeasurementWindow_Area;

        /// <summary>
        /// Подпись переключателя «Объём».
        /// </summary>
        public static string Volume => Resources.MeasurementWindow_Volume;

        /// <summary>
        /// Подпись элемента комбобокса «Между двумя точками».
        /// </summary>
        public static string BetweenTwoPoints => Resources.MeasurementWindow_BetweenTwoPoints;

        /// <summary>
        /// Подпись элемента комбобокса «Между точкой и плоскостью».
        /// </summary>
        public static string BetweenPointAndPlane => Resources.MeasurementWindow_BetweenPointAndPlane;

        /// <summary>
        /// Подпись кнопки «Измерить».
        /// </summary>
        public static string MeasureButton => Resources.MeasurementWindow_MeasureButton;
    }
}
