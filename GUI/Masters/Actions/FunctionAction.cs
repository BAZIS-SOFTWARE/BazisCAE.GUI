using BazisGUI.Args;
using BazisGUI.Masters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Actions
{
    public class FunctionAction : IHandlerAction
    {
        public Action<ChangeFunctionsEventArgs> FunctionsAct { get; set; }
    }
}
