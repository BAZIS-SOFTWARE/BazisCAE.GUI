using BazisGUI.Extensions;
using BazisGUI.Navigator;
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
        private void ChangeCompProperties(PropertyChangedEventArgs obj, string nodeText)
        {
            var parameters = ReadTaskParametersFromFile(nodeText.Split(' ')[1]);
            if (parameters is ChemicalParameters cmp) 
                ChangeChemicalTask(obj, cmp);
            else if (parameters is MechanicalParameters mhp) 
                ChangeMechanicalTask(obj, mhp);
            else if (parameters is TermalParameters tmp)
                ChangeTermalTask(obj, tmp);

            switch (obj.Header)
            {
                case "Выполнить":
                    var isExe = bool.Parse(obj.NewValue);
                    var selectedInstruction = navigator.SelectedNode;
                    selectedInstruction.Text = selectedInstruction.Text.Replace(isExe ? "пропустить" : "выполнить", isExe ? "выполнить" : "пропустить");
                    nodeText = selectedInstruction.Text;
                    break;
                case "Алгоритм решения":
                    parameters.SolverSettings.Solver = obj.NewValue;
                    break;
                case "Кол-во итераций решения":
                    parameters.SolverSettings.MaxIter = int.Parse(obj.NewValue);
                    break;
                case "Точность решения, у.ед.":
                    parameters.SolverSettings.Precision = ParseFloatValue(obj.NewValue);
                    break;
                case "Коэф. релаксации (w)":
                    parameters.SolverSettings.Relaxation = ParseFloatValue(obj.NewValue);
                    break;
                case "Max. коэф. релаксации (wm)":
                    parameters.SolverSettings.MaxRelaxation = ParseFloatValue(obj.NewValue);
                    break;
                case "Приоритет":
                    parameters.SolverSettings.Priority = obj.NewValue;
                    break;
                case "Кол-во итераций на шаге":
                    parameters.Iterations = int.Parse(obj.NewValue);
                    break;
                case "Частота сохранений, шаг":
                    parameters.SaveRate = int.Parse(obj.NewValue);
                    break;
                case "Начальная температура, C°":
                    parameters.InitTemp = ParseFloatValue(obj.NewValue);
                    break;
                case "Время начала, сек":
                    parameters.TimeSettings.StartTime = ParseFloatValue(obj.NewValue);
                    break;
                case "Время окончания, сек":
                    parameters.TimeSettings.StopTime = ParseFloatValue(obj.NewValue);
                    break;
                case "Начальный шаг расчета, сек":
                    parameters.TimeSettings.InitTimeStep = ParseFloatValue(obj.NewValue);
                    break;
                case "Минимальный шаг расчета, сек":
                    parameters.TimeSettings.MinTimeStep = ParseFloatValue(obj.NewValue);
                    break;
                case "Максимальный шаг расчета, сек":
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
            if (obj.Header == "Тип")
                selectInstruction = obj.NewValue;
            else if (obj.Header.Contains("Выполнять"))
            {
                var name = obj.Header.Split(' ')[1];

                navigator.TrySearchNodes(NodeName.Calculations, out List<TreeNode> task);


                var selectedInstruction = task[0].Nodes.Cast<TreeNode>().FirstOrDefault(inst => inst.Text.Contains(name));

                var isExe =  bool.Parse(obj.NewValue);
                if (isExe)
                    selectedInstruction.Text = selectedInstruction.Text.Replace("пропустить", "выполнить");
                else
                    selectedInstruction.Text = selectedInstruction.Text.Replace("выполнить", "пропустить");
            }
            Navigator_SelectCompsEvent();
        }

        [Obsolete ("Отсутствует химические задачи, не протестировано")]
        private void ChangeChemicalTask(PropertyChangedEventArgs obj, ChemicalParameters cmp)
        {
            if(obj.Header == "Макс.концентр. (dCt max), %")
                cmp.ChemicalConvergence.Is_Switched_Cm = bool.Parse(obj.NewValue);
            else if(obj.Header == "Значение макс.концентр.")
                cmp.ChemicalConvergence.Cm = ParseFloatValue(obj.NewValue);
            else if (obj.Header == "Начальная концентрация, %")
                cmp.InitConcentration = ParseFloatValue(obj.NewValue);
        }

        private void ChangeTermalTask(PropertyChangedEventArgs obj, TermalParameters tmp)
        {
            if (obj.Header == "Макс. темп. (dTt max), C°")
                tmp.TermalConvergence.Is_Switched_Tm = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение макс. темп.")
                tmp.TermalConvergence.Tm = ParseFloatValue(obj.NewValue);
        }

        private void ChangeMechanicalTask(PropertyChangedEventArgs obj, MechanicalParameters mhp)
        {
            if (obj.Header == "Макс. разница dU, >0")
                mhp.MechanicalConvergence.DUm = ParseFloatValue(obj.NewValue);
            else if (obj.Header == "Макс. перемещения U, >0")
                mhp.MechanicalConvergence.Is_Switched_Um = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение макс. перемещения U")
                mhp.MechanicalConvergence.Um = ParseFloatValue(obj.NewValue);
            else if (obj.Header == "Пласт. деформации Si/St, >1")
                mhp.MechanicalConvergence.Is_Physically_NonLinear = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение пласт. деформации Si/St")
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