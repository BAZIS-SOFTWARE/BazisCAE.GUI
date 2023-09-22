using System;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using BaseModule.ToolStrips;
using TaskModule.ToolStrips;

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage()
        {
            InitializeComponent();
        }

        private void HtPage_Load(object sender, EventArgs e)
        {

            //var htTaskToolStrip = new HeatTreatmentTasksToolStrip() { Name = "Термообработка" };
            heatTreatmentTasksToolStrip.Renderer = new BaseToolStrRender();
            heatTreatmentTasksToolStrip.advisorStatusChanged += HtTaskToolStrip_advisorStatusChanged;

            AddToolStrip(heatTreatmentTasksToolStrip);
        }

        private void HtTaskToolStrip_advisorStatusChanged(object arg1, AdvisorEventArgs arg2)
        {
            if (!arg2.Status)
            {
                var taskAdv = new HeatTreatmentAdvisor() { Dock = DockStyle.Fill, Name = "Термообработка" };
                var icon = TaskModule.Properties.Resources.HT;
                CreateAdvisor(taskAdv,icon);
            }
            else DeleteAdvisor();
        }

        public override void UnCheckToolStripButtons()
        {
            foreach (ToolStripButton item in heatTreatmentTasksToolStrip.Items)
                item.Checked = false;
        }

        public override ToolStripMenuItem CreateTasksInterface()
        {
            var taskMenuItem = base.CreateTasksInterface();

            ToolStripMenuItem htMenuItem = new ToolStripMenuItem()
            {
                Name = "Термообработка",
                Text = "Термообработка",
                CheckOnClick = true
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            htMenuItem
            });

            htMenuItem.Click += (ar1, ar2) => {

                var taskAdv = new TaskAdvisor();


                taskAdv = new HeatTreatmentAdvisor() { Dock = DockStyle.Fill, Name = "Термообработка" };

                if (htMenuItem.Checked)
                {
                    var icon = TaskModule.Properties.Resources.HT;
                    CreateAdvisor(taskAdv, icon);
                }

                else DeleteAdvisor();
            };

            return taskMenuItem;
        }
    }
}
