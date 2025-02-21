using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using Model.Interfaces;
using PreProc.Interfaces;
using System;
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

        public static string ConvertToNavigatorNodeName(ObjType objType)
        {
            switch (objType)
            {
                case ObjType.Точка:
                    return "точки";
                case ObjType.Кривая:
                    return "кривые";
                case ObjType.Поверхность:
                    return "поверхности";
                case ObjType.Объем:
                    return "объемы";
                case ObjType.Узел:
                    return "узлы";
                case ObjType.Элемент1D:
                    return "элементы1D";
                case ObjType.Элемент2D:
                    return "элементы2D";
                default:
                    return "элементы3D";
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
    }
}
