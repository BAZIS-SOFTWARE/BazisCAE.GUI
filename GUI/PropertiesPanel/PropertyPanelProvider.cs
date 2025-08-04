using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using BazisGUI.PropertiesPanel.Control;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyPanelProvider
    {
        PanelConverter _converter { get; set; }

        public bool ValidationData(string tag, string newValue, out string corrected)
        {
            var type = tag.ToEnum<ValidationType>();
            corrected = newValue;
            if (type.HasFlag(ValidationType.Text))
            {
                if (newValue == null || newValue.Contains(" "))
                {
                    MessageBox.Show("Имя не должно содержать пробелов или быть пустым", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (type.HasFlag(ValidationType.Float))
            {
                if (newValue.Contains(" "))
                {
                    newValue = newValue.Replace(" ", "");
                }
                if (!float.TryParse(newValue, out _))
                {
                    MessageBox.Show("Не верный формат данных", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (type.HasFlag(ValidationType.PositiveOnly))
            {
                if (Convert.ToDouble(newValue) < 0)
                {
                    MessageBox.Show("Не допустимо отрицательное значение", "FormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            corrected = newValue;
            return true;
        }
        public void UpdateObjectValue(string header, string newValue, string oldValue)
        {
            _converter.UpdateObject(header, newValue);
        }
    }
}