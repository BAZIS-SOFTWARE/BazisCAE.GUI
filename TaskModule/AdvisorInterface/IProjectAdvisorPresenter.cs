using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorInterface
{
    public interface IProjectAdvisorPresenter
    {
        string TaskTypeInfo { get; }

        List<string> FindTaskDataInfo(string dataName);
        List<string> GetModelGroupInfo(string objType);
        Dictionary<string, List<string>> GetTaskDataInfo();
    }
}
