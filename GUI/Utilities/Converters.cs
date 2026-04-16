using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //public static NodeName ConvertToNavigatorNodeType(ObjType objType)
        //{
        //    switch (objType)
        //    {
        //        case ObjType.Точка:
        //            return NodeName.Точки;
        //        case ObjType.Кривая:
        //            return NodeName.Кривые;
        //        case ObjType.Поверхность:
        //            return NodeName.Поверхности;
        //        case ObjType.Узел:
        //            return NodeName.Узлы;
        //        case ObjType.Элемент1D:
        //            return NodeName.Элементы1D;
        //        case ObjType.Элемент2D:
        //            return NodeName.Элементы2D;
        //        default:
        //            return NodeName.Элементы3D;
        //    }
        //}

        //public static ObjType ConvertNavigatorNodeNameToObjType(NodeName navNodeName)
        //{
        //    switch (navNodeName)
        //    {
        //        case NodeName.Точки:
        //        case NodeName.Точка: 
        //            return ObjType.Точка;
        //        case NodeName.Кривые:
        //        case NodeName.Кривая:
        //            return ObjType.Кривая;
        //        case NodeName.Поверхности:
        //        case NodeName.Поверхность:
        //            return ObjType.Поверхность;
        //        case NodeName.Узлы:
        //        case NodeName.Узел:
        //            return ObjType.Узел;
        //        case NodeName.Элементы1D:
        //        case NodeName.Элемент1D:
        //            return ObjType.Элемент1D;
        //        case NodeName.Элементы2D:
        //        case NodeName.Элемент2D:
        //            return ObjType.Элемент2D;
        //        default: return ObjType.Элемент3D;
        //    }
        //}  

        /// <summary>
        /// Метод для получения всех строковых значений для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEnumNames<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T)).ToList();
        }

        public static ObjType ConvertSelectionTypeToObjType(SelectionType st)
        {
            switch (st)
            {
                case SelectionType.Points: return ObjType.Точка;
                case SelectionType.Curves: return ObjType.Кривая;
                case SelectionType.Surfaces: return ObjType.Поверхность;
                case SelectionType.Nodes: return ObjType.Узел;
                case SelectionType.Elements1D: return ObjType.Элемент1D;
                case SelectionType.Elements2D: return ObjType.Элемент2D;
                case SelectionType.Elements3D: return ObjType.Элемент3D;
                default:
                    throw new ArgumentException($"{Localization.Localization.GetStringResourceByName("ConvertFailCaption")}:{st.ToString()} -> ObjType");
            }
        }

        public static bool TryConvertSelectionTypeToObjType(SelectionType st, out ObjType res)
        {
            try
            {
                res = ConvertSelectionTypeToObjType(st);
                return true;
            }
            catch (Exception ex) 
            {
                res = ObjType.Узел;
                return false;
            }
        }

        public static SelectionType ConvertObjTypeToSelectionType(ObjType ot)
        {
            switch (ot)
            {
                case ObjType.Точка: return SelectionType.Points;
                case ObjType.Кривая: return SelectionType.Curves;
                case ObjType.Поверхность: return SelectionType.Surfaces;
                case ObjType.Узел: return SelectionType.Nodes;
                case ObjType.Элемент1D: return SelectionType.Elements1D;
                case ObjType.Элемент2D: return SelectionType.Elements2D;
                case ObjType.Элемент3D: return SelectionType.Elements3D;
                default: return SelectionType.Objects;
            }
        }
    }
}
