using System;

namespace BazisGUI.Console.Events
{
    public class SaveProjectEventArgs : EventArgs
    {
        public string Path { get; }

        public SaveProjectEventArgs(string path)
        {
            Path = path;
        }
    }
}