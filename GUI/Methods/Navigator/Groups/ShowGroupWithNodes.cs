using BazisGUI.PropertiesPanel;
using Model.Interfaces.MeshObjects;
using Model.Interfaces;
using Model.Utilities;
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
        private void ShowGroupWithNodes(IGroup group)
        {
            //var group = project.GetModelGroup(obj);
            using (project.ModelView.BeginUpdate())
            {
                foreach (var iobj in group)
                {
                    var elem = (IElement)iobj;
                    project.ModelView.SetVisible(elem.ObjType, [elem.Number], true);
                    var numbers = elem.GetVertexes().Select(x => x.Number);
                    project.ModelView.SetVisible(ObjType.Узел, numbers, true);
                }
            }
        }
    }
}
