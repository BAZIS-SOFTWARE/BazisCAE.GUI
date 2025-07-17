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
        private void navigator_DelSetEvent(NodeType nodeType, string setName)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);

            project.DeleteModelSet(objType, setName);
            VBOController.DeleteVBObjects(objType.ToString());

            PresentGroupDataOnTree();
            PresentCondDataOnTree();

            var ndPres = project.CreateModelObjectsPresentor(objType);
            CreateVBObject(ndPres);
            DisplayObjects();
        }
    }
}
