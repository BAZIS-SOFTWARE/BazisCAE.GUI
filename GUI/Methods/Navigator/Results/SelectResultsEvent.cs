using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;
using Project.Tasks;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectResultsEvent()
        {
            /*
             * TO DO
             * Показать значения в узлах (checkBox)
             * Показать значения в элементах (checkBox)
             * Усреднять результаты (checkBox)
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
            // настройки шкалы

            //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);

            propertiesPanel.DrawTable(rows);
        }
    }
}
