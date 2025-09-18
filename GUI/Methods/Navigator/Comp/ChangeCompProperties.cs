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
        private string _nodeText = string.Empty;
        private void ChangeCompProperties(PropertyChangedEventArgs obj, string nodeText)
        {
            _nodeText = nodeText;
            var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
            //parameters = ReadTaskParametersFromFile(nodeText.Split(' ')[1]);
            if (parameters is ChemicalParameters cmp) 
            {
                ChangeChemicalTask(obj, cmp);
            }
            else if (parameters is MechanicalParameters mhp) 
                ChangeMechanicalTask(obj, mhp);
            else if (parameters is TermalParameters tmp)
                ChangeTermalTask(obj, tmp);

            SaveGeneralParametersToFile();
            navigator_SelectTaskEvent(nodeName, nodeText);
        }

        [Obsolete ("Отсутствует химические задачи, не протестировано")]
        private void ChangeChemicalTask(PropertyChangedEventArgs obj, ChemicalParameters cmp)
        {
            if(obj.Header == "Макс.концентр. (dCt max), %")
                cmp.ChemicalConvergence.Is_Switched_Cm = bool.Parse(obj.NewValue);
            else if(obj.Header == "Значение макс.концентр.")
                cmp.ChemicalConvergence.Cm = float.Parse(obj.NewValue);
            else if (obj.Header == "Начальная концентрация, %")
                cmp.InitConcentration = float.Parse(obj.NewValue);
        }

        private void ChangeTermalTask(PropertyChangedEventArgs obj, TermalParameters tmp)
        {
            if (obj.Header == "Макс. темп. (dTt max), C°")
                tmp.TermalConvergence.Is_Switched_Tm = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение макс. темп.")
                tmp.TermalConvergence.Tm = float.Parse(obj.NewValue);
        }

        private void ChangeMechanicalTask(PropertyChangedEventArgs obj, MechanicalParameters mhp)
        {
            if (obj.Header == "Макс. разница dU, >0")
                mhp.MechanicalConvergence.DUm = float.Parse(obj.NewValue);
            else if (obj.Header == "Макс. перемещения U, >0")
                mhp.MechanicalConvergence.Is_Switched_Um = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение макс. перемещения U")
                mhp.MechanicalConvergence.Um = float.Parse(obj.NewValue);
            else if (obj.Header == "Пласт. деформации Si/St, >1")
                mhp.MechanicalConvergence.Is_Physically_NonLinear = bool.Parse(obj.NewValue);
            else if (obj.Header == "Значение пласт. деформации Si/St")
                mhp.MechanicalConvergence.PlasticityCriterion = float.Parse(obj.NewValue);
        }

        private void SaveGeneralParametersToFile()
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var parLine = JsonConvert.SerializeObject(parameters, settingsSerializer);
            var path = _nodeText.Split(' ')[1];
            File.WriteAllText(path, parLine);
        }
    }
}