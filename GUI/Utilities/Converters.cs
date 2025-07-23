using BaseModule.Navigator;
using BaseModule.Results.GraphCreation;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using Model;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using PreProc.Interfaces;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI.Utilities
{
    public static class Converters
    {
        public static DataKind ConvertToDataKind(string dataKind)
        {
            DataKind objType;
            return Enum.TryParse(dataKind, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {dataKind}");
        }
        public static string ConvertToDBTablesNames(GraphObjects graphObjects)
        {
            switch (graphObjects)
            {
                case GraphObjects.Узел:
                    return "nodes";
                default:
                    return "elements";
            }
        }
        public static ObjType ConvertToObjsType(Objects objects)
        {
            switch (objects)
            {
                case Objects.Точка:
                    return ObjType.Точка;
                case Objects.Узел:
                    return ObjType.Узел;
                case Objects.Линия:
                    return ObjType.Кривая;
                case Objects.Элемент2D:
                    return ObjType.Элемент2D;
                case Objects.Элемент3D:
                    return ObjType.Элемент3D;
                default:
                    throw new Exception($"Ошибка конвертации объектов {objects}");
            }
        }

        public static ObjType ConvertToObjsType(string objects)
        {
            ObjType objType;
            return Enum.TryParse(objects, out objType) ? objType :
                throw new Exception($"Ошибка конвертации объектов {objects}");
        }

        public static NodeName ConvertToNavigatorNodeType(ObjType objType)
        {
            switch (objType)
            {
                case ObjType.Точка:
                    return NodeName.Точки;
                case ObjType.Кривая:
                    return NodeName.Кривые;
                case ObjType.Поверхность:
                    return NodeName.Поверхности;
                case ObjType.Узел:
                    return NodeName.Узлы;
                case ObjType.Элемент1D:
                    return NodeName.Элементы1D;
                case ObjType.Элемент2D:
                    return NodeName.Элементы2D;
                default:
                    return NodeName.Элементы3D;
            }
        }

        public static ObjType ConvertNavigatorNodeNameToObjType(NodeName navNodeName)
        {
            switch (navNodeName)
            {
                case NodeName.Точки:
                case NodeName.Точка: 
                    return ObjType.Точка;
                case NodeName.Кривые:
                case NodeName.Кривая:
                    return ObjType.Кривая;
                case NodeName.Поверхности:
                case NodeName.Поверхность:
                    return ObjType.Поверхность;
                case NodeName.Узлы:
                case NodeName.Узел:
                    return ObjType.Узел;
                case NodeName.Элементы1D:
                case NodeName.Элемент1D:
                    return ObjType.Элемент1D;
                case NodeName.Элементы2D:
                case NodeName.Элемент2D:
                    return ObjType.Элемент2D;
                default: return ObjType.Элемент3D;
            }
        }

        public static TaskKind ConvertToPreProcType(Tasks tasks)
        {
            switch (tasks)
            {
                case Tasks.химическая:
                    return TaskKind.химическая;
                case Tasks.термическая:
                    return TaskKind.термическая;
                case Tasks.механическая:
                    return TaskKind.механическая;
                case Tasks.химическая_и_термическая:
                    return TaskKind.термическая_химическая;          
                default:
                    return TaskKind.термическая_механическая;
            }
        }   

        /// <summary>
        /// Метод для получения всех строковых значений для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEnumNames<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T)).ToList();
        }


    }
}
