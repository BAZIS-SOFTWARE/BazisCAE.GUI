using BaseModule.Tasks;
using BaseModule.Tasks.HeatTreatmentModule;
using BaseModule.Tasks.WeldingModule;
using ProjectInterfaces.Tasks;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using TaskModule.WeldingModule;

namespace TaskModule.HeatTreatmentModule
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage()
        {
            InitializeComponent();

            EmbeddedControls.Find("pinnedHTAdvControl", false)[0].BringToFront();
        }

        public void ConfigAdvisor(ProcessType processType)
        {
            var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];

            var taskAdv = pContr.HTAdvisor;

            pContr.HeaderName = $"Постановка задачи {processType}";
            
            SetAdvisor(taskAdv);
        }       
    }
}
