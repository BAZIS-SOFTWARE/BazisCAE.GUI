using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetSetProperty(ISetInfo _objectsSet)
        {
            return new List<RowProperty>
            {
               new RowProperty(SetPropertyKeys.Name.ToString(), Resources.Header_set_name, _objectsSet.Name),

               new RowProperty(SetPropertyKeys.Color.ToString(), Resources.Header_set_color, _objectsSet.Color),

               new RowProperty(SetPropertyKeys.View.ToString(), Resources.Header_set_view,
               new DropDownPropertyValue(_objectsSet.ViewMode,Converters.GetEnumNames<ViewMode>()))
            };
        }
    }
}
