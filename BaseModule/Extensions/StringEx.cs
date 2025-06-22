using BaseModule.Navigator;
using System;

namespace BaseModule.Extensions
{
    public static class StringEx
    {
        /// <summary>
        /// Метод для преобразование из строки в enum с проверкой на ошибки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, out T result))
                return result;
            else throw new ArgumentException($"Ошибка: значение '{value}' не соответствует ни одному значению.");
        }
    }
}
