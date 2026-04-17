using Model.Interfaces;
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

        public static string GetMethodIsNotImplementedExceptionCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("MethodIsNotImplementedException");
        }

        public static string GetStartCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("StartCaption");
        }

        public static string GetStopCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("StopCaption");
        }

        public static string GetSelectionTypeLocalization(SelectionType select)
        {
            switch (select) 
            {
                case SelectionType.Points:
                    return GetStringResourceByName("btnSelect.Text.Points");
                case SelectionType.Curves:
                    return GetStringResourceByName("btnSelect.Text.Curves");
                case SelectionType.Surfaces:
                    return GetStringResourceByName("btnSelect.Text.Serfaces");
                case SelectionType.Nodes:
                    return GetStringResourceByName("btnSelect.Text.Nodes");
                case SelectionType.Elements1D:
                    return GetStringResourceByName("btnSelect.Text.Elements1D");
                case SelectionType.Elements2D:
                    return GetStringResourceByName("btnSelect.Text.Elements2D");
                case SelectionType.Elements3D:
                    return GetStringResourceByName("btnSelect.Text.Elements3D");
                default:
                    return GetStringResourceByName("btnSelect.Text.Objects");
            }
        }
    }
}
