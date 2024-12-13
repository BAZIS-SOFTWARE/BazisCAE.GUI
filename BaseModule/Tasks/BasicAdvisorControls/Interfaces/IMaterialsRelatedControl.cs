using BaseModule.Tasks.BasicAdvisorControls.Interfaces;
using System.Collections.Generic;

namespace TaskModule.BasicAdvisorControls.Interfaces
{
    public interface IMaterialsRelatedControl : IElmentsGroupsControl
    {
        void Add_Materials(List<string> materials);
    }
}
