using BaseModule.Navigator;
using BaseModule.Results.Animation;
using BaseModule.Results.Export;
using BaseModule.Results.GraphCreation;
using BaseModule.Results.ScaleControl;
using BasicControls.OpenFileDialogEx;
using BazisGUI.Utilities;
using Geometry;
using Gif.Components;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using ModelController;
using ModelControllerInterfaces;
using PostProc;
using PostProc.ScenePresenter;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Project.Results;
using Project.Results.IO;
using Project.Tasks;
using Project.Tasks.Functions;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx.Graph;

namespace BazisGUI
{
    public partial class ToolStripPage
    {
        ISceneScale scale;
        public event Action<object,string> LoadResultsEvent;
        public event Action<object> RemoveResultsEvent;
        public event Action<object> HideResultsEvent;
        public event Action<object,Result,int> ShowResultsEvent;
        public event Action<object,CreateAnimationEventArgs> CreateGIFAnimationEvent;
        public bool ShowResultsField { get; set; } = true;

        public bool ShowNodeResultsValue { get; set; } = false;

        public bool ShowElementsResultsValue { get; set; } = false;

        public bool MergeResultsValue { get; set; } = true;

        string ResultDbPath { get; set; } = string.Empty;

        IEnumerable<float> resultTimes;

        private bool showScale = true;
        public bool IsScaleMaxMinManual { get; set; } = false;

       enum ResultType { nodes, elements}

        PostProcController resultsController = new PostProcController();

        PostProcController ResultsController { get { return resultsController; } }    

        public IEnumerable<float> GetResultTimes()
        {
            foreach (var item in resultTimes)
            {
                yield return item;
            }
        }

        public void ShowScalePage()
        {
            var scPage = new ScalePage() { Dock = DockStyle.Fill };

            scPage.Max = scale.MaxValue;
            scPage.Min = scale.MinValue;

            scPage.SetUpMaxMinEvent += (ar) => { IsScaleMaxMinManual = ar; };

            scPage.IsMaxMinAuto = IsScaleMaxMinManual;

            scPage.Precision = scale.Precision;

            scPage.X_Coord = scale.Coord_X;
            scPage.Y_Coord = scale.Coord_Y;

            scPage.SetScaleSettingEvent += (ar1, ar2) =>
            {
                scale.Precision = ar2.Precision;
                scale.FillRange(ar2.Min,ar2.Max, ar2.Range);
            };
            scPage.ShowScaleEvent += (ar1, ar2) =>
            {
                var scenePage = basePage.ScenePage;
                scenePage.SceneControl.HideGeometryObj("DisplaySceneScale");

                if (ar2)
                {
                    scale.Coord_X = scPage.X_Coord;
                    scale.Coord_Y = scPage.Y_Coord;


                    scenePage.SceneControl.DisplaySceneScale(scale);
                }

                scenePage.SceneControl.DisplayObjects();
            };
            scPage.SetX_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_X = (int)ar2;
            };
            scPage.SetY_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_Y = (int)ar2;
            };
            
            var scForm = new Form() {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Size = scPage.Size, 
                Name = "Scale", 
                Text = "Шкала значений", 
                ShowIcon = false,
                ClientSize = scPage.Size
            };

