using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
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
        private void navigator_ShowObjectsEvent(NodeName obj)
        {
            ChangeObjectsViewState(obj,true);
        }

        private void navigator_HideObjectsEvent(NodeName obj)
        {
            ChangeObjectsViewState(obj, false);
        }

        private void ChangeObjectsViewState(NodeName obj, bool viewState)
        {
            var objType = Converters.ConvertNavigatorNodeNameToObjType(obj);
            foreach (var set in project.GetModelSetsInfo(objType))
            {
                set.SetViewState(viewState);
                set.SetBackColor();
                VBOController.DeleteVBObjects(set.Name);

                if (viewState)
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
