using System;
using System.Drawing;
using System.IO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void загрузитьgeoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var file = GmshController.Gmsh.Model.GetFileName();

                var changed = Path.ChangeExtension(file, "gscript");

                project.LoadSMF(changed);

                console.PrintInfo($"скрипт {changed} выполнен", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void сформироватьgeoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var file = GmshController.Gmsh.Model.GetFileName();

                var changed = Path.ChangeExtension(file, "gscript");
                
                project.SaveSMF(changed);

                console.PrintInfo($"скрипт {changed} сформирован", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
