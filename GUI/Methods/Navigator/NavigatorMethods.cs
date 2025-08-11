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
using BasicControls.OpenFileDialogEx;
using Project.Tasks;

namespace BazisGUI
{
    enum ResultType { nodes, elements }
    public partial class BaseForm
    {
              

        public void PresentGroupDataOnTree()
        {
            navigator.BeginUpdate();

            navigator.TrySearchNodes("группыОбъектов", out List<TreeNode> nodes);

            nodes[0].Nodes.Clear();

            foreach (var item in project.GetAllModelGroups())
            {
                var r = navigator.CreateRealNode(item.ObjType.ToString(), $"{item.Name} {item.Count}");

                nodes[0].Nodes.Add(r);
                navigator.SetContextMenu(r);
            }

            navigator.EndUpdate();
        }

        public void PresentTaskTypeAndKind()
        {
            lblStatus.Text = $"{project.Path}/{project.Name}";

            navigator.TrySearchNodes(NodeName.вид, out List<TreeNode> kind);
            kind.First().Text = $"Вид : {project.ProjectKind}";

            navigator.TrySearchNodes(NodeName.тип, out List<TreeNode> type);
            type.First().Text = $"Тип : {project.ProjectType}";

        }

        public void PresentMatAndFuncData()
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeName.базаМатериалов, out List<TreeNode> mats);
                mats[0].Text = $"База материалов : {project.MaterialsDB}";

                navigator.TrySearchNodes(NodeName.базаФункций, out List<TreeNode> func);
                func[0].Text = $"База функций : {project.FunctionsDB}";

                navigator.EndUpdate();

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        



        private void DisplayMRF(float time, ICondData data)
        {
            var mf = data.FrameFunction.LocalFrame as MovedFrame;
            mf.Time = time - data.StartTime;
            mf.CalcPosition();
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

        public void DisplayDirection(float time, ICondData data, IEnumerable<IModelObject> modelObjs)
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

            DisplayGeometryObjectEvent = null;
            
            foreach (var obj in modelObjs)
            {
                foreach (var point in obj.GetCoordinates())
                {
                    var temp = vector.Mult(0.01f);
                    var p1 = point.Sum(temp);
                    DisplayVector(temp, point, color);
                }
                //DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        public void ShowGantChart(IEnumerable<ICondData> tasks)
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
