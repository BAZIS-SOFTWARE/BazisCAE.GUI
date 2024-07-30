using BaseModule;
using BaseModule.Console;
using BaseModule.Navigator;
using CustomControls.Controls;
using CustomControls.OS;
using Geometry;
using Gif.Components;
using Graph;
using ModelInterfaces;
using ModelInterfaces.MeshObjects;
using ProjectInterfaces;
using ProjectInterfaces.Results;
using ProjectInterfaces.Tasks;
using SceneInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultModule
{
    public partial class ResultPage: BasePage
    {
        ISceneScale scale;
        public event Action<object,string, bool, bool> LoadResultsEvent;
        public IResultsController ResultsController { get; set; }
        
        public bool IsResultsValueShowen { get; set; }

        private bool showScale = true;
        public bool IsScaleMaxMinManual { get; set; } = false;

        public IResultData ResultData { get; set; }

        public ResultPage()
        {
            InitializeComponent();

            NavigatorControl.TreeView.Nodes.Add(new TreeNode("Результаты", 1, 1) { Name = "Результаты", Tag = 6, ContextMenuStrip = resultsMenuStrip });

            var nodeNode = new TreeNode("ПоУзлам", 1, 1) { Name = "ПоУзлам", Tag = "6.1" };
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes.Add(nodeNode);
            var elemNode = new TreeNode("ПоЭлементам", 1, 1) { Name = "ПоЭлементам", Tag = "6.1" };
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes.Add(elemNode);
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

            scPage.SetScaleSetting += (ar1, ar2) =>
            {
                scale.Precision = ar2.Precision;
                scale.FillRange(ar2.Min,ar2.Max, ar2.Range);
            };
            scPage.ShowScaleEvent += (ar1, ar2) =>
            {
                ScenePage.SceneControl.HideGeometryObj("DisplaySceneScale");

                if (ar2)
                {
                    scale.Coord_X = scPage.X_Coord;
                    scale.Coord_Y = scPage.Y_Coord;


                    ScenePage.SceneControl.DisplaySceneScale(scale);
                }

                ScenePage.SceneControl.DisplayObjects();
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
                grPage.CreateTimeGraphEvent += (ar1, ar2) =>
                {
                    CreateTimeGraph(ar2.ResultKind, ar2.ObjsType);
                };
                grPage.CreatePathGraphEvent += (ar1, ar2) =>
                {
                    CreatePathGraph(ar2.ResultKind, ar2.ObjsType, ar2.Time);
                };

                grPage.SelectResultsEvent += (ar) =>
                {
                    NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
                    NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

                    var res = ResultData.FindByTaskKind(ar);
                    PresentResultsOnTree(res);
                };

                var resKinds = ResultData.GetResultKinds();
                var resDic = new Dictionary<string, List<float>>();
                foreach (var resKind in resKinds)
                {
                    resDic.Add(resKind.ToString(), new List<float>());
                    var resTimes = ResultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                    resDic[resKind.ToString()] = resTimes;
                }
                grPage.SetResultsItems(resDic);

                var scForm = new Form() 
                {
                    Owner = Application.OpenForms[0],
                    TopMost = true, 
                    Text = "Построить график", 
                    Size = grPage.Size, 
                    ShowIcon = false ,
                    ClientSize = grPage.Size
                };
                scForm.Controls.Add(grPage);
                scForm.Show();

        }

        public void ShowAnimation()
        {
            var anPage = new AnimationPage() { Dock = DockStyle.Fill };
            anPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (NavigatorControl.TreeView.SelectedNode?.Level == 2)
                    ShowResults(ar2.Time, ar2.ResultKind, ar2.ScaleFactor);
                else ConsoleControl.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            anPage.CreateGIFAnimationEvent += CreateGIFAnimation;
            anPage.SaveScreenShotEvent += (ar1) => { CreateScreenShot(ar1); };
            anPage.SelectResultsEvent += (ar1) => 
            {
                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

                var res = ResultData.FindByTaskKind(ar1);
                PresentResultsOnTree(res);
            };

            var resKinds = ResultData.GetResultKinds();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                resDic.Add(resKind.ToString(), new List<float>());
                var resTimes = ResultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                resDic[resKind.ToString()] = resTimes;
            }

            anPage.SetResultsItems(resDic);

            var anForm = new Form() 
            {
                Owner = Application.OpenForms[0],
                TopMost = true, 
                Size = anPage.Size, 
                Name = "Animation", 
                Text = "Анимация", 
                ShowIcon = false,
                ClientSize = anPage.Size
            };

            anForm.FormClosing += (ar1, ar2) => 
            {
                if (anPage.IsAnimationStarted)
                    anPage.StopAnimation();
            };
            anForm.FormClosed += (ar1,ar2) =>{ anPage = null; };
            anForm.Controls.Add(anPage);
            anForm.Show();
        }



        private void CreateGIFAnimation(object sender, CreateAnimationEventArgs args)
        {
            try
            {
                var outputFilePath = $@"{GeneralData.Path}\results.gif";

                AnimatedGifEncoder e = new AnimatedGifEncoder();

                e.Start(outputFilePath);
                e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);

                for (int i = 0; i < args.Times.Length; i++)
                {
                    ShowResults(args.Times[i], args.ResltsName, args.ScaleFactor);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{GeneralData.Path}\{image}.bmp";
                    CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)args.Times.Length * 100).ToString("#.##");
                        ConsoleControl.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }
                    File.Delete(imagePath);
                }
                e.Finish();
                ConsoleControl.PrintInfo("GIF анимация создана", Color.Green);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
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

        public void ShowOpenResultsFileDialog(bool addRes)
        {
            var openDialogEx = new OpenFileDialogEx()
            {
                StartLocation = AddonWindowLocation.Right,
                DefaultViewMode = FolderViewMode.Thumbnails,
                MergeResults = false
            };

            openDialogEx.OpenDialog.InitialDirectory = Path.GetFullPath(System.Windows.Forms.Application.ExecutablePath);
            openDialogEx.OpenDialog.AddExtension = true;
 
            openDialogEx.StartLocation = AddonWindowLocation.None;

            openDialogEx.OpenDialog.Filter = "Results files (*.db)|*.db";

            if (openDialogEx.ShowDialog(this) == DialogResult.Cancel)
                return;
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

            LoadResultsEvent?.Invoke(this,openDialogEx.OpenDialog.FileName, openDialogEx.MergeResults, addRes);
        }     

        private void ShowResults(float time, string resKind, int scaleFactor)
        {
            try
            {
                var result = ResultData.FindByTime(resKind, time);

                var resName = NavigatorControl.TreeView.SelectedNode.Name;
                var nodeName = NavigatorControl.TreeView.SelectedNode.Parent.Name;

                scale.Title = resKind;
                scale.Info = $"{resName} {time}";

                ObjType objsType;

                if (nodeName == "ПоУзлам")
                    objsType = ObjType.Узел;

                else objsType = ObjType.Элемент;

                if (!IsScaleMaxMinManual)
                {
                    if (objsType == ObjType.Элемент)
                        SetMaxMinAuto(result, "elements", resName);
                    else
                        SetMaxMinAuto(result, "nodes", resName);
                }

                var scaleItems = GetScaleItems();

                ResultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.Item2, scaleItems.Item1);
                ResultsController.ResultsFieldsCreator.ScaleFactor = scaleFactor;

                ScenePage.SceneControl.HideDisplayText2D();
                ScenePage.SceneControl.HideDisplayText3D();

                ScenePage.ClearAllGeometryDataOnScene();
                ScenePage.ClearAllMeshDataOnScene();

                if (GeneralData.TaskType == TaskType.Volume)
                {
                    var els3D = scenePage.ModelData.ObjectData.E3DCollection;
                    var elsResults = ResultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, objsType, resName, els3D);

                    var presenter = ScenePage.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);

                    ScenePage.CreateObjectsOnScene(ObjType.Фигура2D.ToString(), presenter);
                }
                else
                {
                    var els2D = scenePage.ModelData.ObjectData.E2DCollection;
                    var elsResults = ResultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, objsType, resName, els2D);

                    var presenter = ScenePage.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);
                    ScenePage.CreateObjectsOnScene(ObjType.Фигура2D.ToString(), presenter);
                }

                if (IsResultsValueShowen)
                    ShowResultValue(objsType, resName, result);

                if (showScale)
                {
                    ScenePage.SceneControl.HideGeometryObj("DisplaySceneScale");
                    ScenePage.SceneControl.DisplaySceneScale(scale);
                }


                //SceneControl.ChangeViewModeVBObjects("Results", ObjView.Surface);

                ScenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }

        private (ItemRange[], Color[]) GetScaleItems()
        {
            var itemRanges = new ItemRange[scale.Count()];
            var itemColors = new Color[scale.Count()];

            var scaleItems = scale.ToArray();

            for (int i = 0; i < scaleItems.Length; i++)
            {
                itemRanges[i] = new ItemRange()
                {
                    Max = scaleItems[i].Max,
                    Min = scaleItems[i].Min
                };

                itemColors[i] = scaleItems[i].Color;
            }
            return (itemRanges, itemColors);
        }

        private void SetMaxMinAuto(IResult result, string objsType, string resName)
        {
            var max = (float)result.Data.Tables[objsType].Compute($"Max({resName})", "");
            var min = (float)result.Data.Tables[objsType].Compute($"Min({resName})", "");

            scale.FillRange(min, max, 10);
        }

        private async void CreatePathGraph(string resKind, ObjType objsType, float time)
        {
            try
            {
                if (NavigatorControl.TreeView.SelectedNode?.Level != 2)
                {
                    throw new Exception("Выберите вид результатов в разделе результаты");
                }

                ScenePage.ClearAllDataOnScene();
                ScenePage.PresentAllModelObjectsToScene();
                ScenePage.SelectedObjects = objsType;

                var objs = await CreatePathAsync();

                var selNode = NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

                var result = ResultData.FindByTime(resKind, time);

                var pathPoints = new List<Point3D>();
                var path = 0.0f;
                var grPoints = new List<GraphPoint>();

                if (result != null)
                    foreach (var obj in objs)
                    {
                        var res = 0.0f;
                        if (objsType == ObjType.Узел)
                            res = result.GetNodeValue(obj.Number, resDes);
                        else res = result.GetElementValue(obj.Number, resDes);

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

                    grContainer.CreateGraphObj("Результаты по расстоянию", new List<GraphData>() { grData }, new AxisFormat(), new AxisFormat());
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
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private async void CreateTimeGraph(string resKind, ObjType objsType)
        {
            try
            {
                if (NavigatorControl.TreeView.SelectedNode?.Level != 2)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                ScenePage.ClearAllDataOnScene();
                ScenePage.PresentAllModelObjectsToScene();
                ScenePage.SelectedObjects = objsType;

                var objs = await SelectObjectsAsync(objsType);

                if(objs.Count == 0)
                    throw new Exception("Не выбран ни один объект!");

                var selNode = NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

                var results = ResultData.FindByTaskKind(resKind);

                var grDataAr = new List<GraphData>();
                Random random = new Random();
                foreach (var obj in objs)
                {
                    var grPoints = new List<GraphPoint>();

                    foreach (var result in results)
                    {
                        var res = 0.0f;
                        if (objsType == ObjType.Узел)
                            res = result.GetNodeValue(obj.Number, resDes);
                        else res = result.GetElementValue(obj.Number, resDes);

                        var grPoint = new GraphPoint(result.Time, res);
                        grPoints.Add(grPoint);
                    }

                    ScenePage.SceneControl.DisplayText3D($"{objsType}_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"{objsType}_{obj.Number}", color, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                ScenePage.SceneControl.DisplayObjects();
                var grContainer = new GraphContainer();

                if (grDataAr.Count != 0)
                {
                    grContainer.CreateGraphObj("Результаты по времени", grDataAr, new AxisFormat(), new AxisFormat());
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
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        public async Task<List<IModelObject>> SelectObjectsAsync(ObjType objType)
        {
            var nodes = new List<IModelObject>();
            PressedKey = Keys.None;
            ScenePage.SceneControl.DisplayText2D(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения", Color.Black, new Point2D(10, 10));
            ScenePage.SceneControl.DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                    {
                        var objs = scenePage.ModelData.ObjectData.GetObjects(objType);
                        nodes = objs.Where(x => x.MasterColor == ScenePage.SceneControl.SelectionColor).ToList();
                        break;
                    }
                    if(PressedKey == Keys.Escape)
                    {
                        Invoke(new Action(() =>
                        {
                            ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                        }));
                        break;
                    }
                }
            });
            ScenePage.SceneControl.HideDisplayText2D();
            ScenePage.SceneControl.DisplayObjects();
            PressedKey = Keys.None;
            return nodes;
        }

        public void PresentResultsOnTree(IEnumerable<IResult> results)
        {
            var nodeSchema = results.First().GetDataSchema("nodes");
            var elemSchema = results.First().GetDataSchema("elements");

            var resultNode = NavigatorControl.TreeView.Nodes["Результаты"];
            foreach (var desc in nodeSchema)
            {
                    NavigatorControl.CreateChildNode("ПоУзлам", desc, desc, "6.1.1");
            }

            foreach (var desc in elemSchema)
            {
                    NavigatorControl.CreateChildNode("ПоЭлементам", desc, desc, "6.1.1");
            }
        }

        public async Task<List<IResult>> LoadResultsAsync(string fileName)
        {
            var res = new List<IResult>();
            await Task.Run(new Action(() =>
            {

                foreach (var result in ResultData.Loader.Load(fileName))
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo(result.ToString(), Color.Black);
                    }));

                    res.Add(result);
                }

                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Загрузка завершена", Color.Green);
                }));

            }));
            return res;
        }

        public async Task MergeResults(IEnumerable<IResult> results)
        {
            try
            {
                IElement[] elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = scenePage.ModelData.ObjectData.E3DCollection.ToArray();
                else
                    elements = scenePage.ModelData.ObjectData.E2DCollection.ToArray();

                var act = new Action(() =>
                {
                    var interfaceNodes = ScenePage.ModelController.InterfacedNodesFinder.Find(elements);

                    var resKinds = results.Select(x => x.TaskKind).Distinct();

                    //var resKinds = ResultData.GetResultKinds();

                    foreach (var item in resKinds)
                    {
                        Invoke(new Action(() =>
                        {
                            ConsoleControl.PrintInfo($"Выполняется пересчет на узлы для задачи {item}", Color.Black);
                            ConsoleControl.PrintInfo("", Color.Black);
                        }));

                        var resNames = results.First(x => x.TaskKind == item).GetDataSchema("elements");

                        for (int i = 1; i < resNames.Count; i++)
                        {
                            ResultsController.ResultsMerger.Merge(interfaceNodes, resNames[i], results.Where(x => x.TaskKind == item));

                            Invoke(new Action(() =>
                            {
                                ConsoleControl.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                            }));
                        }
                    }


                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);
                    }));

                });

                await Task.Run(act);

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo($"В ходе пересчета возникла ошибка: {ex.Message}", Color.Red);
                }));
            }
        }

        private void ShowResultValue(ObjType objsType, string resName, IResult result)
        {
            IEnumerable<IModelObject> objs;
            if (objsType == ObjType.Узел)
                objs = scenePage.ModelData.ObjectData.NodeCollection;
            else
                objs = scenePage.ModelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.MasterColor == ScenePage.SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentr();
                    var res = 0.0f;
                    if (objsType == ObjType.Узел)
                        res = result.GetNodeValue(obj.Number, resName);
                    else res = result.GetElementValue(obj.Number, resName);
                    ScenePage.SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

        private void ResultPage_Load(object sender, EventArgs e)
        {
            scale = ScenePage.SceneControl.CreateScaleObject(0, 1, 2, "", "");
        }

        private void скрытьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScenePage.ClearAllDataOnScene();

            ScenePage.PresentAllModelObjectsToScene();

            ScenePage.SceneControl.FitObjectsToScreen();
            ScenePage.SceneControl.DisplayObjects();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultData.Clear();
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

            ScenePage.ClearAllDataOnScene();

            foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
                ScenePage.CreateObjectsOnScene(item.ToString(), ScenePage.CreateObjectsPresentor(item));

            ScenePage.SceneControl.DisplayObjects();
        }

        private async void пересчитатьНаУзлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsoleControl.PrintInfo($"Выполняется пересчет с элементов на узлы. Не выходите из модуля!", Color.Orange);
            await MergeResults(ResultData);                     
        }

        public void ShowExportResultsPage()
        {
            var exprtPage = new ExportControl() { Dock = DockStyle.Fill };
            exprtPage.ExportResultEvent += ExportGrid;

            var resKinds = ResultData.GetResultKinds();
            var names = new List<string>();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                var results = ResultData.FindByTaskKind(resKind.ToString());
                names.AddRange(results.First().GetDataSchema("nodes"));
                resDic.Add(resKind.ToString(), new List<float>());
                var resTimes = ResultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                resDic[resKind.ToString()] = resTimes;
            }

            exprtPage.SetSelectorsValues(resDic);
            exprtPage.SetNodesNames(names);

            var exprtForm = new Form()
            {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Size = exprtPage.Size,
                Name = "export",
                Text = "Экспорт результатов",
                ShowIcon = false,
                ClientSize = exprtPage.Size
            };

            exprtForm.FormClosed += (ar1, ar2) => { exprtPage = null; };
            exprtForm.Controls.Add(exprtPage);
            exprtForm.Show();
        }

        private void ExportGrid(ExportResultEventArgs args)
        {
            try
            {
                var results = ResultData.FindByTime(args.TaskKind, args.Time);
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\GridExport_{DateTime.Now.ToString().Replace("/", "_").Replace(":", "_")}{format}";

                var scaleItems = GetScaleItems();
                ResultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.Item2, scaleItems.Item1);
                ResultsController.ResultsFieldsCreator.ScaleFactor = 1;

                IEnumerable<ISurfaceElement> elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = scenePage.ModelData.ObjectData.E3DCollection;
                else
                    elements = scenePage.ModelData.ObjectData.E2DCollection;

                var figures = ResultsController.ResultsFieldsCreator.CreateSurfaceObjects(results,
                    ObjType.Узел,
                    args.ResName,
                    elements);

                ResultsController.ResultsExporter.ExportResults(figures, formatedPath, args.Extension);
                ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {args.Path}", Color.Black);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }
    }   
}
