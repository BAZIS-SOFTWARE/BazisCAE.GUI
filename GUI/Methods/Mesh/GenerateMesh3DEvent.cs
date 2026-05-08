using BazisGUI.Properties;
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
        private void создать3DСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // заглушка
                if (GmshController.Gmsh == null)
                    throw new NullReferenceException(Resources.GenerateMesh3DEvents_Generate3D_GMSHNull_Exception);
                DeleteGMSHMeshObjects(ObjType.Узел);
                project.ClearModelCollection(ObjType.Узел);
                project.GenerateMesh(3);

                if (!settingsConfig.ShowAllMeshWhenGeneration)
                {
                    project.HideMesh(1);
                    project.HideMesh(2);
                    project.HideMesh(3);
                }
                    
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

                console.PrintInfo(Resources.GenerateMesh3DEvents_Generate3D_GeneratedElements_Message +
                    $" 1D: {project.GetModelObjects(ObjType.Элемент1D).Count()}," +
                    $" 2D: {project.GetModelObjects(ObjType.Элемент2D).Count()}," +
                    $" 3D: {project.GetModelObjects(ObjType.Элемент3D).Count()}." +
                    $" {Resources.GenerateMesh3DEvents_Generate3D_CheckRecommendation_Message}", Color.Orange);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                return;
            }
        }

        private void DeleteGMSHMeshObjects(ObjType type)
        {
            int[] dimTags = null;
            var dim = 0;
            if (type == ObjType.Узел) //удаляем всю сетку узлы,1d,2d,3d
            {
                dimTags = new int[0];
            }
            if (type == ObjType.Элемент1D)//удаляем все 1d элементы
            {
                dim = 1;
                dimTags = GmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент2D)//удаляем все 2d элементы
            {
                dim = 2;
                dimTags = GmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент3D)//удаляем все 3d элементы
            {
                dim = 3;
                GmshController.Gmsh.Model.GetEntities(dim);
            }
            GmshController.Gmsh.Model.Mesh.Clear(dimTags);
        }
    }
}
