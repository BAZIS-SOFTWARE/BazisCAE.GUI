using BaseModule;
using CustomControls;
using CustomControls.Controls;
using CustomControls.OS;
using Geometry;
using Gif.Components;
using Graph;
using Model;
using ModelController.MeshObjsUtility;
using ModelController.ModelScenePresentator;
using Project.Interfaces;
using Project.IO;
using Project.ResultsData;
using Project.ResultsData.ScenePresenter;
using Project.ResultsData.ScenePresenter.Interfaces;
using Project.TasksData;
using Scene;
using SceneInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToolStrips;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ResultModule
{
    public partial class ResultPage: BasePage
    {
        IScale scale;
        
        private bool showResultValue;

        Dictionary<string, int> imgDict;
        //Dictionary<string,List<float>> resItems;

        private ScalePage scPage;
        private AnimationPage anPage;

        public ResultPage()
        {
            InitializeComponent();

            scale = new RainbowScale(1, 0, 10);

            imgDict = new Dictionary<string, int>()
            {
                { "Узлы",3},
                { "Элементы",4},
            };

            //resItems = new Dictionary<string, List<float>>();

            var resToolStrip = new ResultsToolStrip
            {
                Renderer = new BtnToolStrRender()
            };
            resToolStrip.ItemClicked += ResultsToolStrip_ItemClicked;

            AddToolStrip(resToolStrip);

            TreeView.Nodes.Add(new TreeNode("Результаты", 1, 1) { Name = "Результаты" });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var resKinds = Project.ResultData.GetResultKinds();
            foreach (var resKind in resKinds)
            {
                var results = Project.ResultData.FindByTaskKind(resKind);
                PresentResultsOnTree(results);
            }
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

            clearResultsMenuItem.Click += (ar1, ar2) => { ClearResults(); };

            ToolStripMenuItem addResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "addResults",
                Text = "Добавить результаты"
            };

            addResultsMenuItem.Click += (ar1, ar2) => { AddResults(); };

            ToolStripMenuItem loadResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "loadResults",
                Text = "Загрузить результаты"
            };

            loadResultsMenuItem.Click += (ar1, ar2) => { ShowOpenResultsFileDialog(); };

            ToolStripMenuItem hideResultsMenuItem = new ToolStripMenuItem()
            {
                Name = "hideResults",
                Text = "Скрыть результаты"
            };

            hideResultsMenuItem.Click += (ar1, ar2) => { HideResults(); };

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
            scPage = new ScalePage() { Dock = DockStyle.Fill };

            scPage.Max = scale.MaxValue;
            scPage.Min = scale.MinValue;

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
                    SceneControl.HideGeometryObj("CreateScaleObject");
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
            scForm.FormClosed += (ar1, ar2) => 
            { scPage = null; SceneControl.HideGeometryObj("CreateScaleObject"); };

            scForm.Controls.Add(scPage);
            scForm.Show();
        }

        private void CreateGraph()
        {       
            var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                if (TreeView.SelectedNode?.Level == 3)
                    CreateTimeGraph(TreeView.SelectedNode.Parent.Parent.Name, ar2.ObjsType);
                else ConsoleControl.PrintInfo("Выберите результаты для построения графика!", Color.Red);
            };
            grPage.CreatePathGraphEvent += (ar1, ar2) =>
            {
                if (TreeView.SelectedNode?.Level == 3)
                    CreatePathGraph(TreeView.SelectedNode.Parent.Parent.Name, ar2.ObjsType, ar2.Time);
                else ConsoleControl.PrintInfo("Выберите результаты для построения графика!", Color.Red);
            };

            grPage.SelectObjectsEvent += (ar) => 
            {
                ClearAllDataOnScene();

                var presenter = new ModelScenePresentator(Project.Model);
                SceneControl.SetPresentor(presenter);

                PresentAllModelObjectsOnScene();

                var selectToolStrip = FindToolStrip<SelectToolStrip>();

                foreach (var objsType in selectToolStrip.GetObjsTypes())
                {
                    if (objsType == ar)
                        selectToolStrip.SelectObjectsType = objsType;
                }
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
            var scForm = new Form() { TopMost = true, Text = "Построить график",Icon = icon, Size = grPage.Size };
            scForm.Controls.Add(grPage);
            scForm.Show();
        }

        private void ShowAnimation()
        {
            anPage = new AnimationPage() { Dock = DockStyle.Fill };
            anPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (TreeView.SelectedNode?.Level == 3)
                    ShowResults(ar2.Time, ar2.ResultKind, ar2.ScaleFactor);
                else ConsoleControl.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            anPage.CreateGIFAnimationEvent += CreateGIFAnimation;
            anPage.SaveScreenShotEvent += (ar1) => { CreateScreenShot(ar1); };

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

        //Вспомогательный метод, "меняет местами" два элемента
        public static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            //Временная (вспомогательная) переменная, хранит значение первого элемента
            int tmpParam = aFirstArg;

            //Первый аргумент получил значение второго
            aFirstArg = aSecondArg;

            //Второй аргумент, получил сохраненное ранее значение первого
            aSecondArg = tmpParam;
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

        private void HideResults()
        {
            ClearAllDataOnScene();

            var presenter = new ModelScenePresentator(Project.Model);
            SceneControl.SetPresentor(presenter);

            PresentAllModelObjectsOnScene();

            var selToolStrip = FindToolStrip<SelectToolStrip>();
            if (selToolStrip.GetObjsTypes().Count() != 0)
            {
                selToolStrip.GetObjsTypes().First();
                SceneControl.DisplayObjects();
            }
        }

        private void ShowOpenResultsFileDialog()
        {
            var openDialogEx = new OpenFileDialogEx()
            {
                StartLocation = AddonWindowLocation.Right,
                DefaultViewMode = FolderViewMode.Thumbnails,
            };

            openDialogEx.OpenDialog.InitialDirectory = Path.GetFullPath(Application.ExecutablePath);
            openDialogEx.OpenDialog.AddExtension = true;

            //openDialogEx.Size = new Size(650,267);
 
            openDialogEx.StartLocation = AddonWindowLocation.None;

            openDialogEx.OpenDialog.Filter = "Results files (*.db)|*.db";

            if (openDialogEx.ShowDialog(this) == DialogResult.Cancel)
                return;
            //resItems.Clear();
            Project.ResultData.Clear();
            TreeView.Nodes[4].Nodes.Clear();
            LoadResults(openDialogEx.OpenDialog.FileName, openDialogEx.MergeResults);
        }

        private void ResultsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Tag.ToString() == "0")
            {
                ClearResults();
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                AddResults();
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                ShowOpenResultsFileDialog();
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                HideResults();
            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                ShowValue(e.ClickedItem.Pressed);
            }
            else if (e.ClickedItem.Tag.ToString() == "5")
            {
                if (anPage == null)
                    ShowAnimation();

            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                CreateGraph();
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                if (scPage == null)
                    ShowScale();
            }
        }

        private void AddResults()
        {
            ShowOpenResultsFileDialog();
        }

        private void ClearResults()
        {
            HideResults();

            Project.ResultData.Clear();
            TreeView.Nodes[4].Nodes.Clear();
        }

        private void ShowResults(float time, string resKind, int scaleFactor)
        {
            //var timeStr = rtbTimeSteps.Lines[resIndex];

            var selNode = TreeView.SelectedNode;
            var resDes = selNode.Name;

            var colorRanges = scale.ColorRange().ToArray();
            var valueRanges = scale.ValueRange().ToArray();

            var result = Project.ResultData.FindByTime(resKind, time);

            var scenePresentor = new FieldCreator(Project);
            
            if(Project.TaskType == TaskType.Volume)
            {
                var els3D = Project.Model.ObjectData.FindMany<Element3D>().ToArray();
                scenePresentor.SetFieldCreator(new GradientFieldsCreator(els3D, valueRanges, colorRanges, scaleFactor));
            }
            else
            {
                var els2D = Project.Model.ObjectData.FindMany<Element2D>().ToArray();
                scenePresentor.SetFieldCreator(new GradientFieldsCreator(els2D, valueRanges, colorRanges, scaleFactor));
            }

            var resName = TreeView.SelectedNode.Name;
            var objsType = TreeView.SelectedNode.Parent.Name;
            var resultSurfaces = scenePresentor.CreateFieldObjects(result, objsType, resName);

            if (showResultValue)
                ShowResultValue(objsType, resName, result);

            SceneControl.HideAllVBObjects();
            SceneControl.DeleteAllVBObjects();

            var resultModel = new ModelData();
            resultModel.ObjectData.AddRange(resultSurfaces);
            var presenter = new ModelScenePresentator(resultModel);

            SceneControl.SetPresentor(presenter);

            SceneControl.CreateVBObjects("Поверхность");
            SceneControl.ChangeViewModeVBObjects("Поверхность", Scene.VBO.ObjView.Surface);
            SceneControl.ShowVBObject("Поверхность");
            SceneControl.DisplayObjects();
        }

        private void CreatePathGraph(string resKind, string objsType, float time)
        {

            var selNode = TreeView.SelectedNode;
            var resDes = selNode.Name;

            var result = Project.ResultData.FindByTime(resKind, time);

            var objs = SceneControl.GetSelectedObjects().Select(x => Project.Model.ObjectData.Find(x)).ToList();
            objs.SortByDistance();

            var pathPoints = new List<Point3D>();
            var path = 0.0f;
            var grPoints = new List<SimpleGraphPoint>();

            if (result != null)
                foreach (var obj in objs)
                {
                    var res = 0.0f;
                    if (objsType == "Узлы")
                        res = result.GetNodeValue(obj.Number, resDes);
                    else res = result.GetElementValue(obj.Number, resDes);

                    var point = obj.CalcCentralPoint();

                    var delta = new Point3D();
                    if (pathPoints.Count > 0)
                        delta = point.Sub(pathPoints.Last());
                    path += Vector.GetVectorLenght(delta);

                    pathPoints.Add(obj.CalcCentralPoint());

                    var grPoint = new SimpleGraphPoint(path, res);
                    grPoints.Add(grPoint);
                }

            if (grPoints.Count != 0)
            {
                var grData = new GraphData(resDes, Color.Orange, false, "Путь", resDes, grPoints.ToArray());
                var grContainer = new GraphContainer();

                grContainer.CreateGraphObj(resDes, new List<GraphData>() { grData });
                grContainer.Dock = DockStyle.Fill;
                var form = new Form
                {
                    TopMost = true
                };
                form.Controls.Add(grContainer);
                form.Show();
            }

        }

        private void CreateTimeGraph(string resKind, string objsType)
        {

            var selNode = TreeView.SelectedNode;
            var resDes = selNode.Name;

            var results = Project.ResultData.FindByTaskKind(resKind);
            var grDataAr = new List<GraphData>();


            foreach (var objNumber in SceneControl.GetSelectedObjects())
            {
                var grPoints = new List<SimpleGraphPoint>();

                foreach (var result in results)
                {
                    var res = 0.0f;
                    if (objsType == "Узлы")
                        res = result.GetNodeValue(objNumber, resDes);
                    else res = result.GetElementValue(objNumber, resDes);

                    var grPoint = new SimpleGraphPoint(result.Time, res);
                    grPoints.Add(grPoint);
                }
                var grData = new GraphData(resDes, Color.Orange, false, "Время", resDes, grPoints.ToArray());
                grDataAr.Add(grData);
            }

            var grContainer = new GraphContainer();

            if (grDataAr.Count != 0)
            {
                grContainer.CreateGraphObj(resDes, grDataAr);
                grContainer.Dock = DockStyle.Fill;
                var form = new Form
                {
                    TopMost = true
                };
                form.Controls.Add(grContainer);
                form.Show();
            }

        }

        private void LoadResults(string fileName,bool mergeRes)
        {
            var dbExtension = System.IO.Path.GetExtension(fileName);
            var pureFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);

            IResultsLoader resultsLoader;
            if (dbExtension == ".db")
                resultsLoader = new LoadResultsFileDB();
            else
                resultsLoader = new LoadResultsFileBrfTextFormat();

            resultsLoader.LoadEvent += (ar1, ar2) => { ConsoleControl.PrintInfo(ar2.Message, Color.Black); };
            var results = resultsLoader.Load(fileName);

            if (results.Count() == 0)
            {
                ConsoleControl.PrintInfo("База данных не содержит результатов!", Color.Red);
                return;
            }

            if(mergeRes)
            {
                ConsoleControl.PrintInfo("Выполняется пересчет результатов с элементов на узлы...", Color.Black);           
                MergeResults(results);
                ConsoleControl.PrintInfo("Пересчет завершен", Color.Green);
            }

            Project.ResultData.AddRange(results, new ResultsComparer());

            var resKind = results.First().TaskKind.ToString();

            if (TreeView.Nodes[4].Nodes.Find(resKind, false).Count() == 0)
                PresentResultsOnTree(results);

            anPage?.Clear();
        }

        private void MergeResults(List<Result> results)
        {
            Element[] elements;
            if (Project.TaskType == TaskType.Volume)
                elements = Project.Model.ObjectData.FindMany<Element3D>().ToArray();
            else
                elements = Project.Model.ObjectData.FindMany<Element2D>().ToArray();
            
            var interfaceNodesFinder = new FindInterfacedNodes(elements);
            var interfaceNodes = interfaceNodesFinder.Find();
            var mergeResults = new MergeResults(results);
            var resNames = results[0].GetDataSchema("elements");

            for (int i = 1; i < resNames.Count; i++)
                mergeResults.Merge(interfaceNodes, resNames[i]);
        }

        public void PresentResultsOnTree(IEnumerable<Result> results)
        {
            var nodeSchema = results.First().GetDataSchema("nodes");
            var elemSchema = results.First().GetDataSchema("elements");
            var resultsName = results.First().TaskKind.ToString();
            var resNode = new TreeNode()
            {
                Text = resultsName,
                Name = resultsName,
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                Tag = "3"
            };

            var nodesNode = new TreeNode()
            {
                Text = "Узлы",
                Name = "Узлы",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                Tag = "3.1"
            };
            CreateTreeNodesResDesc(nodeSchema, nodesNode, imgDict["Узлы"]);
            resNode.Nodes.Add(nodesNode);

            var elemsNode = new TreeNode()
            {
                Text = "Элементы",
                Name = "Элементы",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                Tag = "3.1"
            };
            CreateTreeNodesResDesc(elemSchema, elemsNode, imgDict["Элементы"]);
            resNode.Nodes.Add(elemsNode);

            TreeView.Nodes[4].Nodes.Add(resNode);
        }

        public void CreateTreeNodesResDesc(List<string> resultSchema, TreeNode treeNode, int picIndex)
        {
            foreach (var desc in resultSchema)
            {
                var node = new TreeNode()
                {
                    Text = desc,
                    Name = desc,
                    ImageIndex = picIndex,
                    SelectedImageIndex = picIndex,
                    Tag = "3.1.1"
                };
                treeNode.Nodes.Add(node);
            }
        }

        public void CreateScale()
        {
            SceneControl.HideGeometryObj("CreateScaleObject");
            if(TreeView.SelectedNode?.Level == 3)
            {
                var title = TreeView.SelectedNode.Parent.Name;
                var comments = TreeView.SelectedNode.Name;
                SceneControl.CreateScaleObject(
          scale.Coord_X, scale.Coord_Y, scale.ColorRange().ToArray(), scale.ValueRange().ToList(), title, comments);
            }
            else
                SceneControl.CreateScaleObject(
          scale.Coord_X, scale.Coord_Y, scale.ColorRange().ToArray(), scale.ValueRange().ToList(), "", "");
        }

        private void ShowResultValue(string objsType, string resName, Project.ResultsData.Result result)
        {
            SceneControl.HideDisplayText3D();

            foreach (var obj in Project.Model.ObjectData.FindMany(objsType))
            {
                if (obj.MasterColor == SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentralPoint();
                    var res = 0.0f;
                    if (objsType == "Узлы")
                        res = result.GetNodeValue(obj.Number, resName);
                    else res = result.GetElementValue(obj.Number, resName);
                    SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

    }   
}
