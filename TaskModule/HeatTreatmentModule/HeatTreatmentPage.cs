using ProjectInterfaces.Tasks;
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
                    Name = "Нагрев",
                    Text = owenHeatingMenuItem.Text
                };

                taskAdv.ProcessType = ProcessType.Heating;

                DeleteAdvisor();
                if (owenHeatingMenuItem.Checked)
                        CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            quenchingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new HeatTreatmentAdvisor() { 
                    Dock = DockStyle.Fill, 
                    Name = "Закалка",
                    Text = quenchingMenuItem.Text
                };

                taskAdv.ProcessType = ProcessType.Quenching;

                DeleteAdvisor();
                if (quenchingMenuItem.Checked)
                    CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            temperingMenuItem.Click += (ar1, ar2) => {
                var taskAdv = new HeatTreatmentAdvisor() { 
                    Dock = DockStyle.Fill, 
                    Name = "Выдержка",
                    Text = temperingMenuItem.Text
                };

                taskAdv.ProcessType = ProcessType.Tempering;

                DeleteAdvisor();
                if (temperingMenuItem.Checked)
                    CreateAdvisor(taskAdv);
                else DeleteAdvisor();
            };

            return taskMenuItem;
        }
    }
}
