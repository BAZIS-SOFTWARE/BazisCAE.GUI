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

        public static NodeType ConvertToNavigatorNodeType(ObjType objType)
        {
            switch (objType)
            {
                case ObjType.Точка:
                    return NodeType.Точки;
                case ObjType.Кривая:
                    return NodeType.Кривые;
                case ObjType.Поверхность:
                    return NodeType.Поверхности;
                case ObjType.Объем:
                    return NodeType.Объемы;
                case ObjType.Узел:
                    return NodeType.Узлы;
                case ObjType.Элемент1D:
                    return NodeType.Элементы1D;
                case ObjType.Элемент2D:
                    return NodeType.Элементы2D;
                default:
                    return NodeType.Элементы3D;
            }
        }

        public static ObjType ConvertNavigatorNodeTypeToObjType(NodeType navNodeName)
        {
            switch (navNodeName)
            {
                case NodeType.Точки: return ObjType.Точка;
                case NodeType.Кривые: return ObjType.Кривая;
                case NodeType.Поверхности: return ObjType.Поверхность;
                case NodeType.Объемы: return ObjType.Объем;
                case NodeType.Узлы: return ObjType.Узел;
                case NodeType.Элементы1D: return ObjType.Элемент1D;
                case NodeType.Элементы2D: return ObjType.Элемент2D;
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
