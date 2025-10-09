using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule.Results.GraphCreation;
using ResultDB.IO;
using System.Windows.Forms;
using BazisGUI.Utilities;
using Model.Interfaces;
using System.Collections.Generic;
using UserControlsEx.Graph;
using System.Threading.Tasks;
using System.Linq;
using BaseModule.Navigator;
using Model;
using ResultDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
                    throw new Exception("Не выбран ни один узел");

                await SelectContainerAsync(@"Выберите время и нажмите на клавишу ""E"" для подтверждения");

                if (navigator.SelectedNode.Name != NodeName.Время.ToString())
                    throw new Exception("Выберите время в разделе результаты");

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
                    foreach (var obj in objs)
                    {       
                        var point = obj.CalcCentr();

                        var delta = new Point3D();
                        if (pathPoints.Count > 0)
                            delta = point.Sub(pathPoints.Last());
                        path += Vector.GetVectorLenght(delta);

                        pathPoints.Add(obj.CalcCentr());

                        var res = result.GetValue(ResultType.nodes.ToString(), obj.Number, resDes);
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
    }
}
