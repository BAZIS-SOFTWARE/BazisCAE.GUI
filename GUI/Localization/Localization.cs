using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Localization
{
    public static class Localization
    {
        /// <summary>
        /// Получение строкового ресурса из файла ресурсов BaseForm на текущей языковой культуре
        /// </summary>
        /// <param name="name">Имя строкового ресурса</param>
        /// <returns>Строковый ресурс из BaseForm.resx файла на текущей языковой культуре</returns>
        public static string GetStringResourceByName(string name)
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString(name);
        }

        /// <summary>
        /// Получение строкового ресурса из файла ресурсов типа T на текущей языковой культуре
        /// </summary>
        /// <typeparam name="T">Тип, ресурсы которого обозреваются в поисках нужного ресурса с именем name</typeparam>
        /// <param name="name">Имя искомого строкового ресурса</param>
        /// <returns>Строковый ресурс из T.resx файла на текущей языковой культуре</returns>
        public static string GetStringResourceByName<T>(string name)
        {
            var resources = new ComponentResourceManager(typeof(T));
            return resources.GetString(name);
        }

        /// <summary>
        /// Получить подпись об отсутствии искомого файла на текущей языковой культуре
        /// </summary>
        /// <returns>Строковая подпись на текущей языковой культуре</returns>
        public static string GetFileMissingCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("FileAbsenceCaption");
        }

        /// <summary>
        /// Получение подписи об ошибке на текущей языковой культуре
        /// </summary>
        /// <returns>Строковая подпись на текущей языковой культуре</returns>
        public static string GetErrorCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("ErrorCaption");
        }

        /// <summary>
        /// Получение подписи "Внимание"
        /// </summary>
        /// <returns>Строковая подпись на текущей языковой культуре</returns>
        public static string GetAttentionCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("AttentionCaption");
        }

        /// <summary>
        /// Получение стека сообщения об ошибке вместе со стеком на текущей языковой культуре
        /// </summary>
        /// <param name="ex">Возникшая ошибка</param>
        /// <returns>Строка с ошибкой и стеком вызовов на текущей языковой культуре</returns>
        public static string GetErrorWithStackMessage(Exception ex)
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return $"{ex.Message} {resources.GetString("StackTrace")}:{ex.StackTrace}";
        }
    }
}
