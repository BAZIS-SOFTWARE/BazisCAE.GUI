namespace BazisGUI.AvaloniaUI.Clip.Models
{
    /// <summary>
    /// Набор готовых ориентаций плоскости отсечения (пресетов).
    /// </summary>
    /// <remarks>
    /// Соответствует радиокнопкам-пресетам в WinForms-контроле
    /// <see cref="BazisGUI.Clip.ClipControl"/>. Имя обозначает оси, параллельные
    /// плоскости: например, <see cref="YZ"/> — плоскость, параллельная осям YZ
    /// (нормаль направлена вдоль оси X).
    /// </remarks>
    public enum PlanePreset
    {
        /// <summary>Плоскость, параллельная осям YZ (нормаль +X).</summary>
        YZ,

        /// <summary>Плоскость, параллельная осям ZY (нормаль −X).</summary>
        ZY,

        /// <summary>Плоскость, параллельная осям ZX (нормаль +Y).</summary>
        ZX,

        /// <summary>Плоскость, параллельная осям XZ (нормаль −Y).</summary>
        XZ,

        /// <summary>Плоскость, параллельная осям XY (нормаль +Z).</summary>
        XY,

        /// <summary>Плоскость, параллельная осям YX (нормаль −Z).</summary>
        YX
    }
}
