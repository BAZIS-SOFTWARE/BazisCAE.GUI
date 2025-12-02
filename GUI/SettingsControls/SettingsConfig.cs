using BazisGUI.Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI.SettingsControls
{
    [Serializable]
    public class SettingsConfig
    {
        //view settings
        public Color SelectObjectColor;
        public Color SelectGroupColor;
        public Color BackGroundColor;
        public Color NodeColor;
        public string SolverPath;
        public string SolverFile;
        public bool Lighting;
        public int LightingIntensity;
        public Point LighterPosition;
        public bool Transparency;
        public bool BackRibbers;
        public int TransparencyValue;
        public ViewProjection Projection = ViewProjection.Perspective;
        public bool DisplayBasis = true;
        public bool DisplayCompass = true;
        //public bool IsInsideObjectsShown = true;
        public bool IsCutting = false;
        public float RotationAngle = 2.5f;
        public ViewAxis RotationAxis = ViewAxis.XYZ;
        public float AngleOfProjection = 2.5f;

        //result settings
        public bool ShowResultsField;
        public bool ShowResultsScale;
        public bool ShowNodeResultsValue;
        public bool ShowElementsResultsValue;
        public bool MergeResultsValue;
        public bool IsScaleMaxMinManual;
        public int Scale_X_Coord;
        public int Scale_Y_Coord;
        public float Scale_MaxValue;
        public float Scale_MinValue;
        public int Scale_Precision;
        public int Scale_Intervals;
        public int Scale_scale;
        internal bool ShowNodesOnCurves;
    }
}