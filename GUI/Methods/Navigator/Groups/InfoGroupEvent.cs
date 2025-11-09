
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_InfoGroupEvent(int obj)
        {
            var group = project.GetModelGroup(obj);
            console.PrintInfo(group.ToString(), Color.Black);
        }
    }
}
