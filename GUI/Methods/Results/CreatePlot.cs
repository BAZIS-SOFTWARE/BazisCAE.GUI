using System;
using Geometry;
using System.Drawing;
using ResultDB.IO;
using System.Windows.Forms;
using Model.Interfaces;
using System.Collections.Generic;
using UserControlsEx.Graph;
using System.Threading.Tasks;
using System.Linq;
using BazisGUI.Navigator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public async Task SelectContainerAsync(string message)
        {
            PressedKey = Keys.None;

            DisplayText2D(message, Color.Black, new Point2D(10, 10));
            DisplayObjects();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                        break;
                    if (PressedKey == Keys.Escape)
                    {
                        Invoke(new Action(() => console.PrintInfo(Localization.Localization.GetStringResourceByName("CreatePlot.SelectContainerAsync.CancelOperation.Message"), Color.Black)));
                        break;
                    }
                }
            });
            DisplayText2DEvent = null;
            DisplayObjects();
            PressedKey = Keys.None;
        }

        private async void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();
                // выбор объектов
                await SelectContainerAsync(Localization.Localization.GetStringResourceByName("CreatePlot.BuildGraph.SelectContainerAsync.SelectNodes.Message"));

                var nodes = project.GetModelObjects(ObjType.Узел).
                    Where(x => x.Color == settingsConfig.SelectObjectColor);

                if (nodes.Count() == 0)
                    throw new Exception(Localization.Localization.GetStringResourceByName("CreatePlot.BuildDiagram.NoNodesSelected.Exception"));

                await SelectContainerAsync(Localization.Localization.GetStringResourceByName("CreatePlot.BuildGraph.SelectContainerAsync.SelectResult.Message"));

                if (navigator.SelectedNode.Name != NodeName.Result.ToString())
                    throw new Exception(Localization.Localization.GetStringResourceByName("CreatePlot.BuildGraph.SelectResult.Exception"));

                var selNode = navigator.SelectedNode;
                var resDes = selNode.Text;

                var loader = new LoadResultsFileDB();

                // важно, так как если режим усреднения, то будет исключение
                var tables = new List<string>(){ResultType.nodes.ToString(), ResultType.elements.ToString() };
                var times = loader.GetValues(ResultDbPath, "nodes", "Time");

                var grDataAr = new List<GraphData>();
                Random random = new Random();

                foreach (var obj in nodes)
                {
                    var grPoints = new List<GraphPoint>();

                    console.PrintInfo($"{Localization.Localization.GetStringResourceByName("CreatePlot.BuildGraph.BuildingGraph.Text_Part1")} {obj.ObjType} {obj.Number}, {Localization.Localization.GetStringResourceByName("CreatePlot.BuildGraph.BuildingGraph.Text_Part2")}...", Color.Orange); ;

                    foreach (var time in times)
                    {
         
                        var result = loader.GetResult(ResultDbPath, tables, time);
                        if (settingsConfig.MergeResultsValue)
                            MergeResults(result);
                        var res = result.GetValue(ResultType.nodes.ToString(), obj.Number, resDes);

                        var grPoint = new GraphPoint(result.Time, res);
                        grPoints.Add(grPoint);
                    }

                    DisplayText3D($"{Localization.Localization.GetStringResourceByName("CreatePlot.DisplayText3D.Text")}_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"{Localization.Localization.GetStringResourceByName("CreatePlot.GraphData.Header_Part1")}_{obj.Number}", color, Localization.Localization.GetStringResourceByName("CreatePlot.GraphData.XUnit"), resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                DisplayObjects();
                var grContainer = new GraphContainer();

                if (grDataAr.Count != 0)
                {
                    grContainer.CreateGraphData(Localization.Localization.GetStringResourceByName("CreatePlot.CreateGraphData.Header"), grDataAr, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        Owner = Application.OpenForms[0],
                        TopMost = true,
                        Text = $"{Localization.Localization.GetStringResourceByName("CreatePlot.GraphForm.Text_Part1")} {resDes} - {Localization.Localization.GetStringResourceByName("CreatePlot.GraphForm.Text_Part2")}",
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
    }
}
