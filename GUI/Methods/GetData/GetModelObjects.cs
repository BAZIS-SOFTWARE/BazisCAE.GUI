using Model.Interfaces.ObjectsCollections;
using Model.Interfaces;
using Model;
using OperationalController.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public IEnumerable<IModelObject> GetModelObjects(string objects)
        {
            if (objects == "Объекты")
                return project.GetAllModelObjects();
            else if (objects == "Элементы")
                return project.GetModelElements();
            else if (objects == "Фигуры")
                return project.GetModelElements();
            else
            {
                var objType = objects.ToEnum<ObjType>();
                return project.GetModelObjects(objType);
            }
        }
    }
}
