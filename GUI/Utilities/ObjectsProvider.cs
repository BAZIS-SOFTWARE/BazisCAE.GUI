using Model;
using Model.Interfaces;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Utilities
{
    public static class ObjectsProvider
    {
        public static IEnumerable<IModelObject> SelectorProvider(IObjectsData objectsData, string objects)
        {
            if (objects == "Объекты")
                return objectsData.GetAllObjects();
            else if (objects == "Элементы")
                return objectsData.GetAllElements();
            else if (objects == "Фигуры")
                return objectsData.GetAllElements();
            else
            {
                var objType = ObjectsConverter.ConvertToObjsType(objects);
                return objectsData.GetObjects(objType);
            }
        }
    }
}
