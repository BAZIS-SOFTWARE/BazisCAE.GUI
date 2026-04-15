using BazisGUI.Console.Events;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.MeshObjects;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void GeometryParser(CreateGeometryEventArgs geomCreator)
        {
            if(GmshController == null)
            {
                return;
            }
            var objType = (ObjType)geomCreator.Type;
            switch (objType)
            {
                case ObjType.Точка:
                    var prm = geomCreator.Parameters;
                    var coord = prm[0].Split(',');

                    if(double.TryParse(coord[0], out double x) &&
                       double.TryParse(coord[1], out double y) &&
                       double.TryParse(coord[2], out double z))
                        AddPoint(x, y, z);
                    break;
                case ObjType.Кривая:
                    AddLine(1,2);
                    break;
                case ObjType.Поверхность:
                    break;
                default:
                    throw new NotSupportedException();
            }


            //GmshController.CreateLines();
            //ImportCAD;
 
            PresentGeoData();
            DisplayObjects();
        }

        private void AddPoint(double x, double y, double z, double meshSize = 0) 
        {
            var crpn = GmshController.Gmsh.Model.Occ.AddPoint(x,y,z);
            GmshController.Gmsh.Model.Occ.Synchronize();
            var points = GmshController.CreateControlPoints();// тут уже видим созданную точку
            
            project.CreateGeometryObject(1, crpn);
            VBOController.DeleteVBObjects("Точка");
            var points1 = project.GetModelObjects(ObjType.Точка);
            var pre = project.CreateModelObjectsPresentor(ObjType.Точка);
            var vb = CreateVBObject(pre);
            VBOController.AddVbo(vb);
        }

        private void AddLine(int startTag, int endTag, int tag = -1)
        {
            GmshController.Gmsh.Model.Occ.AddLine(startTag, endTag);
        }

        private void AddPlane()
        {

        }
    }
}
