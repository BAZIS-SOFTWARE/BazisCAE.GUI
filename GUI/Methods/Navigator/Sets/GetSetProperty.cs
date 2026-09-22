using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetSetProperty(ISetInfo _objectsSet)
        {
            var modelView = project.ModelView;
            return new List<RowProperty>
            {
               new RowProperty(SetPropertyKeys.Name.ToString(), Resources.Header_set_name, _objectsSet.Name, isReadOnly: true),

               new RowProperty(SetPropertyKeys.Color.ToString(), Resources.Header_set_color, modelView.GetSetColor(_objectsSet)),

               new RowProperty(SetPropertyKeys.View.ToString(), Resources.Header_set_view,
               new DropDownPropertyValue(modelView.GetViewMode(_objectsSet), Converters.GetEnumNames<ViewMode>()))
            };
        }
    }
}
