using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control
{
    public class SetInfoConverter : PanelConverter
    {
        private readonly ISetInfo _objectsSet;
        public SetInfoConverter(ISetInfo obj)
        {
            _objectsSet = obj;
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", _objectsSet.Name, ValidationType.Text),
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
                RowProperty.CreateComboBox("Представление", _objectsSet.ViewMode.ToString(), Converters.GetEnumNames<ViewMode>().ToList())
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            if (header == "Имя") _objectsSet.Name = newValue;
            else if (header == "Цвет")
            {
                Color color;
                if (newValue.StartsWith("Color [A="))
                {
                    string[] parts = newValue.Trim('C', 'o', 'l', 'r', ' ', '[', ']').Split(',');
                    int a = int.Parse(parts[0].Split('=')[1]);
                    int r = int.Parse(parts[1].Split('=')[1]);
                    int g = int.Parse(parts[2].Split('=')[1]);
                    int b = int.Parse(parts[3].Split('=')[1]);
                    color = Color.FromArgb(a, r, g, b);
                }
                else
                {
                    color = Color.FromName(newValue.Replace("Color [", "").Replace("]", ""));
                }
                _objectsSet.SetColor(color);
            }
            else if (header == "Представление") _objectsSet.SetViewMode(Converters.StringToEnum<ViewMode>(newValue.ToString()));
        }
    }
}
