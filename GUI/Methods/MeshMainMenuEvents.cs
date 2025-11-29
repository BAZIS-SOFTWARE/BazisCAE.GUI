using Model.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    { 

        //[HandleProcessCorruptedStateExceptions]
        //[SecurityCritical]
        //private void MeshGenerator_generate2DMeshEvent(object sender, double meshDencity)
        //{
        //    try
        //    {
        //        var cntr = (GMSHGeneralMeshControl)sender;
        //        GmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeFactor", meshDencity);

        //        DeleteGMSHMeshObjects(ObjType.Узел);
        //        GmshController.Gmsh.Model.Mesh.Generate(1);
        //        GmshController.Gmsh.Model.Mesh.Generate(2);
        //    }
        //    catch (Exception ex)
        //    {
        //        console.PrintInfo(ex.Message, Color.Red);
        //        return;
        //    }
        //    var error = GmshController.Gmsh.Logger.GetLastError();
        //    if (!string.IsNullOrEmpty(error))
        //        console.PrintInfo(error, Color.Red);

        //    project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

        //    FitObjectsToScreen();
        //    DisplayObjects();
        //}

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
