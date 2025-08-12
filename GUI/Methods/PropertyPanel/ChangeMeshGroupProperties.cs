using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeMeshGroupProperties(PropertyChangedEventArgs obj, int index)
        {
            var grName = navigator.SelectedNode.Text.Split(' ')[0];
            var _objectsGr = project.GetModelGroup(index);
            if (obj.Header == "Имя")
                _objectsGr.Name = obj.NewValue.ToString();
        }

        private void ChangeMeshSetProperties(PropertyChangedEventArgs obj, int dimm)
        {
            var setName = navigator.SelectedNode.Text.Split(' ')[0];
            ISetInfo _objectsSet;
            if (dimm == 3)
                _objectsSet = project.GetModelSetInfo(ObjType.Элемент3D, setName);
            else if (dimm == 2)
                _objectsSet = project.GetModelSetInfo(ObjType.Элемент2D, setName);
            else
                _objectsSet = project.GetModelSetInfo(ObjType.Элемент1D, setName);

            if (obj.Header == "Имя")
            {
                project.ChangeMeshSetName(dimm,
                    obj.OldValue.ToString(),
                    obj.NewValue.ToString());
                PresentObjectsDataOnTree();
            }
            else if (obj.Header == "Цвет")
            {
                Color color;

                var newValue = obj.NewValue.ToString();
                if (newValue.StartsWith("Color [A="))
                {
                    string[] parts = newValue.Trim('C', 'o', 'l', 'r', ' ', '[', ']').Split(',');
                    int a = int.Parse(parts[0].Split('=')[1]);
                    int r = int.Parse(parts[1].Split('=')[1]);
                    int g = int.Parse(parts[2].Split('=')[1]);
                    int b = int.Parse(parts[3].Split('=')[1]);
                    color = Color.FromArgb(a, r, g, b);
                }
                else
                {
                    //(Color)ColorConverter.ConvertFromString()
                    color = Color.FromName(obj.NewValue.ToString());
                }

                if(_objectsSet != null)
                {
                    _objectsSet.SetColor(color);
                    ColorObjects(_objectsSet.ObjType.ToString());
                }

            }
            else if (obj.Header == "Представление")
                _objectsSet.SetViewMode(obj.NewValue.ToString().ToEnum<ViewMode>());

        }
    }
}
