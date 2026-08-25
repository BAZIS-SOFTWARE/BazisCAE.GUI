using System.Drawing;

namespace BazisGUI.AvaloniaUI.SettingsControl.Services
{
    /// <summary>
    /// Граница между ViewModel окна настроек и прикладной логикой приложения.
    /// </summary>
    /// <remarks>
    /// Реализации гарантируют выполнение операций в UI-потоке WinForms через
    /// <see cref="System.Threading.SynchronizationContext"/> (см.
    /// <see cref="SynchronizationContextSettingsOperationService"/>): применение настроек
    /// к <see cref="BazisGUI.SettingsControls.SettingsConfig"/>, рендереру и сцене
    /// остаётся на стороне WinForms.
    /// </remarks>
    public interface ISettingsOperationService
    {
        /// <summary>Задать цвет фона сцены.</summary>
        void SetBackgroundColor(Color color);

        /// <summary>Задать цвет выделения объектов.</summary>
        void SetSelectionObjectColor(Color color);

        /// <summary>Задать цвет выделения групп.</summary>
        void SetSelectionGroupColor(Color color);

        /// <summary>Задать цвет узлов.</summary>
        void SetNodeColor(Color color);

        /// <summary>Задать путь до решателя.</summary>
        void SetSolverPath(string path);

        /// <summary>Включить/выключить освещение.</summary>
        void SetLighting(bool enabled);

        /// <summary>Задать интенсивность освещения (0..100).</summary>
        void SetLightingIntensity(int intensity);

        /// <summary>
        /// Задать положение источника света. Координаты <paramref name="x"/> и
        /// <paramref name="y"/> заданы в системе координат контрола выбора света,
        /// <paramref name="controlWidth"/> и <paramref name="controlHeight"/> — размер
        /// контрола (для масштабирования к размерам сцены).
        /// </summary>
        void SetLighterPosition(double x, double y, double controlWidth, double controlHeight);

        /// <summary>Включить/выключить прозрачность.</summary>
        void SetTransparency(bool enabled);

        /// <summary>Задать значение прозрачности (0..100).</summary>
        void SetTransparencyValue(int value);

        /// <summary>Включить ортографическую проекцию.</summary>
        void SetOrtoProjection(bool enabled);

        /// <summary>Задать язык интерфейса (код «ru»/«en»).</summary>
        void SetLanguage(string language);

        /// <summary>Сохранить конфигурацию настроек (при закрытии окна).</summary>
        void Save();
    }
}
