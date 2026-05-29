using BazisGUI.Console.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BazisGUI.Scripting
{
    public static class CommandList
    {
        public static readonly Dictionary<string, GenCmd> Commands = new Dictionary<string, GenCmd>()
        {
            { "Load project",GenCmd.LoadProject},
            { "Save project",GenCmd.SaveProject},
            { "Solve project",GenCmd.SolveProject},
            { "Renumber mesh",GenCmd.RenumberMesh},
            { "Move node",GenCmd.MoveNodes},
            { "Move mesh",GenCmd.MoveMesh},
            { "Rotate mesh",GenCmd.RotateMesh},
            { "Generate mesh",GenCmd.GenerateMesh},
            { "Find free nodes",GenCmd.FindFreeNodes},
            { "Find Coincident",GenCmd.FindCoincident},
            { "Find 3D elements",GenCmd.FindVolElems},
            { "Find object",GenCmd.FindObject},
            { "Connect with beams",GenCmd.BeamConnection},
            { "Set precision level",GenCmd.SetLevel },
            { "Merge elements sets",GenCmd.MergeElementSets },
            { "Build 2D mesh",GenCmd.CreateMesh2DPoligon },
            { "Create point",GenCmd.CreatePoint },
            { "Create point by vector", GenCmd.CreatePointByVector },
            { "Create point by projection onto curve", GenCmd.CreatePointProjectionOntoCurve },
            { "Create point by projection onto plane", GenCmd.CreatePointProjectionOntoPlane },
            { "Create curve",GenCmd.CreateCurve },
            { "Create surface",GenCmd.CreateSurface },
            { "Set mesh point", GenCmd.SetMeshPoint },
            { "Set mesh curve", GenCmd.SetMeshCurve },
            { "Set regular mesh surface", GenCmd.SetRegularSurface },
            { "Set embedded mesh surface", GenCmd.SetEmbeddedSurface },
            { "Set min size", GenCmd.SetMinSize },
            { "Set max size", GenCmd.SetMaxSize },
            { "Algo2D", GenCmd.Algo2D },
            { "Algo3D", GenCmd.Algo3D },
            { "Scale factor", GenCmd.ScaleFactor },
            { "Extrude along curve",GenCmd.ExtrudeCurve },
            { "Extrusion by rotation",GenCmd.ExtrudeRotate },
            { "Save STEP", GenCmd.SaveSTEP },
            { "Quit",GenCmd.Exit }
        };

        public static bool Exists(string name)
        {
            return Commands.ContainsKey(name);
        }
    }
}
