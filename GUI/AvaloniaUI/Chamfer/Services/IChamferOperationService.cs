namespace BazisGUI.AvaloniaUI.Chamfer.Services
{
    /// <summary>
    /// Boundary between the Chamfer ViewModel and the application's geometry logic.
    /// </summary>
    public interface IChamferOperationService
    {
        void AddByAngle(double length, double angle);

        void AddByLengths(double length1, double length2);
    }
}
