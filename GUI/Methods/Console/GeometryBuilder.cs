using BazisGUI.Console.Events;
using Model.Interfaces;
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
            GmshController.Gmsh.Model.Occ.Synchronize();
            
            PresentGeoData();
            DisplayObjects();
        }

        private void AddPoint(double x, double y, double z, double meshSize = 0) 
        {
            //GmshController.Gmsh.Model.Add("surface");
            GmshController.Gmsh.Model.Occ.AddPoint(x,y,z);
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
