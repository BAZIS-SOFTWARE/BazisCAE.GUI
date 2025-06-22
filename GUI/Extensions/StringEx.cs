using BaseModule.Navigator;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI.Extensions
{
    public static class StringEx
    {
        public static ObjType ToObjType(this string str)
        {
            ObjType objType;
            return Enum.TryParse(str, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {str}");
        }

        public static NodeType ToNodeType(this string str)
        {
            NodeType nodeType;
            return Enum.TryParse(str, out nodeType) ? nodeType :
                throw new Exception($"Ошибка конвертации объектов {str}");
        }

        public static DataKind ToDataKind(this string str)
        {
            DataKind objType;
            return Enum.TryParse(str, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {str}");
        }

        /// <summary>
        /// Метод для преобразование из строки в enum с проверкой на ошибки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(this string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, out T result))
                return result;
            else throw new ArgumentException($"Ошибка: значение '{value}' не соответствует ни одному значению.");
        }
    }
}
