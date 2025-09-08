using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.PropertiesPanel.DataGridViewNumericUpDown;
using Project.Interfaces.Tasks;
using Project.Tasks;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectResultsEvent()
        {
            /*
             * TO DO

             * Показывать шкалу
             * Масштаб (TextBox)
             * Уточнить значения (checkBox)
             * Макс. значение (TextBox)
             * Мин. значение (TextBox)
             * Точность (NumericUpDown) тут нужно попробовать создать собственный cell
             *      на базе dataGridViewCell из коробки
             * Интервалы (NumericUpDown) как создать смотри выше
             * Положение шкалы по Х (NumericUpDown) как создать смотри выше
             * Положение шкалы по Y (NumericUpDown) как создать смотри выше
             */

            List<RowProperty> rows = new List<RowProperty>();


            rows.Add(new RowProperty("Показывать поле", settingsConfig.ShowResultsField));
            rows.Add(new RowProperty("Показать значения в узлах", settingsConfig.ShowNodeResultsValue));
            rows.Add(new RowProperty("Показать значения в элементах", settingsConfig.ShowElementsResultsValue));
            rows.Add(new RowProperty("Усреднять результаты", settingsConfig.MergeResultsValue));
            rows.Add(new RowProperty("Показывать шкалу", false));
            rows.Add(new RowProperty("Масштаб", 1));
            rows.Add(new RowProperty("Уточнить значения", false));
            rows.Add(new RowProperty("Макс. значение", 1));
            rows.Add(new RowProperty("Мин. значение", 0));
            rows.Add(new RowProperty("Точность", new NumericUpDownValue(4, 0, 15, 0, 1)));
            rows.Add(new RowProperty("Интервалы", new NumericUpDownValue(10, 2, 10, 0, 1)));

            rows.Add(new RowProperty("Положение шкалы по Х", new NumericUpDownValue(70, 0, 2000, 0, 1)));
            rows.Add(new RowProperty("Положение шкалы по Y", new NumericUpDownValue(170, 0, 2000, 0, 1)));

            //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);

            propertiesPanel.DrawTable(rows);
        }
    }
}
