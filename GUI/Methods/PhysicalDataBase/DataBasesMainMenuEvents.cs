using BazisGUI.Args;
using BazisGUI.DataBases;
using BazisGUI.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void материалыMenuItem_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripMenuItem;
            var name = Resources.BaseForm_материалыMenuItem_Click_Materials;
            if (btn.Checked)
                OpenMaterialsDB(name);
            else
                TabButtonsService.RemoveControl(name);
        }

        public void OpenMaterialsDB(string name)
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() { HeadColor = Color.Gainsboro };

                matBasePage.LoadEvent += () =>
                {
                    if (project == null)
                        return;

                    project.MaterialsDB = matBasePage.Materials;
                    console.PrintInfo($"{Resources.DataBaseMainMenuEvents_OpenDB_Message} {matBasePage.Materials.Name} {Resources.DataBaseMainMenuEvents_OpenDB_SuccessfullyAdded_Message}", Color.Green);
                };

                if (project == null)
                    return;

                // Проект без базы здесь не существует. При его создании она берется по-умолчанию

                if (project.MaterialsDB == null)
                {
                    console.PrintInfo(Resources.DataBaseMainMenuEvents_OpenMatDB_DBNotLoaded_Message, Color.Red);
                    return;
                }
                matBasePage.Materials = project.MaterialsDB;
                matBasePage.PresentMaterials();
                matBasePage.OnMutationEvent += () => OnChangeMaterials(this, new ChangeMaterialsEventArgs(project.MaterialsDB.Keys.ToArray()));
                OnChangeMaterials?.Invoke(this, new ChangeMaterialsEventArgs(project.MaterialsDB.Keys.ToArray()));

                TabButtonsService.AddControl(name, matBasePage);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripMenuItem;
            var name = Resources.BaseForm_функцииMenuItem_Click_Functions;

            if (btn.Checked)
                OpenFunctionsDB(name);
            else
                TabButtonsService.RemoveControl(name);
        }

        public void OpenFunctionsDB(string name)
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() {  HeadColor = Color.Gainsboro };

                funBasePage.LoadEvent += () =>
                {
                    if (project == null)
                        return;

                    project.FunctionsDB = funBasePage.Functions;
                    console.PrintInfo($"{Resources.DataBaseMainMenuEvents_OpenDB_Message} {funBasePage.Functions.Name} {Resources.DataBaseMainMenuEvents_OpenDB_SuccessfullyAdded_Message}", Color.Green);
                };

                if (project == null)
                    return;

                if (project.FunctionsDB == null)
                {
                    console.PrintInfo(Resources.DataBaseMainMenuEvents_OpenFuncDB_DBNotLoaded_Message, Color.Red);
                    return;
                }
                funBasePage.Functions = project.FunctionsDB;
                funBasePage.PresentFunctions();

                funBasePage.OnMutationEvent += () => OnChangeFunctions(this, new ChangeFunctionsEventArgs(project.FunctionsDB.Keys.ToArray()));
                OnChangeFunctions?.Invoke(this, new ChangeFunctionsEventArgs(project.FunctionsDB.Keys.ToArray()));

                TabButtonsService.AddControl(name, funBasePage);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private string FindFileByPath(string path, string fileName)
        {
            var projFiles = Directory.GetFiles(path, fileName, SearchOption.AllDirectories);
            if (projFiles.Count() > 0)
            {
                return Path.GetDirectoryName(projFiles[0]);
            }

            return null;
        }
    }
}
