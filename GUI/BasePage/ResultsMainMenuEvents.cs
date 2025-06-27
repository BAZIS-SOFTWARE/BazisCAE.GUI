using BaseModule.Navigator;
using BaseModule.Results.Export;
using BaseModule.Results.GraphCreation;
using BaseModule.Results.ScaleControl;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
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

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void усреднитьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (усреднитьРезультатыToolStripMenuItem.Checked)
                MergeResultsValue = true;
            else
            {
                MergeResultsValue = false;
            }
        }
        private void exportResultsMenuItem_Click(object sender, EventArgs e)
        {
            if (ResultDbPath.Equals(string.Empty))
            {
                console.PrintInfo($"Не указан путь к базе результатов. Загрузите результаты перед экспортом.", Color.Orange);
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

                if (arg.ExportType == ExportType.Results) ExportResultsAsync(project.ModelData, result, arg);
                else ExportGridAsync(project.ModelData, project.GeneralData, result, arg);
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
                Location = scene.PointToScreen(Point.Empty)
            };

            exportForm.FormClosed += (ar1, ar2) => { exportPage = null; };
            exportForm.Controls.Add(exportPage);
            exportForm.Show();
        }
        private void scaleSettingsMenuItem_Click(object sender, EventArgs e)
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
                scale.FillRange(ar2.Min, ar2.Max, ar2.Range);
            };
            scPage.ShowScaleEvent += (ar1, ar2) =>
            {
                scene.SceneControl.HideGeometryObj("DisplaySceneScale");

                if (ar2)
                {
                    scale.Coord_X = scPage.X_Coord;
                    scale.Coord_Y = scPage.Y_Coord;


                    scene.SceneControl.DisplaySceneScale(scale);
                }

                scene.SceneControl.DisplayObjects();
            };
            scPage.SetX_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_X = (int)ar2;
            };
            scPage.SetY_PositionEvent += (ar1, ar2) =>
            {
                scale.Coord_Y = (int)ar2;
            };

            var scForm = new Form()
            {
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
            scForm.FormClosed += (ar1, ar2) => { scene.ClearAllGeometryDataOnScene(); };
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

                scene.ClearAllDataOnScene();
                //scene.PresentAllModelObjectsToScene();
                //scene.SelectedObjects = ObjType.Узел.ToString();

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
                ShowResultsField = true;
            else
            {
                ShowResultsField = false;
            }
        }
        private void показатьЗначенияВЭлементахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (показатьЗначенияВЭлементахToolStripMenuItem.Checked)
                ShowElementsResultsValue = true;
            else
            {
                ShowElementsResultsValue = false;
                scene.SceneControl.HideDisplayText3D();
                scene.SceneControl.DisplayObjects();
            }
        }
        private void showNodeValueMenuItem_Click(object sender, EventArgs e)
        {

            if (showNodeValueMenuItem.Checked)
                ShowNodeResultsValue = true;
            else
            {
                ShowNodeResultsValue = false;
                scene.SceneControl.HideDisplayText3D();
                scene.SceneControl.DisplayObjects();
            }
        }
        private void loadResultsMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = dataController.OpenResults();

            project.GeneralData.ResultDB = fileName;

            PresentResultsInfo(project.GeneralData.ResultDB);
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
    }
}
