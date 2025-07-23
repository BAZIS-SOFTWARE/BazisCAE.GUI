using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeCondProperties(PropertyChangedEventArgs obj, ICondData cond)
        {
            if (obj.Header.Contains("Группа"))
            {
                var group = project.GetAllModelGroups().First(x => x.Name == obj.NewValue.ToString());
                cond.Group = group;
            }
            else if (obj.Header == "Старт, сек.") cond.StartTime = float.Parse(obj.NewValue.ToString());
            else if (obj.Header == "Стоп, сек.") cond.StopTime = float.Parse(obj.NewValue.ToString());
            else
                panelProvider.UpdateObjectValue(obj.Header,
                    obj.NewValue.ToString(),
                    obj.OldValue.ToString());
        }

        private void ChangeMatProperties(PropertyChangedEventArgs obj, MatData matCond)
        {
            ChangeCondProperties(obj, matCond);
            if (obj.Header == "Материал")
            {
                matCond.MatName = obj.NewValue.ToString();
            }  
        }
    }
}
