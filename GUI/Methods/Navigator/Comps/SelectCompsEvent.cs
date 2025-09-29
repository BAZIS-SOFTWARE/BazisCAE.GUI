using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Project.TaskParameters;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectCompsEvent(NodeName arg1, string arg2)
        {
            //EditTSFFile(arg2.Split(' ')[1]); на время разработки храню
            try
            {
                /* TO DO
                 * При нажатии сформировать следующие строки
                    Расчеты - Список типов расчетов из тех что сформированы (comboBox)
                    Выполнить - checkBox
                 */

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }      
    }
}
