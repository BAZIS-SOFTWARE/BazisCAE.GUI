using Avalonia.Platform.Storage;
using BazisAvaloniaGUI.Navigator;
using ResultDB;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    // В BaseForm объявлен в GUI/Methods/Navigator/NavigatorMethods.cs.
    enum ResultType { nodes, elements }

    // Из GUI/Methods/Results/ResultsMainMenuEvents.cs перенесены пункты меню "Открыть" и "Объединить"
    // и заполнение дерева результатов. Вывод полей результатов на сцену (PresentResultsField, ShowResultValue)
    // и MergeResults используются выбором результатов в навигаторе, который в Avalonia ещё не перенесён.
    internal partial class MainWindow
    {
        IEnumerable<float> resultTimes;

        /// <summary>
        /// Обработчик нажатия пункта меню "Объединить БД результатов".
        /// Позволяет выбрать несколько файлов .db и последовательно объединяет их в один.
        /// </summary>
        private async void MergeDataBase_Click(object sender, EventArgs e)
        {
            var openDialog = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Выберите файлы БД результатов",
                FileTypeFilter = FileTypes("Results files (*.db)|*.db"),
                AllowMultiple = true,
            });

            if (openDialog.Count == 0)
                return;

            var paths = openDialog.Select(file => file.TryGetLocalPath()).ToArray();
            if (paths == null || paths.Length < 2)
            {
                console.PrintInfo("Необходимо выбрать минимум два файла", Color.Orange);
                return;
            }

            var loader = new LoadResultsFileDB();
            var currentResultPath = string.Empty;

            try
            {
                currentResultPath = loader.Merge(paths[0], paths[1]);

                for (int i = 2; i < paths.Length; i++)
                {
                    var nextPath = paths[i];
                    var newResultPath = loader.Merge(currentResultPath, nextPath);
                    TryDeleteFile(currentResultPath);
                    currentResultPath = newResultPath;
                    console.PrintInfo($"Объединено файлов {i + 1} из {paths.Length}", Color.Black);
                }

                console.PrintInfo("Объединение файлов завершено", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo($"Ошибка при объединении файлов: {ex.Message}", Color.Red);
            }

            /// <summary>
            /// Пытается удалить файл по указанному пути. Выполняет сборку мусора перед удалением,
            /// чтобы освободить возможные блокировки файла.
            /// </summary>
            void TryDeleteFile(string path)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(path);
                    }
                }
                catch (Exception ex)
                {
                    console.PrintInfo($"Не удалось удалить временный файл: {path}\n{ex.Message}", Color.Red);
                }
            }
        }

        private async void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var openDialog = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                SuggestedStartLocation = await StorageProvider.TryGetFolderFromPathAsync(AppContext.BaseDirectory),
                FileTypeFilter = FileTypes("Results files (*.db)|*.db")
            });

            if (openDialog.Count == 0)
                return;


            ResultDbPath = openDialog[0].TryGetLocalPath();

            FillingResultsData();
        }

        private void FillingResultsData()
        {
            var loader = new LoadResultsFileDB();
            var scheme = loader.GetTablesSchemes(ResultDbPath).
                FirstOrDefault(x => x.Key == ResultType.nodes.ToString());

            List<TreeNode> results;

            if (!navigator.TrySearchNodes(NodeName.Results, out results))
            {
                var rn = navigator.CreateRealNode(NodeName.Results);

                navigator.TrySearchNodes(NodeName.Project, out List<TreeNode> prNodes);
                prNodes[0].Nodes.Add(rn);
                results.Add(rn);
            }
            else
                results[0].Nodes.Clear();

            resultTimes = loader.GetValues(ResultDbPath, scheme.Key, "Time");


            foreach (var desc in scheme.Value)
            {
                var rn = navigator.CreateRealNode(NodeName.Result, $"{desc}");

                var vn = navigator.CreateVirtualNode(NodeName.Result);
                rn.Nodes.Add(vn);
                results[0].Nodes.Add(rn);
            }
        }
    }
}
