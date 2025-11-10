using BaseModule.PropertiesPanel;
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
            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }

            // TO DO реализация на 3. В дальнейшем нужно подумать о более
            // технологичной работе с визуализацией
            VBOController.DeleteVBObjects(ObjType.Узел.ToString());
            var ndPres = project.CreateModelObjectsPresentor(ObjType.Узел);
            var vbo = CreateVBObject(ndPres);
            VBOController.AddVbo(vbo);

            foreach (var set in group.Select(x => project.
GetModelSetInfo(x.ObjType, x.Number)).
Distinct(new DefaultSetInfoComparer()))
            {
                VBOController.DeleteVBObjects(set.Name);

                //if (set.ViewState)
                //{
                var pres = project.CreateModelObjectsPresentor(set);
                var vb = CreateVBObject(pres);
                VBOController.AddVbo(vb);
                //}
            }

            DisplayObjects();
        }
    }
}
