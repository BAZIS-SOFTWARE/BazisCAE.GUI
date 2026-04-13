using BazisGUI.Navigator;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Project.Interfaces.Tasks;
using ResultDB;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        IEnumerable<float> resultTimes;

        public void SortCharNumberStrings(string[] anArray)
        {
            //Основной цикл (количество повторений равно количеству элементов массива)
            for (int i = 0; i < anArray.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    var chrs_a = anArray[j].Where(x => char.IsDigit(x)).ToArray();
                    var str_a = string.Join("", chrs_a);

                    var chrs_b = anArray[j + 1].Where(x => char.IsDigit(x)).ToArray();
                    var str_b = string.Join("", chrs_b);

                    var a = int.Parse(str_a);
                    var b = int.Parse(str_b);
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (a > b)
                    {
                        var tmp = anArray[j];
                        anArray[j] = anArray[j + 1];
                        anArray[j + 1] = tmp;
                    }
                }
            }
        }

        public void MergeResults(Result result)
        {
            try
            {
                Dictionary<int, List<int>> interfaceNodes;
                if (project.ProjectType == TaskType.Volume |
                    project.ProjectType == TaskType.Volume_mixed)
                    interfaceNodes = project.FindInterfacedNodes(3);
                else
                    interfaceNodes = project.FindInterfacedNodes(2);

                console.PrintInfo($"Выполняется пересчет на узлы, время {result.Time}", Color.Black);
                console.PrintInfo("", Color.Black);

                var resNames = result.Data.Tables[(int)ResultType.elements].GetTableSchema();

                for (int i = 1; i < resNames.Length; i++)
                {
                    resultsController.ResultsMerger.Merge(interfaceNodes, resNames[i], result);

                    Invoke(new Action(() =>
                    {
                        console.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                    }));
                }

                console.PrintInfo("Пересчет завершен", Color.Green);

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo($"В ходе пересчета возникла ошибка: {ex.Message}", Color.Red);
                }));
            }
        }

        /// <summary>
        /// Обработчик нажатия пункта меню "Объединить БД результатов".
        /// Позволяет выбрать несколько файлов .db и последовательно объединяет их в один.
        /// </summary>
        private void MergeDataBase_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog()
            {
                Title = "Выберите файлы БД результатов",
                Filter = "Results files (*.db)|*.db",
                Multiselect = true,
            };

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            var paths = openDialog.FileNames;
            if (paths == null || paths.Length < 2)
            {
                console.PrintInfo("Необходимо выбрать минимум два файла", Color.Orange);
                return;
            }

            var loader = new LoadResultsFileDB();
            string currentResultPath = null;

            try
            {
                currentResultPath = loader.Merge(paths[0], paths[1]);

                for (int i = 2; i < paths.Length; i++)
                {
                    var nextPath = paths[i];
                    var newResultPath = loader.Merge(currentResultPath, nextPath);
                    TryDeleteFile(currentResultPath);
                    currentResultPath = newResultPath;
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

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = Path.GetFullPath(System.Windows.Forms.Application.ExecutablePath);
            openDialog.AddExtension = true;

            openDialog.Filter = "Results files (*.db)|*.db";

            if (openDialog.ShowDialog() == DialogResult.Cancel)
                return;


            ResultDbPath = openDialog.FileName;

            FillingResultsData();
        }

        private void FillingResultsData()
        {
            var loader = new LoadResultsFileDB();
            var scheme = loader.GetTablesSchemes(ResultDbPath).
                FirstOrDefault(x => x.Key == ResultType.nodes.ToString());

            List<TreeNode> results;

            if (!navigator.TrySearchNodes(NodeName.результаты, out results))
            {
                var rn = navigator.CreateRealNode(NodeName.результаты, "Результаты");

                //.SetContextMenu(rn);
                navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                prNodes[0].Nodes.Add(rn);
                results.Add(rn);
            }
            else
                results[0].Nodes.Clear();

            resultTimes = loader.GetValues(ResultDbPath, scheme.Key, "Time");


            foreach (var desc in scheme.Value)
            {
                var rn = navigator.CreateRealNode(NodeName.результат, $"{desc}");

                //var node = new TreeNode($"{desc}", 16, 16)
                //{ Tag = "6.1", Name = desc };

                var vn = navigator.CreateVirtualNode(NodeName.результат);
                rn.Nodes.Add(vn);
                results[0].Nodes.Add(rn);
            }
        }

        private void PresentResultsField(Result result, string resName, string tableName)
        {
            var scaleItems = resultsController.GetItems();
            resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.ToArray());
            resultsController.ResultsFieldsCreator.ScaleFactor = settingsConfig.Scale_scale;


            IEnumerable<ISurfaceElement> elems;

            if (project.ProjectType == TaskType.Volume | project.ProjectType == TaskType.Volume_mixed)
                elems = project.GetModelSurfaceElements(3);
            else
                elems = project.GetModelSurfaceElements(2);

            var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, tableName, resName, elems);
            var pre = presentersCreator.CreateSurfaceObjectsPresenter(elsResults);
            pre.Name = resName;

            VBOController.DeleteAllVBObjects();
            var vb = CreateVBObject(pre);
            VBOController.AddVbo(vb);
        }

        private Tuple<float, float> GetMaxMin(Result result, string tableName, string resName)
        {
            var max = (float)result.Data.Tables[tableName].Compute($"Max({resName})", "");
            var min = (float)result.Data.Tables[tableName].Compute($"Min({resName})", "");

            return new Tuple<float, float>(max, min);
        }

        private void ShowResultValue(ResultType resType, string resName, Result result)
        {
            IEnumerable<IModelObject> objs;

            if (resType == ResultType.nodes)
                objs = project.GetAllModelNodes();
            else
                objs = project.GetAllModelElements();

            foreach (var obj in objs)
            {
                if (obj.Color == settingsConfig.SelectObjectColor)
                {
                    var coord = obj.CalcCentr();
                    var res = result.GetValue((int)resType, obj.Number, resName);
                    DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

        //private async void ExportResultsAsync(IModelData modelData, Result result, ExportResultEventArgs args)
        //{
        //    try
        //    {
        //        var format = args.Extension.Split('-')[0];
        //        var formatedPath = $"{args.Path}\\ResultsExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

        //        await Task.Run(() =>
        //        {
        //            IEnumerable<IModelObject> objects;

        //            var objTypes = Converters.ConvertToObjsType(args.ExportObj);

        //            if (objTypes == ObjType.Узел)
        //                objects = modelData.ObjectData.NodesSet.Values;
        //            else
        //                objects = modelData.ObjectData.GetAllElements();

        //            resultsController.ResultsExporter.ExportObjectsResults(objects, result, args.ResName, formatedPath, format);
        //        });

        //        console.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
        //    }
        //    catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
        //}

        //private async void ExportGridAsync(IModelData modelData, ITaskData taskData, Result result, ExportResultEventArgs args)
        //{
        //    try
        //    {
        //        var format = args.Extension.Split('-')[0];
        //        var formatedPath = $"{args.Path}\\GridExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

        //        await Task.Run(() =>
        //        {
        //            IEnumerable<ISurfaceElement> elements;
        //            if (taskData.TaskType == TaskType.Volume)
        //                elements = modelData.ObjectData.E3DCollection.GetObjects();
        //            else
        //                elements = modelData.ObjectData.E2DCollection.GetObjects();

        //            var figures = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result,
        //                ResultType.nodes.ToString(), args.ResName, elements);
        //            resultsController.GridExporter.ExportGridSurfaces(figures, formatedPath, $".{args.Extension}");
        //        });

        //        console.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
        //    }
        //    catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
        //}

        //private async void CopyResultDBAsync(Result result, CopyResultDBEventArgs args)
        //{
        //    var path = args.DirPath + "\\temp.db";
        //    await Task.Run(() =>
        //    {
        //        var saver = new SaveResultsFileDb();
        //        saver.Save(new List<Result>() { result }, path, false);
        //    });
        //    console.PrintInfo($"созданный файл сохранен по пути: {path}", Color.Black);
        //}

        private void exportResultsMenuItem_Click(object sender, EventArgs e)
        {


            //if (ResultDbPath.Equals(string.Empty))
            //{
            //    console.PrintInfo($"Не указан путь к базе результатов. Загрузите результаты перед экспортом.", Color.Orange);
            //    return;
            //}

            // предварительная настройка шкалы
            //var scaleItems = GetScaleItems();
            //resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
            //resultsController.ResultsFieldsCreator.ScaleFactor = 1;

            // инициализация инфраструктуры для работы с результатами
            //var loader = new LoadResultsFileDB();
            //var scheme = loader.GetTablesSchemes(ResultDbPath);
            //var nodeNames = scheme.FirstOrDefault(x => x.Key == ResultType.nodes.ToString()).Value;
            //var elemNames = scheme.FirstOrDefault(x => x.Key == ResultType.elements.ToString()).Value;
            //var times = loader.GetValues(ResultDbPath, ResultType.nodes.ToString(), "Time").ToList();

            //var exportPage = new ExportControl() { Dock = DockStyle.Fill };
            //exportPage.ExportResultEvent += async (arg) =>
            //{
            //    var result = await Task.Run(() =>
            //    {
            //        var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
            //            ? new List<string> { ResultType.elements.ToString() }
            //            : new List<string> { ResultType.nodes.ToString() };
            //        return loader.GetResult(ResultDbPath, table, arg.Time);
            //    });

            //    if (arg.ExportType == ExportType.Results) ExportResultsAsync(project.ModelData, result, arg);
            //    else ExportGridAsync(project.ModelData, project.GeneralData, result, arg);
            //};
            //exportPage.CopyResultDBEvent += async (arg) =>
            //{
            //    var result = await Task.Run(() =>
            //    {
            //        var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
            //            ? new List<string> { ResultType.elements.ToString() }
            //            : new List<string> { ResultType.nodes.ToString() };
            //        return loader.GetResult(ResultDbPath, table, arg.Time);
            //    });

            //    CopyResultDBAsync(result, arg);
            //};

            //exportPage.SetTimes(times);
            //exportPage.SetNodeNames(nodeNames);
            //exportPage.SetElementNames(elemNames);

            //var exportForm = new Form()
            //{
            //    Owner = Application.OpenForms[0],
            //    TopMost = true,
            //    Size = exportPage.Size,
            //    Name = "export",
            //    Text = "Экспорт результатов",
            //    ShowIcon = false,
            //    ClientSize = exportPage.Size,
            //    Location = PointToScreen(Point.Empty)
            //};

            //exportForm.FormClosed += (ar1, ar2) => { exportPage = null; };
            //exportForm.Controls.Add(exportPage);
            //exportForm.Show();
        }

        //private void показатьЗначенияВЭлементахToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (показатьЗначенияВЭлементахToolStripMenuItem.Checked)
        //        settingsConfig.ShowElementsResultsValue = true;
        //    else
        //    {
        //        settingsConfig.ShowElementsResultsValue = false;
        //        DisplayText3DEvent = null;
        //        DisplayObjects();
        //    }
        //}
        //private void showNodeValueMenuItem_Click(object sender, EventArgs e)
        //{

        //    if (showNodeValueMenuItem.Checked)
        //        settingsConfig.ShowNodeResultsValue = true;
        //    else
        //    {
        //        settingsConfig.ShowNodeResultsValue = false;
        //        DisplayText3DEvent = null;
        //        DisplayObjects();
        //    }
        //}
    }
}
