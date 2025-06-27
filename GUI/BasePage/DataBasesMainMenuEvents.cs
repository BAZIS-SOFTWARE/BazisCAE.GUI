using Project.Interfaces;
using PropertiesDataBases.DataBases;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            OpenMaterialsDB(project.GeneralData);
        }

        public void OpenMaterialsDB(IGeneralData generalData)
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };

                matBasePage.LoadEvent += () =>
                {
                    ChangeMaterialDBEventHandler(generalData, matBasePage);
                };

                matBasePage.SaveEvent += () =>
                {
                    ChangeMaterialDBEventHandler(generalData, matBasePage);
                };

                var filePath = FindFileByPath(generalData.Path, generalData.Materials);
                if (filePath == null)
                    console.PrintInfo($"База данных {generalData.Materials} не найдена в директории {generalData.Path}", Color.Red);
                else
                    matBasePage.Load($@"{filePath}\{generalData.Materials}", false);

                var name = "База материалов";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = matBasePage.Size, ShowIcon = false };
                form.Controls.Add(matBasePage);
                form.ClientSize = matBasePage.Size;
                form.Show();

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            //var module = (TaskPage)ModulePage;
            OpenFunctionsDB(project.GeneralData);
        }

        public void OpenFunctionsDB(IGeneralData generalData)
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };
                funBasePage.LoadEvent += () =>
                {
                    ChangeFuncDBEventHandler(generalData, funBasePage);
                };

                funBasePage.SaveEvent += () =>
                {
                    ChangeFuncDBEventHandler(generalData, funBasePage);
                };

                var filePath = FindFileByPath(generalData.Path, generalData.Functions);
                if (filePath == null)
                    console.PrintInfo($"База данных {generalData.Functions} не найдена в директории {generalData.Path}", Color.Red);
                else
                    funBasePage.Load($@"{filePath}\{generalData.Functions}", false);

                var name = "База функций";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = funBasePage.Size, ShowIcon = false };
                form.Controls.Add(funBasePage);
                form.ClientSize = funBasePage.Size;
                form.Show();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
