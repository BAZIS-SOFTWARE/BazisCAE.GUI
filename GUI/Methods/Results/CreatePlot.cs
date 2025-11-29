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
                        Invoke(new Action(() =>
                        {
                            console.PrintInfo("Операция отменена", Color.Black);
                        }));
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
                await SelectContainerAsync(@"Выберите узлы и нажмите на клавишу ""E"" для подтверждения");

                var nodes = project.GetModelObjects(ObjType.Узел).
                    Where(x => x.Color == settingsConfig.SelectObjectColor);

                if (nodes.Count() == 0)
                    throw new Exception("Не выбран ни один узел");

                await SelectContainerAsync(@"Выберите результат и нажмите на клавишу ""E"" для подтверждения");

                if (navigator.SelectedNode.Name != NodeName.результат.ToString())
                    throw new Exception("Выберите результат в разделе результаты");

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

                    console.PrintInfo($"Идет построение графика для объекта {obj.ObjType} {obj.Number}, подождите немного...", Color.Orange); ;

                    foreach (var time in times)
                    {
         
                        var result = loader.GetResult(ResultDbPath, tables, time);
                        if (settingsConfig.MergeResultsValue)
                            MergeResults(result);
                        var res = result.GetValue(ResultType.nodes.ToString(), obj.Number, resDes);

                        var grPoint = new GraphPoint(result.Time, res);
                        grPoints.Add(grPoint);
                    }

                    DisplayText3D($"Узел_{obj.Number}", Color.Black, obj.CalcCentr());
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    var grData = new GraphData($"Узел_{obj.Number}", color, "Сек.", resDes, grPoints.ToArray());
                    grDataAr.Add(grData);
                }
                DisplayObjects();
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
    }
}
