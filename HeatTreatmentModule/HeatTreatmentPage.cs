using System;
using System.Windows.Forms;
using TaskModule;
using ToolStrips;
using AdvisorControls;
using TaskModule.BasicTaskAdvisor;

namespace HeatTreatmentModule
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage()
        {
            InitializeComponent();
        }

        private void HtPage_Load(object sender, EventArgs e)
        {

            var htTaskToolStrip = new HeatTreatmentTasksToolStrip() { Name = "ТО" };
            htTaskToolStrip.Renderer = new BtnToolStrRender();
            htTaskToolStrip.advisorStatusChanged += HtTaskToolStrip_advisorStatusChanged;

            AddToolStrip(htTaskToolStrip);
        }

        private void HtTaskToolStrip_advisorStatusChanged(object arg1, AdvisorEventArgs arg2)
        {
            if (!arg2.Status)
            {
                var taskAdv = new HeatTreatmentAdvisor() { Dock = DockStyle.Fill, Name = "ТО" };
                var icon = HeatTreatmentModule.Properties.Resources.HT;
                CreateAdvisor(taskAdv,icon);
            }
            else DeleteAdvisor();
        }

        public override void UnBlockInterface()
        {
            base.UnBlockInterface();

            var toolStr = FindToolStrip<HeatTreatmentTasksToolStrip>();
            toolStr.Enabled = true;

            foreach (ToolStripButton item in toolStr.Items)
                item.Enabled = true;
        }

        public override ToolStripMenuItem CreateTasksInterface()
        {
            var taskMenuItem = base.CreateTasksInterface();

            ToolStripMenuItem htMenuItem = new ToolStripMenuItem()
            {
                Name = "ТО",
                Text = "ТО",
                CheckOnClick = true
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            htMenuItem
            });

            htMenuItem.Click += (ar1, ar2) => {

                var taskAdv = new TaskAdvisor();


                taskAdv = new HeatTreatmentAdvisor() { Dock = DockStyle.Fill, Name = "ТО" };

                if (htMenuItem.Checked)
                {
                    var icon = HeatTreatmentModule.Properties.Resources.HT;
                    CreateAdvisor(taskAdv, icon);
                }

                else DeleteAdvisor();
            };

            return taskMenuItem;
        }
    }
}
