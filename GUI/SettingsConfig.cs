using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    [Serializable]
    public class SettingsConfig
    {
        public Color SelectionColor;
        public Color BackGroudColor;
        public string SolverPath;
        public bool Lighting;
        public bool Transparency;
    }
}