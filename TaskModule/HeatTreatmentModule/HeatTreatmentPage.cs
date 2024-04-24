using System.Windows.Forms;

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage()
        {
            InitializeComponent();
        }

        public override ToolStripMenuItem CreateTasksInterface()
        {
            var taskMenuItem = base.CreateTasksInterface();

            ToolStripMenuItem owenHeatingMenuItem = new ToolStripMenuItem()
            {
                Name = "owenHeating",
                Text = "Нагрев",
                CheckOnClick = true
            };

            ToolStripMenuItem quenchingMenuItem = new ToolStripMenuItem()
            {
                Name = "quenching",
                Text = "Закалка",
                CheckOnClick = true
            };

            ToolStripMenuItem temperingMenuItem = new ToolStripMenuItem()
            {
                Name = "tempering",
                Text = "Отпуск/Отжиг/Старение",
                CheckOnClick = true
            };

            ToolStripMenuItem diffusionMenuItem = new ToolStripMenuItem()
            {
                Name = "diffusion",
                Text = "ХТО",
                CheckOnClick = true,
                Enabled = false
            };


            taskMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            owenHeatingMenuItem,quenchingMenuItem,temperingMenuItem,diffusionMenuItem
            });

            owenHeatingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new HeatTreatmentAdvisor() { 
                    Dock = DockStyle.Fill, 
                    Name = "Термообработка",
                    Text = owenHeatingMenuItem.Text
                };
                
                taskAdv.HTKind = HTKind.Нагрев;

                DeleteAdvisor();
                if (owenHeatingMenuItem.Checked)
                        CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            quenchingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new HeatTreatmentAdvisor() { 
                    Dock = DockStyle.Fill, 
                    Name = "Термообработка",
                    Text = quenchingMenuItem.Text
                };

                taskAdv.HTKind = HTKind.Охлаждение;

                DeleteAdvisor();
                if (quenchingMenuItem.Checked)
                    CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            temperingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new HeatTreatmentAdvisor() { 
                    Dock = DockStyle.Fill, 
                    Name = "Термообработка",
                    Text = temperingMenuItem.Text
                };

                taskAdv.HTKind = HTKind.Выдержка;

                DeleteAdvisor();
                if (temperingMenuItem.Checked)
                    CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            return taskMenuItem;
        }
    }
}
