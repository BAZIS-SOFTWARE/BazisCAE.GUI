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
                    ChangeMaterialDBEventHandler(matBasePage);
                };

                matBasePage.SaveEvent += () =>
                {
                    ChangeMaterialDBEventHandler(matBasePage);
                };

                if (project == null)
                    return;

                var filePath = FindFileByPath(project.Path, project.MaterialsDB);
                if (filePath == null)
                    console.PrintInfo($"База данных {project.MaterialsDB} не найдена в директории {project.Path}", Color.Red);
                else
                    matBasePage.Load($@"{filePath}\{project.MaterialsDB}", false);
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
                    ChangeFuncDBEventHandler(funBasePage);
                };

                funBasePage.SaveEvent += () =>
                {
                    ChangeFuncDBEventHandler(funBasePage);
                };

                var name = "База функций";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = funBasePage.Size, ShowIcon = false };
                form.Controls.Add(funBasePage);
                form.ClientSize = funBasePage.Size;
                form.Show();

                if (project == null)
                    return;

                var filePath = FindFileByPath(project.Path, project.FunctionsDB);
                if (filePath == null)
                    console.PrintInfo($"База данных {project.FunctionsDB} не найдена в директории {project.Path}", Color.Red);
                else
                    funBasePage.Load($@"{filePath}\{project.FunctionsDB}", false);


            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void ChangeFuncDBEventHandler(FunctionDataBasePage funBasePage)
        {
            if (project == null)
                return;

            if (funBasePage.DbPath != project.Path)
                IOFileController.CopyFile(funBasePage.DbName, funBasePage.DbPath, project.Path);

            project.FunctionsDB = funBasePage.DbName;
            var funData = funBasePage.Functions;
            //GetTaskAdvisor()?.SetFunctions(funData.Keys.ToList());
            PresentMatAndFuncData();
        }

        public void ChangeMaterialDBEventHandler(MaterialsDataBasePage matBasePage)
        {
            if (project == null)
                return; 

            if (matBasePage.DbPath != project.Path)
                IOFileController.CopyFile(matBasePage.DbName, matBasePage.DbPath, project.Path);

            project.MaterialsDB = matBasePage.DbName;
            var matData = matBasePage.Materials;
            //GetTaskAdvisor()?.SetMaterials(matData.Keys.ToList());
            PresentMatAndFuncData();
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
