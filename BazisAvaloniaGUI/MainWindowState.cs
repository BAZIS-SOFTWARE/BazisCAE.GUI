using OperationalController;
using System.Globalization;

namespace BazisAvaloniaGUI;

/// <summary>Project commands and state, independent of visual controls.</summary>
internal sealed class MainWindowState
{
    private ProjectController? project;
    public event Action? Changed;
    public event Action<ProjectController>? ProjectChanged;
    public event Action<string>? Error;
    public string? ProjectPath { get; private set; }
    public string Status { get; private set; } = "Создайте или загрузите проект";
    public bool IsBusy { get; private set; }
    public bool HasProject => project != null;

    public void SetStatus(string value)
    {
        Status = value;
        Changed?.Invoke();
    }

    public async Task CreateProject(string path) => await Run("Создание проекта...", async () =>
    {
        var created = await Task.Run(() =>
        {
            var result = new ProjectController();
            result.CreateProject(Path.GetFileName(path));
            result.CreateTask();
            result.Save(path);
            return result;
        });
        SetProject(created, path);
    });

    public async Task OpenProject(string path) => await Run("Загрузка проекта...", async () =>
    {
        var loaded = await Task.Run(() =>
        {
            var result = new ProjectController();
            // The legacy text BPF parser expects invariant decimal points in function parameters.
            // Keep the override scoped to the worker so the window's language is unaffected.
            if (string.Equals(Path.GetExtension(path), ".bpf", StringComparison.OrdinalIgnoreCase))
            {
                var previousCulture = CultureInfo.CurrentCulture;
                try
                {
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                    result.Load(path);
                }
                finally
                {
                    CultureInfo.CurrentCulture = previousCulture;
                }
            }
            else
                result.Load(path);
            return result;
        });
        SetProject(loaded, path);
    });

    public async Task SaveProject(string? path = null) => await Run("Сохранение проекта...", async () =>
    {
        if (project == null) throw new InvalidOperationException("Нет открытого проекта.");
        var destination = path ?? ProjectPath ?? throw new InvalidOperationException("Укажите путь проекта.");
        var previousName = project.Name;
        try
        {
            project.Name = Path.GetFileName(destination);
            await Task.Run(() => project.Save(destination));
        }
        catch
        {
            project.Name = previousName;
            throw;
        }
        ProjectPath = destination;
        SetStatus(destination);
    });

    private void SetProject(ProjectController value, string path)
    {
        project = value;
        ProjectPath = path;
        SetStatus(path);
        ProjectChanged?.Invoke(value);
    }

    private async Task Run(string progress, Func<Task> operation)
    {
        if (IsBusy) return;
        IsBusy = true;
        var previous = Status;
        SetStatus(progress);
        try { await operation(); }
        catch (Exception error) { SetStatus(previous); Error?.Invoke(error.Message); }
        finally { IsBusy = false; Changed?.Invoke(); }
    }
}
