using BaseModule.PinnedControl;
using BaseModule.Tasks.WeldingModule;

namespace BaseModule.Tasks.WeldingModule
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
