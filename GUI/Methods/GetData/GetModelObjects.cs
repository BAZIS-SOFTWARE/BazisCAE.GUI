using Model.Interfaces;
using System.Collections.Generic;
using BaseModule.Extensions;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public IEnumerable<IModelObject> GetModelObjects(string objects)
        {
            if (objects == "Объекты")
                return project.GetAllModelObjects();
            else if (objects == "Элементы")
                return project.GetAllModelElements();
            else
            {
                var objType = objects.ToEnum<ObjType>();
                return project.GetModelObjects(objType);
            }
        }
    }
}
