using System;
using Geometry;
using System.Drawing;
using ResultDB.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using UserControlsEx.Graph;
using System.Linq;
using BazisGUI.Navigator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private async void построитьДиаграммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();

                var objs = await CreatePathAsync();

                if (objs.Count() == 0)
                    throw new Exception(Localization.Localization.GetStringResourceByName("Result.BuildDiagram.NoNodesSelectedException"));

                await SelectContainerAsync(Localization.Localization.GetStringResourceByName("Result.BuildDiagram.SelectContaimerAsync.SelectTime.Message"));

                if (navigator.SelectedNode.Name != NodeName.Time.ToString())
                    throw new Exception(Localization.Localization.GetStringResourceByName("Result.BuildDiagram.SelectTime.Exception"));

                var selNode = navigator.SelectedNode;
                var resDes = selNode.Parent.Text;
                var time = float.Parse(selNode.Text);

                var loader = new LoadResultsFileDB();
                var tables = new List<string>() { ResultType.nodes.ToString() };

                var pathPoints = new List<Point3D>();
                var path = 0.0f;
                var grPoints = new List<GraphPoint>();
                
                var result = loader.GetResult(ResultDbPath, tables, time);
                if (result != null)
                {
                    if (settingsConfig.MergeResultsValue)
                        MergeResults(result);

                    foreach (var obj in objs)
                    {
                        var point = obj.CalcCentr();

                        var delta = new Point3D();
                        if (pathPoints.Count > 0)
                            delta = point.Sub(pathPoints.Last());
                        path += Vector.GetVectorLength(delta);

                        pathPoints.Add(obj.CalcCentr());

                        var res = result.GetValue(ResultType.nodes.ToString(), obj.Number, resDes);
                        var grPoint = new GraphPoint(path, res);
                        grPoints.Add(grPoint);
                    }
                }
                    

                if (grPoints.Count != 0)
                {
                    var grData = new GraphData(resDes, Color.Orange, Localization.Localization.GetStringResourceByName("Result.BuildDiagram.GraphData.XUnit"), resDes, grPoints.ToArray());
                    var grContainer = new GraphContainer();

                    grContainer.CreateGraphData(Localization.Localization.GetStringResourceByName("Result.BuildDiagram.DistanceResultSet.Header"), new List<GraphData>() { grData }, new AxisFormat(), new AxisFormat());
                    grContainer.Dock = DockStyle.Fill;
                    var form = new Form
                    {
                        Owner = Application.OpenForms[0],
                        TopMost = true,
                        Text = $"{Localization.Localization.GetStringResourceByName("Result.BuildDiagram.Text_Part1")} {resDes} - {Localization.Localization.GetStringResourceByName("Result.BuildDiagram.Text_Part2")}",
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
    }
}
