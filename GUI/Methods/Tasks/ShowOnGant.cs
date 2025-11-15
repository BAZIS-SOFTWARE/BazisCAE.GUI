using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьНаДиаграммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowGantChart(project.GetAllCondData());
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
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
    }
}
