using Model.Interfaces;
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
                var objs = project.GetModelObjects(ObjType.Кривая);
                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToArray();
                var s = project.CreateChamfer(selObjs, length, angle, isByAngle, reflected);
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                PresentMeshData();
                DisplayObjects();
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
            const string ChamferPreviewName = "ChamferPreview";
            if (!VBOController.DeleteVBObjects(ChamferPreviewName))
                return;

            if (redraw)
                DisplayObjects();
        }
    }
}
