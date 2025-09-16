using BaseModule.Utilities;
using Project.Interfaces;
using PropertiesCalculator.MaterialData;
using PropertiesDataBases.DataBases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void материалыMenuItem_Click(object sender, EventArgs e)
        {
            //var module = (TaskPage)ModulePage;
            OpenMaterialsDB();
        }

        public void OpenMaterialsDB()
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };
                var name = "База материалов";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = matBasePage.Size, ShowIcon = false };
                form.Controls.Add(matBasePage);
                form.ClientSize = matBasePage.Size;
                form.Show();

                matBasePage.LoadEvent += () =>
                {
                    if (project == null)
                        return;

                    project.MaterialsDB = matBasePage.Materials;
                };

                if (project == null)
                    return;

                // Проект без базы здесь не существует. При его создании она берется по-умолчанию

                if (project.MaterialsDB == null)
                {
                    console.PrintInfo($"База данных материалов не загружена", Color.Red);
                    return;
                }
                matBasePage.Materials = project.MaterialsDB;
                matBasePage.PresentMaterials();
                //matBasePage.Load($@"{project.Path}\{project.MaterialsDB.Name}", false);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            //var module = (TaskPage)ModulePage;
            OpenFunctionsDB();
        }

        public void OpenFunctionsDB()
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };
                funBasePage.LoadEvent += () =>
                {
                    if (project == null)
                        return;

                    project.FunctionsDB = funBasePage.Functions;
                };

                var name = "База функций";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = funBasePage.Size, ShowIcon = false };
                form.Controls.Add(funBasePage);
                form.ClientSize = funBasePage.Size;
                form.Show();

                if (project == null)
                    return;

                if (project.FunctionsDB == null)
                {
                    console.PrintInfo($"База данных функций не загружена", Color.Red);
                    return;
                }
                funBasePage.Functions = project.FunctionsDB;
                funBasePage.PresentFunctions();
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
