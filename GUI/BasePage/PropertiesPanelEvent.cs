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
        }
    }
}
