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
    public partial class ResultsPage: ToolStripPage
    {
        ISceneScale scale;
        public event Action<object,string> LoadResultsEvent;

        public bool ShowResultsField { get; set; } = true;

        public bool ShowNodeResultsValue { get; set; } = false;

        public bool ShowElementsResultsValue { get; set; } = false;

        public bool MergeResultsValue { get; set; } = true;

        string ResultDbPath { get; set; } = string.Empty;

        private bool showScale = true;
        public bool IsScaleMaxMinManual { get; set; } = false;

       enum ResultType { nodes, elements}

        PostProcController resultsController;

        IGeneralData GeneralData { get { return BasePage.GetGeneralData(); } }

        IModelController ModelController
        {
            get { return BasePage.ScenePage.GetModelController(); }
        }

        IModelData ModelData
        {
            get { return ModelController.ModelData; }
        }

        public void SetResultsController(PostProcController resultsController)
        {
            this.resultsController = resultsController;
        }

        public ResultsPage()
        {
            InitializeComponent();

            var navigator = BasePage.NavigatorControl;

            navigator.TreeView.Nodes.Add(new TreeNode("Набор результатов", 14, 14) { Name = "Набор результатов", Tag = 6, ContextMenuStrip = resultsMenuStrip });

            resultsMenuStrip.Enabled = true;

            selectToolStrip.Location = new Point(3, 0);
            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);

            var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];
            anPage.BringToFront();
            SetAnimation(anPage.AnimationPage);
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
                var scenePage = BasePage.ScenePage;
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

        public void CreateGraph()
        {
            var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
            var loader = new LoadResultsFileDB();
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                CreateTimeGraph(loader,ar2.Objects);
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
            scForm.FormClosed += (ar1, ar2) => { BasePage.ScenePage.ClearAllGeometryDataOnScene(); };
            scForm.Controls.Add(grPage);
            scForm.Show();

        }

        public void SetAnimation(AnimationPage animationPage)
        {

            animationPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (BasePage.NavigatorControl.TreeView.SelectedNode?.Level == 1)
                {
                    var loader = new LoadResultsFileDB();
                    var result = loader.GetResult(ResultDbPath,
                        new List<string>() 
                        { 
                            ResultType.nodes.ToString(),
                            ResultType.elements.ToString()
                        }, ar2.Time);
                    ShowResults(result, ar2.ScaleFactor);
                }

                else BasePage.ConsoleControl.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            animationPage.CreateGIFAnimationEvent += (arg1, arg2) => { CreateGIFAnimation(arg2); };
            animationPage.SaveScreenShotEvent += (ar1) => { BasePage.CreateScreenShot(ar1); };
        }

        public void ShowAnimation()
        {   
            var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];

            EmbeddedSplitContainer.SplitterDistance = EmbeddedSplitContainer.Panel1.Width - anPage.Width;         
            EmbeddedSplitContainer.Panel2Collapsed = false;
        }

        private void CreateGIFAnimation(CreateAnimationEventArgs args)
        {
            try
            {
                var outputFilePath = $@"{GeneralData.Path}\results.gif";

                AnimatedGifEncoder e = new AnimatedGifEncoder();

                e.Start(outputFilePath);
                e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);

                var loader = new LoadResultsFileDB();

                var tables = new List<string>();
                foreach (TreeNode item in BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes)
                    tables.Add(item.Text);
                

                for (int i = 0; i < args.Times.Length; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, args.Times[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    ShowResults(result, args.ScaleFactor);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{GeneralData.Path}\{image}.bmp";
                    BasePage.CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)args.Times.Length * 100).ToString("#.##");
                        BasePage.ConsoleControl.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }
                    File.Delete(imagePath);
                }
                e.Finish();
                BasePage.ConsoleControl.PrintInfo("GIF анимация создана", Color.Green);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
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

        private void ShowResults(Result result, int scaleFactor)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                var resName = BasePage.NavigatorControl.TreeView.SelectedNode.Name;
                var tableName = ResultType.nodes.ToString();

                scale.Title = result.TaskKind.ToString();
                scale.Info = $"{resName} {result.Time}";

                if (MergeResultsValue)
                    MergeResults(result);

                if (!IsScaleMaxMinManual)
                    SetMaxMinAuto(result, tableName, resName);
                
                if(ShowResultsField)
                {
                    scenePage.ClearAllGeometryDataOnScene();
                    scenePage.ClearAllMeshDataOnScene();

                    var presenter = CreateResultsField(result, scaleFactor, resName, tableName);
                    scenePage.CreateObjectsOnScene(ObjType.Поверхность.ToString(), presenter);
                }

                if (ShowNodeResultsValue)
                {
                    scenePage.SceneControl.HideDisplayText3D();
                    ShowResultValue(ResultType.nodes, resName, result);
                }


                if (ShowElementsResultsValue)
                {
                    scenePage.SceneControl.HideDisplayText3D();
                    ShowResultValue(ResultType.elements, resName, result);
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
                BasePage.ConsoleControl.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }

        private IObjsPresenter CreateResultsField(Result result, int scaleFactor, string resName, string tableName)
        {
            var scaleItems = GetScaleItems();
            resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
            resultsController.ResultsFieldsCreator.ScaleFactor = scaleFactor;

            IEnumerable<ISurfaceElement> elems;

            if (GeneralData.TaskType == TaskType.Volume)
                elems = ModelData.ObjectData.E3DCollection.GetObjects();
            else
                elems = ModelData.ObjectData.E2DCollection.GetObjects();

            var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, tableName, resName, elems);
            return ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults, false);
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

        private async void CreatePathGraph(Result result,string table)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                if (BasePage.NavigatorControl.TreeView.SelectedNode?.Level != 2)
                {
                    throw new Exception("Выберите вид результатов в разделе результаты");
                }

                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene();
                scenePage.SelectedObjects = ObjType.Узел.ToString();

                var objs = await BasePage.CreatePathAsync();

                var selNode = BasePage.NavigatorControl.TreeView.SelectedNode;
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
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private async void CreateTimeGraph(LoadResultsFileDB loader, GraphObjects objsType)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                if (BasePage.NavigatorControl.TreeView.SelectedNode?.Level != 1)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene();
                scenePage.SelectedObjects = objsType.ToString();

                var objs = await SelectObjectsAsync(objsType);

                if(objs.Count == 0)
                    throw new Exception("Не выбран ни один объект!");

                var selNode = BasePage.NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

                var dbTable = Converters.ConvertToDBTablesNames(objsType);
                var times = loader.GetValues(ResultDbPath, dbTable, "Time");

                var grDataAr = new List<GraphData>();
                Random random = new Random();

                foreach (var obj in objs)
                {
                    var grPoints = new List<GraphPoint>();

                    BasePage.ConsoleControl.PrintInfo($"Идет построение графика для объекта {obj.ObjType} {obj.Number}, подождите немного...", Color.Red);;

                    foreach (var time in times)
                    {
                        //var res = 0.0f;
                        var result = loader.GetResult(ResultDbPath, new List<string>() { dbTable}, time);

                        var res = result.GetValue(dbTable,obj.Number, resDes);

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
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        public async Task<List<IModelObject>> SelectObjectsAsync(GraphObjects objType)
        {
            var nodes = new List<IModelObject>();
            BasePage.PressedKey = Keys.None;
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.DisplayText2D(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения", Color.Black, new Point2D(10, 10));
            scenePage.SceneControl.DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (BasePage.PressedKey == Keys.E)
                    {
                        var objs = ObjectsProvider.GraphPageProvider(ModelData.ObjectData,objType);
                        nodes = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToList();
                        break;
                    }
                    if(BasePage.PressedKey == Keys.Escape)
                    {
                        Invoke(new Action(() =>
                        {
                            BasePage.ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                        }));
                        break;
                    }
                }
            });
            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.DisplayObjects();
            BasePage.PressedKey = Keys.None;
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


                BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes.Clear();

                foreach (var desc in scheme.Value)
                {
                    var node = new TreeNode($"{desc}", 16, 16)
                    { Tag = "6.1", Name = desc };

                    BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes.Add(node);
                }

                var pAnPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];

                var anPage = pAnPage.AnimationPage;

                anPage.ClearResultsItems();

                var times = loader.GetValues(fileName, scheme.Key, "Time");

                if (times.Count() != 0)
                    anPage.ShowResultsTimeSteps(times.ToList());
            }

        }

        public void MergeResults(Result result)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                IEnumerable<IElement> elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = ModelData.ObjectData.E3DCollection.GetObjects();
                else
                    elements = ModelData.ObjectData.E2DCollection.GetObjects();


                    var interfaceNodes = ModelController.InterfacedNodesFinder.Find(elements);

                    BasePage.ConsoleControl.PrintInfo($"Выполняется пересчет на узлы", Color.Black);
                    BasePage.ConsoleControl.PrintInfo("", Color.Black);

                    var resNames = result.Data.Tables[(int)ResultType.elements].GetTableSchema();

                    for (int i = 1; i < resNames.Length; i++)
                    {
                        resultsController.ResultsMerger.Merge(interfaceNodes, resNames[i], result);

                        Invoke(new Action(() =>
                        {
                            BasePage.ConsoleControl.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                        }));
                    }

                    BasePage.ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    BasePage.ConsoleControl.PrintInfo($"В ходе пересчета возникла ошибка: {ex.Message}", Color.Red);
                }));
            }
        }

        private void ShowResultValue(ResultType tableType, string resName, Result result)
        {
            IEnumerable<IModelObject> objs;

            var scenePage = BasePage.ScenePage;

            if (tableType == ResultType.nodes)
                objs = ModelData.ObjectData.NodesSet.Values;
            else
                objs = ModelData.ObjectData.GetAllElements();

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

        private void ResultPage_Load(object sender, EventArgs e)
        {
            scale = BasePage.ScenePage.SceneControl.CreateScaleObject(0, 1, 2, "", "");
        }

        private void скрытьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var scenePage = BasePage.ScenePage;

            scenePage.ClearAllDataOnScene();

            scenePage.PresentAllModelObjectsToScene();

            scenePage.SceneControl.FitObjectsToScreen();
            scenePage.SceneControl.DisplayObjects();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resultData.Clear();
            //ResultData.Clear();
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоУзлам"].Nodes.Clear();
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

            var scenePage = BasePage.ScenePage;

            scenePage.ClearAllDataOnScene();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                scenePage.CreateObjectsOnScene(item.ToString(), scenePage.CreateObjectsPresentor(item));

            scenePage.SceneControl.DisplayObjects();

            var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];
            anPage.AnimationPage.ClearResultsItems();
            //if (splitContainerEx.Panel2.Controls.Find("PinnedAnimationControl", false).Count() != 0)
            //splitContainerEx.Panel2.Controls[0]
        }

        private void пересчитатьНаУзлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MergeResults();
            BasePage.ConsoleControl.PrintInfo($"Выполняется пересчет с элементов на узлы. Не выходите из модуля!", Color.Orange);                    
        }

        public void ShowExportResultsPage()
        {
            if (ResultDbPath.Equals(string.Empty))
            {
                BasePage.ConsoleControl.PrintInfo("Не задан путь к БД результатов. Укажите его перед экспортом", Color.Orange);
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

            //var tables = new List<string>();
            //foreach (TreeNode item in BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes)
            //    tables.Add(item.Text);

            var exportPage = new ExportControl() { Dock = DockStyle.Fill };
            exportPage.ExportResultEvent += (arg) =>
            {
                var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
                ? new List<string> { ResultType.elements.ToString() }
                : new List<string> { ResultType.nodes.ToString() };
                var result = loader.GetResult(ResultDbPath, table, arg.Time);

                if (arg.ExportType == ExportType.Results) ExportResults(result, arg);
                else ExportGrid(result, arg);
            };
            exportPage.CopyResultDBEvent += (arg) =>
            {
                var table = arg.ExportObj == BaseModule.Interfaces.GeneralParams.Objects.Элемент
                ? new List<string> { ResultType.elements.ToString() }
                : new List<string> { ResultType.nodes.ToString() };
                var result = loader.GetResult(ResultDbPath, table, arg.Time);
                CopyResultDB(result, arg);
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
                Location = BasePage.ScenePage.PointToScreen(Point.Empty)
            };

            exportForm.FormClosed += (ar1, ar2) => { exportPage = null; };
            exportForm.Controls.Add(exportPage);
            exportForm.Show();
        }

        private void ExportResults(Result result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\ResultsExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

                IEnumerable<IModelObject> objects;

                var objTypes = Converters.ConvertToObjsType(args.ExportObj);

                if (objTypes == ObjType.Узел)
                    objects = ModelData.ObjectData.NodesSet.Values;
                else
                    objects = ModelData.ObjectData.GetAllElements();

                resultsController.ResultsExporter.ExportObjectsResults(objects, result, args.ResName, formatedPath, format);
                BasePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private void ExportGrid(Result result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\GridExport_{args.ResName}_{args.Time}_{args.ExportObj}.{format}";

                IEnumerable<ISurfaceElement> elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = ModelData.ObjectData.E3DCollection.GetObjects();
                else
                    elements = ModelData.ObjectData.E2DCollection.GetObjects();

                var figures = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result,
                    ResultType.nodes.ToString(), args.ResName, elements);

                resultsController.GridExporter.ExportGridSurfaces(figures, formatedPath, $".{args.Extension}");
                BasePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private void CopyResultDB(Result result, CopyResultDBEventArgs args)
        {
            var saver = new SaveResultsFileDb();
            saver.Save(new List<Result>() { result}, args.DirPath + "\\temp.db", false);
        }
    }   
}
