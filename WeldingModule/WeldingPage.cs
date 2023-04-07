using System;
using System.Windows.Forms;
using ToolStrips;
using AdvisorControls;
using TaskModule;

namespace WeldingModule
{
    public partial class WeldingPage : TaskPage
    {
        public WeldingPage()
        {
            InitializeComponent();
        }

        private void WeldingPage_Load(object sender, EventArgs e)
        {
            
            var weldingTaskToolStrip = new WeldingTasksToolStrip() { Name = "Сварка" };
            weldingTaskToolStrip.Renderer = new BtnToolStrRender();
            weldingTaskToolStrip.advisorStatusChanged += WeldingTaskToolStrip_advisorStatusChanged;

            AddToolStrip(weldingTaskToolStrip);
        }

        private void WeldingTaskToolStrip_advisorStatusChanged(object arg1, AdvisorEventArgs arg2)
        {
            if (!arg2.Status)
            {
                var taskAdv = new WeldingAdvisor() { Dock = DockStyle.Fill, Name = "Сварка" };

                CreateAdvisor(taskAdv);
            }
            else DeleteAdvisor();
        }

        public override ToolStripMenuItem CreateTasksInterface()
        {
            var taskMenuItem = base.CreateTasksInterface();

            ToolStripMenuItem weldingMenuItem = new ToolStripMenuItem()
            {
                Name = "Сварка",
                Text = "Сварка",
                CheckOnClick = true
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            weldingMenuItem
            });

            weldingMenuItem.Click += (ar1, ar2) => {

                var taskAdv = new TaskAdvisor();


                taskAdv = new WeldingAdvisor() { Dock = DockStyle.Fill, Name = "Сварка" };

                if (weldingMenuItem.Checked)
                    CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            return taskMenuItem;
        }      

    }
}
