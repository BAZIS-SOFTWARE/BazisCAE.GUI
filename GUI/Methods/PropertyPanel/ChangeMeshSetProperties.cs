using BazisGUI.Extensions;
using BazisGUI.Navigator;
using BazisGUI.PropertiesPanel;
using BazisGUI.Scene.Interfaces;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeMeshSetProperties(PropertyChangedEventArgs obj, int dimm)
        {
            var setName = navigator.SelectedNode.Text.Split(' ')[1];
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
                PresentMeshData();
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
                    color = Color.FromName(newValue.Replace("Color [", "").Replace("]", ""));
                }

                if (_objectsSet != null)
                {
                    _objectsSet.SetColor(color);
                    ColorObjects(_objectsSet.ObjType.ToString());
                }

            }
            else if (obj.Header == "Представление")
            {
                var viewMode = obj.NewValue.ToString().ToEnum<ViewMode>();
                _objectsSet.SetViewMode(viewMode);

                ObjView objView;
                //var set = project.GetModelSetInfo(objType, setName);
                if (viewMode == ViewMode.Line)
                {
                    objView = ObjView.Lines;
                    //set.SetViewMode(ViewMode.Line);
                }

                else if (viewMode == ViewMode.Surface)
                {
                    objView = ObjView.Surface;
                    //set.SetViewMode(ViewMode.Surface);
                }

                else
                {
                    objView = ObjView.LinesSurface;
                    //set.SetViewMode(ViewMode.LineSurface);
                }

                VBOController.ChangeViewModeVBObjects(setName, objView);

                DisplayObjects();
            }
            else if(obj.Header == "Порядок точности")
            {
                SetElementsOrderEvent(int.Parse(obj.NewValue));
            }    
        }

        private void SetElementsOrderEvent(int obj)
        {
            
            var setName = navigator.SelectedNode.Text.Split(' ')[1];
            var objInfo = navigator.SelectedNode.Text.Split(' ')[0];
            
            var isExpand = navigator.SelectedNode.IsExpanded;

            var objType = objInfo.ToEnum<ObjType>();

            if (objType == ObjType.Элемент1D)
                project.ChangeMeshSetOrder(1, setName, obj);
            else if (objType == ObjType.Элемент2D)
                project.ChangeMeshSetOrder(2, setName, obj);
            else if (objType == ObjType.Элемент3D)
                project.ChangeMeshSetOrder(3, setName, obj);

            PresentMeshData();
            navigator.TrySearchNodes(NodeName.Mesh, out List<TreeNode> mesh);

            mesh.First().Collapse();
            mesh.First().Expand();


            if (isExpand)
            {
                var nodeName = navigator.SelectedNode.Name;
                var nodes = mesh.First().Nodes.Find(nodeName, false);
                nodes.FirstOrDefault(x => x.Text.Contains(setName))?.Expand();
            }

        }
    }
}
