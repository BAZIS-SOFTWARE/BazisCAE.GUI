namespace BazisGUI.AvaloniaUI.Measurement.Models
{
    /// <summary>
    /// Вид выполняемого измерения.
    /// </summary>
    /// <remarks>
    /// Полный аналог <see cref="BazisGUI.Measurement.MeasureKind"/> WinForms-контрола
    /// <see cref="BazisGUI.Measurement.MeasuringSet"/>. Определяется здесь отдельно,
    /// чтобы модуль Avalonia оставался самодостаточным, как модуль Chamfer.
    /// </remarks>
    public enum MeasureKind
    {
        /// <summary>
        /// Расстояние между двумя точками.
        /// </summary>
        DistancePointToPoint,

        /// <summary>
        /// Расстояние между точкой и плоскостью.
        /// </summary>
        DistancePointToPlane,

        /// <summary>
        /// Длина пути по выбранным узлам.
        /// </summary>
        Path,

        /// <summary>
        /// Площадь выбранных элементов.
        /// </summary>
        Square,

        /// <summary>
        /// Объём выбранных элементов.
        /// </summary>
        Volume
    }
}
