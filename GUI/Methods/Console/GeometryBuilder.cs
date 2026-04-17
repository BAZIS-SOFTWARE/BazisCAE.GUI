using BazisGUI.Console.Events;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void GeometryParser(CreateGeometryEventArgs geomCreator)
        {
            if (GmshController == null)
            {
                return;
            }
            var objType = (ObjType)geomCreator.Type;
            switch (objType)
            {
                case ObjType.Точка:
                    var prm = geomCreator.Parameters;
                    var coord = prm[0].Split(',');

                    if (double.TryParse(coord[0], out double x) &&
                       double.TryParse(coord[1], out double y) &&
                       double.TryParse(coord[2], out double z))
                        AddPoint(x, y, z);
                    break;
                case ObjType.Кривая:
                    var points = geomCreator.Parameters;
                    if (int.TryParse(points[0], out int startTag) &&
                       int.TryParse(points[1], out int endTag))
                        AddLine(startTag, endTag);
                    break;
                case ObjType.Поверхность:
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

        private void AddPoint(double x, double y, double z, double meshSize = 0)
        {
            project.CreatePoint(x, y, z);
            RefreshGeometry(ObjType.Точка, "Точка");
        }

        private void AddLine(int startTag, int endTag, int tag = -1)
        {
            project.CreateLine(startTag, endTag);
            RefreshGeometry(ObjType.Кривая, "Кривая");
        }

        private void AddPlane(List<int> linesNumber)
        {
            project.CreateSurface(linesNumber.ToArray());
            RefreshGeometry(ObjType.Поверхность, "Поверхность");
        }

        private void RefreshGeometry(ObjType objType, string vboName)
        {
            VBOController.DeleteVBObjects(vboName);

            var presenter = project.CreateModelObjectsPresentor(objType);
            var vbObject = CreateVBObject(presenter);

            VBOController.AddVbo(vbObject);
        }
    }
}
