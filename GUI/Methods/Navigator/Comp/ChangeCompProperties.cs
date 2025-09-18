using BaseModule.Extensions;
using BaseModule.Navigator;
using Newtonsoft.Json;
using Project.TaskParameters;
using System.IO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private string _nodeText = string.Empty;
        private void ChangeCompProperties(BaseModule.PropertiesPanel.PropertyChangedEventArgs obj, string nodeText)
        {
            _nodeText = nodeText;
            var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
            //parameters = ReadTaskParametersFromFile(nodeText.Split(' ')[1]);
            if (parameters is ChemicalParameters cmp) 
            {

            }
            else if (parameters is MechanicalParameters mhp) 
            {
                ChangeMechanicalTask(obj, mhp);
            }
            SaveGeneralParametersToFile();
            navigator_SelectTaskEvent(nodeName, nodeText);
        }

        private void ChangeMechanicalTask(BaseModule.PropertiesPanel.PropertyChangedEventArgs obj, MechanicalParameters mhp)
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