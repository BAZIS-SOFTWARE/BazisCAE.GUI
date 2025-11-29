using System;

namespace BazisGUI.Console.Events
{
    public class LoadProjectEventArgs : EventArgs
    {
        public string Path { get; }

        public LoadProjectEventArgs(string path)
        {
            Path = path;
        }
    }
}