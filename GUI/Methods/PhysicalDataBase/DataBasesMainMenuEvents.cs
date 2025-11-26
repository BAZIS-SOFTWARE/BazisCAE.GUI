using BaseModule.Utilities;
using Mono.Unix.Native;
using Project.Interfaces;
using PropertiesCalculator.MaterialData;
using BazisGUI.DataBases;
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
            var btn = sender as ToolStripMenuItem;

            if(btn.Checked)
                OpenMaterialsDB();
            else
            {
                HideTabButton("btnTabМатериалы");
                splitContainer3.Panel1.Controls.RemoveByKey("cntrМатериалы");
            }
        }

        public void OpenMaterialsDB()
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() 
                { 
                    Dock = DockStyle.Fill, 
                    HeadColor = Color.Gainsboro,
                    Name = "cntrМатериалы"
                };

                ShowTabButton("btnTabМатериалы");

                matBasePage.Size = cntrНавигатор.Size;
                matBasePage.Location = cntrНавигатор.Location;
                matBasePage.Anchor = cntrНавигатор.Anchor;

                splitContainer3.Panel1.Controls.Add(matBasePage);
                matBasePage.BringToFront();

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
            var btn = sender as ToolStripMenuItem;

            if (btn.Checked)
                OpenFunctionsDB();
            else
            {
                HideTabButton("btnTabФункции");
                splitContainer3.Panel1.Controls.RemoveByKey("cntrФункции");
            }
        }

        public void OpenFunctionsDB()
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() 
                { 
                    Dock = DockStyle.Fill, 
                    HeadColor = Color.Gainsboro,
                    Name = "cntrФункции"
                };
                funBasePage.LoadEvent += () =>
                {
                    if (project == null)
                        return;

                    project.FunctionsDB = funBasePage.Functions;
                };

                ShowTabButton("btnTabФункции");

                funBasePage.Size = cntrНавигатор.Size;
                funBasePage.Location = cntrНавигатор.Location;
                funBasePage.Anchor = cntrНавигатор.Anchor;

                splitContainer3.Panel1.Controls.Add(funBasePage);
                funBasePage.BringToFront();

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
