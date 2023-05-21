using AnimatedGif;
using BaseModule;
using Geometry;
using Gif.Components;
using Graph;
using MathNet.Numerics;
using MathNet.Numerics.Providers.LinearAlgebra;
using MB.Controls;
using Model;
using ModelController.ModelScenePresentator;
using Project.Interfaces;
using Project.TasksData.Functions;
using ProjectController.IO;
using ProjectController.Presenters;
using ProjectController.Presenters.ScenePresenters;
using ProjectController.Presenters.ScenePresenters.Interfaces;
using ProjectController.SceneResultPresenters;
using Scene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ToolStrips;
//using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ResultModule
{
    public partial class ResultPage: BasePage
    {
        IScale scale;
        
        private bool showResultValue;

        Dictionary<string, int> imgDict;
        Dictionary<string,List<float>> resItems;

        private int nodesObjsIndex = 3;
        private int elementsObjsIndex = 4;
        private ScalePage scPage;
        private AnimationPage anPage;

        public ResultPage()
        {
            InitializeComponent();

            TreeView.ImageList = treeNodesImageList;

            scale = new RainbowScale(4, 1, 0, 10)
            {
                Coord_X = 70,
                Coord_Y = 140
            };

            ProjectInfoIndex = 2;
            CollapseIndex = 0;
            ExpandIndex = 1;

            imgDict = new Dictionary<string, int>()
            {
                { "Узлы",nodesObjsIndex},
                { "Элементы",elementsObjsIndex},
            };

            resItems = new Dictionary<string, List<float>>();

            var resToolStrip = new ResultsToolStrip
            {
                Renderer = new BtnToolStrRender()
            };
            resToolStrip.ItemClicked += ResultsToolStrip_ItemClicked;

            AddToolStrip(resToolStrip);

            TreeView.Nodes.Add(new TreeNode("Результаты", 0, 0) { Name = "Результаты" });

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            SetVersion(verStr);
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(CreateResultsInterface());
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

            loadResultsMenuItem.Click += (ar1, ar2) => { LoadResults(); };

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
            scPage.SetScaleSetting += (ar1, ar2) =>
            {
                scale.FillRange(ar2.Precision, ar2.Max, ar2.Min, ar2.Range);

                CreateScale();
                SceneControl.DisplayObjects();

            };
            scPage.ShowScaleEvent += (ar1, ar2) =>
            {
                if (ar2)
                {
                    CreateScale();
                }

                else
                {
                    SceneControl.UnPlugGeometryObj("CreateScaleObject");
                }

                SceneControl.DisplayObjects();
            };
            scPage.SetX_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_X = (int)ar2;

                CreateScale();
                SceneControl.DisplayObjects();

                SceneControl.DisplayObjects();
            };
            scPage.SetY_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_Y = (int)ar2;

                CreateScale();
                SceneControl.DisplayObjects();

            };

            var icon = ResultModule.Properties.Resources.Scale;
            var scForm = new Form() { TopMost = true, Icon = icon, Size = scPage.Size, Name = "Scale", Text = "Шкала значений" };
            scForm.FormClosed += (ar1, ar2) => 
            { scPage = null; SceneControl.UnPlugGeometryObj("CreateScaleObject"); };

            scForm.Controls.Add(scPage);
            scForm.Show();
        }

        private void CreateGraph()
        {
            var grPage = new GraphCreationPage() { Dock = DockStyle.Fill };
            grPage.CreateTimeGraphEvent += (ar1, ar2) =>
            {
                if (TreeView.SelectedNode?.Level == 3)
                    CreateTimeGraph(ar2.ResultKind, ar2.ObjsType);
                else ConsoleControl.PrintInfo("Выберите результаты для построения графика!", Color.Red);
            };
            grPage.CreatePathGraphEvent += (ar1, ar2) =>
            {
                if (TreeView.SelectedNode?.Level == 3)
                    CreatePathGraph(ar2.ResultKind, ar2.ObjsType, ar2.Time);
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

            grPage.SetResultsItems(resItems);

            var icon = ResultModule.Properties.Resources.Graph;
            var scForm = new Form() { TopMost = true, Icon = icon, Size = grPage.Size };
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
            anPage.SetResultsItems(resItems);

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
                SceneControl.UnPlugDisplayText3D();
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

        private void LoadResults()
        {
            OpenFileDialog newProjDialog = new OpenFileDialog();

            if (newProjDialog.ShowDialog() == DialogResult.Cancel)
                return;
            resItems.Clear();
            LoadResults(newProjDialog.FileName);
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
                LoadResults();
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
            var newProjDialog = new OpenFileDialog();

            if (newProjDialog.ShowDialog() == DialogResult.Cancel)
                return;
            LoadResults(newProjDialog.FileName);
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

            var result = Project.ResultData.FindByTime(resKind, time);

            var scenePresentor = new ScenePresenter(Project);
            var elements = Project.Model.ObjectData.FindMany<Element>().ToArray();
            var colorRanges = scale.ColorRange().ToArray();
            var valueRanges = scale.ValueRange().ToArray();
            scenePresentor.SetFieldCreator(new GradientFieldsCreator(elements, valueRanges, colorRanges, scaleFactor));

            var resDesc = TreeView.SelectedNode.Name;
            var objsType = TreeView.SelectedNode.Parent.Name;
            var resultSurfaces = scenePresentor.CreateFieldObjects(result, objsType, resDes);

            if (showResultValue)
                ShowResultValue(objsType, resDes, result);

            SceneControl.DeleteAllVBObjects();

            var resultModel = new ModelData();
            resultModel.ObjectData.AddRange(resultSurfaces);
            var presenter = new ModelScenePresentator(resultModel);

            SceneControl.SetPresentor(presenter);
            PresentModelObjectsOnScene("Поверхность");

            SceneControl.UnPlugVBObjects();
            SceneControl.ChangeViewModeVBObjects("Поверхность", Scene.VBO.ObjView.Surface);
            SceneControl.PlugVBObjects();

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

        private void LoadResults(string fileName)
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
            Project.ResultData.AddRange(results);

            var times = results.Select(x => x.Time);
            var minTime = times.First();
            var maxTime = times.Last();
            var resName = $"{results[0].TaskKind}_{minTime}_{maxTime}";

            resItems.Add(resName, times.ToList());

            var nodeSchema = results[0].GetDataSchema("nodes");
            var elemSchema = results[0].GetDataSchema("elements");

            PresentResultsOnTree(resName, nodeSchema, elemSchema);

            anPage?.Clear();
        }

        private void PresentResultsOnTree(string resName, List<string> nodeSchema, List<string> elemSchema)
        {
            var resNode = new TreeNode()
            {
                Text = resName,
                Name = resName,
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
            CreateTreeNodesResDesc(nodeSchema, nodesNode, nodesObjsIndex);
            resNode.Nodes.Add(nodesNode);

            var elemsNode = new TreeNode()
            {
                Text = "Элементы",
                Name = "Элементы",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                Tag = "3.1"
            };
            CreateTreeNodesResDesc(elemSchema, elemsNode, elementsObjsIndex);
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
            SceneControl.UnPlugGeometryObj("CreateScaleObject");
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

        private void ShowResultValue(string objsType, string resDescription, Project.ResultsData.Result result)
        {
            SceneControl.UnPlugDisplayText3D();

            foreach (var obj in Project.Model.ObjectData.FindMany(objsType))
            {
                if (obj.MasterColor == SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentralPoint();
                    var res = 0.0f;
                    if (objsType == "Узлы")
                        res = result.GetNodeValue(obj.Number, resDescription);
                    else res = result.GetElementValue(obj.Number, resDescription);
                    SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }

    }   
}
