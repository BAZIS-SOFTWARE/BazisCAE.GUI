using BazisGUI.Extensions;
using BazisGUI.Localization;
using BazisGUI.Navigator;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using Newtonsoft.Json;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace BazisGUI
{
    public partial class BaseForm
    {
        enum CompPropertyKeys { Type, Execute, Algorithm, SolveIterations, SolveAccuracy, RelaxationCoef, MaxRelaxationCoef, Priority, IterationOnStep, SaveRate, InitTemp, StartTime, StopTime, InitialSolveStep, MinSolveStep, MaxSolveStep }
        enum PriorityKeys { Низкий, НижеСреднего, Средний, ВышеСреднего, Высокий, Наивысший }

        private void ChangeCompProperties(PropertyChangedEventArgs obj, string nodeText)
        {
            var parameters = ReadTaskParametersFromFile(nodeText.Split(' ')[1]);
            if (parameters is ChemicalParameters cmp) 
                ChangeChemicalTask(obj, cmp);
            else if (parameters is MechanicalParameters mhp) 
                ChangeMechanicalTask(obj, mhp);
            else if (parameters is TermalParameters tmp)
                ChangeTermalTask(obj, tmp);

            var key = Enum.Parse<CompPropertyKeys>(obj.Key);
            switch (key)
            {
                case CompPropertyKeys.Execute:
                    // TODO: проверить корректность работы с данными при их смене
                    var isExe = bool.Parse(obj.NewValue);
                    var selectedInstruction = navigator.SelectedNode;
                    selectedInstruction.Text = selectedInstruction.Text.Replace(isExe ? Properties.Resources.Пропустить : Properties.Resources.Выполнить, isExe ? Properties.Resources.Выполнить : Properties.Resources.Пропустить);
                    nodeText = selectedInstruction.Text;
                    break;
                case CompPropertyKeys.Algorithm:
                    parameters.SolverSettings.Solver = obj.NewValue;
                    break;
                case CompPropertyKeys.SolveIterations:
                    parameters.SolverSettings.MaxIter = int.Parse(obj.NewValue);
                    break;
                case CompPropertyKeys.SolveAccuracy:
                    parameters.SolverSettings.Precision = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.RelaxationCoef:
                    parameters.SolverSettings.Relaxation = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.MaxRelaxationCoef:
                    parameters.SolverSettings.MaxRelaxation = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.Priority:
                    parameters.SolverSettings.Priority = obj.NewValue;
                    break;
                case CompPropertyKeys.IterationOnStep:
                    parameters.Iterations = int.Parse(obj.NewValue);
                    break;
                case CompPropertyKeys.SaveRate:
                    parameters.SaveRate = int.Parse(obj.NewValue);
                    break;
                case CompPropertyKeys.InitTemp:
                    parameters.InitTemp = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.StartTime:
                    parameters.TimeSettings.StartTime = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.StopTime:
                    parameters.TimeSettings.StopTime = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.InitialSolveStep:
                    parameters.TimeSettings.InitTimeStep = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.MinSolveStep:
                    parameters.TimeSettings.MinTimeStep = ParseFloatValue(obj.NewValue);
                    break;
                case CompPropertyKeys.MaxSolveStep:
                    parameters.TimeSettings.MaxTimeStep = ParseFloatValue(obj.NewValue);
                    break;
            }
            SaveGeneralParametersToFile(parameters, nodeText);

            //перерисовывает панель свойств если был нажат какой либо чек бокс
            
            //if(bool.TryParse(obj.NewValue, out bool res))
                    //Navigator_SelectCompEvent(nodeName, nodeText);
        }

        private void ChangeCompProperties(PropertyChangedEventArgs obj)
        {
            var key = Enum.Parse<CompPropertyKeys>(obj.Key);

            if (key == CompPropertyKeys.Type)
                selectInstruction = obj.NewValue;
            else if (key == CompPropertyKeys.Execute)
            {
                // obj.LocalizedHeader.Contains("Выполнять")
                var name = obj.LocalizedHeader.Split(' ')[1];
                navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);
                var selectedInstruction = task[0].Nodes.Cast<TreeNode>().FirstOrDefault(inst => inst.Text.Contains(name));

                var isExe =  bool.Parse(obj.NewValue);
                if (isExe)
                    selectedInstruction.Text = selectedInstruction.Text.Replace(Resources.Пропустить, Resources.Выполнить);
                else
                    selectedInstruction.Text = selectedInstruction.Text.Replace(Resources.Выполнить, Resources.Пропустить);
            }
            Navigator_SelectCompsEvent();
        }

        [Obsolete ("Отсутствует химические задачи, не протестировано")]
        private void ChangeChemicalTask(PropertyChangedEventArgs obj, ChemicalParameters cmp)
        {
            var key = Enum.Parse<ChemicalTaskPropertyKeys>(obj.Key);
            switch (key)
            {
                case ChemicalTaskPropertyKeys.MaxConсentration:
                    cmp.ChemicalConvergence.Is_Switched_Cm = bool.Parse(obj.NewValue);
                    break;
                case ChemicalTaskPropertyKeys.MaxConсentrationValue:
                    cmp.ChemicalConvergence.Cm = ParseFloatValue(obj.NewValue);
                    break;
                case ChemicalTaskPropertyKeys.InitialConcentration:
                    cmp.InitConcentration = ParseFloatValue(obj.NewValue);
                    break;
            }
        }

        private void ChangeTermalTask(PropertyChangedEventArgs obj, TermalParameters tmp)
        {

            if (obj.LocalizedHeader == "Макс. темп. (dTt max), C°")
                tmp.TermalConvergence.Is_Switched_Tm = bool.Parse(obj.NewValue);
            else if (obj.LocalizedHeader == "Значение макс. темп.")
                tmp.TermalConvergence.Tm = ParseFloatValue(obj.NewValue);
        }

        private void ChangeMechanicalTask(PropertyChangedEventArgs obj, MechanicalParameters mhp)
        {
            if (obj.LocalizedHeader == "Макс. разница dU, >0")
                mhp.MechanicalConvergence.DUm = ParseFloatValue(obj.NewValue);
            else if (obj.LocalizedHeader == "Макс. перемещения U, >0")
                mhp.MechanicalConvergence.Is_Switched_Um = bool.Parse(obj.NewValue);
            else if (obj.LocalizedHeader == "Значение макс. перемещения U")
                mhp.MechanicalConvergence.Um = ParseFloatValue(obj.NewValue);
            else if (obj.LocalizedHeader == "Пласт. деформации Si/St, >1")
                mhp.MechanicalConvergence.Is_Physically_NonLinear = bool.Parse(obj.NewValue);
            else if (obj.LocalizedHeader == "Значение пласт. деформации Si/St")
                mhp.MechanicalConvergence.PlasticityCriterion = ParseFloatValue(obj.NewValue);
        }

        private void ApplySettingsToAllInstructions()
        {
            try
            {
                var selectedNode = navigator.SelectedNode;
                var compType = selectedNode.Text.Split(' ')[0];
                var sample = ReadTaskParametersFromFile(selectedNode.Text.Split(' ')[1]);

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add(item.Text);

                foreach (var taskName in tasks)
                    if (taskName.Contains(compType))
                    {
                        var temp = ReadTaskParametersFromFile(taskName.Split(' ')[1]);

                        if(temp is TermalParameters term)
                        {
                            var _sample = sample as TermalParameters;
                            term.TermalConvergence.Is_Switched_Tm = _sample.TermalConvergence.Is_Switched_Tm;
                            term.TermalConvergence.Tm = _sample.TermalConvergence.Tm;
                        }
                        else if (temp is MechanicalParameters mech)
                        {
                            var _sample = sample as MechanicalParameters;
                            mech.MechanicalConvergence.DUm = _sample.MechanicalConvergence.DUm;
                            mech.MechanicalConvergence.Is_Physically_NonLinear = _sample.MechanicalConvergence.Is_Physically_NonLinear;
                            mech.MechanicalConvergence.Is_Switched_Um = _sample.MechanicalConvergence.Is_Switched_Um;
                            mech.MechanicalConvergence.MaterialPlasticityCoeff = _sample.MechanicalConvergence.MaterialPlasticityCoeff;
                            mech.MechanicalConvergence.Um = _sample.MechanicalConvergence.Um;
                            mech.MechanicalConvergence.PlasticityCriterion = _sample.MechanicalConvergence.PlasticityCriterion;
                            mech.MechanicalConvergence.SiStm = _sample.MechanicalConvergence.SiStm;
                        }

                        temp.InitTemp = sample.InitTemp;
                        temp.Iterations = sample.Iterations;
                        temp.MetallurgicalProcesses = sample.MetallurgicalProcesses;
                        temp.SaveRate = sample.SaveRate;
                        temp.SolverSettings = sample.SolverSettings;
                        temp.TermalProcesses = sample.TermalProcesses;
                        temp.TimeSettings.InitTimeStep = sample.TimeSettings.InitTimeStep;
                        temp.TimeSettings.MinTimeStep = sample.TimeSettings.MinTimeStep;
                        temp.TimeSettings.MaxTimeStep = sample.TimeSettings.MaxTimeStep;
                        SaveGeneralParametersToFile(temp, taskName);
                    }
                        // TODO
                       
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SaveGeneralParametersToFile(GeneralParameters parameters, string nodeText)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);
            var path = nodeText.Split(' ')[1];
            File.WriteAllText(path, parLine);
        }

        private float ParseFloatValue(string value)
        {
            value = value.Trim().Replace(',', '.');
            return float.Parse(value);
        }
    }
}