using ProjectInterfaces.Tasks;
using System.Windows.Forms;
using TaskModule.WeldingModule;

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage()
        {
            InitializeComponent();
        }

        public HeatTreatmentAdvisor CreateHeatTreatmentAdvisor(ProcessType processType)
        {
            var taskAdv = new HeatTreatmentAdvisor()
            {
                Dock = DockStyle.Fill,
                Name = processType.ToString(),
                Text = processType.ToString()
            };

            taskAdv.ProcessType = ProcessType.Heating;

            return taskAdv;
        }       
    }
}
