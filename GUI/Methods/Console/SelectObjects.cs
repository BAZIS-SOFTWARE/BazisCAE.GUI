using BazisGUI.Utilities;
using Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private static bool TryParseObjType(string value, out ObjType objType)
        {
            switch (value?.Trim().ToLowerInvariant())
            {
                case "point":
                    objType = ObjType.Точка;
                    return true;
                case "curve":
                    objType = ObjType.Кривая;
                    return true;
                case "surface":
                    objType = ObjType.Поверхность;
                    return true;
                    return true;
                case "node":
                    objType = ObjType.Узел;
                    return true;
                case "line":
                    objType = ObjType.Элемент1D;
                    return true;
                case "element2d":
                    objType = ObjType.Элемент2D;
                    return true;
                case "element3d":
                    objType = ObjType.Элемент3D;
                    return true;
                default:
                    objType = default;
                    return false;
            }
        }
        private async Task<List<int>> GetSelectedObjectNumbersAsync(ObjType objType)
        {
            SelectedObjects = Converters.ConvertObjTypeToSelectionType(objType);
            var selectedObjects = new List<int>();
            while (true)
            {
                var message =$@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

                var selectedObject = await SelectObjectAsync(objType, message);
                if (selectedObject is not IModelObject typedObject)
                    break;
                selectedObjects.Add(typedObject.Number);

                ResetObjectColor(objType);
            }

            return selectedObjects;
        }

        private void ResetObjectColor(ObjType objType)
        {
            var set = project?.GetModelSetsInfo(objType).FirstOrDefault();
            if (set == null)
                return;
            set.SetBackColor();
            var pres = project?.CreateModelObjectsPresentor(set);
            if (pres != null)
                SetVBObjectAttribute(pres, "цвет");
        }
    }
}
