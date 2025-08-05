using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetSetProperty(ISetInfo _objectsSet)
        {
            return new List<RowProperty>
            {
               new RowProperty("Имя", _objectsSet.Name, null),
               new RowProperty( "Цвет", _objectsSet.Color,null),
               new RowProperty("Представление",_objectsSet.ViewMode,
               Converters.GetEnumNames<ViewMode>())
            };
        }
    }
}
