using System;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using BaseModule.ToolStrips;
using TaskModule.ToolStrips;

namespace TaskModule.WeldingModule
{
    public partial class WeldingPage : TaskPage
    {
        public WeldingPage()
        {
            InitializeComponent();
        }

        public override void UnCheckToolStripButtons()
        {
            foreach (ToolStripButton item in weldingTaskToolStrip.Items)
                item.Checked = false;
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
                {
                    var icon = TaskModule.Properties.Resources.Welding;
                    if (GetTaskAdvisor() == null)
                        CreateAdvisor(taskAdv, icon);
                }

                else DeleteAdvisor();
            };

            return taskMenuItem;
        }      

    }
}
