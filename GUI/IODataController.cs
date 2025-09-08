using BaseModule.Utilities;
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

namespace BazisGUI
{
    public class IODataController
    {
        string meshFilter =
"All files(*.*)|*.*|" +
"Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp)|*.inp|" +
"GMSH(*.inp_v2)|*.inp_v2|" +
"ANSYS(*.cdb*)|*.cdb|" +
"STL(*.stl*)|*.stl|" +
"SOLOMIA(*.dat*)|*.dat";
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

        public void SaveAsProject(Controller controller)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "bpf";

                var filter = "(*.bpf)|*.bpf|(*.bpf2)|*.bpf2";

                saveDialog.Filter = filter;

                if (saveDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                if (controller == null)
                    MessageBox.Show("Сначала откройте или создайте новый проект");
                else
                {
                    var newFolder = Path.GetDirectoryName(saveDialog.FileName);
                    var oldFolder = controller.Path;

                    controller.Name = Path.GetFileName(saveDialog.FileName);
                    controller.Path = newFolder;

                    if (oldFolder != controller.Path)
                    {
                        if(controller.MaterialsDB != null)
                            IOFileController.CopyFile(controller.MaterialsDB.Name, oldFolder, controller.Path);
                        if (controller.FunctionsDB != null)
                            IOFileController.CopyFile(controller.FunctionsDB.Name, oldFolder, controller.Path);
                    }

                    controller.Save(saveDialog.FileName);
                }
            }
        }

        public async Task AppendModel(IModelData modelData)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = meshFilter;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            var ext = Path.GetExtension(dialog.FileName);

            if (ext == ".inp")
                modelData.Loader = new LoadModelFromINPTextFile();
            else if (ext == ".inp_v2")
                modelData.Loader = new LoadModelFromINPTextFile_v2();
            else if (ext == ".ASC")
                modelData.Loader = new LoadModelFromASCIITextFile_v2();
            else if (ext == ".dat")
                modelData.Loader = new LoadModelFromSalomeFile();
            else if (ext == ".STL" | ext == ".stl")
                modelData.Loader = new LoadFromSTLFile();
            else
                modelData.Loader = new LoadModelFromCDBTextFile();

            await AppendModelAsync(modelData, dialog.FileName);
        }

        private async Task AppendModelAsync(IModelData modelData, string path)
        {
            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };

            var mbf = CreateMessageBoxExForm(mb);
            mbf.Show();
            await Task.Run(new Action(() =>
            {

                modelData.Loader.LoadEvent += (ar1, ar2) =>
                {
                    mb.Invoke(new Action(() =>
                    {
                        mb.Message = ar2.Message;
                    }));
                };
                modelData.Append(path);

            }));
            mbf.Close();
        }

        public async Task<Controller> ImportMesh()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = meshFilter;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            var path = Path.GetDirectoryName(dialog.FileName);
            var name = Path.GetFileName(dialog.FileName);

            var project = new Controller();

            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };

            var mbf = CreateMessageBoxExForm(mb);
            mbf.Show();
            mb.Message = "Импорт сетки...";
            await Task.Run(new Action(() =>
            {
                project.ImportMesh($"{path}\\{name}");
            }));
            mbf.Close();

            project.Name = "новый_проект.bpf2";
            return project;
        }

        public async Task<string> ExportMesh(Controller project)
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

        public async Task<Controller> LoadProjectAsync(string path)
        {
            var controller = new Controller();
            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };

            var mbf = CreateMessageBoxExForm(mb);
            mbf.Show();
            await Task.Run(new Action(() =>
            {
                // TO DO Сделать динамическое отображение данных при загрузке
                //controller.ModelData.Loader.LoadEvent += (ar1, ar2) =>
                //{
                mb.Invoke(new Action(() =>
                {
                    mb.Message = "Открытие проекта...";
                }));
                //};
                controller.Load(path);

            }));
            mbf.Close();

            return controller;
        }

        public Form CreateMessageBoxExForm(MessageBoxEx.MessageBoxEx mb)
        {
            var mbf = new Form()
            {
                ShowIcon = false,
                Text = "Загрузка данных. Пожалуйста подождите...",
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

        public Controller CreateNewProject(string path, string name)
        {
            var project = new Controller();
            project.CreateProject($"{path}\\{name}");
            //project.MaterialsDB = "materials_v3.jsf";
            //project.FunctionsDB = "functions.jsf";   
            


            //var startMatPath = Application.StartupPath + "\\Materials";
            //IOFileController.CopyFile(project.MaterialsDB, startMatPath, path);
            //var startFunPath = Application.StartupPath + "\\Functions";
            //IOFileController.CopyFile(project.FunctionsDB, startFunPath, path);

            return project;
        }

        public async Task<Controller> OpenProject()
        {
            var filter = "Project file(*.bpf)|*.bpf|Project file(*.bpf2)|*.bpf2";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.DefaultExt = "bpf";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            var path = Path.GetDirectoryName(dialog.FileName);
            var name = Path.GetFileName(dialog.FileName);

            //var project = CreateNewProject(path, name);

            var res = LoadProjectAsync(dialog.FileName);
            await res;

            return res.Result;

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

        public string OpenResults()
        {
            var openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = Path.GetFullPath(System.Windows.Forms.Application.ExecutablePath);
            openDialog.AddExtension = true;

            openDialog.Filter = "Results files (*.db)|*.db";

            if (openDialog.ShowDialog() == DialogResult.Cancel)
                return string.Empty;

            return openDialog.FileName;
        }
    }
}
