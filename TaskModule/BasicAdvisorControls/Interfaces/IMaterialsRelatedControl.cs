using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.BasicAdvisorControls.Interfaces
{
    public interface IMaterialsRelatedControl : IElmentsGroupsControl
    {
        void Add_Materials(List<string> materials);
    }
}
