using BaseModule;
using BaseModule.Console;
using BaseModule.Navigator;
using BaseModule.Utilities;
using CustomControls.Controls;
using CustomControls.OS;
using Geometry;
using Gif.Components;
using Graph;
using ModelControllerInterfaces;
using ModelInterfaces;
using ModelInterfaces.MeshObjects;
using ProjectInterfaces;
using ProjectInterfaces.Results;
using ProjectInterfaces.Tasks;
using ResultModule.Animation;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ResultModule
{
    public partial class ResultPage: ToolStripPage
    {
        ISceneScale scale;
        public event Action<object,string, bool, bool> LoadResultsEvent;
        
        public bool IsResultsValueShowen { get; set; }

        private bool showScale = true;
        public bool IsScaleMaxMinManual { get; set; } = false;

        IResultsController resultsController;

        IResultData resultData;

        IGeneralData GeneralData { get { return basePage.GetGeneralData(); } }

        IModelController ModelController
        {
            get { return BasePage.ScenePage.GetModelController(); }
        }

        IModelData ModelData
        {
            get { return ModelController.ModelData; }
        }

        public void SetResultsController(IResultsController resultsController)
        {
            this.resultsController = resultsController;
        }

        public void SetResultData(IResultData resultData)
        {
            this.resultData = resultData;
        }

        public ResultPage()
        {
            InitializeComponent();

            var navigator = BasePage.NavigatorControl;

            navigator.TreeView.Nodes.Add(new TreeNode("Набор результатов", 14, 14) { Name = "Набор результатов", Tag = 6, ContextMenuStrip = resultsMenuStrip });

            var nodeNode = new TreeNode("ПоУзлам", 14, 14) { Name = "ПоУзлам", Tag = "6.1" };
            navigator.TreeView.Nodes["Набор результатов"].Nodes.Add(nodeNode);
            var elemNode = new TreeNode("ПоЭлементам", 14, 14) { Name = "ПоЭлементам", Tag = "6.1" };
            navigator.TreeView.Nodes["Набор результатов"].Nodes.Add(elemNode);
            resultsMenuStrip.Enabled = true;
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
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                var results = resultData.FindByTaskKind(ar2.ResultKind);
                CreateTimeGraph(results, ar2.ObjsType);
            };
            grPage.CreatePathGraphEvent += (ar1, ar2) =>
                {
                    var result = resultData.FindByTime(ar2.ResultKind, ar2.Time);
                    CreatePathGraph(result, ar2.ObjsType);
                };

            grPage.SelectResultsEvent += (ar) =>
            {
                BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоУзлам"].Nodes.Clear();
                BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

                var res = resultData.FindByTaskKind(ar);
                PresentResultsOnTree(res);
            };

            var resKinds = resultData.GetResultKinds();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                resDic.Add(resKind.ToString(), new List<float>());
                var resTimes = resultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                resDic[resKind.ToString()] = resTimes;
            }
            grPage.SetResultsItems(resDic);

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

        public void ShowAnimation()
        {
            var anPage = new PinnedAnimationControl() { Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };

            splitContainerEx.SplitterDistance = splitContainerEx.Panel1.Width - anPage.Width;

            anPage.ControlCollapseEvent += () =>
            {
                splitContainerEx.Panel2Collapsed = true;
                splitContainerEx.Panel2.Controls.Clear();
            };


            anPage.animationPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (BasePage.NavigatorControl.TreeView.SelectedNode?.Level == 2)
                {
                    var result = resultData.FindByTime(ar2.ResultKind, ar2.Time, 1e-2f);
                    ShowResults(result, ar2.ScaleFactor);
                }

                else BasePage.ConsoleControl.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            anPage.animationPage.CreateGIFAnimationEvent += (arg1, arg2) => { CreateGIFAnimation(arg2); };
            anPage.animationPage.SaveScreenShotEvent += (ar1) => { BasePage.CreateScreenShot(ar1); };
            anPage.animationPage.SelectResultsEvent += (ar1) =>
            {
                BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоУзлам"].Nodes.Clear();
                BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

                var res = resultData.FindByTaskKind(ar1);
                PresentResultsOnTree(res);
            };

            var resDic = CreateResultsDic();

            anPage.animationPage.SetResultsItems(resDic);
            if (resDic.Count != 0)
                anPage.animationPage.ShowResultsTimeSteps(resDic.First().Key);

            splitContainerEx.Panel2Collapsed = false;
            splitContainerEx.Panel2.Padding = new Padding(0, 5, 5, 0);
            splitContainerEx.Panel2.Controls.Add(anPage);

            //var anForm = new Form() 
            //{
            //    Owner = Application.OpenForms[0],
            //    TopMost = true, 
            //    Size = anPage.Size, 
            //    Name = "Animation", 
            //    Text = "Анимация", 
            //    ShowIcon = false,
            //    ClientSize = anPage.Size
            //};

            //anForm.FormClosing += (ar1, ar2) => 
            //{
            //    if (anPage.animationPage.IsAnimationStarted)
            //        anPage.animationPage.StopAnimation();
            //};
            //anForm.FormClosed += (ar1,ar2) =>{ anPage = null; };
            //anForm.Controls.Add(anPage);
            //anForm.Show();
        }

        public Dictionary<string, List<float>> CreateResultsDic()
        {
            var resKinds = resultData.GetResultKinds();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                resDic.Add(resKind.ToString(), new List<float>());
                var resTimes = resultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                resDic[resKind.ToString()] = resTimes;
            }

            return resDic;
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

                for (int i = 0; i < args.Times.Length; i++)
                {
                    var result = resultData.FindByTime(args.ResltsKind, args.Times[i]);
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
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоУзлам"].Nodes.Clear();
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

            LoadResultsEvent?.Invoke(this,openDialogEx.OpenDialog.FileName, openDialogEx.MergeResults, addRes);
        }     

        private void ShowResults(IResult result, int scaleFactor)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                var resName = BasePage.NavigatorControl.TreeView.SelectedNode.Name;
                var nodeName = BasePage.NavigatorControl.TreeView.SelectedNode.Parent.Name;

                scale.Title = result.TaskKind.ToString();
                scale.Info = $"{resName} {result.Time}";

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

                resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.Item2, scaleItems.Item1);
                resultsController.ResultsFieldsCreator.ScaleFactor = scaleFactor;

                scenePage.SceneControl.HideDisplayText2D();
                scenePage.SceneControl.HideDisplayText3D();

                scenePage.ClearAllGeometryDataOnScene();
                scenePage.ClearAllMeshDataOnScene();

                if (GeneralData.TaskType == TaskType.Volume)
                {
                    var els3D = ModelData.ObjectData.E3DCollection;
                    var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, objsType, resName, els3D);

                    var presenter = ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);

                    scenePage.CreateObjectsOnScene(ObjType.Фигура2D.ToString(), presenter);
                }
                else
                {
                    var els2D = ModelData.ObjectData.E2DCollection;
                    var elsResults = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result, objsType, resName, els2D);

                    var presenter = ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);
                    scenePage.CreateObjectsOnScene(ObjType.Фигура2D.ToString(), presenter);
                }

                if (IsResultsValueShowen)
                    ShowResultValue(objsType, resName, result);

                if (showScale)
                {
                    scenePage.SceneControl.HideGeometryObj("DisplaySceneScale");
                    scenePage.SceneControl.DisplaySceneScale(scale);
                }


                //SceneControl.ChangeViewModeVBObjects("Results", ObjView.Surface);

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
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

            scale.FillRange(min, (float)max, 10);
        }

        private async void CreatePathGraph(IResult result, ObjType objsType)
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
                scenePage.SelectedObjects = objsType;

                var objs = await BasePage.CreatePathAsync();

                var selNode = BasePage.NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

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

        private async void CreateTimeGraph(IEnumerable<IResult> results, ObjType objsType)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                if (BasePage.NavigatorControl.TreeView.SelectedNode?.Level != 2)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene();
                scenePage.SelectedObjects = objsType;

                var objs = await SelectObjectsAsync(objsType);

                if(objs.Count == 0)
                    throw new Exception("Не выбран ни один объект!");

                var selNode = BasePage.NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

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

        public async Task<List<IModelObject>> SelectObjectsAsync(ObjType objType)
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
                        var objs = ModelData.ObjectData.GetObjects(objType);
                        nodes = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToList();
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

        public void PresentResultsOnTree(IEnumerable<IResult> results)
        {
            var nodeSchema = results.First().GetDataSchema("nodes");
            var elemSchema = results.First().GetDataSchema("elements");

            var resultNode = BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"];
            foreach (var desc in nodeSchema)
            {
                BasePage.NavigatorControl.CreateChildNode("ПоУзлам", desc, desc, "6.1.1");
            }

            foreach (var desc in elemSchema)
            {
                BasePage.NavigatorControl.CreateChildNode("ПоЭлементам", desc, desc, "6.1.1");
            }
        }

        public async Task<List<IResult>> LoadResultsAsync(string fileName, IResultData resultData)
        {
            var res = new List<IResult>();
            await Task.Run(new Action(() =>
            {

                foreach (var result in resultData.Loader.Load(fileName))
                {
                    Invoke(new Action(() =>
                    {
                        BasePage.ConsoleControl.PrintInfo(result.ToString(), Color.Black);
                    }));

                    res.Add(result);
                }

                Invoke(new Action(() =>
                {
                    BasePage.ConsoleControl.PrintInfo("Загрузка завершена", Color.Green);
                }));

            }));
            return res;
        }

        public async Task MergeResults()
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                IElement[] elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = ModelData.ObjectData.E3DCollection.ToArray();
                else
                    elements = ModelData.ObjectData.E2DCollection.ToArray();

                var act = new Action(() =>
                {
                    var interfaceNodes = ModelController.InterfacedNodesFinder.Find(elements);

                    var resKinds = resultData.Select(x => x.TaskKind).Distinct();

                    //var resKinds = ResultData.GetResultKinds();

                    foreach (var item in resKinds)
                    {
                        Invoke(new Action(() =>
                        {
                            BasePage.ConsoleControl.PrintInfo($"Выполняется пересчет на узлы для задачи {item}", Color.Black);
                            BasePage.ConsoleControl.PrintInfo("", Color.Black);
                        }));

                        var resNames = resultData.First(x => x.TaskKind == item).GetDataSchema("elements");

                        for (int i = 1; i < resNames.Count; i++)
                        {
                            resultsController.ResultsMerger.Merge(interfaceNodes, resNames[i], resultData.Where(x => x.TaskKind == item));

                            Invoke(new Action(() =>
                            {
                                BasePage.ConsoleControl.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                            }));
                        }
                    }


                    Invoke(new Action(() =>
                    {
                        BasePage.ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);
                    }));

                });

                await Task.Run(act);

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    BasePage.ConsoleControl.PrintInfo($"В ходе пересчета возникла ошибка: {ex.Message}", Color.Red);
                }));
            }
        }

        private void ShowResultValue(ObjType objsType, string resName, IResult result)
        {
            IEnumerable<IModelObject> objs;

            var scenePage = BasePage.ScenePage;

            if (objsType == ObjType.Узел)
                objs = ModelData.ObjectData.NodeCollection;
            else
                objs = ModelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.MasterColor == scenePage.SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentr();
                    var res = 0.0f;
                    if (objsType == ObjType.Узел)
                        res = result.GetNodeValue(obj.Number, resName);
                    else res = result.GetElementValue(obj.Number, resName);
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
            resultData.Clear();
            //ResultData.Clear();
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоУзлам"].Nodes.Clear();
            BasePage.NavigatorControl.TreeView.Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

            var scenePage = BasePage.ScenePage;

            scenePage.ClearAllDataOnScene();

            foreach (var item in ModelData.ObjectData.ObjsTypes)
                scenePage.CreateObjectsOnScene(item.ToString(), scenePage.CreateObjectsPresentor(item));

            scenePage.SceneControl.DisplayObjects();

            List<PinnedAnimationControl> cntrs = new List<PinnedAnimationControl>();
            RecursiveSearchControls.AllTypedControls(splitContainerEx.Panel2, cntrs);
            if (cntrs.Count != 0)
                cntrs[0].animationPage.ClearResultsItems();
            //if (splitContainerEx.Panel2.Controls.Find("PinnedAnimationControl", false).Count() != 0)
            //splitContainerEx.Panel2.Controls[0]
        }

        private void пересчитатьНаУзлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergeResults();
            BasePage.ConsoleControl.PrintInfo($"Выполняется пересчет с элементов на узлы. Не выходите из модуля!", Color.Orange);                    
        }

        public void ShowExportResultsPage()
        {
            var scaleItems = GetScaleItems();
            resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems.Item2, scaleItems.Item1);
            resultsController.ResultsFieldsCreator.ScaleFactor = 1;

            var exportPage = new ExportControl() { Dock = DockStyle.Fill };
            exportPage.ExportResultEvent += (arg) => 
            {
                var results = resultData.FindByTime(arg.TaskKind, arg.Time);
                if (arg.ExportType == ExportType.Results)
                    ExportResults(results, arg);
                else
                    ExportGrid(results, arg);
            };
            exportPage.CopyResultDBEvent += (arg) =>
            {
                var results = resultData.FindByTime(arg.TaskKind, arg.Time);
                CopyResultDB(results, arg);
            };

            var resKinds = resultData.GetResultKinds();
            var nodeNames = new List<string>();
            var elementNames = new List<string>();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                var results = resultData.FindByTaskKind(resKind.ToString());

                nodeNames.AddRange(results.First().GetDataSchema("nodes"));
                elementNames.AddRange(results.First().GetDataSchema("elements"));

                resDic.Add(resKind.ToString(), new List<float>());
                resDic[resKind.ToString()] = resultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
            }

            exportPage.SetResultKinds(resKinds.Select(x => x.ToString()));
            exportPage.SetResultValues(resDic);
            exportPage.SetNodeNames(nodeNames);
            exportPage.SetElementNames(elementNames);

            var exportForm = new Form()
            {
                Owner = Application.OpenForms[0],
                TopMost = true,
                Size = exportPage.Size,
                Name = "export",
                Text = "Экспорт результатов",
                ShowIcon = false,
                ClientSize = exportPage.Size
            };

            exportForm.FormClosed += (ar1, ar2) => { exportPage = null; };
            exportForm.Controls.Add(exportPage);
            exportForm.Show();
        }

        private void ExportResults(IResult result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\ResultsExport_{args.ResName}_{args.Time}_{args.ExportType}_{args.ExportObj}.{format}";

                IEnumerable<IModelObject> objects;
                if (args.ExportObj == ObjType.Узел)
                    objects = ModelData.ObjectData.NodeCollection;
                else
                    objects = ModelData.ObjectData.GetAllElements();

                resultsController.ResultsExporter.ExportObjectsResults(objects, result, args.ResName, formatedPath, format);
                BasePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private void ExportGrid(IResult result, ExportResultEventArgs args)
        {
            try
            {
                var format = args.Extension.Split('-')[0];
                var formatedPath = $"{args.Path}\\GridExport_{args.ResName}_{args.Time}_{args.ExportType}_{args.ExportObj}.{format}";

                IEnumerable<ISurfaceElement> elements;
                if (GeneralData.TaskType == TaskType.Volume)
                    elements = ModelData.ObjectData.E3DCollection;
                else
                    elements = ModelData.ObjectData.E2DCollection;

                var figures = resultsController.ResultsFieldsCreator.CreateSurfaceObjects(result,
                    ObjType.Узел, args.ResName, elements);

                resultsController.GridExporter.ExportGridSurfaces(figures, formatedPath, $".{args.Extension}");
                BasePage.ConsoleControl.PrintInfo($"созданный файл сохранен по пути: {formatedPath}", Color.Black);
            }
            catch (Exception ex) { BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red); }
        }

        private void CopyResultDB(IResult result, CopyResultDBEventArgs args)
        {
            BasePage.ConsoleControl.PrintInfo($"Метод не реализован!", Color.Red);
        }
    }   
}
