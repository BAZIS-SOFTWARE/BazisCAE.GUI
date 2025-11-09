using BaseModule.Extensions;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowObjectEvent(string arg1, int arg3)
        {
            ShowHideObject(arg1, arg3, true);
        }


        private void navigator_HideObjectEvent(string arg1,  int arg3)
        {
            ShowHideObject(arg1, arg3, false);
        }
        private void navigator_DelObjectEvent(string arg1, int arg3)
        {

        }
        public void ShowHideObject(string objInfo ,int number,bool flag)
        {
            try
            {
                ISetInfo set;
                ObjType objType;

                // пока заглушим обработку объема
                if (objInfo.TryToEnum(out objType))
                {
                    //var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);
                    set = project.GetModelSetInfo(objType, number);
                    set.SetBackColor();

                    var obj = project.GetModelObject(objType, number);
                    obj.ViewState = flag;
                }
                else
                {
                    set = project.GetModelSetsInfo(ObjType.Поверхность).First();
                    set.SetBackColor();

                    var vol = project.GetModelVolumes().First(x => x.Number == number);

                    foreach (var item in vol.GetSurfaceFigures())
                        item.ViewState = flag;
                }


                VBOController.DeleteVBObjects(set.Name);
                set.SetBackColor();
                if (set.ViewState)
                {
                    var pre = project.CreateModelObjectsPresentor(set);
                    var vbo = CreateVBObject(pre);
                    VBOController.AddVbo(vbo);
                }

                DisplayObjects();             
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
