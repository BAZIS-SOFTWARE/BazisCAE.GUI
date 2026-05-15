using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using GmshApi;
using LicenseInfo;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using static IronPython.Runtime.Profiler;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeSurfaceProperty(PropertyChangedEventArgs obj, int number, ref bool flag)
        {
            if (Enum.TryParse(obj.Key, out SurfacePropertyKeys key))
            {
                if (key == SurfacePropertyKeys.MeshType)
                    HandleMeshTypeParameter(obj.NewValue, number, ref flag);

                else if (key == SurfacePropertyKeys.AddedCurves)
                    HandleAddedCurvesParameter(obj.NewValue, number);

                else
                {
                    var attributes = GmshController.GetTransfiniteSurface(number);

                    if (key == SurfacePropertyKeys.Quadratization)
                        HandleQuadratizationParameter(obj.NewValue, number);

                    else if (key == SurfacePropertyKeys.CornerPoints)
                        attributes[0] = obj.NewValue;

                    else if (key == SurfacePropertyKeys.RibersOrientation)
                        attributes[1] = obj.NewValue;

                    var arrangement = attributes[1].ToEnum<Arrangement>();
                    var points = attributes[0].Split(',').Select(int.Parse);

                    project.GmshController.SetTransfiniteSurface(number, arrangement, points.ToArray());
                }
            }
        }

        private void PrepareDataForSetRegularMeshSurface(string number, string cornerPoints, string ribersOrientation, string quadratization)
        {
            var valid = int.TryParse(number, out var _number) &
                ribersOrientation.TryToEnum<Arrangement>(out var _arrangement);

            var _cornerPoints = cornerPoints
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToList();

            var _quadratization = quadratization == "quad";

            if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);

            SetRegularMeshSurface(_number, _cornerPoints, _arrangement, _quadratization);
        }

        private void PrepareDataForSetEmbeddedMeshSurface(string number, string embeddedCurves)
        {
            var valid = int.TryParse(number, out var _number);
            var _embeddedCurves = embeddedCurves
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToList();


            if (!valid || _embeddedCurves == null)
                throw new ArgumentException(Resources.InvalidCommandException);

            SetEmbeddedMeshSurface(_number, _embeddedCurves);
        }

        private void SetEmbeddedMeshSurface(int number, List<int> embeddedCurves)
        {
            if (GmshController.Gmsh.Model.Mesh.GetEmbedded(2, number).Length > 0)
                GmshController.Gmsh.Model.Mesh.RemoveEmbedded([2, number]);
            GmshController.Gmsh.Model.Mesh.Embed(1, embeddedCurves.ToArray(), 2, number);
        }

        private void SetRegularMeshSurface(int number, List<int> cornerPoints, Arrangement arrangement, bool quadratization) 
        {
            project.GmshController.SetTransfiniteSurface(number, arrangement, cornerPoints.ToArray());

            if(quadratization)
                project.GmshController.SetRecombineSurface(number);
        }

        private void HandleMeshTypeParameter(string newValue, int number, ref bool flag)
        {
            flag = true;
            if (newValue == "регулярная")
            {
                var surfPoints = project.GmshController.GetSurfaceNodes(number);
                project.GmshController.SetTransfiniteSurface(number, Arrangement.Left, surfPoints);
            }
            else
            {
                // тут спросить у Николая достаточно ли одной команды для снятия транфиниции объема?
                GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                //удаляем запись из словаря атрибутов
                GmshController.Gmsh.Model.RemoveAttribute($"transfinite surface {number}");
            }
        }

        private void HandleAddedCurvesParameter(string newValue, int number)
        {
            if (GmshController.Gmsh.Model.Mesh.GetEmbedded(2, number).Length > 0)
                GmshController.Gmsh.Model.Mesh.RemoveEmbedded([2, number]);

            var arrayStr = newValue.Split(',');
            var tags = arrayStr.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToArray();
            if (tags != null)
                GmshController.Gmsh.Model.Mesh.Embed(1, tags, 2, number);
        }

        private void HandleQuadratizationParameter(string newValue, int number)
        {
            if (bool.Parse(newValue))
                project.GmshController.SetRecombineSurface(number);
            else
            {
                GmshController.Gmsh.Model.Mesh.RemoveConstraints(new int[] { 2, number });
                GmshController.Gmsh.Model.RemoveAttribute($"recombine surface {number}");
            }
        }
    }
}
