using BazisGUI.GantChart;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьНаДиаграммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripMenuItem;
                if(btn.Checked)
                    ShowGantChart(project.GetAllCondData());
                else
                    HideGantChart();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void HideGantChart()
        {
            HideTabButton("btnTabГант");
            splitContainer3.Panel1.Controls.RemoveByKey("cntrГант");
        
        }

        public void ShowGantChart(IEnumerable<ICondData> tasks)
        {
            var ganttContol = new cntrГант();
            ganttContol.AddConds(tasks);

            ShowTabButton("btnTabГант");

            ganttContol.Size = cntrНавигатор.Size;
            ganttContol.Location = cntrНавигатор.Location;
            ganttContol.Anchor = cntrНавигатор.Anchor;
            
            splitContainer3.Panel1.Controls.Add(ganttContol);
            ganttContol.BringToFront();
        }
    }
}
