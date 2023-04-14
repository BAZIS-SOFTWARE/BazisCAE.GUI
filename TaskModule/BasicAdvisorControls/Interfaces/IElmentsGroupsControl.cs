using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.BasicAdvisorControls.Interfaces
{
    public interface IElmentsGroupsControl
    {
        void Fill_eGroups(string taskType, string elemType, List<string> groupNames);
    }
}
