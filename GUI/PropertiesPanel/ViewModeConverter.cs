using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BazisGUI.PropertiesPanel
{
    public class ViewModeConverter
    {
        /// <summary>
        /// Метод для получения всех строковых значений для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEnumNames()
        {
            return Enum.GetNames(typeof(ViewMode)).ToList();
        }

        //public static string EnumToString(ViewMode viewMode)
        //{
        //    return viewMode.ToString();
        //}

        /// <summary>
        /// Метод для преобразование из строки в enum с проверкой на ошибки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ViewMode StringToEnum(string value)
        {
            if (Enum.IsDefined(typeof(ViewMode), value))
            {
                return (ViewMode)Enum.Parse(typeof(ViewMode), value);
            }
            else
            {
                Debug.WriteLine($"Ошибка: значение '{value}' не соответствует ни одному значению из ViewMode.");
                return ViewMode.Point;
            }
        }
    }
}
