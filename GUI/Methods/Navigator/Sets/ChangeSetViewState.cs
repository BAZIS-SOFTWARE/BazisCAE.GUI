using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene.VBO;
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
            var set = project.GetModelSetInfo(objType, setName);
            set.SetViewState(viewState);
            set.SetBackColor();
            // Сделать выключение vbo не получиться. Потеряется синхронизация.
            //VBOController.SwitchVBObject(setName, viewState);

            VBOController.DeleteVBObjects(setName);

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
