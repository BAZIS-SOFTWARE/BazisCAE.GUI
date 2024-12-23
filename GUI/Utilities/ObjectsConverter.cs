using Model.Interfaces;
using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI.Utilities
{
    public static class ObjectsConverter
    {
        public static ObjType ConvertToObjsType(Objects objects)
        {
            switch (objects)
            {
                case Objects.Точка:
                    return ObjType.Точка;
                case Objects.Линия:
                    return ObjType.Линия;
                case Objects.Элемент2D:
                    return ObjType.Элемент2D;
                case Objects.Элемент3D:
                    return ObjType.Элемент3D;
                default:
                    throw new Exception($"Ошибка конвертации объектов {objects}");
            }
        }
    }
}
