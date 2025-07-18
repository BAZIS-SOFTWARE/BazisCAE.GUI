using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
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
            foreach (var iobj in group)
                iobj.ViewState = viewState;

            var vbobj = VBOController.FindVBObj(group.ObjType.ToString());
            if (vbobj == null)
                throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
            var viewMode = vbobj.ViewMode;

            VBOController.DeleteVBObjects(group.ObjType.ToString());
            var pres = project.CreateModelObjectsPresentor(group.ObjType);
            var vb = CreateVBObject(pres);
            vb.ViewMode = viewMode;
            VBOController.AddVbo(vb);

            DisplayObjects();
        }
    }
}
