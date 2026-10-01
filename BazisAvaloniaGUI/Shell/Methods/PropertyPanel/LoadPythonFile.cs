using Avalonia.Platform.Storage;
using BazisAvaloniaGUI.Localization;
using System;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        // Avalonia: StorageProvider возвращает результат асинхронно, поэтому путь передаётся в обратный вызов.
        private async void LoadPythonFile(Action<string> loaded)
        {
            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = Resources.LoadPythonFile_ВыберитеPythonФайл,
                AllowMultiple = false,
                FileTypeFilter = [new FilePickerFileType("Python Files") { Patterns = ["*.py"] }]
            });

            if (files.Count != 0)
                loaded(files[0].TryGetLocalPath());
            else
                loaded(string.Empty);
        }
    }
}
