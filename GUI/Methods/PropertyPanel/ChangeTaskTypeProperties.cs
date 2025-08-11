using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeTaskTypeProperties(PropertyChangedEventArgs obj, int index)
        {
            /*
             TO DO
            обратиться к выбранному узлу дерева navigator.SelectedNode.Text

             */
            var grName = navigator.SelectedNode.Text.Split(' ')[0];
            var _objectsGr = project.GetModelGroup(index);
            if (obj.Header == "Имя")
                _objectsGr.Name = obj.NewValue.ToString();
        }

        private void ChangeTaskKindProperties(PropertyChangedEventArgs obj, int index)
        {
            var grName = navigator.SelectedNode.Text.Split(' ')[0];
            var _objectsGr = project.GetModelGroup(index);
            if (obj.Header == "Имя")
                _objectsGr.Name = obj.NewValue.ToString();
        }
    }
}
