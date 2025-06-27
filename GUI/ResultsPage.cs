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
    public partial class BaseForm
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

        public IEnumerable<float> GetResultTimes()
        {
            foreach (var item in resultTimes)
            {
                yield return item;
            }
        }       

        public void SetAnimation(AnimationPage animationPage)
        {

            animationPage.ShowResultEvent += (ar1, ar2) =>
            {
                if (navigator.GetSelectedNode()?.Level == 1)
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

                else console.PrintInfo("Выберите результаты для отображения!", Color.Red);
            };

            animationPage.CreateGIFAnimationEvent += (arg1, arg2) => 
            {
                CreateGIFAnimationEvent?.Invoke(this, arg2);
            };
            animationPage.SaveScreenShotEvent += (ar1) => { CreateScreenShot(ar1); };
        }

        public void ShowAnimation()
        {   
            //var anPage = embeddedControls.Find("pinnedAnimationControl", false)[0];

            //EmbeddedSplitContainer.SplitterDistance = EmbeddedSplitContainer.Panel1.Width - anPage.Width;         
            //EmbeddedSplitContainer.Panel2Collapsed = false;
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
                navigator.TrySearchNodes(NodeType.результаты.ToString(), out List<TreeNode> nodes);
                foreach (TreeNode item in nodes[0].Nodes)
                    tables.Add(item.Text);


                for (int i = 0; i < args.Times.Length; i++)
                {
                    var result = loader.GetResult(ResultDbPath, tables, args.Times[i]); //resultData.FindByTime(args.ResltsKind, args.Times[i]);
                    ShowResults(generalData, modelData, result, args.ScaleFactor);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{generalData.Path}\{image}.bmp";
                    CreateScreenShot(imagePath);

                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var bmpImage = Image.FromStream(stream);

                        //var bmpImage = Image.FromFile(imagesPaths[i]);
                        e.AddFrame(bmpImage);
                        var total = ((i + 1) / (float)args.Times.Length * 100).ToString("#.##");
                        console.PrintInfo($@"Создание GIF анимации {total}%", Color.Black);
                    }
                    File.Delete(imagePath);
                }
                e.Finish();
                console.PrintInfo("GIF анимация создана", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
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
                var resName = navigator.GetSelectedNode().Name;
                var tableName = ResultType.nodes.ToString();

                scale.Title = result.TaskKind.ToString();
                scale.Info = $"{resName} {result.Time}";

                if (MergeResultsValue)
                    MergeResults(generalData, modelData,result);

                if (!IsScaleMaxMinManual)
                    SetMaxMinAuto(result, tableName, resName);

                if (ShowResultsField)
                {
                    scene.ClearAllGeometryDataOnScene();
                    scene.ClearAllMeshDataOnScene();

                    var presenter = CreateResultsField(generalData,modelData, result, scaleFactor, resName, tableName);
                    scene.CreateObjectsOnScene(ObjType.Поверхность.ToString(), presenter);
                }

                if (ShowNodeResultsValue)
                {
                    scene.SceneControl.HideDisplayText3D();
                    ShowResultValue(modelData, ResultType.nodes, resName, result);
                }


                if (ShowElementsResultsValue)
                {
                    scene.SceneControl.HideDisplayText3D();
                    ShowResultValue(modelData,ResultType.elements, resName, result);
                }


                if (showScale)
                {
                    scene.SceneControl.HideGeometryObj("DisplaySceneScale");
                    scene.SceneControl.DisplaySceneScale(scale);
                }

                scene.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                console.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
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
            return scene.PresentersCreator.CreateSurfaceObjectsPresenter(elsResults);
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

        

        private async void CreateTimeGraph(LoadResultsFileDB loader, GraphObjects objsType, IObjectsData objectsData)
        {
            try
            {
                if (navigator.GetSelectedNode()?.Level != 1)
                    throw new Exception("Выберите вид результатов в разделе результаты");

                scene.ClearAllDataOnScene();
                //scene.PresentAllModelObjectsToScene();
                //scene.SelectedObjects = objsType.ToString();

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

                    scene.SceneControl.DisplayText3D($"{objsType}_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"{objsType}_{obj.Number}", color, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                scene.SceneControl.DisplayObjects();
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

            scene.SceneControl.DisplayText2D(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения", Color.Black, new Point2D(10, 10));
            scene.SceneControl.DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                    {
                        var objs = ObjectsProvider.GraphPageProvider(objsData, objType);
                        nodes = objs.Where(x => x.Color == scene.SceneControl.SelectionColor).ToList();
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
            scene.SceneControl.HideDisplayText2D();
            scene.SceneControl.DisplayObjects();
            PressedKey = Keys.None;
            return nodes;
        }       

        public void MergeResults(IGeneralData generalData, IModelData modelData,  Result result)
        {
            try
            {
                IEnumerable<IElement> elements;
                if (generalData.TaskType == TaskType.Volume)
                    elements = modelData.ObjectData.E3DCollection.GetObjects();
                else
                    elements = modelData.ObjectData.E2DCollection.GetObjects();


                    var interfaceNodes = modelController.InterfacedNodesFinder.Find(elements);

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

        private void ShowResultValue(IModelData modelData, ResultType tableType, string resName, Result result)
        {
            IEnumerable<IModelObject> objs;

            if (tableType == ResultType.nodes)
                objs = modelData.ObjectData.NodesSet.Values;
            else
                objs = modelData.ObjectData.GetAllElements();

            foreach (var obj in objs)
            {
                if (obj.Color == scene.SceneControl.SelectionColor)
                {
                    var coord = obj.CalcCentr();
                    var res = result.GetValue((int)tableType, obj.Number, resName);
                    scene.SceneControl.DisplayText3D(res.ToString(), Color.Black, coord);
                }
            }
        }


        public void HideResults(IModelData modelData)
        {
            scene.ClearAllDataOnScene();

            scene.PresentAllModelObjectsToScene(modelData);

            scene.SceneControl.FitObjectsToScreen();
            scene.SceneControl.DisplayObjects();
        }

        public void RemoveResults(IModelData modelData)
        {
            navigator.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
            //nodes[0].Nodes["ПоУзлам"].Nodes.Clear();
            //nodes[0].Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

            scene.ClearAllDataOnScene();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                scene.CreateObjectsOnScene(item.ToString(), scene.CreateObjectsPresentor(modelData,item));

            scene.SceneControl.DisplayObjects();

            //var anPage = (PinnedAnimationControl)EmbeddedControls.Find("pinnedAnimationControl", false)[0];
            //anPage.AnimationPage.ClearResultsItems();
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
