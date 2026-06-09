using BazisGUI.Masters.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface IBaseMaster : IMasterInterface
    {
        event EventHandler<PrintInfoEventArgs> PrintInfoEvent;
        event EventHandler<GenerateConditionsEventArgs> GenerateConditionsEvent;
        event EventHandler<UpdateSceneEventArgs> UpdateSceneEvent;
        event EventHandler<EventArgs> OnMasterLoaded;

        // Тут возможно команда SendCmd("cmdStr")
        // cmdStr - "название команды" "агр1" "арг2" и т.д.

        // Тут возможно команда ReceiveCmd("cmdStr")
        // cmdStr - "статус выпонения -1 или 1" "название команды" "результат"

        string MasterName { get; }
    }
}
