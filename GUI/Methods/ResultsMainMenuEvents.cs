using BaseModule.Navigator;
using BaseModule.Results.Export;
using BaseModule.Results.GraphCreation;
using BaseModule.Results.ScaleControl;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using PostProc;
using Project.Interfaces.Tasks;
using Project.Interfaces;
using Project.Results;
using Project.Results.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx.Graph;
using BazisGUI.Scene;
using OperationalController;

namespace BazisGUI
{
    public partial class BaseForm
    {
        string ResultDbPath { get; set; } = string.Empty;// в дереве

        IEnumerable<float> resultTimes;

        public IEnumerable<float> GetResultTimes()
        {
            foreach (var item in resultTimes)
            {
                yield return item;
            }
        }
        private void усреднитьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (усреднитьРезультатыToolStripMenuItem.Checked)
                settingsConfig.MergeResultsValue = true;
            else
            {
                settingsConfig.MergeResultsValue = false;
            }
        }
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
        private void настройкиШкалыMenuItem_Click(object sender, EventArgs e)
        {
            var scPage = new ScalePage() { Dock = DockStyle.Fill };

            scPage.Max = settingsConfig.Scale_MaxValue;
            scPage.Min = settingsConfig.Scale_MinValue;

            scPage.SetUpMaxMinEvent += (ar) => { settingsConfig.IsScaleMaxMinManual = ar; };

            scPage.IsMaxMinAuto = settingsConfig.IsScaleMaxMinManual;

            scPage.Precision = settingsConfig.Scale_Precision;

            scPage.X_Coord = settingsConfig.Scale_X_Coord;
            scPage.Y_Coord = settingsConfig.Scale_Y_Coord;

            scPage.SetScaleSettingEvent += (ar1, ar2) =>
            {
                settingsConfig.Scale_Precision = ar2.Precision;
                settingsConfig.Scale_MaxValue = ar2.Max;
                settingsConfig.Scale_MinValue = ar2.Min;
                settingsConfig.Scale_Intervals = ar2.Range;
            };

            scPage.SetX_PositionEvent += (ar1, ar2) =>
            {
                settingsConfig.Scale_X_Coord = (int)ar2;
            };
            scPage.SetY_PositionEvent += (ar1, ar2) =>
            {
                settingsConfig.Scale_Y_Coord = (int)ar2;
            };

            scPage.SetScaleEvent += (ar1, ar2) =>
            {
                settingsConfig.Scale_scale = int.Parse(ar2);
            };

            var scForm = new Form()
            {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Size = scPage.Size,
                Name = "Scale",
                Text = "Настройки шкалы значений",
                ShowIcon = false,
                ClientSize = scPage.Size
            };

            scForm.Controls.Add(scPage);
            scForm.Show();
        }
        private void createPlotMenuItem_Click(object sender, EventArgs e)
        {
            var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
            var loader = new LoadResultsFileDB();
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                CreateTimeGraph(loader, ar2.Objects, project.ModelData.ObjectData);
            };
            grPage.CreatePathGraphEvent += (ar1, ar2) =>
            {

                var dbTable = Converters.ConvertToDBTablesNames(ar2.Objects);
                var result = loader.GetResult(ResultDbPath, new List<string>() { dbTable }, ar2.Time);

                CreatePathGraph(result, dbTable);
            };

            var times = loader.GetValues(ResultDbPath, ResultType.nodes.ToString(), "Time");

            grPage.SetResultsItems(times.ToList());

