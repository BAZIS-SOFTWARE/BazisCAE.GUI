using BazisGUI.Utilities;
using BazisGUI.SettingsControls;
using GmshApi;
using Model;
using Model.Interfaces;
using Model.IO;
using Model.IO.STL;
using Newtonsoft.Json;
using OperationalController;
using OperationalController.GmshController;
using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using BazisGUI.Properties;

namespace BazisGUI
{
    public class IODataController
    {

        public SettingsConfig LoadConfig()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullPath = $@"{folder}\settingsConfig.json";

            if (File.Exists(fullPath))
            {
                var settings = File.ReadAllText(fullPath);
                return (SettingsConfig)JsonConvert.DeserializeObject(settings, typeof(SettingsConfig));
            }
            else return null;
        }
        public GmshController LoadGMSH()
        {
            var path = Environment.GetEnvironmentVariable("BazisMeshPath", EnvironmentVariableTarget.Machine);

            if (path == null || path == "")
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "dinamic library(*.dll)|*.dll|All files(*.*)|*.*"
                    ;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return null;
                path = dialog.FileName;
            }
            else
                path = $@"{path}";


            var gmshController = new GmshController();
            gmshController.Load(path);
            //ObjectData = new ObjectsData();
            gmshController.Gmsh.Option.SetNumber("General.AbortOnError", 0);//Запретить изделию Кристофа обваливать Базис
            
            return gmshController;
        }

        public async Task<ProjectController> ImportMesh(string fullPath)
        {
            var controller = new ProjectController();

            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };

            var mbf = CreateMessageBoxExForm(mb);
            mbf.Show();
            mb.Message = Resources.ImportMeshCaption;
            await Task.Run(new Action(() =>
            {
                controller.MessageEvent += (ar1) =>
                {
                    mb.Invoke(new Action(() =>
                    {
                        mb.Message = ar1;
                    }));
                };
                controller.ImportMesh(fullPath);
            }));
            mbf.Close();

            controller.UnsubMessasge();

            controller.Name = "новый_проект.bpf2";
            return controller;
        }

        public async Task<string> ExportMesh(ProjectController project)
        {

            var filter =
"All files(*.*)|*.*|" +
"STL(*.stl*)|*.stl";

            var dialog = new SaveFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            project.ExportMesh(dialog.FileName);

            //var ext = Path.GetExtension(dialog.FileName);


            //if (ext == ".STL" | ext == ".stl")
            //{
            //    var saver = new SaveToTxtSTLFile();
            //    saver.Save(modelData, dialog.FileName);
            //}

            return dialog.FileName;
        }

        //public async Task<Controller> LoadProjectAsync(string path)
        //{
        //    var controller = new Controller();
        //    MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
        //    { Dock = DockStyle.Fill };

        //    var mbf = CreateMessageBoxExForm(mb);
        //    mbf.Show();
        //    await Task.Run(new Action(() =>
        //    {
        //        // TO DO Сделать динамическое отображение данных при загрузке
        //        controller.MessageEvent += (ar1) =>
        //        {
        //            mb.Invoke(new Action(() =>
        //            {
        //                mb.Message = ar1;
        //            }));
        //        };
        //        controller.Load(path);

        //    }));
        //    mbf.Close();

        //    return controller;
        //}

        public Form CreateMessageBoxExForm(MessageBoxEx.MessageBoxEx mb)
        {
            var mbf = new Form()
            {
                ShowIcon = false,
                Name = "Загрузка",
                Text = Resources.LoadingForm_Text,
                StartPosition = FormStartPosition.Manual,
                Location = new System.Drawing.Point(Application.OpenForms[0].Width / 2, Application.OpenForms[0].Height / 2),
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                ClientSize = mb.Size,
                Owner = Application.OpenForms[0]
            };

            mbf.Controls.Add(mb);
            return mbf;
        }

        public async Task<ProjectController> OpenProject(string fullPath)
        {
            var controller = new ProjectController();
            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };

            var mbf = CreateMessageBoxExForm(mb);
            mbf.Show();
            await Task.Run(new Action(() =>
            {
                controller.MessageEvent += (ar1) =>
                {
                    mb.Invoke(new Action(() =>
                    {
                        mb.Message = ar1;
                    }));
                };
                controller.Load(fullPath);

            }));
            mbf.Close();
            controller.UnsubMessasge();
            return controller;
        }



        //public async Task<Controller> OpenProject(string fullPath)
        //{
        //    var path = Path.GetDirectoryName(fullPath);
        //    var name = Path.GetFileName(fullPath);

        //    var project = CreateNewProject(path, name);

        //    LoadProjectAsync(project);
        //    //await res;
        //    return project;

        //}
    }
}
