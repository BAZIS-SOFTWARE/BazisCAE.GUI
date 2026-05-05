using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum SurfacePropertyKeys { Number, MeshType, MeshKind, CornerPoints, RibersOrientation, Quadratization, AddedCurves, PointsNumbers }
        private List<RowProperty> GetSurfaceProperties(int number)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty(SurfacePropertyKeys.Number.ToString(),
                Resources.Header_surface_number,
                number,
                true));

            var attributes = GmshController.GetTransfiniteSurface(number);
            var meshTypes = new List<string>() { "*", "регулярная" };

            if (attributes.Length == 0)
                rows.Add(new RowProperty(SurfacePropertyKeys.MeshType.ToString(),
                    Resources.Header_surface_meshType,
                    new DropDownPropertyValue("*", meshTypes)));
            else
            {
                rows.Add(new RowProperty(SurfacePropertyKeys.MeshKind.ToString(),
                    Resources.Header_surface_meshKind,
                    new DropDownPropertyValue("регулярная", meshTypes)));

                rows.Add(new RowProperty(SurfacePropertyKeys.CornerPoints.ToString(),
                    Resources.Header_surface_cornerPoints,
                    attributes[0]));

                rows.Add(new RowProperty(SurfacePropertyKeys.RibersOrientation.ToString(),
                    Resources.Header_surface_ribersOrientation,
                    attributes[1]));

                rows.Add(new RowProperty(SurfacePropertyKeys.Quadratization.ToString(),
                    Resources.Header_surface_quadratization,
                    GmshController.GetRecombineSurface(number)));
            }

            var numbersCurves = GmshController.Gmsh.Model.Mesh.GetEmbedded(2, number).Where((v, i) => (i & 1) == 1).ToArray();
            var strCurvesNumber = string.Join(",", numbersCurves);

            rows.Add(new RowProperty(SurfacePropertyKeys.AddedCurves.ToString(),
                Resources.Header_surface_addedCurves,
                strCurvesNumber));

            rows.Add(new RowProperty(SurfacePropertyKeys.PointsNumbers.ToString(), 
                Resources.Header_surface_pointsNumbers,
                new ButtonPropertyValue(Resources.Показать, () =>
                {
                    var all = GmshController.Gmsh.Model.GetAdjacencies(2, number).Item2
                    .Select(x => GmshController.Gmsh.Model
                    .GetAdjacencies(1, x).Item2);

                    var distComb = all.SelectMany(x => x).Distinct().ToArray();
                    ShowObjectsNumbers(ObjType.Точка, distComb);
                    DisplayObjects();
                })));

            return rows;
        }
    }
}
