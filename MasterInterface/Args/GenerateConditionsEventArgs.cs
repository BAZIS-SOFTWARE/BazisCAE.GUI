using System;
using System.Windows.Forms.VisualStyles;

namespace BazisGUI.Masters.Args
{
    public class GenerateConditionsEventArgs : EventArgs
    {
        public string[] InputStrings {get; }

        public GenerateConditionsEventArgs(string[] strings)
        {
            InputStrings = strings;
        }
    }
}
