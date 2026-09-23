using Model.Interfaces;
using Geometry;
using OperationalController.GeomObjsCreator;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void CreateChamfer(double length, double angle, bool isByAngle, bool reflected)
        {
            try
            {
                var selObjs = project.ModelView.GetSelected(ObjType.Кривая).ToArray();
                var s = project.CreateChamfer(selObjs, length, angle, isByAngle, reflected);
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                PresentMeshData();
                RequestRedraw();
                PresentGeoData();
            }
            catch (Exception ex) 
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
            RequestClearChamferPreview();
        }


        private void ClearChamferPreview(bool redraw = true)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ClearChamferPreview(redraw)));
                return;
            }

            chamferPreviewSegments = Array.Empty<Segment3D>();
            DisplayGeometryObjectEvent -= DisplayChamferPreview;

            if (redraw)
                RequestRedraw();
        }
    }
}
