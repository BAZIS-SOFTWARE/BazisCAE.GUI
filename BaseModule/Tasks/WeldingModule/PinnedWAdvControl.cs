using BaseModule.PinnedControl;
using BaseModule.Tasks.WeldingModule;

namespace TaskModule.BasicTaskAdvisor
{
    public partial class PinnedWAdvControl : PinnedPage
    {
        public WeldingAdvisor WeldingAdvisor { get { return weldingAdvisor; } }

        public PinnedWAdvControl()
        {
            InitializeComponent();
        } 
    }
}
