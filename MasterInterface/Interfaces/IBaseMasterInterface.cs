using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IBaseMasterInterface : IMasterInterface
    {
        event Action<string, Color> PrintInfoEvent;
        event Action<string[]> GenerateConditionsEvent;
        event Action UpdateSceneEvent;

        string MasterName { get; }
    }
}
