using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowGroupEvent(int obj)
        {
            try
            {
                var group = project.GetModelGroup(obj);
                ChangeGroupViewState(group, true);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
