using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelGroupEvent()
        {
            var node = navigator.SelectedNode;
            var group = project.ModelData.GroupData[node.Index];
            var number = group.Number;

            project.DeleteModelGroup(group.Name);
            OnGroupDeleted?.Invoke(number);

            //удаляем узел
            node.Remove();

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree();
        }
    }
}
