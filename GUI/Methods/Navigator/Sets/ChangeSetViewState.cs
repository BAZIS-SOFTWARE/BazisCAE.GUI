using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene.VBO;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
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
        private void ChangeSetViewState(string nodeText, NodeName nodeName, bool viewState)
        {
            ISetInfo set;

            if (nodeName == NodeName.Объемы)
            {
                set = project.GetModelSetInfo(ObjType.Поверхность, ObjType.Поверхность.ToString());

                foreach (var item in project.GetModelVolumes())
                {
                    foreach (var surface in item.GetSurfaceFigures())
                        surface.ViewState = viewState;
                }
            }
            else
            {
                var setName = nodeText.Split(' ')[1];
                if (nodeName == NodeName.Поверхности)
                {
                    var ar = nodeText.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);
                set = project.GetModelSetInfo(objType, setName);
                set.SetViewState(viewState);
                set.SetBackColor();
            }
            // Сделать выключение vbo не получиться. Потеряется синхронизация.
            //VBOController.SwitchVBObject(setName, viewState);

            VBOController.DeleteVBObjects(set.Name);

            if (viewState)
            {    
                var pres = project.CreateModelObjectsPresentor(set);
                var vb = CreateVBObject(pres);
                VBOController.AddVbo(vb);
            }

            DisplayObjects();
        }
    }
}
