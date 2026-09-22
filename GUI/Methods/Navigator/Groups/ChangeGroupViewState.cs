using Model.Interfaces;
using Model.Utilities;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeGroupViewState(IGroup group, bool viewState)
        {
            // TO DO сделать метод group.HideObjects() в целях инкапсуляции
            using (project.ModelView.BeginUpdate())
            {
                foreach (var objType in group.Select(x => x.ObjType).Distinct())
                {
                    var numbers = group.Where(x => x.ObjType == objType).Select(x => x.Number);
                    project.ModelView.SetVisible(objType, numbers, viewState);
                }
            }
        }
    }
}
