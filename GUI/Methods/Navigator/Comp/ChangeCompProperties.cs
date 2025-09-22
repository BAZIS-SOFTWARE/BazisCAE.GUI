using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Newtonsoft.Json;
using Project.TaskParameters;
using System;
using System.IO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeCompProperties(PropertyChangedEventArgs obj, string nodeText)
        {
            var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
            var parameters = ReadTaskParametersFromFile(nodeText.Split(' ')[1]);
            if (parameters is ChemicalParameters cmp) 
                ChangeChemicalTask(obj, cmp);
            else if (parameters is MechanicalParameters mhp) 
                ChangeMechanicalTask(obj, mhp);
            else if (parameters is TermalParameters tmp)
                ChangeTermalTask(obj, tmp);


            switch(obj.Header)
            {
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
            if(bool.TryParse(obj.NewValue, out bool res))
                    navigator_SelectTaskEvent(nodeName, nodeText);
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