using Model.Interfaces.ObjectsCollections;
using Model.Interfaces;
using System.Collections.Generic;
using BazisGUI.Extensions;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public IEnumerable<ISetInfo> GetModelSetsInfo(string objects)
        {
            if (objects == "Объекты")
            {
                foreach (var item in project.GetModelSetsInfo(ObjType.Точка))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Кривая))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Поверхность))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Узел))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент1D))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент2D))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                    yield return item;

            }
            else if (objects == "Элементы")
            {
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент1D))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент2D))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                    yield return item;
            }

            else if (objects == "Фигуры")
            {
                foreach (var item in project.GetModelSetsInfo(ObjType.Точка))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Кривая))
                    yield return item;
                foreach (var item in project.GetModelSetsInfo(ObjType.Поверхность))
                    yield return item;
            }
            else
            {
                var objType = objects.ToEnum<ObjType>();
                foreach (var item in project.GetModelSetsInfo(objType))
                    yield return item;
            }
        }
    }
}
