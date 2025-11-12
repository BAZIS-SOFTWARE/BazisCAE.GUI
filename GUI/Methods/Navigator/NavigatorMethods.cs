
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BazisGUI.TasksControls;
using Geometry;
using Model.Interfaces;
using Newtonsoft.Json;
using Project.Interfaces.Tasks;
using Project.TaskParameters;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions.Welding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    enum ResultType { nodes, elements }
    public partial class BaseForm
    {
               
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
            // пока не используем. Ищем замену для netCore


            // Assuming you have a List<Task> where Task has properties like Name, StartDate, EndDate
            //public class Task
            //        {
            //            public string Name { get; set; }
            //            public DateTime StartDate { get; set; }
            //            public DateTime EndDate { get; set; }
            //        }

            // In your WinForm, after populating your DataGridView (e.g., dataGridView1)
            //private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //    {
            //        // Assuming a column is designated for the Gantt bar visualization
            //        // and other columns hold task details and dates.
            //        // You would need to map the column index to your Gantt visualization column.

            //        // Example: If column 2 is for the Gantt bar
            //        if (e.ColumnIndex == 2)
            //        {
            //            // Get task data for the current row
            //            Task currentTask = (Task)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            //            // Calculate bar position and width based on dates and column width
            //            // This is a simplified example; actual calculation would be more complex
            //            // and depend on the time scale represented by the column.
            //            int barStartPixel = (int)((currentTask.StartDate - DateTime.Today).TotalDays * (e.CellBounds.Width / 30.0)); // Assuming 30 days per column width
            //            int barWidthPixel = (int)((currentTask.EndDate - currentTask.StartDate).TotalDays * (e.CellBounds.Width / 30.0));

            //            using (SolidBrush barBrush = new SolidBrush(Color.Blue)) // Example color
            //            {
            //                e.Graphics.FillRectangle(barBrush, e.CellBounds.X + barStartPixel, e.CellBounds.Y + 5, barWidthPixel, e.CellBounds.Height - 10);
            //            }

            //            e.Handled = true; // Prevent default cell painting
            //        }
            //    }
            //}



            //var ganttContol = new GanttChartTreeView(tasks);
            //var ganttDiagramForm = new Form
            //{
            //    ClientSize = new Size(850, 600),
            //    FormBorderStyle = FormBorderStyle.FixedSingle,
            //    MaximizeBox = false,
            //    MinimizeBox = false
            //};

            //ganttDiagramForm.Controls.Add(ganttContol);
            //ganttDiagramForm.Show(this);
        }
        [Obsolete("Не используем, так как свойства редактируются через панель \"свойств\"")]
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
