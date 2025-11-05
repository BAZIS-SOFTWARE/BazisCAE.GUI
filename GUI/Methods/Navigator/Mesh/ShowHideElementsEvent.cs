using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowElementsEvent(int obj,bool flag)
        {
            try
            {
                if (obj == 1)
                {
                    foreach (var item in project.GetModelSetsInfo(ObjType.Элемент1D))
                        NewMethod1(item, flag);
                }
                else if (obj == 2)
                {
                    foreach (var item in project.GetModelSetsInfo(ObjType.Элемент2D))
                        NewMethod1(item, flag);
                }
                else if (obj == 3)
                {
                    foreach (var item in project.GetModelSetsInfo(ObjType.Элемент3D))
                        NewMethod1(item, flag);
                }
                else if (obj == 0)
                {
                    foreach (var item in project.GetModelSetsInfo(ObjType.Узел))
                        NewMethod1(item, flag);
                }
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }      

        public void NewMethod1(ISetInfo item, bool state)
        {  
            VBOController.DeleteVBObjects(item.Name);

            item.SetViewState(state);
            if (state)
            {
                var pre = project.CreateModelObjectsPresentor(item);
                var vbo = CreateVBObject(pre);
                VBOController.AddVbo(vbo);
            }

        }
    }
}
