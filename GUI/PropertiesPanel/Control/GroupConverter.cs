using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System.Collections.Generic;

namespace BazisGUI.PropertiesPanel.Control
{
    public class GroupConverter : PanelConverter
    {
        private readonly IGroup _group;

        public GroupConverter(IGroup obj)
        {
            _group = obj;
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", _group.Name, null)
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            _group.Name = newValue.ToString();
        }
    }
}
