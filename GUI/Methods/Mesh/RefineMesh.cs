using Model.Interfaces;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void уплотнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO довнедрить
            GmshController.Gmsh.Model.Mesh.Refine();

            project.ClearModelCollection(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            FitObjectsToScreen();
            DisplayObjects();
        }
    }
}
