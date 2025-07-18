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
        private void ChangeSetViewState(string setName, ObjType objType, bool viewState)
        {
            project.GetModelSetInfo(objType, setName).SetViewState(viewState);

            VBOController.DeleteVBObjects(objType.ToString());

            if (project.GetModelObjects(objType).Any(x => x.ViewState == true))
            {
                var pres = project.CreateModelObjectsPresentor(objType);
                var vb = CreateVBObject(pres);
                VBOController.AddVbo(vb);
            }

            DisplayObjects();
        }
    }
}
