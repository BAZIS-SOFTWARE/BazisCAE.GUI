using BazisGUI.Properties;
using BazisGUI.Scripting;
using System;
using System.Collections.Generic;
using System.IO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void HandleScriptLoadRequested(string path)
        {
            var commands = new List<string>();
            if (System.IO.File.Exists(path))
            {
                var cmdLines = File.ReadAllLines(path);
                foreach (var line in cmdLines)
                    commands.Add(line);
            }
            else throw new Exception($"\n > {Resources.ExecuteCMDFileMissing}");
            
            var scriptExecuter = new CommandPreprocessor();
            scriptExecuter.CommandEnteredEvent += ExecuteCommand;

            scriptExecuter.ReadCommands(commands);
        }
    }
}
