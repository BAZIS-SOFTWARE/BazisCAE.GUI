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

            var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];
            pContr.BringToFront();
            var taskAdv = pContr.HTAdvisor;

            SetAdvisor(taskAdv);
        }

        public override TaskAdvisor GetTaskAdvisor()
        {
            var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedWAdvControl", false)[0];
            return pContr.HTAdvisor;
        }

        public void ConfigAdvisor(ProcessType processType)
        {
            var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];

            pContr.HeaderName = $"Постановка задачи {processType}";

            FillAdvisor(pContr.HTAdvisor);
        }       
    }
}
