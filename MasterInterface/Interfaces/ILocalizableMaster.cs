using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterInterface.Interfaces
{
    public interface ILocalizableMaster : IMasterInterface
    {
        string GetCurrentUICultureMasterName();
    }
}
