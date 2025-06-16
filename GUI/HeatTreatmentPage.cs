using BaseModule.Tasks.HeatTreatmentModule;
using PreProc.Interfaces;
using TaskModule.BasicTaskAdvisor;

namespace BazisGUI
{
    public partial class HeatTreatmentPage: TaskPage
    {
        public HeatTreatmentPage() : base()
        {
            InitializeComponent();

            //var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];
            //pContr.BringToFront();
            //var taskAdv = pContr.HTAdvisor;
            ////BasePage.panelProvider.OnUpdateNavigator += () => PresentTaskDataOnTree(taskData);
            //SetAdvisor(taskAdv);
        }

        //public override TaskAdvisor GetTaskAdvisor()
        //{
            //var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];
            //return pContr.HTAdvisor;
        //}

        //public void ConfigAdvisor(ProcessType processType)
        //{
        //    var pContr = (PinnedHTAdvControl)EmbeddedControls.Find("pinnedHTAdvControl", false)[0];

        //    pContr.HeaderName = $"Постановка задачи {processType}";

        //    ProcessType = processType;

        //    FillAdvisor(pContr.HTAdvisor);
        //}       
    }
}
