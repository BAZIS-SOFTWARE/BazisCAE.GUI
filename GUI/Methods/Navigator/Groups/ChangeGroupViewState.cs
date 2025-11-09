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
            foreach (var iobj in group)
                iobj.ViewState = viewState;


            foreach (var set in group.Select(x => project.
            GetModelSetInfo(x.ObjType, x.Number)).
            Distinct(new DefaultSetInfoComparer()))
            {
                VBOController.DeleteVBObjects(set.Name);

                if(set.ViewState)
                {
                    var pres = project.CreateModelObjectsPresentor(set);
                    var vb = CreateVBObject(pres);
                    VBOController.AddVbo(vb);
                }
            }

            DisplayObjects();
        }
    }
}
