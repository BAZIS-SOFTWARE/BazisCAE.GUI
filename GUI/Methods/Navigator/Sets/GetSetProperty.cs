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
               new RowProperty("Имя", _objectsSet.Name),
               new RowProperty("Цвет", _objectsSet.Color),
               new RowProperty("Представление",new DropDownPropertyValue(_objectsSet.ViewMode,Converters.GetEnumNames<ViewMode>(), false))
            };
        }
    }
}
