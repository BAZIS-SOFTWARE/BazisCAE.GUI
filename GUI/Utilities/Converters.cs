using BaseModule.Navigator;
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

        public static ComplexTaskType ConvertToPreProcType(Tasks tasks)
        {
            switch (tasks)
            {
                case Tasks.химическая:
                    return ComplexTaskType.химическая;
                case Tasks.термическая:
                    return ComplexTaskType.термическая;
                case Tasks.механическая:
                    return ComplexTaskType.механическая;
                case Tasks.химическая_и_термическая:
                    return ComplexTaskType.термическая_химическая;          
                default:
                    return ComplexTaskType.термическая_механическая;
            }
        }

        public static GeneralInfo ConvertToNavigatorGeneralInfo(IGeneralData generalData)
        {
            return new GeneralInfo()
            {
                Name = generalData.Name,
                Path = generalData.Path,
                Comments = generalData.Comments,

                Materials = generalData.Materials,
                Functions = generalData.Functions,
                TaskType = generalData.TaskType.ToString()
            };
        }

        public static ModelInfo ConvertToNavigatorModelInfo(IModelData modelData)
        {
            var modelInfo = new ModelInfo();
            foreach (var group in modelData.GroupData)
            {
                var grInfo = new GroupInfo()
                {
                    Name = group.Name,
                    NodeType = ConvertToNavigatorNodeType(group.ObjType)
                };
                modelInfo.groups.Add(grInfo);
            }

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                foreach (var itemInfo in modelData.ObjectData.GetSetsInfo(item))
                {
                    var setInfo = new SetInfo()
                    {
                        Name = itemInfo.Name,
                        NodeType = ConvertToNavigatorNodeType(itemInfo.ObjType),
                        NumberOfObjects = itemInfo.NumberOfObjects
                    };

                    modelInfo.sets.Add(setInfo);
                }
            }

            return modelInfo;
        }

        /// <summary>
        /// Метод для получения всех строковых значений для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEnumNames()
        {
            return Enum.GetNames(typeof(ViewMode)).ToList();
        }

        /// <summary>
        /// Метод для преобразование из строки в enum с проверкой на ошибки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ViewMode StringToEnum(string value)
        {
            if (Enum.TryParse<ViewMode>(value,out var result) && Enum.IsDefined(typeof(ViewMode), result)) 
                return result;
            else throw new ArgumentException($"Ошибка: значение '{value}' не соответствует ни одному значению из ViewMode.");
        }
    }
}
