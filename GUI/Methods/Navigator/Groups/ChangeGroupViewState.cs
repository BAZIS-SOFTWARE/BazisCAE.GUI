using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Utilities;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