            scForm.Controls.Add(scPage);
            scForm.Show();
        }

        public void CreateGraph(IModelData modelData)
        {
            var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
            var loader = new LoadResultsFileDB();
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                CreateTimeGraph(loader,ar2.Objects, modelData.ObjectData);
            };
            grPage.CreatePathGraphEvent += (ar1, ar2) =>
                {

                    var dbTable = Converters.ConvertToDBTablesNames(ar2.Objects);
                    var result = loader.GetResult(ResultDbPath, new List<string>() { dbTable }, ar2.Time);

                    CreatePathGraph(result, dbTable, modelData);
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
            scForm.FormClosed += (ar1, ar2) => { basePage.ScenePage.ClearAllGeometryDataOnScene(); };
            scForm.Controls.Add(grPage);
            scForm.Show();

        }

        public void SetAnimation(AnimationPage animationPage)
        {

            animationPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (basePage.NavigatorControl.GetSelectedNode()?.Level == 1)
                {
                    var loader = new LoadResultsFileDB();
                    var result = loader.GetResult(ResultDbPath,
                        new List<string>() 
                        { 
                            ResultType.nodes.ToString(),
                            ResultType.elements.ToString()
                        }, ar2.Time);
                    ShowResultsEvent?.Invoke(this, result, ar2.ScaleFactor);
    
                }

                else basePage.ConsoleControl.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            animationPage.CreateGIFAnimationEvent += (arg1, arg2) => 
            {
                CreateGIFAnimationEvent?.Invoke(this, arg2);
            };
            animationPage.SaveScreenShotEvent += (ar1) => { basePage.CreateScreenShot(ar1); };
        }

        public void ShowAnimation()
        {   
            var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];

            EmbeddedSplitContainer.SplitterDistance = EmbeddedSplitContainer.Panel1.Width - anPage.Width;         
            EmbeddedSplitContainer.Panel2Collapsed = false;
        }

        public void CreateGIFAnimation(IGeneralData generalData, IModelData modelData, CreateAnimationEventArgs args)
        {
            try
            {
                var outputFilePath = $@"{generalData.Path}\results.gif";

                AnimatedGifEncoder e = new AnimatedGifEncoder();

                e.Start(outputFilePath);
                e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);

                var loader = new LoadResultsFileDB();

                var tables = new List<string>();
                basePage.NavigatorControl.TrySearchNodes(NodeType.результаты.ToString(), out List<TreeNode> nodes);
                foreach (TreeNode item in nodes[0].Nodes)
                    tables.Add(item.Text);


                for (int i = 0; i < args.Times.Length; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, args.Times[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    ShowResults(generalData, modelData, result, args.ScaleFactor);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{generalData.Path}\{image}.bmp";
                    basePage.CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)args.Times.Length * 100).ToString("#.##");
                        basePage.ConsoleControl.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }
                    File.Delete(imagePath);
                }
                e.Finish();
                basePage.ConsoleControl.PrintInfo("GIF анимация создана", Color.Green);
            }
            catch (Exception ex)
            {
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
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

        public void ShowResults(IGeneralData generalData,IModelData modelData,  Result result, int scaleFactor)
        {
            try
            {
                var scenePage = basePage.ScenePage;
                var resName = basePage.NavigatorControl.GetSelectedNode().Name;
                var tableName = ResultType.nodes.ToString();

                scale.Title = result.TaskKind.ToString();
                scale.Info = $"{resName} {result.Time}";

                if (MergeResultsValue)
                    MergeResults(generalData, modelData,result);

                if (!IsScaleMaxMinManual)
                    SetMaxMinAuto(result, tableName, resName);

                if (ShowResultsField)
                {
                    scenePage.ClearAllGeometryDataOnScene();
                    scenePage.ClearAllMeshDataOnScene();

                    var presenter = CreateResultsField(generalData,modelData, result, scaleFactor, resName, tableName);
                    scenePage.CreateObjectsOnScene(ObjType.Поверхность.ToString(), presenter);
                }

                if (ShowNodeResultsValue)
                {
                    scenePage.SceneControl.HideDisplayText3D();
                    ShowResultValue(modelData, ResultType.nodes, resName, result);
                }


                if (ShowElementsResultsValue)
                {
                    scenePage.SceneControl.HideDisplayText3D();
                    ShowResultValue(modelData,ResultType.elements, resName, result);
                }


                if (showScale)
                {
                    scenePage.SceneControl.HideGeometryObj("DisplaySceneScale");
                    scenePage.SceneControl.DisplaySceneScale(scale);
                }

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                basePage.ConsoleControl.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }

        private IObjsPresenter CreateResultsField(IGeneralData generalData,IModelData modelData, Result result, int scaleFactor, string resName, string tableName)
        {
            var scaleItems = GetScaleItems();
            resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
            resultsController.ResultsFieldsCreator.ScaleFactor = scaleFactor;

            IEnumerable<ISurfaceElement> elems;

            if (generalData.TaskType == TaskType.Volume)
                elems = modelData.ObjectData.E3DCollection.GetObjects();
            else
                elems = modelData.ObjectData.E2DCollection.GetObjects();

            var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, tableName, resName, elems);
            return basePage.ScenePage.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults);
        }

        private ItemRange[] GetScaleItems()
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

        private void SetMaxMinAuto(Result result, string tableName, string resName)
        {
            var max = (float)result.Data.Tables[tableName].Compute($"Max({resName})", "");
            var min = (float)result.Data.Tables[tableName].Compute($"Min({resName})", "");

            scale.FillRange(min, max, 10);
        }

        private async void CreatePathGraph(Result result, string table,IModelData modelData)
        {
            try
            {
                var scenePage = basePage.ScenePage;
                if (basePage.NavigatorControl.GetSelectedNode()?.Level != 2)
                {
                    throw new Exception("Выберите вид результатов в разделе результаты");
                }

                scenePage.ClearAllDataOnScene();
                //scenePage.PresentAllModelObjectsToScene();
                //scenePage.SelectedObjects = ObjType.Узел.ToString();

                var objs = await basePage.CreatePathAsync(modelData);

                var selNode = basePage.NavigatorControl.GetSelectedNode();
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
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private async void CreateTimeGraph(LoadResultsFileDB loader, GraphObjects objsType, IObjectsData objectsData)
        {
            try
            {
                var scenePage = basePage.ScenePage;
                if (basePage.NavigatorControl.GetSelectedNode()?.Level != 1)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                scenePage.ClearAllDataOnScene();
                //scenePage.PresentAllModelObjectsToScene();
                //scenePage.SelectedObjects = objsType.ToString();

                var objs = await SelectObjectsAsync(objsType, objectsData);

                if (objs.Count == 0)
                    throw new Exception("Не выбран ни один объект!");

                var selNode = basePage.NavigatorControl.GetSelectedNode();
                var resDes = selNode.Name;

                var dbTable = Converters.ConvertToDBTablesNames(objsType);
                var times = loader.GetValues(ResultDbPath, dbTable, "Time");

                var grDataAr = new List<GraphData>();
                Random random = new Random();

                foreach (var obj in objs)
                {
                    var grPoints = new List<GraphPoint>();

                    basePage.ConsoleControl.PrintInfo($"Идет построение графика для объекта {obj.ObjType} {obj.Number}, подождите немного...", Color.Red); ;

                    foreach (var time in times)
                    {
                        //var res = 0.0f;
                        var result = loader.GetResult(ResultDbPath, new List<string>() { dbTable }, time);

                        var res = result.GetValue(dbTable, obj.Number, resDes);

                        var grPoint = new GraphPoint(result.Time, res);
                        grPoints.Add(grPoint);
                    }

                    scenePage.SceneControl.DisplayText3D($"{objsType}_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"{objsType}_{obj.Number}", color, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                scenePage.SceneControl.DisplayObjects();
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
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        public async Task<List<IModelObject>> SelectObjectsAsync(GraphObjects objType, IObjectsData objsData)
        {
            var nodes = new List<IModelObject>();
            basePage.PressedKey = Keys.None;
            var scenePage = basePage.ScenePage;
            scenePage.SceneControl.DisplayText2D(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения", Color.Black, new Point2D(10, 10));
            scenePage.SceneControl.DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (basePage.PressedKey == Keys.E)
                    {
                        var objs = ObjectsProvider.GraphPageProvider(objsData, objType);
                        nodes = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToList();
                        break;
                    }
                    if (basePage.PressedKey == Keys.Escape)
                    {
                        Invoke(new Action(() =>
                        {
                            basePage.ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                        }));
                        break;
                    }
                }
            });
            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.DisplayObjects();
            basePage.PressedKey = Keys.None;
            return nodes;
        }

        public void PresentResultsInfo(string fileName)
        {
            ResultDbPath = fileName;

            if(fileName != "")
            {
                var loader = new LoadResultsFileDB();
                var scheme = loader.GetTablesSchemes(fileName).
                    FirstOrDefault(x => x.Key == ResultType.nodes.ToString());

                basePage.NavigatorControl.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
                nodes[0].Nodes.Clear();

                resultTimes = loader.GetValues(fileName, scheme.Key, "Time");

                foreach (var desc in scheme.Value)
                {
                    var rn = basePage.NavigatorControl.CreateRealNode(NodeType.Результат, $"{desc}");
                    rn.ImageIndex = 14;
                    rn.SelectedImageIndex = 14;
                    //var node = new TreeNode($"{desc}", 16, 16)
                    //{ Tag = "6.1", Name = desc };

                    var vn = basePage.NavigatorControl.CreateVirtualNode(NodeType.Результат);
                    rn.Nodes.Add(vn);
                    nodes[0].Nodes.Add(rn);
                }

                //var pAnPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];

                //var anPage = pAnPage.AnimationPage;

                //anPage.ClearResultsItems();

    

                //if (times.Count() != 0)
                //    anPage.ShowResultsTimeSteps(times.ToList());
            }

        }

        public void MergeResults(IGeneralData generalData, IModelData modelData,  Result result)
        {
            try
            {
                var scenePage = basePage.ScenePage;
                IEnumerable<IElement> elements;
                if (generalData.TaskType == TaskType.Volume)
                    elements = modelData.ObjectData.E3DCollection.GetObjects();
                else
                    elements = modelData.ObjectData.E2DCollection.GetObjects();


                    var interfaceNodes = ModelController.InterfacedNodesFinder.Find(elements);

                    basePage.ConsoleControl.PrintInfo($"Выполняется пересчет на узлы", Color.Black);
                    basePage.ConsoleControl.PrintInfo("", Color.Black);

                    var resNames = result.Data.Tables[(int)ResultType.elements].GetTableSchema();

                    for (int i = 1; i < resNames.Length; i++)
                    {
                        resultsController.ResultsMerger.Merge(interfaceNodes, resNames[i], result);

                        Invoke(new Action(() =>
                        {
                            basePage.ConsoleControl.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                        }));
                    }

                    basePage.ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    basePage.ConsoleControl.PrintInfo($"В ходе пересчета возникла ошибка: {ex.Message}", Color.Red);
                }));
            }
        }

        private void ShowResultValue(IModelData modelData, ResultType tableType, string resName, Result result)
        {
            IEnumerable<IModelObject> objs;

            var scenePage = basePage.ScenePage;

            if (tableType == ResultType.nodes)
                objs = modelData.ObjectData.NodesSet.Values;
            else
                objs = modelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.Color == scenePage.SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentr();
                    var res = result.GetValue((int)tableType, obj.Number, resName);
                    scenePage.SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }


        public void HideResults(IModelData modelData)
        {
            var scenePage = basePage.ScenePage;

            scenePage.ClearAllDataOnScene();

            scenePage.PresentAllModelObjectsToScene(modelData);

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        public void RemoveResults(IModelData modelData)
        {
            basePage.NavigatorControl.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
            nodes[0].Nodes["ПоУзлам"].Nodes.Clear();
            nodes[0].Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

            var scenePage = basePage.ScenePage;

            scenePage.ClearAllDataOnScene();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                scenePage.CreateObjectsOnScene(item.ToString(), scenePage.CreateObjectsPresentor(modelData,item));

            scenePage.SceneControl.DisplayObjects();

            var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];
            anPage.AnimationPage.ClearResultsItems();
        }

        public void ShowExportResultsPage(IModelData modelData, IGeneralData generalData)
        {
            if (ResultDbPath.Equals(string.Empty))
            {
                basePage.ConsoleControl.PrintInfo($"Не указан путь к базе результатов. Загрузите результаты перед экспортом.", Color.Orange);
                return;
            }

            // предварительная настройка шкалы
            var scaleItems = GetScaleItems();
            resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
            resultsController.ResultsFieldsCreator.ScaleFactor = 1;

            // инициализация инфраструктуры для работы с результатами
            var loader = new LoadResultsFileDB();
            var scheme = loader.GetTablesSchemes(ResultDbPath);
            var nodeNames = scheme.FirstOrDefault(x => x.Key == ResultType.nodes.ToString()).Value;
            var elemNames = scheme.FirstOrDefault(x => x.Key == ResultType.elements.ToString()).Value;
            var times = loader.GetValues(ResultDbPath, ResultType.nodes.ToString(), "Time").ToList();

            var exportPage = new ExportControl() { Dock = DockStyle.Fill };
            exportPage.ExportResultEvent += async (arg) =>
            {
                var result = await Task.Run(() =>
                {
                    var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
                        ? new List<string> { ResultType.elements.ToString() }
                        : new List<string> { ResultType.nodes.ToString() };
                    return loader.GetResult(ResultDbPath, table, arg.Time);
                });

                if (arg.ExportType == ExportType.Results) ExportResultsAsync(modelData, result, arg);
                else ExportGridAsync(modelData,generalData, result, arg);
            };
            exportPage.CopyResultDBEvent += async (arg) =>
            {
                var result = await Task.Run(() =>
                {
                    var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
                        ? new List<string> { ResultType.elements.ToString() }
                        : new List<string> { ResultType.nodes.ToString() };
                    return loader.GetResult(ResultDbPath, table, arg.Time);
                });

                CopyResultDBAsync(result, arg);
            };

            exportPage.SetTimes(times);
            exportPage.SetNodeNames(nodeNames);
            exportPage.SetElementNames(elemNames);

            var exportForm = new Form()
            {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Size = exportPage.Size,
                Name = "export",
                Text = "Экспорт результатов",
                ShowIcon = false,
                ClientSize = exportPage.Size,
                Location = basePage.ScenePage.PointToScreen(Point.Empty)
            };

            exportForm.FormClosed += (ar1, ar2) => { exportPage = null; };
            exportForm.Controls.Add(exportPage);
            exportForm.Show();
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

                basePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private async void ExportGridAsync(IModelData modelData,IGeneralData generalData, Result result, ExportResultEventArgs args)
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

                basePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private async void CopyResultDBAsync(Result result, CopyResultDBEventArgs args)
        {
            var path = args.DirPath + "\\temp.db";
            await Task.Run(() => 
            { 
                var saver = new SaveResultsFileDb(); 
                saver.Save(new List<Result>() { result }, path, false); 
            });
            basePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {path}", Color.Black);
        }
    }   
}
