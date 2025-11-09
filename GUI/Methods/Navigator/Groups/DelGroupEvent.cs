namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelGroupEvent(int grIndex)
        {
            var group = project.ModelData.GroupData[grIndex];
            project.DeleteModelGroup(group.Name);

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree();
        }
    }
}
