using BaseModule.PropertiesPanel;
using Model.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control
{
    public class IGroupControl : PanelConverter
    {
        private readonly IGroup _group;

        public IGroupControl(IGroup obj)
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

        public override void UpdateObject(PropertyChangedEventArgs e)
        {
            _group.Name = e.NewValue.ToString();
        }
    }
}
