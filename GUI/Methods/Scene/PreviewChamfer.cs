using Geometry;
using Model.Interfaces;
using BazisGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private const string ChamferPreviewName = "ChamferPreview";

        private void PreviewChamfer(double length, double secondValue, bool isByAngle, bool reflected)
        {
            try
            {
                var objs = project.GetModelObjects(ObjType.Кривая);
                var curveTags = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToArray();

                var segments = new List<Segment3D>(curveTags.Length * 4);

                foreach (var curveTag in curveTags)
                {
                    var (surfaceTags, _) = project.GetAdjacentGeometryObjects(1, curveTag);

                    if (surfaceTags.Length != 2)
                        throw new InvalidOperationException(
                            string.Format(Resources.ChamferPreview_CurveMustBelongToTwoSurfaces, surfaceTags.Length));

                    var (firstVolumes, _) = project.GetAdjacentGeometryObjects(2, surfaceTags[0]);
                    var (secondVolumes, _) = project.GetAdjacentGeometryObjects(2, surfaceTags[1]);
                    var commonVolumes = firstVolumes.Intersect(secondVolumes).Distinct().ToArray();
                    if (commonVolumes.Length != 1)
                        throw new InvalidOperationException(
                            string.Format(Resources.ChamferPreview_SurfacesMustBelongToOneVolume, commonVolumes.Length));

                    var volumeTag = commonVolumes[0];
                    var curveType = project.GetType(1, curveTag);
                    if (!curveType.Contains("Line", StringComparison.OrdinalIgnoreCase))
                        throw new NotSupportedException(
                            Resources.ChamferPreview_OnlyStraightCurvesSupported);

                    var (minimum, maximum) = project.GetParametrizationBounds(1, curveTag);
                    if (minimum.Length == 0 || maximum.Length == 0)
                        throw new InvalidOperationException(Resources.ChamferPreview_CurveParametrizationUnavailable);

                    var middleParameter = (minimum[0] + maximum[0]) / 2.0;
                    var edgeStart = ToPoint3D(project.GetGeoObjPoints(1, curveTag, new[] { minimum[0] }));
                    var edgeEnd = ToPoint3D(project.GetGeoObjPoints(1, curveTag, new[] { maximum[0] }));
                    var edgeMiddle = ToPoint3D(project.GetGeoObjPoints(1, curveTag, new[] { middleParameter }));
                    var tangent = Normalize(edgeEnd.Sub(edgeStart), string.Format(Resources.ChamferPreview_CurveHasZeroLength, curveTag));
                    var secondLength = isByAngle ? CalculateSecondLength(length, secondValue, edgeMiddle, surfaceTags, volumeTag) : secondValue;
                    var firstDirection = GetOffsetDirection(surfaceTags[0], volumeTag, edgeMiddle, tangent);
                    var secondDirection = GetOffsetDirection(surfaceTags[1], volumeTag, edgeMiddle, tangent);
                    var firstOffset = firstDirection.Mult((float)(reflected ? secondLength : length));
                    var secondOffset = secondDirection.Mult((float)(reflected ? length : secondLength));
                    var firstStart = edgeStart.Sum(firstOffset);
                    var firstEnd = edgeEnd.Sum(firstOffset);
                    var secondStart = edgeStart.Sum(secondOffset);
                    var secondEnd = edgeEnd.Sum(secondOffset);

                    segments.Add(new Segment3D(firstStart, firstEnd));
                    segments.Add(new Segment3D(secondStart, secondEnd));
                    segments.Add(new Segment3D(firstStart, secondStart));
                    segments.Add(new Segment3D(firstEnd, secondEnd));
                }

                DisplayChamferPreview(segments.ToArray());
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                RequestClearChamferPreview();
            }
        }

        private double[] GetOutwardNormal(int surfaceTag, int volumeTag, double[] point)
        {
            var parameters = project.GmshController.Gmsh.Model.GetParametrization(2, surfaceTag, point);
            var normal = project.GmshController.Gmsh.Model.GetNormal(surfaceTag, parameters);
            if (normal.Length != 3)
                throw new InvalidOperationException(string.Format(Resources.ChamferPreview_SurfaceNormalUnavailable, surfaceTag));

            var length = Math.Sqrt(normal.Sum(component => component * component));
            if (!double.IsFinite(length) || length == 0)
                throw new InvalidOperationException(string.Format(Resources.ChamferPreview_SurfaceHasInvalidNormal, surfaceTag));

            var orientation = GetSurfaceOrientation(volumeTag, surfaceTag);
            return normal.Select(component => orientation * component / length).ToArray();
        }

        private int GetSurfaceOrientation(int volumeTag, int surfaceTag)
        {
            var boundary = project.GetBoundary(new[] { 3, volumeTag }, oriented: true);
            for (var index = 1; index < boundary.Length; index += 2)
            {
                if (Math.Abs(boundary[index]) == surfaceTag)
                    return Math.Sign(boundary[index]);
            }

            throw new InvalidOperationException(string.Format(Resources.ChamferPreview_SurfaceNotOnVolumeBoundary, surfaceTag, volumeTag));
        }

        private Point3D GetOffsetDirection(int surfaceTag, int volumeTag, Point3D edgeMiddle, Point3D tangent)
        {
            var point = new[] { (double)edgeMiddle._x, edgeMiddle._y, edgeMiddle._z };
            var outwardNormal = ToPoint3D(GetOutwardNormal(surfaceTag, volumeTag, point));
            var direction = Normalize(
                Vector.CrossProd(outwardNormal, tangent),
                string.Format(Resources.ChamferPreview_OffsetDirectionUnavailable, surfaceTag));
            var (x, y, z) = project.GetCenterOfMass(2, surfaceTag);
            var toSurfaceCenter = new Point3D(
                (float)x - edgeMiddle._x,
                (float)y - edgeMiddle._y,
                (float)z - edgeMiddle._z);

            return Vector.DotProd(direction, toSurfaceCenter) < 0 ? direction.Mult(-1) : direction;
        }

        private double CalculateSecondLength(double firstLength, double angleInDegrees, Point3D edgeMiddle, int[] surfaceTags, int volumeTag)
        {
            if (!double.IsFinite(angleInDegrees) || angleInDegrees <= 0 || angleInDegrees >= 180)
                throw new ArgumentOutOfRangeException(
                    nameof(angleInDegrees),
                    Resources.ChamferPreview_AngleOutOfRange);

            var point = new[] { (double)edgeMiddle._x, edgeMiddle._y, edgeMiddle._z };
            var firstNormal = GetOutwardNormal(surfaceTags[0], volumeTag, point);
            var secondNormal = GetOutwardNormal(surfaceTags[1], volumeTag, point);
            var dotProduct = firstNormal[0] * secondNormal[0]
                + firstNormal[1] * secondNormal[1]
                + firstNormal[2] * secondNormal[2];
            var normalsAngle = Math.Acos(Math.Clamp(dotProduct, -1.0, 1.0));
            var surfaceAngle = Math.PI - normalsAngle;

            if (surfaceAngle <= 0 || surfaceAngle >= Math.PI)
                throw new InvalidOperationException(
                    Resources.ChamferPreview_InvalidSurfaceAngle);

            var chamferAngle = angleInDegrees * Math.PI / 180.0;
            if (surfaceAngle + chamferAngle >= Math.PI)
                throw new ArgumentOutOfRangeException(
                    nameof(angleInDegrees),
                    string.Format(Resources.ChamferPreview_AngleMustBeLessThan,
                        surfaceAngle * 180.0 / Math.PI,
                        180.0 - surfaceAngle * 180.0 / Math.PI));

            var calculatedLength = firstLength
                * Math.Sin(chamferAngle)
                / Math.Sin(surfaceAngle + chamferAngle);

            if (!double.IsFinite(calculatedLength) || calculatedLength <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(angleInDegrees),
                    Resources.ChamferPreview_CalculatedLengthMustBePositive);

            return calculatedLength;
        }

        private Point3D ToPoint3D(double[] coordinates)
        {
            if (coordinates == null || coordinates.Length != 3)
                throw new InvalidOperationException(Resources.ChamferPreview_InvalidGeometryCoordinates);

            return new Point3D((float)coordinates[0], (float)coordinates[1], (float)coordinates[2]);
        }

        private Point3D Normalize(Point3D vector, string errorMessage)
        {
            var vectorLength = Vector.GetVectorLength(vector);
            if (!float.IsFinite(vectorLength) || vectorLength == 0)
                throw new InvalidOperationException(errorMessage);

            return vector.Mult(1.0f / vectorLength);
        }

        private void DisplayChamferPreview(Segment3D[] segments)
        {
            // Создание/удаление VBO должно выполняться в потоке WinForms/GL.
            if (InvokeRequired)
            {
                BeginInvoke(new Action(
                    () => DisplayChamferPreview(segments)));

                return;
            }

            ClearChamferPreview(redraw: false);

            if (segments == null || segments.Length == 0)
            {
                DisplayObjects();
                return;
            }

            // GL.Lines воспринимает каждую пару вершин как отдельный отрезок.
            float[] coordinates = segments
                .SelectMany(segment => new[]
                {
                    segment.P0._x,
                    segment.P0._y,
                    segment.P0._z,

                    segment.P1._x,
                    segment.P1._y,
                    segment.P1._z
                })
                .ToArray();

            int vertexCount = coordinates.Length / 3;

            int[] indices = Enumerable
                .Range(0, vertexCount)
                .ToArray();

            // Чёрный цвет RGBA для каждой вершины.
            float[] colors = Enumerable
                .Range(0, vertexCount)
                .SelectMany(_ => new[] {0.0f,0.0f,0.0f, 1.0f})
                .ToArray();

            // LineObjects нормали не использует, но конструктор их ожидает.
            float[] normals = new float[vertexCount * 3];

            var previewVbo = VBOController.CreateLineVBObjects(indices, coordinates, colors, normals, Array.Empty<bool>(), ChamferPreviewName);

            previewVbo.Gl_LineWidth = 3.0f;

            // Необходимо для существующего режима усреднённого рендера.
            previewVbo.ActiveDrawingObject = averageColorRenderer.IsEnable ? averageColorRenderer : null;

            VBOController.AddVbo(previewVbo);
            DisplayObjects();
        }
    }
}
