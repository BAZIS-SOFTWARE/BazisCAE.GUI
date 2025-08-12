using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetGroupProperty(IGroup obj)
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", obj.Name)
            };
        }
    }
}