using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    [Serializable]
    public class SettingsConfig
    {
        public Color SelectObjectColor;
        public Color SelectGroupColor;
        public Color BackGroudColor;
        public string SolverPath;
        public bool Lighting;
        public bool Transparency;

    }
}