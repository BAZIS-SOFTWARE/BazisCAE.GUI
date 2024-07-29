using BaseModule.Utilities;
using GmshApi.GmshController;
using Model;
using Model.IO;
using ModelControllerInterfaces.GmshController;
using ModelInterfaces;
using Project;
using Project.IO;
using ProjectInterfaces;
using Results.ResultsData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks;

namespace BazisGUI
{
    public class IODataController
    {
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
            var ierr = 0;
            gmshController.OptionSetNumber("General.AbortOnError", 0, ref ierr);//Запретить поделию Кристофа обваливать Базис
            
            return gmshController;
        }

        public ProjectData ImportGeometry(ref GmshController gmshController)
        {
            var dialog = new OpenFileDialog();

            var filter =
"(*.brep*)|*.brep|" +
"(*.geo*)|*.geo|" +
"*.stp*)|*.stp|" +
"(*.step*)|*.step|" +
"(*.iges*)|*.iges|" +
"(*.igs*)|*.igs";

            dialog.Filter = filter;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;


            if (gmshController == null)
                gmshController = LoadGMSH();

            var ierr = 0;
            gmshController.Clear(ref ierr);
            gmshController.Open(dialog.FileName, ref ierr);

            var path = Path.GetDirectoryName(dialog.FileName);
            var name = "новый_проект.bpf";

            var project = CreateNewProject(path, name);

            UpdateGeometry(gmshController, project, ObjType.Точка);
            UpdateGeometry(gmshController, project, ObjType.Линия);

            return project;
            //gmshController.ModelGetFileName()

        }

        private void UpdateGeometry(GmshController gmshController, ProjectData project, ObjType objType)
        {
            if (objType == ObjType.Точка)
            {
                var controlPoints = gmshController.CreateControlPoints();
                if (controlPoints.Count > 0)
                    project.ModelData.ObjectData.PointCollection.AddRange(controlPoints);
            }
            else if (objType == ObjType.Линия)
            {
                var curves = gmshController.CreateLines();
                if (curves.Count > 0)
                    project.ModelData.ObjectData.LineCollection.AddRange(curves);
            }
        }

        public void SaveAsProject(ProjectData project)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "bpf";

                if (saveDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                if (project == null)
                    MessageBox.Show("Сначала откройте или создайте новый проект");
                else
                {
                    var newFolder = Path.GetDirectoryName(saveDialog.FileName);
                    var oldFolder = project.GeneralData.Path;

                    project.GeneralData.Name = Path.GetFileName(saveDialog.FileName);
                    project.GeneralData.Path = newFolder;

                    if (oldFolder != project.GeneralData.Path)
                    {
                        IOFileController.CopyFile(project.GeneralData.Materials, oldFolder, project.GeneralData.Path);
                        IOFileController.CopyFile(project.GeneralData.Functions, oldFolder, project.GeneralData.Path);
                    }

                    project.Save();
                }
            }
        }


        public async Task<ProjectData> ImportMesh()
        {

            var filter =
"All files(*.*)|*.*|" +
"Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp*)|*.inp|" +
"ANSYS(*.cdb*)|*.cdb|" +
"STL(*.stl*)|*.stl|" +
"SOLOMIA(*.dat*)|*.dat";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            var path = Path.GetDirectoryName(dialog.FileName);
            var name = Path.GetFileName(dialog.FileName);

            var project = CreateNewProject(path, name);

            var ext = Path.GetExtension(dialog.FileName);

            if (ext == ".inp")
                project.ModelData.Loader = new LoadModelFromGMSHTextFile();
            else if (ext == ".ASC")
                project.ModelData.Loader = new LoadModelFromASCIITextFile();
            else if (ext == ".dat")
                project.ModelData.Loader = new LoadModelFromSalomeFile();
            else if (ext == ".STL")
                project.ModelData.Loader = new LoadModelFromSTLFile();
            else
                project.ModelData.Loader = new LoadModelFromCDBTextFile();

            await LoadProjectAsync(project);

            project.GeneralData.Name = "новый_проект.bpf";
            return project;
        }

        public async Task LoadProjectAsync(ProjectData project)
        {
            MessageBoxEx.MessageBoxEx mb = new MessageBoxEx.MessageBoxEx()
            { Dock = DockStyle.Fill };
            var mbf = new Form()
            {
                ShowIcon = false,
                Text = "Загрузка данных. Пожалуйста подождите...",
                StartPosition = FormStartPosition.Manual,
                Location =  new System.Drawing.Point(Application.OpenForms[0].Width/2, Application.OpenForms[0].Height / 2),
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                ClientSize = mb.Size,
                Owner = Application.OpenForms[0]
            };

            mbf.Controls.Add(mb);
            mbf.Show();
            await Task.Run(new Action(() =>
            {

                project.Loader.LoadEvent += (ar1, ar2) =>
                {
                    mb.Invoke(new Action(() =>
                    {
                        mb.Message = ar2.Message;
                    }));
                };
                project.Load();

            }));
            mbf.Close();
        }

        public ProjectData CreateNewProject(string path, string name)
        {
            var project = new ProjectData(name, path);
            project.ModelData = new ModelData();
            project.TaskData = new TaskData();
            project.ResultData = new ResultData();

            project.Loader = new LoadProjectFromTextFormat();
            project.Saver = new SaveProjectTextFormat();

            return project;
        }

        public async Task<ProjectData> OpenProject()
        {
            var filter = "Project file(*.bpf)|*.bpf";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.DefaultExt = "bpf";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            var path = Path.GetDirectoryName(dialog.FileName);
            var name = Path.GetFileName(dialog.FileName);

            var project = CreateNewProject(path, name);

            await LoadProjectAsync(project);

            return project;

        }
    }
}
