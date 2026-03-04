using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class FunctionsHandler<T> : IMasterInterfaceHandler<T> where T : IFunctionsHandling
    {
        public Action<string[]> SetFunctions;

        public FunctionsHandler(Action<string[]> setFunctions)
        {
            SetFunctions = setFunctions;
        }

        public void Handle(T instance)
        {
            SetFunctions -= instance.SetFunctions;
            SetFunctions += instance.SetFunctions;
        }
    }
}
