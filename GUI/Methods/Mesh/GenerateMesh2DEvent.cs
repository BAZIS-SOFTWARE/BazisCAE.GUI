using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;

namespace BazisGUI
{
    public partial class BaseForm
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void наПоверхностиГеометрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteGMSHMeshObjects(ObjType.Узел);
                project.ClearModelCollection(ObjType.Узел);
                project.GenerateMesh(2, GmshController);

                //gmshController.Gmsh.Model.Mesh.Generate(3);
                //var nds = gmshController.GetNodes();

                var error = GmshController.Gmsh.Logger.GetLastError();
                if (!string.IsNullOrEmpty(error))
                    console.PrintInfo(error, Color.Red);

                DeleteVBObjsByObjsType(ObjType.Узел);
                CreateVBObjsByObjsType(ObjType.Узел);
                DeleteVBObjects("Элементы");
                CreateVBObjects("Элементы");
                PresentMeshData();
                PresentModelObjectsForSelection();
                FitObjectsToScreen();
                DisplayObjects();

                console.PrintInfo($"Сгенерировано элементов" +
                    $" 1D: {project.GetModelSetsInfo(ObjType.Элемент1D).Sum(x => x.NumberOfObjects)}," +
                    $" 2D: {project.GetModelSetsInfo(ObjType.Элемент2D).Sum(x => x.NumberOfObjects)}." +
                    $" Рекомендуется проверить порядок точности наборов перед началом расчета в панели свойств, выбрав его в навигаторе", Color.DarkOrange);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                return;
            }
        }
    }
}
