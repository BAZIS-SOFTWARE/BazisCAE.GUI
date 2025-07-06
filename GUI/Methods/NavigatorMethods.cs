using BaseModule.Navigator;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseModule.Extensions;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions.Welding;
using Geometry;
using BaseModule.GanttChart;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BazisGUI.TasksControls;
using Newtonsoft.Json;
using Project.TaskParameters;
using System.IO;
using BaseModule.Results.Animation;
using Gif.Components;
using Project.Results.IO;
using Project.Results;
using BazisGUI.Scene;

namespace BazisGUI
{
    enum ResultType { nodes, elements }
    public partial class BaseForm
    {
        public void ShowResults(Result result)
        {
            try
            {
                var resName = navigator.GetSelectedNode().Name;
                var tableName = ResultType.nodes.ToString();

                if (settingsConfig.MergeResultsValue)
                    MergeResults(result);

                if (settingsConfig.ShowResultsField)
                {
                    var scale = new SceneScale(0, 1, 2, "", "");

                    scale.Title = result.TaskKind.ToString();
                    scale.Info = $"{resName} {result.Time}";
                    scale.Coord_X = settingsConfig.Scale_X_Coord;
                    scale.Coord_Y = settingsConfig.Scale_Y_Coord;

                    if (!settingsConfig.IsScaleMaxMinManual)
                    {
                        var res = GetMaxMin(result, tableName, resName);
                        scale.FillRange(res.Item2, res.Item1, settingsConfig.Scale_Intervals);
                    }
                    else
                        scale.FillRange(settingsConfig.Scale_MinValue, settingsConfig.Scale_MaxValue, settingsConfig.Scale_Intervals);


                    ClearAllGeometryDataOnScene();
                    ClearAllMeshDataOnScene();

                    var scaleItems = GetScaleItems(scale);
                    resultsController.ResultsFieldsCreator.SetScaleItems(scaleItems);
                    resultsController.ResultsFieldsCreator.ScaleFactor = settingsConfig.Scale_scale;

                    var presenter = CreateResultsField(result, resName, tableName);
                    CreateObjectsOnScene(presenter);

                    HideGeometryObj("DisplaySceneScale");
                    DisplaySceneScale(scale);
                }

                if (settingsConfig.ShowNodeResultsValue)
                {
                    HideDisplayText3D();
                    ShowResultValue(ResultType.nodes, resName, result);
                }


                if (settingsConfig.ShowElementsResultsValue)
                {
                    HideDisplayText3D();
                    ShowResultValue(ResultType.elements, resName, result);
                }

                DisplayObjects();

            }
            catch (Exception ex)
            {
                console.PrintInfo($@"Ошибка : {ex.Message},\n Источник : {ex.Source}", Color.Red);
            }
        }
        public void CreateGIFAnimation(CreateAnimationEventArgs args)
        {
            try
            {
                var outputFilePath = $@"{project.GeneralData.Path}\results.gif";

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
                    ShowResults(result);
                    var image = $@"screenShot_{args.Times[i]}";
                    var imagePath = $@"{project.GeneralData.Path}\{image}.bmp";
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

        public void PresentMatAndFuncDataOnTree(IGeneralData generalData)
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeType.базаМатериалов, out List<TreeNode> mats);
                mats[0].Text = $"База материалов : {generalData.Materials}";

                navigator.TrySearchNodes(NodeType.базаФункций, out List<TreeNode> func);
                func[0].Text = $"База функций : {generalData.Functions}";

                navigator.EndUpdate();

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        public void PresentCondDataOnTree(IGeneralData generalData, ITaskData taskData)
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeType.условия, out List<TreeNode> cond);
                cond[0].Nodes.Clear();

                PresentMatAndFuncDataOnTree(generalData);

                foreach (var data in taskData)
                {
                    var nodeType = data.Kind.ToString().ToEnum<NodeType>();
                    var imgIndex = navigator.GetObjectImageIndex(nodeType);

                    var child = navigator.CreateRealNode(nodeType, $"{data}");
                    child.ImageIndex = imgIndex;
                    child.SelectedImageIndex = imgIndex;

                    navigator.TrySearchNodes(NodeType.условия.ToString(), out List<TreeNode> nodes);
                    nodes.First().Nodes.Add(child);
                }

