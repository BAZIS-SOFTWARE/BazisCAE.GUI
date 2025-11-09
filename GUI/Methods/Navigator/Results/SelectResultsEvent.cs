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

            var rows = GetResultsProperties();



            //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);

            propertiesPanel.DrawTable(rows);
        }

        public List<RowProperty> GetResultsProperties()
        {
            List<RowProperty> rows = new List<RowProperty>();


            rows.Add(new RowProperty("Показывать поле", settingsConfig.ShowResultsField));
            rows.Add(new RowProperty("Показать значения в узлах", settingsConfig.ShowNodeResultsValue));
            rows.Add(new RowProperty("Показать значения в элементах", settingsConfig.ShowElementsResultsValue));
            rows.Add(new RowProperty("Усреднять результаты", settingsConfig.MergeResultsValue));
            rows.Add(new RowProperty("Показывать шкалу", settingsConfig.ShowResultsScale));

            if (settingsConfig.ShowResultsScale)
            {
                rows.Add(new RowProperty("Масштаб", settingsConfig.Scale_scale));
                rows.Add(new RowProperty("Уточнить значения", settingsConfig.IsScaleMaxMinManual));

                if (settingsConfig.IsScaleMaxMinManual)
                {
                    rows.Add(new RowProperty("Макс. значение", settingsConfig.Scale_MaxValue));
                    rows.Add(new RowProperty("Мин. значение", settingsConfig.Scale_MinValue));
                }

                rows.Add(new RowProperty("Точность", new NumericUpDownValue(settingsConfig.Scale_Precision, 0, 15, 0, 1)));
                rows.Add(new RowProperty("Интервалы", new NumericUpDownValue(settingsConfig.Scale_Intervals, 2, 10, 0, 1)));

                rows.Add(new RowProperty("Положение шкалы по Х",
                    new NumericUpDownValue(settingsConfig.Scale_X_Coord, 0, 2000, 0, 1)));
                rows.Add(new RowProperty("Положение шкалы по Y",
                    new NumericUpDownValue(settingsConfig.Scale_Y_Coord, 0, 2000, 0, 1)));
            }

            return rows;
        }
    }
}
