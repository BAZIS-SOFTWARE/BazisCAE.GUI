using BazisGUI.Masters.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IBaseMasterInterface : IMasterInterface
    {
        event EventHandler<PrintInfoEventArgs> PrintInfoEvent;
        event EventHandler<GenerateConditionsEventArgs> GenerateConditionsEvent;
        event EventHandler<UpdateSceneEventArgs> UpdateSceneEvent;

        string MasterName { get; }
    }
}
