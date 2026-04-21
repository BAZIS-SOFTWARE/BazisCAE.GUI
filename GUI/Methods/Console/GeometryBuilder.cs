using BazisGUI.Console.Events;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ExtruderParserEventHandler(CreateExtruderEventArgs createExtruderEvent)
        {
            if (createExtruderEvent.Type == ExtruderType.Curve)
            {
                // "TODO: Потенциальное место проблем с локалью"
                string input = createExtruderEvent.Parameters[3].Replace(',', '.');
                var valid =
                    int.TryParse(createExtruderEvent.Parameters[0], out var numberSurface) &
                    int.TryParse(createExtruderEvent.Parameters[1], out var numberCurve) &
                    int.TryParse(createExtruderEvent.Parameters[2], out var numberStartPoint) &
                    double.TryParse(input, out var step);
                bool transfinite = createExtruderEvent.Parameters[4] == "1";

                if (!valid)
                    throw new ArgumentException("Введены неверные данные");

                ExtrudeCurve(numberSurface, numberCurve, numberStartPoint, step, transfinite);
            }
            else
            {
                var valid =
                    int.TryParse(createExtruderEvent.Parameters[0], out var numberSurface) &
                    float.TryParse(createExtruderEvent.Parameters[1], out var angle) &
                    int.TryParse(createExtruderEvent.Parameters[2], out var numberStartPoint);
                bool transfinite = createExtruderEvent.Parameters[4] == "1";

                var rotAxis = createExtruderEvent.Parameters[3].Trim().ToUpper() switch
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

        private void GeometryParserEventHandler(CreateGeometryEventArgs geomCreator)
        {
            if (GmshController == null)
            {
                return;
            }
            var type = geomCreator.Type;
            switch (type)
            {
                // "TODO: подобрать другой разделитель, чтобы не было конфликта культур"
                case GeometryType.Point:
                    var prm = geomCreator.Parameters;
                    var coord = prm[0].Split(',');

                    if (double.TryParse(coord[0], out double x) &&
                       double.TryParse(coord[1], out double y) &&
                       double.TryParse(coord[2], out double z))
                        AddPoint(x, y, z);
                    break;
                case GeometryType.Curve:
                    var points = geomCreator.Parameters;
                    if (int.TryParse(points[0], out int startTag) &&
                       int.TryParse(points[1], out int endTag))
                        AddLine(startTag, endTag);
                    break;
                case GeometryType.Surface:
                    var lineNumbers = geomCreator.Parameters[0]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x.Trim()))
                        .ToList();
                    AddPlane(lineNumbers);
                    break;
                default:
                    throw new NotSupportedException();
            }
            PresentGeoData();
            DisplayObjects();
        }

        private void ExtrudeCurve(int numberSurface, int numberCurve, int numberStartPoint, double step, bool transfinite)
            => project.ExtrudeElement3DAlongCurve(numberSurface, numberCurve, numberStartPoint, step, transfinite);
        
        private void ExtrudeRotate(int numberSurface, float angle, int originPoint, Vector3 rotAxis, bool transfinite)
        {
            var point = project.GetModelPoint(originPoint);
            Vector3 origin = new Vector3(point._x, point._y, point._z);
            project.ExtrudeElement3DRotate(numberSurface, angle, origin, rotAxis, transfinite);
        }
        private void AddPoint(double x, double y, double z, double meshSize = 0)
        {
            project.CreatePoint(x, y, z);
            RefreshGeometry(ObjType.Точка);
        }

        private void AddLine(int startTag, int endTag, int tag = -1)
        {
            project.CreateLine(startTag, endTag);
            RefreshGeometry(ObjType.Кривая);
        }

        private void AddPlane(List<int> linesNumber)
        {
            project.CreateSurface(linesNumber.ToArray());
            RefreshGeometry(ObjType.Поверхность);
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
            VBOController.DeleteAllVBObjects();
            CreateVBObjects("Объекты");
            PresentMeshData();
            DisplayObjects();
        }
    }
}
