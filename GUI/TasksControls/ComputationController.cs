using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using Project;
using ProjectInterfaces.Tasks;
using ProjectInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks;
using TasksParameters;
using Newtonsoft.Json;
using AdvisorControls.TaskPlannerControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace BazisGUI.TasksControls
{
    public class ComputationController
    {

        public ComputationController(string projPath)
        {
            ProjPath = projPath;
        }

        public string ProjPath { get; }

        public void CreateFileParameters(ComputationToken compToken, PreProc preProc, ProcessType processType)
        {
            if (compToken.TasksSet == TasksSet.термическая)
            {
                var compData = CreateCompData<TermalParameters>(TaskKind.термическая, compToken);
                preProc.SetDraftParameters(compData.Item2, processType);

                WriteTaskParametersToFile(compData.Item1, compData.Item2);
            }
            else if (compToken.TasksSet == TasksSet.механическая)
            {
                var compData = CreateCompData<MechanicalParameters>(TaskKind.механическая, compToken);
                preProc.SetDraftParameters(compData.Item2, processType);

                WriteTaskParametersToFile(compData.Item1, compData.Item2);
            }
            else if (compToken.TasksSet == TasksSet.термическая_и_механическая)
            {
                var tCompData = CreateCompData<TermalParameters>(TaskKind.термическая, compToken);
                preProc.SetDraftParameters(tCompData.Item2, processType);

                WriteTaskParametersToFile(tCompData.Item1, tCompData.Item2);

                var mCompData = CreateCompData<MechanicalParameters>(TaskKind.механическая, compToken);
                preProc.SetDraftParameters(mCompData.Item2, processType);

                mCompData.Item2.ThermalFile = tCompData.Item1;

                WriteTaskParametersToFile(mCompData.Item1, mCompData.Item2);
            }
        }

        private Tuple<string,T> CreateCompData<T>(TaskKind taskKind, ComputationToken compToken)
            where T : GeneralParameters, new()
        {
            var taskParams = new T();

            FillTaskTimeParameters(compToken.TimeParam, taskParams);

            if (compToken.FurtherComputation)
                taskParams.RestartFile = $"{taskKind}_*_*_" +
$"{compToken.TimeParam.StartTime}.tsf";

            var fileName = $"{taskKind}_{compToken.TaskIndex}_" +
$"{compToken.TimeParam.StartTime}_" +
$"{compToken.TimeParam.StopTime}.tsf";

            return new Tuple<string, T>(fileName, taskParams);
        }

        private void FillTaskTimeParameters(TimeParameters args, GeneralParameters parameters)
        {
            parameters.TimeSettings.InitTimeStep = args.InitTimeStep;
            parameters.TimeSettings.MaxTimeStep = args.MaxTimeStep;
            parameters.TimeSettings.MinTimeStep = args.MinTimeStep;
            parameters.TimeSettings.StartTime = args.StartTime;
            parameters.TimeSettings.StopTime = args.StopTime;
        }

        private void WriteTaskParametersToFile(string fileName, GeneralParameters parameters)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);

            File.WriteAllText($@"{ProjPath}\InputData\{fileName}", parLine);
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

            TasksSet tasksSet;
            Enum.TryParse(taskName, out tasksSet);

            if (tasksSet == TasksSet.термическая)
            {
                return JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else if (tasksSet == TasksSet.механическая)
            {
                return JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else return JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(filePath), settingsSerializer);

        }
    }
}
