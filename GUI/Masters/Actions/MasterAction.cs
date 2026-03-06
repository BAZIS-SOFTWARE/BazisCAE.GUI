using BazisGUI.Masters.Args;
using BazisGUI.Masters.Interfaces;
using System;

namespace BazisGUI.Masters.Actions
{
    public class MasterAction : IHandlerAction
    {
        public EventHandler<EventArgs> UpdateSceneAction { get; set; }
        public EventHandler<PrintInfoEventArgs> PrintInfoAction { get; set; }
        public EventHandler<GenerateConditionsEventArgs> GenerateConditionsAction { get; set;}
        public EventHandler<EventArgs> OnMasterLoaded { get; set; }
    }
}
