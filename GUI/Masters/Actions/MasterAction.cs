using BazisGUI.Masters.Args;
using BazisGUI.Masters.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Actions
{
    public class MasterAction : IHandlerAction
    {
        public Action UpdateSceneAction { get; set; }
        public Action<string, Color> PrintInfoAction { get; set; }
        public Action<GenerateConditionsEventArgs> GenerateConditionsAction { get; set;}
    }
}