            var scForm = new Form()
            {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Text = "Построить график",
                Size = grPage.Size,
                ShowIcon = false,
                ClientSize = grPage.Size
            };
            scForm.FormClosed += (ar1, ar2) => { ClearAllGeometryDataOnScene(); };
            scForm.Controls.Add(grPage);
            scForm.Show();
        }

        private async void CreatePathGraph(Result result, string table)
        {
            try
            {
                if (navigator.GetSelectedNode()?.Level != 2)
                {
                    throw new Exception("Выберите вид результатов в разделе результаты");
                }

                ClearAllDataOnScene();
                //PresentAllModelObjectsToScene();
                //SelectedObjects = ObjType.Узел.ToString();

                var objs = await CreatePathAsync();

                var selNode = navigator.GetSelectedNode();
                var resDes = selNode.Name;

                var pathPoints = new List<Point3D>();
                var path = 0.0f;
                var grPoints = new List<GraphPoint>();

                if (result != null)
                    foreach (var obj in objs)
                    {
                        var res = result.GetValue(table, obj.Number, resDes);
                        var point = obj.CalcCentr();

                        var delta = new Point3D();
                        if (pathPoints.Count > 0)
                            delta = point.Sub(pathPoints.Last());
                        path += Vector.GetVectorLenght(delta);

                        pathPoints.Add(obj.CalcCentr());

                        var grPoint = new GraphPoint(path, res);
                        grPoints.Add(grPoint);
                    }

                if (grPoints.Count != 0)
                {
                    var grData = new GraphData(resDes, Color.Orange, "мм", resDes, grPoints.ToArray());
                    var grContainer = new GraphContainer();

                    grContainer.CreateGraphData("Набор результатов по расстоянию", new List<GraphData>() { grData }, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        Owner = Application.OpenForms[0],
                        TopMost = true,
                        Text = $"График {resDes} - координата",
                        ShowIcon = false,
                        ClientSize = grContainer.Size
                    };
                    form.Controls.Add(grContainer);
                    form.Show();
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        private void createFieldMenuItem_Click(object sender, EventArgs e)
        {
            if (createFieldMenuItem.Checked)
                settingsConfig.ShowResultsField = true;
            else
            {
                settingsConfig.ShowResultsField = false;
            }
        }
        private void показатьЗначенияВЭлементахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (показатьЗначенияВЭлементахToolStripMenuItem.Checked)
                settingsConfig.ShowElementsResultsValue = true;
            else
            {
                settingsConfig.ShowElementsResultsValue = false;
                DisplayText3DEvent = null;
                DisplayObjects();
            }
        }
        private void showNodeValueMenuItem_Click(object sender, EventArgs e)
        {

            if (showNodeValueMenuItem.Checked)
                settingsConfig.ShowNodeResultsValue = true;
            else
            {
                settingsConfig.ShowNodeResultsValue = false;
                DisplayText3DEvent = null;
                DisplayObjects();
            }
        }
        private void loadResultsMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = dataController.OpenResults();

            PresentResultsInfo(fileName);
        }

        public void PresentResultsInfo(string fileName)
        {
            ResultDbPath = fileName;

            if (fileName != "")
            {
                var loader = new LoadResultsFileDB();
                var scheme = loader.GetTablesSchemes(fileName).
                    FirstOrDefault(x => x.Key == ResultType.nodes.ToString());

                navigator.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
                nodes[0].Nodes.Clear();

                resultTimes = loader.GetValues(fileName, scheme.Key, "Time");

                foreach (var desc in scheme.Value)
                {
                    var rn = navigator.CreateRealNode(NodeType.Результат, $"{desc}");
                    rn.ImageIndex = 14;
                    rn.SelectedImageIndex = 14;
                    //var node = new TreeNode($"{desc}", 16, 16)
                    //{ Tag = "6.1", Name = desc };

                    var vn = navigator.CreateVirtualNode(NodeType.Результат);
                    rn.Nodes.Add(vn);
                    nodes[0].Nodes.Add(rn);
                }
            }

        }

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



        private IObjsPresenter CreateResultsField(Result result, string resName, string tableName)
        {
            IEnumerable<ISurfaceElement> elems;


            if (project.GeneralData.TaskType == TaskType.Volume)
                elems = project.ModelData.ObjectData.E3DCollection.GetObjects();
            else
                elems = project.ModelData.ObjectData.E2DCollection.GetObjects();

            var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, tableName, resName, elems);
            return presentersCreator.CreateSurfaceObjectsPresenter(elsResults);
        }

        private ItemRange[] GetScaleItems(SceneScale scale)
        {
            var itemRanges = new ItemRange[scale.Count()];

            var scaleItems = scale.ToArray();

            for (int i = 0; i < scaleItems.Length; i++)
            {
                itemRanges[i] = new ItemRange()
                {
                    Max = scaleItems[i].Max,
                    Min = scaleItems[i].Min,
                    Color = scaleItems[i].Color
                };
            }
            return itemRanges;
        }

        private Tuple<float, float> GetMaxMin(Result result, string tableName, string resName)
        {
            var max = (float)result.Data.Tables[tableName].Compute($"Max({resName})", "");
            var min = (float)result.Data.Tables[tableName].Compute($"Min({resName})", "");

            return new Tuple<float, float>(max, min);
        }



        private async void CreateTimeGraph(LoadResultsFileDB loader, GraphObjects objsType, IObjectsData objectsData)
        {
            try
            {
                if (navigator.GetSelectedNode()?.Level != 1)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                ClearAllDataOnScene();
                //PresentAllModelObjectsToScene();
                //SelectedObjects = objsType.ToString();

                var objs = await SelectObjectsAsync(objsType, objectsData);

                if (objs.Count == 0)
                    throw new Exception("Не выбран ни один объект!");

                var selNode = navigator.GetSelectedNode();
                var resDes = selNode.Name;

                var dbTable = Converters.ConvertToDBTablesNames(objsType);
                var times = loader.GetValues(ResultDbPath, dbTable, "Time");

                var grDataAr = new List<GraphData>();
                Random random = new Random();

                foreach (var obj in objs)
                {
                    var grPoints = new List<GraphPoint>();

                    console.PrintInfo($"Идет построение графика для объекта {obj.ObjType} {obj.Number}, подождите немного...", Color.Red); ;

                    foreach (var time in times)
                    {
                        //var res = 0.0f;
                        var result = loader.GetResult(ResultDbPath, new List<string>() { dbTable }, time);

                        var res = result.GetValue(dbTable, obj.Number, resDes);

                        var grPoint = new GraphPoint(result.Time, res);
                        grPoints.Add(grPoint);
                    }

                    DisplayText3D($"{objsType}_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"{objsType}_{obj.Number}", color, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                DisplayObjects();
                var grContainer = new GraphContainer();

                if (grDataAr.Count != 0)
                {
                    grContainer.CreateGraphData("Набор результатов по времени", grDataAr, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        Owner = Application.OpenForms[0],
                        TopMost = true,
                        Text = $"График {resDes} - время",
                        ShowIcon = false,
                        ClientSize = grContainer.Size
                    };


                    form.Controls.Add(grContainer);
                    form.ClientSize = grContainer.Size;
                    form.Show();
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        public async Task<List<IModelObject>> SelectObjectsAsync(GraphObjects objType, IObjectsData objsData)
        {
            var nodes = new List<IModelObject>();
            PressedKey = Keys.None;

            DisplayText2D(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения", Color.Black, new Point2D(10, 10));
            DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                    {
                        var objs = ObjectsProvider.GraphPageProvider(objsData, objType);
                        nodes = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).ToList();
                        break;
                    }
                    if (PressedKey == Keys.Escape)
                    {
                        Invoke(new Action(() =>
                        {
                            console.PrintInfo("Операция отменена", Color.Black);
                        }));
                        break;
                    }
                }
            });
            DisplayText2DEvent = null;
            DisplayObjects();
            PressedKey = Keys.None;
            return nodes;
        }

        public void MergeResults(Result result)
        {
            try
            {
                Dictionary<int,List<int>> interfaceNodes;
                if (project.GeneralData.TaskType == TaskType.Volume)
                    interfaceNodes = project.FindInterfacedNodes(3);
                else
                    interfaceNodes = project.FindInterfacedNodes(2);

                console.PrintInfo($"Выполняется пересчет на узлы", Color.Black);
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

        private void ShowResultValue(ResultType tableType, string resName, Result result)
        {
            IEnumerable<IModelObject> objs;

            if (tableType == ResultType.nodes)
                objs = project.ModelData.ObjectData.NodesSet.Values;
            else
                objs = project.ModelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.Color == settingsConfig.SelectObjectColor)
                {
                    var coord = obj.CalcCentr();
                    var res = result.GetValue((int)tableType, obj.Number, resName);
                    DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

        private async void ExportResultsAsync(IModelData modelData, Result result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\ResultsExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

                await Task.Run(() =>
                {
                    IEnumerable<IModelObject> objects;

                    var objTypes = Converters.ConvertToObjsType(args.ExportObj);

                    if (objTypes == ObjType.Узел)
                        objects = modelData.ObjectData.NodesSet.Values;
                    else
                        objects = modelData.ObjectData.GetAllElements();

                    resultsController.ResultsExporter.ExportObjectsResults(objects, result, args.ResName, formatedPath, format);
                });

                console.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
        }

        private async void ExportGridAsync(IModelData modelData, IGeneralData generalData, Result result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\GridExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

                await Task.Run(() =>
                {
                    IEnumerable<ISurfaceElement> elements;
                    if (generalData.TaskType == TaskType.Volume)
                        elements = modelData.ObjectData.E3DCollection.GetObjects();
                    else
                        elements = modelData.ObjectData.E2DCollection.GetObjects();

                    var figures = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result,
                        ResultType.nodes.ToString(), args.ResName, elements);
                    resultsController.GridExporter.ExportGridSurfaces(figures, formatedPath, $".{args.Extension}");
                });

                console.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { console.PrintInfo(ex.Message, Color.Red); }
        }

        private async void CopyResultDBAsync(Result result, CopyResultDBEventArgs args)
        {
            var path = args.DirPath + "\\temp.db";
            await Task.Run(() =>
            {
                var saver = new SaveResultsFileDb();
                saver.Save(new List<Result>() { result }, path, false);
            });
            console.PrintInfo($"созданный файл сохранен по пути: {path}", Color.Black);
        }
    }
}
