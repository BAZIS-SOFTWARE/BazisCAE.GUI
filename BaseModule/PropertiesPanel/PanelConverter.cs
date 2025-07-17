using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    [ComVisible(false)]
    public abstract class PanelConverter
    {
        public virtual List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>();
        }

        public virtual void UpdateObject(string header, string newValue)
        {
            throw new NotImplementedException("Тип конвертера не определен");
        }

        /// <summary>
        /// Метод реализующий создание ячейки TextBox 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <param name="isReadOnly">По умолчанию ячейка доступна для редактирования</param>
        public RowProperty CreateTextBox(string header, string value, ValidationType validationType = ValidationType.None, bool isReadOnly = false)
        {
            return new RowProperty(header,
                new DataGridViewTextBoxCell() { Value = value },
            SequenceType.After, validationType, isReadOnly);
        }

        /// <summary>
        /// CreateComboBox
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <param name="availableValues"></param>
        /// <param name="isDropDown"></param>
        /// <param name="validationType"></param>
        /// <returns></returns>
        public RowProperty CreateComboBox(string header, string value, List<string> availableValues, bool isDropDown = false, ValidationType validationType = ValidationType.None)
        {
            var comboBoxCell = new DataGridViewComboBoxCell();
            comboBoxCell.Items.AddRange(availableValues.ToArray());
            comboBoxCell.Value = value;

            return new RowProperty(header, comboBoxCell
            , SequenceType.After, validationType, false, isDropDown, availableValues);
        }
    }
}
