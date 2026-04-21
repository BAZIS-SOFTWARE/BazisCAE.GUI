using BazisGUI.Navigator;
using BazisGUI.PropertiesPanel;
using System;
using System.ComponentModel;

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
        /// <typeparam name="T">Тип графического компонента, ресурсы которого обозреваются в поисках нужной строки с именем name</typeparam>
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

        /// <summary>
        /// Получение подписи-предупреждения об ошибке отсутствия реализации на текущей языковой культуре
        /// </summary>
        /// <returns>Сообщение об ошибке, вызванной отсутствием реализации на текущей языковой культуре</returns>
        public static string GetMethodIsNotImplementedExceptionCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("MethodIsNotImplementedException");
        }

        /// <summary>
        /// Получение подписи "Старт" на текущей языковой культуре
        /// </summary>
        /// <returns>Строка с подписью "Старт" на текущей языковой культуре</returns>
        public static string GetStartCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("StartCaption");
        }

        /// <summary>
        /// Получение подписи "Стоп" на текущей языковой культуре
        /// </summary>
        /// <returns>Строка с подписью "Стоп" на текущей языковой культуре</returns>
        public static string GetStopCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("StopCaption");
        }

        /// <summary>
        /// Получение выбранного типа объектов на текущей языковой культуре
        /// </summary>
        /// <param name="select">Выбранный тип объектов</param>
        /// <returns>Строковое представление выбранного типа объектов на текущей языковой культуре</returns>
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

        public static string GetNavigatorNodeNameLocalization(NodeName nodeName)
        {
            switch (nodeName)
            {
                case NodeName.Geometry:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Geometry");
                case NodeName.Mesh:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Mesh");
                case NodeName.Sets:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Sets");
                case NodeName.Objects:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Objects");
                case NodeName.Groups:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Groups");
                case NodeName.NodesGroup:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.NodesGroup");
                case NodeName.ElementsGroup:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.ElementsGroup");
                case NodeName.Task:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Task");
                case NodeName.Material:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Material");
                case NodeName.Media:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Media");
                case NodeName.Heat:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Heat");
                case NodeName.Clamp:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Clamp");
                case NodeName.Load:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Load");
                case NodeName.Calculations:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Calculations");
                case NodeName.Calculation:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Calculation");
                case NodeName.Results:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Results");
                case NodeName.Result:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Result");
                case NodeName.Time:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Time");
                default:
                    return GetStringResourceByName<NavigatorControl>("Navigator.TreeView.Node.Text.Project");
            }
        }
    }
}
