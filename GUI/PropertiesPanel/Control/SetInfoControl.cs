using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control
{
    public class SetInfoControl : PanelConverter
    {
        private readonly ISetInfo _objectsSet;
        public SetInfoControl(ISetInfo obj) 
        {
            _objectsSet = obj;
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", _objectsSet.Name, () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
                    
                new RowProperty("Цвет", _objectsSet.Color.Name, () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    using (ColorDialog colorDialog = new ColorDialog())
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            return colorDialog.Color;
                        }
                    }
                    return cell.Value;
                },
                SequenceType.Before),

                new RowProperty("Представление", _objectsSet.ViewMode,
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(Converters.GetEnumNames().ToArray());
                    comboBoxCell.Value = _objectsSet.ViewMode;
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
            };
        }

        public override void UpdateObject(PropertyChangedEventArgs e)
        {
            if (e.Header == "Имя") _objectsSet.Name = e.NewValue.ToString();
            else if (e.Header == "Цвет") _objectsSet.SetColor((System.Drawing.Color)e.NewValue);
            else if (e.Header == "Представление") _objectsSet.SetViewMode(Converters.StringToEnum(e.NewValue.ToString()));
        }
    }
}
