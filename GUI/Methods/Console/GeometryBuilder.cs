using BazisGUI.Console.Enums;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ExtruderParserEventHandler(ExtruderType type, List<string> parameters)
        {
            if (type == ExtruderType.Curve)
            {
                // "TODO: Потенциальное место проблем с локалью"
                string input = parameters[3].Replace(',', '.');
                var valid =
                    int.TryParse(parameters[0], out var numberSurface) &
                    int.TryParse(parameters[2], out var numberStartPoint) &
                    double.TryParse(input, out var step);
                bool transfinite = parameters[4] == "1";
                var curveNumbers = parameters[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x.Trim()))
                    .ToList();
                if (!valid)
                    throw new ArgumentException("Введены неверные данные");

                ExtrudeCurve(numberSurface, curveNumbers.ToArray(), numberStartPoint, step, transfinite);
            }
            else
            {
                var valid =
                    int.TryParse(parameters[0], out var numberSurface) &
                    float.TryParse(parameters[1], out var angle) &
                    int.TryParse(parameters[2], out var numberStartPoint);
                bool transfinite = parameters[4] == "1";

                var rotAxis = parameters[3].Trim().ToUpper() switch
                {
                    "X" => Vector3.UnitX,
                    "Y" => Vector3.UnitY,
                    "Z" => Vector3.UnitZ,
                    _ => throw new ArgumentException("Ось поворота указана не верно")
                };

                if (!valid)
                    throw new ArgumentException("Введены неверные данные");

                ExtrudeRotate(numberSurface, angle, numberStartPoint, rotAxis, transfinite);
            }
            PresentExtrude();
        }

        private int GeometryParserEventHandler(CreateCommandType type, List<string> parameters)
        {
            var tag = -1;
            if (GmshController == null)
            {
                return tag;
            }

            switch (type)
            {
                // "TODO: подобрать другой разделитель, чтобы не было конфликта культур"
                case CreateCommandType.AddPoint:
                    var prm = parameters;
                    var coord = prm[0].Split(',');

                    if (double.TryParse(coord[0], out double x) &&
                       double.TryParse(coord[1], out double y) &&
                       double.TryParse(coord[2], out double z))
                        tag = AddPoint(x, y, z);
                    break;
                case CreateCommandType.AddCurve:
                    var points = parameters;
                    if (int.TryParse(points[0], out int startTag) &&
                       int.TryParse(points[1], out int endTag))
                        tag =AddLine(startTag, endTag);
                    break;
                case CreateCommandType.AddSurface:
                    var lineNumbers = parameters[0]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x.Trim()))
                        .ToList();
                    tag = AddPlane(lineNumbers);
                    break;
                case CreateCommandType.AddPointByVector:
                    var prmByVector = parameters;
                    if (int.TryParse(prmByVector[0], out int basePointTag) &&
                        int.TryParse(prmByVector[1], out int directionPointTag) &&
                        double.TryParse(prmByVector[2], out double offset))
                        tag = AddPointByVector(basePointTag, directionPointTag, offset);
                    break;
                case CreateCommandType.AddPointProjectToSurface:
                    var prmProjectToSurface = parameters;
                    if (int.TryParse(prmProjectToSurface[0], out int pointTag) &&
                        int.TryParse(prmProjectToSurface[1], out int surfaceTag))
                        tag = AddPointProjectionOntoPlane(pointTag, 2, surfaceTag);
                    break;
                case CreateCommandType.AddPointProjectToCurve:
                    var prmProjectToCurve = parameters;
                    if (int.TryParse(prmProjectToCurve[0], out int pointTag1) &&
                        int.TryParse(prmProjectToCurve[1], out int curveTag))
                        tag = AddPointProjectionOntoCurve(pointTag1, 1, curveTag);
                    break;
                default:
                    throw new NotSupportedException();
            }
            PresentGeoData();
            DisplayObjects();
            return tag;
        }

        private void ExtrudeCurve(int numberSurface, int[] numbersCurve, int numberStartPoint, double step, bool transfinite)
            => project.ExtrudeElement3DAlongCurve(numberSurface, numbersCurve, numberStartPoint, step, transfinite);
        
        private void ExtrudeRotate(int numberSurface, float angle, int originPoint, Vector3 rotAxis, bool transfinite)
        {
            var point = project.GetModelPoint(originPoint);
            Vector3 origin = new Vector3(point._x, point._y, point._z);
            project.ExtrudeElement3DRotate(numberSurface, angle, origin, rotAxis, transfinite);
        }
        private int AddPoint(double x, double y, double z, double meshSize = 0)
        {
            var pointTag = project.CreatePoint(x, y, z);
            RefreshGeometry(ObjType.Точка);
            return pointTag;
        }

        private int AddLine(int startTag, int endTag, int tag = -1)
        {
            var lineTag = project.CreateLine(startTag, endTag);
            RefreshGeometry(ObjType.Кривая);
            return lineTag;
        }

        private int AddPlane(List<int> linesNumber)
        {
            var planeTag = project.CreateSurface(linesNumber.ToArray());
            RefreshGeometry(ObjType.Поверхность);
            return planeTag;
        }

        private int AddPointByVector(int startTag, int endTag, double step)
        {
            var pointTag = project.CreatePointByVector(startTag, endTag, step);
            RefreshGeometry(ObjType.Точка);
            return pointTag;    
        }

        private int AddPointProjectionOntoPlane(int pointNumber, int dim, int surfaceTag)
        {
            var pointTag = project.CreatePointProjectionOntoGeometry(pointNumber, dim, surfaceTag);
            RefreshGeometry(ObjType.Точка);
            return pointTag;
        }

        private int AddPointProjectionOntoCurve(int pointNumber, int dim, int curveTag)
        {
            var pointTag = project.CreatePointProjectionOntoGeometry(pointNumber, dim, curveTag);
            RefreshGeometry(ObjType.Точка);
            return pointTag;
        }
        private void RefreshGeometry(ObjType objType)
        {
            VBOController.DeleteVBObjects(objType.ToString());

            var presenter = project.CreateModelObjectsPresentor(objType);
            var vbObject = CreateVBObject(presenter);

            VBOController.AddVbo(vbObject);
        }

        private void PresentExtrude()
        {
           // RefreshGeometry(ObjType.Точка); RefreshGeometry(ObjType.Элемент3D);

            //var set = project.GetModelSetsInfo(ObjType.Элемент3D).Where(x => x.Name.Contains("extrude")).Last();
            //var pre = project.CreateModelObjectsPresentor(set);
            //var vbo = CreateVBObject(pre);
            //VBOController.AddVbo(vbo);


            VBOController.DeleteAllVBObjects();
            CreateVBObjects("Объекты");

            PresentMeshData();
            DisplayObjects();
        }
    }
}
