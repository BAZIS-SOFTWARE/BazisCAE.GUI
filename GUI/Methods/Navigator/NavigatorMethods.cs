using BazisGUI.TasksControls;
using Geometry;
using Model.Interfaces;
using Newtonsoft.Json;
using Project.Interfaces.Tasks;
using Project.TaskParameters;
using Project.Tasks.Functions.FrameFunctions;
using Project.Tasks.LocalFrames;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    enum ResultType { nodes, elements }
    public partial class BaseForm
    {
        private void DisplayMRF(float time, ICondData data)
        {

            if (data.LocalFrame is MovedFrame mf)
            {
                mf.Time = time - data.StartTime;
                var trajPoints = mf.BaseLine.Select(x => x.CalcCentr()).ToArray();
                DisplayPath(trajPoints);
            }


            data.LocalFrame.CalcPosition();
            DisplayLocalFrame(data.LocalFrame.Frame);

            if (data.Function is SPH sphear)
            {
                DisplaySphere((float)sphear.Width, data.LocalFrame.Frame);
            }
            else if (data.Function is CIL cilinder)
            {
                DisplayConus((float)cilinder.UpperDiam, (float)cilinder.BottomDiam, (float)cilinder.Length, data.LocalFrame.Frame);
            }
        }

        public void DisplayDirection(float time, ICondData data, IEnumerable<IModelObject> modelObjs)
        {
            var vector = new Point3D();
            Color color;

            if (data.Direction == Direction.X)
            {
                vector = new Point3D(1, 0, 0);
                color = Color.FromArgb(255, 0, 0);
            }

            else if (data.Direction == Direction.Y)
            {
                vector = new Point3D(0, 1, 0);
                color = Color.FromArgb(0, 255, 0);
            }

            else
            {
                vector = new Point3D(0, 0, 1);
                color = Color.FromArgb(0, 0, 255);
            }

            DisplayGeometryObjectEvent = null;
            
            foreach (var obj in modelObjs)
            {
                foreach (var point in obj.GetCoordinates())
                {
                    var temp = vector.Mult(0.01f);
                    var p1 = point.Sum(temp);
                    DisplayVector(temp, point, color);
                }
                //DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        
        [Obsolete("Не используем, так как свойства редактируются через панель \"свойств\"")]
        public void EditTSFFile(string fileName)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(fileName);

                var cntr = new TaskControl();
                cntr.BtnSave_ClickEvent += (arg) =>
                {
                    File.WriteAllText(fileName, arg);
                    console.PrintInfo($"Файл {fileName} изменен", Color.Green);
                };
                cntr.InputData(parameters);

                var location = PointToScreen(Point.Empty);

                var form = new Form()
                {
                    Text = fileName,
                    ShowIcon = false,
                    ClientSize = cntr.Size,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Owner = Application.OpenForms[0],

                };
                form.Controls.Add(cntr);
                form.Location = location;
                form.Show();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Green);
            }

        }

        public GeneralParameters ReadTaskParametersFromFile(string filePath)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var taskName = fileName.Split('_')[0];

            TaskKind taskKind;
            Enum.TryParse(taskName, out taskKind);

            if (taskKind == TaskKind.термическая)
            {
                return JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else if (taskKind == TaskKind.механическая)
            {
                return JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else return JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(filePath), settingsSerializer);

        }
    }
}
