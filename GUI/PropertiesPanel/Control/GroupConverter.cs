using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

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
            return new List < RowProperty > 
            {
                new RowProperty("Имя", _group.Name, () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
            };
        }

        public override void UpdateObject(string header, string newValue, string oldValue)
        {
            _group.Name = newValue.ToString();
        }
    }
}
