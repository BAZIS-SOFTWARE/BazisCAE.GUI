using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI.SettingsControls
{
    [Serializable]
    public class SettingsConfig
    {
        public Color SelectObjectColor;
        public Color SelectGroupColor;
        public Color BackGroudColor;
        public string SolverPath;
        public bool Lighting;
        public int LightingIntensity;
        public Point LighterPosition;
        public bool Transparency;
        public bool BackRibbers;
        public int TransparencyValue;
    }
}