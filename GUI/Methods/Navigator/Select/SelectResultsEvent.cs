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
             * формирование свойств результатов
             */

            List<RowProperty> rows = new List<RowProperty>();


            rows.Add(new RowProperty("Показать поле", settingsConfig.ShowResultsField));


            //var _converter = DataConverter.CreateConverter(data, _funcDBNames, _matDBNames, allGroup);

            propertiesPanel.DrawTable(rows);
        }
    }
}