                navigator.EndUpdate();
                cond[0].Expand();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void PresentObjectsDataOnTree(IObjectsData objectsData)
        {
            navigator.BeginUpdate();

            navigator.TrySearchNodes("объекты", out List<TreeNode> nodes);
            foreach (TreeNode item in nodes[0].Nodes)
                item.Nodes.Clear();

            foreach (ObjType objType in Enum.GetValues(typeof(ObjType)))
                foreach (var item in objectsData.GetSetsInfo(objType))
                {
                    if (item.NumberOfObjects > 0)
                    {
                        //if(item.ObjType == ObjType.Узел)
                        //    nodes[0].Nodes[NodeType.Узлы.ToString()]
                        var root = Converters.ConvertToNavigatorNodeType(item.ObjType);
                        navigator.TryCreateNode(root.ToString(), item.Name, $"{item.Name} {item.NumberOfObjects}", NodeKind.virt);
                    }
                }
            navigator.EndUpdate();
        }

        private void DisplayMRF(float time, IPhysicalData data)
        {
            var mf = data.FrameFunction.LocalFrame as MovedFrame;
            mf.Time = time - data.StartTime;

            DisplayLocalFrame(mf.Frame);
            var trajPoints = mf.BaseLine.Select(x => x.CalcCentr()).ToArray();
            DisplayPath(trajPoints);

            if (data.FrameFunction is SphereFunction sphear)
            {
                DisplaySphere(sphear.Width, mf.Frame);
            }
            else if (data.FrameFunction is CillindricalFunction cilinder)
            {
                DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, mf.Frame);
            }
        }

        public void DisplayDirection(float time, IPhysicalData data, IEnumerable<IModelObject> modelObjs)
        {
            var vector = new Point3D();
            Color color;

            if (data.Direction == Direction.X)
            {
                vector = new Point3D(1, 0, 0);
                color = Color.FromArgb(255, 0, 0);
            }

            else if (data.Direction == Direction.Y)
            {
                vector = new Point3D(0, 1, 0);
                color = Color.FromArgb(0, 255, 0);
            }

            else
            {
                vector = new Point3D(0, 0, 1);
                color = Color.FromArgb(0, 0, 255);
            }

            foreach (var obj in modelObjs)
            {
                foreach (var point in obj.GetCoordinates())
                {
                    var scl = 10 * (1.0f / Height * 1.0f / ScaleFactor);
                    vector = vector.Mult(scl);
                    var p1 = point.Sum(vector);
                    DisplayLine(point, p1, color);
                }

                //DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        public void ShowGantChart(IEnumerable<string> tasks)
        {
            var ganttContol = new GanttChartTreeView(tasks, 10);
            var ganttDiagramForm = new Form
            {
                ClientSize = new Size(850, 600),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false
            };

            ganttDiagramForm.Controls.Add(ganttContol);
            ganttDiagramForm.Show(this);
        }

        public void EditTSFFile(string fileName)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(fileName);

                var cntr = new TaskControl();
                cntr.BtnSave_ClickEvent += (arg) =>
                {
                    File.WriteAllText(fileName, arg);
                    console.PrintInfo($"Файл {fileName} изменен", Color.Green);
                };
                cntr.InputData(parameters);

                var location = PointToScreen(Point.Empty);

                var form = new Form()
                {
                    Text = fileName,
                    ShowIcon = false,
                    ClientSize = cntr.Size,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Owner = Application.OpenForms[0],

                };
                form.Controls.Add(cntr);
                form.Location = location;
                form.Show();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Green);
            }

        }

        public GeneralParameters ReadTaskParametersFromFile(string filePath)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var taskName = fileName.Split('_')[0];

            Tasks tasksSet;
            Enum.TryParse(taskName, out tasksSet);

            if (tasksSet == Tasks.термическая)
            {
                return JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else if (tasksSet == Tasks.механическая)
            {
                return JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else return JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(filePath), settingsSerializer);

        }
    }
}
