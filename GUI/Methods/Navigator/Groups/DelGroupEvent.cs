using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelGroupEvent()
        {
            var node = navigator.SelectedNode;
            var group = project.ModelData.GroupData[node.Index];
            var objType = group.ObjType;
            var number = group.Number;

            project.DeleteModelGroup(group.Name);
            OnGroupDeleted?.Invoke(objType, number);

            //удаляем узел
            node.Remove();

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree();
        }
    }
}
