using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void propertiesPanel_OnPropertyUpdate(BaseModule.PropertiesPanel.PropertyChangedEventArgs obj)
        {
            panelProvider.UpdateObjectValue(obj.Header, obj.NewValue.ToString(), obj.OldValue.ToString());
            
            // TO DO оптимизировать. Обновлять на дереве только те данные, которые на самом деле изменились
            PresentGeneralDataOnTree(project.GeneralData);
            PresentObjectsDataOnTree(project.ModelData.ObjectData);
            PresentGroupDataOnTree(project.ModelData.GroupData);

            //if (obj is TaskPage taskPage)
            PresentCondDataOnTree(project.GeneralData, project.TaskData);

        }
    }
}
