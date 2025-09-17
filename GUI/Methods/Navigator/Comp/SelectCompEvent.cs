using BaseModule.Navigator;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectTaskEvent(NodeName arg1, string arg2)
        {
            EditTSFFile(arg2.Split(' ')[1]);
        }
    }
}
