using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelGroupEvent()
        {
            var node = navigator.SelectedNode;
            var group = project.ModelData.GroupData[node.Index];
            var name = group.Name;
            var objType = group.ObjType;

            project.DeleteModelGroup(group.Name);
            OnGroupDeleted?.Invoke(objType, name);

            //удаляем узел
            node.Remove();

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree();
        }
    }
}
