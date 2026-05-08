using BazisGUI.Properties;
using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_FindFreeNodesEvent()
        {
            var freeNodes = project.FindFreeNodes();

            Invoke(new Action(() =>
            {
                console.PrintInfo($"{Resources.FindFreeNodesEvent_Found_Message} {freeNodes.Count()} {Resources.FindFreeNodesEvent_FreeNodes_Message}", Color.Black);

                if(freeNodes.Count() != 0)
                {
                    VBOController.DeleteAllVBObjects();
                    project.GetModelSetsInfo(ObjType.Узел).First().SetViewState(false);

                    foreach (var freeNode in freeNodes)
                        project.GetModelObject(ObjType.Узел, freeNode).ViewState = true;


                    var objsTypeStr = ObjType.Узел.ToString();
                    VBOController.DeleteVBObjects(objsTypeStr);

                    var pres = project.CreateModelObjectsPresentor(ObjType.Узел);

                    var vbo = CreateVBObject(pres);
                    VBOController.AddVbo(vbo);

                    DisplayObjects();
                }
            }));
        }
    }
}
