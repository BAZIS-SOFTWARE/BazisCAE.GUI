using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelGroupEvent()
        {
            var node = navigator.SelectedNode;
            var group = project.ModelData.GroupData[node.Index];

            OnGroupDeleted?.Invoke(group.ObjType, group.Name);
            project.DeleteModelGroup(group.Name);

            //удаляем узел
            node.Remove();

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree();
        }
    }
}
