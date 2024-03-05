using BaseModule;
using BaseModule.Navigator;
using BaseModule.ToolStrips;
using CustomControls.Controls;
using CustomControls.OS;
using Geometry;
using Gif.Components;
using Graph;
using ModelControllerInterfaces;
using ModelInterfaces;
using ModelInterfaces.MeshObjects;
using ProjectInterfaces;
using ProjectInterfaces.IO;
using ProjectInterfaces.Tasks;
using ResultModule.ToolStrips;
using SceneInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace ResultModule
{
    public partial class ResultPage: BasePage
    {
        IScale scale;
        
        private bool showResultValue;
        public bool IsScaleMaxMinAuto { get; set; } = true;

        public ResultPage()
        {
            InitializeComponent();

            scale = new RainbowScale(1, 0, 10);

            var resToolStrip = new ResultsToolStrip
            {
                Renderer = new BaseToolStrRender()
            };
            resToolStrip.ItemClicked += ResultsToolStrip_ItemClicked;

            AddToolStrip(resToolStrip);

            NavigatorControl.TreeView.Nodes.Add(new TreeNode("Результаты", 1, 1) { Name = "Результаты", Tag = 6 });

            var nodeNode = new TreeNode("ПоУзлам", 1, 1) { Name = "ПоУзлам", Tag = "6.1" };
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes.Add(nodeNode);
            var elemNode = new TreeNode("ПоЭлементам", 1, 1) { Name = "ПоЭлементам", Tag = "6.1" };
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes.Add(elemNode);
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(CreateResultsInterface());
            base.CreateMenuInterface();
        }

        private ToolStripMenuItem CreateResultsInterface()
        {
            ToolStripMenuItem resultsMenuItem = new ToolStripMenuItem()
            {
                Name = "resultsMenuItem",
                Text = "Результаты"
            };

            ToolStripMenuItem clearResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "clearResults",
                Text = "Очистить результаты"
            };

            clearResultsMenuItem.Click += (ar1, ar2) => 
            {
                Project.ResultData.Clear();
                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

                ClearAllDataOnScene();

                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                    PresentObjectsToScene(item.ToString(), CreateObjectsPresentor(item));

                SceneControl.DisplayObjects();
            };

            ToolStripMenuItem addResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "addResults",
                Text = "Добавить результаты"
            };

            addResultsMenuItem.Click += (ar1, ar2) => { ShowOpenResultsFileDialog(true); };

            ToolStripMenuItem loadResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "loadResults",
                Text = "Загрузить результаты"
            };

            loadResultsMenuItem.Click += (ar1, ar2) => { ShowOpenResultsFileDialog(false); };

            ToolStripMenuItem hideResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "hideResults",
                Text = "Скрыть результаты"
            };

            hideResultsMenuItem.Click += (ar1, ar2) => 
            {
                ClearAllDataOnScene();

                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                    PresentObjectsToScene(item.ToString(), CreateObjectsPresentor(item));

                SceneControl.DisplayObjects();
            };

            ToolStripMenuItem showValueResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "showValueResults",
                Text = "Показать значения",
                CheckOnClick = true
            };

            showValueResultsMenuItem.Click += (ar1, ar2) => { ShowValue(showValueResultsMenuItem.Checked); };

            ToolStripMenuItem showAnimationResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "showAnimationResults",
                Text = "Показать анимацию"
            };

            showAnimationResultsMenuItem.Click += (ar1, ar2) => 
            {
                    ShowAnimation(); 
            };

            ToolStripMenuItem createGraphResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "createGraphResults",
                Text = "Построить график"
            };

            createGraphResultsMenuItem.Click += (ar1, ar2) => { CreateGraph(); };

            ToolStripMenuItem showScaleResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "showScaleResults",
                Text = "Показать шкалу"
            };

            showScaleResultsMenuItem.Click += (ar1, ar2) => 
            { 
                    ShowScale(); 
            };

            resultsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            clearResultsMenuItem,
            addResultsMenuItem,
            loadResultsMenuItem,
            hideResultsMenuItem,
            showValueResultsMenuItem,
            showAnimationResultsMenuItem,
            createGraphResultsMenuItem,
            showScaleResultsMenuItem
            });

            return resultsMenuItem;
        }

        private void ShowScale()
        {
            var scPage = new ScalePage() { Dock = DockStyle.Fill };

            scPage.Max = scale.MaxValue;
            scPage.Min = scale.MinValue;

            scPage.ChangeMaxMinAutoEvent += (ar) => { IsScaleMaxMinAuto = ar; };

            scPage.IsMaxMinAuto = IsScaleMaxMinAuto;

            scPage.Precision = scale.Precision;

            scPage.X_Coord = scale.Coord_X;
            scPage.Y_Coord = scale.Coord_Y;

            scPage.SetScaleSetting += (ar1, ar2) =>
            {
                scale.Precision = ar2.Precision;
                scale.FillRange(ar2.Max, ar2.Min, ar2.Range);
            };
            scPage.ShowScaleEvent += (ar1, ar2) =>
            {
                if (ar2)
                {
                    CreateScale();
                }

                else
                {                   
                    SceneControl.HideGeometryObj("DisplaySceneScale");
                }

                SceneControl.DisplayObjects();
            };
            scPage.SetX_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_X = (int)ar2;
            };
            scPage.SetY_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_Y = (int)ar2;
            };
            
            var icon = ResultModule.Properties.Resources.Scale;
            var scForm = new Form() { TopMost = true, Icon = icon, Size = scPage.Size, Name = "Scale", Text = "Шкала значений" };

            scForm.Controls.Add(scPage);
            scForm.Show();
        }

        private void CreateGraph()
        {
                var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
                grPage.CreateTimeGraphEvent += (ar1, ar2) =>
                {
                    CreateTimeGraph(NavigatorControl.TreeView.Nodes["Результаты"].Text, ar2.ObjsType);
                };
                grPage.CreatePathGraphEvent += (ar1, ar2) =>
                {
                    CreatePathGraph(NavigatorControl.TreeView.Nodes["Результаты"].Text, ar2.ObjsType, ar2.Time);
                };

                grPage.SelectObjectsEvent += (ar) =>
                {
                    ClearAllDataOnScene();

                    foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                        PresentObjectsToScene(item.ToString(), CreateObjectsPresentor(item));

                    SelectedObjects = ar;

                    SceneControl.DisplayObjects();
                };

                var resKinds = Project.ResultData.GetResultKinds();
                var resDic = new Dictionary<string, List<float>>();
                foreach (var resKind in resKinds)
                {
                    resDic.Add(resKind.ToString(), new List<float>());
                    var resTimes = Project.ResultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                    resDic[resKind.ToString()] = resTimes;
                }
                grPage.SetResultsItems(resDic);

                var icon = ResultModule.Properties.Resources.Graph;
                var scForm = new Form() { TopMost = true, Text = "Построить график", Icon = icon, Size = grPage.Size };
                scForm.Controls.Add(grPage);
                scForm.Show();

        }

        private void ShowAnimation()
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
                NavigatorControl.TreeView.Nodes["Результаты"].Text = ar1;

                var res = Project.ResultData.FindByTaskKind(ar1);
                PresentResultsOnTree(res);
            };

            var resKinds = Project.ResultData.GetResultKinds();
            var resDic = new Dictionary<string, List<float>>();
            foreach (var resKind in resKinds)
            {
                resDic.Add(resKind.ToString(), new List<float>());
                var resTimes = Project.ResultData.FindByTaskKind(resKind).Select(x => x.Time).ToList();
                resDic[resKind.ToString()] = resTimes;
            }

            anPage.SetResultsItems(resDic);

            var icon = ResultModule.Properties.Resources.Animation;
            var anForm = new Form() { TopMost = true, Icon = icon, Size = anPage.Size, Name = "Animation", Text = "Анимация" };
            
            anForm.FormClosed += (ar1,ar2) =>{ anPage = null; };
            anForm.Controls.Add(anPage);
            anForm.Show();
        }



        private void CreateGIFAnimation(object sender, CreateAnimationEventArgs args)
        {
            try
            {
                //you should replace filepath

                var search = string.Format("screenShot_*");
                var imagesPaths = Directory.GetFiles(Project.Path, search);
                SortCharNumberStrings(imagesPaths);

                String outputFilePath = $@"{Project.Path}\results.gif";

                AnimatedGifEncoder e = new AnimatedGifEncoder();

                e.Start(outputFilePath);
                e.SetDelay(args.DelayTime);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);

                for (int i = 0; i < imagesPaths.Length; i++)
                {
                    using (var stream = new FileStream(imagesPaths[i], FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i / (float)imagesPaths.Length) * 100).ToString("#.##");
                        ConsoleControl.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }

                }
                e.Finish();
                ConsoleControl.PrintInfo("GIF анимация создана", Color.Green);

                //delete temp scrShots

                foreach (var image in imagesPaths)
                    File.Delete(image);

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

        private void ShowValue(bool state)
        {
            if (state)
                showResultValue = true;
            else
            {
                showResultValue = false;
                SceneControl.HideDisplayText3D();
            }
        }

        private void ShowOpenResultsFileDialog(bool addRes)
        {
            var openDialogEx = new OpenFileDialogEx()
            {
                StartLocation = AddonWindowLocation.Right,
                DefaultViewMode = FolderViewMode.Thumbnails,
                MergeResults = true
            };

            openDialogEx.OpenDialog.InitialDirectory = Path.GetFullPath(Application.ExecutablePath);
            openDialogEx.OpenDialog.AddExtension = true;

            //openDialogEx.Size = new Size(650,267);
 
            openDialogEx.StartLocation = AddonWindowLocation.None;

            openDialogEx.OpenDialog.Filter = "Results files (*.db)|*.db";

            if (openDialogEx.ShowDialog(this) == DialogResult.Cancel)
                return;
            //resItems.Clear();

            LoadResults(openDialogEx.OpenDialog.FileName, openDialogEx.MergeResults, addRes);
        }

        private void ResultsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Tag.ToString() == "0")
            {
                SceneControl.DeleteVBObjects("Results");

                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                    PresentObjectsToScene(item.ToString(), CreateObjectsPresentor(item));

                SceneControl.DisplayObjects();

                Project.ResultData.Clear();

                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
                NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                ShowOpenResultsFileDialog(true);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                ShowOpenResultsFileDialog(false);
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                ClearAllDataOnScene();

                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                    PresentObjectsToScene(item.ToString(), CreateObjectsPresentor(item));

                SceneControl.DisplayObjects();
            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                ShowValue(e.ClickedItem.Pressed);
            }
            else if (e.ClickedItem.Tag.ToString() == "5")
            {
                if (Application.OpenForms["Animation"] == null)
                    ShowAnimation();

            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                CreateGraph();
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                if (Application.OpenForms["Scale"] == null)
                    ShowScale();
            }
        }

        private void ShowResults(float time, string resKind, int scaleFactor)
        {
            try
            {
                var result = Project.ResultData.FindByTime(resKind, time);

                var resName = NavigatorControl.TreeView.SelectedNode.Name;
                var objsType = NavigatorControl.TreeView.SelectedNode.Parent.Name;

                if (objsType == "ПоУзлам")
                    objsType = "Узлы";

                else objsType = "Элементы";

                if (IsScaleMaxMinAuto)
                {
                    if (objsType == "Элементы")
                        SetMaxMinAuto(result, "elements", resName);
                    else
                        SetMaxMinAuto(result, "nodes", resName);
                    if (SceneControl.FindGeometryObj("CreateScaleObject"))
                        CreateScale();
                }

                var colorRanges = scale.ColorRange().ToArray();
                var valueRanges = scale.ValueRange().ToArray();

                var fieldCreator = new GradientFieldsCreator(valueRanges, colorRanges, scaleFactor);

                SceneControl.HideDisplayText2D();
                SceneControl.HideDisplayText3D();
                SceneControl.DeleteAllVBObjects();

                if (Project.TaskType == TaskType.Volume)
                {
                    var els3D = Project.ModelData.ObjectData.E3DCollection;
                    var elsResults = fieldCreator.CreateSurfaceObjects(result, objsType, resName, els3D);

                    var presenter = PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);
 
                    PresentObjectsToScene("Results", presenter);
                }
                else
                {
                    var els2D = Project.ModelData.ObjectData.E2DCollection;
                    var elsResults = fieldCreator.CreateSurfaceObjects(result, objsType, resName, els2D);

                    var presenter = PresentersCreator.CreateSurfaceObjectsPresenter(elsResults,false);
                    PresentObjectsToScene("Results", presenter);
                }

                if (showResultValue)
                    ShowResultValue(objsType, resName, result);

                SceneControl.ChangeViewModeVBObjects("Results", ObjView.Surface);

                SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }

        private void SetMaxMinAuto(IResult result, string objsType, string resName)
        {
            var max = (float)result.Data.Tables[objsType].Compute($"Max({resName})", "");
            var min = (float)result.Data.Tables[objsType].Compute($"Min({resName})", "");

            scale.FillRange(max, min, 10);
        }

        private void CreatePathGraph(string resKind, ObjType objsType, float time)
        {
            try
            {
                if (resKind == "Результаты")
                {
                    throw new Exception("Выберите результаты для построения графика используя панель анимации");
                }

                if (NavigatorControl.TreeView.SelectedNode?.Level != 2)
                {
                    throw new Exception("Выберите вид результатов в разделе результаты");
                }
                var selNode = NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

                var result = Project.ResultData.FindByTime(resKind, time);

                var objs = Project.ModelData.ObjectData.GetObjects(objsType).
                    Where(x => x.MasterColor == SceneControl.SelectionColor).ToList();

                objs.Sort();

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

                    grContainer.CreateGraphObj(resDes, new List<GraphData>() { grData }, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        TopMost = true,
                        Icon = ResultModule.Properties.Resources.Graph,
                        Text = $"График {resDes} - координата"
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

        private void CreateTimeGraph(string resKind, ObjType objsType)
        {
            try
            {

                if (resKind == "Результаты")
                    throw new Exception("Выберите результаты для построения графика используя панель анимации");

                if (NavigatorControl.TreeView.SelectedNode?.Level != 2)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                var selNode = NavigatorControl.TreeView.SelectedNode;
                var resDes = selNode.Name;

                var results = Project.ResultData.FindByTaskKind(resKind);

                var grDataAr = new List<GraphData>();

                var objs = Project.ModelData.ObjectData.GetObjects(objsType).Where(x => x.MasterColor == SceneControl.SelectionColor);
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
                    var grData = new GraphData(resDes, Color.Orange, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }

                var grContainer = new GraphContainer();

                if (grDataAr.Count != 0)
                {
                    grContainer.CreateGraphObj(resDes, grDataAr, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        TopMost = true,
                        Icon = ResultModule.Properties.Resources.Graph,
                        Text = $"График {resDes} - время"
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

        private async void LoadResults(string fileName,bool mergeRes, bool addRes)
        {
            var dbExtension = System.IO.Path.GetExtension(fileName);
            var pureFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);

            IResultsLoader resultsLoader;
            if (dbExtension == ".db")
                resultsLoader = new LoadResultsFileDB();
            else
                resultsLoader = new LoadResultsFileBrfTextFormat();

            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоУзлам"].Nodes.Clear();
            NavigatorControl.TreeView.Nodes["Результаты"].Nodes["ПоЭлементам"].Nodes.Clear();

            if (!addRes)
                Project.ResultData.Clear();

            Enabled = false;
            PrintCommand("Выполняется загрузка результатов...");
            var res = await LoadResultsAsync(fileName, resultsLoader);
            PrintCommand("");
            Enabled = true;

            if (mergeRes)
            {
                Enabled = false;
                PrintCommand("Выполняется пересчет результатов с элементов на узлы...");
                await MergeResults(res);
                ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);
                PrintCommand("");
                Enabled = true;
            }

            Project.ResultData.AddRange(res);

            Application.OpenForms["Animation"]?.Close();
        }

        private async Task<List<IResult>> LoadResultsAsync(string fileName, IResultsLoader resultsLoader)
        {
            var res = new List<IResult>();
            await Task.Run(new Action(() =>
            {

                foreach (var result in resultsLoader.Load(fileName))
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo(result.ToString(), Color.Black);
                    }));

                    res.Add(result);
                }

            }));
            return res;
        }

        private async Task MergeResults(IEnumerable<IResult> results)
        {
            IElement[] elements;
            if (Project.TaskType == TaskType.Volume)
                elements = Project.ModelData.ObjectData.E3DCollection.ToArray();
            else
                elements = Project.ModelData.ObjectData.E2DCollection.ToArray();

            var act = new Action(() =>
            {
                var interfaceNodes = ModelController.InterfacedNodesFinder.Find(elements);
                var mergeResults = new MergeResults(results);
                var resNames = results.First().GetDataSchema("elements");

                for (int i = 1; i < resNames.Count; i++)
                {
                    mergeResults.Merge(interfaceNodes, resNames[i]);

                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Выполнен пересчет на узлы для {resNames[i]}", Color.Black);
                    }));
                }
            });

            await Task.Run(act);
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

        public void CreateScale()
        {
            SceneControl.HideGeometryObj("DisplaySceneScale");
            ISceneScale sceneScale;
            if(NavigatorControl.TreeView.SelectedNode?.Level == 3)
            {
                var title = NavigatorControl.TreeView.SelectedNode.Parent.Name;
                var comments = NavigatorControl.TreeView.SelectedNode.Name;
                sceneScale = SceneControl.CreateScaleObject(
          scale.MinValue,scale.MaxValue, scale.ValueRange().Count(), title, comments);
            }
            else
                sceneScale = SceneControl.CreateScaleObject(
          scale.MinValue, scale.MaxValue, scale.ValueRange().Count(), "", "");

            SceneControl.DisplaySceneScale(sceneScale, scale.Coord_X, scale.Coord_X);
        }

        private void ShowResultValue(string objsType, string resName, IResult result)
        {
            IEnumerable<IModelObject> objs;
            if (objsType == "Узлы")
                objs = Project.ModelData.ObjectData.NodeCollection;
            else
                objs = Project.ModelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.MasterColor == SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentr();
                    var res = 0.0f;
                    if (objsType == "Узлы")
                        res = result.GetNodeValue(obj.Number, resName);
                    else res = result.GetElementValue(obj.Number, resName);
                    SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

        private void ResultPage_Load(object sender, EventArgs e)
        {
            if (Project.ResultData == null)
                Project.ResultData = new ResultData();
        }
    }   
}
