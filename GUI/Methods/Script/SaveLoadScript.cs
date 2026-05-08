using BazisGUI.Properties;
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

                console.PrintInfo($"{Resources.SaveLoadScript_GeoScript_Message} {changed} {Resources.SaveLoadScript_GeoScript_Executed_Message}", Color.Green);
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

                console.PrintInfo($"{Resources.SaveLoadScript_GeoScript_Message} {changed} {Resources.SaveLoadScript_GeoScript_Formed_Message}", Color.Green);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
