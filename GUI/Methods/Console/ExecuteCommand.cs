using BazisGUI.Console;
using BazisGUI.Console.Enums;
using BazisGUI.Properties;
using BazisGUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        Dictionary<string, GenCmd> genCmds = new Dictionary<string, GenCmd>()
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
            { "Extrude along curve",GenCmd.ExtrudeCurve },
            { "Extrusion by rotation",GenCmd.ExtrudeRotate },
            { "Quit",GenCmd.Exit }
        };

        Dictionary<GenCmd, string[]> subCmds = new Dictionary<GenCmd, string[]>()
        {
            { GenCmd.LoadProject, new[] { "path" } },
            { GenCmd.SaveProject, new[] { "path" } },
            { GenCmd.SolveProject,new string[] { } },
            { GenCmd.RenumberMesh, new[] { "type:initial number" } },
            { GenCmd.MoveMesh, new[] { "move", "x,y,z" } },
            { GenCmd.MoveNodes, new[] { "move" } },
            { GenCmd.RotateMesh, new[] { "rotate", "x,y,z:angle" } },
            { GenCmd.FindFreeNodes,new string[] { } },
            { GenCmd.FindCoincident, new[] { "nodes", "distance" } },
            { GenCmd.FindVolElems, new[] { "measure" } },
            { GenCmd.FindObject, new[] { "type,number" } },
            { GenCmd.BeamConnection, new [] { "search radius", "max quantity", "group#1", "group#2" } },
            { GenCmd.SetLevel, new[] { "type", "precision level" } },
            { GenCmd.MergeElementSets, new[] { "type", "set#1", "set#2" } },
            { GenCmd.CreateMesh2DPoligon, new[] { "x1,y1", "x2,y2", "x3,y3", "x4,y4", "number of elements" } },
            { GenCmd.CreatePoint, new [] { "x,y,z" } },
            { GenCmd.CreatePointByVector, new string[]{ "copy_point#1", "direction_point#2", "offset" } },
            { GenCmd.CreatePointProjectionOntoCurve, new string[]{ "point", "curve" } },
            { GenCmd.CreatePointProjectionOntoPlane, new string[]{ "point", "surface" } },
            { GenCmd.CreateCurve, new [] { "point#1","point#2" } },
            { GenCmd.CreateSurface, new[] { "curves forming the contour", "curve#1,curve#2,curve#3..." } },
            { GenCmd.ExtrudeCurve, new[] { "Element 2D", "curve#1,curve#2,curve#3...", "point", "step", "transfinite mesh 1-yes, 0-no" } },
            { GenCmd.ExtrudeRotate, new[] { "Element 2D", "angle in degrees", "point", "XYZ rotation axi", "transfinite mesh 1-yes, 0-no" } },
            { GenCmd.Exit, Array.Empty<string>() },
            { GenCmd.GenerateMesh, Array.Empty<string>()}
        };

        private void PrintAllCommands()
        {
            console.PrintInfo($"{Resources.AvailableCommands}:", Color.Black);

            foreach (var item in genCmds)
            {
                var args = string.Join(" ", subCmds[item.Value].Select(s => $"\"{s}\""));
                console.PrintInfo($"- \"{item.Key}\" {args}", Color.Black);
            }
        }
        private async Task<int> ExecuteCommand(string line)
        {
            var cmds = FieldsParser.ParseLine(line);
            var number = -1;
            if (cmds.Count != 0)
            {
                if (!this.genCmds.ContainsKey(cmds[0]))
                    throw new Exception(Resources.NotACommandException);
                if (subCmds[genCmds[cmds[0]]].Length != cmds.Count - 1)
                    throw new Exception(Resources.InvalidArgumentsNumberException);

                ConsoleHistory.AddComand(line);
                switch (genCmds[cmds[0]])
                {
                    case GenCmd.CreateMesh2DPoligon:
                        CreateMesh2DPoligon(cmds[1], cmds[2], cmds[3], cmds[4], cmds[5]);
                        break;
                    case GenCmd.MergeElementSets:
                        MergeEventSets(cmds[1], cmds[2], cmds[3]);
                        break;
                    case GenCmd.FindObject:
                        FindObject(cmds[1]);
                        break;
                    case GenCmd.LoadProject:
                        await OpenProject(cmds[1]);
                        break;
                    case GenCmd.SaveProject:
                        project.Save(cmds[1]);
                        break;
                    case GenCmd.CreateGraph:
                        break;
                    case GenCmd.RenumberMesh:
                        console_RenumberMeshEvent(cmds[1]);
                        break;
                    case GenCmd.MoveMesh:
                        console_ModelShiftCoordinateEvent(cmds[2]);
                        break;
                    case GenCmd.RotateMesh:
                        console_ModelRotateEvent(cmds[2]);
                        break;
                    case GenCmd.MoveNodes:
                        if (cmds[1] == Resources.MoveRotNodesOption)
                            console_NodesShiftCoordinate();
                        break;
                    case GenCmd.FindFreeNodes:
                        console_FindFreeNodesEvent();
                        break;
                    case GenCmd.FindVolElems:
                        FindVolElems(cmds[1]);
                        break;
                    case GenCmd.FindCoincident:
                        if (cmds[1] == Resources.FindCoincidentOption)
                            await FindCoincidentNodes(float.Parse(cmds[2]));
                        break;
                    case GenCmd.BeamConnection:
                        BeamConnection(cmds[1], cmds[2], cmds[3], cmds[4]);
                        break;
                    case GenCmd.SolveProject:
                        //TODO: Реализовать метод
                        break;
                    case GenCmd.SetLevel:
                        SetLevel(cmds[1], cmds[2]);
                        break;
                    case GenCmd.Exit:
                        Application.Exit();
                        break;
                    case GenCmd.CreatePoint:
                        number = GeometryParserEventHandler(CreateCommandType.AddPoint, [cmds[1]]);
                        break;
                    case GenCmd.CreateCurve:
                        number = GeometryParserEventHandler(CreateCommandType.AddCurve, [cmds[1], cmds[2]]);
                        break;
                    case GenCmd.CreateSurface:
                        number = GeometryParserEventHandler(CreateCommandType.AddSurface, [cmds[2]]);
                        break;
                    case GenCmd.ExtrudeCurve:
                        ExtruderParserEventHandler(ExtruderType.Curve, new List<string> { cmds[1], cmds[2], cmds[3], cmds[4], cmds[5] });
                        number = 1;
                        break;
                    //case GenCmd.ExtrudeRotate:
                    //    ExtrudeEvent(new CreateExtruderEventArgs(ExtruderType.Rotate, new List<string> { cmds[1], cmds[2], cmds[3], cmds[4], cmds[5] }));
                    //    break;
                    case GenCmd.CreatePointByVector:
                        number = GeometryParserEventHandler(CreateCommandType.AddPointByVector, [cmds[1], cmds[2], cmds[3]]);
                        break;
                    case GenCmd.CreatePointProjectionOntoPlane:
                        number = GeometryParserEventHandler(CreateCommandType.AddPointProjectToSurface, [cmds[1], cmds[2]]);
                        break;
                    case GenCmd.CreatePointProjectionOntoCurve:
                        number = GeometryParserEventHandler(CreateCommandType.AddPointProjectToCurve, [cmds[1], cmds[2]]);
                        break;
                    case GenCmd.GenerateMesh:
                        создать3DСеткуToolStripMenuItem_Click(null, EventArgs.Empty);
                        btnSelect.Text = Resources.btnSelect_Text_Objects;
                        break;
                }
            }
            return number;
        }
    }
}
