using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using GmshApi;
using LicenseInfo;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using static IronPython.Modules._ast;
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

        private void PrepareDataForSetRegularMeshSurface(string number, string cornerPoints, string ribersOrientation, string quadratization, out int _number, out Arrangement _arrangement, out List<int> _cornerPoints, out bool _quadratization)
        {
            var valid = int.TryParse(number, out _number) &
                ribersOrientation.TryToEnum<Arrangement>(out _arrangement);

            _cornerPoints = cornerPoints
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToList();

            _quadratization = quadratization == "quad";

            if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);
        }
        
        private void PrepareDataForGetRelatedGeometryObjects(string geoDim, string geoNumbers, string relatedDim, out int _geoDim, out List<int> _geoNumbers, out int _relatedDim)
        {
            if (!int.TryParse(geoDim, out _geoDim))
                throw new ArgumentException(Resources.InvalidCommandException);

            if (!int.TryParse(relatedDim, out _relatedDim))
                throw new ArgumentException(Resources.InvalidCommandException);

            _geoNumbers = new List<int>();

            foreach (var number in geoNumbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (!int.TryParse(number.Trim(), out var parsedNumber))
                    throw new ArgumentException(Resources.InvalidCommandException);

                _geoNumbers.Add(parsedNumber);
            }

            if (_geoNumbers.Count == 0)
                throw new ArgumentException(Resources.InvalidCommandException);
        }

        private Tuple<int[], int[]> GetAdjacentGeometryObjects(int geoDim, int geoNumber)
        {
            return project.SelectAdjacencies(geoDim, geoNumber);
        }

        private void PrepareDataForSetEmbeddedMeshSurface(string targetType, string targetNumber, string embeddedType, string embeddedNumbers, out int _targetType, out int _targetNumber, out int _embeddedType, out IEnumerable<int> _embeddedNumbers)
        {
            var valid = int.TryParse(targetType, out _targetType) &
                int.TryParse(targetNumber, out _targetNumber) &
                int.TryParse(embeddedType, out _embeddedType);

            _embeddedNumbers = embeddedNumbers
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToList();


            if (!valid || _embeddedNumbers == null)
                throw new ArgumentException(Resources.InvalidCommandException);
        }

        private void SetEmbeddedMesh(int hostDimension, int hostTag, int embeddedDimension, IEnumerable<int> embeddedEntities)
        {
            if (GmshController.Gmsh.Model.Mesh.GetEmbedded(hostDimension, hostTag).Length > 0)
                GmshController.Gmsh.Model.Mesh.RemoveEmbedded([hostDimension, hostTag]);

            var entities = embeddedEntities?.ToArray();

            if (entities?.Length > 0)
                GmshController.Gmsh.Model.Mesh.Embed(embeddedDimension,entities,hostDimension,hostTag);
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
